using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class LForm
    {
        public float Height { get; set;}
        public float Width { get; set; }
        public float Length { get; set; }
        public List<Point3D>[] Object { get; set; }

        public LForm(float h=150,float l=100, float w=20)
        {
            Height = h;
            Length = l;
            Width = w;
        }
        public List<Point3D> Get2DFigure()
        {
           //6┌─┐5
           // │ │4
           // │ └──┐3
           //1└────┘2

            List<Point3D> result = new List<Point3D>();
            //1
            result.Add(new Point3D(-((float)Length) / 2, -(float)Height / 2, 0));
            //2
            result.Add(new Point3D(((float)Length) / 2, -(float)Height / 2, 0));
            //3
            result.Add(new Point3D(((float)Length) / 2, -(float)Height/4, 0));
            //4
            result.Add(new Point3D(-((float)Length) / 6, -(float)Height / 4, 0));
            //5
            result.Add(new Point3D(-((float)Length) / 2 + ((float)Length) / 3, (float)Height/2, 0));
            //6
            result.Add(new Point3D(-((float)Length) / 2, (float)Height/2, 0));

            return result;
        }
        public List<Point3D>[] Get3DFigure(List<Point3D> L)
        {
            List<Point3D>[] L3D = new List<Point3D>[2];
            L3D[0] = L;
            L3D[1] = new List<Point3D>();
            foreach(var point in L)
            {
                L3D[1].Add(point.Move(0,0,Width));
            }
            return L3D;
        }
        public void GetNewObject()
        {
            Object = Get3DFigure(Get2DFigure());
        }

    }
}
