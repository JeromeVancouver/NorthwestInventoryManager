namespace NorthwestInventoryManager
{
    partial class fmPartHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmPartHistory));
            this.label11 = new System.Windows.Forms.Label();
            this.cbPart = new System.Windows.Forms.ComboBox();
            this.dgHistory = new System.Windows.Forms.DataGridView();
            this.cDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSpecs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 20);
            this.label11.TabIndex = 107;
            this.label11.Text = "Part ID";
            // 
            // cbPart
            // 
            this.cbPart.FormattingEnabled = true;
            this.cbPart.Location = new System.Drawing.Point(78, 9);
            this.cbPart.Name = "cbPart";
            this.cbPart.Size = new System.Drawing.Size(263, 21);
            this.cbPart.TabIndex = 108;
            this.cbPart.SelectedIndexChanged += new System.EventHandler(this.cbPart_SelectedIndexChanged);
            this.cbPart.Leave += new System.EventHandler(this.cbPart_Leave);
            // 
            // dgHistory
            // 
            this.dgHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDate,
            this.cQty,
            this.cSpecs,
            this.cUser});
            this.dgHistory.Location = new System.Drawing.Point(16, 47);
            this.dgHistory.Name = "dgHistory";
            this.dgHistory.Size = new System.Drawing.Size(644, 503);
            this.dgHistory.TabIndex = 109;
            // 
            // cDate
            // 
            this.cDate.HeaderText = "Date dd/mm/yyyy";
            this.cDate.Name = "cDate";
            this.cDate.Width = 150;
            // 
            // cQty
            // 
            this.cQty.HeaderText = "Quantity";
            this.cQty.Name = "cQty";
            // 
            // cSpecs
            // 
            this.cSpecs.HeaderText = "Specs";
            this.cSpecs.Name = "cSpecs";
            this.cSpecs.Width = 200;
            // 
            // cUser
            // 
            this.cUser.HeaderText = "User";
            this.cUser.Name = "cUser";
            this.cUser.Width = 150;
            // 
            // fmPartHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 562);
            this.Controls.Add(this.dgHistory);
            this.Controls.Add(this.cbPart);
            this.Controls.Add(this.label11);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmPartHistory";
            this.Text = "Part History";
            this.Load += new System.EventHandler(this.fmPartHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbPart;
        private System.Windows.Forms.DataGridView dgHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSpecs;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUser;
    }
}