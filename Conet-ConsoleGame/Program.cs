using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Linq;
using System.Threading;

namespace Conet_ConsoleGame
{
    class Program
    {
        static bool gamestate = false;
        static int[] playerHorse = new int[] { 101, 102, 103, 104};
        static int[] enemyHorse = new int[] { 201, 202, 203, 204 };
        static string[] stringmap = new string[4] { "  ", "□", "▣" ,"◆"};
        static int[,] Printmap = new int[,]
        {
          {2, 1, 1, 0, 1, 1, 2 },
          {1, 1, 0, 0, 0, 1, 1 },
          {1, 0, 1, 0, 1, 0, 1 },
          {0, 0, 0, 2, 0, 0, 0 },
          {1, 0, 1, 0, 1, 0, 1 },
          {1, 1, 0, 0, 0, 1, 1 },
          {2, 1, 1, 0, 1, 1, 3 },
        };
        static int[,] BackUpmap = new int[,]
     {
          {2, 1, 1, 0, 1, 1, 2 },
          {1, 1, 0, 0, 0, 1, 1 },
          {1, 0, 1, 0, 1, 0, 1 },
          {0, 0, 0, 2, 0, 0, 0 },
          {1, 0, 1, 0, 1, 0, 1 },
          {1, 1, 0, 0, 0, 1, 1 },
          {2, 1, 1, 0, 1, 1, 3 },
     };
        static int[,] map = new int[,]
 {
          {10, 9,  8,  0,  7,  6,  5 },
          {11, 20, 0,  0,  0,  24, 4 },
          {12, 0,  21, 0,  25, 0,  3 },
          {0,  0,  0,  30, 0,  0,  0 },
          {13, 0,  22, 0,  26,  0, 2 },
          {14, 23, 0,  0,  0,  27, 1 },
          {15, 16, 17, 0,  18, 19, 0 },
         };

