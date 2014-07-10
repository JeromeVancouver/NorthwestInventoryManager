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
    public partial class fmPartHistory : Form
    {
        public fmPartHistory()
        {
            InitializeComponent();
        }

        private void cbPart_Leave(object sender, EventArgs e)
        {
            dgHistory.Rows.Clear();
            string date = "";
            double qty = 0.0;
            string specs = "";
            string user_id = "";
            string qry = "SELECT date, qty, specs, user_id FROM inventory_trans WHERE part_id = '" + cbPart.Text + "' order by date;";
            MySqlDataReader rdr;

            rdr = MysqlInterface.DoQuery(qry);
            int i = 0;
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0)) date = rdr.GetString(0);
                if (!rdr.IsDBNull(0)) qty = rdr.GetDouble(1);
                if (!rdr.IsDBNull(0)) specs = rdr.GetString(2);
                if (!rdr.IsDBNull(0)) user_id = rdr.GetString(3);

                dgHistory.Rows.Add();

                dgHistory.Rows[i].Cells[0].Value = date;

                dgHistory.Rows[i].Cells[1].Value = qty.ToString();
                dgHistory.Rows[i].Cells[2].Value = specs;
                dgHistory.Rows[i].Cells[3].Value = user_id;

                i++;
            }
        }

        private void fmPartHistory_Load(object sender, EventArgs e)
        {
            int count = 0;
            int i = 0;
            try
            {
                count = Globals.PART_ARRAY.GetLength(0);
                for (i = 0; i < count; i++)
                    cbPart.Items.Add(Globals.PART_ARRAY[i, 0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cbPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgHistory.Rows.Clear();
            DateTime date = DateTime.Today;
            double qty = 0.0;
            string specs = "";
            string user_id = "";
            string qry = "SELECT date, qty, specs, user_id FROM inventory_trans WHERE part_id = '" + cbPart.Text + "' order by date;";
            MySqlDataReader rdr;

            rdr = MysqlInterface.DoQuery(qry);
            int i = 0;
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0)) date = rdr.GetDateTime(0);
                if (!rdr.IsDBNull(0)) qty = rdr.GetDouble(1);
                if (!rdr.IsDBNull(0)) specs = rdr.GetString(2);
                if (!rdr.IsDBNull(0)) user_id = rdr.GetString(3);

                dgHistory.Rows.Add();
                dgHistory.Rows[i].Cells[0].Value = date.ToShortDateString();

                dgHistory.Rows[i].Cells[1].Value = qty.ToString();
                dgHistory.Rows[i].Cells[2].Value = specs;
                dgHistory.Rows[i].Cells[3].Value = user_id;

                i++;
            }
        }
    }
}
