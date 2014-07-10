namespace NorthwestInventoryManager
{
    partial class fmNewPart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmNewPart));
            this.btCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCustID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCustName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(123, 70);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(174, 23);
            this.btCreate.TabIndex = 3;
            this.btCreate.Text = "Create Part and Close";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Description";
            // 
            // tbCustID
            // 
            this.tbCustID.Location = new System.Drawing.Point(104, 19);
            this.tbCustID.Name = "tbCustID";
            this.tbCustID.Size = new System.Drawing.Size(278, 20);
            this.tbCustID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Part ID";
            // 
            // tbCustName
            // 
            this.tbCustName.Location = new System.Drawing.Point(104, 45);
            this.tbCustName.Name = "tbCustName";
            this.tbCustName.Size = new System.Drawing.Size(278, 20);
            this.tbCustName.TabIndex = 2;
            // 
            // fmNewPart
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
            this.Name = "fmNewPart";
            this.Text = "Create New Part";
            this.Load += new System.EventHandler(this.fmNewPart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCustID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCustName;
    }
}