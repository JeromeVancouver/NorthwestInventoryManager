namespace NorthwestInventoryManager
{
    partial class fmShippingEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmShippingEntry));
            this.dtActualShip = new System.Windows.Forms.DateTimePicker();
            this.dtDesiredShip = new System.Windows.Forms.DateTimePicker();
            this.dtOrderDate = new System.Windows.Forms.DateTimePicker();
            this.tbFOB = new System.Windows.Forms.TextBox();
            this.btShipTo = new System.Windows.Forms.Button();
            this.cbShipTo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btCarrier = new System.Windows.Forms.Button();
            this.cbCarrier = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgOrderForm = new System.Windows.Forms.DataGridView();
            this.cLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cShip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBackorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btCustomer = new System.Windows.Forms.Button();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCustPO = new System.Windows.Forms.TextBox();
            this.tbOrderId = new System.Windows.Forms.TextBox();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbSend = new System.Windows.Forms.PictureBox();
            this.btSend = new System.Windows.Forms.Button();
            this.btReportsDropDown = new System.Windows.Forms.Button();
            this.pbReports = new System.Windows.Forms.PictureBox();
            this.btReports = new System.Windows.Forms.Button();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.pbShip = new System.Windows.Forms.PictureBox();
            this.btShip = new System.Windows.Forms.Button();
            this.btInvoice = new System.Windows.Forms.Button();
            this.btPacklist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderForm)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShip)).BeginInit();
            this.SuspendLayout();
            // 
            // dtActualShip
            // 
            this.dtActualShip.Enabled = false;
            this.dtActualShip.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtActualShip.Location = new System.Drawing.Point(156, 201);
            this.dtActualShip.Name = "dtActualShip";
            this.dtActualShip.Size = new System.Drawing.Size(145, 20);
            this.dtActualShip.TabIndex = 112;
            this.dtActualShip.Value = new System.DateTime(2013, 10, 15, 0, 0, 0, 0);
            // 
            // dtDesiredShip
            // 
            this.dtDesiredShip.Enabled = false;
            this.dtDesiredShip.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesiredShip.Location = new System.Drawing.Point(156, 174);
            this.dtDesiredShip.Name = "dtDesiredShip";
            this.dtDesiredShip.Size = new System.Drawing.Size(145, 20);
            this.dtDesiredShip.TabIndex = 111;
            this.dtDesiredShip.Value = new System.DateTime(2013, 10, 15, 0, 0, 0, 0);
            // 
            // dtOrderDate
            // 
            this.dtOrderDate.Enabled = false;
            this.dtOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtOrderDate.Location = new System.Drawing.Point(156, 122);
            this.dtOrderDate.Name = "dtOrderDate";
            this.dtOrderDate.Size = new System.Drawing.Size(145, 20);
            this.dtOrderDate.TabIndex = 110;
            this.dtOrderDate.Value = new System.DateTime(2013, 10, 15, 0, 0, 0, 0);
            // 
            // tbFOB
            // 
            this.tbFOB.Enabled = false;
            this.tbFOB.Location = new System.Drawing.Point(422, 71);
            this.tbFOB.Name = "tbFOB";
            this.tbFOB.Size = new System.Drawing.Size(189, 20);
            this.tbFOB.TabIndex = 87;
            // 
            // btShipTo
            // 
            this.btShipTo.Location = new System.Drawing.Point(279, 97);
            this.btShipTo.Name = "btShipTo";
            this.btShipTo.Size = new System.Drawing.Size(22, 21);
            this.btShipTo.TabIndex = 107;
            this.btShipTo.Text = "..";
            this.btShipTo.UseVisualStyleBackColor = true;
            // 
            // cbShipTo
            // 
            this.cbShipTo.Enabled = false;
            this.cbShipTo.FormattingEnabled = true;
            this.cbShipTo.Location = new System.Drawing.Point(156, 96);
            this.cbShipTo.Name = "cbShipTo";
            this.cbShipTo.Size = new System.Drawing.Size(117, 21);
            this.cbShipTo.TabIndex = 84;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 20);
            this.label11.TabIndex = 106;
            this.label11.Text = "ShipTo ID";
            // 
            // tbNotes
            // 
            this.tbNotes.Enabled = false;
            this.tbNotes.Location = new System.Drawing.Point(422, 124);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(189, 97);
            this.tbNotes.TabIndex = 89;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(339, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 105;
            this.label10.Text = "Notes";
            // 
            // btCarrier
            // 
            this.btCarrier.Location = new System.Drawing.Point(589, 97);
            this.btCarrier.Name = "btCarrier";
            this.btCarrier.Size = new System.Drawing.Size(22, 21);
            this.btCarrier.TabIndex = 104;
            this.btCarrier.Text = "..";
            this.btCarrier.UseVisualStyleBackColor = true;
            // 
            // cbCarrier
            // 
            this.cbCarrier.Enabled = false;
            this.cbCarrier.FormattingEnabled = true;
            this.cbCarrier.Items.AddRange(new object[] {
            "Firmed",
            "Released",
            "On Hold",
            "Shipped",
            "Closed"});
            this.cbCarrier.Location = new System.Drawing.Point(423, 97);
            this.cbCarrier.Name = "cbCarrier";
            this.cbCarrier.Size = new System.Drawing.Size(161, 21);
            this.cbCarrier.TabIndex = 88;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(339, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.TabIndex = 103;
            this.label9.Text = "Carrier ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(339, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 102;
            this.label8.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(339, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 101;
            this.label6.Text = "FOB";
            // 
            // dgOrderForm
            // 
            this.dgOrderForm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cLine,
            this.cPartId,
            this.cDescription,
            this.cQuantity,
            this.cShip,
            this.cBackorder,
            this.cUnitPrice,
            this.cGST,
            this.cPST});
            this.dgOrderForm.Location = new System.Drawing.Point(11, 241);
            this.dgOrderForm.Name = "dgOrderForm";
            this.dgOrderForm.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgOrderForm.Size = new System.Drawing.Size(824, 254);
            this.dgOrderForm.TabIndex = 100;
            // 
            // cLine
            // 
            this.cLine.HeaderText = "Ln#";
            this.cLine.Name = "cLine";
            this.cLine.ReadOnly = true;
            this.cLine.Width = 50;
            // 
            // cPartId
            // 
            this.cPartId.HeaderText = " Part ID";
            this.cPartId.Name = "cPartId";
            this.cPartId.ReadOnly = true;
            this.cPartId.Width = 200;
            // 
            // cDescription
            // 
            this.cDescription.HeaderText = "Description";
            this.cDescription.Name = "cDescription";
            this.cDescription.ReadOnly = true;
            this.cDescription.Width = 250;
            // 
            // cQuantity
            // 
            this.cQuantity.HeaderText = "Quantity";
            this.cQuantity.Name = "cQuantity";
            this.cQuantity.ReadOnly = true;
            this.cQuantity.Width = 75;
            // 
            // cShip
            // 
            this.cShip.HeaderText = "Ship Qty";
            this.cShip.Name = "cShip";
            this.cShip.Width = 75;
            // 
            // cBackorder
            // 
            this.cBackorder.HeaderText = "Backordered";
            this.cBackorder.Name = "cBackorder";
            this.cBackorder.Width = 75;
            // 
            // cUnitPrice
            // 
            this.cUnitPrice.HeaderText = "Unit Price";
            this.cUnitPrice.Name = "cUnitPrice";
            this.cUnitPrice.ReadOnly = true;
            this.cUnitPrice.Width = 75;
            // 
            // cGST
            // 
            this.cGST.HeaderText = "GST";
            this.cGST.Name = "cGST";
            this.cGST.ReadOnly = true;
            // 
            // cPST
            // 
            this.cPST.HeaderText = "PST";
            this.cPST.Name = "cPST";
            this.cPST.ReadOnly = true;
            // 
            // btCustomer
            // 
            this.btCustomer.Location = new System.Drawing.Point(279, 73);
            this.btCustomer.Name = "btCustomer";
            this.btCustomer.Size = new System.Drawing.Size(22, 21);
            this.btCustomer.TabIndex = 99;
            this.btCustomer.Text = "..";
            this.btCustomer.UseVisualStyleBackColor = true;
            // 
            // cbCustomer
            // 
            this.cbCustomer.Enabled = false;
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(156, 72);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(117, 21);
            this.cbCustomer.TabIndex = 83;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 96;
            this.label7.Text = "Order Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 95;
            this.label5.Text = "Actual Ship Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 94;
            this.label4.Text = "Desired Ship Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 93;
            this.label3.Text = "Customer PO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 92;
            this.label2.Text = "Customer ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 91;
            this.label1.Text = "Order ID";
            // 
            // tbCustPO
            // 
            this.tbCustPO.Enabled = false;
            this.tbCustPO.Location = new System.Drawing.Point(156, 149);
            this.tbCustPO.Name = "tbCustPO";
            this.tbCustPO.Size = new System.Drawing.Size(145, 20);
            this.tbCustPO.TabIndex = 85;
            // 
            // tbOrderId
            // 
            this.tbOrderId.Location = new System.Drawing.Point(156, 46);
            this.tbOrderId.Name = "tbOrderId";
            this.tbOrderId.Size = new System.Drawing.Size(145, 20);
            this.tbOrderId.TabIndex = 82;
            this.tbOrderId.Leave += new System.EventHandler(this.tbOrderId_Leave);
            // 
            // tbStatus
            // 
            this.tbStatus.Enabled = false;
            this.tbStatus.Location = new System.Drawing.Point(422, 43);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(189, 20);
            this.tbStatus.TabIndex = 113;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.pbSend);
            this.panel2.Controls.Add(this.btSend);
            this.panel2.Controls.Add(this.btReportsDropDown);
            this.panel2.Controls.Add(this.pbReports);
            this.panel2.Controls.Add(this.btReports);
            this.panel2.Controls.Add(this.pbSearch);
            this.panel2.Controls.Add(this.btSearch);
            this.panel2.Controls.Add(this.pbShip);
            this.panel2.Controls.Add(this.btShip);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(865, 38);
            this.panel2.TabIndex = 114;
            // 
            // pbSend
            // 
            this.pbSend.BackColor = System.Drawing.Color.Transparent;
            this.pbSend.Image = global::NorthwestInventoryManager.Properties.Resources.Email_icon;
            this.pbSend.Location = new System.Drawing.Point(354, 5);
            this.pbSend.Name = "pbSend";
            this.pbSend.Size = new System.Drawing.Size(22, 27);
            this.pbSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSend.TabIndex = 94;
            this.pbSend.TabStop = false;
            // 
            // btSend
            // 
            this.btSend.BackColor = System.Drawing.SystemColors.Control;
            this.btSend.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btSend.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSend.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSend.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btSend.Location = new System.Drawing.Point(346, 2);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(164, 34);
            this.btSend.TabIndex = 93;
            this.btSend.Text = "Send Invoice";
            this.btSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSend.UseVisualStyleBackColor = false;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            this.btSend.MouseLeave += new System.EventHandler(this.btShip_MouseLeave_1);
            this.btSend.MouseHover += new System.EventHandler(this.btShip_MouseHover_1);
            // 
            // btReportsDropDown
            // 
            this.btReportsDropDown.BackColor = System.Drawing.SystemColors.Control;
            this.btReportsDropDown.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btReportsDropDown.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btReportsDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReportsDropDown.Font = new System.Drawing.Font("Neuropol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReportsDropDown.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btReportsDropDown.Location = new System.Drawing.Point(319, 2);
            this.btReportsDropDown.Name = "btReportsDropDown";
            this.btReportsDropDown.Size = new System.Drawing.Size(25, 34);
            this.btReportsDropDown.TabIndex = 92;
            this.btReportsDropDown.Text = "v";
            this.btReportsDropDown.UseVisualStyleBackColor = false;
            this.btReportsDropDown.Click += new System.EventHandler(this.btReportsDropDown_Click);
            this.btReportsDropDown.MouseLeave += new System.EventHandler(this.btShip_MouseLeave_1);
            this.btReportsDropDown.MouseHover += new System.EventHandler(this.btShip_MouseHover_1);
            // 
            // pbReports
            // 
            this.pbReports.BackColor = System.Drawing.Color.Transparent;
            this.pbReports.Image = global::NorthwestInventoryManager.Properties.Resources.reports_icon;
            this.pbReports.Location = new System.Drawing.Point(209, 6);
            this.pbReports.Name = "pbReports";
            this.pbReports.Size = new System.Drawing.Size(22, 24);
            this.pbReports.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReports.TabIndex = 91;
            this.pbReports.TabStop = false;
            this.pbReports.Click += new System.EventHandler(this.pbReports_Click);
            // 
            // btReports
            // 
            this.btReports.BackColor = System.Drawing.SystemColors.Control;
            this.btReports.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btReports.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReports.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReports.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btReports.Location = new System.Drawing.Point(201, 2);
            this.btReports.Name = "btReports";
            this.btReports.Size = new System.Drawing.Size(119, 34);
            this.btReports.TabIndex = 90;
            this.btReports.Text = "Reports";
            this.btReports.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btReports.UseVisualStyleBackColor = false;
            this.btReports.Click += new System.EventHandler(this.btReports_Click);
            this.btReports.MouseLeave += new System.EventHandler(this.btShip_MouseLeave_1);
            this.btReports.MouseHover += new System.EventHandler(this.btShip_MouseHover_1);
            // 
            // pbSearch
            // 
            this.pbSearch.BackColor = System.Drawing.Color.Transparent;
            this.pbSearch.Image = global::NorthwestInventoryManager.Properties.Resources.find_icon;
            this.pbSearch.Location = new System.Drawing.Point(99, 6);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(22, 25);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSearch.TabIndex = 89;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // btSearch
            // 
            this.btSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSearch.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btSearch.Location = new System.Drawing.Point(94, 2);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(105, 34);
            this.btSearch.TabIndex = 88;
            this.btSearch.Text = "Search";
            this.btSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            this.btSearch.MouseLeave += new System.EventHandler(this.btShip_MouseLeave_1);
            this.btSearch.MouseHover += new System.EventHandler(this.btShip_MouseHover_1);
            // 
            // pbShip
            // 
            this.pbShip.BackColor = System.Drawing.Color.Transparent;
            this.pbShip.Image = global::NorthwestInventoryManager.Properties.Resources.Ship_icon;
            this.pbShip.Location = new System.Drawing.Point(9, 4);
            this.pbShip.Name = "pbShip";
            this.pbShip.Size = new System.Drawing.Size(22, 27);
            this.pbShip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShip.TabIndex = 85;
            this.pbShip.TabStop = false;
            this.pbShip.Click += new System.EventHandler(this.pbShip_Click);
            // 
            // btShip
            // 
            this.btShip.BackColor = System.Drawing.SystemColors.Control;
            this.btShip.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btShip.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btShip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btShip.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btShip.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btShip.Location = new System.Drawing.Point(1, 2);
            this.btShip.Name = "btShip";
            this.btShip.Size = new System.Drawing.Size(91, 34);
            this.btShip.TabIndex = 84;
            this.btShip.Text = "Ship";
            this.btShip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btShip.UseVisualStyleBackColor = false;
            this.btShip.Click += new System.EventHandler(this.btShip_Click_1);
            this.btShip.MouseLeave += new System.EventHandler(this.btShip_MouseLeave_1);
            this.btShip.MouseHover += new System.EventHandler(this.btShip_MouseHover_1);
            // 
            // btInvoice
            // 
            this.btInvoice.BackColor = System.Drawing.SystemColors.Control;
            this.btInvoice.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInvoice.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInvoice.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btInvoice.Location = new System.Drawing.Point(202, 35);
            this.btInvoice.Name = "btInvoice";
            this.btInvoice.Size = new System.Drawing.Size(156, 34);
            this.btInvoice.TabIndex = 100;
            this.btInvoice.Text = "Invoice";
            this.btInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInvoice.UseVisualStyleBackColor = false;
            this.btInvoice.Visible = false;
            this.btInvoice.Click += new System.EventHandler(this.btInvoice_Click);
            this.btInvoice.MouseLeave += new System.EventHandler(this.btShip_MouseLeave_1);
            this.btInvoice.MouseHover += new System.EventHandler(this.btShip_MouseHover_1);
            // 
            // btPacklist
            // 
            this.btPacklist.BackColor = System.Drawing.SystemColors.Control;
            this.btPacklist.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btPacklist.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btPacklist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPacklist.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPacklist.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btPacklist.Location = new System.Drawing.Point(202, 65);
            this.btPacklist.Name = "btPacklist";
            this.btPacklist.Size = new System.Drawing.Size(156, 34);
            this.btPacklist.TabIndex = 115;
            this.btPacklist.Text = "Packlist";
            this.btPacklist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPacklist.UseVisualStyleBackColor = false;
            this.btPacklist.Visible = false;
            this.btPacklist.Click += new System.EventHandler(this.btPacklist_Click);
            this.btPacklist.MouseLeave += new System.EventHandler(this.btShip_MouseLeave_1);
            this.btPacklist.MouseHover += new System.EventHandler(this.btShip_MouseHover_1);
            // 
            // fmShippingEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 509);
            this.Controls.Add(this.btPacklist);
            this.Controls.Add(this.btInvoice);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.dtActualShip);
            this.Controls.Add(this.dtDesiredShip);
            this.Controls.Add(this.dtOrderDate);
            this.Controls.Add(this.tbFOB);
            this.Controls.Add(this.btShipTo);
            this.Controls.Add(this.cbShipTo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btCarrier);
            this.Controls.Add(this.cbCarrier);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgOrderForm);
            this.Controls.Add(this.btCustomer);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCustPO);
            this.Controls.Add(this.tbOrderId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmShippingEntry";
            this.Text = "Shipping Entry";
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderForm)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtActualShip;
        private System.Windows.Forms.DateTimePicker dtDesiredShip;
        private System.Windows.Forms.DateTimePicker dtOrderDate;
        private System.Windows.Forms.TextBox tbFOB;
        private System.Windows.Forms.Button btShipTo;
        private System.Windows.Forms.ComboBox cbShipTo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btCarrier;
        private System.Windows.Forms.ComboBox cbCarrier;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgOrderForm;
        private System.Windows.Forms.Button btCustomer;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCustPO;
        private System.Windows.Forms.TextBox tbOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn cQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn cShip;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBackorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPST;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbSend;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btReportsDropDown;
        private System.Windows.Forms.PictureBox pbReports;
        private System.Windows.Forms.Button btReports;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.PictureBox pbShip;
        private System.Windows.Forms.Button btShip;
        private System.Windows.Forms.Button btInvoice;
        private System.Windows.Forms.Button btPacklist;
    }
}