
namespace CAPSTONEPROJ.Transaction
{
    partial class Apgarscorefrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Apgarscorefrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblIDNo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.respirationBox = new System.Windows.Forms.GroupBox();
            this.txtrespiration = new System.Windows.Forms.TextBox();
            this.rdvigorous = new System.Windows.Forms.RadioButton();
            this.rdslowirreg = new System.Windows.Forms.RadioButton();
            this.rdabsentR = new System.Windows.Forms.RadioButton();
            this.activityBox = new System.Windows.Forms.GroupBox();
            this.txtactivity = new System.Windows.Forms.TextBox();
            this.rdactive = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.rdabsentA = new System.Windows.Forms.RadioButton();
            this.grimaceBox = new System.Windows.Forms.GroupBox();
            this.txtgrimace = new System.Windows.Forms.TextBox();
            this.rdcryactive = new System.Windows.Forms.RadioButton();
            this.rdGrimace = new System.Windows.Forms.RadioButton();
            this.rdFloppy = new System.Windows.Forms.RadioButton();
            this.pulseBox = new System.Windows.Forms.GroupBox();
            this.txtpulse = new System.Windows.Forms.TextBox();
            this.rdthan100 = new System.Windows.Forms.RadioButton();
            this.rdless100 = new System.Windows.Forms.RadioButton();
            this.rdabsentp = new System.Windows.Forms.RadioButton();
            this.appearanceBox = new System.Windows.Forms.GroupBox();
            this.txtAppearance = new System.Windows.Forms.TextBox();
            this.rdPink = new System.Windows.Forms.RadioButton();
            this.rdBlue = new System.Windows.Forms.RadioButton();
            this.rdPale = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.respirationBox.SuspendLayout();
            this.activityBox.SuspendLayout();
            this.grimaceBox.SuspendLayout();
            this.pulseBox.SuspendLayout();
            this.appearanceBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Pink;
            this.panel1.Controls.Add(this.lblIDNo);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.respirationBox);
            this.panel1.Controls.Add(this.activityBox);
            this.panel1.Controls.Add(this.grimaceBox);
            this.panel1.Controls.Add(this.pulseBox);
            this.panel1.Controls.Add(this.appearanceBox);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 740);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblIDNo
            // 
            this.lblIDNo.AutoSize = true;
            this.lblIDNo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDNo.Location = new System.Drawing.Point(201, 64);
            this.lblIDNo.Name = "lblIDNo";
            this.lblIDNo.Size = new System.Drawing.Size(69, 16);
            this.lblIDNo.TabIndex = 80;
            this.lblIDNo.Text = "CONTENT";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(447, 64);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(69, 16);
            this.lblName.TabIndex = 81;
            this.lblName.Text = "CONTENT";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(98, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 16);
            this.label15.TabIndex = 82;
            this.label15.Text = "Patient ID No:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(344, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 16);
            this.label8.TabIndex = 83;
            this.label8.Text = "Patient Name:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(427, 115);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 19);
            this.label5.TabIndex = 55;
            this.label5.Text = "2";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(300, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 19);
            this.label3.TabIndex = 56;
            this.label3.Text = "1";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(204, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 19);
            this.label2.TabIndex = 57;
            this.label2.Text = "0";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(533, 115);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 19);
            this.label6.TabIndex = 58;
            this.label6.Text = "Score";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(64, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 19);
            this.label4.TabIndex = 59;
            this.label4.Text = "Signs";
            // 
            // lblScore
            // 
            this.lblScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.Blue;
            this.lblScore.Location = new System.Drawing.Point(215, 693);
            this.lblScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(22, 24);
            this.lblScore.TabIndex = 49;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(49, 693);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "APGAR Score : ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // respirationBox
            // 
            this.respirationBox.Controls.Add(this.txtrespiration);
            this.respirationBox.Controls.Add(this.rdvigorous);
            this.respirationBox.Controls.Add(this.rdslowirreg);
            this.respirationBox.Controls.Add(this.rdabsentR);
            this.respirationBox.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.respirationBox.Location = new System.Drawing.Point(46, 570);
            this.respirationBox.Name = "respirationBox";
            this.respirationBox.Size = new System.Drawing.Size(569, 86);
            this.respirationBox.TabIndex = 48;
            this.respirationBox.TabStop = false;
            this.respirationBox.Text = "R-espiration";
            // 
            // txtrespiration
            // 
            this.txtrespiration.Enabled = false;
            this.txtrespiration.Location = new System.Drawing.Point(473, 37);
            this.txtrespiration.Name = "txtrespiration";
            this.txtrespiration.Size = new System.Drawing.Size(90, 29);
            this.txtrespiration.TabIndex = 1;
            this.txtrespiration.Text = "0";
            // 
            // rdvigorous
            // 
            this.rdvigorous.AutoSize = true;
            this.rdvigorous.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdvigorous.Location = new System.Drawing.Point(357, 44);
            this.rdvigorous.Name = "rdvigorous";
            this.rdvigorous.Size = new System.Drawing.Size(113, 22);
            this.rdvigorous.TabIndex = 0;
            this.rdvigorous.TabStop = true;
            this.rdvigorous.Text = "Vigorous cry";
            this.rdvigorous.UseVisualStyleBackColor = true;
            this.rdvigorous.CheckedChanged += new System.EventHandler(this.rdvigorous_CheckedChanged);
            // 
            // rdslowirreg
            // 
            this.rdslowirreg.AutoSize = true;
            this.rdslowirreg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdslowirreg.Location = new System.Drawing.Point(234, 33);
            this.rdslowirreg.Name = "rdslowirreg";
            this.rdslowirreg.Size = new System.Drawing.Size(94, 40);
            this.rdslowirreg.TabIndex = 0;
            this.rdslowirreg.TabStop = true;
            this.rdslowirreg.Text = "Slow and \r\nIrregular";
            this.rdslowirreg.UseVisualStyleBackColor = true;
            this.rdslowirreg.CheckedChanged += new System.EventHandler(this.rdvigorous_CheckedChanged);
            // 
            // rdabsentR
            // 
            this.rdabsentR.AutoSize = true;
            this.rdabsentR.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdabsentR.Location = new System.Drawing.Point(133, 44);
            this.rdabsentR.Name = "rdabsentR";
            this.rdabsentR.Size = new System.Drawing.Size(75, 22);
            this.rdabsentR.TabIndex = 0;
            this.rdabsentR.TabStop = true;
            this.rdabsentR.Text = "Absent";
            this.rdabsentR.UseVisualStyleBackColor = true;
            this.rdabsentR.CheckedChanged += new System.EventHandler(this.rdvigorous_CheckedChanged);
            // 
            // activityBox
            // 
            this.activityBox.Controls.Add(this.txtactivity);
            this.activityBox.Controls.Add(this.rdactive);
            this.activityBox.Controls.Add(this.radioButton8);
            this.activityBox.Controls.Add(this.rdabsentA);
            this.activityBox.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityBox.Location = new System.Drawing.Point(46, 458);
            this.activityBox.Name = "activityBox";
            this.activityBox.Size = new System.Drawing.Size(569, 86);
            this.activityBox.TabIndex = 48;
            this.activityBox.TabStop = false;
            this.activityBox.Text = "A-ctivity";
            // 
            // txtactivity
            // 
            this.txtactivity.Enabled = false;
            this.txtactivity.Location = new System.Drawing.Point(473, 37);
            this.txtactivity.Name = "txtactivity";
            this.txtactivity.Size = new System.Drawing.Size(90, 29);
            this.txtactivity.TabIndex = 1;
            this.txtactivity.Text = "0";
            // 
            // rdactive
            // 
            this.rdactive.AutoSize = true;
            this.rdactive.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdactive.Location = new System.Drawing.Point(357, 44);
            this.rdactive.Name = "rdactive";
            this.rdactive.Size = new System.Drawing.Size(69, 22);
            this.rdactive.TabIndex = 0;
            this.rdactive.TabStop = true;
            this.rdactive.Text = "Active";
            this.rdactive.UseVisualStyleBackColor = true;
            this.rdactive.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged_1);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton8.Location = new System.Drawing.Point(234, 33);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(116, 40);
            this.radioButton8.TabIndex = 0;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Flexed arms \r\nand legs";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged_1);
            // 
            // rdabsentA
            // 
            this.rdabsentA.AutoSize = true;
            this.rdabsentA.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdabsentA.Location = new System.Drawing.Point(133, 44);
            this.rdabsentA.Name = "rdabsentA";
            this.rdabsentA.Size = new System.Drawing.Size(75, 22);
            this.rdabsentA.TabIndex = 0;
            this.rdabsentA.TabStop = true;
            this.rdabsentA.Text = "Absent";
            this.rdabsentA.UseVisualStyleBackColor = true;
            this.rdabsentA.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged_1);
            // 
            // grimaceBox
            // 
            this.grimaceBox.Controls.Add(this.txtgrimace);
            this.grimaceBox.Controls.Add(this.rdcryactive);
            this.grimaceBox.Controls.Add(this.rdGrimace);
            this.grimaceBox.Controls.Add(this.rdFloppy);
            this.grimaceBox.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grimaceBox.Location = new System.Drawing.Point(46, 353);
            this.grimaceBox.Name = "grimaceBox";
            this.grimaceBox.Size = new System.Drawing.Size(569, 86);
            this.grimaceBox.TabIndex = 48;
            this.grimaceBox.TabStop = false;
            this.grimaceBox.Text = "G-rimace";
            // 
            // txtgrimace
            // 
            this.txtgrimace.Enabled = false;
            this.txtgrimace.Location = new System.Drawing.Point(473, 37);
            this.txtgrimace.Name = "txtgrimace";
            this.txtgrimace.Size = new System.Drawing.Size(90, 29);
            this.txtgrimace.TabIndex = 1;
            this.txtgrimace.Text = "0";
            // 
            // rdcryactive
            // 
            this.rdcryactive.AutoSize = true;
            this.rdcryactive.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdcryactive.Location = new System.Drawing.Point(357, 44);
            this.rdcryactive.Name = "rdcryactive";
            this.rdcryactive.Size = new System.Drawing.Size(95, 22);
            this.rdcryactive.TabIndex = 0;
            this.rdcryactive.TabStop = true;
            this.rdcryactive.Text = "Cry active";
            this.rdcryactive.UseVisualStyleBackColor = true;
            this.rdcryactive.CheckedChanged += new System.EventHandler(this.rdFloppy_CheckedChanged_1);
            // 
            // rdGrimace
            // 
            this.rdGrimace.AutoSize = true;
            this.rdGrimace.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdGrimace.Location = new System.Drawing.Point(234, 44);
            this.rdGrimace.Name = "rdGrimace";
            this.rdGrimace.Size = new System.Drawing.Size(86, 22);
            this.rdGrimace.TabIndex = 0;
            this.rdGrimace.TabStop = true;
            this.rdGrimace.Text = "Grimace";
            this.rdGrimace.UseVisualStyleBackColor = true;
            this.rdGrimace.CheckedChanged += new System.EventHandler(this.rdFloppy_CheckedChanged_1);
            // 
            // rdFloppy
            // 
            this.rdFloppy.AutoSize = true;
            this.rdFloppy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdFloppy.Location = new System.Drawing.Point(133, 44);
            this.rdFloppy.Name = "rdFloppy";
            this.rdFloppy.Size = new System.Drawing.Size(58, 22);
            this.rdFloppy.TabIndex = 0;
            this.rdFloppy.TabStop = true;
            this.rdFloppy.Text = "Pale";
            this.rdFloppy.UseVisualStyleBackColor = true;
            this.rdFloppy.CheckedChanged += new System.EventHandler(this.rdFloppy_CheckedChanged_1);
            // 
            // pulseBox
            // 
            this.pulseBox.Controls.Add(this.txtpulse);
            this.pulseBox.Controls.Add(this.rdthan100);
            this.pulseBox.Controls.Add(this.rdless100);
            this.pulseBox.Controls.Add(this.rdabsentp);
            this.pulseBox.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulseBox.Location = new System.Drawing.Point(46, 248);
            this.pulseBox.Name = "pulseBox";
            this.pulseBox.Size = new System.Drawing.Size(569, 86);
            this.pulseBox.TabIndex = 48;
            this.pulseBox.TabStop = false;
            this.pulseBox.Text = "P-ulse";
            // 
            // txtpulse
            // 
            this.txtpulse.Enabled = false;
            this.txtpulse.Location = new System.Drawing.Point(473, 37);
            this.txtpulse.Name = "txtpulse";
            this.txtpulse.Size = new System.Drawing.Size(90, 29);
            this.txtpulse.TabIndex = 1;
            this.txtpulse.Text = "0";
            // 
            // rdthan100
            // 
            this.rdthan100.AutoSize = true;
            this.rdthan100.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdthan100.Location = new System.Drawing.Point(357, 44);
            this.rdthan100.Name = "rdthan100";
            this.rdthan100.Size = new System.Drawing.Size(93, 22);
            this.rdthan100.TabIndex = 0;
            this.rdthan100.TabStop = true;
            this.rdthan100.Text = "<100bmp";
            this.rdthan100.UseVisualStyleBackColor = true;
            this.rdthan100.CheckedChanged += new System.EventHandler(this.rdthan100_CheckedChanged);
            // 
            // rdless100
            // 
            this.rdless100.AutoSize = true;
            this.rdless100.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdless100.Location = new System.Drawing.Point(234, 44);
            this.rdless100.Name = "rdless100";
            this.rdless100.Size = new System.Drawing.Size(93, 22);
            this.rdless100.TabIndex = 0;
            this.rdless100.TabStop = true;
            this.rdless100.Text = ">100bmp";
            this.rdless100.UseVisualStyleBackColor = true;
            this.rdless100.CheckedChanged += new System.EventHandler(this.rdthan100_CheckedChanged);
            // 
            // rdabsentp
            // 
            this.rdabsentp.AutoSize = true;
            this.rdabsentp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdabsentp.Location = new System.Drawing.Point(133, 44);
            this.rdabsentp.Name = "rdabsentp";
            this.rdabsentp.Size = new System.Drawing.Size(75, 22);
            this.rdabsentp.TabIndex = 0;
            this.rdabsentp.TabStop = true;
            this.rdabsentp.Text = "Absent";
            this.rdabsentp.UseVisualStyleBackColor = true;
            this.rdabsentp.CheckedChanged += new System.EventHandler(this.rdthan100_CheckedChanged);
            // 
            // appearanceBox
            // 
            this.appearanceBox.Controls.Add(this.txtAppearance);
            this.appearanceBox.Controls.Add(this.rdPink);
            this.appearanceBox.Controls.Add(this.rdBlue);
            this.appearanceBox.Controls.Add(this.rdPale);
            this.appearanceBox.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appearanceBox.Location = new System.Drawing.Point(46, 147);
            this.appearanceBox.Name = "appearanceBox";
            this.appearanceBox.Size = new System.Drawing.Size(569, 86);
            this.appearanceBox.TabIndex = 48;
            this.appearanceBox.TabStop = false;
            this.appearanceBox.Text = "A-ppearance";
            // 
            // txtAppearance
            // 
            this.txtAppearance.Enabled = false;
            this.txtAppearance.Location = new System.Drawing.Point(473, 37);
            this.txtAppearance.Name = "txtAppearance";
            this.txtAppearance.Size = new System.Drawing.Size(90, 29);
            this.txtAppearance.TabIndex = 1;
            this.txtAppearance.Text = "0";
            // 
            // rdPink
            // 
            this.rdPink.AutoSize = true;
            this.rdPink.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPink.Location = new System.Drawing.Point(357, 44);
            this.rdPink.Name = "rdPink";
            this.rdPink.Size = new System.Drawing.Size(57, 22);
            this.rdPink.TabIndex = 0;
            this.rdPink.TabStop = true;
            this.rdPink.Text = "Pink";
            this.rdPink.UseVisualStyleBackColor = true;
            this.rdPink.CheckedChanged += new System.EventHandler(this.rdPale_CheckedChanged_1);
            // 
            // rdBlue
            // 
            this.rdBlue.AutoSize = true;
            this.rdBlue.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBlue.Location = new System.Drawing.Point(234, 44);
            this.rdBlue.Name = "rdBlue";
            this.rdBlue.Size = new System.Drawing.Size(57, 22);
            this.rdBlue.TabIndex = 0;
            this.rdBlue.TabStop = true;
            this.rdBlue.Text = "Blue";
            this.rdBlue.UseVisualStyleBackColor = true;
            this.rdBlue.CheckedChanged += new System.EventHandler(this.rdPale_CheckedChanged_1);
            // 
            // rdPale
            // 
            this.rdPale.AutoSize = true;
            this.rdPale.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPale.Location = new System.Drawing.Point(133, 44);
            this.rdPale.Name = "rdPale";
            this.rdPale.Size = new System.Drawing.Size(58, 22);
            this.rdPale.TabIndex = 0;
            this.rdPale.TabStop = true;
            this.rdPale.Text = "Pale";
            this.rdPale.UseVisualStyleBackColor = true;
            this.rdPale.CheckedChanged += new System.EventHandler(this.rdPale_CheckedChanged_1);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(519, 683);
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
            this.panel2.Size = new System.Drawing.Size(654, 48);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(652, 46);
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
            this.label1.Size = new System.Drawing.Size(589, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "APGAR Score";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.AutoSize = true;
            this.btnclose.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.LavenderBlush;
            this.btnclose.Location = new System.Drawing.Point(595, 8);
            this.btnclose.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(55, 29);
            this.btnclose.TabIndex = 0;
            this.btnclose.Text = "X";
            this.btnclose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Apgarscorefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(670, 756);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Apgarscorefrm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apgarscorefrm";
            this.Load += new System.EventHandler(this.Apgarscorefrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.respirationBox.ResumeLayout(false);
            this.respirationBox.PerformLayout();
            this.activityBox.ResumeLayout(false);
            this.activityBox.PerformLayout();
            this.grimaceBox.ResumeLayout(false);
            this.grimaceBox.PerformLayout();
            this.pulseBox.ResumeLayout(false);
            this.pulseBox.PerformLayout();
            this.appearanceBox.ResumeLayout(false);
            this.appearanceBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label btnclose;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblIDNo;
        public System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox respirationBox;
        private System.Windows.Forms.TextBox txtrespiration;
        private System.Windows.Forms.RadioButton rdvigorous;
        private System.Windows.Forms.RadioButton rdslowirreg;
        private System.Windows.Forms.RadioButton rdabsentR;
        private System.Windows.Forms.GroupBox activityBox;
        private System.Windows.Forms.TextBox txtactivity;
        private System.Windows.Forms.RadioButton rdactive;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton rdabsentA;
        private System.Windows.Forms.GroupBox grimaceBox;
        private System.Windows.Forms.TextBox txtgrimace;
        private System.Windows.Forms.RadioButton rdcryactive;
        private System.Windows.Forms.RadioButton rdGrimace;
        private System.Windows.Forms.RadioButton rdFloppy;
        private System.Windows.Forms.GroupBox pulseBox;
        private System.Windows.Forms.TextBox txtpulse;
        private System.Windows.Forms.RadioButton rdthan100;
        private System.Windows.Forms.RadioButton rdless100;
        private System.Windows.Forms.RadioButton rdabsentp;
        private System.Windows.Forms.GroupBox appearanceBox;
        private System.Windows.Forms.TextBox txtAppearance;
        private System.Windows.Forms.RadioButton rdPink;
        private System.Windows.Forms.RadioButton rdBlue;
        private System.Windows.Forms.RadioButton rdPale;
    }
}