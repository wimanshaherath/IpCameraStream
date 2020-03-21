using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
namespace Ipcamera
{
    public partial class Form1 : Form
    {
        MJPEGStream Stream;
        //public String streamAddress;
        public Form1()
        {
            InitializeComponent();
            Stream = new MJPEGStream("http://192.168.1.2:4747/video");
            Stream.NewFrame += Stream_NewFrame;
        }

        private void Stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = bmp;
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //streamAddress = txtStream.Text;
            Stream.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stream.Stop();
        }
    }
}
