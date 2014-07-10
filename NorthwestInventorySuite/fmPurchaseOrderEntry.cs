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
using Outlook = Microsoft.Office.Interop.Outlook;

namespace NorthwestInventoryManager
{
    public partial class fmPurchaseOrderEntry : Form
    {
        /*CLASS VARIABLES*/
        private static string id = "";
        private static int LINE = 0;

        public fmPurchaseOrderEntry()
        {
            InitializeComponent();
        }

        private void ClearSheet()
        {
            dgOrderForm.Rows.Clear();
            LINE = 0;
            dtActualShip.Value = DateTime.Now;
            dtDesiredShip.Value = DateTime.Now;
            tbFOB.Text = "";
            dtOrderDate.Value = DateTime.Now;
            tbOrderId.Text = "";
            tbNotes.Text = "";
            tbVendorPO.Text = "";
            cbCarrier.Text = "";
            cbVendor.Text = "";
            cbShipTo.Text = "";
            cbStatus.Text = "";

        }

        private void LoadPurchaseOrderLine(string oid)
        {

            dgOrderForm.Rows.Clear();
            try
            {
                MySqlDataReader rdr = null;


                string sqlqry = "SELECT line_no, part_id, description, ordered_qty, unit_price, gst, pst, notes FROM po_line " +
                                        "where po_id = '" + oid + "';";
                rdr = MysqlInterface.DoQuery(sqlqry);

                int line_no = 1;
                string part_id = "";
                string description = "";
                double ordered_qty = 0.0;
                double unit_price = 0.0f;
                float gst = 0.0f;
                float pst = 0.0f;
                string notes = "";
                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        if (!rdr.IsDBNull(0))
                        {
                            if(!rdr.IsDBNull(0)) line_no = rdr.GetInt32(0);
                            if (!rdr.IsDBNull(1)) part_id = rdr.GetString(1);
                            if (!rdr.IsDBNull(2)) description = rdr.GetString(2);
                            if (!rdr.IsDBNull(3)) ordered_qty = Math.Round(rdr.GetDouble(3), 3);
                            if (!rdr.IsDBNull(4)) unit_price = Math.Round(rdr.GetDouble(4), 3);
                            if (!rdr.IsDBNull(5)) gst = rdr.GetFloat(5);
                            if (!rdr.IsDBNull(6)) pst = rdr.GetFloat(6);
                            if (!rdr.IsDBNull(7)) notes = rdr.GetString(7);

                            dgOrderForm.Rows.Add(line_no.ToString(), part_id,"",description, ordered_qty.ToString(), unit_price.ToString(), gst.ToString(), pst.ToString(), notes);
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
            ClearSheet();
            tbOrderId.Text = oid;
            string cust_id = "";
            string cust_po = "";
            string shipto_id = "";
            string shipper_id = "";
            string fob = "";
            string status = "";
            string notes = "";
            DateTime oDate = DateTime.Today;
            DateTime dDate = DateTime.Today;
            DateTime aDate = DateTime.Today;

            try
            {
                MySqlDataReader rdr = null;
                string query = "SELECT vendor_id, vendor_po, shipto_id, shipper_id, fob, state, order_date, desired_receive_date, actual_receive_date, notes FROM purchase_order where id = '" + oid + "';";
                rdr = MysqlInterface.DoQuery(query);


                while (rdr.Read())
                {

                    if(!rdr.IsDBNull(0)) cbVendor.Text = cust_id = rdr.GetString(0);
                    if (!rdr.IsDBNull(1)) tbVendorPO.Text = cust_po = rdr.GetString(1);
                    if (!rdr.IsDBNull(2)) cbShipTo.Text = shipto_id = rdr.GetString(2);
                    if (!rdr.IsDBNull(3)) cbCarrier.Text = shipper_id = rdr.GetString(3);
                    if (!rdr.IsDBNull(4)) tbFOB.Text = fob = rdr.GetString(4);
                    if (!rdr.IsDBNull(5)) cbStatus.Text = status = rdr.GetString(5);
                    if (!rdr.IsDBNull(6))
                        oDate = rdr.GetDateTime(6);
                    if (!rdr.IsDBNull(7))
                        dDate = rdr.GetDateTime(7);
                    if (!rdr.IsDBNull(8))
                        aDate = rdr.GetDateTime(8);
                    if (!rdr.IsDBNull(9)) tbNotes.Text = notes = rdr.GetString(9);

                }

                dtOrderDate.Text = oDate.ToString();
                dtDesiredShip.Text = dDate.ToString();
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

            LoadPurchaseOrderLine(oid);

        }


        private void fmPurchaseOrderEntry_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlDataReader rdr = null;

                rdr = MysqlInterface.DoQuery("SELECT id FROM vendor");
                ClearSheet();
                while (rdr.Read())
                    cbVendor.Items.Add(rdr.GetString(0));

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

        private void tbOrder_TextChanged(object sender, EventArgs e)
        {

        }

        public static void fmCustMain()
        {
            Application.Run(new fmCustMaintenance());
        }

        private void btVendor_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(fmCustMain));
            t.Start();
        }

        public static void fmShipAdd()
        {
            Application.Run(new fmAddress(id, id, "vendor", "PURCHENTRY"));
        }

        private void btShipTo_Click(object sender, EventArgs e)
        {
            id = cbVendor.Text;
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(fmShipAdd));
            t.Start();
        }

