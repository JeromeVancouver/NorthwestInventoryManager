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
    public partial class fmCarrier : Form
    {

        string defaultId;
        string currentAddress;


        public fmCarrier()
        {
            InitializeComponent();
        }

        public fmCarrier(string id)
        {
            defaultId = id;
            InitializeComponent();

        }


        public void UpdateCarrier()
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
                cmd.CommandText = "UPDATE carrier SET id = '" + cbCarrier.Text + "', name = '" + tbCName.Text + "', address = '" + currentAddress.ToString() + 
                    "' WHERE id = '" + cbCarrier.Text + "';";
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
                cmd.CommandText = "UPDATE address SET user_id = '" + cbCarrier.Text + "', address_id = '" + cbCarrier.Text + "', address = '" + tbAddress.Text + "', city = '" + tbCity.Text + "', province = '" + tbProvince.Text + 
                    "', country = '" + tbCountry.Text +"', postal_code = '" +  tbPostalCode.Text +"', contact = '" + tbContact.Text + 
                    "' WHERE address_id = '" + currentAddress.ToString() + "' and address_type = 'carrier';";
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
            string aType = "carrier";
            string address_id = cbCarrier.Text;
            string aUser = cbCarrier.Text;
            string address = tbAddress.Text;
            string city = tbCity.Text;
            string province = tbProvince.Text;
            string country = tbCountry.Text;
            string pCode = tbPostalCode.Text;
            string contact = tbContact.Text;

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
                "VALUES(@address_type,@user_id, @address_id, @address, @city, @province, @country, @postal_code, @contact)";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@address_type", aType);
                cmd.Parameters.AddWithValue("@user_id", aUser);
                cmd.Parameters.AddWithValue("@address_id", address_id);
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

        public void SaveNewCarrier(MySqlDataReader rdr)
        {
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            string id = cbCarrier.Text;
            string name = tbCName.Text;
            try
            {
                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;

                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open(); //open the connection


                rdr.Close();
                /*rdr = MysqlInterface.DoQuery("SELECT id FROM address where user_id = '" + id + "' and address_type = 'carrier';");
                while (rdr.Read())
                {
                    aId = rdr.GetInt32(0);
                }*/

                String cmdText = "INSERT INTO carrier (id, name, address) VALUES(@id,@name, @address)";
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", id);
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

        private void btSave_Click(object sender, EventArgs e)
        {
            String cName;

            cName = cbCarrier.Text;

            try
            {
                MySqlDataReader rdr = null;
                int count = 0;
                string user = cbCarrier.Text;

                rdr = MysqlInterface.DoQuery("SELECT count(user_id) FROM address where user_id = '" + user + "' and address_type = 'carrier';");

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
            try
            {

                MySqlDataReader rdr = null;
                rdr = MysqlInterface.DoQuery("SELECT count(id) FROM carrier where id = '" + cName + "';");

                while (rdr.Read())
                {
                    int count = rdr.GetInt32(0);
                    if (count > 0)
                        UpdateCarrier();
                    else
                    {
                        SaveNewCarrier(rdr);
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

        private void fmCarrier_Load(object sender, EventArgs e)
        {
            cbCarrier.Items.Clear();
            cbCarrier.Text = defaultId;
            try
            {
                MySqlDataReader rdr = null;
                rdr = MysqlInterface.DoQuery("SELECT id FROM carrier;");
                string cID;
                while (rdr.Read())
                {
                    cID = rdr.GetString(0);
                    cbCarrier.Items.Add(cID);
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

        public void ChangeIndex()
        {
            try
            {
                MySqlDataReader rdr = null;
                rdr = MysqlInterface.DoQuery("SELECT id, name, address FROM carrier where id = '" + cbCarrier.Text + "';");
                string cID;
                string cName = "";
                string cAddress = "";
                while (rdr.Read())
                {
                    cID = rdr.GetString(0);
                    cName = rdr.GetString(1);
                    cAddress = rdr.GetString(2);
                    currentAddress = cAddress;
                }

                tbCName.Text = cName;
                rdr.Close();
                rdr = MysqlInterface.DoQuery("SELECT address, city, province, country, postal_code, contact FROM address where user_id = '" + cAddress + "';");

                string address = "";
                string city = "";
                string province = "";
                string country = "";
                string postal_code = "";
                string contact = "";
                while (rdr.Read())
                {
                    address = rdr.GetString(0);
                    city = rdr.GetString(1);
                    province = rdr.GetString(2);
                    country = rdr.GetString(3);
                    postal_code = rdr.GetString(4);
                    contact = rdr.GetString(5);
                }

                tbAddress.Text = address;
                tbCity.Text = city;
                tbProvince.Text = province;
                tbCountry.Text = country;
                tbPostalCode.Text = postal_code;
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


        private void cbCarrier_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeIndex();

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
