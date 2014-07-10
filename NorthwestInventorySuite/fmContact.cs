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
    public partial class fmContact : Form
    {
        string cId;

        public fmContact()
        {
            InitializeComponent();
        }

        public fmContact(string id)
        {
            InitializeComponent();
            cId = id;
            lbOwner.Text = "Owner Id: " + cId;
        }

        private void ClearForm()
        {
            cbName.Text = "";
            cbName.Items.Clear();
            tbEmail.Text = "";
            tbPhone.Text = "";
            tbTitle.Text = "";
        }

        private void fmContact_Load(object sender, EventArgs e)
        {
            ClearForm();
            string qry = "SELECT CONTACT_NAME, CONTACT_TITLE, CONTACT_EMAIL, CONTACT_PHONE FROM contact WHERE OWNER_ID = '" + cId + "';";

            MySqlDataReader rdr = MysqlInterface.DoQuery(qry);
            bool firstRead = true;
            string cName = "";
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0))
                {
                    cName = rdr.GetString(0);
                    cbName.Items.Add(cName);
                }
                if (firstRead)
                {
                    cbName.Text = cName;
                    if (!rdr.IsDBNull(1))
                        tbTitle.Text = rdr.GetString(1);
                    if (!rdr.IsDBNull(2))
                        tbEmail.Text = rdr.GetString(2);
                    if (!rdr.IsDBNull(3))
                        tbPhone.Text = rdr.GetString(3);
                    firstRead = false;
                }
            }

            MysqlInterface.close();
        }

        private void cbName_Leave(object sender, EventArgs e)
        {
            string contactId = cbName.Text;
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

        public void UpdateContact()
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
                cmd.CommandText = "UPDATE contact SET  contact_title = '" + tbTitle.Text + "', contact_email = '" + tbEmail.Text + "', contact_phone = '" + tbPhone.Text +
                    "' WHERE owner_id = '" + cId + "' AND contact_name = '" + cbName.Text + "';";
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

        public void SaveNewContact()
        {
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            string owner = cId;
            string cName = cbName.Text;
            string title = tbTitle.Text;
            string email = tbEmail.Text;
            string phone = tbPhone.Text;

            try
            {
                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;

                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open(); //open the connection
                String cmdText = "INSERT INTO contact (owner_id, contact_name, contact_title, contact_email, contact_phone)" +
                "VALUES(@owner,@name, @title, @email, @phone)";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@owner", owner);
                cmd.Parameters.AddWithValue("@name", cName);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phone);
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

            cName = cbName.Text;

            try
            {
                MySqlDataReader rdr = null;
                int count = 0;

                rdr = MysqlInterface.DoQuery("SELECT count(contact_name) FROM contact where owner_id = '" + cId
                    + "' and contact_name =  '" + cName + "';");

                while (rdr.Read())
                {
                    count = rdr.GetInt32(0);
                    if (count > 0)
                        UpdateContact();
                    else
                    {
                        SaveNewContact();
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
                "' WHERE id = '" + cId + "';";
            int numRowsUpdated = cmd.ExecuteNonQuery();



            Globals.FM_CUSTOMER_MAINTENANCE.UpdateContact(cbName.Text);
            Close();
        }
    }
}
