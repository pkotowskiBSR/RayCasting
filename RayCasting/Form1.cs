using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayCasting
{
    public partial class Form1 : Form
    {
        List<Sphere> spheres= new List<Sphere>();
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            spheres.Add(new Sphere(300, 200, 100, 190, Color.Blue));
            spheres.Add(new Sphere(150, 130, 10, 20, Color.Red));
            spheres.Add(new Sphere(100, 100, 20, 40, Color.Green));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                {
                    float zmin = float.PositiveInfinity;
                   foreach (Sphere sphere in spheres)
                   {
                        (bool isIntersect, float z) = sphere.Intersect(x, y);

                        if (isIntersect)
                        {
                            if (z < zmin)
                            {
                                bmp.SetPixel(x, y, sphere.Color);
                                zmin = z;
                            }
                        }
                   }
                }
            pictureBox1.Refresh();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(bmp,0,0);
        }
    }
}
