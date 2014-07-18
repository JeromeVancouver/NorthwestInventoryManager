using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace NorthwestInventoryManager
{
    public partial class fmCompanyCreation : Form
    {
        public fmCompanyCreation()
        {
            InitializeComponent();
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            string host = tbServer.Text;
            string user = tbUser.Text;
            string password = tbPassword.Text;
            string dbase = tbDatabase.Text;

            MysqlInterface.SetConnectionInformation(host, user, password, dbase);
            if (MysqlInterface.init())
                MessageBox.Show("Connection Successful");
            else
                MessageBox.Show("Connection Failed");
                
        }

        private void tbSetup_Click(object sender, EventArgs e)
        {

            string host = tbServer.Text;
            string user = tbUser.Text;
            string password = tbPassword.Text;
            string dbase = tbDatabase.Text;

            MysqlInterface.SetConnectionInformation(host, user, password, dbase);

            MysqlInterface.close();
            MysqlInterface.init();

            string str = "USE `" + tbDatabase.Text + "`;";

            MysqlInterface.ExecuteQuery(str);

            string text = File.ReadAllText("Clear Data.sql");

            MysqlInterface.ExecuteQuery(text);


            MySqlConnection con = null;
            MySqlCommand cmd = null;
            try
            {

                str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open(); //open the connection
                String cmdText = "INSERT INTO comp_info (name, address, city, province, country, postal_code) " +
                "VALUES(@name, @address, @city, @province, @country, @postal_code)";

                cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@name", tbCompany.Text);
                cmd.Parameters.AddWithValue("@address", tbAddress.Text);
                cmd.Parameters.AddWithValue("@city", tbCompany.Text);
                cmd.Parameters.AddWithValue("@province", tbProv.Text);
                cmd.Parameters.AddWithValue("@country", tbCountry.Text);
                cmd.Parameters.AddWithValue("@postal_code", tbPCode.Text);

                cmd.ExecuteNonQuery();

                cmdText = "INSERT INTO users (id, name, password) " +
                "VALUES(@id, @uname, @pass)";

                cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", tbUser.Text);
                cmd.Parameters.AddWithValue("@uname", tbUser.Text);
                cmd.Parameters.AddWithValue("@pass", tbPassword.Text);

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



            string lines = tbServer.Text + "\r\n" + tbDatabase.Text + "\r\n" + tbUser.Text;

            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter("config.ini");
            file.WriteLine(lines);

            file.Close();


            Hide();
            Globals.FM_LOGIN = new fmLogin(host, dbase, user);
            Globals.FM_LOGIN.Show();

        }

        private void fmCompanyCreation_Load(object sender, EventArgs e)
        {

        }

    }
}
