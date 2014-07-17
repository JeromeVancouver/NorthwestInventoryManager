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
    public partial class fmNewCustomer : Form
    {
        public fmNewCustomer()
        {
            InitializeComponent();
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            string aType = "customer";
            string addName = tbCustName.Text;
            string custId = tbCustID.Text;

            try
            {
                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;

                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open(); //open the connection

                string cmdText = "INSERT INTO customer (id, name, address, bill_name, bill_address, discount, contact, phone, fax, email, carrier_id, shipto_id, state, pst_num, notes)" +
                "VALUES(@id, @name, @address, @bill_name, @bill_address, 1.0, '', '', '', '', '', '', '', '', '')";
        
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", custId);
                cmd.Parameters.AddWithValue("@name", addName);
                cmd.Parameters.AddWithValue("@address", custId);
                cmd.Parameters.AddWithValue("@bill_name", addName);
                cmd.Parameters.AddWithValue("@bill_address", custId);

                cmd.ExecuteNonQuery();

                cmdText = "INSERT INTO address (address_type, user_id, address_id, address, city, province, country, postal_code, contact)" +
                "VALUES(@address_type, @user_id, @address_id, '', '', '', '', '', '')";

                cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@address_type", aType);
                cmd.Parameters.AddWithValue("@user_id", custId);
                cmd.Parameters.AddWithValue("@address_id", custId);
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
            Globals.LoadCustomers();
            Globals.FM_CUSTOMER_MAINTENANCE.LoadCustomers();
            Globals.FM_CUSTOMER_MAINTENANCE.LoadCustomer(custId);
            Close();
        }

    }
}
