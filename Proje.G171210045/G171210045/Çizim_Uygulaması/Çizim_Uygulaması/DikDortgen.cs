using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Çizim_Uygulaması
{
    class DikDortgen:Sekil
    {
        private int genislik, uzunluk,SG,SU;   //dikdortgene özel genişlik ,uzunluk, son genişlik değeri ve son uzunluk değeri 
        public DikDortgen (Brush color)
        {
            this.color = color;
            isim = "Kare";
        }

        public override void Deger_Ata(int ex, int ey)
        {
            if (Yardimci.Sinirdami(X, Y, ex - X, ey - Y))
            {
                genislik = ex - X;
                uzunluk = ey - Y;
            }        
        }

        public override void Ciz(Graphics cizme)
        {
            if (Yardimci.Sinirdami(X, Y, genislik, uzunluk))
            {
                SX = X;
                SY = Y;
                SG = genislik;
                SU = uzunluk;
            }   
            cizme.FillRectangle(color, SX, SY, SG, SU);     //dikdörtgenin her yöne doğru çizilebilmesini sağladım bu yüzden dört farklı çiz metodu var
            if (genislik < 0)
                cizme.FillRectangle(color, SX + SG, SY, -SG, SU);            
            if (uzunluk < 0)
                cizme.FillRectangle(color, SX, SY + SU, SG, -SU);
            if (genislik < 0 && uzunluk < 0)
                cizme.FillRectangle(color, SX + SG, SY + SU, -SG, -SU);            
            x_ekseni_sonu = SX + SG;
            y_ekseni_sonu = SY + SU;

        }

        public override bool Icindemi(int ex,int ey)
        {
            if ((x_ekseni_sonu > ex && ex > X) || (x_ekseni_sonu < ex && ex < X))
                if ((y_ekseni_sonu > ey && ey > Y) || y_ekseni_sonu < ey && ey < Y)
                    return true;
                else
                    return false;
            else
                return false;
        }

        public override void Kucult()
        {
            if (genislik < 0)
                genislik += 10;
            if (genislik > 0)
                genislik -= 10;
            if (uzunluk < 0)
                uzunluk += 10;
            if (uzunluk > 0)
                uzunluk -= 10;
        }

        public override void Buyult()
        {
            if (genislik < 0)
                genislik -= 10;
            if(genislik>0)
                genislik += 10;
            if (uzunluk < 0)
                uzunluk -= 10;
            if(uzunluk>0)
                uzunluk += 10;
        }

        public override void Secili(Graphics cizme)
        {
            if(SG>0&&SU>0)
                cizme.FillRectangle(Yardimci.SekilSecimRenk, SX-7, SY-7, SG+14, SU+14);
            if (SG < 0)
                cizme.FillRectangle(Yardimci.SekilSecimRenk, (SX + SG)-7, SY-7, -SG+14, SU+14);
            if (SU < 0)                                                                               //dikdörtgenimiz 4 yana çizilebildiği için her bir tarafın seçili olduğunu gösteren çizim farklı oluyor
                cizme.FillRectangle(Yardimci.SekilSecimRenk, SX-7, (SY + SU)-7, SG+14, -SU+14);
            if (SG < 0 && SU < 0)
                cizme.FillRectangle(Yardimci.SekilSecimRenk, (SX + SG)-7, (SY + SU)-7, -SG+14, -SU+14);
        }

        public override void Esitle()
        {
            if (uzunluk > genislik)
                genislik = uzunluk;  //sadece dikdortgen için var ve dikdörtgeni kare yapmamızı sağlıyor 
            else
                uzunluk = genislik;
        }

    }
}
