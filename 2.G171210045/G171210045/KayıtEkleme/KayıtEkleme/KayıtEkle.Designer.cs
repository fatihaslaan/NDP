namespace KayıtEkleme
{
    partial class frmKayıtEkle
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
            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbbxRenk1 = new System.Windows.Forms.ComboBox();
            this.cmbbxRenk2 = new System.Windows.Forms.ComboBox();
            this.cmbbxRenk3 = new System.Windows.Forms.ComboBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            this.lblMesaj = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAd
            // 
            this.txtAd.ForeColor = System.Drawing.Color.Black;
            this.txtAd.Location = new System.Drawing.Point(111, 37);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(233, 26);
            this.txtAd.TabIndex = 0;
            this.txtAd.TextChanged += new System.EventHandler(this.txtAd_TextChanged);
            // 
            // txtSoyad
            // 
            this.txtSoyad.ForeColor = System.Drawing.Color.Black;
            this.txtSoyad.Location = new System.Drawing.Point(111, 105);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(233, 26);
            this.txtSoyad.TabIndex = 1;
            this.txtSoyad.TextChanged += new System.EventHandler(this.txtSoyad_TextChanged);
            // 
            // txtTel
            // 
            this.txtTel.ForeColor = System.Drawing.Color.Black;
            this.txtTel.Location = new System.Drawing.Point(111, 176);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(233, 26);
            this.txtTel.TabIndex = 2;
            this.txtTel.TextChanged += new System.EventHandler(this.txtTel_TextChanged);
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(16, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Soyad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(16, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tel";
            // 
            // cmbbxRenk1
            // 
            this.cmbbxRenk1.FormattingEnabled = true;
            this.cmbbxRenk1.Location = new System.Drawing.Point(386, 38);
            this.cmbbxRenk1.Name = "cmbbxRenk1";
            this.cmbbxRenk1.Size = new System.Drawing.Size(151, 28);
            this.cmbbxRenk1.TabIndex = 6;
            this.cmbbxRenk1.SelectedIndexChanged += new System.EventHandler(this.cmbbxRenk1_SelectedIndexChanged);
            // 
            // cmbbxRenk2
            // 
            this.cmbbxRenk2.FormattingEnabled = true;
            this.cmbbxRenk2.Location = new System.Drawing.Point(386, 103);
            this.cmbbxRenk2.Name = "cmbbxRenk2";
            this.cmbbxRenk2.Size = new System.Drawing.Size(151, 28);
            this.cmbbxRenk2.TabIndex = 7;
            this.cmbbxRenk2.SelectedIndexChanged += new System.EventHandler(this.cmbbxRenk2_SelectedIndexChanged);
            // 
            // cmbbxRenk3
            // 
            this.cmbbxRenk3.FormattingEnabled = true;
            this.cmbbxRenk3.Location = new System.Drawing.Point(386, 174);
            this.cmbbxRenk3.Name = "cmbbxRenk3";
            this.cmbbxRenk3.Size = new System.Drawing.Size(151, 28);
            this.cmbbxRenk3.TabIndex = 8;
            this.cmbbxRenk3.SelectedIndexChanged += new System.EventHandler(this.cmbbxRenk3_SelectedIndexChanged);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(558, 36);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(158, 51);
            this.btnEkle.TabIndex = 9;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnGeri
            // 
            this.btnGeri.Location = new System.Drawing.Point(558, 151);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(158, 51);
            this.btnGeri.TabIndex = 10;
            this.btnGeri.Text = "Geri Dön";
            this.btnGeri.UseVisualStyleBackColor = true;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // lblMesaj
            // 
            this.lblMesaj.BackColor = System.Drawing.Color.Black;
            this.lblMesaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMesaj.ForeColor = System.Drawing.Color.Red;
            this.lblMesaj.Location = new System.Drawing.Point(20, 220);
            this.lblMesaj.Name = "lblMesaj";
            this.lblMesaj.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMesaj.Size = new System.Drawing.Size(695, 53);
            this.lblMesaj.TabIndex = 11;
            this.lblMesaj.Text = "Lütfen bilgilerinizi girin.";
            this.lblMesaj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmKayıtEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(728, 283);
            this.Controls.Add(this.lblMesaj);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.cmbbxRenk3);
            this.Controls.Add(this.cmbbxRenk2);
            this.Controls.Add(this.cmbbxRenk1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.txtAd);
            this.Name = "frmKayıtEkle";
            this.Text = "Rehber";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKayıtEkle_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbbxRenk1;
        private System.Windows.Forms.ComboBox cmbbxRenk2;
        private System.Windows.Forms.ComboBox cmbbxRenk3;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Label lblMesaj;
    }
}