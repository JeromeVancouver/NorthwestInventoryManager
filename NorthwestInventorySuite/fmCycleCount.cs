using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace NorthwestInventoryManager
{
    public partial class fmCycleCount : Form
    {
        public string state;

        public fmCycleCount()
        {
            InitializeComponent();
        }

        public fmCycleCount(string status)
        {
            InitializeComponent();
            state = status;
        }

        private void fmCycleCount_Load(object sender, EventArgs e)
        {
            try
            {
                ReportDocument cryRpt = new ReportDocument();
                string dir = System.IO.Directory.GetCurrentDirectory();dir = "CycleCount.rpt";
                cryRpt.Load(dir);
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

                crParameterDiscreteValue.Value = state.ToString();
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["rackid"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.RefreshReport();


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
