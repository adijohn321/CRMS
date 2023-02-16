
namespace CAPSTONEPROJ.Transaction
{
    partial class AMSTLandEINC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AMSTLandEINC));
            this.label15 = new System.Windows.Forms.Label();
            this.lblIDNo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbleinc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.eincBox = new System.Windows.Forms.CheckedListBox();
            this.lblamstl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.appearanceBox = new System.Windows.Forms.GroupBox();
            this.amstlbox = new System.Windows.Forms.CheckedListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.appearanceBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(98, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 16);
            this.label15.TabIndex = 82;
            this.label15.Text = "Patient ID No:";
            // 
            // lblIDNo
            // 
            this.lblIDNo.AutoSize = true;
            this.lblIDNo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDNo.Location = new System.Drawing.Point(201, 80);
            this.lblIDNo.Name = "lblIDNo";
            this.lblIDNo.Size = new System.Drawing.Size(69, 16);
            this.lblIDNo.TabIndex = 80;
            this.lblIDNo.Text = "CONTENT";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(447, 80);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(69, 16);
            this.lblName.TabIndex = 81;
            this.lblName.Text = "CONTENT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(344, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 16);
            this.label8.TabIndex = 83;
            this.label8.Text = "Patient Name:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(42, 513);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "EINC:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbleinc
            // 
            this.lbleinc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbleinc.AutoSize = true;
            this.lbleinc.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbleinc.ForeColor = System.Drawing.Color.Blue;
            this.lbleinc.Location = new System.Drawing.Point(208, 513);
            this.lbleinc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbleinc.Name = "lbleinc";
            this.lbleinc.Size = new System.Drawing.Size(22, 24);
            this.lbleinc.TabIndex = 49;
            this.lbleinc.Text = "0";
            this.lbleinc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Pink;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lblIDNo);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblamstl);
            this.panel1.Controls.Add(this.lbleinc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.appearanceBox);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 789);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.eincBox);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(46, 349);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 137);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Essential Intrapartum Newborn Care (EINC)";
            // 
            // eincBox
            // 
            this.eincBox.BackColor = System.Drawing.Color.Pink;
            this.eincBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eincBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eincBox.FormattingEnabled = true;
            this.eincBox.Items.AddRange(new object[] {
            "Immediate and thorough rying of baby.",
            "Early-skin-to-skin contact between mother and the newborn",
            "Properly-timed cord clamping",
            "Non-separation of the mother and baby for early breastfeeding initiation."});
            this.eincBox.Location = new System.Drawing.Point(7, 32);
            this.eincBox.Name = "eincBox";
            this.eincBox.Size = new System.Drawing.Size(519, 84);
            this.eincBox.TabIndex = 0;
            this.eincBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.eincBox_ItemCheck_1);
            this.eincBox.Click += new System.EventHandler(this.eincBox_Click);
            this.eincBox.SelectedIndexChanged += new System.EventHandler(this.eincBox_SelectedIndexChanged_1);
            this.eincBox.DoubleClick += new System.EventHandler(this.eincBox_DoubleClick);
            // 
            // lblamstl
            // 
            this.lblamstl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblamstl.AutoSize = true;
            this.lblamstl.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblamstl.ForeColor = System.Drawing.Color.Blue;
            this.lblamstl.Location = new System.Drawing.Point(215, 292);
            this.lblamstl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblamstl.Name = "lblamstl";
            this.lblamstl.Size = new System.Drawing.Size(22, 24);
            this.lblamstl.TabIndex = 49;
            this.lblamstl.Text = "0";
            this.lblamstl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(49, 292);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "AMSTL: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // appearanceBox
            // 
            this.appearanceBox.Controls.Add(this.amstlbox);
            this.appearanceBox.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appearanceBox.Location = new System.Drawing.Point(46, 166);
            this.appearanceBox.Name = "appearanceBox";
            this.appearanceBox.Size = new System.Drawing.Size(620, 111);
            this.appearanceBox.TabIndex = 48;
            this.appearanceBox.TabStop = false;
            this.appearanceBox.Text = "Active Management of the 3rd stage of labor (AMSTL)";
            // 
            // amstlbox
            // 
            this.amstlbox.BackColor = System.Drawing.Color.Pink;
            this.amstlbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.amstlbox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amstlbox.FormattingEnabled = true;
            this.amstlbox.Items.AddRange(new object[] {
            "Prophylactic administration of oxytocin.",
            "Clamping and cutting of umbilical cord.",
            "Immediately after delivery of the baby and controlled cord traction."});
            this.amstlbox.Location = new System.Drawing.Point(7, 32);
            this.amstlbox.Name = "amstlbox";
            this.amstlbox.Size = new System.Drawing.Size(484, 63);
            this.amstlbox.TabIndex = 0;
            this.amstlbox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.amstlbox_ItemCheck);
            this.amstlbox.Click += new System.EventHandler(this.amstlbox_Click);
            this.amstlbox.DoubleClick += new System.EventHandler(this.amstlbox_DoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(570, 707);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 49);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Orchid;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(682, 48);
            this.panel2.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.MediumPurple;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnclose, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(680, 46);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(617, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "AMSTL and EINC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.AutoSize = true;
            this.btnclose.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.LavenderBlush;
            this.btnclose.Location = new System.Drawing.Point(623, 8);
            this.btnclose.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(55, 29);
            this.btnclose.TabIndex = 0;
            this.btnclose.Text = "X";
            this.btnclose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // AMSTLandEINC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(698, 805);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AMSTLandEINC";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AMSTLandEINC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AMSTLandEINC_FormClosing);
            this.Load += new System.EventHandler(this.AMSTLandEINC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.appearanceBox.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label lblIDNo;
        public System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbleinc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox appearanceBox;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label btnclose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox eincBox;
        private System.Windows.Forms.CheckedListBox amstlbox;
        private System.Windows.Forms.Label lblamstl;
        private System.Windows.Forms.Label label2;
    }
}