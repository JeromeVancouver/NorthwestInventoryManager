namespace NorthwestInventoryManager
{
    partial class fmContact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmContact));
            this.lbOwner = new System.Windows.Forms.Label();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.btSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbOwner
            // 
            this.lbOwner.AutoSize = true;
            this.lbOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOwner.Location = new System.Drawing.Point(12, 9);
            this.lbOwner.Name = "lbOwner";
            this.lbOwner.Size = new System.Drawing.Size(150, 20);
            this.lbOwner.TabIndex = 57;
            this.lbOwner.Text = "Owner ID: CLEWAT";
            // 
            // cbName
            // 
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point(153, 49);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(242, 21);
            this.cbName.TabIndex = 56;
            this.cbName.Text = "CLEWAT";
            this.cbName.Leave += new System.EventHandler(this.cbName_Leave);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(204, 163);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(142, 23);
            this.btSave.TabIndex = 55;
            this.btSave.Text = "Save and Close";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 54;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 51;
            this.label5.Text = "Contact Phone #";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "Contact Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 49;
            this.label3.Text = "Contact Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 48;
            this.label1.Text = "Contact Name";
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(153, 127);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(244, 20);
            this.tbPhone.TabIndex = 47;
            this.tbPhone.Text = "Canada";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(153, 101);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(244, 20);
            this.tbEmail.TabIndex = 44;
            this.tbEmail.Text = "Langley";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(153, 75);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(244, 20);
            this.tbTitle.TabIndex = 43;
            this.tbTitle.Text = "#205 - 26596 Gloucester Way";
            // 
            // fmContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 200);
            this.Controls.Add(this.lbOwner);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmContact";
            this.Text = "Contact Information";
            this.Load += new System.EventHandler(this.fmContact_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbOwner;
        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbTitle;
    }
}