namespace NorthwestInventoryManager
{
    partial class fmPOReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmPOReceipt));
            this.tbStatus = new System.Windows.Forms.TextBox();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbReports = new System.Windows.Forms.PictureBox();
            this.btReports = new System.Windows.Forms.Button();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.pbShip = new System.Windows.Forms.PictureBox();
            this.btReceive = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderForm)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShip)).BeginInit();
            this.SuspendLayout();
            // 
            // tbStatus
            // 
            this.tbStatus.Enabled = false;
            this.tbStatus.Location = new System.Drawing.Point(426, 41);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(189, 20);
            this.tbStatus.TabIndex = 139;
            // 
            // dtActualShip
            // 
            this.dtActualShip.Enabled = false;
            this.dtActualShip.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtActualShip.Location = new System.Drawing.Point(160, 199);
            this.dtActualShip.Name = "dtActualShip";
            this.dtActualShip.Size = new System.Drawing.Size(145, 20);
            this.dtActualShip.TabIndex = 138;
            this.dtActualShip.Value = new System.DateTime(2013, 10, 15, 0, 0, 0, 0);
            // 
            // dtDesiredShip
            // 
            this.dtDesiredShip.Enabled = false;
            this.dtDesiredShip.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesiredShip.Location = new System.Drawing.Point(160, 172);
            this.dtDesiredShip.Name = "dtDesiredShip";
            this.dtDesiredShip.Size = new System.Drawing.Size(145, 20);
            this.dtDesiredShip.TabIndex = 137;
            this.dtDesiredShip.Value = new System.DateTime(2013, 10, 15, 0, 0, 0, 0);
            // 
            // dtOrderDate
            // 
            this.dtOrderDate.Enabled = false;
            this.dtOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtOrderDate.Location = new System.Drawing.Point(160, 120);
            this.dtOrderDate.Name = "dtOrderDate";
            this.dtOrderDate.Size = new System.Drawing.Size(145, 20);
            this.dtOrderDate.TabIndex = 136;
            this.dtOrderDate.Value = new System.DateTime(2013, 10, 15, 0, 0, 0, 0);
            // 
            // tbFOB
            // 
            this.tbFOB.Enabled = false;
            this.tbFOB.Location = new System.Drawing.Point(426, 69);
            this.tbFOB.Name = "tbFOB";
            this.tbFOB.Size = new System.Drawing.Size(189, 20);
            this.tbFOB.TabIndex = 118;
            // 
            // btShipTo
            // 
            this.btShipTo.Location = new System.Drawing.Point(283, 95);
            this.btShipTo.Name = "btShipTo";
            this.btShipTo.Size = new System.Drawing.Size(22, 21);
            this.btShipTo.TabIndex = 135;
            this.btShipTo.Text = "..";
            this.btShipTo.UseVisualStyleBackColor = true;
            // 
            // cbShipTo
            // 
            this.cbShipTo.Enabled = false;
            this.cbShipTo.FormattingEnabled = true;
            this.cbShipTo.Location = new System.Drawing.Point(160, 94);
            this.cbShipTo.Name = "cbShipTo";
            this.cbShipTo.Size = new System.Drawing.Size(117, 21);
            this.cbShipTo.TabIndex = 116;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 20);
            this.label11.TabIndex = 134;
            this.label11.Text = "ShipTo ID";
            // 
            // tbNotes
            // 
            this.tbNotes.Enabled = false;
            this.tbNotes.Location = new System.Drawing.Point(426, 122);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(189, 97);
            this.tbNotes.TabIndex = 120;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(343, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 133;
            this.label10.Text = "Notes";
            // 
            // btCarrier
            // 
            this.btCarrier.Location = new System.Drawing.Point(593, 94);
            this.btCarrier.Name = "btCarrier";
            this.btCarrier.Size = new System.Drawing.Size(22, 21);
            this.btCarrier.TabIndex = 132;
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
            this.cbCarrier.Location = new System.Drawing.Point(427, 95);
            this.cbCarrier.Name = "cbCarrier";
            this.cbCarrier.Size = new System.Drawing.Size(161, 21);
            this.cbCarrier.TabIndex = 119;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(343, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.TabIndex = 131;
            this.label9.Text = "Carrier ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(343, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 130;
            this.label8.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(343, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 129;
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
            this.dgOrderForm.Location = new System.Drawing.Point(15, 239);
            this.dgOrderForm.Name = "dgOrderForm";
            this.dgOrderForm.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgOrderForm.Size = new System.Drawing.Size(824, 270);
            this.dgOrderForm.TabIndex = 128;
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
            this.cShip.HeaderText = "Received";
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
            this.btCustomer.Location = new System.Drawing.Point(283, 71);
            this.btCustomer.Name = "btCustomer";
            this.btCustomer.Size = new System.Drawing.Size(22, 21);
            this.btCustomer.TabIndex = 127;
            this.btCustomer.Text = "..";
            this.btCustomer.UseVisualStyleBackColor = true;
            // 
            // cbCustomer
            // 
            this.cbCustomer.Enabled = false;
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(160, 70);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(117, 21);
            this.cbCustomer.TabIndex = 115;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 126;
            this.label7.Text = "Order Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 125;
            this.label5.Text = "Actual Ship Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 124;
            this.label4.Text = "Desired Ship Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 123;
            this.label3.Text = "Customer PO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 122;
            this.label2.Text = "Customer ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 121;
            this.label1.Text = "Order ID";
            // 
            // tbCustPO
            // 
            this.tbCustPO.Enabled = false;
            this.tbCustPO.Location = new System.Drawing.Point(160, 147);
            this.tbCustPO.Name = "tbCustPO";
            this.tbCustPO.Size = new System.Drawing.Size(145, 20);
            this.tbCustPO.TabIndex = 117;
            // 
            // tbOrderId
            // 
            this.tbOrderId.Location = new System.Drawing.Point(160, 44);
            this.tbOrderId.Name = "tbOrderId";
            this.tbOrderId.Size = new System.Drawing.Size(145, 20);
            this.tbOrderId.TabIndex = 114;
            this.tbOrderId.Leave += new System.EventHandler(this.tbOrderId_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.pbReports);
            this.panel2.Controls.Add(this.btReports);
            this.panel2.Controls.Add(this.pbSearch);
            this.panel2.Controls.Add(this.btSearch);
            this.panel2.Controls.Add(this.pbShip);
            this.panel2.Controls.Add(this.btReceive);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(865, 38);
            this.panel2.TabIndex = 143;
            // 
            // pbReports
            // 
            this.pbReports.BackColor = System.Drawing.Color.Transparent;
            this.pbReports.Image = global::NorthwestInventoryManager.Properties.Resources.reports_icon;
            this.pbReports.Location = new System.Drawing.Point(246, 6);
            this.pbReports.Name = "pbReports";
            this.pbReports.Size = new System.Drawing.Size(22, 24);
            this.pbReports.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReports.TabIndex = 91;
            this.pbReports.TabStop = false;
            this.pbReports.Click += new System.EventHandler(this.pbReports_Click);
            this.pbReports.MouseLeave += new System.EventHandler(this.pbReports_MouseLeave);
            this.pbReports.MouseHover += new System.EventHandler(this.pbReports_MouseHover);
            // 
            // btReports
            // 
            this.btReports.BackColor = System.Drawing.SystemColors.Control;
            this.btReports.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btReports.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReports.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReports.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btReports.Location = new System.Drawing.Point(238, 2);
            this.btReports.Name = "btReports";
            this.btReports.Size = new System.Drawing.Size(182, 34);
            this.btReports.TabIndex = 90;
            this.btReports.Text = "Order Reciept";
            this.btReports.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btReports.UseVisualStyleBackColor = false;
            this.btReports.Click += new System.EventHandler(this.btReports_Click);
            this.btReports.MouseLeave += new System.EventHandler(this.btReceive_MouseLeave);
            this.btReports.MouseHover += new System.EventHandler(this.btReceive_MouseHover);
            // 
            // pbSearch
            // 
            this.pbSearch.BackColor = System.Drawing.Color.Transparent;
            this.pbSearch.Image = global::NorthwestInventoryManager.Properties.Resources.find_icon;
            this.pbSearch.Location = new System.Drawing.Point(136, 6);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(22, 25);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSearch.TabIndex = 89;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            this.pbSearch.MouseLeave += new System.EventHandler(this.pbSearch_MouseLeave);
            this.pbSearch.MouseHover += new System.EventHandler(this.pbSearch_MouseHover);
            // 
            // btSearch
            // 
            this.btSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSearch.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btSearch.Location = new System.Drawing.Point(131, 2);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(105, 34);
            this.btSearch.TabIndex = 88;
            this.btSearch.Text = "Search";
            this.btSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            this.btSearch.MouseLeave += new System.EventHandler(this.btReceive_MouseLeave);
            this.btSearch.MouseHover += new System.EventHandler(this.btReceive_MouseHover);
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
            this.pbShip.MouseLeave += new System.EventHandler(this.pbShip_MouseLeave);
            this.pbShip.MouseHover += new System.EventHandler(this.pbShip_MouseHover);
            // 
            // btReceive
            // 
            this.btReceive.BackColor = System.Drawing.SystemColors.Control;
            this.btReceive.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btReceive.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReceive.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReceive.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btReceive.Location = new System.Drawing.Point(1, 2);
            this.btReceive.Name = "btReceive";
            this.btReceive.Size = new System.Drawing.Size(127, 34);
            this.btReceive.TabIndex = 84;
            this.btReceive.Text = "Receive";
            this.btReceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btReceive.UseVisualStyleBackColor = false;
            this.btReceive.Click += new System.EventHandler(this.btReceive_Click);
            this.btReceive.MouseLeave += new System.EventHandler(this.btReceive_MouseLeave);
            this.btReceive.MouseHover += new System.EventHandler(this.btReceive_MouseHover);
            // 
            // fmPOReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 521);
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
            this.Name = "fmPOReceipt";
            this.Text = "Purchase Order Receipt";
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderForm)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbStatus;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbReports;
        private System.Windows.Forms.Button btReports;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.PictureBox pbShip;
        private System.Windows.Forms.Button btReceive;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn cQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn cShip;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBackorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPST;
    }
}