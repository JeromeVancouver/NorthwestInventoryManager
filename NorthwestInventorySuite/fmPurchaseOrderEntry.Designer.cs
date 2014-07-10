namespace NorthwestInventoryManager
{
    partial class fmPurchaseOrderEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmPurchaseOrderEntry));
            this.cbStatus = new System.Windows.Forms.ComboBox();
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
            this.btVendor = new System.Windows.Forms.Button();
            this.cbVendor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbVendorPO = new System.Windows.Forms.TextBox();
            this.tbOrderId = new System.Windows.Forms.TextBox();
            this.dtActualShip = new System.Windows.Forms.DateTimePicker();
            this.dtDesiredShip = new System.Windows.Forms.DateTimePicker();
            this.dtOrderDate = new System.Windows.Forms.DateTimePicker();
            this.btDelete = new System.Windows.Forms.Button();
            this.btAddLine = new System.Windows.Forms.Button();
            this.dgOrderForm = new System.Windows.Forms.DataGridView();
            this.cLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cVendorPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbDeleteOrder = new System.Windows.Forms.PictureBox();
            this.btDeleteOrder = new System.Windows.Forms.Button();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.pbSend = new System.Windows.Forms.PictureBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btSend = new System.Windows.Forms.Button();
            this.btReportsDropDown = new System.Windows.Forms.Button();
            this.pbReports = new System.Windows.Forms.PictureBox();
            this.btReports = new System.Windows.Forms.Button();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.pbNew = new System.Windows.Forms.PictureBox();
            this.btNew = new System.Windows.Forms.Button();
            this.btReceiving = new System.Windows.Forms.Button();
            this.btPurchaseOrder = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tbDiscount = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.chPST = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.chGST = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderForm)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeleteOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNew)).BeginInit();
            this.SuspendLayout();
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(428, 47);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(189, 21);
            this.cbStatus.TabIndex = 8;
            this.cbStatus.Text = "Released";
            // 
            // tbFOB
            // 
            this.tbFOB.Location = new System.Drawing.Point(428, 74);
            this.tbFOB.Name = "tbFOB";
            this.tbFOB.Size = new System.Drawing.Size(189, 20);
            this.tbFOB.TabIndex = 9;
            // 
            // btShipTo
            // 
            this.btShipTo.Location = new System.Drawing.Point(285, 99);
            this.btShipTo.Name = "btShipTo";
            this.btShipTo.Size = new System.Drawing.Size(22, 21);
            this.btShipTo.TabIndex = 101;
            this.btShipTo.Text = "..";
            this.btShipTo.UseVisualStyleBackColor = true;
            this.btShipTo.Click += new System.EventHandler(this.btShipTo_Click);
            // 
            // cbShipTo
            // 
            this.cbShipTo.FormattingEnabled = true;
            this.cbShipTo.Location = new System.Drawing.Point(162, 98);
            this.cbShipTo.Name = "cbShipTo";
            this.cbShipTo.Size = new System.Drawing.Size(117, 21);
            this.cbShipTo.TabIndex = 3;
            this.cbShipTo.Text = "CLEWAT";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 20);
            this.label11.TabIndex = 99;
            this.label11.Text = "ShipTo ID";
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(428, 130);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(189, 97);
            this.tbNotes.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(345, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 97;
            this.label10.Text = "Notes";
            // 
            // btCarrier
            // 
            this.btCarrier.Location = new System.Drawing.Point(595, 99);
            this.btCarrier.Name = "btCarrier";
            this.btCarrier.Size = new System.Drawing.Size(22, 21);
            this.btCarrier.TabIndex = 96;
            this.btCarrier.Text = "..";
            this.btCarrier.UseVisualStyleBackColor = true;
            this.btCarrier.Click += new System.EventHandler(this.btCarrier_Click);
            // 
            // cbCarrier
            // 
            this.cbCarrier.FormattingEnabled = true;
            this.cbCarrier.Location = new System.Drawing.Point(428, 100);
            this.cbCarrier.Name = "cbCarrier";
            this.cbCarrier.Size = new System.Drawing.Size(161, 21);
            this.cbCarrier.TabIndex = 10;
            this.cbCarrier.Text = "ROLRIG";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(345, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.TabIndex = 94;
            this.label9.Text = "Carrier ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(345, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 93;
            this.label8.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(345, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 92;
            this.label6.Text = "FOB";
            // 
            // btVendor
            // 
            this.btVendor.Location = new System.Drawing.Point(285, 75);
            this.btVendor.Name = "btVendor";
            this.btVendor.Size = new System.Drawing.Size(22, 21);
            this.btVendor.TabIndex = 90;
            this.btVendor.Text = "..";
            this.btVendor.UseVisualStyleBackColor = true;
            this.btVendor.Click += new System.EventHandler(this.btVendor_Click);
            // 
            // cbVendor
            // 
            this.cbVendor.FormattingEnabled = true;
            this.cbVendor.Location = new System.Drawing.Point(162, 74);
            this.cbVendor.Name = "cbVendor";
            this.cbVendor.Size = new System.Drawing.Size(117, 21);
            this.cbVendor.TabIndex = 2;
            this.cbVendor.Text = "KINPRO";
            this.cbVendor.Leave += new System.EventHandler(this.cbVendor_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 86;
            this.label7.Text = "Order Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 84;
            this.label5.Text = "Actual Ship Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 83;
            this.label4.Text = "Desired Ship Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 82;
            this.label3.Text = "Vendor PO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 81;
            this.label2.Text = "Vendor ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 80;
            this.label1.Text = "Order ID";
            // 
            // tbVendorPO
            // 
            this.tbVendorPO.Location = new System.Drawing.Point(162, 151);
            this.tbVendorPO.Name = "tbVendorPO";
            this.tbVendorPO.Size = new System.Drawing.Size(145, 20);
            this.tbVendorPO.TabIndex = 5;
            this.tbVendorPO.Text = "162500";
            // 
            // tbOrderId
            // 
            this.tbOrderId.Location = new System.Drawing.Point(162, 48);
            this.tbOrderId.Name = "tbOrderId";
            this.tbOrderId.Size = new System.Drawing.Size(145, 20);
            this.tbOrderId.TabIndex = 1;
            this.tbOrderId.Leave += new System.EventHandler(this.tbOrderId_Leave);
            // 
            // dtActualShip
            // 
            this.dtActualShip.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtActualShip.Location = new System.Drawing.Point(162, 207);
            this.dtActualShip.Name = "dtActualShip";
            this.dtActualShip.Size = new System.Drawing.Size(145, 20);
            this.dtActualShip.TabIndex = 7;
            this.dtActualShip.Value = new System.DateTime(2013, 10, 15, 0, 0, 0, 0);
            // 
            // dtDesiredShip
            // 
            this.dtDesiredShip.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesiredShip.Location = new System.Drawing.Point(162, 180);
            this.dtDesiredShip.Name = "dtDesiredShip";
            this.dtDesiredShip.Size = new System.Drawing.Size(145, 20);
            this.dtDesiredShip.TabIndex = 6;
            this.dtDesiredShip.Value = new System.DateTime(2013, 10, 15, 0, 0, 0, 0);
            // 
            // dtOrderDate
            // 
            this.dtOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtOrderDate.Location = new System.Drawing.Point(162, 124);
            this.dtOrderDate.Name = "dtOrderDate";
            this.dtOrderDate.Size = new System.Drawing.Size(145, 20);
            this.dtOrderDate.TabIndex = 4;
            this.dtOrderDate.Value = new System.DateTime(2013, 10, 15, 0, 0, 0, 0);
            // 
            // btDelete
            // 
            this.btDelete.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.btDelete.Location = new System.Drawing.Point(662, 200);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(33, 34);
            this.btDelete.TabIndex = 109;
            this.btDelete.Text = "-";
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btAddLine
            // 
            this.btAddLine.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.btAddLine.Location = new System.Drawing.Point(623, 200);
            this.btAddLine.Name = "btAddLine";
            this.btAddLine.Size = new System.Drawing.Size(33, 34);
            this.btAddLine.TabIndex = 12;
            this.btAddLine.Text = "+";
            this.btAddLine.UseVisualStyleBackColor = true;
            this.btAddLine.Click += new System.EventHandler(this.btAddLine_Click);
            // 
            // dgOrderForm
            // 
            this.dgOrderForm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cLine,
            this.cPartId,
            this.cVendorPart,
            this.cDescription,
            this.cQuantity,
            this.cUnitPrice,
            this.cGST,
            this.cPST,
            this.cNotes});
            this.dgOrderForm.Location = new System.Drawing.Point(21, 240);
            this.dgOrderForm.Name = "dgOrderForm";
            this.dgOrderForm.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgOrderForm.Size = new System.Drawing.Size(824, 301);
            this.dgOrderForm.TabIndex = 110;
            this.dgOrderForm.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOrderForm_CellValueChanged);
            // 
            // cLine
            // 
            this.cLine.HeaderText = "Ln#";
            this.cLine.Name = "cLine";
            this.cLine.Width = 50;
            // 
            // cPartId
            // 
            this.cPartId.HeaderText = " Part ID";
            this.cPartId.Name = "cPartId";
            this.cPartId.Width = 200;
            // 
            // cVendorPart
            // 
            this.cVendorPart.HeaderText = "Vendor Part ID";
            this.cVendorPart.Name = "cVendorPart";
            this.cVendorPart.Width = 150;
            // 
            // cDescription
            // 
            this.cDescription.HeaderText = "Description";
            this.cDescription.Name = "cDescription";
            this.cDescription.Width = 250;
            // 
            // cQuantity
            // 
            this.cQuantity.HeaderText = "Quantity";
            this.cQuantity.Name = "cQuantity";
            this.cQuantity.Width = 75;
            // 
            // cUnitPrice
            // 
            this.cUnitPrice.HeaderText = "Unit Price";
            this.cUnitPrice.Name = "cUnitPrice";
            this.cUnitPrice.Width = 75;
            // 
            // cGST
            // 
            this.cGST.HeaderText = "GST";
            this.cGST.Name = "cGST";
            // 
            // cPST
            // 
            this.cPST.HeaderText = "PST";
            this.cPST.Name = "cPST";
            // 
            // cNotes
            // 
            this.cNotes.HeaderText = "Notes";
            this.cNotes.Name = "cNotes";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.pbDeleteOrder);
            this.panel2.Controls.Add(this.btDeleteOrder);
            this.panel2.Controls.Add(this.pbSave);
            this.panel2.Controls.Add(this.pbSend);
            this.panel2.Controls.Add(this.btSave);
            this.panel2.Controls.Add(this.btSend);
            this.panel2.Controls.Add(this.btReportsDropDown);
            this.panel2.Controls.Add(this.pbReports);
            this.panel2.Controls.Add(this.btReports);
            this.panel2.Controls.Add(this.pbSearch);
            this.panel2.Controls.Add(this.btSearch);
            this.panel2.Controls.Add(this.pbNew);
            this.panel2.Controls.Add(this.btNew);
            this.panel2.Location = new System.Drawing.Point(0, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(865, 38);
            this.panel2.TabIndex = 114;
            // 
            // pbDeleteOrder
            // 
            this.pbDeleteOrder.BackColor = System.Drawing.Color.Transparent;
            this.pbDeleteOrder.Image = global::NorthwestInventoryManager.Properties.Resources.delete_icon;
            this.pbDeleteOrder.Location = new System.Drawing.Point(612, 7);
            this.pbDeleteOrder.Name = "pbDeleteOrder";
            this.pbDeleteOrder.Size = new System.Drawing.Size(22, 24);
            this.pbDeleteOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeleteOrder.TabIndex = 101;
            this.pbDeleteOrder.TabStop = false;
            this.pbDeleteOrder.Click += new System.EventHandler(this.pbDeleteOrder_Click);
            this.pbDeleteOrder.MouseLeave += new System.EventHandler(this.pbDeleteOrder_MouseLeave);
            this.pbDeleteOrder.MouseHover += new System.EventHandler(this.pbDeleteOrder_MouseHover);
            // 
            // btDeleteOrder
            // 
            this.btDeleteOrder.BackColor = System.Drawing.SystemColors.Control;
            this.btDeleteOrder.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btDeleteOrder.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btDeleteOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDeleteOrder.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeleteOrder.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btDeleteOrder.Location = new System.Drawing.Point(604, 2);
            this.btDeleteOrder.Name = "btDeleteOrder";
            this.btDeleteOrder.Size = new System.Drawing.Size(113, 34);
            this.btDeleteOrder.TabIndex = 100;
            this.btDeleteOrder.Text = "Delete";
            this.btDeleteOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDeleteOrder.UseVisualStyleBackColor = false;
            this.btDeleteOrder.Click += new System.EventHandler(this.btDeleteOrder_Click);
            this.btDeleteOrder.MouseLeave += new System.EventHandler(this.btDeleteOrder_MouseLeave);
            this.btDeleteOrder.MouseHover += new System.EventHandler(this.btDeleteOrder_MouseHover);
            // 
            // pbSave
            // 
            this.pbSave.BackColor = System.Drawing.Color.Transparent;
            this.pbSave.Image = global::NorthwestInventoryManager.Properties.Resources.Save_icon;
            this.pbSave.Location = new System.Drawing.Point(517, 7);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(22, 24);
            this.pbSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSave.TabIndex = 99;
            this.pbSave.TabStop = false;
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            this.pbSave.MouseLeave += new System.EventHandler(this.pbSave_MouseLeave);
            this.pbSave.MouseHover += new System.EventHandler(this.pbSave_MouseHover);
            // 
            // pbSend
            // 
            this.pbSend.BackColor = System.Drawing.Color.Transparent;
            this.pbSend.Image = global::NorthwestInventoryManager.Properties.Resources.Email_icon;
            this.pbSend.Location = new System.Drawing.Point(384, 5);
            this.pbSend.Name = "pbSend";
            this.pbSend.Size = new System.Drawing.Size(22, 27);
            this.pbSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSend.TabIndex = 94;
            this.pbSend.TabStop = false;
            this.pbSend.Click += new System.EventHandler(this.pbSend_Click);
            this.pbSend.MouseLeave += new System.EventHandler(this.pbSend_MouseLeave);
            this.pbSend.MouseHover += new System.EventHandler(this.pbSend_MouseHover);
            // 
            // btSave
            // 
            this.btSave.BackColor = System.Drawing.SystemColors.Control;
            this.btSave.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btSave.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSave.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btSave.Location = new System.Drawing.Point(509, 2);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(93, 34);
            this.btSave.TabIndex = 98;
            this.btSave.Text = "Save";
            this.btSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            this.btSave.MouseLeave += new System.EventHandler(this.btDeleteOrder_MouseLeave);
            this.btSave.MouseHover += new System.EventHandler(this.btDeleteOrder_MouseHover);
            // 
            // btSend
            // 
            this.btSend.BackColor = System.Drawing.SystemColors.Control;
            this.btSend.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btSend.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSend.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSend.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btSend.Location = new System.Drawing.Point(376, 2);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(131, 34);
            this.btSend.TabIndex = 93;
            this.btSend.Text = "Send PO";
            this.btSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSend.UseVisualStyleBackColor = false;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            this.btSend.MouseLeave += new System.EventHandler(this.btDeleteOrder_MouseLeave);
            this.btSend.MouseHover += new System.EventHandler(this.btDeleteOrder_MouseHover);
            // 
            // btReportsDropDown
            // 
            this.btReportsDropDown.BackColor = System.Drawing.SystemColors.Control;
            this.btReportsDropDown.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btReportsDropDown.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btReportsDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReportsDropDown.Font = new System.Drawing.Font("Neuropol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReportsDropDown.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btReportsDropDown.Location = new System.Drawing.Point(349, 2);
            this.btReportsDropDown.Name = "btReportsDropDown";
            this.btReportsDropDown.Size = new System.Drawing.Size(25, 34);
            this.btReportsDropDown.TabIndex = 92;
            this.btReportsDropDown.Text = "v";
            this.btReportsDropDown.UseVisualStyleBackColor = false;
            this.btReportsDropDown.Click += new System.EventHandler(this.btReportsDropDown_Click);
            this.btReportsDropDown.MouseLeave += new System.EventHandler(this.btDeleteOrder_MouseLeave);
            this.btReportsDropDown.MouseHover += new System.EventHandler(this.btDeleteOrder_MouseHover);
            // 
            // pbReports
            // 
            this.pbReports.BackColor = System.Drawing.Color.Transparent;
            this.pbReports.Image = global::NorthwestInventoryManager.Properties.Resources.reports_icon;
            this.pbReports.Location = new System.Drawing.Point(239, 5);
            this.pbReports.Name = "pbReports";
            this.pbReports.Size = new System.Drawing.Size(22, 26);
            this.pbReports.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReports.TabIndex = 91;
            this.pbReports.TabStop = false;
            this.pbReports.Click += new System.EventHandler(this.btReportsDropDown_Click);
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
            this.btReports.Location = new System.Drawing.Point(231, 2);
            this.btReports.Name = "btReports";
            this.btReports.Size = new System.Drawing.Size(119, 34);
            this.btReports.TabIndex = 90;
            this.btReports.Text = "Reports";
            this.btReports.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btReports.UseVisualStyleBackColor = false;
            this.btReports.Click += new System.EventHandler(this.btReportsDropDown_Click);
            this.btReports.MouseLeave += new System.EventHandler(this.btDeleteOrder_MouseLeave);
            this.btReports.MouseHover += new System.EventHandler(this.btDeleteOrder_MouseHover);
            // 
            // pbSearch
            // 
            this.pbSearch.BackColor = System.Drawing.Color.Transparent;
            this.pbSearch.Image = global::NorthwestInventoryManager.Properties.Resources.find_icon;
            this.pbSearch.Location = new System.Drawing.Point(128, 6);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(22, 25);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSearch.TabIndex = 89;
            this.pbSearch.TabStop = false;
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
            this.btSearch.Location = new System.Drawing.Point(123, 2);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(105, 34);
            this.btSearch.TabIndex = 88;
            this.btSearch.Text = "Search";
            this.btSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            this.btSearch.MouseLeave += new System.EventHandler(this.btDeleteOrder_MouseLeave);
            this.btSearch.MouseHover += new System.EventHandler(this.btDeleteOrder_MouseHover);
            // 
            // pbNew
            // 
            this.pbNew.BackColor = System.Drawing.Color.Transparent;
            this.pbNew.Image = global::NorthwestInventoryManager.Properties.Resources.file_icon;
            this.pbNew.Location = new System.Drawing.Point(9, 4);
            this.pbNew.Name = "pbNew";
            this.pbNew.Size = new System.Drawing.Size(22, 27);
            this.pbNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNew.TabIndex = 85;
            this.pbNew.TabStop = false;
            this.pbNew.Click += new System.EventHandler(this.pbNew_Click);
            this.pbNew.MouseLeave += new System.EventHandler(this.pbNew_MouseLeave);
            this.pbNew.MouseHover += new System.EventHandler(this.pbNew_MouseHover);
            // 
            // btNew
            // 
            this.btNew.BackColor = System.Drawing.SystemColors.Control;
            this.btNew.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btNew.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNew.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNew.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btNew.Location = new System.Drawing.Point(1, 2);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(121, 34);
            this.btNew.TabIndex = 84;
            this.btNew.Text = "New PO";
            this.btNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btNew.UseVisualStyleBackColor = false;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            this.btNew.MouseLeave += new System.EventHandler(this.btDeleteOrder_MouseLeave);
            this.btNew.MouseHover += new System.EventHandler(this.btDeleteOrder_MouseHover);
            // 
            // btReceiving
            // 
            this.btReceiving.BackColor = System.Drawing.SystemColors.Control;
            this.btReceiving.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btReceiving.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btReceiving.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReceiving.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReceiving.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btReceiving.Location = new System.Drawing.Point(231, 67);
            this.btReceiving.Name = "btReceiving";
            this.btReceiving.Size = new System.Drawing.Size(175, 34);
            this.btReceiving.TabIndex = 116;
            this.btReceiving.Text = "Receiving";
            this.btReceiving.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReceiving.UseVisualStyleBackColor = false;
            this.btReceiving.Visible = false;
            this.btReceiving.Click += new System.EventHandler(this.btReceiving_Click);
            this.btReceiving.MouseLeave += new System.EventHandler(this.btDeleteOrder_MouseLeave);
            this.btReceiving.MouseHover += new System.EventHandler(this.btDeleteOrder_MouseHover);
            // 
            // btPurchaseOrder
            // 
            this.btPurchaseOrder.BackColor = System.Drawing.SystemColors.Control;
            this.btPurchaseOrder.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btPurchaseOrder.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btPurchaseOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPurchaseOrder.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPurchaseOrder.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btPurchaseOrder.Location = new System.Drawing.Point(231, 34);
            this.btPurchaseOrder.Name = "btPurchaseOrder";
            this.btPurchaseOrder.Size = new System.Drawing.Size(175, 34);
            this.btPurchaseOrder.TabIndex = 115;
            this.btPurchaseOrder.Text = "Purchase Order";
            this.btPurchaseOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPurchaseOrder.UseVisualStyleBackColor = false;
            this.btPurchaseOrder.Visible = false;
            this.btPurchaseOrder.Click += new System.EventHandler(this.btPurchaseOrder_Click);
            this.btPurchaseOrder.MouseLeave += new System.EventHandler(this.btDeleteOrder_MouseLeave);
            this.btPurchaseOrder.MouseHover += new System.EventHandler(this.btDeleteOrder_MouseHover);
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(651, 171);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(58, 29);
            this.label34.TabIndex = 124;
            this.label34.Text = "Remove Line";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(623, 170);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(35, 29);
            this.label33.TabIndex = 123;
            this.label33.Text = "Add Line";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(775, 199);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(63, 13);
            this.label32.TabIndex = 122;
            this.label32.Text = "DISCOUNT";
            // 
            // tbDiscount
            // 
            this.tbDiscount.Location = new System.Drawing.Point(769, 216);
            this.tbDiscount.Name = "tbDiscount";
            this.tbDiscount.Size = new System.Drawing.Size(74, 20);
            this.tbDiscount.TabIndex = 121;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(741, 199);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(28, 13);
            this.label27.TabIndex = 120;
            this.label27.Text = "PST";
            // 
            // chPST
            // 
            this.chPST.AutoSize = true;
            this.chPST.Location = new System.Drawing.Point(746, 219);
            this.chPST.Name = "chPST";
            this.chPST.Size = new System.Drawing.Size(15, 14);
            this.chPST.TabIndex = 119;
            this.chPST.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(706, 199);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 13);
            this.label26.TabIndex = 118;
            this.label26.Text = "GST";
            // 
            // chGST
            // 
            this.chGST.AutoSize = true;
            this.chGST.Location = new System.Drawing.Point(714, 219);
            this.chGST.Name = "chGST";
            this.chGST.Size = new System.Drawing.Size(15, 14);
            this.chGST.TabIndex = 117;
            this.chGST.UseVisualStyleBackColor = true;
            // 
            // fmPurchaseOrderEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 552);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.tbDiscount);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.chPST);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.chGST);
            this.Controls.Add(this.btReceiving);
            this.Controls.Add(this.btPurchaseOrder);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgOrderForm);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btAddLine);
            this.Controls.Add(this.dtActualShip);
            this.Controls.Add(this.dtDesiredShip);
            this.Controls.Add(this.dtOrderDate);
            this.Controls.Add(this.cbStatus);
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
            this.Controls.Add(this.btVendor);
            this.Controls.Add(this.cbVendor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbVendorPO);
            this.Controls.Add(this.tbOrderId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmPurchaseOrderEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order Entry";
            this.Load += new System.EventHandler(this.fmPurchaseOrderEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderForm)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDeleteOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNew)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbStatus;
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
        private System.Windows.Forms.Button btVendor;
        private System.Windows.Forms.ComboBox cbVendor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbVendorPO;
        private System.Windows.Forms.TextBox tbOrderId;
        private System.Windows.Forms.DateTimePicker dtActualShip;
        private System.Windows.Forms.DateTimePicker dtDesiredShip;
        private System.Windows.Forms.DateTimePicker dtOrderDate;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btAddLine;
        private System.Windows.Forms.DataGridView dgOrderForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cVendorPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn cQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPST;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNotes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbDeleteOrder;
        private System.Windows.Forms.Button btDeleteOrder;
        private System.Windows.Forms.PictureBox pbSave;
        private System.Windows.Forms.PictureBox pbSend;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btReportsDropDown;
        private System.Windows.Forms.PictureBox pbReports;
        private System.Windows.Forms.Button btReports;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.PictureBox pbNew;
        private System.Windows.Forms.Button btNew;
        private System.Windows.Forms.Button btReceiving;
        private System.Windows.Forms.Button btPurchaseOrder;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox tbDiscount;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox chPST;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox chGST;

    }
}