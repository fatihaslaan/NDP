using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace KayıtEkleme
{
    public partial class frmKayıtListele : Form
    {
        int adsayac;
        int soyadsayac;   //değerlerin uzunluklarını bulmamaızı sağlıyor
        int telsayac;   
        string[] kayıtlar;
        string[] AdRenk;
        string[] SoyadRenk;
        string[] TelRenk;             //gerekli dizilerimiz
        string[] Adlar;
        string[] Soyadlar;
        string[] Teller;

        private void Ozellik()
        {
            for (int i = 0; i < kayıtlar.Length; i++)                  // kayıt sayısı kadar for döngüsüne sokuyoruz ve her isim soyisim ve telefon numaralarının renklerini 
            {                
                if (i % 2 == 0)
                {                         
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);                    //ve satırın konumuna göre cümlelerin kalın yazılmasını sağlıyoruz
                }
                else
                {                    
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                }

                if (AdRenk[i] == "k")                           //kendi dizilerinden çekip denetledikten sonra yine telefon isim ve soyisimleri dizilerden çekip yazıdırıyoruz
                {
                    richTextBox1.SelectionColor = Color.Red;
                }
                else if (AdRenk[i] == "m")
                {
                    richTextBox1.SelectionColor = Color.Blue;
                }
                else if (AdRenk[i] == "y")
                {
                    richTextBox1.SelectionColor = Color.Green;
                }

                richTextBox1.AppendText(Adlar[i] + " ");
                
                if (SoyadRenk[i] == "k")
                {
                    richTextBox1.SelectionColor = Color.Red;
                }
                else if (SoyadRenk[i] == "m")
                {
                    richTextBox1.SelectionColor = Color.Blue;
                }
                else if (SoyadRenk[i] == "y")
                {
                    richTextBox1.SelectionColor = Color.Green;
                }

                richTextBox1.AppendText(Soyadlar[i] + " ");

                if (TelRenk[i] == "k")
                {
                    richTextBox1.SelectionColor = Color.Red;
                }
                else if (TelRenk[i] == "m")
                {
                    richTextBox1.SelectionColor = Color.Blue;
                }
                else if (TelRenk[i] == "y")
                {
                    richTextBox1.SelectionColor = Color.Green;
                }

                richTextBox1.AppendText(Teller[i] + "\n");

            }           

        }

        public frmKayıtListele()
        {
            InitializeComponent();         
        }

        private void btnKayıtListele_Click(object sender, EventArgs e)
        {
            if (File.Exists("veriler.txt"))  //kayıtların olup olmadığını kontrol ediyoruz
            {
                richTextBox1.Text = null;   //her basımda tekrar tekrar yazmasını önliyoruz
                Ozellik();  //gerekli fonksiyonumuzu çağırıyoruz                
            }
        }

        private void frmKayıtListele_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGiris giris = new frmGiris();       //ana menümüze dönüyoruz
            giris.Show();
        }

        private void frmKayıtListele_Load(object sender, EventArgs e)   //form yüklendiğinde gerekli olan şeyleri yapıyoruz
        {
            if (File.Exists("veriler.txt"))         //dosyanın olup olmadığını kontrol ediyoruz
            {               
                kayıtlar = File.ReadAllLines("veriler.txt"); //bastığımız anda verilerin kayıtlar dizisine aktarılmasını sağlıyoruz
                AdRenk = new string[kayıtlar.Length];
                SoyadRenk = new string[kayıtlar.Length];
                TelRenk = new string[kayıtlar.Length];    //her bir diziye kayıt sayısı kadar yer açıyoruz
                Adlar = new string[kayıtlar.Length];
                Soyadlar = new string[kayıtlar.Length];
                Teller = new string[kayıtlar.Length];
                for (int i = 0; i < kayıtlar.Length; i++)
                {
                    adsayac = 0;
                    soyadsayac = 0;             //sayaclarımızı sıfırlıyoruz ki her seferinde ad soyad ve tel numaralarının uzunlukları aynı olmasın
                    telsayac = 0;
                    AdRenk[i] = kayıtlar[i].Substring(0, 1);
                    SoyadRenk[i] = kayıtlar[i].Substring(1, 1);             //renkleri dizilerine atıyoruz
                    TelRenk[i] = kayıtlar[i].Substring(2, 1);
                    kayıtlar[i] = kayıtlar[i].Substring(4, kayıtlar[i].Length - 4);         //kayıtları sadeleştiriyoruz
                    for (int z = 0; z < kayıtlar[i].Length; z++)
                    {
                        if (Convert.ToString(kayıtlar[i][z]) == " " || z == kayıtlar[i].Length - 1)
                        {
                            if (adsayac == 0)
                            {                                   //ad soyad ve telefon uzunluklarını beliriliyoruz
                                adsayac = z;
                            }
                            else if (adsayac != 0 && soyadsayac == 0)
                            {
                                soyadsayac = z - adsayac - 1;
                            }
                            else if (soyadsayac != 0 && telsayac == 0)
                            {
                                telsayac = z - adsayac - soyadsayac - 1;
                            }
                        }
                    }
                    Adlar[i] = kayıtlar[i].Substring(0, adsayac);
                    Soyadlar[i] = kayıtlar[i].Substring(adsayac + 1, soyadsayac);                 // adları soyadları ve telleri dizilerine atıyoruz
                    Teller[i] = kayıtlar[i].Substring(adsayac + soyadsayac + 2, telsayac);
                }
            }
            else
            {
                richTextBox1.Text = "Kayıt Bulunmamaktadır!!";
            }
        }

    }
}
