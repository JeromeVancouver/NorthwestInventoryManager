namespace NorthwestInventoryManager
{
    partial class fmNewTruck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmNewTruck));
            this.btCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.cbCarrier = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(125, 71);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(174, 23);
            this.btCreate.TabIndex = 3;
            this.btCreate.Text = "Create Truck";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Shipper";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Truck Description";
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(111, 13);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(278, 20);
            this.tbDesc.TabIndex = 1;
            // 
            // cbCarrier
            // 
            this.cbCarrier.FormattingEnabled = true;
            this.cbCarrier.Location = new System.Drawing.Point(111, 38);
            this.cbCarrier.Name = "cbCarrier";
            this.cbCarrier.Size = new System.Drawing.Size(146, 21);
            this.cbCarrier.TabIndex = 2;
            // 
            // fmNewTruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 107);
            this.Controls.Add(this.cbCarrier);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDesc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmNewTruck";
            this.Text = "fmNewTruck";
            this.Load += new System.EventHandler(this.fmNewTruck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.ComboBox cbCarrier;
    }
}