using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Text;
using System.Windows;

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
        public static float operatorscale(VVector2D v1)
        {
            float mathsqrt;
           mathsqrt= (float)Math.Sqrt((Math.Pow(v1.X, 2) + Math.Pow(v1.Y, 2)));
            return mathsqrt;
        }
        public static VVector2D normalize(VVector2D v1)
        {

            float mathsqrt;
            mathsqrt = (float)Math.Sqrt((Math.Pow(v1.X, 2) + Math.Pow(v1.Y, 2)));

            return new VVector2D(v1.X / mathsqrt, v1.Y / mathsqrt);
        }
        public static double innerVector(VVector2D v1,VVector2D v2)
        {
            //if(dot>360)
            //{
            //    throw new DivideByZeroException();
            //}
            double innersum = v1.X * v2.X + v1.Y * v2.Y;
          //  double vLength = operatorscale(v1) * operatorscale(v2);
         //  double theta = innersum / vLength;
         //   double innerD = (double)(Math.Acos(theta) * (180 / Math.PI));
         
         
            return innersum;
        }
        public static double cosDot(VVector2D v1, VVector2D v2)
        {
            //if(dot>360)
            //{
            //    throw new DivideByZeroException();
            //}
            double innersum = v1.X * v2.X + v1.Y * v2.Y;
            double vLength = operatorscale(v1) * operatorscale(v2);
            double theta = innersum / vLength;
            //double innerD = (double)(Math.Acos(theta) * (180 / Math.PI));

   
            return theta;
        }
        public static double Dot(VVector2D v1, VVector2D v2)
        {
            //if(dot>360)
            //{
            //    throw new DivideByZeroException();
            //}
            double innersum = v1.X * v2.X + v1.Y * v2.Y;
            double vLength = operatorscale(v1) * operatorscale(v2);
            double theta = innersum / vLength;
            double innerD = (double)(Math.Acos(theta) * (180 / Math.PI));


            return innerD;
        }
        public static VVector2D Xsymmetry(VVector2D v1)
        {
            return new VVector2D(v1.X, v1.Y * -1);
        }
        public static VVector2D Ysymmetry(VVector2D v1)
        {
            return new VVector2D(v1.X*-1, v1.Y);
        }
        public static VVector2D Rotation(VVector2D v1, float angle)
        {
            double theta = angle * Math.PI / 180;
            return new VVector2D((float)(v1.X * Math.Cos(theta) - v1.Y * Math.Sin(theta)), (float)(v1.X * Math.Sin(theta) + v1.Y * Math.Cos(theta)));
           //(a_1  cos 𝜃−a_2  sin 𝜃, a_1  sin 𝜃+a_2  cos 𝜃);
        }
    }
}
