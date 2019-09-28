using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Çizim_Uygulaması
{
    class Daire:Sekil
    {
        private int cap,SC;
        private int Cap
        {
            get
            {
                return cap;
            }
            set
            {
                if (value > 0)
                    cap = value;
                else
                    cap = 0;
            }
        }  //daire için gerekenler        

        public Daire(Brush color)
        {
            this.color = color;
            isim = "Daire";
        }

        public override void Deger_Ata(int ex, int ey)
        {
            Cap = Math.Abs(ex - X);
        }

        public override void Ciz(Graphics cizme)
        {
            if (Yardimci.Sinirdami(X, Y, Cap))
            {
                SX = X;
                SY = Y;
                SC = Cap;
            }
            x_ekseni_sonu = SX + SC;
            y_ekseni_sonu = SY + SC;
            cizme.FillEllipse(color, SX - SC / 2, SY - SC / 2, SC + SC / 2, SC + SC / 2);
        }

        public override bool Icindemi(int ex,int ey)
        {
            if (x_ekseni_sonu > ex && ex > SX-SC/2)
                if (y_ekseni_sonu > ey && ey > SY-SC/2)
                    return true;
                else
                    return false;
            else
                return false;
        }

        public override void Kucult()
        {
            Cap -= 10;
        }

        public override void Buyult()
        {
            Cap += 10;
        }

        public override void Secili(Graphics cizme)
        {
            cizme.FillRectangle(Yardimci.SekilSecimRenk, (SX - SC / 2)-7, (SY - SC / 2)-7, (SC + SC / 2)+14, (SC + SC / 2)+14);                     
        }

    }
}