        public static void fmCarrierSetup()
        {
            Application.Run(new fmCarrier(id));
        }

        private void btCarrier_Click(object sender, EventArgs e)
        {
            id = cbCarrier.Text;
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(fmCarrierSetup));
            t.Start();
        }

        private void tbOrderId_Leave(object sender, EventArgs e)
        {
            LINE = 0;
            if (tbOrderId.Text != "")
                ChangeIndex(tbOrderId.Text);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        float disc = 0.0f;

        private void cbVendor_Leave(object sender, EventArgs e)
        {
            disc = 1.0f;
            MySqlDataReader rdr = null;
            string vend = cbVendor.Text;
            string qry = "SELECT DISCOUNT, CARRIER_ID, SHIPTO_ID FROM vendor where ID = '" + vend + "';";
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0)) disc = rdr.GetFloat(0);
                if (!rdr.IsDBNull(1)) cbCarrier.Text = rdr.GetString(1);
                if (!rdr.IsDBNull(2)) cbShipTo.Text = rdr.GetString(2); 
                
                tbDiscount.Text = Math.Round(disc, 3).ToString();
                chGST.Checked = true;
                chPST.Checked = false;
            }

            MysqlInterface.close();
        }

        private void btAddLine_Click(object sender, EventArgs e)
        {
            LINE++;
            string str_lNo = LINE.ToString();
            string str_qty = "";
            string str_partId = "";
            string str_desc = "";
            string str_uPrice = "";
            string str_cust_PID = "";
            string notes = "";
            string[] row = { str_lNo, "", str_qty, str_partId, str_desc, str_uPrice, str_cust_PID, notes };

            int rows = dgOrderForm.Rows.Count - 1;
            dgOrderForm.Rows.Add();
            dgOrderForm.Rows[rows].Cells["cLine"].Value = str_lNo;
            dgOrderForm.Rows[rows].Cells["cNotes"].Value = "";
        }

        public void ChangePart()
        {
            MySqlDataReader rdr = null;

            dgOrderForm.Rows[Globals.row].Cells[Globals.column].Value = Globals.part;

            string qry = "SELECT DESCRIPTION, PURCHASE_PRICE FROM part where ID = '" + Globals.part + "';";
            rdr = MysqlInterface.DoQuery(qry);
            try
            {
                string desc = "";
                string price = "";
                while (rdr.Read())
                {
                    desc = rdr.GetString(0);
                    price = rdr.GetString(1);
                }
                dgOrderForm.Rows[Globals.row].Cells[Globals.column + 2].Value = desc;

                double lnPrice = Convert.ToDouble(price);

                lnPrice = lnPrice * Convert.ToDouble(tbDiscount.Text);
                lnPrice = Math.Round(lnPrice, 2);
                dgOrderForm.Rows[Globals.row].Cells[Globals.column + 4].Value = lnPrice.ToString();
                dgOrderForm.Rows[Globals.row].Cells[4].Value = "1";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Data.ToString());
            }
        }

        private void dgOrderForm_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (tbOrderId.Text == "")
                return;
            int c = e.ColumnIndex;
            if (Globals.partSelected == false)
            {
                if (e.RowIndex >= 0)
                {
                    if (c == 1 && dgOrderForm.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        string curPart;
                        curPart = Globals.part = dgOrderForm.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        Globals.row = e.RowIndex;
                        Globals.column = e.ColumnIndex;
                        Globals.FM_PART_LOOKUP = new fmPartLookup("POForm", curPart);
                        Globals.FM_PART_LOOKUP.ShowDialog();
                        Globals.FM_PART_LOOKUP.BringToFront();

                    } 
                    if ((c == 4 || c==5) && dgOrderForm.Rows[e.RowIndex].Cells[4].Value != null)
                    {

                        double qty = Convert.ToDouble(dgOrderForm.Rows[e.RowIndex].Cells[4].Value.ToString());
                        double price = Convert.ToDouble(dgOrderForm.Rows[e.RowIndex].Cells[5].Value.ToString());
                        double gst = qty * price * GetGSTRate();
                        double pst = qty * price * GetPSTRate();
                        dgOrderForm.Rows[e.RowIndex].Cells[6].Value = Math.Round(gst, 2);
                        dgOrderForm.Rows[e.RowIndex].Cells[7].Value = Math.Round(pst, 2);


                    }
                }
            }
            else
                Globals.partSelected = false;
        }

        private void SaveCustomerOrderData()
        {
            
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            int order_id = Convert.ToInt32(tbOrderId.Text);
            string cust_id = cbVendor.Text;
            string po = tbVendorPO.Text;
            string shiptoid = cbShipTo.Text;
            string shipperid = cbCarrier.Text;
            string fob = tbFOB.Text;
            string state = cbStatus.Text;
            DateTime orderdate = dtOrderDate.Value;
            DateTime shipdate = dtDesiredShip.Value;
            DateTime actualdate = dtActualShip.Value;
            string ad = actualdate.ToString("yyyy-MM-dd");
            string dd = shipdate.ToString("yyyy-MM-dd");
            string od = orderdate.ToString("yyyy-MM-dd");
            string notes = tbNotes.Text;
            try
            {
                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;

                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";
 
                con = new MySqlConnection(str);
                con.Open(); //open the connection
                String cmdText = "INSERT INTO purchase_order (id, vendor_id, vendor_po, shipto_id, shipper_id, fob, state, order_date, desired_receive_date, actual_receive_date, notes)" +
                "VALUES(@id,@vendor_id, @vendor_po, @shipto_id, @shipper_id, @fob, @state, @od, @dd, @ad, @notes)";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", order_id);
                cmd.Parameters.AddWithValue("@vendor_id", cust_id);
                cmd.Parameters.AddWithValue("@vendor_po", po);
                cmd.Parameters.AddWithValue("@shipto_id", shiptoid);
                cmd.Parameters.AddWithValue("@shipper_id", shipperid);
                cmd.Parameters.AddWithValue("@fob", fob);
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@od", od);
                cmd.Parameters.AddWithValue("@dd", dd);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@notes", notes);
                cmd.ExecuteNonQuery();
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
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }


        private void UpdateOrderLine(int index)
        {

            MySqlConnection con = null;
            MySqlCommand cmd = new MySqlCommand();

            string line_no = dgOrderForm.Rows[index].Cells["cLine"].Value.ToString();
            string desc = dgOrderForm.Rows[index].Cells["cDescription"].Value.ToString();
            string partid = dgOrderForm.Rows[index].Cells["cPartId"].Value.ToString();
            string ordered = dgOrderForm.Rows[index].Cells["cQuantity"].Value.ToString();
            string unit_price = dgOrderForm.Rows[index].Cells["cUnitPrice"].Value.ToString();
            string gst = dgOrderForm.Rows[index].Cells["cGST"].Value.ToString();
            string pst = dgOrderForm.Rows[index].Cells["cPST"].Value.ToString();
            string notes = dgOrderForm.Rows[index].Cells["cNotes"].Value.ToString();
            //MySqlDataReader rdr = null;



            //rdr = MysqlInterface.DoQuery("SELECT length, width, height FROM part where id = '" + partid + "';");

            try
            {


                cmd.Connection = con;
                MysqlInterface.ExecuteQuery("UPDATE po_line SET part_id = '" + partid + "', description = '" + desc +
                    "', ordered_qty = " + ordered + ", unit_price = " + unit_price +
                    ", GST = " + gst + ", PST = " + pst + ", notes = '" + notes +
                    "' WHERE po_id = " + tbOrderId.Text + " and line_no = " + line_no + ";");
                // int numRowsUpdated = cmd.ExecuteNonQuery();
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


        private void AddOrderLine(int index)
        {
            MySqlConnection con = null;
            MySqlCommand cmd = null;
            try
            {


                string order_id = tbOrderId.Text;
                string line_no = "";
                string partid = "";
                string ordered = "";
                string unit_price = "";
                string desc = "";

                line_no = dgOrderForm.Rows[index].Cells["cLine"].Value.ToString();
                desc = dgOrderForm.Rows[index].Cells["cDescription"].Value.ToString();
                partid = dgOrderForm.Rows[index].Cells["cPartId"].Value.ToString();
                ordered = dgOrderForm.Rows[index].Cells["cQuantity"].Value.ToString();
                unit_price = dgOrderForm.Rows[index].Cells["cUnitPrice"].Value.ToString();
                string gst = dgOrderForm.Rows[index].Cells["cGST"].Value.ToString();
                string pst = dgOrderForm.Rows[index].Cells["cPST"].Value.ToString();
                string notes = dgOrderForm.Rows[index].Cells["cNotes"].Value.ToString();

                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;

                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open(); //open the connection
                String cmdText = "INSERT INTO po_line (line_no, po_id, part_id, description, ordered_qty, unit_price, gst, pst, notes)" +
                "VALUES(@line_no, @po_id, @part_id, @desc, @ordered_qty, @unit_price, @gst, @pst, @notes)";

                cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@line_no", line_no);
                cmd.Parameters.AddWithValue("@po_id", order_id);
                cmd.Parameters.AddWithValue("@part_id", partid);
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.Parameters.AddWithValue("@ordered_qty", ordered);
                cmd.Parameters.AddWithValue("@unit_price", unit_price);
                cmd.Parameters.AddWithValue("@gst", gst);
                cmd.Parameters.AddWithValue("@pst", pst);
                cmd.Parameters.AddWithValue("@notes", notes);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Error Saving Order Line");
            }
            finally
            {
                cmd.Dispose();
                con.Dispose();
            }
        }

        private void SaveCustomerOrderLine()
        {

            string line_no = "";

            int rcount = dgOrderForm.Rows.Count;

            for (int i = 0; i < rcount - 1; i++)
            {

                try
                {
                    MySqlDataReader rdr = null;
                    int count = 0;


                    string id = tbOrderId.Text;
                    line_no = dgOrderForm.Rows[i].Cells["cLine"].Value.ToString();
                    string qry = "SELECT count(line_no) FROM po_line where po_id = '" + id +
                        "' and line_no = " + " '" + line_no.ToString() + "';";
                    rdr = MysqlInterface.DoQuery(qry);
                    if (rdr == null || rdr.IsClosed)
                    {
                        MessageBox.Show("Invalid Reader Saving Cust Order Line");
                        break;
                    }

                    while (rdr.Read())
                        count = rdr.GetInt32(0);

                    if (count > 0)
                        UpdateOrderLine(i);
                    else
                        AddOrderLine(i);
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

        private void UpdateOrder()
        {

            MySqlConnection con = null;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;


                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open();


                cmd.Connection = con;
                cmd.CommandText = "UPDATE purchase_order SET vendor_id = '" + cbVendor.Text + "', vendor_po = '" + tbVendorPO.Text + "', shipto_id = '" + cbShipTo.Text + "', shipper_id = '" + cbCarrier.Text +
                    "', fob = '" + tbFOB.Text + "', state = '" + cbStatus.Text + "', notes = '" + tbNotes.Text + "' WHERE id = '" + tbOrderId.Text + "';";
                int numRowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
            finally
            {
                if (con != null)
                    con.Close();
                if (cmd != null)
                    cmd.Dispose();
            }

        }



        private void UpdateOrderTotal(float t, string cId)
        {

            string host = MysqlInterface.host;
            string dbase = MysqlInterface.dbase;
            string user = MysqlInterface.user;
            string password = MysqlInterface.password;

            MySqlConnection con = null;
            MySqlCommand cmd = new MySqlCommand();
            MysqlInterface.close();
            string str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

            con = new MySqlConnection(str);
            con.Open();


            cmd.Connection = con;
            cmd.CommandText = "UPDATE purchase_order SET total = '" + t + "' WHERE id = '" + cId + "';";
            int numRowsUpdated = cmd.ExecuteNonQuery();

            id = tbOrderId.Text;
            con.Close();
        }

        private void UpdateCurrentOrderId()
        {
            string host = MysqlInterface.host;
            string dbase = MysqlInterface.dbase;
            string user = MysqlInterface.user;
            string password = MysqlInterface.password;

            MySqlConnection con = null;
            MySqlCommand cmd = new MySqlCommand();

            string curid = "";
            MySqlDataReader rdr = null;
            string qry = "SELECT po_id FROM current_values;";
            rdr = MysqlInterface.DoQuery(qry);

            while (rdr.Read())
                curid = rdr.GetString(0);

            if (id == curid)
            {
                curid = (Convert.ToInt32(curid) + 1).ToString();


                string str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open();


                cmd.Connection = con;
                cmd.CommandText = "UPDATE current_values SET po_id = '" + curid + "';";
                int numRowsUpdated = cmd.ExecuteNonQuery();
            }
        }

        private bool IsShipped()
        {
            MySqlDataReader rdr = null;
            string shipped = "";
            id = tbOrderId.Text; ;


            rdr = MysqlInterface.DoQuery("SELECT state FROM purchase_order where id = '" + id + "';");
            while (rdr.Read())
                shipped = rdr.GetString(0);

            if (shipped == "Received")
                return true;
            else
                return false;
        }

        private bool IsFirmed()
        {
            if (cbStatus.Text == "Firmed")
                return true;
            else
                return false;
        }

        private void SavePO()
        {
            if (IsShipped())
            {
                MessageBox.Show("Unable To Make Changes To Received Order");
                return;
            }

            if (IsFirmed())
            {
                DialogResult result = MessageBox.Show("Release Order?",
                        "Release",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    cbStatus.Text = "Released";
            }
            MySqlConnection con = null;
            MySqlCommand cmd = new MySqlCommand();

            string id = tbOrderId.Text;
            MySqlDataReader rdr = null;
            int count = 0;
            try
            {
                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;

                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                rdr = MysqlInterface.DoQuery("SELECT count(id) FROM purchase_order where id = '" + id + "';");
                while (rdr.Read())
                    count = rdr.GetInt32(0);

                if (count > 0)
                {
                    UpdateOrder();
                    SaveCustomerOrderLine();
                }
                else
                {
                    SaveCustomerOrderData();
                    SaveCustomerOrderLine();
                }
                id = tbOrderId.Text;

                float total = 0.0f;
                rdr = null;

                string qry = "SELECT unit_price, ordered_qty, gst, pst FROM po_line where po_id = '" + id + "';";
                rdr = MysqlInterface.DoQuery(qry);

                while (rdr.Read())
                    total = total + (rdr.GetFloat(0) * rdr.GetFloat(1)) + rdr.GetFloat(2) + rdr.GetFloat(3);

                UpdateOrderTotal(total, tbOrderId.Text);
                UpdateCurrentOrderId();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.ToString());
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

        private void btSave_Click(object sender, EventArgs e)
        {
            SavePO();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void packlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = tbOrderId.Text;
            Globals.FM_RECEIVING = new fmReceiving(id);
            Globals.FM_RECEIVING.Show();
        }

        private void DeleteOrder()
        {
            DialogResult result;

            result = DialogResult.Cancel;

            result = MessageBox.Show("Delete Order?",
                        "Delete Customer Order?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);


            if (result == DialogResult.No)
                return;

            MySqlConnection con = null;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;

                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open();


                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM po_line WHERE po_id = " + tbOrderId.Text + ";";
                int numRowsUpdated = cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM purchase_order WHERE id = " + tbOrderId.Text + ";";
                numRowsUpdated = cmd.ExecuteNonQuery();
                ClearSheet();
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

        private void CreateNewOrder()
        {
            ClearSheet();
            cbVendor.Focus();
            cbStatus.Text = "Firmed";
            tbFOB.Text = "FOB Origin";
            MySqlDataReader rdr = null;
            string id = "";
            string qry = "SELECT po_id FROM current_values;";
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
                id = rdr.GetString(0);

            tbOrderId.Text = id;
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            CreateNewOrder();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            Globals.FM_ORDER_SEARCH = new fmOrderSearch("PurchaseOrder");
            Globals.FM_ORDER_SEARCH.ShowDialog();
            Globals.FM_ORDER_SEARCH.BringToFront();
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            SavePO();
        }

        private void btDeleteOrder_Click(object sender, EventArgs e)
        {
            DeleteOrder();
        }

        private void pbDeleteOrder_Click(object sender, EventArgs e)
        {
            DeleteOrder();
        }

        private void SendPO()
        {
            try
            {
                MySqlDataReader rdr = null;
                string email = "";
                string contact = "";
                string qry = "select c.email, c.contact from vendor c where c.ID = '" + cbVendor.Text + "';";
                rdr = MysqlInterface.DoQuery(qry);
                while (rdr.Read())
                {
                    email = rdr.GetString(0);
                    contact = rdr.GetString(1);
                }

                string orderid = tbOrderId.Text;
                ReportDocument cryRpt = new ReportDocument();
                string dir = System.IO.Directory.GetCurrentDirectory();
                dir = "PurchaseOrder.rpt";
                cryRpt.Load(dir);
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

                crParameterDiscreteValue.Value = orderid;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["order_id"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, "pos//po-" + orderid + ".pdf");


                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                string directory = System.IO.Directory.GetCurrentDirectory();
                orderid = tbOrderId.Text;
                directory = directory + "\\pos\\po-" + orderid + ".pdf";
                mailItem.Attachments.Add(directory);
                mailItem.Subject = "Pinnacle Glass Doors - Purchase Order# " + orderid;
                mailItem.To = email;

                string name = contact;
                if (contact != "")
                {
                    int pos = name.IndexOf(' ');
                    if (pos != -1)
                        name = name.Substring(0, pos);
                }
                mailItem.Body = "Hi " + name + ",\n\n" + "Please see the attached purchase order. Please confirm pricing and ship date." +
                    "\n\nThank You,\n\n" + Globals.USER_NAME;
                mailItem.Importance = Outlook.OlImportance.olImportanceNormal;
                mailItem.Display(true);

            }
            catch (LogOnException)
            {
                MessageBox.Show("Incorrect Logon Parameters. Check your user name and password.");
            }
            catch (DataSourceException)
            {
                MessageBox.Show("An error has occurred while connecting to the database.");
            }
            catch (EngineException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            SendPO();
        }

        private void btPurchaseOrder_Click(object sender, EventArgs e)
        {
            HideButtons();
            id = tbOrderId.Text;
            Globals.FM_PURCHASE_ORDER = new fmPurchaseOrder(id);
            Globals.FM_PURCHASE_ORDER.Show();
        }

        private void btReceiving_Click(object sender, EventArgs e)
        {
            HideButtons();
            id = tbOrderId.Text;
            Globals.FM_RECEIVING = new fmReceiving(id);
            Globals.FM_RECEIVING.Show();
        }

        private void btReportsDropDown_Click(object sender, EventArgs e)
        {
            if (btPurchaseOrder.Visible)
                HideButtons();
            else
            {
                btPurchaseOrder.Visible = true;
                btReceiving.Visible = true;
            }
        }

        private void HideButtons()
        {
            btPurchaseOrder.Visible = false;
            btReceiving.Visible = false;
        }

        private double GetPSTRate()
        {
            if (chPST.Checked)
                return 0.07;
            else
                return 0.0;
        }

        private double GetGSTRate()
        {
            if (chGST.Checked)
                return 0.05;
            else
                return 0.0;
        }

        private void pbNew_Click(object sender, EventArgs e)
        {
            CreateNewOrder();
        }

        private void pbNew_MouseHover(object sender, EventArgs e)
        {
            btNew.FlatAppearance.BorderSize = 2;
        }

        private void pbNew_MouseLeave(object sender, EventArgs e)
        {
            btNew.FlatAppearance.BorderSize = 1;
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

        private void pbSend_MouseHover(object sender, EventArgs e)
        {
            btSend.FlatAppearance.BorderSize = 2;
        }

        private void pbSend_MouseLeave(object sender, EventArgs e)
        {
            btSend.FlatAppearance.BorderSize = 1;
        }

        private void pbSend_Click(object sender, EventArgs e)
        {
            SendPO();
        }

        private void pbSave_MouseHover(object sender, EventArgs e)
        {
            btSave.FlatAppearance.BorderSize = 2;
        }

        private void pbSave_MouseLeave(object sender, EventArgs e)
        {
            btSave.FlatAppearance.BorderSize = 1;
        }

        private void pbDeleteOrder_MouseHover(object sender, EventArgs e)
        {
            btDeleteOrder.FlatAppearance.BorderSize = 2;
        }

        private void pbDeleteOrder_MouseLeave(object sender, EventArgs e)
        {
            btDeleteOrder.FlatAppearance.BorderSize = 1;
        }

        private void btDeleteOrder_MouseHover(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderSize = 2;
        }

        private void btDeleteOrder_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderSize = 1;
        }




    }
}
