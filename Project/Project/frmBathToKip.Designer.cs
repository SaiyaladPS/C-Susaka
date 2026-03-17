namespace Project
{
    partial class frmBathToKip
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbath = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExc = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKip = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Phetsarath OT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(105, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "ແລກປ່ຽນເງິນບາດເປັນກີບ";
            this.label1.Click += new System.EventHandler(this.ແລກປ່ຽນບາດເປັນກີບ_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "ປ້ອນຈຳນວນເງິນບາດ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtbath
            // 
            this.txtbath.Location = new System.Drawing.Point(157, 91);
            this.txtbath.Name = "txtbath";
            this.txtbath.Size = new System.Drawing.Size(227, 31);
            this.txtbath.TabIndex = 2;
            this.txtbath.TextChanged += new System.EventHandler(this.txtbath_TextChanged);
            this.txtbath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbath_KeyPress);
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(157, 136);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(227, 31);
            this.txtRate.TabIndex = 3;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "ປ້ອນອັດຕາແລກປ່ຽນ";
            // 
            // btnExc
            // 
            this.btnExc.Location = new System.Drawing.Point(93, 213);
            this.btnExc.Name = "btnExc";
            this.btnExc.Size = new System.Drawing.Size(76, 32);
            this.btnExc.TabIndex = 5;
            this.btnExc.Text = "ແລກປ່ຽນ";
            this.btnExc.UseVisualStyleBackColor = true;
            this.btnExc.Click += new System.EventHandler(this.btnExc_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(238, 213);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(76, 32);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "ລ້າງ";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "ຈຳນວນເງິນກີບ";
            // 
            // txtKip
            // 
            this.txtKip.Location = new System.Drawing.Point(157, 287);
            this.txtKip.Name = "txtKip";
            this.txtKip.ReadOnly = true;
            this.txtKip.Size = new System.Drawing.Size(227, 31);
            this.txtKip.TabIndex = 8;
            // 
            // frmBathToKip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 482);
            this.Controls.Add(this.txtKip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.txtbath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmBathToKip";
            this.Text = "frmBathToKip";
            this.Load += new System.EventHandler(this.frmBathToKip_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbath;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExc;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKip;
    }
}