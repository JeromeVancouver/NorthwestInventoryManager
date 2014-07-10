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
    public partial class fmSubstitution : Form
    {
        int SubCount;

        public fmSubstitution()
        {
            InitializeComponent();
            SubCount = 0;
        }

        private void tbUsedPart_Leave(object sender, EventArgs e)
        {
            string curPart;
            curPart = Globals.part = tbUsedPart.Text;
            Globals.FM_PART_LOOKUP = new fmPartLookup("SubUsed", curPart);
            Globals.FM_PART_LOOKUP.ShowDialog();
            Globals.FM_PART_LOOKUP.BringToFront();
        }

        private void tbSubPart_Leave(object sender, EventArgs e)
        {
            string curPart;
            curPart = Globals.part = tbSubPart.Text;
            Globals.FM_PART_LOOKUP = new fmPartLookup("SubSub", curPart);
            Globals.FM_PART_LOOKUP.ShowDialog();
            Globals.FM_PART_LOOKUP.BringToFront();
        }

        public void ChangeUsed()
        {
            tbUsedPart.Text = Globals.part;
        }

        public void ChangeSub()
        {
            tbSubPart.Text = Globals.part;
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

        private void btAdd_Click(object sender, EventArgs e)
        {
            dgAdjustment.Rows.Add();
            int index = GetPartIndex(tbUsedPart.Text);

            dgAdjustment.Rows[SubCount].Cells[0].Value = tbUsedPart.Text;

            string desc = "";
            string price = "";

            desc = Globals.PART_ARRAY[index, 1];
            price = Globals.PART_ARRAY[index, 4];
            dgAdjustment.Rows[SubCount].Cells[1].Value = desc;
            dgAdjustment.Rows[SubCount].Cells[2].Value = tbUsedQty.Text;
            dgAdjustment.Rows[SubCount].Cells[3].Value = "ORDER: " + tbRefNum.Text;
            SubCount++;

            dgAdjustment.Rows.Add();
            index = GetPartIndex(tbSubPart.Text);

            dgAdjustment.Rows[SubCount].Cells[0].Value = tbSubPart.Text;

            desc = Globals.PART_ARRAY[index, 1];
            price = Globals.PART_ARRAY[index, 4];
            dgAdjustment.Rows[SubCount].Cells[1].Value = desc;
            dgAdjustment.Rows[SubCount].Cells[2].Value = "-" + tbSubQty.Text;
            dgAdjustment.Rows[SubCount].Cells[3].Value = "ORDER: " + tbRefNum.Text;
            SubCount++;
        }

        private void ClearForm()
        {
            tbRefNum.Text = "";
            tbSubPart.Text = "";
            tbSubQty.Text = "";
            tbUsedQty.Text = "";
            tbSubQty.Text = "";
            dgAdjustment.Rows.Clear();
            SubCount = 0;
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
                string pID = "";
                string qty = "";
                DateTime tDate = DateTime.Today;
                string specs = "";
                string uID = Globals.USER;

                for (int i = 0; i < SubCount; i++)
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

                for (int i = 0; i < SubCount; i++)
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
