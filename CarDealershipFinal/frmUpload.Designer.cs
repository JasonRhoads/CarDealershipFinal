namespace CarDealershipFinal
{
    partial class frmUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpload));
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboMake = new System.Windows.Forms.ComboBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lblMake = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblVaring = new System.Windows.Forms.Label();
            this.txtVaring = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(33, 275);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "&Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(149, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboMake
            // 
            this.cboMake.FormattingEnabled = true;
            this.cboMake.Items.AddRange(new object[] {
            "BMW",
            "Ford",
            "Honda",
            "Toyota"});
            this.cboMake.Location = new System.Drawing.Point(103, 31);
            this.cboMake.Name = "cboMake";
            this.cboMake.Size = new System.Drawing.Size(121, 21);
            this.cboMake.TabIndex = 1;
            this.cboMake.Tag = "Make";
            this.cboMake.SelectedIndexChanged += new System.EventHandler(this.cboMake_SelectedIndexChanged);
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(103, 152);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(121, 20);
            this.txtColor.TabIndex = 4;
            this.txtColor.Tag = "Color";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(103, 112);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(121, 20);
            this.txtAge.TabIndex = 3;
            this.txtAge.Tag = "Year";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(103, 192);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(121, 20);
            this.txtPrice.TabIndex = 5;
            this.txtPrice.Tag = "Price";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(103, 72);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(121, 20);
            this.txtModel.TabIndex = 2;
            this.txtModel.Tag = "Model";
            // 
            // lblMake
            // 
            this.lblMake.AutoSize = true;
            this.lblMake.Location = new System.Drawing.Point(29, 34);
            this.lblMake.Name = "lblMake";
            this.lblMake.Size = new System.Drawing.Size(37, 13);
            this.lblMake.TabIndex = 0;
            this.lblMake.Text = "Make:";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(29, 75);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(39, 13);
            this.lblModel.TabIndex = 8;
            this.lblModel.Text = "Model:";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(30, 115);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(29, 13);
            this.lblAge.TabIndex = 9;
            this.lblAge.Text = "Age:";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(30, 155);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(34, 13);
            this.lblColor.TabIndex = 10;
            this.lblColor.Text = "Color:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(30, 195);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 11;
            this.lblPrice.Text = "Price:";
            // 
            // lblVaring
            // 
            this.lblVaring.AutoSize = true;
            this.lblVaring.Location = new System.Drawing.Point(30, 235);
            this.lblVaring.Name = "lblVaring";
            this.lblVaring.Size = new System.Drawing.Size(43, 13);
            this.lblVaring.TabIndex = 12;
            this.lblVaring.Text = "Engine:";
            // 
            // txtVaring
            // 
            this.txtVaring.Location = new System.Drawing.Point(103, 232);
            this.txtVaring.Name = "txtVaring";
            this.txtVaring.Size = new System.Drawing.Size(121, 20);
            this.txtVaring.TabIndex = 6;
            this.txtVaring.Tag = "Variable";
            // 
            // frmUpload
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(254, 327);
            this.Controls.Add(this.txtVaring);
            this.Controls.Add(this.lblVaring);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.lblMake);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.cboMake);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUpload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Upload Car";
            this.Load += new System.EventHandler(this.frmUpload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboMake;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblMake;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblVaring;
        private System.Windows.Forms.TextBox txtVaring;
    }
}