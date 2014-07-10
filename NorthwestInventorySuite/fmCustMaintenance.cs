using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace NorthwestInventoryManager
{
    public partial class fmCustMaintenance : Form
    {

        static string id;
        int soldToUpdate = 0;
        const int SOLD_TO = 1;
        const int BILL_TO = 0;
        const int SHIP_TO = 3;

        public fmCustMaintenance()
        {
            InitializeComponent();
        }



        public void LoadCustomers()
        {
            try
            {
                int count = 0;
                string custName;
                cbCustID.Text = "";
                cbCustID.Items.Clear();
                count = Globals.CUSTOMER_ARRAY.GetLength(0);
                for (int i = 0; i < count; i++)
                {
                    custName = Globals.CUSTOMER_ARRAY[i, 0] + " - " + Globals.CUSTOMER_ARRAY[i, 1];
                    cbCustID.Items.Add(custName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data.ToString());
            }
   
        }

        private void LoadCarriers()
        {
            int count = 0;
            count = Globals.CARRIER_ARRAY.Length;
            for (int i = 0; i < count; i++)
                cbCarrier.Items.Add(Globals.CARRIER_ARRAY[i]);

        }

        private void ClearForm()
        {
            tbNotes.Text = "";
            tbBillCity.Text = "";
            tbBillCountry.Text = "";
            tbBillName.Text = "";
            tbBillPCode.Text = "";
            tbBillProvince.Text = "";
            tbBillStreet.Text = "";
            tbPSTNumber.Text = "";
            tbSoldCity.Text = "";
            cbContact.Text = "";
            cbContact.Items.Clear();
            tbSoldCountry.Text = "";
            tbEmail.Text = "";
            tbFax.Text = "";
            tbSoldName.Text = "";
            tbSoldPCode.Text = "";
            tbPhone.Text = "";
            tbSoldProvince.Text = "";
            tbSoldStreet.Text = "";
            tbTaxCode.Text = "";
            tbDiscount.Text = "";
            tbTitle.Text = "";

            cbBillTo.Text = "";
            cbCarrier.Text = "";
            cbShipTo.Text = "";
            cbSoldTo.Text = "";
            //LoadCustomers();
            //cbCustID.Text = "";
        }

        private void fmCustMaintenance_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadCustomers();
            LoadCarriers();
        }


        private void btShipTo_Click(object sender, EventArgs e)
        {
            soldToUpdate = SHIP_TO;
            id = cbShipTo.Text;
            string cId = GetCurrentCustID();
            Globals.FM_ADDRESS = new fmAddress(id, cId, "customer", "CUSTMAIN");
            Globals.FM_ADDRESS.Show();
        }

        private void btCarrier_Click(object sender, EventArgs e)
        {
            Globals.FM_CARRIER = new fmCarrier();
            Globals.FM_CARRIER.Show();
        }

        public void UpdateAddress(string address)
        {

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
            if(soldToUpdate == SOLD_TO)
                cmd.CommandText = "UPDATE customer SET address = '" + address +
                    "' WHERE id = '" + GetCurrentCustID() + "';";
            else if (soldToUpdate == BILL_TO)
                cmd.CommandText = "UPDATE customer SET bill_address = '" + address +
                    "' WHERE id = '" + GetCurrentCustID() + "';";
            else if (soldToUpdate == SHIP_TO)
                cmd.CommandText = "UPDATE customer SET shipto_id = '" + address +
                    "' WHERE id = '" + GetCurrentCustID() + "';";
            int numRowsUpdated = cmd.ExecuteNonQuery();
            ClearForm();
            LoadCustomer(GetCurrentCustID());
        }

        public void UpdateContact(string cName)
        {

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
            cmd.CommandText = "UPDATE customer SET contact = '" + cName +
                "' WHERE id = '" + GetCurrentCustID() + "';";
            int numRowsUpdated = cmd.ExecuteNonQuery();
            ClearForm();
            LoadCustomer(GetCurrentCustID());
        }



        private void btSoldTo_Click(object sender, EventArgs e)
        {
            soldToUpdate = 1;
            id = cbSoldTo.Text;
            string cId = GetCurrentCustID();
            Globals.FM_ADDRESS = new fmAddress(id, cId, "customer", "CUSTMAIN");
            Globals.FM_ADDRESS.Show();
        }

        private void btBillTo_Click(object sender, EventArgs e)
        {
            soldToUpdate = 0;
            id = cbBillTo.Text;
            string cId = GetCurrentCustID();
            Globals.FM_ADDRESS = new fmAddress(id, cId, "customer", "CUSTMAIN");
            Globals.FM_ADDRESS.Show();
        }

        private void LoadCustomerAddressBook(string cId)
        {
            MySqlDataReader rdr = null;

            string qry = "SELECT ADDRESS_ID FROM address where USER_ID = '" + cId + "';";
            rdr = MysqlInterface.DoQuery(qry);
            string id;
            cbShipTo.Items.Clear();
            cbBillTo.Items.Clear();
            cbSoldTo.Items.Clear();
            while (rdr.Read())
            {
                id = rdr.GetString(0);
                cbShipTo.Items.Add(id);
                cbBillTo.Items.Add(id);
                cbSoldTo.Items.Add(id);
            }

            MysqlInterface.close();
        }

        private void LoadCustomerDetails(string cId)
        {
            MySqlDataReader rdr = null;

            string name = "";
            string address = "";
            string bill_name = "";
            string bill_address = "";
            string discount = "";
            string contact = "";
            string fax = "";
            string carrier_id = "";
            string shipto_id = "";
            string tax_code = "";
            string pst_num = "";
            string notes = "";

            string qry = "SELECT NAME, ADDRESS, BILL_NAME, BILL_ADDRESS, DISCOUNT, FAX, CARRIER_ID, SHIPTO_ID, STATE, PST_NUM, NOTES, CONTACT FROM customer WHERE ID = '" + cId + "';";

            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0))
                    tbSoldName.Text = name = rdr.GetString(0);
                if (!rdr.IsDBNull(1))
                    cbSoldTo.Text = address = rdr.GetString(1);
                if (!rdr.IsDBNull(2))
                    tbBillName.Text = bill_name = rdr.GetString(2);
                if (!rdr.IsDBNull(3))
                    cbBillTo.Text = bill_address = rdr.GetString(3);
                if (!rdr.IsDBNull(4))
                    tbDiscount.Text = discount = rdr.GetString(4);
                if (!rdr.IsDBNull(5))
                    tbFax.Text = fax = rdr.GetString(5);
                if (!rdr.IsDBNull(6))
                    cbCarrier.Text = carrier_id = rdr.GetString(6);
                if (!rdr.IsDBNull(7))
                    cbShipTo.Text = shipto_id = rdr.GetString(7);
                if (!rdr.IsDBNull(8))
                    tbTaxCode.Text = tax_code = rdr.GetString(8);
                if (!rdr.IsDBNull(9))
                    tbPSTNumber.Text = pst_num = rdr.GetString(9);
                if (!rdr.IsDBNull(10))
                    tbNotes.Text = notes = rdr.GetString(10);
                if (!rdr.IsDBNull(11))
                    contact = rdr.GetString(11);
            }

            MysqlInterface.close();

            qry = "SELECT CONTACT_NAME, CONTACT_TITLE, CONTACT_EMAIL, CONTACT_PHONE FROM contact WHERE OWNER_ID = '" + cId + "';";

            rdr = MysqlInterface.DoQuery(qry);
            string cName = "";
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0))
                {
                    cName = rdr.GetString(0);
                    cbContact.Items.Add(cName);
                }
                if (cName == contact)
                {
                    cbContact.Text = cName;
                    if (!rdr.IsDBNull(1))
                        tbTitle.Text = rdr.GetString(1);
                    if (!rdr.IsDBNull(2))
                        tbEmail.Text = rdr.GetString(2);
                    if (!rdr.IsDBNull(3))
                        tbPhone.Text = rdr.GetString(3);
                }
            }

            MysqlInterface.close();
        }

        private void LoadShippingBilling(string cId)
        {

            string address = "";
            string city = "";
            string province = "";
            string country = "";
            string postal_code = "";

            string qry = "SELECT address, city, province, country, postal_code, contact FROM address where ADDRESS_ID = '" + cbSoldTo.Text + "';";
            MySqlDataReader rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0)) tbSoldStreet.Text = address = rdr.GetString(0);
                if (!rdr.IsDBNull(1)) tbSoldCity.Text = city = rdr.GetString(1);
                if (!rdr.IsDBNull(2)) tbSoldProvince.Text = province = rdr.GetString(2);
                if (!rdr.IsDBNull(3)) tbSoldCountry.Text = country = rdr.GetString(3);
                if (!rdr.IsDBNull(4)) tbSoldPCode.Text = postal_code = rdr.GetString(4);
            }

            address = "";
            city = "";
            province = "";
            country = "";
            postal_code = "";

            qry = "SELECT address, city, province, country, postal_code, contact FROM address where ADDRESS_ID = '" + cbBillTo.Text + "';";
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0)) tbBillStreet.Text = address = rdr.GetString(0);
                if (!rdr.IsDBNull(1)) tbBillCity.Text = city = rdr.GetString(1);
                if (!rdr.IsDBNull(2)) tbBillProvince.Text = province = rdr.GetString(2);
                if (!rdr.IsDBNull(3)) tbBillCountry.Text = country = rdr.GetString(3);
                if (!rdr.IsDBNull(4)) tbBillPCode.Text = postal_code = rdr.GetString(4);
            }

            MysqlInterface.close();
        }

        public void LoadCustomer(string cId)
        {


            try
            {
                int count = 0;
                string custName;
                count = Globals.CUSTOMER_ARRAY.GetLength(0);
                for (int i = 0; i < count; i++)
                {
                    custName = Globals.CUSTOMER_ARRAY[i, 0] + " - " + Globals.CUSTOMER_ARRAY[i, 1];
                    if (Globals.CUSTOMER_ARRAY[i, 0] == cId)
                        cbCustID.Text = custName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data.ToString());
            }


            LoadCustomerAddressBook(cId);
            LoadCustomerDetails(cId);
            LoadShippingBilling(cId);

        }

        private void cbCustID_Leave(object sender, EventArgs e)
        {
            ClearForm();
            if (GetCurrentCustID() == "")
                return;
            else
                LoadCustomer(GetCurrentCustID());
            
        }

        private string GetCurrentCustID()
        {
            string id = cbCustID.Text;
            if (id.Length < 7)
                return "";
            id = cbCustID.Text.Substring(0, 6);
            return id;
        }

        private void SaveCustomer()
        {
            string name = tbSoldName.Text;
            string address = cbSoldTo.Text;
            string bill_name = tbBillName.Text;
            string bill_address = cbBillTo.Text;
            string discount = tbDiscount.Text;
            string contact = cbContact.Text;
            string phone = tbPhone.Text;
            string fax = tbFax.Text;
            string email = tbEmail.Text;
            string carrier_id = cbCarrier.Text;
            string shipto_id = cbShipTo.Text;
            string tax_code = tbTaxCode.Text;
            string pst_num = tbPSTNumber.Text;

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
                Globals.FM_SAVE = new fmSaveDialogue("Saving Customer Info");
                Globals.FM_SAVE.Show();
                Globals.FM_SAVE.Refresh();

                Globals.FM_SAVE.ChangeText("Customer Information");

                cmd.CommandText = "UPDATE customer SET name = '" + name + "', address = '" + address + "', bill_name = '" + bill_name + "', bill_address = '" + bill_address +
                    "', discount = '" + discount + "', contact = '" + contact + "', phone = '" + phone + "', fax = '" + fax +
                    "', email = '" + email + "', carrier_id = '" + carrier_id + "', shipto_id = '" + shipto_id + "', state = '" + tax_code +
                    "', pst_num = '" + pst_num + "', notes = '" + tbNotes.Text +
                    "' WHERE id = '" + GetCurrentCustID() + "';";
                int numRowsUpdated = cmd.ExecuteNonQuery();

                Globals.FM_SAVE.Hide();
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

        private void btSave_Click(object sender, EventArgs e)
        {
            SaveCustomer();
        }



        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.FM_NEW_CUSTOMER = new fmNewCustomer();
            Globals.FM_NEW_CUSTOMER.Show();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SendEmail()
        {
            try
            {
                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.Subject = "Pinnacle Glass Doors";
                mailItem.To = tbEmail.Text;
                string name = cbContact.Text;
                int pos = name.IndexOf(' ');
                if (pos > 0)
                    name = name.Substring(0, pos);
                mailItem.Body = "Hi " + name + ",\n\n";
                mailItem.Importance = Outlook.OlImportance.olImportanceNormal;
                mailItem.Display(true);
            }
            catch (Exception eX)
            {
                throw new Exception("cDocument: Error occurred trying to Create an Outlook Email"
                                    + Environment.NewLine + eX.Message);
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        private void cbContact_Leave(object sender, EventArgs e)
        {
            string cId = GetCurrentCustID();
            string contactId = cbContact.Text;
            string qry = "SELECT CONTACT_TITLE, CONTACT_EMAIL, CONTACT_PHONE FROM contact WHERE OWNER_ID = '" + cId + 
                "' AND CONTACT_NAME = '" + contactId + "';";

            MySqlDataReader rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0))
                    tbTitle.Text = rdr.GetString(0);
                if (!rdr.IsDBNull(1))
                    tbEmail.Text = rdr.GetString(1);
                if (!rdr.IsDBNull(2))
                    tbPhone.Text = rdr.GetString(2);
            }

            MysqlInterface.close();
        }

        private void btContact_Click(object sender, EventArgs e)
        {
            id = cbSoldTo.Text;
            string cId = GetCurrentCustID();
            Globals.FM_CONTACT = new fmContact(cId);
            Globals.FM_CONTACT.Show();
        }

        private void cbSoldTo_Leave(object sender, EventArgs e)
        {
            LoadShippingBilling(GetCurrentCustID());
        }

        private void cbBillTo_Leave(object sender, EventArgs e)
        {
            LoadShippingBilling(GetCurrentCustID());
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

       }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dir = System.IO.Directory.GetCurrentDirectory();
            System.Diagnostics.Process.Start(dir + "\\Tutorials\\CustomerMaintenance.html");
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btSearch_Click(object sender, EventArgs e)
        {

        }

        private void btNew_Click(object sender, EventArgs e)
        {
            try
            {
                Globals.FM_NEW_CUSTOMER = new fmNewCustomer();
                Globals.FM_NEW_CUSTOMER.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btSearch_Click_1(object sender, EventArgs e)
        {
            Globals.FM_CUST_LOOKUP = new fmCustLookup("CustMain");
            Globals.FM_CUST_LOOKUP.ShowDialog();
            Globals.FM_CUST_LOOKUP.BringToFront();
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            Globals.FM_CUST_LOOKUP = new fmCustLookup("CustMain");
            Globals.FM_CUST_LOOKUP.ShowDialog();
            Globals.FM_CUST_LOOKUP.BringToFront();
        }

        private void pbNew_Click(object sender, EventArgs e)
        {
            try
            {
                Globals.FM_NEW_CUSTOMER = new fmNewCustomer();
                Globals.FM_NEW_CUSTOMER.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btEmail_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        private void pbSend_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveCustomer();
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            SaveCustomer();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {

            (sender as Button).FlatAppearance.BorderSize = 2;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {

            (sender as Button).FlatAppearance.BorderSize = 1;
        }

        private void pbSave_MouseHover(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 2;
        }

        private void pbSave_MouseLeave(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 1;
        }

        private void pbSend_MouseHover(object sender, EventArgs e)
        {
            btSend.FlatAppearance.BorderSize = 2;
        }

        private void pbSend_MouseLeave(object sender, EventArgs e)
        {
            btSend.FlatAppearance.BorderSize = 1;
        }

        private void pbSearch_MouseHover(object sender, EventArgs e)
        {
            btSearch.FlatAppearance.BorderSize = 2;
        }

        private void pbSearch_MouseLeave(object sender, EventArgs e)
        {
            btSearch.FlatAppearance.BorderSize = 1;
        }

        private void pbNew_MouseHover(object sender, EventArgs e)
        {
            btNew.FlatAppearance.BorderSize = 2;
        }

        private void pbNew_MouseLeave(object sender, EventArgs e)
        {
            btNew.FlatAppearance.BorderSize = 1;
        }
    }
}
