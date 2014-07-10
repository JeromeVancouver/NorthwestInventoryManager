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
    public partial class fmOrderSearch : Form
    {
        private string parent;

        public fmOrderSearch()
        {
            InitializeComponent();
            parent = "";
        }

        public fmOrderSearch(string form)
        {
            InitializeComponent();
            parent = form;
        }

        private void ClearGrid()
        {
            dgOrders.Rows.Clear();
            dgOrders.RowCount = 1;
            dgOrders.Columns.Clear();
        }

        private void Search()
        {
            dgOrders.Rows.Clear();

            string order = tbOrderId.Text;
            string po = tbPO.Text;
            string cust = tbCustId.Text;
            DateTime oDate;
            string date = "";
            bool first = true;
            string state = cbState.Text;
            string tDef = cbTDef.Text;
            string oTotal = tbTotal.Text;

            string toDate = dtToDate.Value.ToString("yyyy-MM-dd");
            string fromDate = dtFromDate.Value.ToString("yyyy-MM-dd");

            string qry = "select id, cust_id, shipto_id, cust_po, order_date, desired_ship_date, total, state, notes from customer_order ";
            if (parent == "PurchaseOrder" || parent == "PurchaseReceipt")
                qry = "select id, vendor_id, shipto_id, vendor_po, order_date, desired_receive_date, total, state, notes from purchase_order ";
            if (order != "")
            {
                qry = qry + " where ";
                qry = qry + " id like '%" + order + "%' ";
                first = false;
            }

            if (po != "")
            {
                if (!first)
                    qry = qry + " and ";
                else
                    qry = qry + " where ";
                if (parent == "PurchaseOrder" || parent == "PurchaseReceipt")
                    qry = qry + " vendor_po like '%" + po + "%' ";
                else
                    qry = qry + " cust_po like '%" + po + "%' ";
                first = false;
            }
            if (cust != "")
            {
                if (!first)
                    qry = qry + " and ";
                else
                    qry = qry + " where ";
                if (parent == "PurchaseOrder" || parent == "PurchaseReceipt")
                    qry = qry + " vendor_id like '%" + cust + "%' ";
                else
                    qry = qry + " cust_id like '%" + cust + "%' ";
                first = false;
            }
            if (state != "")
            {
                if (!first)
                    qry = qry + " and ";
                else
                    qry = qry + " where ";
                qry = qry + " state like '" + state + "' ";
                first = false;
            }
            if (oTotal != "")
            {
                if (!first)
                    qry = qry + " and ";
                else
                    qry = qry + " where ";
                qry = qry + " total " + tDef + " " + oTotal;
                first = false;
            }

            if (!first)
                qry = qry + " and ";
            else
                qry = qry + " where ";
            qry = qry + " order_date  >= '" + fromDate + "' ";
            qry = qry + " and ";
            qry = qry + " order_date  <= '" + toDate + "' ";
            first = false;

            MySqlDataReader rdr = null;

            string shipto = "";
            DateTime sDate;
            string total;
            string shipDate = "";
            string notes = "";

            rdr = MysqlInterface.DoQuery(qry);
            if (rdr != null)
            {
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(0))
                    {
                        order = rdr.GetString(0);
                        cust = rdr.GetString(1);
                        shipto = rdr.GetString(2);
                        po = rdr.GetString(3);
                        oDate = rdr.GetDateTime(4);
                        date = oDate.ToString("yyyy-MM-dd");
                        sDate = rdr.GetDateTime(5);
                        shipDate = sDate.ToString("yyyy-MM-dd");
                        total = rdr.GetInt32(6).ToString();
                        state = rdr.GetString(7);
                        if (!rdr.IsDBNull(8)) notes = rdr.GetString(8); else notes = "";
                        string[] row = { order, state, cust, shipto, po, total, date, shipDate, notes };
                        dgOrders.Rows.Add(row);
                    }
                }
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void dgOrders_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int c = 0;
            int r = e.RowIndex;
            string oid = dgOrders.Rows[r].Cells[c].Value.ToString();


            if (parent == "CustOrder")
                Globals.FM_ORDER.ChangeIndex(oid);
            else if (parent == "ShipOrder")
                Globals.FM_SHIPPING_ENTRY.ChangeIndex(oid);
            else if (parent == "PurchaseOrder")
                Globals.FM_PURCHASE.ChangeIndex(oid);
            else if (parent == "PurchaseReceipt")
                Globals.FM_PO_RECEIPT.ChangeIndex(oid);


            Close();
        }

        private void fmOrderSearch_Load(object sender, EventArgs e)
        {
            dtToDate.Text = DateTime.Today.ToString();
        }

        private void tbCustId_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void bCustId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                Search();
        }
    }
}
