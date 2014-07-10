namespace NorthwestInventoryManager
{
    partial class fmAdjustment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmAdjustment));
            this.tbPartID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCode = new System.Windows.Forms.ComboBox();
            this.dgAdjustment = new System.Windows.Forms.DataGridView();
            this.cPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAdjustment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btCommit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgAdjustment)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPartID
            // 
            this.tbPartID.Location = new System.Drawing.Point(124, 9);
            this.tbPartID.Name = "tbPartID";
            this.tbPartID.Size = new System.Drawing.Size(262, 20);
            this.tbPartID.TabIndex = 0;
            this.tbPartID.Leave += new System.EventHandler(this.tbPartID_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 91;
            this.label2.Text = "Part ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 93;
            this.label1.Text = "Reason Code";
            // 
            // cbCode
            // 
            this.cbCode.FormattingEnabled = true;
            this.cbCode.Items.AddRange(new object[] {
            "Loss / Shrinkage",
            "Damaged",
            "Cycle Count Adjustment",
            "Quarintine"});
            this.cbCode.Location = new System.Drawing.Point(123, 61);
            this.cbCode.Name = "cbCode";
            this.cbCode.Size = new System.Drawing.Size(261, 21);
            this.cbCode.TabIndex = 3;
            // 
            // dgAdjustment
            // 
            this.dgAdjustment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAdjustment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cPID,
            this.cDescription,
            this.cAdjustment,
            this.cReason});
            this.dgAdjustment.Location = new System.Drawing.Point(12, 129);
            this.dgAdjustment.Name = "dgAdjustment";
            this.dgAdjustment.Size = new System.Drawing.Size(532, 159);
            this.dgAdjustment.TabIndex = 95;
            this.dgAdjustment.TabStop = false;
            // 
            // cPID
            // 
            this.cPID.HeaderText = "Part ID";
            this.cPID.Name = "cPID";
            this.cPID.Width = 150;
            // 
            // cDescription
            // 
            this.cDescription.HeaderText = "Description";
            this.cDescription.Name = "cDescription";
            this.cDescription.Width = 175;
            // 
            // cAdjustment
            // 
            this.cAdjustment.HeaderText = "Adj";
            this.cAdjustment.Name = "cAdjustment";
            this.cAdjustment.Width = 50;
            // 
            // cReason
            // 
            this.cReason.HeaderText = "Reason";
            this.cReason.Name = "cReason";
            this.cReason.Width = 150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 97;
            this.label3.Text = "Quantity";
            // 
            // tbQty
            // 
            this.tbQty.Location = new System.Drawing.Point(123, 35);
            this.tbQty.Name = "tbQty";
            this.tbQty.Size = new System.Drawing.Size(70, 20);
            this.tbQty.TabIndex = 1;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(12, 100);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(122, 23);
            this.btAdd.TabIndex = 4;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btCommit
            // 
            this.btCommit.Location = new System.Drawing.Point(140, 100);
            this.btCommit.Name = "btCommit";
            this.btCommit.Size = new System.Drawing.Size(122, 23);
            this.btCommit.TabIndex = 5;
            this.btCommit.Text = "Commit";
            this.btCommit.UseVisualStyleBackColor = true;
            this.btCommit.Click += new System.EventHandler(this.btCommit_Click);
            // 
            // fmAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 300);
            this.Controls.Add(this.btCommit);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbQty);
            this.Controls.Add(this.dgAdjustment);
            this.Controls.Add(this.cbCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPartID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmAdjustment";
            this.Text = "Stock Adjustment";
            ((System.ComponentModel.ISupportInitialize)(this.dgAdjustment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPartID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCode;
        private System.Windows.Forms.DataGridView dgAdjustment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbQty;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAdjustment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReason;
        private System.Windows.Forms.Button btCommit;
    }
}