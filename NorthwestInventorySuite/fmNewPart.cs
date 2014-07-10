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
    public partial class fmNewPart : Form
    {
        bool copy = false;

        public fmNewPart()
        {
            InitializeComponent();
        }

        public fmNewPart(bool copyPart)
        {
            InitializeComponent();
            copy = copyPart;
        }

        private void fmNewPart_Load(object sender, EventArgs e)
        {

        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            string desc = tbCustName.Text;
            string id = tbCustID.Text;
            bool duplicate = false;


            try
            {
                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;

                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open(); //open the connection

                string cmdText = "INSERT INTO part (id, description, code)" +
                "VALUES(@id, @desc, @code)";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.Parameters.AddWithValue("@code", 'p');
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Product Name Already In Use");
                duplicate = true;
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
            if (!duplicate)
            {
                Globals.LoadParts();
                if (copy)
                    Globals.FM_PART_MAINTENANCE.CopyPart(tbCustID.Text, tbCustName.Text);
                else
                {
                    Globals.part = id;
                    Globals.FM_PART_MAINTENANCE.LoadParts();
                    Globals.FM_PART_MAINTENANCE.ChangeIndex(id);
                }
                Close();
            }
        }
    }
}
