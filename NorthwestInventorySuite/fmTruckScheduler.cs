using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace NorthwestInventoryManager
{
    public partial class fmTruckScheduler : Form
    {
        public fmTruckScheduler()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newTruckToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Globals.FM_NEW_TRUCK = new fmNewTruck();
            Globals.FM_NEW_TRUCK.Show();
        }

        public void LoadTruck(string tId, string pId)
        {

            cbPallet.Items.Clear();
            dgTruck.Rows.Clear();
            MySqlDataReader rdr = null;

            string description = "";
            string shipper_id = "";

            string qry = "SELECT DESCRIPTION, SHIPPER_ID FROM truck WHERE ID = '" + tId + "';";
            tbTId.Text = tId;
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0))
                    tbDesc.Text = description = rdr.GetString(0);
                if (!rdr.IsDBNull(1))
                    cbCarrier.Text = shipper_id = rdr.GetString(1);
            }

            qry = "SELECT ID FROM pallet WHERE TRUCK_ID = '" + tId + "';";
            tbTId.Text = tId;
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0)) cbPallet.Items.Add(rdr.GetString(0));
            }

            string id = "";
            string pallet = "";
            string part = "";
            string qty = "";
            string order = "";
            string line = "";

            qry = "SELECT ID, PALLET_ID, PART_ID, QTY, ORDER_ID, ORD_LINE_NO FROM box WHERE TRUCK_ID = '" + tId;
            if (Convert.ToInt32(pId) > 0)
                qry = qry + "' AND PALLET_ID = " + pId.ToString() + ";";
            else
                qry = qry + "';";

            tbTId.Text = tId;
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0)) id = rdr.GetString(0);
                if (!rdr.IsDBNull(1)) pallet = rdr.GetString(1);
                if (!rdr.IsDBNull(1)) part = rdr.GetString(2);
                if (!rdr.IsDBNull(1)) qty = rdr.GetString(3);
                if (!rdr.IsDBNull(1)) order = rdr.GetString(4);
                if (!rdr.IsDBNull(1)) line = rdr.GetString(5);

                string[] row = { id, pallet, part, qty, order, line };
                dgTruck.Rows.Add(row);
                Refresh();
            }

            MysqlInterface.close();
        }

        private void tbOrder_Leave(object sender, EventArgs e)
        {
            MySqlDataReader rdr = null;

            int lineno = 0;
            string part;
            int qty;

            cbLine.Items.Clear();
            dgOrderLine.Rows.Clear();
            string qry = "SELECT line_no, part_id, ordered_qty FROM cust_order_line WHERE CUST_ORDER_ID = '" + tbOrder.Text + "';";
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0))
                {
                    lineno = rdr.GetInt32(0);
                    part = rdr.GetString(1);
                    qty = rdr.GetInt32(2);
                    string[] row = { lineno.ToString(), part, qty.ToString() };
                    dgOrderLine.Rows.Add(row);

                    cbLine.Items.Add(lineno.ToString());
                }
            }

            MysqlInterface.close();
        }

        private int GetCurrentBox()
        {

            return Globals.GetCurrentBox();
        }

        private void UpdateBoxNum(int n)
        {
            string host = MysqlInterface.host;
            string dbase = MysqlInterface.dbase;
            string user = MysqlInterface.user;
            string password = MysqlInterface.password;

            MySqlConnection con = null;
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

            con = new MySqlConnection(str);
            con.Open();


            cmd.Connection = con;
            cmd.CommandText = "UPDATE current_values SET box_id = '" + n.ToString() + "';";
            int numRowsUpdated = cmd.ExecuteNonQuery();
            
        }

        private void btLoadOrder_Click(object sender, EventArgs e)
        {

            int boxnum = GetCurrentBox();
            MySqlDataReader rdr = null;

            int lineno = 0;
            string part = "";
            double qty = 0.0;
            cbLine.Items.Clear();
            string qry = "SELECT line_no, part_id, ordered_qty FROM cust_order_line WHERE CUST_ORDER_ID = '" + tbOrder.Text + "';";
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0))
                {
                    lineno = rdr.GetInt32(0);
                    part = rdr.GetString(1);
                    qty = rdr.GetDouble(2);

                    for (int i = 0; i < qty; i++)
                    {
                        boxnum++;
                        string[] row = { boxnum.ToString(), "1", part, "1", tbOrder.Text, lineno.ToString() };
                        dgTruck.Rows.Add(row);
                        /*boxnum++;
                        string[] row2 = { boxnum.ToString(), "1", part, "1", tbOrder.Text, lineno.ToString() };
                        dgTruck.Rows.Add(row2);*/
                    }
                }
            }

            MysqlInterface.close();

            UpdateBoxNum(boxnum);
        }

        private void UpdateLine(int index)
        {

            string id = dgTruck.Rows[index].Cells["cID"].Value.ToString();
            string truckid = tbTId.Text;
            string palletid = dgTruck.Rows[index].Cells["cPallet"].Value.ToString();
            string partid = dgTruck.Rows[index].Cells["cPartId"].Value.ToString();
            string qty = dgTruck.Rows[index].Cells["cQty"].Value.ToString();
            string orderid = dgTruck.Rows[index].Cells["cOrderId"].Value.ToString();
            string lineno = dgTruck.Rows[index].Cells["cOrderLine"].Value.ToString();

            try
            {
                string query = "UPDATE box SET truck_id = '" + truckid +
                    "', pallet_id = '" + palletid + "', part_id = " + partid + "', qty = " + qty + "', order_id = " 
                    + orderid + "', ord_line_no = " + lineno +
                    " WHERE id = '" + id + ";";
                MysqlInterface.ExecuteQuery(query);
                // int numRowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
            finally
            {
            }
        }

        private void AddLine(int index)
        {
            string id = dgTruck.Rows[index].Cells["cID"].Value.ToString();
            string truckid = tbTId.Text;
            string palletid = dgTruck.Rows[index].Cells["cPallet"].Value.ToString();
            string partid = dgTruck.Rows[index].Cells["cPartId"].Value.ToString();
            string qty = dgTruck.Rows[index].Cells["cQty"].Value.ToString();
            string orderid = dgTruck.Rows[index].Cells["cOrderId"].Value.ToString();
            string lineno = dgTruck.Rows[index].Cells["cOrderLine"].Value.ToString();

            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string host = MysqlInterface.host;
            string dbase = MysqlInterface.dbase;
            string user = MysqlInterface.user;
            string password = MysqlInterface.password;

            String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

            con = new MySqlConnection(str);
            con.Open(); //open the connection
            String cmdText = "INSERT INTO box (id, truck_id, pallet_id, part_id, qty, order_id, ord_line_no)" +
            "VALUES(@id, @truck_id, @pallet_id, @part_id, @qty, @order_id, @order_line_no)";

            cmd = new MySqlCommand(cmdText, con);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@truck_id", truckid);
            cmd.Parameters.AddWithValue("@pallet_id", palletid);
            cmd.Parameters.AddWithValue("@part_id", partid);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@order_id", orderid);
            cmd.Parameters.AddWithValue("@order_line_no", lineno);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string boxnum = "";

            int rcount = dgTruck.Rows.Count;

            for (int i = 0; i < rcount - 1; i++)
            {

                try
                {
                    MySqlDataReader rdr = null;
                    int count = 0;


                    string tid = tbTId.Text;
                    boxnum = dgTruck.Rows[i].Cells["cID"].Value.ToString();
                    string qry = "SELECT count(id) FROM box where id = '" + boxnum + "';";
                    rdr = MysqlInterface.DoQuery(qry);
                    if (rdr == null || rdr.IsClosed)
                    {
                        MessageBox.Show("Invalid Reader Saving Cust Order Line");
                        break;
                    }

                    while (rdr.Read())
                        count = rdr.GetInt32(0);

                    if (count > 0)
                        UpdateLine(i);
                    else
                        AddLine(i);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("OrderLine Error: {0}", ex.ToString());

                }
                finally
                {
                    MysqlInterface.close();
                }
            }
        }

        private void printLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string oid = tbTId.Text;
            Globals.FM_FULL_LABEL = new fmFullLabel(oid);
            Globals.FM_FULL_LABEL.Show();
        }

        private void btLoadTruck_Click(object sender, EventArgs e)
        {
            LoadTruck(tbTId.Text, "0");
        }

        private void btLoadPallet_Click(object sender, EventArgs e)
        {
            LoadTruck(tbTId.Text, cbPallet.Text);
        }


    }
}
