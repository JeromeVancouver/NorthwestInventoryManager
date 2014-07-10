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
    public partial class fmPOReceipt : Form
    {
        int LINE;

        public fmPOReceipt()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadCustomerOrderLine(string oid, bool shipped)
        {

            dgOrderForm.Rows.Clear();
            LINE = 0;
            try
            {
                MySqlDataReader rdr = null;


                string sqlqry = "SELECT line_no, part_id, description, ordered_qty, received_qty, backordered_qty, unit_price, gst, pst FROM po_line " +
                                        "where po_id = '" + oid + "';";
                rdr = MysqlInterface.DoQuery(sqlqry);

                int line_no = 1;
                string part_id = "";
                double ordered_qty = 0;
                double shipped_qty = 0;
                double backordered = 0;
                float unit_price = 0.0f;
                string desc = "";
                double gst = 0.0;
                double pst = 0.0;
                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        if (!rdr.IsDBNull(0))
                        {
                            if (!rdr.IsDBNull(0)) line_no = rdr.GetInt32(0);
                            if (!rdr.IsDBNull(1)) part_id = rdr.GetString(1);
                            if (!rdr.IsDBNull(2)) desc = rdr.GetString(2);
                            if (!rdr.IsDBNull(3)) ordered_qty = Math.Round(rdr.GetDouble(3), 3);
                            if (!rdr.IsDBNull(4)) shipped_qty = Math.Round(rdr.GetDouble(4), 3);
                            if (!rdr.IsDBNull(5)) backordered = Math.Round(rdr.GetDouble(5), 3);
                            if (!rdr.IsDBNull(6)) unit_price = rdr.GetFloat(6);
                            if (!rdr.IsDBNull(7)) gst = Math.Round(rdr.GetDouble(7), 2);
                            if (!rdr.IsDBNull(8)) pst = Math.Round(rdr.GetDouble(8), 2);

                            if (!shipped)
                                dgOrderForm.Rows.Add(line_no.ToString(), part_id, desc, ordered_qty.ToString(), ordered_qty.ToString(), "0", unit_price.ToString(), gst.ToString(), pst.ToString());
                            else
                                dgOrderForm.Rows.Add(line_no.ToString(), part_id, desc, ordered_qty.ToString(), shipped_qty.ToString(), backordered.ToString(), unit_price.ToString(), gst.ToString(), pst.ToString());
                            LINE++;
                        }

                    }
                }
                MysqlInterface.close();


            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                MysqlInterface.close();
            }
        }

        public void ChangeIndex(string oid)
        {
            string status = "";
            tbOrderId.Text = oid;
            DateTime oDate = DateTime.Today;
            DateTime dDate = DateTime.Today;
            DateTime aDate = DateTime.Today;

            try
            {
                MySqlDataReader rdr = null;
                string query = "SELECT vendor_id, vendor_po, shipto_id, shipper_id, fob, state, order_date, desired_receive_date, actual_receive_date, notes FROM purchase_order where id = '" + oid.ToString() + "';";
                rdr = MysqlInterface.DoQuery(query);


                while (rdr.Read())
                {

                    if (!rdr.IsDBNull(0)) cbCustomer.Text = rdr.GetString(0);
                    if (!rdr.IsDBNull(1)) tbCustPO.Text = rdr.GetString(1);
                    if (!rdr.IsDBNull(2)) cbShipTo.Text = rdr.GetString(2);
                    if (!rdr.IsDBNull(3)) cbCarrier.Text = rdr.GetString(3);
                    if (!rdr.IsDBNull(4)) tbFOB.Text = rdr.GetString(4);
                    if (!rdr.IsDBNull(5)) tbStatus.Text = status = rdr.GetString(5);
                    if (!rdr.IsDBNull(6)) oDate = rdr.GetDateTime(6);
                    if (!rdr.IsDBNull(7)) dDate = rdr.GetDateTime(7);
                    if (!rdr.IsDBNull(8)) aDate = rdr.GetDateTime(8);
                    if (!rdr.IsDBNull(9)) tbNotes.Text = rdr.GetString(9);

                }

                dtOrderDate.Text = oDate.ToString();
                dtDesiredShip.Text = dDate.ToString();
                if (status != "Recieved")
                    aDate = DateTime.Today;
                dtActualShip.Text = aDate.ToString();



            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                MysqlInterface.close();
            }
            
            if (status == "Received")
                LoadCustomerOrderLine(oid, true);
            else
                LoadCustomerOrderLine(oid, false);
            

        }

        private void tbOrderId_Leave(object sender, EventArgs e)
        {
            LINE = 0;
            if (tbOrderId.Text != "")
                ChangeIndex(tbOrderId.Text);
        }

        private void CreateTrans(string p, string q, string o, string l)
        {
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string pID = p;
            if (pID == "")
                return;
            string qty = q;
            DateTime tDate = dtActualShip.Value;
            string specs = "RECEIVE ORDER: " + o + " LINE: " + l;
            string uID = Globals.USER;

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
            con.Close();
            con.Dispose();
            cmd.Dispose();
        }

        private void UpdateInventory(string part, double qty, string line)
        {
            MySqlDataReader rdr = null;
            string qry = "SELECT qty_on_hand FROM part where id = '" + part + "';";
            rdr = MysqlInterface.DoQuery(qry);
            double inv_qty = 0;
            double new_inv_qty = 0.0f;
            string update_qry = "";
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0))
                {
                    inv_qty = rdr.GetDouble(0);
                    new_inv_qty = inv_qty + (qty);
                    update_qry = update_qry + "UPDATE part SET qty_on_hand = " + Convert.ToString(new_inv_qty) + " WHERE id = '" + part + "';";
                    
                    CreateTrans(part, qty.ToString(), tbOrderId.Text, line);
                }
            }

            MysqlInterface.close();
            MysqlInterface.init();
            MysqlInterface.ExecuteQuery(update_qry);
            MysqlInterface.close();
        }

        private void UpdateOrder(bool bOrder)
        {
            MySqlConnection con = null;
            MySqlCommand cmd = new MySqlCommand();
            string oID = tbOrderId.Text;

            con = null;
            cmd = new MySqlCommand();

            string host = MysqlInterface.host;
            string dbase = MysqlInterface.dbase;
            string user = MysqlInterface.user;
            string password = MysqlInterface.password;


            String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

            con = new MySqlConnection(str);
            con.Open();
            cmd.Connection = con;

            int rows = dgOrderForm.RowCount-1;

            for (int i = 0; i < rows; i++)
            {
                int line = Convert.ToInt32(dgOrderForm.Rows[i].Cells["cLine"].Value);
                string partid = Convert.ToString(dgOrderForm.Rows[i].Cells["cPartId"].Value);
                double qty = Convert.ToDouble(dgOrderForm.Rows[i].Cells["cQuantity"].Value);
                double ship = Convert.ToDouble(dgOrderForm.Rows[i].Cells["cShip"].Value);
                double gst = Convert.ToDouble(dgOrderForm.Rows[i].Cells["cGST"].Value);
                double pst = Convert.ToDouble(dgOrderForm.Rows[i].Cells["cPST"].Value);
                double pPrice = Convert.ToDouble(dgOrderForm.Rows[i].Cells["cUnitPrice"].Value);
                gst = (gst / Convert.ToDouble(qty)) * ship;
                pst = (pst / Convert.ToDouble(qty)) * ship;

                int backorder = 0;

                UpdateInventory(partid, ship, line.ToString());
                try
                {
                    con = new MySqlConnection(str);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE po_line SET received_qty = '" + ship.ToString() + "', backordered_qty = '" + backorder.ToString() +
                        "', gst = '" + gst.ToString() + "', pst = '" + pst.ToString() +
                        "' WHERE po_id = '" + oID + "' AND line_no = '" + line.ToString() + "';";
                    int numRowsUpdated = cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE part SET purchase_price = '" + pPrice.ToString() +
                    "' WHERE id = '" + partid + "';";

                    numRowsUpdated = cmd.ExecuteNonQuery();
                }
                catch (MySqlException err)
                {
                    Console.WriteLine("Error: " + err.ToString());
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close(); //close the connection
                    }
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            float total = 0.0f;
            try
            {
                total = 0.0f;
                MySqlDataReader rdr = null;
                string qry = "SELECT unit_price, received_qty, gst, pst FROM po_line where po_id = '" + oID + "';";
                rdr = MysqlInterface.DoQuery(qry);

                while (rdr.Read())
                {
                    total = total + (rdr.GetFloat(0) * rdr.GetFloat(1)) + rdr.GetFloat(2) + rdr.GetFloat(3);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                MysqlInterface.close();
            }
            con = null;
            cmd = new MySqlCommand();
            try
            {
                host = MysqlInterface.host;
                dbase = MysqlInterface.dbase;
                user = MysqlInterface.user;
                password = MysqlInterface.password;

                DateTime actualdate = dtActualShip.Value;
                string ad = actualdate.ToString("yyyy-MM-dd");


                str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open();


                cmd.Connection = con;
                cmd.CommandText = "UPDATE purchase_order SET total = '" + total + "', state = 'Received', actual_receive_date = '" + ad + "' WHERE id = '" + oID + "';";
                int numRowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
            finally
            {
                if (con != null)
                {
                    con.Close(); //close the connection
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
        }

        private bool IsShipped()
        {
            MySqlDataReader rdr = null;
            string shipped = "";
            string id = tbOrderId.Text; ;


            rdr = MysqlInterface.DoQuery("SELECT state FROM purchase_order where id = '" + id + "';");
            while (rdr.Read())
                shipped = rdr.GetString(0);

            if (shipped == "Received")
                return true;
            else
                return false;
        }

        private void customerInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            Globals.FM_ORDER_SEARCH = new fmOrderSearch("PurchaseReceipt");
            Globals.FM_ORDER_SEARCH.ShowDialog();
            Globals.FM_ORDER_SEARCH.BringToFront();
        }


        private void btReceive_Click(object sender, EventArgs e)
        {
            if (IsShipped())
            {
                MessageBox.Show("Order Already Received");
                return;
            }
            UpdateOrder(false);
            ChangeIndex(tbOrderId.Text);
        }

        private void pbShip_Click(object sender, EventArgs e)
        {
            if (IsShipped())
            {
                MessageBox.Show("Order Already Received");
                return;
            }
            UpdateOrder(false);
            ChangeIndex(tbOrderId.Text);
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            Globals.FM_ORDER_SEARCH = new fmOrderSearch("PurchaseReceipt");
            Globals.FM_ORDER_SEARCH.ShowDialog();
            Globals.FM_ORDER_SEARCH.BringToFront();
        }

        private void btReports_Click(object sender, EventArgs e)
        {
            string id = tbOrderId.Text;
            Globals.FM_RECEIVING = new fmReceiving(id);
            Globals.FM_RECEIVING.Show();
        }

        private void pbReports_Click(object sender, EventArgs e)
        {
            string id = tbOrderId.Text;
            Globals.FM_RECEIVING = new fmReceiving(id);
            Globals.FM_RECEIVING.Show();
        }

        private void btReceive_MouseHover(object sender, EventArgs e)
        {

            (sender as Button).FlatAppearance.BorderSize = 2;
        }

        private void btReceive_MouseLeave(object sender, EventArgs e)
        {

            (sender as Button).FlatAppearance.BorderSize = 1;
        }

        private void pbShip_MouseHover(object sender, EventArgs e)
        {
            btReceive.FlatAppearance.BorderSize = 2;
        }

        private void pbShip_MouseLeave(object sender, EventArgs e)
        {
            btReceive.FlatAppearance.BorderSize = 1;
        }

        private void pbSearch_MouseHover(object sender, EventArgs e)
        {
            btSearch.FlatAppearance.BorderSize = 2;
        }

        private void pbSearch_MouseLeave(object sender, EventArgs e)
        {
            btSearch.FlatAppearance.BorderSize = 1;
        }

        private void pbReports_MouseHover(object sender, EventArgs e)
        {
            btReports.FlatAppearance.BorderSize = 2;
        }

        private void pbReports_MouseLeave(object sender, EventArgs e)
        {
            btReports.FlatAppearance.BorderSize = 1;
        }
    }
}
