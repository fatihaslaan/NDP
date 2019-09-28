using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Çizim_Uygulaması
{
    class Altigen : Sekil
    {
        private int kenar,SK;//altıgende kullanılacak olan kenar ve kenarın son durumu
        private int Kenar
        {
            get
            {
                return kenar;
            }
            set
            {
                if (value > 0)
                    kenar = value;
                else
                    kenar = 0;
            }
        }

        public Altigen(Brush color)
        {
            this.color = color;  //altıgen çağrıldığında ismi ve rengi
            isim = "Altıgen";
        }

        public override void Deger_Ata(int ex, int ey)
        {
            kenar = Math.Abs(X-ex); //mouse a göre kenar uzunluğu
        }

        public override bool Icindemi(int ex, int ey)
        {
            if (x_ekseni_sonu > ex && ex > SX-SK)   //mouseun şeklin içinde olup olmadığına bakıyoruz
                if (y_ekseni_sonu > ey && ey > SY - SK/1.2F)
                    return true;
                else
                    return false;
            else
                return false;
        }

        public override void Ciz(Graphics cizme)
        {
            if (Yardimci.AUSinirdami(X, Y, Kenar))//altıgene ve üçgene  özel hesap
            {
                SX = X;
                SY = Y;            //cisimlerin sınırın içerisinde olduğu sürece o anki konumlarını çizdirmek
                SK = Kenar;        //ve sınırın dışına taşdığında en sonki durumlarını çizdirebilmek için kullanıyoruz
            }
            x_ekseni_sonu = SX + SK;               //x ve y eksenlerinin son kısımlarını veriyoruz ki böylece kaydederken ve seçerken kolaylık sağlasın
            y_ekseni_sonu = SY + Convert.ToInt32(SK/1.2F);
            PointF nokta1 = new PointF(SX - SK / 2, SY - SK / 1.2F); //bir altıgen oluşturmak için her bir noktanın birbirine bağlanması gerekiyor
            PointF nokta2 = new PointF(SX + SK / 2, SY - SK / 1.2F);
            PointF nokta3 = new PointF(SX + SK, SY);
            PointF nokta4 = new PointF(SX + SK / 2, SY + SK / 1.2F);
            PointF nokta5 = new PointF(SX - SK / 2, SY + SK / 1.2F);
            PointF nokta6 = new PointF(SX - SK, SY);
            PointF[] noktalar = { nokta1, nokta2, nokta3, nokta4, nokta5, nokta6 };
            cizme.FillPolygon(color, noktalar);
        }

        public override void Secili(Graphics cizme)
        {
            cizme.FillRectangle(Yardimci.SekilSecimRenk, (SX - SK)-7, (SY - SK / 1.2F)-7, (2 * SK)+14,(2 * (SK / 1.2F))+14);//çizdiğimiz şeklin seçili olduğunu belli ediyoruz
        }

        public override void Kucult()
        {
            Kenar -= 10;
        }

        public override void Buyult()
        {
            Kenar += 10;
        }
    }
}
