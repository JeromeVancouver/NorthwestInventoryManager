namespace NorthwestInventoryManager
{
    partial class fmTruckScheduler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmTruckScheduler));
            this.dgTruck = new System.Windows.Forms.DataGridView();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPallet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOrderLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTruckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTId = new System.Windows.Forms.TextBox();
            this.cbCarrier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbOrder = new System.Windows.Forms.TextBox();
            this.cbLine = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btLoadOrder = new System.Windows.Forms.Button();
            this.btLoadLine = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.cbPallet = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btLoadTruck = new System.Windows.Forms.Button();
            this.btLoadPallet = new System.Windows.Forms.Button();
            this.dgOrderLine = new System.Windows.Forms.DataGridView();
            this.cLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cQtyOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgTruck)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderLine)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTruck
            // 
            this.dgTruck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTruck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cID,
            this.cPallet,
            this.cPartId,
            this.cQty,
            this.cOrderId,
            this.cOrderLine});
            this.dgTruck.Location = new System.Drawing.Point(399, 34);
            this.dgTruck.Name = "dgTruck";
            this.dgTruck.Size = new System.Drawing.Size(612, 416);
            this.dgTruck.TabIndex = 1;
            this.dgTruck.TabStop = false;
            // 
            // cID
            // 
            this.cID.HeaderText = "ID";
            this.cID.Name = "cID";
            // 
            // cPallet
            // 
            this.cPallet.HeaderText = "Pallet";
            this.cPallet.Name = "cPallet";
            this.cPallet.Width = 50;
            // 
            // cPartId
            // 
            this.cPartId.HeaderText = "Part Id";
            this.cPartId.Name = "cPartId";
            this.cPartId.Width = 300;
            // 
            // cQty
            // 
            this.cQty.HeaderText = "Qty";
            this.cQty.Name = "cQty";
            this.cQty.Width = 50;
            // 
            // cOrderId
            // 
            this.cOrderId.HeaderText = "Order Id";
            this.cOrderId.Name = "cOrderId";
            // 
            // cOrderLine
            // 
            this.cOrderLine.HeaderText = "Order Line";
            this.cOrderLine.Name = "cOrderLine";
            this.cOrderLine.Width = 50;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1023, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTruckToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newTruckToolStripMenuItem
            // 
            this.newTruckToolStripMenuItem.Name = "newTruckToolStripMenuItem";
            this.newTruckToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.newTruckToolStripMenuItem.Text = "New Truck";
            this.newTruckToolStripMenuItem.Click += new System.EventHandler(this.newTruckToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printLabelsToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // printLabelsToolStripMenuItem
            // 
            this.printLabelsToolStripMenuItem.Name = "printLabelsToolStripMenuItem";
            this.printLabelsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.printLabelsToolStripMenuItem.Text = "Print Labels";
            this.printLabelsToolStripMenuItem.Click += new System.EventHandler(this.printLabelsToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Truck Description";
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(115, 121);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(278, 20);
            this.tbDesc.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Truck ID";
            // 
            // tbTId
            // 
            this.tbTId.Location = new System.Drawing.Point(115, 68);
            this.tbTId.Name = "tbTId";
            this.tbTId.Size = new System.Drawing.Size(100, 20);
            this.tbTId.TabIndex = 1;
            // 
            // cbCarrier
            // 
            this.cbCarrier.FormattingEnabled = true;
            this.cbCarrier.Location = new System.Drawing.Point(115, 147);
            this.cbCarrier.Name = "cbCarrier";
            this.cbCarrier.Size = new System.Drawing.Size(146, 21);
            this.cbCarrier.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Shipper";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Truck Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Load Truck";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Order Id";
            // 
            // tbOrder
            // 
            this.tbOrder.Location = new System.Drawing.Point(69, 218);
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.Size = new System.Drawing.Size(100, 20);
            this.tbOrder.TabIndex = 7;
            this.tbOrder.Leave += new System.EventHandler(this.tbOrder_Leave);
            // 
            // cbLine
            // 
            this.cbLine.FormattingEnabled = true;
            this.cbLine.Location = new System.Drawing.Point(69, 400);
            this.cbLine.Name = "cbLine";
            this.cbLine.Size = new System.Drawing.Size(62, 21);
            this.cbLine.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 403);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Line";
            // 
            // btLoadOrder
            // 
            this.btLoadOrder.Location = new System.Drawing.Point(175, 215);
            this.btLoadOrder.Name = "btLoadOrder";
            this.btLoadOrder.Size = new System.Drawing.Size(75, 23);
            this.btLoadOrder.TabIndex = 8;
            this.btLoadOrder.Text = "Load Order";
            this.btLoadOrder.UseVisualStyleBackColor = true;
            this.btLoadOrder.Click += new System.EventHandler(this.btLoadOrder_Click);
            // 
            // btLoadLine
            // 
            this.btLoadLine.Location = new System.Drawing.Point(186, 398);
            this.btLoadLine.Name = "btLoadLine";
            this.btLoadLine.Size = new System.Drawing.Size(75, 23);
            this.btLoadLine.TabIndex = 11;
            this.btLoadLine.Text = "Load Line";
            this.btLoadLine.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(21, 427);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 21;
            this.btSave.Text = "Save Truck";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // cbPallet
            // 
            this.cbPallet.FormattingEnabled = true;
            this.cbPallet.Location = new System.Drawing.Point(115, 94);
            this.cbPallet.Name = "cbPallet";
            this.cbPallet.Size = new System.Drawing.Size(100, 21);
            this.cbPallet.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Pallet";
            // 
            // btLoadTruck
            // 
            this.btLoadTruck.Location = new System.Drawing.Point(221, 65);
            this.btLoadTruck.Name = "btLoadTruck";
            this.btLoadTruck.Size = new System.Drawing.Size(75, 23);
            this.btLoadTruck.TabIndex = 2;
            this.btLoadTruck.Text = "Load Truck";
            this.btLoadTruck.UseVisualStyleBackColor = true;
            this.btLoadTruck.Click += new System.EventHandler(this.btLoadTruck_Click);
            // 
            // btLoadPallet
            // 
            this.btLoadPallet.Location = new System.Drawing.Point(221, 92);
            this.btLoadPallet.Name = "btLoadPallet";
            this.btLoadPallet.Size = new System.Drawing.Size(75, 23);
            this.btLoadPallet.TabIndex = 4;
            this.btLoadPallet.Text = "Load Pallet";
            this.btLoadPallet.UseVisualStyleBackColor = true;
            this.btLoadPallet.Click += new System.EventHandler(this.btLoadPallet_Click);
            // 
            // dgOrderLine
            // 
            this.dgOrderLine.AllowUserToOrderColumns = true;
            this.dgOrderLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrderLine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cLine,
            this.cPart,
            this.cQtyOrder});
            this.dgOrderLine.Location = new System.Drawing.Point(21, 244);
            this.dgOrderLine.Name = "dgOrderLine";
            this.dgOrderLine.Size = new System.Drawing.Size(372, 148);
            this.dgOrderLine.TabIndex = 26;
            this.dgOrderLine.TabStop = false;
            // 
            // cLine
            // 
            this.cLine.HeaderText = "Line";
            this.cLine.Name = "cLine";
            this.cLine.Width = 35;
            // 
            // cPart
            // 
            this.cPart.HeaderText = "Part";
            this.cPart.Name = "cPart";
            this.cPart.Width = 245;
            // 
            // cQtyOrder
            // 
            this.cQtyOrder.HeaderText = "Qty";
            this.cQtyOrder.Name = "cQtyOrder";
            this.cQtyOrder.Width = 48;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 401);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(43, 20);
            this.textBox1.TabIndex = 10;
            // 
            // fmTruckScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 462);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgOrderLine);
            this.Controls.Add(this.btLoadPallet);
            this.Controls.Add(this.btLoadTruck);
            this.Controls.Add(this.cbPallet);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btLoadLine);
            this.Controls.Add(this.btLoadOrder);
            this.Controls.Add(this.cbLine);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbOrder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCarrier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.dgTruck);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fmTruckScheduler";
            this.Text = "Truck Scheduler";
            ((System.ComponentModel.ISupportInitialize)(this.dgTruck)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTruck;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTruckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTId;
        private System.Windows.Forms.ComboBox cbCarrier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbOrder;
        private System.Windows.Forms.ComboBox cbLine;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btLoadOrder;
        private System.Windows.Forms.Button btLoadLine;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printLabelsToolStripMenuItem;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPallet;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOrderLine;
        private System.Windows.Forms.ComboBox cbPallet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btLoadTruck;
        private System.Windows.Forms.Button btLoadPallet;
        private System.Windows.Forms.DataGridView dgOrderLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn cQtyOrder;
        private System.Windows.Forms.TextBox textBox1;
    }
}