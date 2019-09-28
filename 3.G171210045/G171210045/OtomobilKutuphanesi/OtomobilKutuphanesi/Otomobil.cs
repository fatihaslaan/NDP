using System;

namespace OtomobilKutuphanesi
{
    public interface IOtomobil   //otomobilde olucak olan metodları interfacele tanımladık
    {
        void Gaz_Pedalina_Bas();

        void Fren_Pedalina_Bas();

        void Direksiyon_Saga_Cevir();

        void Direksiyon_Sola_Cevir();

        void Kisa_Far_Ac();

        void Uzun_Far_Ac();

        void Far_Kapa();

        void Sinyal_Kapa();

        void Sol_Sinyal_Ac();

        void Sag_Sinyal_Ac();

        void Dortlu_Ac();

        void Kontak_Ac();

        void Kontak_Kapa();

        void Hiz_Gostergesi();

        void Depo_Gostergesi();
    }

    public class Kokpit:Elektronik_Beyin   //kokpitteki aracları tanımladık ve elektroik beyinden kalıtım aldrıdık
    {
        protected enum Direksiyon
        {
            Duz,
            Saga_Donuk,
            Sola_Donuk
        };
       
        protected enum Far_Kumanda_Kolu
        {
            Kapali,
            Kisa_Farlar_Acik,
            Uzun_Farlar_Acik
        };
       
        protected enum Sinyal_Kumanda_Kolu
        {
            Kapali,
            Sol_Sinyal_Acik,
            Sag_Sinyal_Acik,
            Dortlu_Sinyal_Acik
        };
       
        protected enum Gaz_Pedali
        {
            Basildi,
            Basilmadi
        };
       
        protected enum Fren_Pedali
        {
            Basildi,
            Basilmadi
        };
       
        protected enum Kontak_Anahtari
        {
            Acik,
            Kapali
        };

        protected Direksiyon DireksiyonYonu;
        protected Gaz_Pedali GazPedali;
        protected Fren_Pedali FrenPedali;
        protected Kontak_Anahtari Kontak;
        protected Sinyal_Kumanda_Kolu Sinyal;
        protected Far_Kumanda_Kolu Far;

    }

    public class Elektronik_Beyin:Motor
    {                         //elektronik beyinin yöneteceği araclar
        private int tekerlek;
        protected int Tekerlek
        {
            get
            {
                return tekerlek;
            }
            set
            {
                if (value <= 45 && value >= -45)
                    tekerlek = value;
                else if (value > 45)
                    tekerlek = 45;
                else if (value < -45)
                    tekerlek = -45;
            }
        }
        
        protected bool Kisa_Farlar;
        protected bool Uzun_Farlar;
        
        protected bool Sag_Sinyal_Lambalari;
        protected bool Sol_Sinyal_Lambalari;
    }

    public class Motor
    {
        private int sonhiz;
        protected int ivme;           //motor özellikleri
        protected int depo=300;
        protected int yakitharcama;
        private int hiz;
        protected int Hiz
        {
            get
            {
                return hiz;
            }
            set
            {
                if (value <= 220 && value >= 0)
                {
                    hiz = value;
                    sonhiz = hiz;
                }                    
                else
                    hiz=sonhiz;
            }
        }

    }

    public class DizelOtomobil:Kokpit,IOtomobil  //dizel ve benzinli otomobili aynı interfaceden kalıtım aldırdım böylelikle 
    {                                            //kullanıcı interfaceden bi otomobil nesnesi oluşturduğunda arabanın özelliğini secebilecek
        public void Gaz_Pedalina_Bas()
        {
            GazPedali = Gaz_Pedali.Basildi;
            if (Kontak == Kontak_Anahtari.Acik)
            {
                if (depo > 0)
                {
                    Hiz += ivme;
                    depo -= yakitharcama;
                }
                else
                    Console.WriteLine("Depo bitti!");
            }
        }

        public void Fren_Pedalina_Bas()
        {
            FrenPedali = Fren_Pedali.Basildi;
            if (Kontak == Kontak_Anahtari.Acik)
            {
                Hiz -= 10;
            }
        }

        public void Direksiyon_Saga_Cevir()
        {
            if (Kontak == Kontak_Anahtari.Acik)
            {
                Tekerlek += 5;
                if (Tekerlek == 0)
                {
                    DireksiyonYonu = Direksiyon.Duz;
                }
                else if (Tekerlek > 0)
                {
                    DireksiyonYonu = Direksiyon.Saga_Donuk;
                }
                else
                {
                    DireksiyonYonu = Direksiyon.Sola_Donuk;
                }
            }
        }

        public void Direksiyon_Sola_Cevir()
        {
            if (Kontak == Kontak_Anahtari.Acik)
            {
                Tekerlek -= 5;
                if (Tekerlek == 0)
                {
                    DireksiyonYonu = Direksiyon.Duz;
                }
                else if (Tekerlek > 0)
                {
                    DireksiyonYonu = Direksiyon.Saga_Donuk;
                }
                else
                {
                    DireksiyonYonu = Direksiyon.Sola_Donuk;
                }
            }
        }

        public void Kisa_Far_Ac()
        {
            Far = Far_Kumanda_Kolu.Kisa_Farlar_Acik;
            Kisa_Farlar = true;
            Uzun_Farlar = false;
        }

        public void Uzun_Far_Ac()
        {
            Far = Far_Kumanda_Kolu.Uzun_Farlar_Acik;
            Kisa_Farlar = false;
            Uzun_Farlar = true;
        }

        public void Far_Kapa()
        {
            Far = Far_Kumanda_Kolu.Kapali;
            Kisa_Farlar = false;
            Uzun_Farlar = false;
        }

