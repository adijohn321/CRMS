
namespace CAPSTONEPROJ.Transaction
{
    partial class TransactionInpatientsfrm
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
            this.rdChildren = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDelivery = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btngiveMedicine = new System.Windows.Forms.Button();
            this.btnPrintBill = new System.Windows.Forms.Button();
            this.btndischarge = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnapgarscore = new System.Windows.Forms.Button();
            this.btnamstleinc = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.notecontent = new System.Windows.Forms.Label();
            this.searchResult = new System.Windows.Forms.Label();
            this.dots = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewAdmittedPatient = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.rdChildren.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmittedPatient)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdChildren
            // 
            this.rdChildren.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rdChildren.Controls.Add(this.label2);
            this.rdChildren.Controls.Add(this.txtsearch);
            this.rdChildren.Location = new System.Drawing.Point(8, 66);
            this.rdChildren.Margin = new System.Windows.Forms.Padding(2);
            this.rdChildren.Name = "rdChildren";
            this.rdChildren.Size = new System.Drawing.Size(1227, 68);
            this.rdChildren.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Search Name:";
            // 
            // txtsearch
            // 
            this.txtsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsearch.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.Location = new System.Drawing.Point(6, 34);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(506, 23);
            this.txtsearch.TabIndex = 5;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Pink;
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.tableLayoutPanel4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dataGridViewAdmittedPatient);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(8, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1227, 666);
            this.panel2.TabIndex = 20;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDelivery);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox3.Location = new System.Drawing.Point(1066, 356);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(141, 104);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Applied to Mother Patient Only";
            // 
            // btnDelivery
            // 
            this.btnDelivery.BackColor = System.Drawing.Color.Pink;
            this.btnDelivery.Enabled = false;
            this.btnDelivery.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelivery.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDelivery.Location = new System.Drawing.Point(25, 38);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(98, 59);
            this.btnDelivery.TabIndex = 21;
            this.btnDelivery.Text = "Delivery Information";
            this.btnDelivery.UseVisualStyleBackColor = false;
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btngiveMedicine);
            this.groupBox2.Controls.Add(this.btnPrintBill);
            this.groupBox2.Controls.Add(this.btndischarge);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox2.Location = new System.Drawing.Point(1066, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 231);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Applied to All";
            // 
            // btngiveMedicine
            // 
            this.btngiveMedicine.BackColor = System.Drawing.Color.Pink;
            this.btngiveMedicine.Enabled = false;
            this.btngiveMedicine.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold);
            this.btngiveMedicine.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btngiveMedicine.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btngiveMedicine.Location = new System.Drawing.Point(25, 25);
            this.btngiveMedicine.Name = "btngiveMedicine";
            this.btngiveMedicine.Size = new System.Drawing.Size(98, 59);
            this.btngiveMedicine.TabIndex = 21;
            this.btngiveMedicine.Text = "Charge Patient";
            this.btngiveMedicine.UseVisualStyleBackColor = false;
            this.btngiveMedicine.Click += new System.EventHandler(this.btngiveMedicine_Click);
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.BackColor = System.Drawing.Color.Pink;
            this.btnPrintBill.Enabled = false;
            this.btnPrintBill.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBill.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPrintBill.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnPrintBill.Location = new System.Drawing.Point(25, 90);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(98, 59);
            this.btnPrintBill.TabIndex = 21;
            this.btnPrintBill.Text = "Print Bill";
            this.btnPrintBill.UseVisualStyleBackColor = false;
            this.btnPrintBill.Click += new System.EventHandler(this.btndischarge_Click);
            // 
            // btndischarge
            // 
            this.btndischarge.BackColor = System.Drawing.Color.Pink;
            this.btndischarge.Enabled = false;
            this.btndischarge.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndischarge.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btndischarge.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btndischarge.Location = new System.Drawing.Point(25, 155);
            this.btndischarge.Name = "btndischarge";
            this.btndischarge.Size = new System.Drawing.Size(98, 59);
            this.btndischarge.TabIndex = 21;
            this.btndischarge.Text = "Discharge";
            this.btndischarge.UseVisualStyleBackColor = false;
            this.btndischarge.Click += new System.EventHandler(this.btndischarge_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnapgarscore);
            this.groupBox1.Controls.Add(this.btnamstleinc);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Location = new System.Drawing.Point(1066, 466);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 176);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Applied to Newborn Patient Only";
            // 
            // btnapgarscore
            // 
            this.btnapgarscore.BackColor = System.Drawing.Color.Pink;
            this.btnapgarscore.Enabled = false;
            this.btnapgarscore.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnapgarscore.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnapgarscore.Location = new System.Drawing.Point(25, 38);
            this.btnapgarscore.Name = "btnapgarscore";
            this.btnapgarscore.Size = new System.Drawing.Size(98, 59);
            this.btnapgarscore.TabIndex = 21;
            this.btnapgarscore.Text = "APGAR Score";
            this.btnapgarscore.UseVisualStyleBackColor = false;
            this.btnapgarscore.Click += new System.EventHandler(this.btnapgarscore_Click);
            // 
            // btnamstleinc
            // 
            this.btnamstleinc.BackColor = System.Drawing.Color.Pink;
            this.btnamstleinc.Enabled = false;
            this.btnamstleinc.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnamstleinc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnamstleinc.Location = new System.Drawing.Point(25, 103);
            this.btnamstleinc.Name = "btnamstleinc";
            this.btnamstleinc.Size = new System.Drawing.Size(98, 59);
            this.btnamstleinc.TabIndex = 25;
            this.btnamstleinc.Text = "AMSTL and EINC";
            this.btnamstleinc.UseVisualStyleBackColor = false;
            this.btnamstleinc.Click += new System.EventHandler(this.btnamstleinc_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.notecontent, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.searchResult, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.dots, 3, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(8, 15);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(414, 25);
            this.tableLayoutPanel4.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Total List :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notecontent
            // 
            this.notecontent.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.notecontent.AutoSize = true;
            this.notecontent.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notecontent.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.notecontent.Location = new System.Drawing.Point(231, 3);
            this.notecontent.Name = "notecontent";
            this.notecontent.Size = new System.Drawing.Size(40, 18);
            this.notecontent.TabIndex = 21;
            this.notecontent.Text = "0001";
            this.notecontent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // searchResult
            // 
            this.searchResult.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.searchResult.AutoSize = true;
            this.searchResult.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchResult.Location = new System.Drawing.Point(312, 3);
            this.searchResult.Name = "searchResult";
            this.searchResult.Size = new System.Drawing.Size(40, 18);
            this.searchResult.TabIndex = 21;
            this.searchResult.Text = "0001";
            this.searchResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchResult.Visible = false;
            // 
            // dots
            // 
            this.dots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dots.AutoSize = true;
            this.dots.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dots.Location = new System.Drawing.Point(277, 3);
            this.dots.Name = "dots";
            this.dots.Size = new System.Drawing.Size(29, 18);
            this.dots.TabIndex = 22;
            this.dots.Text = ":";
            this.dots.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dots.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(635, 629);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 18);
            this.label3.TabIndex = 23;
            // 
            // dataGridViewAdmittedPatient
            // 
            this.dataGridViewAdmittedPatient.AllowUserToAddRows = false;
            this.dataGridViewAdmittedPatient.AllowUserToDeleteRows = false;
            this.dataGridViewAdmittedPatient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAdmittedPatient.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dataGridViewAdmittedPatient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewAdmittedPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdmittedPatient.Location = new System.Drawing.Point(8, 59);
            this.dataGridViewAdmittedPatient.Name = "dataGridViewAdmittedPatient";
            this.dataGridViewAdmittedPatient.ReadOnly = true;
            this.dataGridViewAdmittedPatient.RowHeadersWidth = 62;
            this.dataGridViewAdmittedPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAdmittedPatient.Size = new System.Drawing.Size(1007, 588);
            this.dataGridViewAdmittedPatient.TabIndex = 24;
            this.dataGridViewAdmittedPatient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAdmittedPatient_CellClick);
            this.dataGridViewAdmittedPatient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAdmittedPatient_CellContentClick);
            this.dataGridViewAdmittedPatient.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewAdmittedPatient_RowPostPaint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.MediumPurple;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1227, 53);
            this.tableLayoutPanel1.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label4.Location = new System.Drawing.Point(2, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1223, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "IN-PATIENT";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // TransactionInpatientsfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1243, 813);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rdChildren);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TransactionInpatientsfrm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransactionInpatientsfrm_FormClosing);
            this.Load += new System.EventHandler(this.TransactionInpatientsfrm_Load);
            this.Shown += new System.EventHandler(this.TransactionInpatientsfrm_Shown);
            this.rdChildren.ResumeLayout(false);
            this.rdChildren.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmittedPatient)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel rdChildren;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btndischarge;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dataGridViewAdmittedPatient;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label notecontent;
        private System.Windows.Forms.Label searchResult;
        private System.Windows.Forms.Label dots;
        private System.Windows.Forms.Button btngiveMedicine;
        private System.Windows.Forms.Button btnPrintBill;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnapgarscore;
        private System.Windows.Forms.Button btnamstleinc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDelivery;
        public System.Windows.Forms.TextBox txtsearch;
    }
}