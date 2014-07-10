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
    public partial class fmPartLookup : Form
    {
        private string parent;
        private string part;

        public fmPartLookup()
        {
            parent = "";
            part = "";
            InitializeComponent();
        }

        public fmPartLookup(string form, string p)
        {
            parent = form;
            part = p;
            InitializeComponent();
        }

        public void ClearPartGrid()
        {
            dgPart.Rows.Clear();
            dgPart.RowCount = 1;
            dgPart.Columns.Clear();

        }

        private void fmPartLookup_Load(object sender, EventArgs e)
        {

            ClearPartGrid();

            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            string column = "Part";
            col.HeaderText = column;
            col.Width = 200;
            col.Name = "f" + column;
            dgPart.Columns.Add(col);

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            column = "Description";
            col1.HeaderText = column;
            col1.Width = 200;
            col1.Name = "f" + column;
            dgPart.Columns.Add(col1);

            int count = 0;
            string p;
            string d;
            count = Globals.PART_ARRAY.GetLength(0);
            for (int i = 0; i < count; i++)
            {
                p = Globals.PART_ARRAY[i, 0];
                int result = 0;
                result = p.IndexOf(part, 0);
                if (result >= 0)
                {
                    d = Globals.PART_ARRAY[i, 1];
                    string[] row = { p, d };
                    dgPart.Rows.Add(row);
                }
            }
        }



        private void dgPart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int c = 0;
            int r = e.RowIndex;
            Globals.partSelected = true;
            Globals.part = dgPart.Rows[r].Cells[c].Value.ToString();
            if (parent == "OrderForm")
                Globals.FM_ORDER.ChangePart();
            else if (parent == "PartForm")
                Globals.FM_PART_MAINTENANCE.ChangePart();
            else if (parent == "PartMain")
                Globals.FM_PART_MAINTENANCE.ChangeIndex(Globals.part);
            else if (parent == "POForm")
                Globals.FM_PURCHASE.ChangePart();
            else if (parent == "Adjustment")
                Globals.FM_ADJUSTMENT.ChangePart();
            else if (parent == "SubUsed")
                Globals.FM_SUBSTITUTION.ChangeUsed();
            else if (parent == "SubSub")
                Globals.FM_SUBSTITUTION.ChangeSub();
            Close();
        }

        private void dgPart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'C')
            {
            }
        }



    }
}
