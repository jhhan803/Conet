using System;

namespace Conet_2DVector
{
    class Program
    {
        static void Main(string[] args)
        {
            VVector2D v1=new VVector2D();
            VVector2D v2 = new VVector2D(3f,5f);
            VVector2D v3 = new VVector2D(11,22);
            
            v1.Disp();
            v2.Disp();
            v3.Disp();
        }
    }
}
