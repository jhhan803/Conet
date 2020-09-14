using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Text;

namespace Conet_2DVector
{
    class VVector2D
    {
        public float X { get; private set; } 
        public float Y { get; private set; } 
        public VVector2D(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        public VVector2D()
        {
    
        }
       public void Disp()
        {
            Console.WriteLine($"({X},{Y})");
        }
        public static VVector2D operator+(VVector2D v1, VVector2D v2)
        {
            return new VVector2D(v1.X + v2.X, v1.Y+ v2.Y);
        }
        public static VVector2D operator-(VVector2D v1, VVector2D v2)
        {
            return new VVector2D(v1.X - v2.X, v1.Y - v2.Y);
        }
        public static VVector2D operator*(VVector2D v1, float sc)
        {
            return new VVector2D (v1.X*sc, v1.Y*sc);
        }
        public static VVector2D operator /(VVector2D v1, float sc)
        {
            if(sc==0)
            {
                throw new DivideByZeroException();
            }
            return new VVector2D(v1.X / sc, v1.Y / sc);
        }
        public static VVector2D vectorCopy(VVector2D v1)//,VVector2D v2)
        {
          //  v1.X = v2.X;
           // v1.Y = v2.Y;
            return new VVector2D(v1.X,v1.Y);
        }
        public static bool operator==(VVector2D v1,VVector2D v2)
        {
            return ((v1.X, v1.Y) == (v2.X, v2.Y));
        }
        public static bool operator !=(VVector2D v1, VVector2D v2)
        {
            return ((v1.X, v1.Y) != (v2.X, v2.Y));
        }
    }
}
