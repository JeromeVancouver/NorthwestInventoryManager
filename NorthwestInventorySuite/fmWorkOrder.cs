using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;

namespace NorthwestInventoryManager
{
    public partial class fmWorkorder : Form
    {
        public string orderid;

        public fmWorkorder()
        {
            InitializeComponent();
        }

        public fmWorkorder(string order)
        {
            InitializeComponent();
            orderid = order;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.Top = 0;
            try
            {
                ReportDocument cryRpt = new ReportDocument();
                string dir = System.IO.Directory.GetCurrentDirectory(); dir = "Default_WorkOrder.rpt";
                cryRpt.Load(dir);

                /*ConnectionInfo crConnectionInfo = new ConnectionInfo();
                crConnectionInfo.ServerName = MysqlInterface.host;
                crConnectionInfo.DatabaseName = MysqlInterface.dbase;
                crConnectionInfo.UserID = MysqlInterface.user;
                crConnectionInfo.Password = MysqlInterface.password;
                crConnectionInfo.AllowCustomConnection = true;
                Tables crTables;
            
                crTables = cryRpt.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables)
                {
                    TableLogOnInfo myTableLogonInfo = crTable.LogOnInfo;
                    myTableLogonInfo.ConnectionInfo.DatabaseName = MysqlInterface.dbase;
                    myTableLogonInfo.ConnectionInfo.UserID = MysqlInterface.user;
                    myTableLogonInfo.ConnectionInfo.Password = MysqlInterface.password;
                    myTableLogonInfo.ConnectionInfo.ServerName = MysqlInterface.host;
                    crTable.ApplyLogOnInfo(myTableLogonInfo);
                }
                */
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


                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh();

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
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }
    }
}
