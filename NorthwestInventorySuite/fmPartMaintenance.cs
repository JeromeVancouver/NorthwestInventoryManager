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
    public partial class fmPartMaintenance : Form
    {
        public int LINE;
        private int curLine;

        public fmPartMaintenance()
        {
            InitializeComponent();
            LINE = 0;
            curLine = 0;
        }

        private void ClearForm()
        {
            tbCaseQty.Text = "";
            tbCode.Text = "";
            tbDescription.Text = "";
            tbHeight.Text = "";
            tbHTSCode.Text = "";
            tbLength.Text = "";
            tbPalletQty.Text = "";
            tbPurchasePrice.Text = "";
            tbQtyonHand.Text = "";
            tbSellingPrice.Text = "";
            tbWeight.Text = "";
            tbWidth.Text = "";
            tbRack.Text = "";
            tbNotes.Text = "";
            ClearBomGrid();
        }

        public void LoadParts()
        {
            int count = 0;
            cbPartID.Items.Clear();
            count = Globals.PART_ARRAY.GetLength(0);
            for (int i = 0; i < count; i++)
                cbPartID.Items.Add(Globals.PART_ARRAY[i, 0]);
        }

        private void fmPartMaintenance_Load(object sender, EventArgs e)
        {
            LoadParts();
        }

        public void FillinBom()
        {
            LINE = 0;
            MySqlDataReader rdr = null;

            string part_id = "";
            string comp_id = "";
            double qty = 0.0;
            double pp;
            string desc = "";
            int lNo = 0;
            string qry = "SELECT b.LINE_NO, b.PART_ID, b.COMPONENT_ID, b.QTY, p.PURCHASE_PRICE, p.DESCRIPTION FROM bom b " + 
            "inner join part p on p.ID = b.COMPONENT_ID " + 
            "where PART_ID = '" + cbPartID.Text + "' ORDER BY b.LINE_NO;";
            LINE = 0;
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0)) lNo = rdr.GetInt32(0);
                if (!rdr.IsDBNull(1)) part_id = rdr.GetString(1);
                if (!rdr.IsDBNull(2)) comp_id = rdr.GetString(2);
                if (!rdr.IsDBNull(3)) qty = rdr.GetFloat(3);
                if (!rdr.IsDBNull(4)) pp = rdr.GetFloat(4); else pp = 0.0;
                if (!rdr.IsDBNull(5)) desc = rdr.GetString(5);
                pp = Math.Round(pp, 2);
                string[] row = { lNo.ToString(), comp_id, desc, qty.ToString(), pp.ToString() };
                dgBom.Rows.Add(row);
                LINE++;
            }
        }

        public void ClearBomGrid()
        {
            dgBom.Rows.Clear();
            dgBom.RowCount = 1;

        }

        public void ChangeIndex(string pId)
        {
            string id = pId;
            cbPartID.Text = id;
            string rack = "";
            string desc = "";
            double pp = 0.0;
            double qty = 0.0;
            char code = ' ';
            double sp = 0.0;
            double weight = 0.0;
            double length = 0.0;
            double width = 0.0;
            double height = 0.0;
            double case_qty = 0.0;
            double pal_qty = 0.0;
            string hts = "";

            try
            {

                MySqlDataReader rdr = null;


                string qry = "SELECT description, rack, weight, length, width, height, purchase_price, selling_price, case_qty, pallet_qty, hts_code, qty_on_hand, code, notes FROM part where id = '" + cbPartID.Text + "';";
                rdr = MysqlInterface.DoQuery(qry);

                ClearForm();

                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) tbDescription.Text = desc = rdr.GetString(0);
                    if (!rdr.IsDBNull(1)) tbRack.Text = rack = rdr.GetString(1);
                    if (!rdr.IsDBNull(2))
                    {
                        weight = Math.Round(rdr.GetFloat(2), 2);
                        tbWeight.Text = weight.ToString();
                    }
                    if (!rdr.IsDBNull(3))
                    {
                        length = Math.Round(rdr.GetFloat(3), 2);
                        tbLength.Text = length.ToString();
                    } 
                    if (!rdr.IsDBNull(4))
                    {
                        width = Math.Round(rdr.GetFloat(4), 2);
                        tbWidth.Text = width.ToString();
                    }
                    if (!rdr.IsDBNull(5))
                    {
                        height = Math.Round(rdr.GetFloat(5), 2);
                        tbHeight.Text = height.ToString();
                    }
                    if (!rdr.IsDBNull(6))
                    {
                        pp = Math.Round(rdr.GetFloat(6), 2);
                        tbPurchasePrice.Text = pp.ToString();
                    }
                    if (!rdr.IsDBNull(7))
                    {
                        sp = Math.Round(rdr.GetFloat(7), 2);
                        tbSellingPrice.Text = sp.ToString();
                    }
                    if (!rdr.IsDBNull(8))
                    {
                        case_qty = Math.Round(rdr.GetFloat(8), 2);
                        tbCaseQty.Text = case_qty.ToString();
                    }
                    if (!rdr.IsDBNull(9))
                    {
                        pal_qty = Math.Round(rdr.GetFloat(9), 2);
                        tbPalletQty.Text = pal_qty.ToString();
                    }
                    if (!rdr.IsDBNull(10)) tbHTSCode.Text = hts = rdr.GetString(10);
                    if (!rdr.IsDBNull(11))
                    {
                        qty = Math.Round(rdr.GetFloat(11), 2);
                        tbQtyonHand.Text = qty.ToString();
                    }
                    if (!rdr.IsDBNull(12))
                    {
                        code = rdr.GetChar(12);
                        tbCode.Text = code.ToString();
                    }
                    if(!rdr.IsDBNull(13)) tbNotes.Text = rdr.GetString(13);

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

            ClearBomGrid();
            FillinBom();
                
        }

        private void cbPartID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChangeIndex(cbPartID.Text);
        }

        private void cbPartID_Leave(object sender, EventArgs e)
        {
            /*try
            {
                string id = cbPartID.Text;
                ClearForm();
                ChangeIndex(id);

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                MysqlInterface.close();
            }*/
            string curPart = cbPartID.Text;
            Globals.FM_PART_LOOKUP = new fmPartLookup("PartMain", curPart);
            Globals.FM_PART_LOOKUP.ShowDialog();
            Globals.FM_PART_LOOKUP.BringToFront();

        }

        private void UpdatePart()
        {
            string csQty = tbCaseQty.Text;
            string code = tbCode.Text;
            string desc = tbDescription.Text;
            string height = tbHeight.Text;
            string hts = tbHTSCode.Text;
            string length = tbLength.Text;
            string plQty = tbPalletQty.Text;
            string pp = tbPurchasePrice.Text;
            string qtyHand = tbQtyonHand.Text;
            string sp = tbSellingPrice.Text;
            string weight = tbWeight.Text;
            string width = tbWidth.Text;
            string id = cbPartID.Text;
            string rack = tbRack.Text;
            string notes = tbNotes.Text;

            if (tbCaseQty.Text == "") csQty = "0.0" ;
            if (tbHeight.Text == "") height = "0.0" ;
            if (tbLength.Text == "") length = "0.0" ;
            if (tbPalletQty.Text == "") plQty = "0.0" ;
            if (tbPurchasePrice.Text == "") pp = "0.0" ;
            if (tbQtyonHand.Text == "") qtyHand = "0.0";
            if (tbSellingPrice.Text == "") sp = "0.0";
            if (tbWeight.Text == "") weight = "0.0";
            if (tbWidth.Text == "") width = "0.0";

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
                cmd.CommandText = "UPDATE part SET description = '" + desc + "', rack = '" + rack + "', weight = " + weight +
                    ", length = " + length + ", width = " + width + ", height = " + height + 
                    ", purchase_price = " + pp + ", selling_price = " + sp + ", case_qty = " + csQty +
                    ", pallet_qty = " + plQty + ", hts_code = '" + hts + "', qty_on_hand = " + qtyHand + ", code = '" + code + "', notes = '" + notes +
                    "' WHERE id = '" + id + "';";
                int numRowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
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

        private void UpdateLine(int index)
        {
            MySqlConnection con = null;
            MySqlCommand cmd = new MySqlCommand();
            
            string line_no = dgBom.Rows[index].Cells["fLine"].Value.ToString();
            string partid = cbPartID.Text;
            string qty = dgBom.Rows[index].Cells["fQty"].Value.ToString();
            string component = dgBom.Rows[index].Cells["fComponent"].Value.ToString();

            //MySqlDataReader rdr = null;



            //rdr = MysqlInterface.DoQuery("SELECT length, width, height FROM part where id = '" + partid + "';");

            try
            {


                cmd.Connection = con;
                string query = "UPDATE bom SET line_no = " + line_no + ", part_id = '" + partid +
                    "', component_id = '" + component + "', qty = " + qty +
                    " WHERE part_id = '" + cbPartID.Text + "' and line_no = " + line_no + ";";
                MysqlInterface.ExecuteQuery(query);
               // int numRowsUpdated = cmd.ExecuteNonQuery();
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

        private void AddLine(int index)
        {
            int line_no = 0;
            string part_id = cbPartID.Text;
            double qty = 0.0;
            string component_id = "";

            line_no = Convert.ToInt32(dgBom.Rows[index].Cells["fLine"].Value.ToString());
            component_id = dgBom.Rows[index].Cells["fComponent"].Value.ToString();
            qty = Convert.ToDouble(dgBom.Rows[index].Cells["fQty"].Value.ToString());

            MySqlCommand cmd = null;

            String cmdText = "INSERT INTO bom (line_no, part_id, component_id, qty)" +
            "VALUES(@line_no, @part_id, @component_id, @qty)";

            cmd = new MySqlCommand(cmdText, MysqlInterface.GetConnection());
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@line_no", line_no);
            cmd.Parameters.AddWithValue("@part_id", part_id);
            cmd.Parameters.AddWithValue("@component_id", component_id);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.ExecuteNonQuery();
        }

        private void DeleteBom()
        {
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
            cmd.CommandText = "DELETE FROM bom WHERE part_id = '" + cbPartID.Text + "';";
            int numRowsUpdated = cmd.ExecuteNonQuery();
        }

        private void UpdateBom()
        {
            string line_no = "";

            int rcount = dgBom.Rows.Count;

            DeleteBom();

            MysqlInterface.close();
            MysqlInterface.init();
            


            try
            {
                for (int i = 0; i < rcount - 1; i++)
                {

                        AddLine(i);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Part Not Saved Please Retry");

            }
            finally
            {
                MysqlInterface.close();
            }
        }

        private void SavePartID()
        {
            string part = cbPartID.Text;
            int count = 0;


            string qry = "SELECT count(id) FROM part where id = '" + part + "';";
            MySqlDataReader rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
                count = rdr.GetInt32(0);

            MysqlInterface.close();

            if (count > 0)
            {
                UpdatePart();
                UpdateBom();
                Globals.LoadParts();
                MessageBox.Show("Saved");
            }
            else
                MessageBox.Show("Invalid Part Name - Part Not Saved");

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            SavePartID();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void btAddLine_Click(object sender, EventArgs e)
        {
            LINE++;
            string str_lNo = LINE.ToString();
            string[] row = { str_lNo, "", "" , ""};

            int rows = dgBom.Rows.Count - 1;
            dgBom.Rows.Add(row);
        }

        public void ChangePart()
        {
            dgBom.Rows[Globals.row].Cells[Globals.column].Value = Globals.part;
        }

        private void dgBom_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int c = e.ColumnIndex;
            if (Globals.partSelected == false)
            {
                if (e.RowIndex >= 0)
                {
                    if (c == 1 && dgBom.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {

                        string curPart = Globals.part = dgBom.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        Globals.row = e.RowIndex;
                        Globals.column = e.ColumnIndex;
                        Globals.FM_PART_LOOKUP = new fmPartLookup("PartForm", curPart);
                        Globals.FM_PART_LOOKUP.ShowDialog();
                        Globals.FM_PART_LOOKUP.BringToFront();

                    }
                }
            }
            else
                Globals.partSelected = false;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            /* --FIX
             * 
             * This should delete the line in the database
             * delete the line user selected, if no line selected delete the last line
             * 
             * */
            if (LINE > 0)
            {

                try
                {

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
                    string lNo = "";
                    lNo = dgBom.Rows[curLine].Cells[0].Value.ToString();
                    cmd.CommandText = "DELETE FROM bom WHERE part_id = '" + cbPartID.Text + "' and line_no = " + lNo + ";";
                    int numRowsUpdated = cmd.ExecuteNonQuery();

                    LINE--;
                    int rows = dgBom.RowCount;
                    dgBom.Rows.RemoveAt(curLine);

                }
                catch (Exception)
                {

                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.FM_NEW_PART = new fmNewPart();
            Globals.FM_NEW_PART.Show();
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            Globals.FM_NEW_PART = new fmNewPart();
            Globals.FM_NEW_PART.Show();
        }

        public void CopyPart(string pName, string pDesc)
        {
            cbPartID.Text = pName;
            tbDescription.Text = pDesc;
            UpdatePart();
            UpdateBom();
            LoadParts();
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            Globals.FM_NEW_PART = new fmNewPart(true);
            Globals.FM_NEW_PART.Show();
        }

        private void btNew_Click_1(object sender, EventArgs e)
        {
            Globals.FM_NEW_PART = new fmNewPart();
            Globals.FM_NEW_PART.Show();
        }

        private void pbNew_Click(object sender, EventArgs e)
        {
            Globals.FM_NEW_PART = new fmNewPart();
            Globals.FM_NEW_PART.Show();
        }

        private void btDuplicate_Click(object sender, EventArgs e)
        {
            Globals.FM_NEW_PART = new fmNewPart(true);
            Globals.FM_NEW_PART.Show();
        }

        private void pbDuplicate_Click(object sender, EventArgs e)
        {
            Globals.FM_NEW_PART = new fmNewPart(true);
            Globals.FM_NEW_PART.Show();
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            SavePartID();
        }

        private void btSave_MouseHover(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderSize = 2;

        }

        private void btSave_MouseLeave(object sender, EventArgs e)
        {

            (sender as Button).FlatAppearance.BorderSize = 1;
        }

        private void pbNew_MouseHover(object sender, EventArgs e)
        {
            btNew.FlatAppearance.BorderSize = 2;
        }

        private void pbNew_MouseLeave(object sender, EventArgs e)
        {
            btNew.FlatAppearance.BorderSize = 1;
        }

        private void pbDuplicate_MouseHover(object sender, EventArgs e)
        {
            btDuplicate.FlatAppearance.BorderSize = 2;
        }

        private void pbDuplicate_MouseLeave(object sender, EventArgs e)
        {
            btDuplicate.FlatAppearance.BorderSize = 1;
        }

        private void pbSave_MouseHover(object sender, EventArgs e)
        {
            btSave.FlatAppearance.BorderSize = 2;
        }

        private void pbSave_MouseLeave(object sender, EventArgs e)
        {
            btSave.FlatAppearance.BorderSize = 1;
        }

        private void dgBom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            curLine = e.RowIndex;
        }



    }
}
