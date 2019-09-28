using System;
using System.Windows.Forms;
using System.IO;


namespace KayıtEkleme
{
    public partial class frmKayıtEkle : Form
    {
        string Ad;
        string SoyAd;
        string Tel;             //bu formda kullanıcaklarımız
        string AdRenk;
        string SoyAdRenk;
        string TelRenk;
        string cumle;       
        
        private void Temizle()
        {
            txtAd.Text = null;
            txtSoyad.Text = null;
            txtTel.Text = null;
            txtAd.ForeColor = System.Drawing.Color.Black;
            txtSoyad.ForeColor = System.Drawing.Color.Black;
            txtTel.ForeColor = System.Drawing.Color.Black;
            Ad = null;                                                // eklemeden sonra tüm değerlerimizi sıfırlıyoruz
            SoyAd = null;
            Tel = null;
            AdRenk = null;
            SoyAdRenk = null;
            TelRenk = null;
            cumle = null;
            cmbbxRenk1.SelectedItem = null;
            cmbbxRenk2.SelectedItem = null;
            cmbbxRenk3.SelectedItem = null;     
        }
        
        public frmKayıtEkle()
        {
            InitializeComponent();
            cmbbxRenk1.Items.Add("Kırmızı");
            cmbbxRenk1.Items.Add("Mavi");
            cmbbxRenk1.Items.Add("Yeşil");         //control boxlarımızı dolduruyoruz
            cmbbxRenk2.Items.Add("Kırmızı");
            cmbbxRenk2.Items.Add("Mavi");
            cmbbxRenk2.Items.Add("Yeşil");
            cmbbxRenk3.Items.Add("Kırmızı");
            cmbbxRenk3.Items.Add("Mavi");
            cmbbxRenk3.Items.Add("Yeşil");
        }

        private bool Eksikmi(string Ad,string Soyad, string Tel, string AdRenk, string SoyadRenk, string TelRenk )
        {
            if (!string.IsNullOrWhiteSpace(Ad))                  //isnullorwhitespace sayesinde boşluk kabul edilmiyor
                if (!string.IsNullOrWhiteSpace(Soyad))
                    if (!string.IsNullOrWhiteSpace(Tel))
                        if (AdRenk != null)
                            if (SoyadRenk != null)
                                if (TelRenk != null)                   //tüm değerler tam olmadan kayıt ekleyemeyiz bu yüzden kontrol ediyoruz.
                                    return true;
                                else return false;
                            else return false;
                        else return false;
                    else return false;
                else return false;
            else return false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {                     
            if (Eksikmi(Ad, SoyAd, Tel, AdRenk, SoyAdRenk, TelRenk))    // değerleri kontrol ediyoruz
            {
                lblMesaj.Text = "Başarılı!!!";   
                cumle = AdRenk + SoyAdRenk + TelRenk + " " + Ad + " " + SoyAd + " " + Tel+ Environment.NewLine;   //verileri bi değişkene atıyoruz
                File.AppendAllText("veriler.txt", cumle);                //değişkeni yazdırıyoruz
                Temizle();              //ve temizliyoruz
                
                
            }
            else if (!Eksikmi(Ad, SoyAd, Tel, AdRenk, SoyAdRenk, TelRenk))      //eğer veriler eksikse
            {
                lblMesaj.Text = "Eksik Bilgi!!!";
                Temizle();                 //yazdırmadan temizliyoruz
            }

        }       

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGiris giris = new frmGiris();   //ana forma dönüyoruz
            giris.Show();
        }

        private void cmbbxRenk1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(cmbbxRenk1.Text=="Kırmızı")
            {                                                      //comboboxa dokunulduğunda yazı rengimizi ve bilgiyi güncelliyoruz
                txtAd.ForeColor = System.Drawing.Color.Red;
                AdRenk = "k";
            }
            else if (cmbbxRenk1.Text == "Mavi")
            {
                txtAd.ForeColor = System.Drawing.Color.Blue;
                AdRenk = "m";
            }
            else if (cmbbxRenk1.Text == "Yeşil")
            {
                txtAd.ForeColor = System.Drawing.Color.Green;
                AdRenk = "y";
            }
        }

        private void cmbbxRenk2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbbxRenk2.Text == "Kırmızı")
            {
                txtSoyad.ForeColor = System.Drawing.Color.Red;
                SoyAdRenk = "k";
            }
            else  if (cmbbxRenk2.Text == "Mavi")
            {
                txtSoyad.ForeColor = System.Drawing.Color.Blue;
                SoyAdRenk = "m";
            }
            else if (cmbbxRenk2.Text == "Yeşil")
            {
                txtSoyad.ForeColor = System.Drawing.Color.Green;
                SoyAdRenk = "y";
            }
        }

        private void cmbbxRenk3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbbxRenk3.Text == "Kırmızı")
            {
                txtTel.ForeColor = System.Drawing.Color.Red;
                TelRenk = "k";
            }
            else if (cmbbxRenk3.Text == "Mavi")
            {
                txtTel.ForeColor = System.Drawing.Color.Blue;
                TelRenk = "m";
            }
            else if (cmbbxRenk3.Text == "Yeşil")
            {
                txtTel.ForeColor = System.Drawing.Color.Green;
                TelRenk = "y";
            }
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            Ad = txtAd.Text.Trim();               //texte yazıldığı anda güncelliyoruz   ve trim kullanarak boşlukları siliyoruz
        }

        private void txtSoyad_TextChanged(object sender, EventArgs e)
        {
            SoyAd = txtSoyad.Text.Trim();           
        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            Tel = txtTel.Text.Trim();
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmKayıtEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();       //uygulamadan çıkış
        }

    }
}
