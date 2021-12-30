using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using openCV;
using System.Drawing.Imaging;

namespace Index
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openimage = new OpenFileDialog();
            openimage.FileName = " ";
            openimage.Filter = "JPEG|*JPG|Bitmap|*.bmp|All|*.*-11";

            if(openimage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.pictureBox1.Image = new Bitmap(openimage.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bitCoppy = new Bitmap((Bitmap)this.pictureBox1.Image);
            int width = bitCoppy.Width;
            int haigh = bitCoppy.Height;
            for (int i = 0; i < width; i++)
                for (int j = 0; j < haigh; j++)
                {
                    Color c1 = bitCoppy.GetPixel(i, j);
                    int a = c1.A;
                    int r = c1.R;
                    int g = c1.G;
                    int b2 = c1.B;
                    int gray = (r + g + b2) / 3;
                    bitCoppy.SetPixel(i, j, Color.FromArgb(a, gray, gray, gray));
                }
            this.pictureBox2.Image = bitCoppy;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bitCoppy = new Bitmap((Bitmap)this.pictureBox1.Image);
            Bitmap redCoppy = new Bitmap((Bitmap)this.pictureBox1.Image);
            Bitmap blueCoppy = new Bitmap((Bitmap)this.pictureBox1.Image);
            Bitmap greenCoppy = new Bitmap((Bitmap)this.pictureBox1.Image);
            int width = bitCoppy.Width;
            int haigh = bitCoppy.Height;


            for (int y = 0; y < haigh; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color p = bitCoppy.GetPixel(x, y);

                    int alpha = p.A;
                    int red = p.R;
                    int green = p.G;
                    int blue = p.B;

                    redCoppy.SetPixel(x, y, Color.FromArgb(alpha, red, 0, 0));
                    blueCoppy.SetPixel(x, y, Color.FromArgb(alpha, 0, green, 0));
                    greenCoppy.SetPixel(x, y, Color.FromArgb(alpha, 0, 0, blue));

                    this.pictureBox2.Image = redCoppy;
                    this.pictureBox4.Image = blueCoppy;
                    this.pictureBox5.Image = greenCoppy;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bitCoppy = new Bitmap((Bitmap)this.pictureBox1.Image);
            int width = bitCoppy.Width;
            int haigh = bitCoppy.Height;

            Bitmap mimg = new Bitmap(width * 2, haigh);
            for (int i = 0; i < haigh; i++)
            {
                for (int j = 0, rx = width * 2 -1 ; j < width; j++, rx--)
                {
                    Color c = bitCoppy.GetPixel(j, i);
                    mimg.SetPixel(j, i, c);
                    mimg.SetPixel(rx, i, c);

                    this.pictureBox2.Image = mimg;
                }
            }
        }

        
    }
}
