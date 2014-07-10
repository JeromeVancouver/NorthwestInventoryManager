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
    public partial class fmVendorMaintenance : Form
    {
        public fmVendorMaintenance()
        {
            InitializeComponent();
        }


        private void btCarrier_Click(object sender, EventArgs e)
        {
            Globals.FM_CARRIER = new fmCarrier();
            Globals.FM_CARRIER.Show();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearForm()
        {
            tbBillCity.Text = "";
            tbBillCountry.Text = "";
            tbBillName.Text = "";
            tbBillPCode.Text = "";
            tbBillProvince.Text = "";
            tbBillStreet.Text = "";
            tbContact.Text = "";
            tbDiscount.Text = "";
            tbEmail.Text = "";
            tbFax.Text = "";
            tbPhone.Text = "";
            tbPSTNumber.Text = "";
            tbSoldCity.Text = "";
            tbSoldCountry.Text = "";
            tbSoldName.Text = "";
            tbSoldPCode.Text = "";
            tbSoldProvince.Text = "";
            tbSoldStreet.Text = "";
            tbTaxCode.Text = "";

            cbBillTo.Text = "";
            cbCarrier.Text = "";
            cbShipTo.Text = "";
            cbSoldTo.Text = "";

        }

        private void LoadVendorAddressBook(string cId)
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
        }

        private void LoadVendorDetails(string cId)
        {
            MySqlDataReader rdr = null;

            string name = "";
            string address = "";
            string bill_name = "";
            string bill_address = "";
            string discount = "";
            string contact = "";
            string phone = "";
            string fax = "";
            string email = "";
            string carrier_id = "";
            string shipto_id = "";
            string tax_code = "";
            string pst_num = "";

            string qry = "SELECT NAME, ADDRESS, BILL_NAME, BILL_ADDRESS, DISCOUNT, CONTACT, PHONE, FAX, EMAIL, CARRIER_ID, SHIPTO_ID, STATE, PST_NUM FROM vendor WHERE ID = '" + cId + "';";

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
                    tbContact.Text = contact = rdr.GetString(5);
                if (!rdr.IsDBNull(6))
                    tbPhone.Text = phone = rdr.GetString(6);
                if (!rdr.IsDBNull(7))
                    tbFax.Text = fax = rdr.GetString(7);
                if (!rdr.IsDBNull(8))
                    tbEmail.Text = email = rdr.GetString(8);
                if (!rdr.IsDBNull(9))
                    cbCarrier.Text = carrier_id = rdr.GetString(9);
                if (!rdr.IsDBNull(10))
                    cbShipTo.Text = shipto_id = rdr.GetString(10);
                if (!rdr.IsDBNull(11))
                    tbTaxCode.Text = tax_code = rdr.GetString(11);
                if (!rdr.IsDBNull(12))
                    tbPSTNumber.Text = pst_num = rdr.GetString(12);
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

        private string GetCurrentVendID()
        {
            string id = cbVendID.Text;
            if (id.Length < 7)
                return "";
            id = cbVendID.Text.Substring(0, 6);
            return id;
        }

        public void LoadVendor(string v)
        {
            cbVendID.Text = v;
            LoadVendorAddressBook(v);
            LoadVendorDetails(v);
            LoadShippingBilling(v);
        }

        private void cbVendID_Leave(object sender, EventArgs e)
        {
            ClearForm();
            LoadVendor(GetCurrentVendID());
        }

        private void fmVendorMaintenance_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadVendorList();
        }

        private void SaveVendor()
        {
            string name = tbSoldName.Text;
            string address = cbSoldTo.Text;
            string bill_name = tbBillName.Text;
            string bill_address = cbBillTo.Text;
            string discount = tbDiscount.Text;
            string contact = tbContact.Text;
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
                cmd.CommandText = "UPDATE vendor SET name = '" + name + "', address = '" + address + "', bill_name = '" + bill_name + "', bill_address = '" + bill_address +
                    "', discount = '" + discount + "', contact = '" + contact + "', phone = '" + phone + "', fax = '" + fax +
                    "', email = '" + email + "', carrier_id = '" + carrier_id + "', shipto_id = '" + shipto_id + "', tax_code = '" + tax_code +
                    "', pst_num = '" + pst_num +
                    "' WHERE id = '" + cbVendID.Text + "';";
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

        private void btSave_Click(object sender, EventArgs e)
        {
            SaveVendor();
        }

        private void btSoldTo_Click(object sender, EventArgs e)
        {
            string id = cbSoldTo.Text;
            string cId = cbVendID.Text;
            Globals.FM_ADDRESS = new fmAddress(id, cId, "vendor", "VENDMAIN");
            Globals.FM_ADDRESS.Show();
        }

        private void btBillTo_Click(object sender, EventArgs e)
        {
            string id = cbShipTo.Text;
            string cId = cbVendID.Text;
            Globals.FM_ADDRESS = new fmAddress(id, cId, "vendor", "VENDMAIN");
            Globals.FM_ADDRESS.Show();
        }

        private void btShipTo_Click(object sender, EventArgs e)
        {
            string id = cbShipTo.Text;
            string cId = "PINGLA";
            Globals.FM_ADDRESS = new fmAddress(id, cId, "own", "VENDMAIN");
            Globals.FM_ADDRESS.Show();
        }

        private void SendEmail()
        {
            try
            {
                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.Subject = "Pinnacle Glass Doors";
                mailItem.To = tbEmail.Text;
                string name = tbContact.Text;
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

        private void btNew_Click(object sender, EventArgs e)
        {
            try
            {
                Globals.FM_NEW_VENDOR = new fmNewVendor();
                Globals.FM_NEW_VENDOR.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        public void LoadVendorList()
        {
            try
            {
                int count = 0;
                string custName;
                cbVendID.Text = "";
                cbVendID.Items.Clear();
                count = Globals.VENDOR_ARRAY.GetLength(0);
                for (int i = 0; i < count; i++)
                {
                    custName = Globals.VENDOR_ARRAY[i, 0] + " - " + Globals.VENDOR_ARRAY[i, 1];
                    cbVendID.Items.Add(custName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data.ToString());
            }

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            Globals.FM_VENDOR_LOOKUP = new fmVendLookup("VendMain");
            Globals.FM_VENDOR_LOOKUP.ShowDialog();
            Globals.FM_VENDOR_LOOKUP.BringToFront();
        }

        private void pbNew_Click(object sender, EventArgs e)
        {
            try
            {
                Globals.FM_NEW_VENDOR = new fmNewVendor();
                Globals.FM_NEW_VENDOR.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btSave_Click_1(object sender, EventArgs e)
        {
            SaveVendor();
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            SaveVendor();
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            Globals.FM_VENDOR_LOOKUP = new fmVendLookup("VendMain");
            Globals.FM_VENDOR_LOOKUP.ShowDialog();
            Globals.FM_VENDOR_LOOKUP.BringToFront();
        }

        private void btEmail_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        private void pbSend_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        private void btNew_MouseHover(object sender, EventArgs e)
        {

            (sender as Button).FlatAppearance.BorderSize = 2;
        }

        private void btNew_MouseLeave(object sender, EventArgs e)
        {

            (sender as Button).FlatAppearance.BorderSize = 1;
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

        private void pbSend_MouseHover(object sender, EventArgs e)
        {
            btSend.FlatAppearance.BorderSize = 2;
        }

        private void pbSend_MouseLeave(object sender, EventArgs e)
        {
            btSend.FlatAppearance.BorderSize = 1;
        }

        private void pbSave_MouseHover(object sender, EventArgs e)
        {
            btSave.FlatAppearance.BorderSize = 2;
        }

        private void pbSave_MouseLeave(object sender, EventArgs e)
        {
            btSave.FlatAppearance.BorderSize = 1;
        }


    }
}
