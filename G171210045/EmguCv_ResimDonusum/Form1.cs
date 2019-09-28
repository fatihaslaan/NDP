using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu;
using Emgu.CV;                        //resimler için gerekli
using Emgu.CV.Structure;
namespace EmguCv_ResimDonusum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }     

        private void btnfotoekle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();                                     //resim seçiyoruz
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";  //seçebileceğimiz şeyler
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image<Bgr, byte> images = new Image<Bgr, byte>(ofd.FileName);
                Image<Bgr, byte> resizedImage = images.Resize(510, 180,Emgu.CV.CvEnum.Inter.Linear); //eski resmimiz küçük görünmesin diye boyutunu değiştirip
                imgbxrenkli.Image = resizedImage;                                                    //yeni bir resme aktardık 

                Image<Gray, byte> grifoto = resizedImage.Convert<Gray, byte>();          //renkli resmimizi gri tonlarla başka bir resme aktardık
                imgbxgri.Image = grifoto;

                int threshold = 70;
                Image<Gray, byte> binary = grifoto.ThresholdBinary(new Gray(threshold), new Gray(255));          //gri resmimizi binary yaptık
                imgbxbinary.Image = binary;

                DenseHistogram hist = new DenseHistogram(256, new RangeF(0, 256));
                hist.Calculate(new Image<Gray, Byte>[] { grifoto }, false, null);
                Mat m = new Mat();                                                     //gri resmimizin histogramını aldık
                hist.CopyTo(m);
                histogramBox1.ClearHistogram();
                histogramBox1.AddHistogram("Gri Histogram", Color.Gray, m, 256, new float[] { 0.0f, 256.0f });
                histogramBox1.Refresh();
            }

        }

    }
}
