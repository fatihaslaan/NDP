namespace KayıtEkleme
{
    partial class frmGiris
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
            this.btnKayıtEkle = new System.Windows.Forms.Button();
            this.btnKayıtlar = new System.Windows.Forms.Button();
            this.btnCıkıs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnKayıtEkle
            // 
            this.btnKayıtEkle.Location = new System.Drawing.Point(12, 80);
            this.btnKayıtEkle.Name = "btnKayıtEkle";
            this.btnKayıtEkle.Size = new System.Drawing.Size(311, 57);
            this.btnKayıtEkle.TabIndex = 0;
            this.btnKayıtEkle.Text = "Kayıt Ekle";
            this.btnKayıtEkle.UseVisualStyleBackColor = true;
            this.btnKayıtEkle.Click += new System.EventHandler(this.btnKayıtEkle_Click);
            // 
            // btnKayıtlar
            // 
            this.btnKayıtlar.Location = new System.Drawing.Point(12, 143);
            this.btnKayıtlar.Name = "btnKayıtlar";
            this.btnKayıtlar.Size = new System.Drawing.Size(311, 57);
            this.btnKayıtlar.TabIndex = 1;
            this.btnKayıtlar.Text = "Kayıtlar";
            this.btnKayıtlar.UseVisualStyleBackColor = true;
            this.btnKayıtlar.Click += new System.EventHandler(this.btnKayıtlar_Click);
            // 
            // btnCıkıs
            // 
            this.btnCıkıs.Location = new System.Drawing.Point(12, 206);
            this.btnCıkıs.Name = "btnCıkıs";
            this.btnCıkıs.Size = new System.Drawing.Size(311, 57);
            this.btnCıkıs.TabIndex = 2;
            this.btnCıkıs.Text = "Çıkış";
            this.btnCıkıs.UseVisualStyleBackColor = true;
            this.btnCıkıs.Click += new System.EventHandler(this.btnCıkıs_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Diwani Bent", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 51);
            this.label1.TabIndex = 3;
            this.label1.Text = "REHBER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(335, 275);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCıkıs);
            this.Controls.Add(this.btnKayıtlar);
            this.Controls.Add(this.btnKayıtEkle);
            this.Name = "frmGiris";
            this.Text = "Rehber";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGiris_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKayıtEkle;
        private System.Windows.Forms.Button btnKayıtlar;
        private System.Windows.Forms.Button btnCıkıs;
        private System.Windows.Forms.Label label1;
    }
}