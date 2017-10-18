using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
     class Point3D
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float H { get; set; }

        public Point3D(float x=0, float y=0, float z=0, float h=1)
        {
            X = x;
            Y = y;
            Z = z;
            H = h;
        }

        public Point3D Normalize()
        {
            return new Point3D(X / H, Y / H, Z / H);
        }
        
        public float[] ToArray()
        {
            return new float[] { X, Y, Z, H };
        }

        public Point3D Move(float x = 0, float y = 0, float z = 0)
        {
            return new Point3D(this.X + x, this.Y + y, this.Z + z, this.H);
        }
    }
}
