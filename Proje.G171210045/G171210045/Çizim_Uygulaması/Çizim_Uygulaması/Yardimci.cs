using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Çizim_Uygulaması
{
    static class Yardimci
    {
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

        public enum mouse { sekildemi, secmedemi, bos };      //mousun o an hangi secenekte olduğunu öğrenmek için
        public enum mouse_down { basıldımı, ciziyormu, bos };              //mousa basıldığında şekilin çizilip çizilmediğini yada cismin seçilip seçilmediğini öğrendik
        public enum sekil { kare, daire, ucgen, altigen, bos };               //çizilen şeklin hangi şekil olduğunu öğrenmek için
        public enum renk { Red,Blue,Green,Orange,Black,Yellow,Purple,Maroon,White};      //hangi renkte olduğumuzu anlamak için
        public static mouse mouse_ = mouse.bos;
        public static mouse_down mouse_down_ = mouse_down.bos;
        public static sekil sekil_ = sekil.bos;
        public static renk renk_ = renk.Red;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

        public static List<Sekil> Sekiller = new List<Sekil>();     //şekil clasından bir list oluşturduk böylelikle şekilleri buraya ekleyeceğiz
        private static Brush Renk = Brushes.Red;            //şekilin rengi için
        public static Brush SecimRenk =new SolidBrush(Color.FromArgb(250, Color.Gray));   //seçili olan özelliklerin daha belirgin olması için 
        public static Brush SekilSecimRenk = new SolidBrush(Color.FromArgb(120, Color.Gray));//seçili şekiller için
        private static int Kullanılan_Sekil = 0;        //en son hangi şekilde kaldığımızı gösteriyoruz
        public static int Secilen_Sekil = 0;          //seçtiğimiz şekli bulduğumuzda ondaki işlemleri listteki sayısı sayesinde yapıyoruz
        public static bool SeciliSekil;               //o an herhangi bir cismin seçilip seçilmediğini kontrol ediyoruz

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

        private static string Satir;     //kaydettiğimiz txtden verileri çekerken 
        private static string Sekil;     //bize kolaylık sağlayan değişkenler
        private static string SekilRenk;
        private static int SekilX;
        private static int SekilY;
        private static int SekilXSonu;
        private static int SekilYSonu;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

        private static void Hangi_Sekil()
        {
            if (sekil_ == sekil.kare) //şekil enumuna göre liste yeni bir nesne ekliyor
                Sekiller.Add(new DikDortgen(Renk));
            else if (sekil_ == sekil.daire)
                Sekiller.Add(new Daire(Renk));
            else if (sekil_ == sekil.ucgen) 
                Sekiller.Add(new Ucgen(Renk));
            else if (sekil_ == sekil.altigen) 
                Sekiller.Add(new Altigen(Renk));
            Sekiller[Kullanılan_Sekil].SekilRengi = Convert.ToString(renk_); //ve o an ki rengi şeklin bilgisine kaydediyor
        }

        private static void Sekil_Ara(int ex, int ey)//mousun yerini paremetre olarak alıyor
        {
            for (int i = 0; i < Sekiller.Count; i++)//şekil sayısı kadar dönüyor
            {
                if (Sekiller[i] != null)    //eğer sekil silinmediyse
                {
                    if (Sekiller[i].Icindemi(ex, ey))     //şeklin içinde olup olmadığına bakıyor
                    {
                        Secilen_Sekil = i;  //seçilen şeklin listteki kaçıncı şekil olduğunu gösteriyor
                        SeciliSekil = true;   //şeklin seçili olduğunu gösteriyor
                    }
                    else if(!SeciliSekil)
                        SeciliSekil = false;    //şeklin seçilmedğini gösteriyor
                }
                else if (!SeciliSekil)
                    SeciliSekil = false;          
            }
        }

        public static void Renk_Degisimi()
        {
            Renk = new SolidBrush(Color.FromName(Convert.ToString(renk_)));     //renktki değişimi enumla renge dönüştürüyor
            if (mouse_ == mouse.secmedemi&& SeciliSekil)      //eğer cisim seçili ise
            {
                if (Sekiller[Secilen_Sekil] != null)
                {
                    Sekiller[Secilen_Sekil].color = Renk;    //rengi değiştiriyor
                    Sekiller[Secilen_Sekil].SekilRengi = Convert.ToString(renk_);   //rengin ismini yazıyor
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

        public static void Mouse_Down(int ex,int ey)
        {
            if (mouse_ == mouse.sekildemi)
            { 
                Hangi_Sekil();
                mouse_down_ = mouse_down.ciziyormu;
                Sekiller[Kullanılan_Sekil].X = ex;
                Sekiller[Kullanılan_Sekil].Y = ey;  //basıldığı noktada şeklin X ve Ysini veriyor
            }
            else if (mouse_ == mouse.secmedemi)
            {
                mouse_down_ = mouse_down.basıldımı;  
                Sekil_Ara(ex,ey);                
            }
        }

        public static void Mouse_Move(int ex,int ey)
        {
            if (mouse_ == mouse.sekildemi)
            {
                if (mouse_down_ == mouse_down.ciziyormu)
                {
                    Sekiller[Kullanılan_Sekil].Deger_Ata(ex, ey);   //cismin hareket ettikçe uzunluğunu ve genişliğini ayarlıyor
                }
            }
            else if (mouse_ == mouse.secmedemi)
            {
                if (mouse_down_ == mouse_down.basıldımı&& SeciliSekil)
                {
                    if (Sekiller[Secilen_Sekil] != null)
                    { 
                        Sekiller[Secilen_Sekil].X = ex;
                        Sekiller[Secilen_Sekil].Y = ey;           //şekle basıldıysa hareket ettirebilmemizi sağlıyor 
                    }
                }
            }
        }

        public static void Mouse_Up()
        {
            if (mouse_ == mouse.sekildemi)
            {
                mouse_down_ = mouse_down.bos;
                Kullanılan_Sekil++;   //bir sonraki şekle geçiyoruz
            }
            else if (mouse_ == mouse.secmedemi)
            {
                mouse_down_ = mouse_down.bos;
            }
        }

        public static void  Paint(PaintEventArgs e)
        {
            Graphics cizme = e.Graphics;
            foreach (Sekil sekil in Sekiller)
            {
                if (sekil != null)
                {
                    sekil.Ciz(cizme);          //tüm şekilleri çiziyor
                }
            }
            if (mouse_ == mouse.secmedemi&& SeciliSekil)
            {
                if (Sekiller[Secilen_Sekil] != null&&mouse_!=mouse.sekildemi)
                {
                    Sekiller[Secilen_Sekil].Secili(cizme);   //seçili şekil varsa belirgin olmasını sağlıyor
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

        public static void KayıtAç()
        {
            OpenFileDialog Ac = new OpenFileDialog();
            Ac.Title = "Dosya Açın";
            Ac.Filter = "Text Dosyaları(*.txt)|*.txt";
            if (Ac.ShowDialog() == DialogResult.OK)
            {
                StreamReader oku = new StreamReader(File.OpenRead(Ac.FileName));
                Sekiller = new List<Sekil>();  //yeni bir list oluşturuyoruz
                Kullanılan_Sekil = 0;
                while ((Satir = oku.ReadLine()) != null)
                {
                    Sekil = Satir.Split(',')[0].Substring(6);
                    SekilRenk = Satir.Split(',')[1].Substring(5);
                    SekilX = Convert.ToInt32(Satir.Split(',')[2].Substring(2));           //bilgileri split sayesinde ayırıyoruz 
                    SekilY = Convert.ToInt32(Satir.Split(',')[3].Substring(2));
                    SekilXSonu = Convert.ToInt32(Satir.Split(',')[4].Substring(7));
                    SekilYSonu = Convert.ToInt32(Satir.Split(',')[5].Substring(7));
                    KayıtOku();
                }
                oku.Dispose();
            }
        }

        private static void KayıtOku()
        {              
            Renk = new SolidBrush(Color.FromName(SekilRenk));
            if (Sekil == "Kare")                             //aldığımız bilgileri kontrol edip ona göre yeni şekiller çizdiriyoruz
                Sekiller.Add(new DikDortgen(Renk));
            else if(Sekil=="Daire")
                Sekiller.Add(new Daire(Renk));
            else if (Sekil == "Üçgen")
                Sekiller.Add(new Ucgen(Renk));
            else if (Sekil == "Altıgen")
                Sekiller.Add(new Altigen(Renk));
            Sekiller[Kullanılan_Sekil].X = SekilX;
            Sekiller[Kullanılan_Sekil].Y = SekilY;
            Sekiller[Kullanılan_Sekil].Deger_Ata(SekilXSonu, SekilYSonu);
            Sekiller[Kullanılan_Sekil].SekilRengi = SekilRenk;
            Kullanılan_Sekil++;
        }

        public static void Kaydet()
        {
            SaveFileDialog Kaydet = new SaveFileDialog();
            Kaydet.Title = "Dosya Kaydedin";
            Kaydet.Filter = "Text Dosyaları(*.txt)|*.txt";          //sadece txt kaydedilebilir
            if (Kaydet.ShowDialog() == DialogResult.OK)
            {
                StreamWriter yaz = new StreamWriter(File.Create(Kaydet.FileName));
                for (int i = 0; i < Sekiller.Count; i++)
                {
                    if(Sekiller[i]!=null)//eğer şekil silinmediyse txte yazıyor
                        yaz.WriteLine("Şekil:" + Sekiller[i].isim + ",Renk:" + Sekiller[i].SekilRengi + ",X:" + Sekiller[i].X + ",Y:" + Sekiller[i].Y + ",X sonu:" + Sekiller[i].x_ekseni_sonu + ",Y sonu:" + Sekiller[i].y_ekseni_sonu);
                }         //şeklin her özelliği txte yazılıyor
                yaz.Dispose();
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

        public static void SekilPaint(PaintEventArgs e)
        {
            Graphics cizme = e.Graphics;
            if (mouse_ == mouse.sekildemi)
            {
                if (sekil_ == sekil.kare)
                {
                    cizme.FillRectangle(SecimRenk, 13, 12, 53, 45);
                }
                if (sekil_ == sekil.daire)
                {                                                        //secilen şeklin hangisi olduğunu görmemizi sağlıyor
                    cizme.FillRectangle(SecimRenk, 75, 12, 52, 44);
                }
                if (sekil_ == sekil.ucgen)
                {
                    cizme.FillRectangle(SecimRenk, 13, 55, 53, 45);
                }
                if (sekil_ == sekil.altigen)
                {
                    cizme.FillRectangle(SecimRenk, 75, 55, 52, 44);
                }
            }
        }

        public static void SecimPaint(PaintEventArgs e)
        {
            Graphics cizme = e.Graphics;
            if (mouse_ == mouse.secmedemi)
            {                                         //eğer seçmeye basıldıysa bunu görmemizi sağlıyor
                cizme.FillRectangle(SecimRenk, 14, 16, 52, 43);                
            }
        }

        public static void RenkPaint(PaintEventArgs e)
        {
            Graphics cizme = e.Graphics;
            if (renk_==renk.Red)                  //hangi renk secildiyse secilen rengin belirgin olmasını sağlıyor
                cizme.FillRectangle(SecimRenk, 14, 14, 35, 32);
            if (renk_ == renk.Blue)
                cizme.FillRectangle(SecimRenk, 51, 14, 35, 32);
            if (renk_ == renk.Green)
                cizme.FillRectangle(SecimRenk, 88, 14, 35, 32);
            if (renk_ == renk.Orange)
                cizme.FillRectangle(SecimRenk, 14, 50, 35, 32);
            if (renk_ == renk.Black)
                cizme.FillRectangle(SecimRenk, 51, 50, 35, 32);
            if (renk_ == renk.Yellow)
                cizme.FillRectangle(SecimRenk, 88, 50, 35, 32);
            if (renk_ == renk.Purple)
                cizme.FillRectangle(SecimRenk, 14, 86, 35, 32);
            if (renk_ == renk.Maroon)
                cizme.FillRectangle(SecimRenk, 51, 86, 35, 32);
            if (renk_ == renk.White)
                cizme.FillRectangle(SecimRenk, 88, 86, 35, 32);

        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

        public static bool Sinirdami(int X, int Y, int genislik, int uzunluk)
        {
            if (genislik > 0 && uzunluk > 0)
                if (X > 0 && X + genislik < 525 && Y > 0 && Y + uzunluk < 448)
                    return true;
                else
                    return false;
            else if (genislik < 0 && uzunluk < 0)
                if (X + genislik > 0 && X < 525 && Y + uzunluk > 0 && Y < 448)
                    return true;
                else
                    return false;
            else if (genislik < 0)
                if (X + genislik > 0 && X < 525 && Y + uzunluk > 0 && Y + uzunluk < 448)
                    return true;
                else
                    return false;
             else if (uzunluk < 0)
                if (X + genislik > 0 && X + genislik < 525 && Y + uzunluk > 0 && Y < 448)
                    return true;
                else
                    return false;             
            else
                return false;

        }  //karenin sınır hesabı 4 tane var çünkü 4 farklı yöne çizilebiliyor

        public static bool Sinirdami(int X,int Y, int cap)
        {
            if (X-cap/2 > 0 && X + cap < 525 && Y-cap/2 > 0 && Y +cap < 448)
                return true;
            else
                return false;
        }            //dairenin sınır hesabı

        public static bool AUSinirdami(int X, int Y, int kenar)
        {
            if (X - kenar> 0 && X + kenar < 525 && Y-kenar/1.2F> 0 && Y + kenar/1.2F < 448)  //altıgen ve üçgenin sınırın içinde olup olmadıgına bakıyor
                return true;
            else     
                return false;
        }
    }
}
