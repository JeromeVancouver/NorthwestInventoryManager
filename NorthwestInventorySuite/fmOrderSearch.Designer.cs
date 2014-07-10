namespace NorthwestInventoryManager
{
    partial class fmOrderSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmOrderSearch));
            this.tbOrderId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPO = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCustId = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.dgOrders = new System.Windows.Forms.DataGridView();
            this.cOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cShipTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cShip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.cbTDef = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // tbOrderId
            // 
            this.tbOrderId.Location = new System.Drawing.Point(100, 19);
            this.tbOrderId.Name = "tbOrderId";
            this.tbOrderId.Size = new System.Drawing.Size(227, 20);
            this.tbOrderId.TabIndex = 0;
            this.tbOrderId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bCustId_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Order ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Purchase Order";
            // 
            // tbPO
            // 
            this.tbPO.Location = new System.Drawing.Point(100, 45);
            this.tbPO.Name = "tbPO";
            this.tbPO.Size = new System.Drawing.Size(227, 20);
            this.tbPO.TabIndex = 1;
            this.tbPO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bCustId_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Customer ID";
            // 
            // tbCustId
            // 
            this.tbCustId.Location = new System.Drawing.Point(100, 71);
            this.tbCustId.Name = "tbCustId";
            this.tbCustId.Size = new System.Drawing.Size(227, 20);
            this.tbCustId.TabIndex = 2;
            this.tbCustId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bCustId_KeyPress);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(388, 104);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(148, 23);
            this.btSearch.TabIndex = 8;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // dgOrders
            // 
            this.dgOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cOrder,
            this.cState,
            this.cCust,
            this.cShipTo,
            this.cPO,
            this.cTotal,
            this.cDate,
            this.cShip,
            this.cNotes});
            this.dgOrders.Location = new System.Drawing.Point(16, 133);
            this.dgOrders.Name = "dgOrders";
            this.dgOrders.Size = new System.Drawing.Size(1038, 399);
            this.dgOrders.TabIndex = 7;
            this.dgOrders.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOrders_CellContentDoubleClick);
            this.dgOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOrders_CellDoubleClick);
            // 
            // cOrder
            // 
            this.cOrder.HeaderText = "Order ID";
            this.cOrder.Name = "cOrder";
            // 
            // cState
            // 
            this.cState.HeaderText = "State";
            this.cState.Name = "cState";
            this.cState.Width = 80;
            // 
            // cCust
            // 
            this.cCust.HeaderText = "Customer ID";
            this.cCust.Name = "cCust";
            this.cCust.Width = 80;
            // 
            // cShipTo
            // 
            this.cShipTo.HeaderText = "ShipTo ID";
            this.cShipTo.Name = "cShipTo";
            this.cShipTo.Width = 80;
            // 
            // cPO
            // 
            this.cPO.HeaderText = "Purchase Order";
            this.cPO.Name = "cPO";
            this.cPO.Width = 80;
            // 
            // cTotal
            // 
            this.cTotal.HeaderText = "Order Total";
            this.cTotal.Name = "cTotal";
            // 
            // cDate
            // 
            this.cDate.HeaderText = "Order Date";
            this.cDate.Name = "cDate";
            // 
            // cShip
            // 
            this.cShip.HeaderText = "Desired Ship";
            this.cShip.Name = "cShip";
            // 
            // cNotes
            // 
            this.cNotes.HeaderText = "Notes";
            this.cNotes.Name = "cNotes";
            this.cNotes.Width = 300;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "State";
            // 
            // cbState
            // 
            this.cbState.FormattingEnabled = true;
            this.cbState.Items.AddRange(new object[] {
            "%",
            "Firmed",
            "Released",
            "Quoted",
            "On Hold",
            "Cancelled",
            "Shipped"});
            this.cbState.Location = new System.Drawing.Point(100, 97);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(227, 21);
            this.cbState.TabIndex = 3;
            this.cbState.Text = "%";
            this.cbState.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bCustId_KeyPress);
            // 
            // cbTDef
            // 
            this.cbTDef.FormattingEnabled = true;
            this.cbTDef.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<="});
            this.cbTDef.Location = new System.Drawing.Point(447, 23);
            this.cbTDef.Name = "cbTDef";
            this.cbTDef.Size = new System.Drawing.Size(42, 21);
            this.cbTDef.TabIndex = 4;
            this.cbTDef.Text = ">";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(385, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Total";
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(495, 23);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(145, 20);
            this.tbTotal.TabIndex = 5;
            this.tbTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bCustId_KeyPress);
            // 
            // dtFromDate
            // 
            this.dtFromDate.Location = new System.Drawing.Point(447, 52);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(193, 20);
            this.dtFromDate.TabIndex = 6;
            this.dtFromDate.Value = new System.DateTime(2013, 3, 6, 13, 53, 0, 0);
            this.dtFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bCustId_KeyPress);
            // 
            // dtToDate
            // 
            this.dtToDate.Location = new System.Drawing.Point(447, 78);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(193, 20);
            this.dtToDate.TabIndex = 7;
            this.dtToDate.Value = new System.DateTime(2014, 3, 6, 13, 55, 22, 0);
            this.dtToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bCustId_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(385, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "From Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "To Date";
            // 
            // fmOrderSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 541);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbTDef);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgOrders);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCustId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOrderId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmOrderSearch";
            this.Text = "Order Search";
            this.Load += new System.EventHandler(this.fmOrderSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOrderId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCustId;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.DataGridView dgOrders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.ComboBox cbTDef;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn cState;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCust;
        private System.Windows.Forms.DataGridViewTextBoxColumn cShipTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cShip;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNotes;
    }
}