namespace NorthwestInventoryManager
{
    partial class fmSubstitution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmSubstitution));
            this.btCommit = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.tbUsedQty = new System.Windows.Forms.TextBox();
            this.dgAdjustment = new System.Windows.Forms.DataGridView();
            this.cPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAdjustment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUsedPart = new System.Windows.Forms.TextBox();
            this.tbSubQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSubPart = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRefNum = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgAdjustment)).BeginInit();
            this.SuspendLayout();
            // 
            // btCommit
            // 
            this.btCommit.Location = new System.Drawing.Point(142, 96);
            this.btCommit.Name = "btCommit";
            this.btCommit.Size = new System.Drawing.Size(122, 23);
            this.btCommit.TabIndex = 7;
            this.btCommit.Text = "Commit";
            this.btCommit.UseVisualStyleBackColor = true;
            this.btCommit.Click += new System.EventHandler(this.btCommit_Click);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(14, 96);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(122, 23);
            this.btAdd.TabIndex = 6;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // tbUsedQty
            // 
            this.tbUsedQty.Location = new System.Drawing.Point(411, 5);
            this.tbUsedQty.Name = "tbUsedQty";
            this.tbUsedQty.Size = new System.Drawing.Size(70, 20);
            this.tbUsedQty.TabIndex = 2;
            // 
            // dgAdjustment
            // 
            this.dgAdjustment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAdjustment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cPID,
            this.cDescription,
            this.cAdjustment,
            this.cReason});
            this.dgAdjustment.Location = new System.Drawing.Point(14, 125);
            this.dgAdjustment.Name = "dgAdjustment";
            this.dgAdjustment.Size = new System.Drawing.Size(532, 159);
            this.dgAdjustment.TabIndex = 105;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 103;
            this.label2.Text = "Used Part";
            // 
            // tbUsedPart
            // 
            this.tbUsedPart.Location = new System.Drawing.Point(143, 5);
            this.tbUsedPart.Name = "tbUsedPart";
            this.tbUsedPart.Size = new System.Drawing.Size(262, 20);
            this.tbUsedPart.TabIndex = 1;
            this.tbUsedPart.Leave += new System.EventHandler(this.tbUsedPart_Leave);
            // 
            // tbSubQty
            // 
            this.tbSubQty.Location = new System.Drawing.Point(411, 31);
            this.tbSubQty.Name = "tbSubQty";
            this.tbSubQty.Size = new System.Drawing.Size(70, 20);
            this.tbSubQty.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 108;
            this.label1.Text = "Substituted Part";
            // 
            // tbSubPart
            // 
            this.tbSubPart.Location = new System.Drawing.Point(143, 31);
            this.tbSubPart.Name = "tbSubPart";
            this.tbSubPart.Size = new System.Drawing.Size(262, 20);
            this.tbSubPart.TabIndex = 3;
            this.tbSubPart.Leave += new System.EventHandler(this.tbSubPart_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 110;
            this.label3.Text = "Order ID";
            // 
            // tbRefNum
            // 
            this.tbRefNum.Location = new System.Drawing.Point(143, 57);
            this.tbRefNum.Name = "tbRefNum";
            this.tbRefNum.Size = new System.Drawing.Size(111, 20);
            this.tbRefNum.TabIndex = 5;
            // 
            // fmSubstitution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 289);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbRefNum);
            this.Controls.Add(this.tbSubQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSubPart);
            this.Controls.Add(this.btCommit);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.tbUsedQty);
            this.Controls.Add(this.dgAdjustment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbUsedPart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmSubstitution";
            this.Text = "Inventory Substitution";
            ((System.ComponentModel.ISupportInitialize)(this.dgAdjustment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCommit;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.TextBox tbUsedQty;
        private System.Windows.Forms.DataGridView dgAdjustment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAdjustment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUsedPart;
        private System.Windows.Forms.TextBox tbSubQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSubPart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRefNum;
    }
}