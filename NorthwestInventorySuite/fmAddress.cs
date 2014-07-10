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
    public partial class fmAddress : Form
    {
        string addId;
        string ownId;
        string aType;
        string formID;

        public fmAddress(string id, string cId, string type, string fId)
        {
            InitializeComponent();
            formID = fId;
            lbOwner.Text = "Owner ID: " + cId;
            cbAddressId.Text = id;
            addId = id;
            ownId = cId;
            aType = type;
        }

        public fmAddress()
        {
            InitializeComponent();
            addId = "";
            ownId = "";
            aType = "";
        }


        public void UpdateAddress()
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
                cmd.CommandText = "UPDATE address SET  address = '" + tbAddress.Text + "', city = '" + tbCity.Text + "', province = '" + tbProvince.Text +
                    "', country = '" + tbCountry.Text + "', postal_code = '" + tbPCode.Text + "', contact = '" + tbContact.Text +
                    "' WHERE address_id = '" + addId +  "' AND user_id = '" + ownId + "';";
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

        public void SaveNewAddress()
        {
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            string aType = "customer";
            string aUser = ownId;
            string address = tbAddress.Text;
            string city = tbCity.Text;
            string province = tbProvince.Text;
            string country = tbCountry.Text;
            string pCode = tbPCode.Text;
            string contact = tbContact.Text;
            string addid = cbAddressId.Text;

            try
            {
                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;

                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open(); //open the connection
                String cmdText = "INSERT INTO address (address_type, user_id, address_id, address, city, province, country, postal_code, contact)" +
                "VALUES(@address_type,@user_id, @addid, @address, @city, @province, @country, @postal_code, @contact)";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@address_type", aType);
                cmd.Parameters.AddWithValue("@user_id", aUser);
                cmd.Parameters.AddWithValue("@addid", addid);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@province", province);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@postal_code", pCode);
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

        public void ChangeIndex()
        {
            try
            {
                MySqlDataReader rdr = null;
                
                rdr = MysqlInterface.DoQuery("SELECT address, city, province, country, postal_code, contact FROM address where address_id = '" + cbAddressId.Text.ToString() +"';");

                string address = "";
                string city = "";
                string province = "";
                string country = "";
                string postal_code = "";
                string contact = "";
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) address = rdr.GetString(0);
                    if (!rdr.IsDBNull(1)) city = rdr.GetString(1);
                    if (!rdr.IsDBNull(2)) province = rdr.GetString(2);
                    if (!rdr.IsDBNull(3)) country = rdr.GetString(3);
                    if (!rdr.IsDBNull(4)) postal_code = rdr.GetString(4);
                    if (!rdr.IsDBNull(5)) contact = rdr.GetString(5);
                }

                tbAddress.Text = address;
                tbCity.Text = city;
                tbProvince.Text = province;
                tbCountry.Text = country;
                tbPCode.Text = postal_code;
                tbContact.Text = contact;



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

        private void btSave_Click(object sender, EventArgs e)
        {
            String cName;

            cName = cbAddressId.Text;

            try
            {
                MySqlDataReader rdr = null;
                int count = 0;
                string user = cbAddressId.Text;

                rdr = MysqlInterface.DoQuery("SELECT count(user_id) FROM address where user_id = '" + ownId 
                    + "' and address_id =  '" + user + "' and address_type = 'customer';");

                while (rdr.Read())
                {
                    count = rdr.GetInt32(0);
                    if (count > 0)
                        UpdateAddress();
                    else
                    {
                        SaveNewAddress();
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
            if(formID == "CUSTMAIN")
                Globals.FM_CUSTOMER_MAINTENANCE.UpdateAddress(cbAddressId.Text);
            else if(formID == "ORDERENTRY")
                Globals.FM_ORDER.UpdateOrderForm(cbAddressId.Text);
            Close();
           
        }

        private void cbAddressId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeIndex();
        }

        private void ClearForm()
        {
            tbAddress.Text = "";
            tbCity.Text = "";
            tbContact.Text = "";
            tbCountry.Text = "";
            tbPCode.Text = "";
            tbProvince.Text = "";
            cbAddressId.Items.Clear();
            cbAddressId.Text = addId;
        }

        private void fmAddress_Load(object sender, EventArgs e)
        {
            ClearForm();
            try
            {

                MySqlDataReader rdr = null;
                rdr = MysqlInterface.DoQuery("SELECT address_id FROM address WHERE user_id = '" + ownId + "';");
                string cID = "";
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) cID = rdr.GetString(0);
                    cbAddressId.Text = addId;
                    cbAddressId.Items.Add(cID);
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
            ChangeIndex();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}
