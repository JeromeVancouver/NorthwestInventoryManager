using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NorthwestInventoryManager
{
    public partial class fmVendLookup : Form
    {
        private new string Parent;


        public fmVendLookup()
        {
            Parent = "";
            InitializeComponent();
        }

        public fmVendLookup(string form)
        {
            Parent = form;
            InitializeComponent();
        }

        public void ClearPartGrid()
        {
            dgPart.Rows.Clear();
            dgPart.RowCount = 1;
            dgPart.Columns.Clear();

        }

        private void fmCustLookup_Load(object sender, EventArgs e)
        {

            ClearPartGrid();

            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            string column = "ID";
            col.HeaderText = column;
            col.Width = 200;
            col.Name = "f" + column;
            dgPart.Columns.Add(col);

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            column = "Name";
            col1.HeaderText = column;
            col1.Width = 200;
            col1.Name = "f" + column;
            dgPart.Columns.Add(col1);

            int count = 0;
            string p;
            string d;
            count = Globals.VENDOR_ARRAY.GetLength(0);
            for (int i = 0; i < count; i++)
            {
                p = Globals.VENDOR_ARRAY[i, 0];
                d = Globals.VENDOR_ARRAY[i, 1];
                string[] row = { p, d };
                dgPart.Rows.Add(row);
            }
        }

        private void dgPart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            string CustID;
            CustID = dgPart.Rows[r].Cells[0].Value.ToString();
            if (Parent == "VendMain")
                Globals.FM_VENDOR_MAINTENANCE.LoadVendor(CustID);
            Close();
        }
    }
}
