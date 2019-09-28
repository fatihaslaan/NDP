/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**			         BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				          NESNEYE DAYALI PROGRAMLAMA DERSİ
**
**				PROJE ÖDEVİ
**				ÖĞRENCİ ADI: Fatih Aslan
**				ÖĞRENCİ NUMARASI: G171210045
**				DERS GRUBU: C
****************************************************************************/
using System;
using System.Windows.Forms;

namespace Çizim_Uygulaması
{
    public partial class FrmCizim : Form
    {
        public FrmCizim()
        {
            InitializeComponent();
            DoubleBuffered = true;        //çizimin hızlanması için
        }
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

        private void btnKare_Click(object sender, EventArgs e)
        {
            pctrbxResim.Cursor = Cursors.Cross;    //görsellik için
            Yardimci.mouse_ =Yardimci.mouse.sekildemi;   //mousun durumunu
            Yardimci.sekil_ = Yardimci.sekil.kare;       //şeklin durumunu veriyor
            pctrbxResim.Refresh();
            grpbxSekil.Refresh();            //seklin seçildiğinde diğer yerlerdeki seçimlerin tazelenmesi için
            grpbxSecim.Refresh();
        }

        private void btnDaire_Click(object sender, EventArgs e)
        {
            pctrbxResim.Cursor = Cursors.Cross;
            Yardimci.mouse_ = Yardimci.mouse.sekildemi;
            Yardimci.sekil_ = Yardimci.sekil.daire;
            pctrbxResim.Refresh();
            grpbxSekil.Refresh();
            grpbxSecim.Refresh();
        }

        private void btnÜçgen_Click(object sender, EventArgs e)
        {
            pctrbxResim.Cursor = Cursors.Cross;
            Yardimci.mouse_ = Yardimci.mouse.sekildemi;
            Yardimci.sekil_ = Yardimci.sekil.ucgen;
            pctrbxResim.Refresh();
            grpbxSekil.Refresh();
            grpbxSecim.Refresh();
        }

        private void btnAltıgen_Click(object sender, EventArgs e)
        {
            pctrbxResim.Cursor = Cursors.Cross;
            Yardimci.mouse_ = Yardimci.mouse.sekildemi;
            Yardimci.sekil_ = Yardimci.sekil.altigen;
            pctrbxResim.Refresh();
            grpbxSekil.Refresh();
            grpbxSecim.Refresh();
        }

//-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

        private void pctrbxResim_MouseDown(object sender, MouseEventArgs e)
        {
            Yardimci.Mouse_Down(e.X, e.Y);       //yaptığımız yardımcı statik clasına bilgi gönderiyoruz
            pctrbxResim.Refresh();
        }    

        private void pctrbxResim_MouseMove(object sender, MouseEventArgs e)
        {
            Yardimci.Mouse_Move(e.X, e.Y);
            if(Yardimci.mouse_==Yardimci.mouse.secmedemi&&Yardimci.mouse_down_==Yardimci.mouse_down.basıldımı&&Yardimci.SeciliSekil)
                pctrbxResim.Cursor = Cursors.SizeAll;        //görsellik için
            if (Yardimci.mouse_down_ == Yardimci.mouse_down.ciziyormu|| Yardimci.mouse_down_ == Yardimci.mouse_down.basıldımı)
                pctrbxResim.Refresh();
           
        }

        private void pctrbxResim_MouseUp(object sender, MouseEventArgs e)
        {
            Yardimci.Mouse_Up();
            if (Yardimci.mouse_ == Yardimci.mouse.secmedemi && Yardimci.mouse_down_ == Yardimci.mouse_down.bos)
                pctrbxResim.Cursor = Cursors.Hand;    //görsellik için
        }

        private void pctrbxResim_Paint(object sender, PaintEventArgs e)
        {
            Yardimci.Paint(e);
        }

//-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

        private void btnKırmızı_Click(object sender, EventArgs e)
        {
            Yardimci.renk_ = Yardimci.renk.Red;     //rengin hangisi olduğunu seçiyoruz
            Yardimci.Renk_Degisimi();
            if (Yardimci.mouse_==Yardimci.mouse.secmedemi)
                pctrbxResim.Refresh();
            grpbxRenk.Refresh();
        }

        private void btnMavi_Click(object sender, EventArgs e)
        {
            Yardimci.renk_ = Yardimci.renk.Blue;
            Yardimci.Renk_Degisimi();
            if (Yardimci.mouse_ == Yardimci.mouse.secmedemi)
                pctrbxResim.Refresh();
            grpbxRenk.Refresh();
        }

        private void btnYeşil_Click(object sender, EventArgs e)
        {
            Yardimci.renk_ = Yardimci.renk.Green;
            Yardimci.Renk_Degisimi();
            if (Yardimci.mouse_ == Yardimci.mouse.secmedemi)
                pctrbxResim.Refresh();
            grpbxRenk.Refresh();
        }

