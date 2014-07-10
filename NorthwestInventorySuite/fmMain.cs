using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Outlook = Microsoft.Office.Interop.Outlook;
using MySql.Data.MySqlClient;

namespace NorthwestInventoryManager
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }


        private void customerMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.FM_CUSTOMER_MAINTENANCE = new fmCustMaintenance();
            Globals.FM_CUSTOMER_MAINTENANCE.Show();
        }

        private void customerOrderEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.FM_ORDER = new fmCustomerOrderEntry();
            Globals.FM_ORDER.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void vendorMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Globals.FM_VENDOR_MAINTENANCE = new fmVendorMaintenance();
            Globals.FM_VENDOR_MAINTENANCE.Show();

        }


        private void partMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Globals.FM_PART_MAINTENANCE = new fmPartMaintenance();
            Globals.FM_PART_MAINTENANCE.Show();
        }


        public static void fmPurcOrderEntry()
        {
            Application.Run(new fmPurchaseOrderEntry());
        }

        private void purchaseOrderEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.FM_PURCHASE = new fmPurchaseOrderEntry();
            Globals.FM_PURCHASE.Show();
        }

        private void shippingEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.FM_SHIPPING_ENTRY = new fmShippingEntry();
            Globals.FM_SHIPPING_ENTRY.Show();
        }

        private void materialPlanningWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fmMain_Load(object sender, EventArgs e)
        {

        }


        private void cycleCountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Globals.FM_IMPORT = new fmImport();
            Globals.FM_IMPORT.Show();
        }

        private void doorCalculatorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Globals.FM_CALCULATOR = new fmCalculator();
            Globals.FM_CALCULATOR.Show();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.FM_OPTIONS = new fmOptions();
            Globals.FM_OPTIONS.Show();
        }

        private void purchaseOrderReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.FM_PO_RECEIPT = new fmPOReceipt();
            Globals.FM_PO_RECEIPT.Show();
        }

        private void truckSchedulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.FM_TRUCK_SCHEDULER = new fmTruckScheduler();
            Globals.FM_TRUCK_SCHEDULER.Show();
        }

        private void substitutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.FM_SUBSTITUTION = new fmSubstitution();
            Globals.FM_SUBSTITUTION.Show();
        }

        private void adjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.FM_ADJUSTMENT = new fmAdjustment();
            Globals.FM_ADJUSTMENT.Show();
        }

        private void partHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.FM_PART_HISTORY = new fmPartHistory();
            Globals.FM_PART_HISTORY.Show();
        }

        private void carrierSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.FM_CARRIER = new fmCarrier();
            Globals.FM_CARRIER.Show();
        }

        private void shortageReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void allocationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stockStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.FM_STOCKSTATUS = new fmStockStatus();
            Globals.FM_STOCKSTATUS.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void shortageReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Globals.FM_SHORTAGE = new fmShortage("Released");
            Globals.FM_SHORTAGE.Show();
        }

        private void allocationReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Globals.FM_ALLOCATION = new fmAllocation("Released");
            Globals.FM_ALLOCATION.Show();
        }

        private void cycleCountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Globals.FM_CYCLE_COUNT = new fmCycleCount("A");
            Globals.FM_CYCLE_COUNT.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UChPqIYGBxD7p1Pn6yW3baWg");
        }




    }
}
