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
    public partial class fmShippingEntry : Form
    {
        public fmShippingEntry()
        {
            InitializeComponent();
        }

        private int line = 0;

        private void LoadCustomerOrderLine(string oid, bool shipped)
        {

            dgOrderForm.Rows.Clear();
            line = 0;
            try
            {
                MySqlDataReader rdr = null;


                string sqlqry = "SELECT line_no, part_id, description, ordered_qty, shipped_qty, backorder_qty, unit_price, modifier, gst, pst FROM cust_order_line " +
                                        "where cust_order_id = '" + oid + "';";
                rdr = MysqlInterface.DoQuery(sqlqry);

                int line_no = 1;
                string part_id = "";
                int ordered_qty = 0;
                int shipped_qty = 0;
                int backordered = 0;
                float unit_price = 0.0f;
                string desc = "";
                double gst;
                double pst;
                char mod = 'M';
                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        if (!rdr.IsDBNull(0))
                        {
                            line_no = rdr.GetInt32(0);
                            part_id = rdr.GetString(1);
                            desc = rdr.GetString(2);
                            ordered_qty = rdr.GetInt32(3);
                            shipped_qty = rdr.GetInt32(4);
                            backordered = rdr.GetInt32(5);
                            unit_price = rdr.GetFloat(6);
                            mod = rdr.GetChar(7);
                            gst = Math.Round(rdr.GetDouble(8), 2);
                            pst = Math.Round(rdr.GetDouble(9), 2);

                            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                            checkColumn.Name = "X";
                            checkColumn.HeaderText = "X";
                            checkColumn.Width = 50;
                            checkColumn.ReadOnly = false;
                            checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values

                            if(!shipped)
                                dgOrderForm.Rows.Add(line_no.ToString(), part_id, desc, ordered_qty.ToString(), ordered_qty.ToString(), "0", unit_price.ToString(), gst.ToString(), pst.ToString());
                            else
                                dgOrderForm.Rows.Add(line_no.ToString(), part_id, desc, ordered_qty.ToString(), shipped_qty.ToString(), backordered.ToString(), unit_price.ToString(), gst.ToString(), pst.ToString());
                            line++;
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

                rdr = MysqlInterface.DoQuery("SELECT cust_id, cust_po, shipto_id, shipper_id, fob, state, order_date, desired_ship_date, actual_ship_date, notes FROM customer_order where id = '" + oid.ToString() + "';");


                while (rdr.Read())
                {

                    if (!rdr.IsDBNull(0)) cbCustomer.Text = rdr.GetString(0);
                    if (!rdr.IsDBNull(1)) tbCustPO.Text = rdr.GetString(1);
                    if (!rdr.IsDBNull(2)) cbShipTo.Text = rdr.GetString(2);
                    if (!rdr.IsDBNull(3)) cbCarrier.Text = rdr.GetString(3);
                    if (!rdr.IsDBNull(4)) tbFOB.Text= rdr.GetString(4);
                    if (!rdr.IsDBNull(5)) tbStatus.Text = status = rdr.GetString(5);
                    if (!rdr.IsDBNull(6)) oDate = rdr.GetDateTime(6);
                    if (!rdr.IsDBNull(7)) dDate = rdr.GetDateTime(7);
                    if (!rdr.IsDBNull(8)) aDate = rdr.GetDateTime(8);
                    if (!rdr.IsDBNull(9)) tbNotes.Text = rdr.GetString(9);

                }

                dtOrderDate.Text = oDate.ToString();
                dtDesiredShip.Text = dDate.ToString();
                if(status != "Shipped")
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

            if (status == "Shipped")
                LoadCustomerOrderLine(oid, true);
            else
                LoadCustomerOrderLine(oid, false);


        }


        private void tbOrderId_Leave(object sender, EventArgs e)
        {
            line = 0;
            if (tbOrderId.Text != "")
                ChangeIndex(tbOrderId.Text);
        }

        private void SaveCustomerOrderData(string oID)
        {

            MySqlConnection con = null;
            MySqlDataReader reader = null;
            string order_id = oID;
            string cust_id = cbCustomer.Text;
            string po = tbCustPO.Text;
            string shiptoid = cbShipTo.Text;
            string shipperid = cbCarrier.Text;
            string fob = tbFOB.Text;
            string state = tbStatus.Text;
            string notes = tbNotes.Text;
            DateTime orderdate = dtOrderDate.Value;
            DateTime shipdate = dtDesiredShip.Value;
            DateTime actualdate = dtActualShip.Value;
            string ad = actualdate.ToString("yyyy-MM-dd");
            string dd = shipdate.ToString("yyyy-MM-dd");
            string od = orderdate.ToString("yyyy-MM-dd");
            try
            {
                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;

                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open(); //open the connection
                String cmdText = "INSERT INTO customer_order (id, cust_id, cust_po, shipto_id, shipper_id, fob, state, order_date, desired_ship_date, actual_ship_date, notes)" +
                "VALUES(@id,@cust_id, @cust_po, @shipto_id, @shipper_id, @fob, @state, @od, @dd, @ad, @notes)";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", order_id);
                cmd.Parameters.AddWithValue("@cust_id", cust_id);
                cmd.Parameters.AddWithValue("@cust_po", po);
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

        private void CreateTrans(string p, string q, string o, string l)
        {
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string pID = p;
            if (pID == "")
                return;
            string qty = "-" + q;
            DateTime tDate = dtActualShip.Value;
            string specs = "SHIP ORDER: " + o + " LINE: " + l;
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

        private void UpdateInventory(string part, int qty, string o, string l)
        {
            MySqlDataReader rdr = null;
            string qry = "SELECT b.component_id, b.qty, p.qty_on_hand FROM bom b inner join part p on p.id = b.component_id where part_id = '" + part + "';";
            rdr = MysqlInterface.DoQuery(qry);
            string comp = "";
            float comp_qty = 0.0f;
            float inv_qty = 0;
            float new_inv_qty = 0.0f;
            string update_qry = "";
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0))
                {
                    comp = rdr.GetString(0);
                    comp_qty = rdr.GetFloat(1);
                    inv_qty = rdr.GetFloat(2);
                    new_inv_qty = inv_qty - (comp_qty * qty);
                    update_qry = update_qry + "UPDATE part SET qty_on_hand = " + Convert.ToString(new_inv_qty) + " WHERE id = '" + comp + "';";

                    CreateTrans(comp, (comp_qty * qty).ToString(), o, l);
                }
            }

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
                int qty = Convert.ToInt32(dgOrderForm.Rows[i].Cells["cQuantity"].Value);
                int ship = Convert.ToInt32(dgOrderForm.Rows[i].Cells["cShip"].Value);
                double gst = Convert.ToDouble(dgOrderForm.Rows[i].Cells["cGST"].Value);
                double pst = Convert.ToDouble(dgOrderForm.Rows[i].Cells["cPST"].Value);
                gst = (gst / Convert.ToDouble(qty)) * ship;
                pst = (pst / Convert.ToDouble(qty)) * ship;

                int backorder;
                if (bOrder)
                    backorder = qty - ship;
                else
                    backorder = 0;

                UpdateInventory(partid, ship, tbOrderId.Text, line.ToString());
                try
                {
                    con = new MySqlConnection(str);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE cust_order_line SET shipped_qty = '" + ship.ToString() + "', backorder_qty = '" + backorder.ToString() +
                        "', gst = '" + gst.ToString() + "', pst = '" + pst.ToString() +
                        "' WHERE cust_order_id = '" + oID + "' AND line_no = '" + line.ToString() + "';";
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
        
                
            float total = 0.0f;
            try
            {
                total = 0.0f;
                MySqlDataReader rdr = null;
                string qry = "SELECT unit_price, shipped_qty, gst, pst FROM cust_order_line where cust_order_id = '" + oID + "';";
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
                cmd.CommandText = "UPDATE customer_order SET total = '" + total + "', state = 'Shipped', actual_ship_date = '" + ad + "' WHERE id = '" + oID + "';";
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

        private string GetOrderID(string oID)
        {
            string newID = "";
            int index;
            int backNum;
            int len;

            backNum = oID.IndexOf("-");
            len = oID.Length - (backNum+1);


            if (backNum != -1)
            {
                index = Convert.ToInt32(oID.Substring(backNum + 1, len));
                index++;
                newID = oID.Remove(backNum+1, len);
                newID = newID + index.ToString();
            }
            else
            {
                newID = oID + "-1";
            }
            return newID;
        }

        private string CreateBackorder()
        {
            string oID;
            int ordered;
            int ship;
            int backordered;

            oID = GetOrderID(tbOrderId.Text);
            SaveCustomerOrderData(oID);

            for (int i = 0; i < line; i++)
            {
                ordered = Convert.ToInt32(dgOrderForm.Rows[i].Cells[3].Value);
                ship = Convert.ToInt32(dgOrderForm.Rows[i].Cells[4].Value);
                backordered = ordered - ship;
                if (backordered > 0)
                    SaveOrderLine(i+1, oID);
            }

            UpdateTotal(oID);
            return oID;
            
        }

        private void SaveOrderLine(int index, string oID)
        {
            string line_no = "";
            string partid = "";
            string ordered = "";
            string unit_price = "";
            string desc = "";
            string ship = "";
            char mod = 'M';
            double gst = 0.0;
            double pst = 0.0;

            try
            {
                MySqlDataReader rdr = null;


                string sqlqry = "SELECT part_id, description, ordered_qty, unit_price, modifier, gst, pst FROM cust_order_line " +
                                        "where cust_order_id = '" + tbOrderId.Text + "' and line_no = " + index.ToString() + ";";
                rdr = MysqlInterface.DoQuery(sqlqry);

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        if (!rdr.IsDBNull(0))
                        {
                            partid = rdr.GetString(0);
                            desc = rdr.GetString(1);
                            ordered = rdr.GetString(2);
                            unit_price = rdr.GetString(3);
                            mod = rdr.GetChar(4);
                            gst = Math.Round(rdr.GetDouble(5), 2);
                            pst = Math.Round(rdr.GetDouble(6), 2);

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

            MySqlConnection con = null;

            line_no = (index).ToString();
            ordered = dgOrderForm.Rows[index-1].Cells["cQuantity"].Value.ToString();
            ship = dgOrderForm.Rows[index-1].Cells["cShip"].Value.ToString();
            gst = gst / Convert.ToDouble(ordered);
            pst = pst / Convert.ToDouble(ordered);
            ordered = (Convert.ToInt32(ordered) - Convert.ToInt32(ship)).ToString();
            gst = gst * Convert.ToDouble(ordered);
            pst = pst * Convert.ToDouble(ordered);


            string host = MysqlInterface.host;
            string dbase = MysqlInterface.dbase;
            string user = MysqlInterface.user;
            string password = MysqlInterface.password;

            String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

            con = new MySqlConnection(str);
            con.Open(); //open the connection
            String cmdText = "INSERT INTO cust_order_line (line_no, cust_order_id, part_id, description, ordered_qty, unit_price, modifier, gst, pst)" +
            "VALUES(@line_no, @cust_order_id, @part_id, @desc, @ordered_qty, @unit_price, @mod, @gst, @pst)";

            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@line_no", line_no);
            cmd.Parameters.AddWithValue("@cust_order_id", oID);
            cmd.Parameters.AddWithValue("@part_id", partid);
            cmd.Parameters.AddWithValue("@desc", desc);
            cmd.Parameters.AddWithValue("@ordered_qty", ordered);
            cmd.Parameters.AddWithValue("@unit_price", unit_price);
            cmd.Parameters.AddWithValue("@mod", mod);
            cmd.Parameters.AddWithValue("@gst", gst.ToString());
            cmd.Parameters.AddWithValue("@pst", pst.ToString());
            cmd.ExecuteNonQuery();


        }

        private void UpdateTotal(string oID)
        {
            MySqlConnection con = null;
            MySqlCommand cmd = new MySqlCommand();

            float total = 0.0f;
            try
            {
                total = 0.0f;
                MySqlDataReader rdr = null;
                string qry = "SELECT unit_price, ordered_qty, gst, pst FROM cust_order_line where cust_order_id = '" + oID + "';";
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
                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;


                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open();


                cmd.Connection = con;
                cmd.CommandText = "UPDATE customer_order SET total = '" + total + "' WHERE id = '" + oID + "';";
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


            rdr = MysqlInterface.DoQuery("SELECT state FROM customer_order where id = '" + id + "';");
            while (rdr.Read())
                shipped = rdr.GetString(0);

            if (shipped == "Shipped")
                return true;
            else
                return false;
        }

        private void ShipOrder()
        {
            int ship;
            int ordered;
            int backordered;
            DialogResult result;

            result = DialogResult.Cancel;

            if (IsShipped())
            {
                MessageBox.Show("Order Already Shipped");
                return;
            }

            for (int i = 0; i < line; i++)
            {
                ordered = Convert.ToInt32(dgOrderForm.Rows[i].Cells[3].Value);
                ship = Convert.ToInt32(dgOrderForm.Rows[i].Cells[4].Value);
                backordered = ordered - ship;
                if (backordered > 0)
                {
                    result = MessageBox.Show("Create Backorder?",
                                            "Create Backorder",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);
                    break;

                }
            }
            if (result == DialogResult.Yes)
            {
                string oID = CreateBackorder();
                UpdateOrder(true);
                ChangeIndex(oID);

            }
            if (result == DialogResult.No || result == DialogResult.Cancel)
            {
                UpdateOrder(false);
                ChangeIndex(tbOrderId.Text);

            }
        }

        private void btShip_Click(object sender, EventArgs e)
        {
            ShipOrder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btShip_Click_1(object sender, EventArgs e)
        {
            ShipOrder();
        }

        private void btReports_Click(object sender, EventArgs e)
        {
            if (btInvoice.Visible)
                HideButtons();
            else
            {
                btInvoice.Visible = true;
                btPacklist.Visible = true;
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            Globals.FM_ORDER_SEARCH = new fmOrderSearch("ShipOrder");
            Globals.FM_ORDER_SEARCH.ShowDialog();
            Globals.FM_ORDER_SEARCH.BringToFront();
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            Globals.FM_ORDER_SEARCH = new fmOrderSearch("ShipOrder");
            Globals.FM_ORDER_SEARCH.ShowDialog();
            Globals.FM_ORDER_SEARCH.BringToFront();
        }

        private void pbShip_Click(object sender, EventArgs e)
        {
            ShipOrder();
        }

        private void HideButtons()
        {
            btInvoice.Visible = false;
            btPacklist.Visible = false;
        }

        private void btReportsDropDown_Click(object sender, EventArgs e)
        {
            if (btInvoice.Visible)
                HideButtons();
            else
            {
                btInvoice.Visible = true;
                btPacklist.Visible = true;
            }
        }

        private void btInvoice_Click(object sender, EventArgs e)
        {
            string oid = tbOrderId.Text;
            Globals.FM_INVOICE = new fmInvoice(oid);
            Globals.FM_INVOICE.Show();
        }

        private void pbReports_Click(object sender, EventArgs e)
        {
            if (btInvoice.Visible)
                HideButtons();
            else
            {
                btInvoice.Visible = true;
                btPacklist.Visible = true;
            }
        }

        private void btPacklist_Click(object sender, EventArgs e)
        {
            HideButtons();
            string oid = tbOrderId.Text;
            Globals.FM_PACKLIST = new fmPacklist(oid);
            Globals.FM_PACKLIST.Show();
        }


        private void btShip_MouseHover_1(object sender, EventArgs e)
        {

            (sender as Button).FlatAppearance.BorderSize = 2;
        }

        private void btShip_MouseLeave_1(object sender, EventArgs e)
        {

            (sender as Button).FlatAppearance.BorderSize = 1;
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDataReader rdr = null;
                string email = "";
                string contact = "";
                string qry = "select c.email, c.contact from customer c where c.ID = '" + cbCustomer.Text + "';";
                rdr = MysqlInterface.DoQuery(qry);
                while (rdr.Read())
                {
                    email = rdr.GetString(0);
                    contact = rdr.GetString(1);
                }

                string orderid = tbOrderId.Text;
                ReportDocument cryRpt = new ReportDocument();
                string dir = System.IO.Directory.GetCurrentDirectory();
                dir = "Invoice.rpt";
                cryRpt.Load(dir);
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

                crParameterDiscreteValue.Value = orderid;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["orderid"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, "invoices//invoice-" + orderid + ".pdf");


                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                string directory = System.IO.Directory.GetCurrentDirectory();
                orderid = tbOrderId.Text;
                directory = directory + "\\invoices\\invoice-" + orderid + ".pdf";
                mailItem.Attachments.Add(directory);
                mailItem.Subject = "Pinnacle Glass Doors - Invoice# " + orderid;
                mailItem.To = email;

                string name = contact;
                if (contact != "")
                {
                    int pos = name.IndexOf(' ');
                    if (pos != -1)
                        name = name.Substring(0, pos);
                }
                mailItem.Body = "Hi " + name + ",\n\n" + "Here is the invoice for Order Number " + orderid + "." + 
                    "\n\nThank You,\n\n" + Globals.USER_NAME;
                mailItem.Importance = Outlook.OlImportance.olImportanceNormal;
                mailItem.Display(true);


                //crystalReportViewer1.ReportSource = cryRpt;
                //crystalReportViewer1.RefreshReport();


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

    }
}