        public void Sinyal_Kapa()
        {
            Sinyal = Sinyal_Kumanda_Kolu.Kapali;
            Sag_Sinyal_Lambalari = false;
            Sol_Sinyal_Lambalari = false;
        }

        public void Sol_Sinyal_Ac()
        {
            Sinyal = Sinyal_Kumanda_Kolu.Sol_Sinyal_Acik;
            Sag_Sinyal_Lambalari = false;
            Sol_Sinyal_Lambalari = true;
        }

        public void Sag_Sinyal_Ac()
        {
            Sinyal = Sinyal_Kumanda_Kolu.Sag_Sinyal_Acik;
            Sag_Sinyal_Lambalari = true;
            Sol_Sinyal_Lambalari = false;
        }

        public void Dortlu_Ac()
        {
            Sinyal = Sinyal_Kumanda_Kolu.Dortlu_Sinyal_Acik;
            Sag_Sinyal_Lambalari = true;
            Sol_Sinyal_Lambalari = true;
        }

        public void Kontak_Ac()
        {
            Kontak = Kontak_Anahtari.Acik;         //araba çalıştırıldığında arabanın özelliğine göre değerler değişiyor
            ivme = 8;
            yakitharcama = 6;
        }

        public void Kontak_Kapa()
        {
            Kontak = Kontak_Anahtari.Kapali;
        }
 
        public void Hiz_Gostergesi()
        {
            if (Kontak == Kontak_Anahtari.Acik)
                Console.WriteLine("Hız:" + Hiz);
        }

        public void Depo_Gostergesi()
        {
            if (Kontak == Kontak_Anahtari.Acik)
                Console.WriteLine("Depo:" + depo);
        }
    }

    public class BenzinliOtomobil : Kokpit, IOtomobil 
    {
        public void Gaz_Pedalina_Bas()
        {
            GazPedali = Gaz_Pedali.Basildi;
            if (Kontak == Kontak_Anahtari.Acik)
            {
                if (depo > 0)
                {
                    Hiz += ivme;
                    depo -= yakitharcama;
                }
                else
                    Console.WriteLine("Depo bitti!");
            }
        }

        public void Fren_Pedalina_Bas()
        {
            FrenPedali = Fren_Pedali.Basildi;
            if (Kontak == Kontak_Anahtari.Acik)
            {
                Hiz -= 10;
            }
        }

        public void Direksiyon_Saga_Cevir()
        {
            if (Kontak == Kontak_Anahtari.Acik)
            {
                Tekerlek += 5;
                if (Tekerlek == 0)
                {
                    DireksiyonYonu = Direksiyon.Duz;
                }
                else if (Tekerlek > 0)
                {
                    DireksiyonYonu = Direksiyon.Saga_Donuk;
                }
                else
                {
                    DireksiyonYonu = Direksiyon.Sola_Donuk;
                }
            }
        }

        public void Direksiyon_Sola_Cevir()
        {
            if (Kontak == Kontak_Anahtari.Acik)
            {
                Tekerlek -= 5;
                if (Tekerlek == 0)
                {
                    DireksiyonYonu = Direksiyon.Duz;
                }
                else if (Tekerlek > 0)
                {
                    DireksiyonYonu = Direksiyon.Saga_Donuk;
                }
                else
                {
                    DireksiyonYonu = Direksiyon.Sola_Donuk;
                }
            }
        }

        public void Kisa_Far_Ac()
        {
            Far = Far_Kumanda_Kolu.Kisa_Farlar_Acik;
            Kisa_Farlar = true;
            Uzun_Farlar = false;
        }

        public void Uzun_Far_Ac()
        {
            Far = Far_Kumanda_Kolu.Uzun_Farlar_Acik;
            Kisa_Farlar = false;
            Uzun_Farlar = true;
        }

        public void Far_Kapa()
        {
            Far = Far_Kumanda_Kolu.Kapali;
            Kisa_Farlar = false;
            Uzun_Farlar = false;
        }

        public void Sinyal_Kapa()
        {
            Sinyal = Sinyal_Kumanda_Kolu.Kapali;
            Sag_Sinyal_Lambalari = false;
            Sol_Sinyal_Lambalari = false;
        }

        public void Sol_Sinyal_Ac()
        {
            Sinyal = Sinyal_Kumanda_Kolu.Sol_Sinyal_Acik;
            Sag_Sinyal_Lambalari = false;
            Sol_Sinyal_Lambalari = true;
        }

        public void Sag_Sinyal_Ac()
        {
            Sinyal = Sinyal_Kumanda_Kolu.Sag_Sinyal_Acik;
            Sag_Sinyal_Lambalari = true;
            Sol_Sinyal_Lambalari = false;
        }

        public void Dortlu_Ac()
        {
            Sinyal = Sinyal_Kumanda_Kolu.Dortlu_Sinyal_Acik;
            Sag_Sinyal_Lambalari = true;
            Sol_Sinyal_Lambalari = true;
        }

        public void Kontak_Ac()
        {
            Kontak = Kontak_Anahtari.Acik;
            ivme = 10;
            yakitharcama = 10;
        }

        public void Kontak_Kapa()
        {
            Kontak = Kontak_Anahtari.Kapali;
        }

        public void Hiz_Gostergesi()
        {
            if (Kontak == Kontak_Anahtari.Acik)
                Console.WriteLine("Hız:" + Hiz);
        }

        public void Depo_Gostergesi()
        {
            if (Kontak == Kontak_Anahtari.Acik)
                Console.WriteLine("Depo:" + depo);
        }
    }
}