        private void btnTuruncu_Click(object sender, EventArgs e)
        {
            Yardimci.renk_ = Yardimci.renk.Orange;
            Yardimci.Renk_Degisimi();
            if (Yardimci.mouse_ == Yardimci.mouse.secmedemi)
                pctrbxResim.Refresh();
            grpbxRenk.Refresh();
        }

        private void btnSiyah_Click(object sender, EventArgs e)
        {
            Yardimci.renk_ = Yardimci.renk.Black;
            Yardimci.Renk_Degisimi();
            if (Yardimci.mouse_ == Yardimci.mouse.secmedemi)
                pctrbxResim.Refresh();
            grpbxRenk.Refresh();
        }

        private void btnSarı_Click(object sender, EventArgs e)
        {
            Yardimci.renk_ = Yardimci.renk.Yellow;
            Yardimci.Renk_Degisimi();
            if (Yardimci.mouse_ == Yardimci.mouse.secmedemi)
                pctrbxResim.Refresh();
            grpbxRenk.Refresh();
        }

        private void btnMor_Click(object sender, EventArgs e)
        {
            Yardimci.renk_ = Yardimci.renk.Purple;
            Yardimci.Renk_Degisimi();
            if (Yardimci.mouse_ == Yardimci.mouse.secmedemi)
                pctrbxResim.Refresh();
            grpbxRenk.Refresh();
        }

        private void btnKoyuKırmızı_Click(object sender, EventArgs e)
        {
            Yardimci.renk_ = Yardimci.renk.Maroon;
            Yardimci.Renk_Degisimi();
            if (Yardimci.mouse_ == Yardimci.mouse.secmedemi)
                pctrbxResim.Refresh();
            grpbxRenk.Refresh();
        }

        private void btnBeyaz_Click(object sender, EventArgs e)
        {
            Yardimci.renk_ = Yardimci.renk.White;
            Yardimci.Renk_Degisimi();
            if (Yardimci.mouse_ == Yardimci.mouse.secmedemi)
                pctrbxResim.Refresh();
            grpbxRenk.Refresh();
        }

//-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

        private void btnSeçme_Click(object sender, EventArgs e)
        {
            pctrbxResim.Cursor = Cursors.Hand;  //görsellik
            Yardimci.mouse_ = Yardimci.mouse.secmedemi;
            grpbxSekil.Refresh();
            grpbxSecim.Refresh();
        }

        private void btnSilme_Click(object sender, EventArgs e)
        {
            if (Yardimci.SeciliSekil)
                Yardimci.Sekiller[Yardimci.Secilen_Sekil] = null;        
            pctrbxResim.Refresh();
        }

        private void btnSilme_KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < Yardimci.Sekiller.Count; i++)
            {                                                      //bir cisim sildikten sonra tüm cisimleri tek tek silmek istemiyorsak 
                Yardimci.Sekiller[i] = null;                    //bir cismi sildikten sonra herhngi bir tuşla hepsini silebiliriz
            }
            pctrbxResim.Refresh();
        }

//-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

        private void btnKayıtAç_Click(object sender, EventArgs e)
        {
            Yardimci.KayıtAç();
            pctrbxResim.Refresh();
            Yardimci.Renk_Degisimi();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Yardimci.Kaydet();
        }

//-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

        private void btnKucult_Click(object sender, EventArgs e)
        {
            if (Yardimci.Sekiller[Yardimci.Secilen_Sekil] != null&&Yardimci.SeciliSekil)
            {
                Yardimci.Sekiller[Yardimci.Secilen_Sekil].Kucult();                            //seçtiğimiz cismin boyutunu çizdikten sonrada değiştirebilmek için
                pctrbxResim.Refresh();
            }
        }

        private void btnBuyult_Click(object sender, EventArgs e)
        {
            if (Yardimci.Sekiller[Yardimci.Secilen_Sekil] != null && Yardimci.SeciliSekil)
            {
                Yardimci.Sekiller[Yardimci.Secilen_Sekil].Buyult();
                pctrbxResim.Refresh();
            }
        }

        private void btnEsitle_Click(object sender, EventArgs e)   //sadece kare için çalışıyor çünkü diğer cisimler orantılı olarak çiziliyor
        {
            if(Yardimci.Sekiller[Yardimci.Secilen_Sekil] != null && Yardimci.SeciliSekil)
            {
                Yardimci.Sekiller[Yardimci.Secilen_Sekil].Esitle();
                pctrbxResim.Refresh();
            }
        }

//-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\
        private void grpbxSecim_Paint(object sender, PaintEventArgs e)
        {
            Yardimci.SecimPaint(e);   
        }       //yaptığımız seçimler belirgin olsun diye

        private void grpbxRenk_Paint(object sender, PaintEventArgs e)
        {
            Yardimci.RenkPaint(e);
        }

        private void grpbxSekil_Paint(object sender, PaintEventArgs e)
        {
            Yardimci.SekilPaint(e);
        }
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

    }
}
