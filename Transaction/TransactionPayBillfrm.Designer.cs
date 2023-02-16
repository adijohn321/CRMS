
namespace CAPSTONEPROJ.Transaction
{
    partial class TransactionPayBillfrm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataTablePane = new System.Windows.Forms.Panel();
            this.dataTableInvoice = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnproceed = new System.Windows.Forms.Button();
            this.txtdiscount = new System.Windows.Forms.ComboBox();
            this.txtchange = new System.Windows.Forms.TextBox();
            this.txtamounttender = new System.Windows.Forms.TextBox();
            this.txttotalamount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsearchInvoice = new System.Windows.Forms.TextBox();
            this.txtdiscountedtotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.dataTablePane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableInvoice)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Pink;
            this.panel2.Controls.Add(this.dataTablePane);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnproceed);
            this.panel2.Controls.Add(this.txtdiscount);
            this.panel2.Controls.Add(this.txtchange);
            this.panel2.Controls.Add(this.txtamounttender);
            this.panel2.Controls.Add(this.txttotalamount);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtsearchInvoice);
            this.panel2.Controls.Add(this.txtdiscountedtotal);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(8, 96);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8);
            this.panel2.Size = new System.Drawing.Size(527, 444);
            this.panel2.TabIndex = 0;
            // 
            // dataTablePane
            // 
            this.dataTablePane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataTablePane.AutoSize = true;
            this.dataTablePane.BackColor = System.Drawing.Color.SeaGreen;
            this.dataTablePane.Controls.Add(this.dataTableInvoice);
            this.dataTablePane.Font = new System.Drawing.Font("Arial", 9F);
            this.dataTablePane.Location = new System.Drawing.Point(92, 102);
            this.dataTablePane.MaximumSize = new System.Drawing.Size(343, 200);
            this.dataTablePane.Name = "dataTablePane";
            this.dataTablePane.Size = new System.Drawing.Size(327, 194);
            this.dataTablePane.TabIndex = 125;
            this.dataTablePane.Visible = false;
            // 
            // dataTableInvoice
            // 
            this.dataTableInvoice.AllowUserToAddRows = false;
            this.dataTableInvoice.AllowUserToDeleteRows = false;
            this.dataTableInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataTableInvoice.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dataTableInvoice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataTableInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableInvoice.ColumnHeadersVisible = false;
            this.dataTableInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableInvoice.Location = new System.Drawing.Point(0, 0);
            this.dataTableInvoice.Name = "dataTableInvoice";
            this.dataTableInvoice.ReadOnly = true;
            this.dataTableInvoice.RowHeadersVisible = false;
            this.dataTableInvoice.RowHeadersWidth = 62;
            this.dataTableInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataTableInvoice.Size = new System.Drawing.Size(327, 194);
            this.dataTableInvoice.TabIndex = 21;
            this.dataTableInvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableInvoice_CellClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(207, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 68);
            this.button1.TabIndex = 130;
            this.button1.Text = "Proceed";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnproceed
            // 
            this.btnproceed.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnproceed.Enabled = false;
            this.btnproceed.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproceed.Location = new System.Drawing.Point(321, 338);
            this.btnproceed.Name = "btnproceed";
            this.btnproceed.Size = new System.Drawing.Size(98, 68);
            this.btnproceed.TabIndex = 130;
            this.btnproceed.Text = "Proceed";
            this.btnproceed.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnproceed.UseVisualStyleBackColor = false;
            this.btnproceed.Click += new System.EventHandler(this.btnproceed_Click);
            // 
            // txtdiscount
            // 
            this.txtdiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtdiscount.Font = new System.Drawing.Font("Arial", 10F);
            this.txtdiscount.FormattingEnabled = true;
            this.txtdiscount.Location = new System.Drawing.Point(218, 194);
            this.txtdiscount.Name = "txtdiscount";
            this.txtdiscount.Size = new System.Drawing.Size(202, 24);
            this.txtdiscount.TabIndex = 129;
            this.txtdiscount.SelectedIndexChanged += new System.EventHandler(this.txtdiscount_SelectedIndexChanged);
            // 
            // txtchange
            // 
            this.txtchange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtchange.Font = new System.Drawing.Font("Arial", 10F);
            this.txtchange.Location = new System.Drawing.Point(218, 292);
            this.txtchange.Name = "txtchange";
            this.txtchange.Size = new System.Drawing.Size(202, 23);
            this.txtchange.TabIndex = 126;
            // 
            // txtamounttender
            // 
            this.txtamounttender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtamounttender.Font = new System.Drawing.Font("Arial", 10F);
            this.txtamounttender.Location = new System.Drawing.Point(218, 259);
            this.txtamounttender.Name = "txtamounttender";
            this.txtamounttender.Size = new System.Drawing.Size(202, 23);
            this.txtamounttender.TabIndex = 119;
            this.txtamounttender.TextChanged += new System.EventHandler(this.txtamounttender_TextChanged);
            this.txtamounttender.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtamounttender_KeyDown);
            this.txtamounttender.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtamounttender_KeyPress);
            this.txtamounttender.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtamounttender_KeyUp);
            // 
            // txttotalamount
            // 
            this.txttotalamount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotalamount.Font = new System.Drawing.Font("Arial", 10F);
            this.txttotalamount.Location = new System.Drawing.Point(218, 159);
            this.txttotalamount.Name = "txttotalamount";
            this.txttotalamount.Size = new System.Drawing.Size(202, 23);
            this.txttotalamount.TabIndex = 128;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(90, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 120;
            this.label5.Text = "Change:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 121;
            this.label4.Text = "Amount Tender:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 122;
            this.label3.Text = "Discount:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 123;
            this.label1.Text = "Total Amount:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 16);
            this.label2.TabIndex = 124;
            this.label2.Text = "Search (Name or Invoice):";
            // 
            // txtsearchInvoice
            // 
            this.txtsearchInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsearchInvoice.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchInvoice.Location = new System.Drawing.Point(93, 77);
            this.txtsearchInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.txtsearchInvoice.Name = "txtsearchInvoice";
            this.txtsearchInvoice.Size = new System.Drawing.Size(327, 23);
            this.txtsearchInvoice.TabIndex = 127;
            // 
            // txtdiscountedtotal
            // 
            this.txtdiscountedtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdiscountedtotal.Font = new System.Drawing.Font("Arial", 10F);
            this.txtdiscountedtotal.Location = new System.Drawing.Point(219, 228);
            this.txtdiscountedtotal.Name = "txtdiscountedtotal";
            this.txtdiscountedtotal.Size = new System.Drawing.Size(202, 23);
            this.txtdiscountedtotal.TabIndex = 131;
            this.txtdiscountedtotal.TextChanged += new System.EventHandler(this.txtdiscountedtotal_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(89, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 16);
            this.label7.TabIndex = 132;
            this.label7.Text = "Discounted total:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumPurple;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(527, 88);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label6.Location = new System.Drawing.Point(205, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 29);
            this.label6.TabIndex = 2;
            this.label6.Text = "Pay Bill";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label8.Location = new System.Drawing.Point(485, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 29);
            this.label8.TabIndex = 3;
            this.label8.Text = "X";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // TransactionPayBillfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(543, 548);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TransactionPayBillfrm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransactionPayBillfrm_FormClosing);
            this.Load += new System.EventHandler(this.TransactionPayBillfrm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.dataTablePane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableInvoice)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel dataTablePane;
        public System.Windows.Forms.DataGridView dataTableInvoice;
        private System.Windows.Forms.ComboBox txtdiscount;
        private System.Windows.Forms.TextBox txtchange;
        private System.Windows.Forms.TextBox txtamounttender;
        private System.Windows.Forms.TextBox txttotalamount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsearchInvoice;
        private System.Windows.Forms.Button btnproceed;
        private System.Windows.Forms.TextBox txtdiscountedtotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
    }
}