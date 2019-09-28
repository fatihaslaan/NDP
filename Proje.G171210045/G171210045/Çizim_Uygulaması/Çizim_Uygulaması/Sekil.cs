using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Çizim_Uygulaması
{
    abstract class Sekil       //diğer şekillere öncü olması için ve nesne oluşturulamamsı için abstract yaptık
    {
        private int x, y;
        public int x_ekseni_sonu;      //her şekilde olucak olan değişkenler
        public int y_ekseni_sonu;
        public string isim;
        public int SX,SY;   //herhangi bi taşma durumunda taşmadan önceki değerleri korumak için        

        public int X
        {
            get
            {
                return(x);
            }
            set
            {
                if (value > 0)
                    x = value;
            }
        }
        public int Y
        {
            get
            {
                return (y);
            }
            set
            {
                if (value > 0)
                    y = value;
            }
        }

        public string SekilRengi;   //her şekilde onun rengini string olarak tutarsak kaydederken rengi saklayabiliriz
        public Brush color= Brushes.Red;   

        public Sekil()
        {
            x = y = 0;
        }

        public abstract void Deger_Ata(int ex,int ey);// burada genişlik ve yükseklik yada kenar veya çap bilgileri girilecek

        public abstract void Ciz(Graphics cizme);     //şekli çizeceğimiz yer

        public abstract bool Icindemi(int ex, int ey); //şekli seçmek için mousun o cismin içinde olup olmadığını öğrenmeliyiz

        public abstract void Kucult();

        public abstract void Buyult();

        public abstract void Secili(Graphics cizme); //şekli seçtiğimiz zaman etrafında seçildiğini belli edecek çizim

        public virtual void Esitle()
        {

        } //sadece kare kullanacağı için abstract yapmadım

    }
}
