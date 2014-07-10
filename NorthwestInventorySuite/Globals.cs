using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace NorthwestInventoryManager
{
    public static class Globals
    {
        public static int GetCurrentBox()
        {
            MySqlDataReader rdr = null;
            int id = 0;
            string qry = "SELECT box_id FROM current_values;";
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                id = rdr.GetInt32(0);
            }
            return id;
        }

        public static string CreateNewTruck(string desc, string carrier)
        {
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            string tId = "";

            try
            {

                string qry = "SELECT truck_id FROM current_values;";
                reader = MysqlInterface.DoQuery(qry);
                while (reader.Read())
                {
                    tId = reader.GetString(0);
                }

                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;

                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open(); //open the connection

                string cmdText = "INSERT INTO truck (id, description, shipper_id)" +
                "VALUES(@id, @description, @shipper_id)";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", tId);
                cmd.Parameters.AddWithValue("@description", desc);
                cmd.Parameters.AddWithValue("@shipper_id", carrier);
                cmd.ExecuteNonQuery();


                str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open();

                string newTId;
                newTId = (Convert.ToInt32(tId) + 1).ToString();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE current_values SET truck_id = '" + newTId + "';";
                int numRowsUpdated = cmd.ExecuteNonQuery();


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
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return tId;
        }


        public static void LoadVendors()
        {
            MySqlDataReader rdr = null;
            string id = "";
            string name = "";
            int count = 0;
            rdr = MysqlInterface.DoQuery("SELECT count(id) FROM vendor");

            while (rdr.Read())
            {
                count = rdr.GetInt32(0);
            }

            Globals.VENDOR_ARRAY = new string[count, 2];

            rdr = MysqlInterface.DoQuery("SELECT id, name FROM vendor");
            int i = 0;
            while (rdr.Read())
            {
                id = rdr.GetString(0);
                Globals.VENDOR_ARRAY[i, 0] = id;

                name = rdr.GetString(1);
                Globals.VENDOR_ARRAY[i, 1] = name;


                i++;
            }
        }

        public static void LoadCustomers()
        {
            MySqlDataReader rdr = null;
            string id = "";
            string name = "";
            int count = 0;
            rdr = MysqlInterface.DoQuery("SELECT count(id) FROM customer");

            while (rdr.Read())
            {
                count = rdr.GetInt32(0);
            }

            Globals.CUSTOMER_ARRAY = new string[count, 2];

            rdr = MysqlInterface.DoQuery("SELECT id, name FROM customer");
            int i = 0;
            while (rdr.Read())
            {
                id = rdr.GetString(0);
                Globals.CUSTOMER_ARRAY[i, 0] = id;

                name = rdr.GetString(1);
                Globals.CUSTOMER_ARRAY[i, 1] = name;


                i++;
            }
        }

        public static void LoadParts()
        {
            MySqlDataReader rdr = null;
            string id = "";
            int count = 0;
            string desc = "";
            string qty = "";
            string pp = "";
            string sp = "";
            rdr = MysqlInterface.DoQuery("SELECT count(id) FROM part");

            while (rdr.Read())
            {
                count = rdr.GetInt32(0);
            }

            Globals.PART_ARRAY = new string[count, 5];

            rdr = MysqlInterface.DoQuery("SELECT id, description, qty_on_hand, purchase_price, selling_price FROM part");
            int i = 0;
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0)) id = rdr.GetString(0); else id = "";
                Globals.PART_ARRAY[i, 0] = id;
                if (!rdr.IsDBNull(1)) desc = rdr.GetString(1); else desc = "";
                Globals.PART_ARRAY[i, 1] = desc;
                if (!rdr.IsDBNull(2)) qty = rdr.GetString(2); else qty = "";
                Globals.PART_ARRAY[i, 2] = qty;
                if (!rdr.IsDBNull(3)) pp = rdr.GetString(3); else pp = "";
                Globals.PART_ARRAY[i, 3] = pp;
                if (!rdr.IsDBNull(4)) sp = rdr.GetString(4); else sp = "";
                Globals.PART_ARRAY[i, 4] = sp;
                i++;
            }
        }

        public static string part;
        public static string qry;
        public static int column;
        public static int row;
        public static bool partSelected;
        public static string USER;
        public static string USER_NAME;


        /*
         * 
         *      FORMS
         * 
        */

        //      MAIN

        public static fmMain FM_MAIN;
        public static fmMessageBox FM_MESSAGEBOX;
        public static fmSplash FM_SPLASH;
        public static fmSaveDialogue FM_SAVE;
        public static fmLogin FM_LOGIN;

        //      FILE

        public static fmCarrier FM_CARRIER;
        public static fmAddress FM_ADDRESS;
        public static fmOptions FM_OPTIONS;
        public static fmContact FM_CONTACT;

        //      SALES

        public static fmCustomerOrderEntry FM_ORDER;
        public static fmCustMaintenance FM_CUSTOMER_MAINTENANCE;
        public static fmCustLookup FM_CUST_LOOKUP;
        public static fmOrderSearch FM_ORDER_SEARCH;
        public static fmNewCustomer FM_NEW_CUSTOMER;
        public static fmShippingEntry FM_SHIPPING_ENTRY;

        //      SCHEDULING

        public static fmTruckScheduler FM_TRUCK_SCHEDULER;
        public static fmNewTruck FM_NEW_TRUCK;

        //      PURCHASING

        public static fmPurchaseOrderEntry FM_PURCHASE;
        public static fmVendorMaintenance FM_VENDOR_MAINTENANCE;
        public static fmPOReceipt FM_PO_RECEIPT;
        public static fmNewVendor FM_NEW_VENDOR;
        public static fmVendLookup FM_VENDOR_LOOKUP;

        //      TOOLS

        public static fmImport FM_IMPORT;
        public static fmCalculator FM_CALCULATOR;

        //      REPORTS

        public static fmInvoice FM_INVOICE;
        public static fmPacklist FM_PACKLIST;
        public static fmWorkOrder FM_WORK_ORDER;
        public static fmProjectCosting FM_PROJECT_COSTING;
        public static fmShortage FM_SHORTAGE;
        public static fmAllocation FM_ALLOCATION;
        public static fmCycleCount FM_CYCLE_COUNT;
        public static fmReceiving FM_RECEIVING;
        public static fmFullLabel FM_FULL_LABEL;
        public static fmPurchaseOrder FM_PURCHASE_ORDER;

        //      INVENTORY


        public static fmPartMaintenance FM_PART_MAINTENANCE;
        public static fmPartLookup FM_PART_LOOKUP;
        public static fmStockStatus FM_STOCKSTATUS;
        public static fmNewPart FM_NEW_PART;
        public static fmSubstitution FM_SUBSTITUTION;
        public static fmAdjustment FM_ADJUSTMENT;
        public static fmPartHistory FM_PART_HISTORY;
        public static fmPartBuilder FM_PART_BUILDER;


        public static string[,] PART_ARRAY;
        public static string[,] CUSTOMER_ARRAY;
        public static string[,] VENDOR_ARRAY;
        public static string[] CARRIER_ARRAY;

    }
}
