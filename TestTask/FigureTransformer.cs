using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TestTask
{
    class FigureTransformer
    {

        public Point3D TransformPoint(Point3D point, float[,] matrix)
        {
            Point3D result = new Point3D();
            for (int i = 0; i < 4; i++)
            {
                result.X += matrix[0, i] * point.ToArray()[i];
            }
            for (int i = 0; i < 4; i++)
            {
                result.Y += matrix[1, i] * point.ToArray()[i];
            }
            for (int i = 0; i < 4; i++)
            {
                result.Z += matrix[2, i] * point.ToArray()[i];
            }
            float H = 0;
            for (int i = 0; i < 4; i++)
            {
                H += matrix[3, i] * point.ToArray()[i];
            }
            result.H = H;
            return result.Normalize();
        }

        public PointF Projection(Point3D point)
        {
            float[,] mat =
            {
                {1,0,0,0},
                {0,1,0,0},
                {-0.35f,-0.35f,0,0},
                {0,0,0,1}
            };
            Point3D buff = TransformPoint(point, mat).Normalize();
            return new PointF(buff.X, buff.Y);
        }

        public List<PointF> Projection(List<Point3D> points, PictureBox canvas)
        {
            
            List<PointF> result = new List<PointF>();
            float[,] mat =
            {
                {1,0,0,0},
                {0,1,0,0},
                {-0.35f,-0.35f,0,0},
                {0,0,0,1}
            };
            foreach(var point in points)
            {
                Point3D buff = TransformPoint(point, mat).Normalize();
                result.Add(new PointF(canvas.ClientSize.Width/2f+buff.X, canvas.ClientSize.Height/2f-buff.Y));
            }
            return result;
        }

        public Point3D Rotate(Point3D point, int degree)
        {
            double fi = Math.PI / 180 * degree;
            float[,] rotmat =
            {
            {(float)Math.Cos(fi),0,(float)-Math.Sin(fi),0 },
            {0,1,0,0},
            {(float)Math.Sin(fi),0,(float)Math.Cos(fi),0 },
            {0,0,0,1}
            };
            return TransformPoint(point, rotmat);
        }

        public List<Point3D> Rotate(List<Point3D> points, int degree)
        {
            double fi = Math.PI / 180 * degree;
            List<Point3D> result = new List<Point3D>();
            float[,] rotmat =
            {
            {(float)Math.Cos(fi),0,(float)-Math.Sin(fi),0 },
            {0,1,0,0},
            {(float)Math.Sin(fi),0,(float)Math.Cos(fi),0 },
            {0,0,0,1}
            };
            foreach(var p in points)
            {
                result.Add(TransformPoint(p, rotmat));
            }
            return result;
        }
    }
}
