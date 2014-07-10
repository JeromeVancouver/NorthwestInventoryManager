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
    public partial class fmNewTruck : Form
    {
        public fmNewTruck()
        {
            InitializeComponent();
        }

        private void fmNewTruck_Load(object sender, EventArgs e)
        {
            string id = "";
            string qry = "SELECT ID FROM carrier;";
            MySqlDataReader rdr = MysqlInterface.DoQuery(qry);
            cbCarrier.Items.Clear();
            while (rdr.Read())
            {
                id = rdr.GetString(0);
                cbCarrier.Items.Add(id);
            }
        }

        private void btCreate_Click(object sender, EventArgs e)
        {

            string desc = tbDesc.Text;
            string carrier = cbCarrier.Text;
            string tId = Globals.CreateNewTruck(desc, carrier);
           

            Globals.FM_TRUCK_SCHEDULER.LoadTruck(tId, "0");
            Close();
        }
    }
}
