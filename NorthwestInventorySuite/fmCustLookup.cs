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
    public partial class fmCustLookup : Form
    {
        private new string Parent;


        public fmCustLookup()
        {
            Parent = "";
            InitializeComponent();
        }

        public fmCustLookup(string form)
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
            count = Globals.CUSTOMER_ARRAY.GetLength(0);
            for (int i = 0; i < count; i++)
            {
                p = Globals.CUSTOMER_ARRAY[i, 0];
                d = Globals.CUSTOMER_ARRAY[i, 1];
                string[] row = { p, d };
                dgPart.Rows.Add(row);
            }
        }

        private void dgPart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            string CustID;
            CustID = dgPart.Rows[r].Cells[0].Value.ToString();
            if (Parent == "OrderForm")
                Globals.FM_ORDER.ChangeCust(CustID);
            else if (Parent == "CustMain")
                Globals.FM_CUSTOMER_MAINTENANCE.LoadCustomer(CustID);
            Close();
        }
    }
}
