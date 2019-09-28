using System;
using System.Windows.Forms;

namespace KayıtEkleme
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();            
        }

        private void btnKayıtEkle_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKayıtEkle frm1 = new frmKayıtEkle();        //kayıt ekleme kısmına gidiyoruz
            frm1.Show();
        }

        private void btnKayıtlar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKayıtListele frm2 = new frmKayıtListele();           //kayıtların listeleneceği alan
            frm2.Show();
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();                  //programdan çıkış yapıyoruz
        }

        private void frmGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
