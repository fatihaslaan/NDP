using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmguCv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btngoster_Click(object sender, EventArgs e)
        {
            Image<Bgr, byte> yeniFoto = new Image<Bgr, byte>(fileName: "1.jpg");
            Image<Bgr, byte> boyutudüzenlenenfoto = yeniFoto.Resize(1020, 380, Emgu.CV.CvEnum.Inter.Linear);
            imgbxresim.Image = boyutudüzenlenenfoto;
            
        }
    }
}
