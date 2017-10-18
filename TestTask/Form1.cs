using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask
{
    public partial class Form1 : Form
    {
        LForm LElement;
        public Form1()
        {
            InitializeComponent();
            LElement = new LForm();
        }
        

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var Penny = new Pen(new SolidBrush(Color.Green));
            Graphics G = e.Graphics;
            PointF[][] PointsForRendering = new PointF[2][];
            FigureTransformer FT = new FigureTransformer();
            PointsForRendering[0] = FT.Projection(FT.Rotate(LElement.Object[0], trackBar1.Value),pictureBox1).ToArray();
            PointsForRendering[1] = FT.Projection(FT.Rotate(LElement.Object[1], trackBar1.Value),pictureBox1).ToArray();
            G.DrawLines(Penny, PointsForRendering[0]);
            G.DrawLine(Penny, PointsForRendering[0][0], PointsForRendering[0][5]);
            G.DrawLines(Penny, PointsForRendering[1]);
            G.DrawLine(Penny, PointsForRendering[1][0], PointsForRendering[1][5]);
            for (int i = 0; i < PointsForRendering[0].Length; i++)
            {
                G.DrawLine(Penny, PointsForRendering[0][i], PointsForRendering[1][i]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1_TextChanged(null, new EventArgs());
            textBox2_TextChanged(null, new EventArgs());
            textBox3_TextChanged(null, new EventArgs());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            float value = 0;
            if (float.TryParse(textBox1.Text,out value))
            {
                LElement.Height = value;
                LElement.GetNewObject();
                pictureBox1.Refresh();
            }
            else
            {
                textBox1.Text = LElement.Height.ToString();
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            float value = 0;
            if (float.TryParse(textBox2.Text, out value))
            {
                LElement.Length = value;
                LElement.GetNewObject();
                pictureBox1.Refresh();
            }
            else
            {
                textBox2.Text = LElement.Length.ToString();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            float value = 0;
            if (float.TryParse(textBox3.Text, out value))
            {
                LElement.Width = value;
                LElement.GetNewObject();
                pictureBox1.Refresh();
            }
            else
            {
                textBox3.Text = LElement.Width.ToString();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            label4.Text = "Угол поворота:" + trackBar1.Value.ToString();
        }
    }
}
