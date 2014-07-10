namespace NorthwestInventoryManager
{
    partial class fmAddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmAddress));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.tbPCode = new System.Windows.Forms.TextBox();
            this.tbProvince = new System.Windows.Forms.TextBox();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbContact = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbAddressId = new System.Windows.Forms.ComboBox();
            this.lbOwner = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Country";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "City, Province, Postal Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Street Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Address ID";
            // 
            // tbCountry
            // 
            this.tbCountry.Location = new System.Drawing.Point(209, 128);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(244, 20);
            this.tbCountry.TabIndex = 25;
            this.tbCountry.Text = "Canada";
            // 
            // tbPCode
            // 
            this.tbPCode.Location = new System.Drawing.Point(397, 102);
            this.tbPCode.Name = "tbPCode";
            this.tbPCode.Size = new System.Drawing.Size(56, 20);
            this.tbPCode.TabIndex = 24;
            this.tbPCode.Text = "V4W 4A8";
            // 
            // tbProvince
            // 
            this.tbProvince.Location = new System.Drawing.Point(332, 102);
            this.tbProvince.Name = "tbProvince";
            this.tbProvince.Size = new System.Drawing.Size(59, 20);
            this.tbProvince.TabIndex = 23;
            this.tbProvince.Text = "BC";
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(209, 102);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(117, 20);
            this.tbCity.TabIndex = 22;
            this.tbCity.Text = "Langley";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(209, 76);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(244, 20);
            this.tbAddress.TabIndex = 21;
            this.tbAddress.Text = "#205 - 26596 Gloucester Way";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "Contact";
            // 
            // tbContact
            // 
            this.tbContact.Location = new System.Drawing.Point(209, 154);
            this.tbContact.Multiline = true;
            this.tbContact.Name = "tbContact";
            this.tbContact.Size = new System.Drawing.Size(244, 65);
            this.tbContact.TabIndex = 32;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(249, 242);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(142, 23);
            this.btSave.TabIndex = 39;
            this.btSave.Text = "Save and Close";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbAddressId
            // 
            this.cbAddressId.FormattingEnabled = true;
            this.cbAddressId.Location = new System.Drawing.Point(209, 50);
            this.cbAddressId.Name = "cbAddressId";
            this.cbAddressId.Size = new System.Drawing.Size(117, 21);
            this.cbAddressId.TabIndex = 40;
            this.cbAddressId.Text = "CLEWAT";
            this.cbAddressId.SelectedIndexChanged += new System.EventHandler(this.cbAddressId_SelectedIndexChanged);
            // 
            // lbOwner
            // 
            this.lbOwner.AutoSize = true;
            this.lbOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOwner.Location = new System.Drawing.Point(6, 10);
            this.lbOwner.Name = "lbOwner";
            this.lbOwner.Size = new System.Drawing.Size(150, 20);
            this.lbOwner.TabIndex = 42;
            this.lbOwner.Text = "Owner ID: CLEWAT";
            // 
            // fmAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 273);
            this.Controls.Add(this.lbOwner);
            this.Controls.Add(this.cbAddressId);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbContact);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCountry);
            this.Controls.Add(this.tbPCode);
            this.Controls.Add(this.tbProvince);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.tbAddress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Address Setup";
            this.Load += new System.EventHandler(this.fmAddress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.TextBox tbPCode;
        private System.Windows.Forms.TextBox tbProvince;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbContact;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbAddressId;
        private System.Windows.Forms.Label lbOwner;
    }
}