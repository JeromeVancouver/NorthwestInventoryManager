using System;
using System.IO;
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
    public partial class fmCustomerOrderEntry : Form
    {
        double disc = 1.00f;
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
        int MAX_LINE;

        
        int line_no = 1;
        string part_id = "";
        int ordered_qty = 0;
        float unit_price = 0.0f;
        string desc = "";
        double gst;
        double pst;
        char mod = 'M';
        string pNum = "";

        static string oid = "";
        static string id;

        string selLine = "-1";
        int selRow = -1;

        bool changingCell;


        public fmCustomerOrderEntry()
        {
            InitializeComponent();
        }


        private void btCustomer_Click(object sender, EventArgs e)
        {
            Globals.FM_CUST_LOOKUP = new fmCustLookup("OrderForm");
            Globals.FM_CUST_LOOKUP.ShowDialog();
            Globals.FM_CUST_LOOKUP.BringToFront();
        }

        public void UpdateOrderForm(string shipto)
        {
            cbShipTo.Text = shipto;
        }

        private void btShipTo_Click(object sender, EventArgs e)
        {
            id = cbShipTo.Text;
            string cId = cbCustomer.Text;
            Globals.FM_ADDRESS = new fmAddress(id, cId, "customer", "ORDERENTRY");
            Globals.FM_ADDRESS.Show();
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

        private void LoadCustomers()
        {
            int count = 0;

            count = Globals.CUSTOMER_ARRAY.GetLength(0);
            for (int i = 0; i < count; i++)
                cbCustomer.Items.Add(Globals.CUSTOMER_ARRAY[i, 0]);

            count = Globals.CARRIER_ARRAY.Length;
            for (int i = 0; i < count; i++)
                cbCarrier.Items.Add(Globals.CARRIER_ARRAY[i]);
        }

        private void fmCustomerOrderEntry_Load(object sender, EventArgs e)
        {
            ClearSheet();
            MAX_LINE = 0;
            LoadCustomers();
            changingCell = false;
            //ChangeIndex(tbOrderId.Text);
        }

        int CONST_LINE_NO = 0;
        int CONST_PARTID = 1;
        int CONST_DESC = 2;
        int CONST_ORDERED = 3;
        int CONST_PRICE = 4;
        int CONST_MOD = 5;
        int CONST_GST = 6;
        int CONST_PST = 7;
        int CONST_NOTES = 8;
        int CONST_STYLE = 9;
        int CONST_WIDTH = 10;
        int CONST_HEIGHT = 11;
        int CONST_JAMB_TYPE = 12;
        int CONST_JAMB_SIZE = 13;
        int CONST_SILL = 14;
        int CONST_WS = 15;
        int CONST_DS = 16;
        int CONST_BM = 17;
        int CONST_DRILL = 18;
        int CONST_LATCH = 19;
        int CONST_STRIKE = 20;
        int CONST_HINGE = 21;
        int CONST_COLOUR = 22;
        int CONST_CORE = 23;
        int CONST_THICKNESS = 24;

        private void LoadLine(MySqlDataReader rdr)
        {
            string temp = "";

            if(!rdr.IsDBNull(0)) { line_no = rdr.GetInt32(0); ORDER_ARRAY[rowCount, CONST_LINE_NO] = line_no.ToString(); }
            if (!rdr.IsDBNull(1)) { part_id = rdr.GetString(1); ORDER_ARRAY[rowCount, CONST_PARTID] = part_id; }
            if (!rdr.IsDBNull(2)) { desc = rdr.GetString(2); ORDER_ARRAY[rowCount, CONST_DESC] = desc; }
            if (!rdr.IsDBNull(3)) { ordered_qty = rdr.GetInt32(3); ORDER_ARRAY[rowCount, CONST_ORDERED] = ordered_qty.ToString(); }
            if (!rdr.IsDBNull(4)) { unit_price = rdr.GetFloat(4); ORDER_ARRAY[rowCount, CONST_PRICE] = unit_price.ToString(); }
            if (!rdr.IsDBNull(5)) { mod = rdr.GetChar(5); ORDER_ARRAY[rowCount, CONST_MOD] = mod.ToString(); }
            if (!rdr.IsDBNull(6)) { gst = Math.Round(rdr.GetDouble(6), 2); ORDER_ARRAY[rowCount, CONST_GST] = gst.ToString(); }
            if (!rdr.IsDBNull(7)) { pst = Math.Round(rdr.GetDouble(7), 2); ORDER_ARRAY[rowCount, CONST_PST] = pst.ToString(); }
            if (!rdr.IsDBNull(8)) { notes = rdr.GetString(8); ORDER_ARRAY[rowCount, CONST_NOTES] = notes; }


            bool cust = false;
            if (mod == 'C')
                cust = true;
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "X";
            checkColumn.HeaderText = "X";
            checkColumn.Width = 50;
            checkColumn.ReadOnly = false;
            checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values


            dgOrderForm.Rows.Add(line_no.ToString(), cust, part_id, "", desc, ordered_qty.ToString(), unit_price.ToString(), gst.ToString(), pst.ToString(), notes);
            
            MAX_LINE = Convert.ToInt32(line_no);
        }

        public static string[,] ORDER_ARRAY;
        public int rowCount;


        private void LoadCustomerOrderLine(string oid)
        {

            dgOrderForm.Rows.Clear();
            int count = 0;
            rowCount = 0;
            try
            {
                MySqlDataReader rdr = null;


                string sqlqry = "SELECT count(line_no) FROM cust_order_line " + 
                                "where cust_order_id = '" + oid + "';";
                
                rdr = MysqlInterface.DoQuery(sqlqry);

                if (rdr != null)
                {                    
                    while (rdr.Read())
                        count = rdr.GetInt32(0);
                    selRow = 0;
                    if (count == 0)
                        count++;
                }

                ORDER_ARRAY = new string[count, 25];

                for (int i = 0; i < count; i++)
                    for (int j = 0; j < 25; j++)
                        ORDER_ARRAY[i, j] = "";

                sqlqry = "SELECT line_no, part_id, description, ordered_qty, unit_price, modifier, gst, pst, notes " + 
                            "FROM cust_order_line " + 
                            "where cust_order_id = '" + oid + "' order by line_no;";
                rdr = MysqlInterface.DoQuery(sqlqry);

                line_no = 1;
                part_id = "";
                ordered_qty = 0;
                unit_price = 0.0f;
                desc = "";
                mod = 'M';

                if(rdr != null)
                {
                    while (rdr.Read())
                    {
                        LoadLine(rdr);
                        rowCount++;
                    }
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
        }

        private void LoadCustomerOrderData()
        {
            MySqlDataReader rdr = null;
            oid = tbOrderId.Text;
            rdr = MysqlInterface.DoQuery("SELECT cust_id, cust_po, shipto_id, shipper_id, fob, state, order_date, desired_ship_date, actual_ship_date, notes, contact FROM customer_order where id = '" + oid + "';");

            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0)) cbCustomer.Text = cust_id = rdr.GetString(0);
                if (!rdr.IsDBNull(1)) tbCustPO.Text = cust_po = rdr.GetString(1);
                if (!rdr.IsDBNull(2)) cbShipTo.Text = shipto_id = rdr.GetString(2);
                if (!rdr.IsDBNull(3)) cbCarrier.Text = shipper_id = rdr.GetString(3);
                if (!rdr.IsDBNull(4)) tbFOB.Text = fob = rdr.GetString(4);
                if (!rdr.IsDBNull(5)) cbStatus.Text = status = rdr.GetString(5);
                if (!rdr.IsDBNull(6)) oDate = rdr.GetDateTime(6);
                if (!rdr.IsDBNull(7)) dDate = rdr.GetDateTime(7);
                if (!rdr.IsDBNull(8)) aDate = rdr.GetDateTime(8);
                if (!rdr.IsDBNull(9)) tbNotes.Text = notes = rdr.GetString(9);
                if (!rdr.IsDBNull(10)) cbContact.Text = rdr.GetString(10);

                dtOrderDate.Text = oDate.ToString();
                dtDesiredShip.Text = dDate.ToString();
                dtActualShip.Text = aDate.ToString();
            }
        }

        private void DisableForm()
        {
            dgOrderForm.Enabled = false;
            dtActualShip.Enabled = false;
            dtDesiredShip.Enabled = false;
            tbFOB.Enabled = false;
            dtOrderDate.Enabled = false;
            tbNotes.Enabled = false;
            tbCustPO.Enabled = false;
            cbCarrier.Enabled = false;
            cbCustomer.Enabled = false;
            cbShipTo.Enabled = false;
            cbShipTo.Enabled = false;
            btAddLine.Enabled = false;
            btCarrier.Enabled = false;
            btCustomer.Enabled = false;
            btDelete.Enabled = false;
            btShipTo.Enabled = false;
        }

        private void EnableForm()
        {
            dgOrderForm.Enabled = true;
            dtActualShip.Enabled = true;
            dtDesiredShip.Enabled = true;
            tbFOB.Enabled = true;
            dtOrderDate.Enabled = true;
            tbNotes.Enabled = true;
            tbCustPO.Enabled = true;
            cbCarrier.Enabled = true;
            cbCustomer.Enabled = true;
            cbShipTo.Enabled = true;
            cbShipTo.Enabled = true;
            cbStatus.Enabled = true;
            btAddLine.Enabled = true;
            btCarrier.Enabled = true;
            btCustomer.Enabled = true;
            btDelete.Enabled = true;
            btShipTo.Enabled = true;
        }

        public void LoadCustomerDetails()
        {
            
            MySqlDataReader rdr = null;
            string cust = cbCustomer.Text;
            string qry = "SELECT DISCOUNT, PST_NUM, STATE FROM customer where ID = '" + cust + "';";
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0)) disc = rdr.GetFloat(0); else disc = 1.0;
                if (!rdr.IsDBNull(1)) pNum = rdr.GetString(1); else pNum = "";

                tbDiscount.Text = Math.Round(disc, 3).ToString();
                chGST.Checked = true;
                if (pNum == "")
                    chPST.Checked = true;
                else
                    chPST.Checked = false;

                string cState = "Not Approved";
                //if (!rdr.IsDBNull(2)) rdr.GetString(2);
                //if (cState != "Approved")
                //    lbWarning.Visible = true;
                //else
                    lbWarning.Visible = false;

            }
            qry = "SELECT contact_name FROM contact WHERE owner_id = '" + cust + "';";
            rdr = MysqlInterface.DoQuery(qry);
            string cont = "";
            while (rdr.Read())
            {
                cont = rdr.GetString(0);
                cbContact.Items.Add(cont);
            }
            MysqlInterface.close();
        }

        public void ChangeIndex(string oid)
        {
            ClearSheet();
            tbOrderId.Text = oid;
            cust_id = "";
            cust_po = "";
            shipto_id = "";
            shipper_id = "";
            fob = "";
            status = "";
            notes = "";
            oDate = DateTime.Today;
            dDate = DateTime.Today;
            aDate = DateTime.Today;

            try
            {
                LoadCustomerOrderData();
                LoadCustomerOrderLine(oid);
                LoadCustomerDetails();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                MysqlInterface.close();
            }
            if (IsShipped())
                DisableForm();
            else
                EnableForm();
        }

        private void btAddLine_Click(object sender, EventArgs e)
        {
            MAX_LINE++;
            string str_lNo = MAX_LINE.ToString();
            string str_qty = "";
            string str_partId = "";
            string str_desc = "";
            string str_uPrice = "";
            string str_cust_PID = "";
            string notes = "";
            string[] row = { str_lNo, "", str_qty, str_partId, str_desc, str_uPrice, str_cust_PID, notes };
            
            int rows = dgOrderForm.Rows.Count-1;
            dgOrderForm.Rows.Add();
            dgOrderForm.Rows[rows].Cells["cLine"].Value = str_lNo;
            dgOrderForm.Rows[rows].Cells["cNotes"].Value = "";
            DataGridViewCheckBoxCell cell;
            cell = dgOrderForm.Rows[rows].Cells["cCustom"] as DataGridViewCheckBoxCell;
            cell.Value = false;

            
           string[,] temp_array;
           temp_array = new string[rows+1, 25];

           for (int i = 0; i < rows; i++)
               for( int j = 0; j < 25; j++) 
                temp_array[i, j] = ORDER_ARRAY[i, j];

           ORDER_ARRAY = temp_array;

           MySqlConnection con = null;
           MySqlCommand cmd = null;
           try
           {


               string order_id = tbOrderId.Text;

               string host = MysqlInterface.host;
               string dbase = MysqlInterface.dbase;
               string user = MysqlInterface.user;
               string password = MysqlInterface.password;

               String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

               con = new MySqlConnection(str);
               con.Open(); //open the connection
               String cmdText = "INSERT INTO cust_order_line (line_no, cust_order_id) " +
               "VALUES(@line_no, @cust_order_id)";

               cmd = new MySqlCommand(cmdText, con);
               cmd.Prepare();
               cmd.Parameters.AddWithValue("@line_no", MAX_LINE.ToString());
               cmd.Parameters.AddWithValue("@cust_order_id", order_id);

               cmd.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error Saving Order Line" + ex.ToString());
           }
           finally
           {
               cmd.Dispose();
               con.Dispose();
           }
            
        }

        private void SaveCustomerOrderData()
        {

             MySqlConnection con = null;
             MySqlDataReader reader = null;
             int order_id = Convert.ToInt32(tbOrderId.Text);
             string cust_id = cbCustomer.Text;
             string po = tbCustPO.Text;
             string shiptoid = cbShipTo.Text;
             string shipperid = cbCarrier.Text;
             string fob = tbFOB.Text;
             string state = cbStatus.Text;
             string notes = tbNotes.Text;
             string contact = cbContact.Text;
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
                 String cmdText = "INSERT INTO customer_order (id, cust_id, cust_po, shipto_id, shipper_id, fob, state, order_date, desired_ship_date, actual_ship_date, notes, contact)" +
                 "VALUES(@id,@cust_id, @cust_po, @shipto_id, @shipper_id, @fob, @state, @od, @dd, @ad, @notes, @contact)";

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
                 cmd.Parameters.AddWithValue("@contact", contact);
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

        string rail;
        string stile;
        string track;
        string insert;

        private string FractionToString(double fraction)
        {
            double n = Convert.ToInt32(Math.Floor(fraction));
            double f = fraction - n;
            if (f == 0.0)
                return Convert.ToInt32(n).ToString();
            string div = "/16";

            f = f * 16;
  
            if (f % 8 == 0)
            {
                f = f / 8;
                div = "/2";
            }
            else if (f % 4 == 0)
            {
                f = f / 4;
                div = "/4";
            }
            else if (f % 2 == 0)
            {
                f = f / 2;
                div = "/8";
            }

            string s;
            s = Convert.ToInt32(n).ToString() + " " + Convert.ToInt32(f).ToString() + div;
            return s;
        }

        /*string rail;
        string stile;
        string insert;
        string track;*/

        private void GetM01Specs(string hInches, string h16, string wInches, string w16, int panels)
        {
            double h1 = 1.25;
            double h2 = 1.38;
            double w1 = 2.5;
            double w2 = 3.8;


            h1 = Convert.ToDouble(hInches);
            h2 = Convert.ToDouble(h16);
            w1 = Convert.ToDouble(wInches);
            w2 = Convert.ToDouble(w16);

            double w = (w1 + w2 / 16) / panels + 0.5;
            double h = (h1 + h2 / 16) - 2.125;
            double r = w - (1.4375);
            double s = h + 0.125;
            double t = (w1 + w2 / 16) - 0.0625;
            rail = FractionToString(r);
            stile = FractionToString(s);
            track = FractionToString(t);
            insert = FractionToString(w) + " x " + FractionToString(h);

        }

        private void GetM03Specs(string hInches, string h16, string wInches, string w16, int panels)
        {
            double h1 = 1.25;
            double h2 = 1.38;
            double w1 = 2.5;
            double w2 = 3.8;


            h1 = Convert.ToDouble(hInches);
            h2 = Convert.ToDouble(h16);
            w1 = Convert.ToDouble(wInches);
            w2 = Convert.ToDouble(w16);

            double w = (w1 + w2/16) / panels + 0.5;
            double h = (h1 + h2/16) - 2.125;
            double r = w - (0.0625);
            double s = h + 0.125;
            double t = (w1 + w2/16) - 0.0625;
            rail = FractionToString(r);
            stile = FractionToString(s);
            track = FractionToString(t);
            insert = FractionToString(w) + " x " + FractionToString(h);

        }

        private void GetM04Specs(string hInches, string h16, string wInches, string w16, int panels)
        {
            double h1 = 1.25;
            double h2 = 1.38;
            double w1 = 2.5;
            double w2 = 3.8;


            h1 = Convert.ToDouble(hInches);
            h2 = Convert.ToDouble(h16);
            w1 = Convert.ToDouble(wInches);
            w2 = Convert.ToDouble(w16);

            double w = (w1 + w2 / 16) / panels + 0.5;
            double h = (h1 + h2 / 16) - 2.125;
            double r = w - (1.375);
            double s = h + 0.125;
            double t = (w1 + w2 / 16) - 0.0625;
            rail = FractionToString(r);
            stile = FractionToString(s);
            track = FractionToString(t);
            insert = FractionToString(w) + " x " + FractionToString(h);

        }

        private void GetM06Specs(string hInches, string h16, string wInches, string w16, int panels)
        {
            double h1 = 1.25;
            double h2 = 1.38;
            double w1 = 2.5;
            double w2 = 3.8;


            h1 = Convert.ToDouble(hInches);
            h2 = Convert.ToDouble(h16);
            w1 = Convert.ToDouble(wInches);
            w2 = Convert.ToDouble(w16);

            double w = ((w1 + w2 / 16) / panels) - 0.375;
            double h = (h1 + h2 / 16) - 2.125;
            double r = w - (0.625);
            double s = h + 0.0625;
            double t = (w1 + w2 / 16) - 0.0625;
            rail = FractionToString(r);
            stile = FractionToString(s);
            track = FractionToString(t);
            insert = FractionToString(w) + " x " + FractionToString(h);

        }

        private void GetM08Specs(string hInches, string h16, string wInches, string w16, int panels)
        {
            double h1 = 1.25;
            double h2 = 1.38;
            double w1 = 2.5;
            double w2 = 3.8;


            h1 = Convert.ToDouble(hInches);
            h2 = Convert.ToDouble(h16);
            w1 = Convert.ToDouble(wInches);
            w2 = Convert.ToDouble(w16);

            double w = ((w1 + w2 / 16) / panels) - 0.375;
            double h = (h1 + h2 / 16) - 2.125;
            double r = w;
            double s = h + 0.0625;
            double t = (w1 + w2 / 16) - 0.0625;
            rail = FractionToString(r);
            stile = FractionToString(s);
            track = FractionToString(t);
            insert = FractionToString(w) + " x " + FractionToString(h);

        }

        private void GetM25Specs(string hInches, string h16, string wInches, string w16, int panels)
        {
            double h1 = 1.25;
            double h2 = 1.38;
            double w1 = 2.5;
            double w2 = 3.8;


            h1 = Convert.ToDouble(hInches);
            h2 = Convert.ToDouble(h16);
            w1 = Convert.ToDouble(wInches);
            w2 = Convert.ToDouble(w16);

            double w = (w1 + w2 / 16) / panels + 0.5;
            double h = (h1 + h2 / 16) - 2.125;
            double r = w - (2.375);
            double s = h + 0.125;
            double t = (w1 + w2 / 16) - 0.0625;
            rail = FractionToString(r);
            stile = FractionToString(s);
            track = FractionToString(t);
            insert = FractionToString(w) + " x " + FractionToString(h);

        }

        private string GetDoorSpecs(string pID)
        {
            string series = pID;
            string heightInches = pID;
            string height16 = pID;
            string widthInches = pID;
            string width16 = pID;
            string colour = pID;
            string option = pID;
            string ins = pID;
            string panels = pID;

            series = heightInches;
            heightInches = series;
            height16 = widthInches;
            widthInches = height16;
            width16 = colour;
            colour = width16;
            option = ins;
            ins = option;
            ins = panels;

            series = pID.Substring(0, 3);
            widthInches = pID.Substring(14, 3);
            width16 = pID.Substring(17, 2);
            heightInches = pID.Substring(20, 3);
            height16 = pID.Substring(23, 2);
            colour = pID.Substring(11, 2);
            option = pID.Substring(4, 2);
            ins = pID.Substring(7, 3);
            panels = pID.Substring(7, 1);
            rail = "";
            stile = "";
            track = "";
            insert = "";

            int panelNum;

            panelNum = Convert.ToInt32(panels);

            switch (series)
            {
                case "M01":{GetM01Specs(heightInches, height16, widthInches, width16, panelNum);return "";}
                case "M02":{GetM03Specs(heightInches, height16, widthInches, width16, panelNum);return "";}
                case "M03":{GetM03Specs(heightInches, height16, widthInches, width16, panelNum);return "";}
                case "M04":{GetM04Specs(heightInches, height16, widthInches, width16, panelNum);return "";}
                case "M06":{GetM06Specs(heightInches, height16, widthInches, width16, panelNum);return "";}
                case "M07":{GetM08Specs(heightInches, height16, widthInches, width16, panelNum);return "";}
                case "M08":
                {
                    GetM08Specs(heightInches, height16, widthInches, width16, panelNum);
                    return "";
                }
                case "M09":
                {
                    GetM01Specs(heightInches, height16, widthInches, width16, panelNum);
                    return "";
                }
                case "M10":
                {
                    GetM01Specs(heightInches, height16, widthInches, width16, panelNum);
                    return "";
                }
                case "M11":
                {
                    GetM01Specs(heightInches, height16, widthInches, width16, panelNum);
                    return "";
                }
                case "M25":
                {
                    GetM25Specs(heightInches, height16, widthInches, width16, panelNum);
                    return "";
                }
                case "M27":
                {
                    GetM25Specs(heightInches, height16, widthInches, width16, panelNum);
                    return "";
                }
                case "M31":
                {
                    GetM01Specs(heightInches, height16, widthInches, width16, panelNum);
                    return "";
                }
                case "M32":
                {
                    GetM03Specs(heightInches, height16, widthInches, width16, panelNum);
                    return "";
                }
                case "M33":
                {
                    GetM03Specs(heightInches, height16, widthInches, width16, panelNum);
                    return "";
                }
                case "P30":
                {
                    GetM01Specs(heightInches, height16, widthInches, width16, panelNum);
                    return "";
                }
                default:
                    return "Invalid";
            }
        }

        private void UpdateOrderLine(int index)
        {
            
            MySqlConnection con = null;
            MySqlCommand cmd = new MySqlCommand();

            string lineNo = dgOrderForm.Rows[index].Cells["cLine"].Value.ToString();


             
            string desc = dgOrderForm.Rows[index].Cells["cDescription"].Value.ToString();
            char mod = 'M';

            DataGridViewCheckBoxCell cell;
            cell = dgOrderForm.Rows[index].Cells["cCustom"] as DataGridViewCheckBoxCell;

            if ((bool)cell.Value == true)
                mod = 'C';
            else
                mod = 'M';

            string partid = ORDER_ARRAY[index, CONST_PARTID];
            string ordered = ORDER_ARRAY[index, CONST_ORDERED];
            string unit_price = ORDER_ARRAY[index, CONST_PRICE]; 
            string gst = ORDER_ARRAY[index, CONST_GST]; 
            string pst = ORDER_ARRAY[index, CONST_PST]; 
            string notes = ORDER_ARRAY[index, CONST_NOTES];

            string style = ORDER_ARRAY[index, CONST_STYLE];
            string width = ORDER_ARRAY[index, CONST_WIDTH];
            string height = ORDER_ARRAY[index, CONST_HEIGHT];
            string jtype = ORDER_ARRAY[index, CONST_JAMB_TYPE];
            string jsize = ORDER_ARRAY[index, CONST_JAMB_SIZE];
            string sill = ORDER_ARRAY[index, CONST_SILL];
            string ws = ORDER_ARRAY[index, CONST_WS];
            string ds = ORDER_ARRAY[index, CONST_DS];
            string bm = ORDER_ARRAY[index, CONST_BM];
            string drill = ORDER_ARRAY[index, CONST_DRILL];
            string latch = ORDER_ARRAY[index, CONST_LATCH];
            string strike = ORDER_ARRAY[index, CONST_STRIKE];
            string hinge = ORDER_ARRAY[index, CONST_HINGE];
            string colour = ORDER_ARRAY[index, CONST_COLOUR];
            string core = ORDER_ARRAY[index, CONST_CORE];
            string thickness = ORDER_ARRAY[index, CONST_THICKNESS];
            //MySqlDataReader rdr = null;



            //rdr = MysqlInterface.DoQuery("SELECT length, width, height FROM part where id = '" + partid + "';");

            try
            {


                cmd.Connection = con;
                string query = "UPDATE cust_order_line SET part_id = '" + partid + "', description = '" + desc +
                    "', ordered_qty = " + ordered + ", unit_price = " + unit_price + ", modifier = '" + mod.ToString() +
                    "', GST = " + gst + ", PST = " + pst + ", notes = '" + notes +
                    "' WHERE cust_order_id = " + tbOrderId.Text + " and line_no = " + lineNo + ";";
                //MysqlInterface.close();
                MysqlInterface.ExecuteQuery(query);
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



        private void SaveCustomerOrderLine()
        {

            string lineNo = "";

            int rcount = dgOrderForm.Rows.Count;

            for (int i = 0; i < rcount-1; i++)
            {
                Globals.FM_SAVE.ChangeText("Saving Order Line#" + (i+1).ToString());
                try
                {
                    MySqlDataReader rdr = null;
                    int count = 0;


                    string id = tbOrderId.Text;
                    lineNo = dgOrderForm.Rows[i].Cells["cLine"].Value.ToString();
                    string qry = "SELECT count(line_no) FROM cust_order_line where cust_order_id = '" + id +
                        "' and line_no = " + " '" + lineNo.ToString() + "';";
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

                DateTime orderdate = dtOrderDate.Value;
                DateTime shipdate = dtDesiredShip.Value;
                DateTime actualdate = dtActualShip.Value;
                string ad = actualdate.ToString("yyyy-MM-dd");
                string dd = shipdate.ToString("yyyy-MM-dd");
                string od = orderdate.ToString("yyyy-MM-dd");   


                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open();


                cmd.Connection = con;
                cmd.CommandText = "UPDATE customer_order SET cust_id = '" + cbCustomer.Text + "', cust_po = '" + tbCustPO.Text + "', shipto_id = '" + cbShipTo.Text + "', shipper_id = '" + cbCarrier.Text +
                    "', fob = '" + tbFOB.Text + "', state = '" + cbStatus.Text + "', notes = '" + tbNotes.Text + "', contact = '" + cbContact.Text +
                    "', order_date = '" + od + "', desired_ship_date = '" + dd + "' WHERE id = '" + tbOrderId.Text + "';";

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

        private bool IsShipped()
        {
            MySqlDataReader rdr = null;
            string shipped = "";
            id = tbOrderId.Text; ;


            rdr = MysqlInterface.DoQuery("SELECT state FROM customer_order where id = '" + id + "';");
            while (rdr.Read())
                shipped = rdr.GetString(0);

            if (shipped == "Shipped")
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
            cmd.CommandText = "UPDATE customer_order SET total = '" + t + "' WHERE id = '" + cId + "';";
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
            string qry = "SELECT order_id FROM current_values;";
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
                cmd.CommandText = "UPDATE current_values SET order_id = '" + curid + "';";
                int numRowsUpdated = cmd.ExecuteNonQuery();
            }
        }

        private void SaveCustomerOrder(string oID)
        {
            bool isShip = IsShipped();


            if (isShip && cbStatus.Text != "Released")
            {
                MessageBox.Show("Unable To Make Changes To Shipped Order");
                return;
            }

            if (cbCarrier.Text == "")
            {
                MessageBox.Show("Please Enter A Carrier Before Saving");
                return;
            }

            Globals.FM_SAVE = new fmSaveDialogue("Saving Customer Order");
            Globals.FM_SAVE.Show();
            Globals.FM_SAVE.Refresh();

            Globals.FM_SAVE.ChangeText("Customer Order");

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

                rdr = MysqlInterface.DoQuery("SELECT count(id) FROM customer_order where cust_id = '" + cbCustomer.Text +
                    "' AND cust_po = '" + tbCustPO.Text + "' AND id <> '" + tbOrderId.Text + "' ;");
                while (rdr.Read())
                    count = rdr.GetInt32(0);

                if (count > 0)
                {
                    DialogResult result = MessageBox.Show("Duplicate PO Found For Customer. Do You Wish To Continue?",
                            "Duplicate PO",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
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

                rdr = MysqlInterface.DoQuery("SELECT count(id) FROM customer_order where id = '" + id + "';");
                while (rdr.Read())
                    count = rdr.GetInt32(0);

                if (count > 0)
                    UpdateOrder();

                SaveCustomerOrderLine();

                id = tbOrderId.Text;

                float total = 0.0f;
                rdr = null;

                string qry = "SELECT unit_price, ordered_qty, gst, pst FROM cust_order_line where cust_order_id = '" + id + "';";
                rdr = MysqlInterface.DoQuery(qry);

                while (rdr.Read())
                    total = total + (rdr.GetFloat(0) * rdr.GetFloat(1)) + rdr.GetFloat(2) + rdr.GetFloat(3);

                UpdateOrderTotal(total, tbOrderId.Text);
                UpdateCurrentOrderId();
                Globals.FM_SAVE.Hide();

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
            if (isShip && cbStatus.Text == "Released")
                ChangeIndex(tbOrderId.Text);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            SaveCustomerOrder(tbOrderId.Text);
        }


        private void workOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oid = tbOrderId.Text;
            Globals.FM_WORK_ORDER = new fmWorkorder(oid);
            Globals.FM_WORK_ORDER.Show();
        }

        private void customerInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oid = tbOrderId.Text;
            Globals.FM_INVOICE = new fmInvoice(oid);
            Globals.FM_INVOICE.Show();

        }

        private void packlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oid = tbOrderId.Text;
            Globals.FM_PACKLIST = new fmPacklist(oid);
            Globals.FM_PACKLIST.Show();
        }

        private void DeleteOrderLine()
        {
            /* --FIX
            * 
            * This should delete the line in the database
            * delete the line user selected, if no line selected delete the last line
            * 
            * */
            if (IsShipped())
            {
                MessageBox.Show("Can Not Alter Shipped Orders");
                return;
            }

            if (Convert.ToInt32(selLine) < 0)
            {
                MessageBox.Show(Globals.FM_ORDER, "Please Select An Order Line", "Order Line?");
                return;
            }

            if (MAX_LINE > 0)
            {

                DialogResult result;

                result = DialogResult.Cancel;
                string question;
                question = " Delete Order Line# " + selLine + "?";
                result = MessageBox.Show(question + " \n\nThis Action Is Irreversible",
                            question,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);


                if (result == DialogResult.No)
                    return;

                MySqlConnection con = null;
                MySqlCommand cmd = new MySqlCommand();

                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;

                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open();


                cmd.Connection = con;
                string query = "DELETE FROM cust_order_line WHERE cust_order_id = '" + tbOrderId.Text + "' AND line_no = " + selLine + ";";
                MysqlInterface.ExecuteQuery(query);

                //MysqlInterface.ExecuteQuery(query);
                //int numRowsUpdated = cmd.ExecuteNonQuery();

                int rows = dgOrderForm.RowCount - 1;
                int ic;
                ic = 0;
                dgOrderForm.Rows.RemoveAt(selRow);

                string[,] temp_array;
                temp_array = new string[rows - 1, 25];

                for (int i = 0; i < rows - 1; i++)
                {
                    if (i != selRow)
                    {
                        for (int j = 0; j < 25; j++)
                        {
                            temp_array[ic, j] = ORDER_ARRAY[i, j];
                        }
                        ic++;
                    }
                }

                ORDER_ARRAY = temp_array;
            }
        }


        public static void fmPartLookup()
        {
            Application.Run(new fmPartLookup());
           
        }

        public int GetPartIndex(string id)
        {
            int count = 0;

            count = Globals.PART_ARRAY.GetLength(0);
            for (int i = 0; i < count; i++)
                if(Globals.PART_ARRAY[i, 0] == id)
                    return i;
            return -1;
        }

        public void ChangeCust(string CustID)
        {
            cbCustomer.Text = CustID;
            LoadCustomerInfo();
        }

        public void ChangePart()
        {
            int index = GetPartIndex(Globals.part);

            dgOrderForm.Rows[Globals.row].Cells[Globals.column].Value = Globals.part;


            //string qry = "SELECT DESCRIPTION, SELLING_PRICE FROM part where ID = '" + Globals.part + "';";
            //rdr = MysqlInterface.DoQuery(qry);
            try
            {
                string desc = "";
                string price = "";
                /*while (rdr.Read())
                {
                    desc = rdr.GetString(0);
                    price = rdr.GetString(1);
                }*/

                desc = Globals.PART_ARRAY[index, 1];
                price = Globals.PART_ARRAY[index, 4];
                dgOrderForm.Rows[Globals.row].Cells[Globals.column + 2].Value = desc;

                double lnPrice = 0.0;
                if(price != "")
                    lnPrice = Convert.ToDouble(price);

                DataGridViewCheckBoxCell cell;
                cell = dgOrderForm.Rows[Globals.row].Cells["cCustom"] as DataGridViewCheckBoxCell;
                if ((bool)dgOrderForm.Rows[Globals.row].Cells["cCustom"].Value == true)
                {
                    string panels = Globals.part.Substring(7, 1);
                    int panelNum = Convert.ToInt32(panels);
                    lnPrice = Math.Round(lnPrice + (20*panelNum), 2);
                    dgOrderForm.Rows[Globals.row].Cells[Globals.column + 2].Value = Globals.part;
                }

                lnPrice = lnPrice * Convert.ToDouble(tbDiscount.Text);
                lnPrice = Math.Round(lnPrice, 2);
                dgOrderForm.Rows[Globals.row].Cells[Globals.column + 4].Value = lnPrice.ToString();
                dgOrderForm.Rows[Globals.row].Cells[5].Value = "1";

                double gst = lnPrice * GetGSTRate();
                double pst = lnPrice * GetPSTRate();
                dgOrderForm.Rows[Globals.row].Cells[7].Value = Math.Round(gst, 2);
                dgOrderForm.Rows[Globals.row].Cells[8].Value = Math.Round(pst, 2);


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Data.ToString());
            }

        }

        private void LoadRow()
        {
            cbStyle.Text = ORDER_ARRAY[selRow, CONST_STYLE];
            tbWidth.Text = ORDER_ARRAY[selRow, CONST_WIDTH];
            tbHeight.Text = ORDER_ARRAY[selRow, CONST_HEIGHT];
            cbJambType.Text = ORDER_ARRAY[selRow, CONST_JAMB_TYPE];
            cbJambSize.Text = ORDER_ARRAY[selRow, CONST_JAMB_SIZE];
            cbSill.Text = ORDER_ARRAY[selRow, CONST_SILL];
            cbWS.Text = ORDER_ARRAY[selRow, CONST_WS];
            cbDS.Text = ORDER_ARRAY[selRow, CONST_DS];
            cbBM.Text = ORDER_ARRAY[selRow, CONST_BM];
            cbDrill.Text = ORDER_ARRAY[selRow, CONST_DRILL];
            cbLatch.Text = ORDER_ARRAY[selRow, CONST_LATCH];
            cbStrike.Text = ORDER_ARRAY[selRow, CONST_STRIKE];
            cbHingeSize.Text = ORDER_ARRAY[selRow, CONST_HINGE];
            cbHingeType.Text = ORDER_ARRAY[selRow, CONST_COLOUR];
            cbCore.Text = ORDER_ARRAY[selRow, CONST_CORE];
            tbThick.Text = ORDER_ARRAY[selRow, CONST_THICKNESS];
        }

        private void dgOrderForm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgOrderForm.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selLine = dgOrderForm.Rows[e.RowIndex].Cells[0].Value.ToString();
                selRow = e.RowIndex;
                LoadRow();
            }
            else
            {
                selLine = "-1";
                selRow = -1;
            }


            if (tbOrderId.Text == "")
                return;
            if (MAX_LINE > 0 && e.ColumnIndex == 1)
            {
                DataGridViewCheckBoxCell cell;
                cell = dgOrderForm.Rows[e.RowIndex].Cells["cCustom"] as DataGridViewCheckBoxCell;

                if ((bool)cell.Value == true)
                    cell.Value = false;
                else
                    cell.Value = true;
            }
            if (e.ColumnIndex == 4)
            {
                dgOrderForm.BeginEdit(false);
            }
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

        private void dgOrderForm_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (tbOrderId.Text == "")
            {
                changingCell = false;
                return;
            }

            string changeValue;

            changeValue = dgOrderForm.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            try
            {
                switch (e.ColumnIndex)
                {
                    case 1:
                        if (changeValue == "True")
                            ORDER_ARRAY[e.RowIndex, CONST_MOD] = "C";
                        else
                            ORDER_ARRAY[e.RowIndex, CONST_MOD] = "M";
                        break;
                    case 2:
                        ORDER_ARRAY[e.RowIndex, CONST_PARTID] = changeValue;
                        break;
                    case 4:
                        ORDER_ARRAY[e.RowIndex, CONST_DESC] = changeValue;
                        break;
                    case 5:
                        ORDER_ARRAY[e.RowIndex, CONST_ORDERED] = changeValue;
                        break;
                    case 6:
                        ORDER_ARRAY[e.RowIndex, CONST_PRICE] = changeValue;
                        break;
                    case 7:
                        ORDER_ARRAY[e.RowIndex, CONST_GST] = changeValue;
                        break;
                    case 8:
                        ORDER_ARRAY[e.RowIndex, CONST_PST] = changeValue;
                        break;
                    case 9:
                        ORDER_ARRAY[e.RowIndex, CONST_NOTES] = changeValue;
                        break;
                }
            }
            catch (Exception)
            {
                Console.Write("NULL EXCEPTION");
            }

            if (!changingCell)
            {
                changingCell = true;

                int c = e.ColumnIndex;
                string curPart = "";
                if (e.RowIndex >= 0)
                {
                    if (c == 2 && dgOrderForm.Rows[e.RowIndex].Cells[c].Value != null)
                    {

                        curPart = Globals.part = dgOrderForm.Rows[e.RowIndex].Cells[c].Value.ToString();
                        Globals.row = e.RowIndex;
                        Globals.column = e.ColumnIndex;
                        Globals.FM_PART_LOOKUP = new fmPartLookup("OrderForm", curPart);
                        Globals.FM_PART_LOOKUP.ShowDialog();
                        Globals.FM_PART_LOOKUP.BringToFront();

                    }
                    if (c == 5 && dgOrderForm.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {

                        double qty = Convert.ToInt32(dgOrderForm.Rows[e.RowIndex].Cells[5].Value.ToString());
                        double price = Convert.ToDouble(dgOrderForm.Rows[e.RowIndex].Cells[6].Value.ToString());
                        double gst = qty * price * GetGSTRate(); ;
                        Globals.row = e.RowIndex;
                        double pst = qty * price * GetPSTRate();
                        dgOrderForm.Rows[e.RowIndex].Cells[7].Value = Math.Round(gst, 2);
                        dgOrderForm.Rows[e.RowIndex].Cells[8].Value = Math.Round(pst, 2);


                    }
                    if (c == 6 && dgOrderForm.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        if (dgOrderForm.Rows[e.RowIndex].Cells[5].Value != null)
                        {
                            double qty = Convert.ToInt32(dgOrderForm.Rows[e.RowIndex].Cells[5].Value.ToString());
                            double price = Convert.ToDouble(dgOrderForm.Rows[e.RowIndex].Cells[6].Value.ToString());
                            double gst = qty * price * GetGSTRate();
                            double pst = qty * price * GetPSTRate();
                            dgOrderForm.Rows[e.RowIndex].Cells[7].Value = Math.Round(gst, 2);
                            dgOrderForm.Rows[e.RowIndex].Cells[8].Value = Math.Round(pst, 2);
                        }


                    }
                }

                Globals.partSelected = false;
                changingCell = false;
            }
        }


        private void LoadCustomerInfo()
        {

            MySqlDataReader rdr = null;
            string cust = cbCustomer.Text;
            string qry = "SELECT DISCOUNT, CARRIER_ID, SHIPTO_ID, PST_NUM, CONTACT, STATE FROM customer where ID = '" + cust + "';";
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0)) disc = rdr.GetFloat(0); else disc = 1.0;
                if (!rdr.IsDBNull(1)) cbCarrier.Text = rdr.GetString(1);
                if (!rdr.IsDBNull(2)) cbShipTo.Text = rdr.GetString(2);
                if (!rdr.IsDBNull(3)) pNum = rdr.GetString(3);
                if (!rdr.IsDBNull(4)) cbContact.Text = rdr.GetString(4);

                tbDiscount.Text = Math.Round(disc, 3).ToString();
                chGST.Checked = true;
                if (pNum == "")
                    chPST.Checked = true;
                else
                    chPST.Checked = false;
                string cState = "Not Approved";
                if (!rdr.IsDBNull(5)) cState= rdr.GetString(5);
                //if (cState != "Approved")
                  //  lbWarning.Visible = true;
                //else
                    lbWarning.Visible = false;

            }

            string shipAddress = "";
            qry = "SELECT address_id FROM address WHERE USER_ID = '" + cust + "';";
            rdr = MysqlInterface.DoQuery(qry);
            cbShipTo.Items.Clear();
            while (rdr.Read())
            {
                shipAddress = rdr.GetString(0);
                cbShipTo.Items.Add(shipAddress);
            }
            MysqlInterface.close();

            qry = "SELECT contact_name FROM contact WHERE owner_id = '" + cust + "';";
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                shipAddress = rdr.GetString(0);
                cbContact.Items.Add(shipAddress);
            }
            MysqlInterface.close();
        }

        private void cbCustomer_Leave(object sender, EventArgs e)
        {
            if (cust_id == cbCustomer.Text)
                return;
            LoadCustomerInfo();
        }

        private void CreateNewOrder()
        {

            ClearSheet();
            EnableForm();
            cbCustomer.Focus();
            tbFOB.Text = "FOB Origin";
            MySqlDataReader rdr = null;
            string id = "";
            string qry = "SELECT order_id FROM current_values;";
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                id = rdr.GetString(0);
            }


            tbOrderId.Text = id;
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            int order_id = Convert.ToInt32(tbOrderId.Text);

            try
            {
                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;

                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open(); //open the connection
                String cmdText = "INSERT INTO customer_order (id)" +
                "VALUES(@id)";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", order_id);
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewOrder();

        }

        private void ClearSheet()
        {
            dgOrderForm.Rows.Clear();
            MAX_LINE = 0;
            dtActualShip.Value = DateTime.Now;
            dtDesiredShip.Value = DateTime.Now;
            tbFOB.Text = "";
            dtOrderDate.Value = DateTime.Now;
            tbOrderId.Text = "";
            tbNotes.Text = "";
            tbCustPO.Text = "";
            cbCarrier.Text = "";
            cbCustomer.Text = "";
            cbShipTo.Text = "";
            cbShipTo.Items.Clear();
            cbStatus.Text = "";
            cbContact.Items.Clear();
            cbContact.Text = "";

            cbBM.Text = "";
            cbCore.Text = "";
            cbDrill.Text = "";
            cbDS.Text = "";
            cbHingeSize.Text = "";
            cbHingeType.Text = "";
            cbJambSize.Text = "";
            cbJambType.Text = "";
            cbLatch.Text = "";
            cbSill.Text = "";
            cbStrike.Text = "";
            cbStyle.Text = "";
            cbType.Text = "";
            cbWS.Text = "";
            tbHeight.Text = "";
            tbThick.Text = "";
            tbTag.Text = "";
            tbWidth.Text = "";
        }

        private void DeleteOrder()
        {

            DialogResult result;

            result = DialogResult.Cancel;

            if (IsShipped())
            {
                MessageBox.Show(Globals.FM_ORDER, "Can Not Delete Shipped Order", "Shipped");
                return;
            }
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
                cmd.CommandText = "DELETE FROM cust_order_line WHERE cust_order_id = " + tbOrderId.Text + ";";
                int numRowsUpdated = cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM customer_order WHERE id = " + tbOrderId.Text + ";";
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

        private void tbOrderId_Leave(object sender, EventArgs e)
        {
            if (id == tbOrderId.Text)
                return;
            MAX_LINE = 0;
            if (tbOrderId.Text != "")
                ChangeIndex(tbOrderId.Text);



        }

        private void fmCustomerOrderEntry_FormClosing(object sender, FormClosingEventArgs e)
        {

            ClearSheet();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void CreateNewQuote()
        {
            ClearSheet();
            cbCustomer.Focus();
            cbStatus.Text = "Quoted";
            tbFOB.Text = "FOB Origin";
            MySqlDataReader rdr = null;
            string id = "";
            string qry = "SELECT order_id FROM current_values;";
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                id = rdr.GetString(0);
            }
            tbOrderId.Text = id;
        }

        private void newQuoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewQuote();
        }

        private void sendQuoteToolStripMenuItem_Click(object sender, EventArgs e)
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
                dir = "Quote.rpt";
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
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, "quotations//quote-" + orderid + ".pdf");


                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                string directory = Directory.GetCurrentDirectory();
                orderid = tbOrderId.Text;
                directory = directory + "\\quotations\\quote-" + orderid + ".pdf";
                mailItem.Attachments.Add(directory);
                mailItem.Subject = "Pinnacle Glass Doors - Quote# " + orderid;
                mailItem.To = email;

                string name = contact;
                if (contact != "")
                {
                    int pos = name.IndexOf(' ');
                    if(pos != -1)
                        name = name.Substring(0, pos);
                }
                mailItem.Body = "Hi " + name + ",\n\n" + "Here is the quote you requested. Please let me know if you would like to proceed with the order" + 
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sendConfirmationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDataReader rdr = null;
                string email = "";
                string contact = "";
                string qry = "select co.contact_email, co.contact_name from customer c inner join contact co on co.owner_id = c.id where c.id = '" + 
                    cbCustomer.Text + "' and co.contact_name = '" + cbContact.Text + "';";
                rdr = MysqlInterface.DoQuery(qry);
                while (rdr.Read())
                {
                    if(!rdr.IsDBNull(0)) email = rdr.GetString(0);
                    if (!rdr.IsDBNull(1)) contact = rdr.GetString(1);
                }

                string orderid = tbOrderId.Text;
                ReportDocument cryRpt = new ReportDocument();
                string dir = System.IO.Directory.GetCurrentDirectory();
                dir = "Confirmation.rpt";
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
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, "confirmations//confirmation-" + orderid + ".pdf");


                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                string directory = Directory.GetCurrentDirectory();
                orderid = tbOrderId.Text;
                string po = tbCustPO.Text;
                directory = directory + "\\confirmations\\confirmation-" + orderid + ".pdf";
                mailItem.Attachments.Add(directory);
                mailItem.Subject = "Pinnacle Glass Doors - Confirmation# " + orderid + " - PO# " + po;
                mailItem.To = email;

                string name = contact;
                if (contact != "")
                {
                    int pos = name.IndexOf(' ');
                    if (pos != -1)
                        name = name.Substring(0, pos);
                }
                mailItem.Body = "Hi " + name + ",\n\n" + "Attached is a confirmation of your purchase order " + po + "." + 
                    "\n\nThank You,\n\n" + Globals.USER_NAME;
                mailItem.Importance = Outlook.OlImportance.olImportanceNormal;
                try 
                    { mailItem.Display(true); }
                catch
                    (Exception ) { }

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

        private void AddSkid(int id, string tID)
        {
            string qry = "INSERT INTO pallet (id, ship_id, cust_id, truck_id, width, length, height)" +
            " VALUES (" + id.ToString() + ", '" + cbShipTo.Text + "', '" + cbCustomer.Text + "', " + tID +
            ", 32, 32, 86);";

            MysqlInterface.ExecuteQuery(qry);
        }

        private void AddPart(int curBox, int curSkid, string tID, string part, int line)
        {
            string qry = "INSERT INTO box (id, truck_id, pallet_id, part_id, qty, order_id, ord_line_no)" +
            " VALUES (" + curBox.ToString() + ", " + tID + ", " + curSkid.ToString() + ", '" + part +
            "', 1, '" + tbOrderId.Text + "', " + line.ToString() + ");";

            MysqlInterface.ExecuteQuery(qry);
        }

        private void createNewTruckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string desc = "Cust: " + cbCustomer.Text + " PO: " + tbCustPO.Text;
            string carrier = cbCarrier.Text;
            string tId = Globals.CreateNewTruck(desc, carrier);
            int curSkid = 0;
            int curBox = Globals.GetCurrentBox();
            line_no = 0;
            int skidSize = 12;
            int rcount = dgOrderForm.Rows.Count;
            MysqlInterface.init();
            for (int i = 0; i < rcount - 1; i++)
            {
                string part = dgOrderForm.Rows[i].Cells[2].Value.ToString();
                int qty = Convert.ToInt32(dgOrderForm.Rows[i].Cells[5].Value);
                line_no = Convert.ToInt32(dgOrderForm.Rows[i].Cells[0].Value);

                for (int j = 0; j < qty; j++)
                {
                    if (skidSize == 12)
                    {
                        skidSize = 0;
                        curSkid++;
                        AddSkid(curSkid, tId);
                    }

                    AddPart(curBox, curSkid, tId, part, line_no);
                    skidSize++;
                    curBox++;
                }
            }
            MysqlInterface.close();

            string qry = "UPDATE current_values SET box_id = " + curBox.ToString() + ";";
            MysqlInterface.ExecuteQuery(qry);



        }

        private void tbOrderId_Enter(object sender, EventArgs e)
        {
            id = tbOrderId.Text;
        }

        private void cbCustomer_Enter(object sender, EventArgs e)
        {
            cust_id = cbCustomer.Text;
        }

        private void projectCostingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oid = tbOrderId.Text;
            Globals.FM_PROJECT_COSTING = new fmProjectCosting(oid);
            Globals.FM_PROJECT_COSTING.Show();
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            /*
            int x, y;
            x = cbCustomer.Location.X + Globals.FM_ORDER.Location.X + 10;
            y = cbCustomer.Location.Y + Globals.FM_ORDER.Location.Y + 55;

            Point p = new Point(x, y);
            Globals.FM_MESSAGEBOX = new fmMessageBox("Select A Customer From The Dropdown Box And Hit TAB, \n\nOr Click .. For A Customer List", p);
            Globals.FM_MESSAGEBOX.Show();
            */
            HideButtons();
            cbStatus.Text = "firmed";
            CreateNewOrder();


            //Globals.FM_MESSAGEBOX.BringToFront();
            
        }

        private void btQuote_Click(object sender, EventArgs e)
        {
            HideButtons();
            cbStatus.Text = "Quoted";
            CreateNewOrder();
        }


        private void cbCustomer_MouseClick(object sender, MouseEventArgs e)
        {
            /*if(Globals.FM_MESSAGEBOX != null)
                Globals.FM_MESSAGEBOX.Close();*/

        }

        private void cbShipTo_Enter(object sender, EventArgs e)
        {
            /*
            int x, y;
            x = cbShipTo.Location.X + Globals.FM_ORDER.Location.X + 10;
            y = cbShipTo.Location.Y + Globals.FM_ORDER.Location.Y + 55;

            Point p = new Point(x, y);
            Globals.FM_MESSAGEBOX = new fmMessageBox("Select A Customer From The Dropdown Box And Hit TAB, \n\nOr Click .. For A Customer List", p);
            Globals.FM_MESSAGEBOX.Show();
             * */
        }

        bool expanded = false;


        private void ExpandForm()
        {
            Point p = btExpand.Location;

            while (Width < 1300)
            {
                Width = Width + 50;
                p.X = + 50;
                btExpand.Location = p;
                Refresh();
            }

            Width = 1300;
            p.X = 1260;
            btExpand.Location = p;
                
            btExpand.Text = "<<";
        }

        private void ShrinkForm()
        {

            Point p = btExpand.Location;

            while (Width > 880)
            {
                Width = Width - 20;
                p.X = - 20;
                btExpand.Location = p;
            }

            Width = 880;
            p.X = 844;
            btExpand.Location = p;

            btExpand.Text = ">>";
        }

        private void btExpand_Click(object sender, EventArgs e)
        {
            if (!expanded)
            {
                ExpandForm();
            }
            else
            {
                ShrinkForm();
            }
            expanded = !expanded;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {


            ORDER_ARRAY[selRow, CONST_STYLE] = cbStyle.Text;
            ORDER_ARRAY[selRow, CONST_WIDTH] = tbWidth.Text;
            ORDER_ARRAY[selRow, CONST_HEIGHT] = tbHeight.Text;
            ORDER_ARRAY[selRow, CONST_JAMB_TYPE] = cbJambType.Text;
            ORDER_ARRAY[selRow, CONST_JAMB_SIZE] = cbJambSize.Text;
            ORDER_ARRAY[selRow, CONST_SILL] = cbSill.Text;
            ORDER_ARRAY[selRow, CONST_WS] = cbWS.Text;
            ORDER_ARRAY[selRow, CONST_DS] = cbDS.Text;
            ORDER_ARRAY[selRow, CONST_BM] = cbBM.Text;
            ORDER_ARRAY[selRow, CONST_DRILL] = cbDrill.Text;
            ORDER_ARRAY[selRow, CONST_LATCH] = cbLatch.Text;
            ORDER_ARRAY[selRow, CONST_STRIKE] = cbStrike.Text;
            ORDER_ARRAY[selRow, CONST_HINGE] = cbHingeSize.Text;
            ORDER_ARRAY[selRow, CONST_COLOUR] = cbHingeType.Text;
            ORDER_ARRAY[selRow, CONST_CORE] = cbCore.Text;
            ORDER_ARRAY[selRow, CONST_THICKNESS] = tbThick.Text;
        }

        private void dgOrderForm_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgOrderForm.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selLine = dgOrderForm.Rows[e.RowIndex].Cells[0].Value.ToString();
                selRow = e.RowIndex;
                LoadRow();
            }
        }

        private void copyCustomerOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableForm();
            cbCustomer.Focus();
            cbStatus.Text = "Firmed";
            MySqlDataReader rdr = null;
            string id = "";
            string qry = "SELECT order_id FROM current_values;";
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                id = rdr.GetString(0);
            }
            tbOrderId.Text = id;
            SaveCustomerOrder(id);
        }

        private void btNew_MouseHover(object sender, EventArgs e)
        {
            btNew.FlatAppearance.BorderSize = 2;
        }

        private void btNew_MouseLeave(object sender, EventArgs e)
        {
            btNew.FlatAppearance.BorderSize = 1;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            Globals.FM_ORDER_SEARCH = new fmOrderSearch("CustOrder");
            Globals.FM_ORDER_SEARCH.ShowDialog();
            Globals.FM_ORDER_SEARCH.BringToFront();
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderSize = 2;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderSize = 1;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
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

        private void pbNew_Click(object sender, EventArgs e)
        {
            HideButtons();
            cbStatus.Text = "firmed";
            CreateNewOrder();
        }

        private void btNewDropDown_Click(object sender, EventArgs e)
        {
            if (btNewOrder.Visible)
                HideButtons();
            else
            {
                btNewOrder.Visible = true;
                btNewQuote.Visible = true;
            }
        }

        private void btNewQuote_Click(object sender, EventArgs e)
        {
            HideButtons();
            cbStatus.Text = "Quoted";
            CreateNewOrder();
        }

        private void btNewOrder_Click(object sender, EventArgs e)
        {
            HideButtons();
            CreateNewOrder();
        }

        private void btReportsDropDown_Click(object sender, EventArgs e)
        {
            if (btWorkOrder.Visible)
                HideButtons();
            else
            {
                btWorkOrder.Visible = true;
                btPacklist.Visible = true;
                btProCost.Visible = true;
            }
        }

        private void btSendDropDown_Click(object sender, EventArgs e)
        {
            if (btSendQuote.Visible)
                HideButtons();
            else
            {
                btSendQuote.Visible = true;
                btSendConfirm.Visible = true;
            }
        }

        private void btWorkOrder_Click(object sender, EventArgs e)
        {
            HideButtons();
            oid = tbOrderId.Text;
            Globals.FM_WORK_ORDER = new fmWorkorder(oid);
            Globals.FM_WORK_ORDER.Show();
        }

        private void btPacklist_Click(object sender, EventArgs e)
        {
            HideButtons();
            oid = tbOrderId.Text;
            Globals.FM_PACKLIST = new fmPacklist(oid);
            Globals.FM_PACKLIST.Show();
        }

        private void btProCost_Click(object sender, EventArgs e)
        {
            HideButtons();
            oid = tbOrderId.Text;
            Globals.FM_PROJECT_COSTING = new fmProjectCosting(oid);
            Globals.FM_PROJECT_COSTING.Show();
        }

        private void btSendQuote_Click(object sender, EventArgs e)
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
                dir = "Quote.rpt";
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
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, "quotations//quote-" + orderid + ".pdf");


                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                string directory = Directory.GetCurrentDirectory();
                orderid = tbOrderId.Text;
                directory = directory + "\\quotations\\quote-" + orderid + ".pdf";
                mailItem.Attachments.Add(directory);
                mailItem.Subject = "Pinnacle Glass Doors - Quote# " + orderid;
                mailItem.To = email;

                string name = contact;
                if (contact != "")
                {
                    int pos = name.IndexOf(' ');
                    if (pos != -1)
                        name = name.Substring(0, pos);
                }
                mailItem.Body = "Hi " + name + ",\n\n" + "Here is the quote you requested. Please let me know if you would like to proceed with the order" +
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

        private void btSendConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDataReader rdr = null;
                string email = "";
                string contact = "";
                string qry = "select co.contact_email, co.contact_name from customer c inner join contact co on co.owner_id = c.id where c.id = '" +
                    cbCustomer.Text + "' and co.contact_name = '" + cbContact.Text + "';";
                rdr = MysqlInterface.DoQuery(qry);
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) email = rdr.GetString(0);
                    if (!rdr.IsDBNull(1)) contact = rdr.GetString(1);
                }

                string orderid = tbOrderId.Text;
                ReportDocument cryRpt = new ReportDocument();
                string dir = System.IO.Directory.GetCurrentDirectory();
                dir = "Confirmation.rpt";
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
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, "confirmations//confirmation-" + orderid + ".pdf");


                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                string directory = Directory.GetCurrentDirectory();
                orderid = tbOrderId.Text;
                string po = tbCustPO.Text;
                directory = directory + "\\confirmations\\confirmation-" + orderid + ".pdf";
                mailItem.Attachments.Add(directory);
                mailItem.Subject = "Pinnacle Glass Doors - Confirmation# " + orderid + " - PO# " + po;
                mailItem.To = email;

                string name = contact;
                if (contact != "")
                {
                    int pos = name.IndexOf(' ');
                    if (pos != -1)
                        name = name.Substring(0, pos);
                }
                mailItem.Body = "Hi " + name + ",\n\n" + "Attached is a confirmation of your purchase order " + po + "." +
                    "\n\nThank You,\n\n" + Globals.USER_NAME;
                mailItem.Importance = Outlook.OlImportance.olImportanceNormal;
                try
                { mailItem.Display(true); }
                catch
                    (Exception) { }

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

        private void DuplicateOrder()
        {
            ClearSheet();
            EnableForm();
            cbCustomer.Focus();
            cbStatus.Text = "Firmed";
            tbFOB.Text = "FOB Origin";
            MySqlDataReader rdr = null;
            string id = "";
            string qry = "SELECT order_id FROM current_values;";
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                id = rdr.GetString(0);
            }
            tbOrderId.Text = id;
            SaveCustomerOrder(tbOrderId.Text);
        }

        private void btDuplicate_Click(object sender, EventArgs e)
        {
            DuplicateOrder();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveCustomerOrder(tbOrderId.Text);
        }

        private void btReports_Click(object sender, EventArgs e)
        {
            if (btWorkOrder.Visible)
                HideButtons();
            else
            {
                btWorkOrder.Visible = true;
                btPacklist.Visible = true;
                btProCost.Visible = true;
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (btSendQuote.Visible)
                HideButtons();
            else
            {
                btSendQuote.Visible = true;
                btSendConfirm.Visible = true;
            }
        }

        private void HideButtons()
        {
            btSendQuote.Visible = false;
            btSendConfirm.Visible = false;
            btWorkOrder.Visible = false;
            btPacklist.Visible = false;
            btProCost.Visible = false;
            btNewOrder.Visible = false;
            btNewQuote.Visible = false;
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            Globals.FM_ORDER_SEARCH = new fmOrderSearch("CustOrder");
            Globals.FM_ORDER_SEARCH.ShowDialog();
            Globals.FM_ORDER_SEARCH.BringToFront();
        }

        private void pbReports_Click(object sender, EventArgs e)
        {
            if (btWorkOrder.Visible)
                HideButtons();
            else
            {
                btWorkOrder.Visible = true;
                btPacklist.Visible = true;
                btProCost.Visible = true;
            }
        }

        private void pbReports_MouseHover(object sender, EventArgs e)
        {
            btReports.FlatAppearance.BorderSize = 2;
        }

        private void pbDuplicate_Click(object sender, EventArgs e)
        {
            DuplicateOrder();
        }

        private void pbDuplicate_MouseHover(object sender, EventArgs e)
        {
            btDuplicate.FlatAppearance.BorderSize = 2;
        }

        private void pbDuplicate_MouseLeave(object sender, EventArgs e)
        {
            btDuplicate.FlatAppearance.BorderSize = 1;

        }

        private void pbSend_Click(object sender, EventArgs e)
        {
            if (btSendQuote.Visible)
                HideButtons();
            else
            {
                btSendQuote.Visible = true;
                btSendConfirm.Visible = true;
            }
        }

        private void pbSend_MouseHover(object sender, EventArgs e)
        {

            btSend.FlatAppearance.BorderSize = 2;
        }

        private void pbSend_MouseLeave(object sender, EventArgs e)
        {

            btSend.FlatAppearance.BorderSize = 1;
        }

        private void pbSave_Click(object sender, EventArgs e)
        {

            SaveCustomerOrder(tbOrderId.Text);
        }

        private void pbSave_MouseHover(object sender, EventArgs e)
        {
            btSend.FlatAppearance.BorderSize = 1;

        }

        private void pbSave_MouseLeave(object sender, EventArgs e)
        {
            btSend.FlatAppearance.BorderSize = 1;

        }

        private void fmCustomerOrderEntry_Click(object sender, EventArgs e)
        {
            HideButtons();
        }

        private void btDeleteOrder_Click(object sender, EventArgs e)
        {
            DeleteOrder();

        }

        private void pbDeleteOrder_Click(object sender, EventArgs e)
        {
            DeleteOrder();
        }

        private void pbDeleteOrder_MouseHover(object sender, EventArgs e)
        {
            btDeleteOrder.FlatAppearance.BorderSize = 2;
        }

        private void pbDeleteOrder_MouseLeave(object sender, EventArgs e)
        {

            btDeleteOrder.FlatAppearance.BorderSize = 1;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DeleteOrderLine();
        }

    



    

    }

             
}
