using System;
using System.Collections.Generic;
using System.Text;

namespace Conet_Maze
{
    class Character
    {
        static int PoisionX;
        static int PoisionY;
        static int moveDistance;
        bool Gamestate;
        //public bool moveX(int move,int[,] maze)
        //{
        //    Program p = new Program();

        //    int temp;
        //    for (int i = 0; i < 10; i++)
        //    {
        //        for (int j = 0; j < 10; j++)
        //        {
        //            if (maze[i, j] == 2)
        //            {
        //                PoisionX = i;
        //                PoisionY = j;
        //            }
        //        }
        //    }
        //    if (maze[PoisionX + move, PoisionY] == 0)
        //    {
        //        temp = maze[PoisionX, PoisionY];
        //        maze[PoisionX, PoisionY] = maze[PoisionX + move, PoisionY];
        //        maze[PoisionX + move, PoisionY] = temp;
        //        p.moveDistance += 1;
        //    }
        //    else if ((maze[PoisionX + move, PoisionY] == 3))
        //    {
        //        maze[PoisionX + move, PoisionY] = maze[PoisionX, PoisionY];
        //        maze[PoisionX, PoisionY] = 0;
        //        p.moveDistance += 1;
        //     //   Console.SetCursorPosition(0, 21);
        //     //   Console.WriteLine("싱글톤체크");
        //        return false;
        //    }
        //    return true;
        //}
        public Tuple<int, bool> moveX(int move, int[,] maze)
        {
            Program p = new Program();

            int temp;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (maze[i, j] == 2)
                    {
                        PoisionX = i;
                        PoisionY = j;
                    }
                }
            }
            if (maze[PoisionX + move, PoisionY] == 0)
            {
                temp = maze[PoisionX, PoisionY];
                maze[PoisionX, PoisionY] = maze[PoisionX + move, PoisionY];
                maze[PoisionX + move, PoisionY] = temp;
                moveDistance += 1;
            }
            else if ((maze[PoisionX + move, PoisionY] == 3))
            {
                maze[PoisionX + move, PoisionY] = maze[PoisionX, PoisionY];
                maze[PoisionX, PoisionY] = 0;
                moveDistance += 1;
                //   Console.SetCursorPosition(0, 21);
                //   Console.WriteLine("싱글톤체크");
                Gamestate = false;
                return new Tuple<int, bool>(moveDistance, Gamestate);
            }
            Gamestate = true;
            return new Tuple<int, bool>(moveDistance, Gamestate);
        }
        public Tuple<int, bool> moveY(int move, int[,] maze)
        {
            Program p = new Program();
            int temp;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (maze[i, j] == 2)
                    {
                        PoisionX = i;
                        PoisionY = j;
                    }
                }
            }
            if (maze[PoisionX, PoisionY + move] == 0)
            {
                temp = maze[PoisionX, PoisionY];
                maze[PoisionX, PoisionY] = maze[PoisionX, PoisionY + move];
                maze[PoisionX, PoisionY + move] = temp;
                moveDistance += 1;
            }
            else if ((maze[PoisionX, PoisionY + move] == 3))
            {
                maze[PoisionX, PoisionY + move] = maze[PoisionX, PoisionY];
                maze[PoisionX, PoisionY] = 0;
                moveDistance += 1;
                //  Console.SetCursorPosition(0, 21);
                //   Console.WriteLine("싱글톤체크");
                Gamestate = false;
                return new Tuple<int, bool>(moveDistance, Gamestate);
            }
            Gamestate = true;
            return new Tuple<int, bool>(moveDistance, Gamestate);
        }
    }
}
