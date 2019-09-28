using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Çizim_Uygulaması
{
    class Ucgen:Sekil
    {
        private int kenar, SK;
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

        public Ucgen(Brush color)
        {
            this.color = color;
            isim = "Üçgen";
        }

        public override void Deger_Ata(int ex, int ey)
        {
            kenar = Math.Abs(X - ex);
        }

        public override bool Icindemi(int ex, int ey)
        {
            if (x_ekseni_sonu > ex && ex > SX - SK)
                if (y_ekseni_sonu > ey && ey > SY - SK / 1.2F)
                    return true;
                else
                    return false;
            else
                return false;
        }

        public override void Ciz(Graphics cizme)
        {
            if (Yardimci.AUSinirdami(X, Y, Kenar))
            {
                SX = X;
                SY = Y;
                SK = Kenar;
            }
            x_ekseni_sonu = SX + SK;
            y_ekseni_sonu = SY + Convert.ToInt32(SK / 1.2F);
            PointF nokta1 = new PointF(SX, SY - SK / 1.2F);
            PointF nokta2 = new PointF(SX + SK, SY + SK / 1.2F);
            PointF nokta3 = new PointF(SX - SK, SY + SK / 1.2F);
            PointF[] noktalar = { nokta1, nokta2, nokta3};
            cizme.FillPolygon(color, noktalar);
        }

        public override void Secili(Graphics cizme)
        {
            cizme.FillRectangle(Yardimci.SekilSecimRenk, (SX - SK) - 7, (SY - SK / 1.2F) - 7, (2 * SK) + 14, (2 * (SK / 1.2F)) + 14);
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
