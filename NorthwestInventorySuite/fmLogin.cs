using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace NorthwestInventoryManager
{
    public partial class fmLogin : Form
    {
        public fmLogin()
        {
            InitializeComponent();
        }

        public fmLogin(string server, string dbase, string user)
        {
            InitializeComponent();
            cbDatabase.Text = dbase;
            tbServer.Text = server;
            tbUser.Text = user;
            
        }

        private void fmLogin_Load(object sender, EventArgs e)
        {

        }


        private void LoadCarriers()
        {
            MySqlDataReader rdr = null;
            string id = "";
            int count = 0;
            rdr = MysqlInterface.DoQuery("SELECT count(id) FROM carrier");

            while (rdr.Read())
            {
                count = rdr.GetInt32(0);
            }

            Globals.CARRIER_ARRAY = new string[count];

            rdr = MysqlInterface.DoQuery("SELECT id FROM carrier");
            int i = 0;
            while (rdr.Read())
            {
                id = rdr.GetString(0);
                Globals.CARRIER_ARRAY[i] = id;
                i++;
            }
        }

        private void Login()
        {
            string host = tbServer.Text;
            string user = tbUser.Text;
            string password = tbPassword.Text;
            string dbase = cbDatabase.Text;
            int count = 0;


            string name = "";
            MysqlInterface.SetConnectionInformation(host, user, password, dbase);

            /*if (cbDatabase.Text == "Pinnacle Test Database")
            {


            }*/


            string qry = "SELECT count(id), name FROM users where id = '" +
                tbUser.Text + "' and password = '" + tbPassword.Text + "';";
            MySqlDataReader rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                count = rdr.GetInt32(0);
                if (count == 0)
                    name = "";
                else
                    name = rdr.GetString(1);

                Globals.USER = tbUser.Text;
                Globals.USER_NAME = name;
            }

            //Globals.FM_PART_BUILDER = new fmPartBuilder();
            //Globals.FM_PART_BUILDER.Show();

            if (count == 0)
                MessageBox.Show("Incorrect User Name or Password");
            else
            {
                Hide();
                Globals.FM_SPLASH = new fmSplash();
                Globals.FM_SPLASH.Show();
                Globals.FM_SPLASH.Refresh();

                Globals.LoadCustomers();
                Globals.FM_SPLASH.ChangeText("Loading: Parts . . . ");
                Globals.LoadParts();
                Globals.FM_SPLASH.ChangeText("Loading: Carriers . . . ");
                LoadCarriers();
                Globals.FM_SPLASH.ChangeText("Loading: Vendors . . . ");
                Globals.LoadVendors();

                Globals.FM_SPLASH.Hide();
                Globals.FM_MAIN = new fmMain();
                Globals.FM_MAIN.Show();
            }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            Login();
        
        }

        private void tbUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                Login();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                Login();
        }

    }
}
