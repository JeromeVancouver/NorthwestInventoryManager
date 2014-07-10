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
    public partial class fmPartBuilder : Form
    {

        string code;
        string type;
        string style;


        public fmPartBuilder()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
        }

        private void fmPartBuilder_Load(object sender, EventArgs e)
        {
            ClearForm();
            try
            {

                MySqlDataReader rdr = null;
                rdr = MysqlInterface.DoQuery("select distinct type from door_style;");
                string type = "";
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) type = rdr.GetString(0);
                    cbType.Items.Add(type);
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

        private void cbType_Leave(object sender, EventArgs e)
        {
            if (type == cbType.Text)
                return;
            cbStyle.Text = "";
            cbStyle.Items.Clear();
            try
            {

                MySqlDataReader rdr = null;
                rdr = MysqlInterface.DoQuery("select style from door_style where type = '" + cbType.Text + "';");
                string style = "";
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) style = rdr.GetString(0);
                    cbStyle.Items.Add(style);
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


        private void UpdatePart()
        {
            string size;
            size = tbWidth.Text + tbWidth16.Text + "x" + tbHeight.Text + tbHeight16.Text + "x" + tbThick.Text + tbThick16.Text;
            lbPart.Text = code + "-" + size;
        }

        private void cbStyle_Leave(object sender, EventArgs e)
        {
            if (style == cbStyle.Text)
                return;

            try
            {

                MySqlDataReader rdr = null;
                rdr = MysqlInterface.DoQuery("select code from door_style where type = '" + cbType.Text + "' AND style = '" + cbStyle.Text + "';");
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) code = rdr.GetString(0);
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
            UpdatePart();
        }

        private void cbType_Enter(object sender, EventArgs e)
        {
            type = cbType.Text;
        }

        private void cbStyle_Enter(object sender, EventArgs e)
        {
            style = cbStyle.Text;
        }

        private void tbWidth_TextChanged(object sender, EventArgs e)
        {
            UpdatePart();
        }

        private void tbWidth16_TextChanged(object sender, EventArgs e)
        {
            UpdatePart();
        }

        private void tbHeight_TextChanged(object sender, EventArgs e)
        {
            UpdatePart();
        }

        private void tbHeight16_TextChanged(object sender, EventArgs e)
        {
            UpdatePart();
        }

        private void tbThick_TextChanged(object sender, EventArgs e)
        {
            UpdatePart();
        }

        private void tbThick16_TextChanged(object sender, EventArgs e)
        {
            UpdatePart();
        }

    }
}
