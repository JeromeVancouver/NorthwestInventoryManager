namespace NorthwestInventoryManager
{
    partial class fmNewCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmNewCustomer));
            this.tbCustName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCustID = new System.Windows.Forms.TextBox();
            this.btCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbCustName
            // 
            this.tbCustName.Location = new System.Drawing.Point(100, 12);
            this.tbCustName.MaxLength = 50;
            this.tbCustName.Name = "tbCustName";
            this.tbCustName.Size = new System.Drawing.Size(278, 20);
            this.tbCustName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Customer ID";
            // 
            // tbCustID
            // 
            this.tbCustID.Location = new System.Drawing.Point(100, 38);
            this.tbCustID.MaxLength = 6;
            this.tbCustID.Name = "tbCustID";
            this.tbCustID.Size = new System.Drawing.Size(89, 20);
            this.tbCustID.TabIndex = 2;
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(123, 70);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(174, 23);
            this.btCreate.TabIndex = 4;
            this.btCreate.Text = "Create Customer";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // fmNewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 107);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCustID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCustName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmNewCustomer";
            this.Text = "Customer Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCustName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCustID;
        private System.Windows.Forms.Button btCreate;
    }
}