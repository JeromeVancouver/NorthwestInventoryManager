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
    public partial class fmOptions : Form
    {
        public fmOptions()
        {
            InitializeComponent();
        }

        private void fmOptions_Load(object sender, EventArgs e)
        {
            string id = lbUserId.Text = Globals.USER;
            string name = "";
            string password = "";

            string qry = "SELECT name, password FROM users WHERE id = '" + id + "';";
            MySqlDataReader rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                tbName.Text = name = rdr.GetString(0);
                tbPassword.Text = password = rdr.GetString(1);

            }
            
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            
            string query = "UPDATE users SET name = '" + tbName.Text + "', password = '" + tbPassword.Text +
            "' WHERE id = '" + lbUserId.Text + "';";
            MysqlInterface.ExecuteQuery(query);
            MessageBox.Show("Updated");
        }
    }
}
