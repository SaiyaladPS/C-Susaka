namespace Project
{
    partial class frmConvertNumberToWord
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
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnConvertla = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lbResult = new System.Windows.Forms.Label();
            this.btnConverten = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Phetsarath OT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "ປ້ອນຕົວເລກ";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(124, 85);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(354, 26);
            this.txtNumber.TabIndex = 1;
            // 
            // btnConvertla
            // 
            this.btnConvertla.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertla.Location = new System.Drawing.Point(111, 157);
            this.btnConvertla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConvertla.Name = "btnConvertla";
            this.btnConvertla.Size = new System.Drawing.Size(125, 35);
            this.btnConvertla.TabIndex = 2;
            this.btnConvertla.Text = "ອ່ານເປັນພາສາລາວ";
            this.btnConvertla.UseVisualStyleBackColor = true;
            this.btnConvertla.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(366, 157);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 35);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "ລ້າງ";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResult.Location = new System.Drawing.Point(56, 221);
            this.lbResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(60, 23);
            this.lbResult.TabIndex = 4;
            this.lbResult.Text = "ຜົນທີ່ຮັບ";
            // 
            // btnConverten
            // 
            this.btnConverten.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConverten.Location = new System.Drawing.Point(244, 157);
            this.btnConverten.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConverten.Name = "btnConverten";
            this.btnConverten.Size = new System.Drawing.Size(112, 35);
            this.btnConverten.TabIndex = 5;
            this.btnConverten.Text = "ອ່ານເປັນອັງກິດ";
            this.btnConverten.UseVisualStyleBackColor = true;
            this.btnConverten.Click += new System.EventHandler(this.btnConverten_Click);
            // 
            // frmConvertNumberToWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 363);
            this.Controls.Add(this.btnConverten);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnConvertla);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConvertNumberToWord";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnConvertla;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Button btnConverten;
    }
}