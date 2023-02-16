
namespace CAPSTONEPROJ.Transaction
{
    partial class ChargePatient
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNewborn = new System.Windows.Forms.Button();
            this.dataGridViewAdmittedPatient = new System.Windows.Forms.DataGridView();
            this.btngiveMedicine = new System.Windows.Forms.Button();
            this.btnPrintBill = new System.Windows.Forms.Button();
            this.btndischarge = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmittedPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumPurple;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1227, 53);
            this.panel1.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label4.Location = new System.Drawing.Point(4, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "In-Patient";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Pink;
            this.panel2.Controls.Add(this.btnNewborn);
            this.panel2.Controls.Add(this.dataGridViewAdmittedPatient);
            this.panel2.Controls.Add(this.btngiveMedicine);
            this.panel2.Controls.Add(this.btnPrintBill);
            this.panel2.Controls.Add(this.btndischarge);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(8, 158);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1227, 647);
            this.panel2.TabIndex = 21;
            // 
            // btnNewborn
            // 
            this.btnNewborn.BackColor = System.Drawing.Color.Pink;
            this.btnNewborn.Enabled = false;
            this.btnNewborn.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewborn.Image = global::CAPSTONEPROJ.Properties.Resources.icons8_exit_60;
            this.btnNewborn.Location = new System.Drawing.Point(1076, 471);
            this.btnNewborn.Name = "btnNewborn";
            this.btnNewborn.Size = new System.Drawing.Size(98, 97);
            this.btnNewborn.TabIndex = 41;
            this.btnNewborn.Text = "Newborn";
            this.btnNewborn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNewborn.UseVisualStyleBackColor = false;
            // 
            // dataGridViewAdmittedPatient
            // 
            this.dataGridViewAdmittedPatient.AllowUserToAddRows = false;
            this.dataGridViewAdmittedPatient.AllowUserToDeleteRows = false;
            this.dataGridViewAdmittedPatient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAdmittedPatient.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dataGridViewAdmittedPatient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewAdmittedPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdmittedPatient.Location = new System.Drawing.Point(11, 128);
            this.dataGridViewAdmittedPatient.Name = "dataGridViewAdmittedPatient";
            this.dataGridViewAdmittedPatient.ReadOnly = true;
            this.dataGridViewAdmittedPatient.RowHeadersWidth = 62;
            this.dataGridViewAdmittedPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAdmittedPatient.Size = new System.Drawing.Size(971, 467);
            this.dataGridViewAdmittedPatient.TabIndex = 24;
            // 
            // btngiveMedicine
            // 
            this.btngiveMedicine.BackColor = System.Drawing.Color.Pink;
            this.btngiveMedicine.Enabled = false;
            this.btngiveMedicine.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold);
            this.btngiveMedicine.Image = global::CAPSTONEPROJ.Properties.Resources.icons8_medicine_60;
            this.btngiveMedicine.Location = new System.Drawing.Point(1077, 265);
            this.btngiveMedicine.Name = "btngiveMedicine";
            this.btngiveMedicine.Size = new System.Drawing.Size(97, 97);
            this.btngiveMedicine.TabIndex = 21;
            this.btngiveMedicine.Text = "Give Medicine";
            this.btngiveMedicine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btngiveMedicine.UseVisualStyleBackColor = false;
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.BackColor = System.Drawing.Color.Pink;
            this.btnPrintBill.Enabled = false;
            this.btnPrintBill.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBill.Image = global::CAPSTONEPROJ.Properties.Resources.icons8_exit_60;
            this.btnPrintBill.Location = new System.Drawing.Point(1076, 368);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(98, 97);
            this.btnPrintBill.TabIndex = 21;
            this.btnPrintBill.Text = "Print Bill";
            this.btnPrintBill.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrintBill.UseVisualStyleBackColor = false;
            // 
            // btndischarge
            // 
            this.btndischarge.BackColor = System.Drawing.Color.Pink;
            this.btndischarge.Enabled = false;
            this.btndischarge.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndischarge.Image = global::CAPSTONEPROJ.Properties.Resources.icons8_exit_60;
            this.btndischarge.Location = new System.Drawing.Point(1076, 162);
            this.btndischarge.Name = "btndischarge";
            this.btndischarge.Size = new System.Drawing.Size(98, 97);
            this.btndischarge.TabIndex = 21;
            this.btndischarge.Text = "Charge Patient";
            this.btndischarge.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btndischarge.UseVisualStyleBackColor = false;
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
            // ChargePatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1243, 813);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "ChargePatient";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChargePatient";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmittedPatient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnNewborn;
        private System.Windows.Forms.Button btngiveMedicine;
        private System.Windows.Forms.Button btnPrintBill;
        private System.Windows.Forms.Button btndischarge;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dataGridViewAdmittedPatient;
    }
}