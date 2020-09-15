using System;

namespace Conet_2DVector
{
    class Program
    {
        static void Main(string[] args)
        {
            VVector2D v1=  new VVector2D(5f,7f);
            VVector2D v2 = new VVector2D(0f,1f);
            VVector2D v3 = new VVector2D(1f,1f);
            
          //  v1.Disp();
          //  v2.Disp();
          //  v3.Disp();
            //   VVector2D.vectorCopy();
            //    v1.innerVector()
            Console.WriteLine($"두벡터의내적{VVector2D.innerVector(v1,v2)}");
            Console.WriteLine($"두벡터의코사인{VVector2D.cosDot(v1, v2)}");
            Console.WriteLine($"두벡터의각{VVector2D.Dot(v1, v2)}");
            VVector2D.Rotation(v1, 135);
            v1.Disp();
             
            Console.WriteLine($"회전시킨벡터{VVector2D.Rotation(v1,135)}");
        }
    }
}
