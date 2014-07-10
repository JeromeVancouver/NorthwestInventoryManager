using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace NorthwestInventoryManager
{
    public partial class fmAdjustment : Form
    {
        int AdCount;

        public fmAdjustment()
        {
            InitializeComponent();
            AdCount = 0;
        }

        public void ChangePart()
        {
            tbPartID.Text = Globals.part;
        }

        public int GetPartIndex(string id)
        {
            int count = 0;

            count = Globals.PART_ARRAY.GetLength(0);
            for (int i = 0; i < count; i++)
                if (Globals.PART_ARRAY[i, 0] == id)
                    return i;
            return -1;
        }

        private void tbPartID_Leave(object sender, EventArgs e)
        {
            string curPart = Globals.part = tbPartID.Text;
            Globals.FM_PART_LOOKUP = new fmPartLookup("Adjustment", curPart);
            Globals.FM_PART_LOOKUP.ShowDialog();
            Globals.FM_PART_LOOKUP.BringToFront();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            dgAdjustment.Rows.Add();
            int index = GetPartIndex(Globals.part);

            dgAdjustment.Rows[AdCount].Cells[0].Value = Globals.part;

            string desc = "";
            string price = "";

            desc = Globals.PART_ARRAY[index, 1];
            price = Globals.PART_ARRAY[index, 4];
            dgAdjustment.Rows[AdCount].Cells[1].Value = desc;
            dgAdjustment.Rows[AdCount].Cells[2].Value = tbQty.Text;
            dgAdjustment.Rows[AdCount].Cells[3].Value = cbCode.Text;
            AdCount++;
        }


        private void ClearForm()
        {
            tbQty.Text = "";
            tbPartID.Text = "";
            cbCode.Text = "";
            dgAdjustment.Rows.Clear();
            AdCount = 0;
        }


        private void UpdateInventory(string part, int qty)
        {
            MySqlDataReader rdr = null;
            string qry = "SELECT qty_on_hand FROM part where id = '" + part + "';";
            rdr = MysqlInterface.DoQuery(qry);
            float inv_qty = 0;
            float new_inv_qty = 0.0f;
            string update_qry = "";
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0))
                {
                    inv_qty = rdr.GetFloat(0);
                    new_inv_qty = inv_qty + (qty);
                    update_qry = update_qry + "UPDATE part SET qty_on_hand = " + Convert.ToString(new_inv_qty) + " WHERE id = '" + part + "';";
                }
            }

            MysqlInterface.ExecuteQuery(update_qry);
        }

        private void btCommit_Click(object sender, EventArgs e)
        {
            int index = 0;
            MySqlConnection con = null;
            MySqlCommand cmd = null;
            try
            {
                string pID = tbPartID.Text;
                string qty = tbQty.Text;
                DateTime tDate = DateTime.Today;
                string specs = cbCode.Text;
                string uID = Globals.USER;

                for (int i = 0; i < AdCount; i++)
                {
                    index = i;

                    pID = dgAdjustment.Rows[index].Cells[0].Value.ToString();
                    qty = dgAdjustment.Rows[index].Cells[2].Value.ToString();
                    specs = dgAdjustment.Rows[index].Cells[3].Value.ToString();

                    string host = MysqlInterface.host;
                    string dbase = MysqlInterface.dbase;
                    string user = MysqlInterface.user;
                    string password = MysqlInterface.password;

                    String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                    con = new MySqlConnection(str);
                    con.Open(); //open the connection
                    String cmdText = "INSERT INTO inventory_trans (part_id, qty, date, specs, user_id)" +
                    "VALUES(@part_id, @qty, @date, @specs, @user_id)";

                    cmd = new MySqlCommand(cmdText, con);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@part_id", pID);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@date", tDate);
                    cmd.Parameters.AddWithValue("@specs", specs);
                    cmd.Parameters.AddWithValue("@user_id", uID);
                    cmd.ExecuteNonQuery();
                }

                for (int i = 0; i < AdCount; i++)
                {
                    index = i;
                    pID = dgAdjustment.Rows[index].Cells[0].Value.ToString();
                    qty = dgAdjustment.Rows[index].Cells[2].Value.ToString();
                    UpdateInventory(pID, Convert.ToInt32(qty));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Saving Order Line");
            }
            finally
            {
                cmd.Dispose();
                con.Dispose();
                ClearForm();
                MessageBox.Show("Adjustments Committed");
            }
        }


    }
}