        //테스트
        static void ShowPanel()
        {
            Console.SetCursorPosition(0, 0);
           for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j * 4, i * 2);
                    if (Printmap[i, j] == 0)
                    {
                        Console.Write(stringmap[0]);
                    }
                    else if (Printmap[i, j] == 1)
                    {
                        Console.Write(stringmap[1]);
                    }
                    else if(Printmap[i, j]>=101&& Printmap[i, j] <= 104)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(stringmap[3]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (Printmap[i, j] >= 201 && Printmap[i, j] <= 204)
                    {
                        Console.Write(stringmap[3]);
                    }
                    else
                    {
                        Console.Write(stringmap[2]);

                    }
                }
            }
        }
        static void Main(string[] args)
        {
              Init();
            while (gamestate)
            {
                Update();
                Render();
            }
            ShowPanel();
        }
        static void Init()
        {
            gamestate = true;
        
            ShowPanel();
            CreateHorse(1);

        }
        static void Update()
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey();
                if(key.Key==ConsoleKey.Spacebar)
            {
                ThrowYut(101);
            }
        }
        static void Render() {
            ShowPanel();
        }
        static void PlayerTurn()
        {
            
        }
        static void CreateHorse(int number)
        {
            //if(number ==1)
            // {
            Console.ForegroundColor = ConsoleColor.Red;
                Printmap[6, 6] = 101;
            Console.ForegroundColor = ConsoleColor.White;
            //}
        }
        static void ThrowYut(int horseNumber)                     //추가해야할 기능
        {                                                         //1. 윷,모,말을 잡았을때 한번더 던지기
            int[] yut = new int[3];                               //2. 2번이상 던졌을때 뭘로 어떻게 움직일지 정하기
            int hiddenyut;                                        //3. 말 업기
            Random rand = new Random();                           //4. 말 이동
            for (int i = 0; i < 3; i++)                                  //5. 말 생성
            { yut[i] = rand.Next(0, 2);
                Console.SetCursorPosition(20, 20+i);
                Console.Write($"윷{i}번째 {yut[i]}");
               
            }                            //6. ui만들기
            hiddenyut = rand.Next(0, 1);
            Console.SetCursorPosition(20, 23);
            Console.Write($"윷{4}번째 {hiddenyut}");

            if ((yut[1] + yut[2] + yut[0] + hiddenyut) == 4)
            {
                Move(horseNumber, 5);
            }
           else if ((yut[1] + yut[2] + yut[0] + hiddenyut) == 3)
            {
                Move(horseNumber, 3);
            }
           else if ((yut[1] + yut[2] + yut[0] + hiddenyut) == 2)
            {
                Move(horseNumber, 2);
            }
           else if ((yut[1] + yut[2] + yut[0] + hiddenyut) == 1)
            {
                if (hiddenyut == 1)
                { Move(horseNumber, -1); }
                else
                    Move(horseNumber, 1);
            }
           else if ((yut[1] + yut[2] + yut[0] + hiddenyut) == 0)
            {
                Move(horseNumber, 4);
            }

        }
        static void Move(int HorseNumber, int moveCount)
        {
            Console.SetCursorPosition(20, 24);
            Console.WriteLine($"움직인 횟수{moveCount}");
            int moveTarget = 0;
            int horseX = 0;
            int horseY = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)  //배열에 있는 플레이어 위치 쳌
                {
                   
                    if (HorseNumber == Printmap[i, j])
                    {
                        moveTarget = map[i, j];
                        horseX = i;
                        horseY = j;
                    }
                }
            }


            for (int k = 0; k < moveCount; k++)
            {
                //캐치or캐리 추가할것
                if (moveTarget == 5 && k== 0)
                {
                    moveTarget = 24;
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)  //일반이동
                        {
                            if (moveTarget == map[i, j])
                            {
                                Printmap[i, j] = HorseNumber;
                                Printmap[horseX, horseY] = BackUpmap[horseX, horseY];
                                horseX = i;
                                horseY = j;
                            }
                        }
                    }
                }
                else if (moveTarget == 10 && k == 0)
                {
                    moveTarget = 20;
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)  //일반이동
                        {
                            if (moveTarget == map[i, j])
                            {
                                Printmap[i, j] = HorseNumber;
                                Printmap[horseX, horseY] = BackUpmap[horseX, horseY];
                                horseX = i;
                                horseY = j;
                            }
                        }
                    }
                }
                else if (moveTarget == 30 && k == 0)
                {
                    moveTarget = 26;
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)  //일반이동
                        {
                            if (moveTarget == map[i, j])
                            {
                                Printmap[i, j] = HorseNumber;
                                Printmap[horseX, horseY] = BackUpmap[horseX, horseY];
                                horseX = i;
                                horseY = j;
                            }
                        }
                    }
                }
                else if (moveTarget == 30 && k != 0)
                {
                    moveTarget = 26;
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)  //일반이동
                        {
                            if (moveTarget == map[i, j])
                            {
                                Printmap[i, j] = HorseNumber;
                                Printmap[horseX, horseY] = BackUpmap[horseX, horseY];
                                horseX = i;
                                horseY = j;
                            }
                        }
                    }
                }
                else if ( moveTarget == 25)
                {
                    moveTarget = 30;
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)  //일반이동
                        {
                            if (moveTarget == map[i, j])
                            {
                                Printmap[i, j] = HorseNumber;
                                Printmap[horseX, horseY] = BackUpmap[horseX, horseY];
                                horseX = i;
                                horseY = j;
                            }
                        }
                    }
                }
                else if (moveTarget == 21&&k!=0)
                {
                    moveTarget = 26;
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)  //일반이동
                        {
                            if (moveTarget == map[i, j])
                            {
                                Printmap[i, j] = HorseNumber;
                                Printmap[horseX, horseY] = BackUpmap[horseX, horseY];
                                horseX = i;
                                horseY = j;
                            }
                        }
                    }
                }
                else if (moveTarget == 23)
                {
                    moveTarget = 15;
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)  //일반이동
                        {
                            if (moveTarget == map[i, j])
                            {
                                Printmap[i, j] = HorseNumber;
                                Printmap[horseX, horseY] = BackUpmap[horseX, horseY];
                                horseX = i;
                                horseY = j;
                            }
                        }
                    }
                }
                else if (moveTarget == 27 || moveTarget == 19)
                {
                    moveTarget = 0;
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)  //일반이동
                        {
                            if (moveTarget == map[i, j])
                            {
                                Printmap[i, j] = HorseNumber;
                                Printmap[horseX, horseY] = BackUpmap[horseX, horseY];
                                horseX = i;
                                horseY = j;
                            }
                        }
                    }
                }
                else if(moveTarget==0&&k!=0)
                {
                    Printmap[horseX, horseY] = BackUpmap[horseX, horseY];
                    CreateHorse(101);
                }

                else if (moveTarget <= 26 && moveTarget != 21 && moveTarget != 23 && moveTarget != 25 && moveTarget != 19)
                {
                    moveTarget += 1;
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)  //일반이동
                        {
                            if (moveTarget == map[i, j])
                            {
                                Printmap[i, j] = HorseNumber;
                                Printmap[horseX, horseY] = BackUpmap[horseX, horseY];
                                horseX = i;
                                horseY = j;
                            }
                        }
                    }
                }
             
            }
        }
        static void MoveRender(int HorseNumber,int moveTarget, int horseX, int horseY)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)  //일반이동
                {
                    if (moveTarget == map[i, j])
                    {
                        Printmap[i, j] = HorseNumber;
                        Printmap[horseX, horseY] = BackUpmap[horseX, horseY];
                        horseX = i;
                        horseY = j;
                    }
                }
            }
        }
} }

