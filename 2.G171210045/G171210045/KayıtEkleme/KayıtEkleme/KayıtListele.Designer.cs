namespace KayıtEkleme
{
    partial class frmKayıtListele
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnKayıtListele = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.richTextBox1.Location = new System.Drawing.Point(20, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(524, 665);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnGeri
            // 
            this.btnGeri.Location = new System.Drawing.Point(550, 74);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(219, 56);
            this.btnGeri.TabIndex = 1;
            this.btnGeri.Text = "Geri Dön";
            this.btnGeri.UseVisualStyleBackColor = true;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // btnKayıtListele
            // 
            this.btnKayıtListele.Location = new System.Drawing.Point(550, 12);
            this.btnKayıtListele.Name = "btnKayıtListele";
            this.btnKayıtListele.Size = new System.Drawing.Size(219, 56);
            this.btnKayıtListele.TabIndex = 2;
            this.btnKayıtListele.Text = "Kayıt Listele";
            this.btnKayıtListele.UseVisualStyleBackColor = true;
            this.btnKayıtListele.Click += new System.EventHandler(this.btnKayıtListele_Click);
            // 
            // frmKayıtListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(781, 689);
            this.Controls.Add(this.btnKayıtListele);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.richTextBox1);
            this.Name = "frmKayıtListele";
            this.Text = "Rehber";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKayıtListele_FormClosing);
            this.Load += new System.EventHandler(this.frmKayıtListele_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Button btnKayıtListele;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

