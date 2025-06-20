﻿namespace CarDealershipFinal
{
    partial class frmCarListings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarListings));
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cboFilterBy = new System.Windows.Forms.ComboBox();
            this.rchListings = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(304, 38);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(87, 23);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "&Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(304, 84);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(87, 23);
            this.btnViewAll.TabIndex = 3;
            this.btnViewAll.Text = "&View All";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(304, 152);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(87, 23);
            this.btnUpload.TabIndex = 5;
            this.btnUpload.Text = "&Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Visible = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(304, 186);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(304, 254);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cboFilterBy
            // 
            this.cboFilterBy.FormattingEnabled = true;
            this.cboFilterBy.Location = new System.Drawing.Point(83, 40);
            this.cboFilterBy.Name = "cboFilterBy";
            this.cboFilterBy.Size = new System.Drawing.Size(204, 21);
            this.cboFilterBy.TabIndex = 1;
            // 
            // rchListings
            // 
            this.rchListings.Location = new System.Drawing.Point(37, 84);
            this.rchListings.Name = "rchListings";
            this.rchListings.ReadOnly = true;
            this.rchListings.Size = new System.Drawing.Size(250, 166);
            this.rchListings.TabIndex = 3;
            this.rchListings.TabStop = false;
            this.rchListings.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(304, 220);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(87, 23);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "&Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(304, 118);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(87, 23);
            this.btnAdmin.TabIndex = 4;
            this.btnAdmin.Text = "Admin Controls";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Visible = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Location = new System.Drawing.Point(34, 9);
            this.lblGreeting.MaximumSize = new System.Drawing.Size(1280, 32);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(149, 13);
            this.lblGreeting.TabIndex = 11;
            this.lblGreeting.Text = "Hello, Guest                            ";
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Location = new System.Drawing.Point(37, 256);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(75, 23);
            this.btnFirstPage.TabIndex = 8;
            this.btnFirstPage.Text = "First Page";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Location = new System.Drawing.Point(212, 256);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(75, 23);
            this.btnLastPage.TabIndex = 11;
            this.btnLastPage.Text = "Last Page";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Location = new System.Drawing.Point(127, 256);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(29, 23);
            this.btnPreviousPage.TabIndex = 9;
            this.btnPreviousPage.Text = "<";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(171, 256);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(26, 23);
            this.btnNextPage.TabIndex = 10;
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // frmCarListings
            // 
            this.AcceptButton = this.btnViewAll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(416, 303);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.btnLastPage);
            this.Controls.Add(this.btnFirstPage);
            this.Controls.Add(this.lblGreeting);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rchListings);
            this.Controls.Add(this.cboFilterBy);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.btnFilter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCarListings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listings";
            this.Load += new System.EventHandler(this.frmCarListings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cboFilterBy;
        private System.Windows.Forms.RichTextBox rchListings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnNextPage;
    }
}

