using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;

namespace NorthwestInventoryManager
{
    public partial class fmFullLabel : Form
    {
        public string orderid;

        public fmFullLabel()
        {
            InitializeComponent();
        }

        public fmFullLabel(string order)
        {
            InitializeComponent();
            orderid = order;
        }


        private void fmFullLabel_Load(object sender, EventArgs e)
        {
            try
            {
                ReportDocument cryRpt = new ReportDocument();
                string dir = System.IO.Directory.GetCurrentDirectory();
                dir = "label3.rpt";
                cryRpt.Load(dir);
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

                crParameterDiscreteValue.Value = orderid;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["orderid"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
                //cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, "c:\\temp\\report.pdf");
                crystalReportViewer1.ReportSource = cryRpt;
                //crystalReportViewer1.RefreshReport();


            }
            catch (LogOnException)
            {
                MessageBox.Show("Incorrect Logon Parameters. Check your user name and password.");
            }
            catch (DataSourceException)
            {
                MessageBox.Show("An error has occurred while connecting to the database.");
            }
            catch (EngineException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
