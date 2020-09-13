using System;

namespace Conet_ConsoleGame
{
    class Program
    {

        static string[] giho = new string[] { };
        static string[,] stringmap = new string[,] { };
        static int[,] map = new int[,] //┌─┐                                 //ㅂ
        {
            {3,4,5 },
            {6,0,6 },
            {7,4,8 }
        };
        static void figure(int x, int y)
        {
            if (map[x, y] == 0)
            {
                stringmap[x, y] = "  ";
            }
            else if (map[x, y] == 2)
            {
                stringmap[x, y] = "★";
            }
            else if (map[x, y] == 3)
            {
                stringmap[x, y] = "♣";
            }
            else { stringmap[x, y] = "■"; }

        }
        static void Main(string[] args)
        {
            Console.WriteLine((char)127);
        }
    }
}
