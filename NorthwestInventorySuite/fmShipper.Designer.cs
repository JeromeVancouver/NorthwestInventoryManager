namespace NorthwestInventoryManager
{
    partial class fmCarrier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmCarrier));
            this.cbCarrier = new System.Windows.Forms.ComboBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbContact = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.tbPostalCode = new System.Windows.Forms.TextBox();
            this.tbProvince = new System.Windows.Forms.TextBox();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbCName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbCarrier
            // 
            this.cbCarrier.FormattingEnabled = true;
            this.cbCarrier.Location = new System.Drawing.Point(211, 12);
            this.cbCarrier.Name = "cbCarrier";
            this.cbCarrier.Size = new System.Drawing.Size(117, 21);
            this.cbCarrier.TabIndex = 56;
            this.cbCarrier.Text = "SAPCOU";
            this.cbCarrier.SelectedIndexChanged += new System.EventHandler(this.cbCarrier_SelectedIndexChanged);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(251, 244);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(142, 23);
            this.btSave.TabIndex = 55;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(82, 244);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(142, 23);
            this.btCancel.TabIndex = 54;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 53;
            this.label7.Text = "Contact";
            // 
            // tbContact
            // 
            this.tbContact.Location = new System.Drawing.Point(211, 173);
            this.tbContact.Multiline = true;
            this.tbContact.Name = "tbContact";
            this.tbContact.Size = new System.Drawing.Size(244, 65);
            this.tbContact.TabIndex = 52;
            this.tbContact.Text = "Sean - 778-822-6141";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 51;
            this.label5.Text = "Country";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "City, Province, Postal Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 49;
            this.label3.Text = "Street Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 48;
            this.label2.Text = "Carrier Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "Carrier ID";
            // 
            // tbCountry
            // 
            this.tbCountry.Location = new System.Drawing.Point(211, 147);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(244, 20);
            this.tbCountry.TabIndex = 46;
            this.tbCountry.Text = "Canada";
            // 
            // tbPostalCode
            // 
            this.tbPostalCode.Location = new System.Drawing.Point(399, 121);
            this.tbPostalCode.Name = "tbPostalCode";
            this.tbPostalCode.Size = new System.Drawing.Size(56, 20);
            this.tbPostalCode.TabIndex = 45;
            this.tbPostalCode.Text = "V2W 5T7";
            // 
            // tbProvince
            // 
            this.tbProvince.Location = new System.Drawing.Point(334, 121);
            this.tbProvince.Name = "tbProvince";
            this.tbProvince.Size = new System.Drawing.Size(59, 20);
            this.tbProvince.TabIndex = 44;
            this.tbProvince.Text = "BC";
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(211, 121);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(117, 20);
            this.tbCity.TabIndex = 43;
            this.tbCity.Text = "Surrey";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(211, 95);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(244, 20);
            this.tbAddress.TabIndex = 42;
            this.tbAddress.Text = "12242";
            // 
            // tbCName
            // 
            this.tbCName.Location = new System.Drawing.Point(211, 69);
            this.tbCName.Name = "tbCName";
            this.tbCName.Size = new System.Drawing.Size(244, 20);
            this.tbCName.TabIndex = 41;
            this.tbCName.Text = "SAP Courier";
            // 
            // fmCarrier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 287);
            this.Controls.Add(this.cbCarrier);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbContact);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCountry);
            this.Controls.Add(this.tbPostalCode);
            this.Controls.Add(this.tbProvince);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.tbCName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmCarrier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carrier Setup";
            this.Load += new System.EventHandler(this.fmCarrier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCarrier;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.TextBox tbPostalCode;
        private System.Windows.Forms.TextBox tbProvince;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbCName;
    }
}