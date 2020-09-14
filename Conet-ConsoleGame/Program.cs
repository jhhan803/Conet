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
        static int playHorse = 4;
        static int enemyHorse = 4;
        static int fieldplayer = 0;
        static int Enemyplayer = 0;
        static string[] stringmap = new string[2] {"  ", "□" };
        static int[,] map = new int[,]
      {    
          {3, 1,  1, 0, 1, 23, 2 },
          {34,33, 0, 0, 0, 22, 1 },
          {1, 0,  1, 0, 1, 0,  1 },
          {0, 0,  0, 5, 0, 0,  0 },
          {1, 0,  1, 0, 55,0,  1 },
          {1, 1,  0, 0, 0, 1,  1 },
          {4, 44, 1, 0, 1, 1,  9 },

        };
        static int[,] BackUpmap = new int[,]
 {
          {0,3, 1,  1, 0, 1, 23, 2 },
          {0,34,33, 0, 0, 0, 22, 1 },
          {0,1, 0,  1, 0, 1, 0,  1 },
          {0,0, 0,  0, 5, 0, 0,  0 },
          {0,1, 0,  1, 0, 55,0,  1 },
          {0,1, 1,  0, 0, 0, 1,  1 },
          {0,4, 44, 1, 0, 1, 1,  9 },

   };


        static void ShowPanel()
        {

           for(int i=0;i< map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j*4, i*2);
                    if (map[i,j]==0)
                    {
                        Console.Write(stringmap[0]);
                    }
                    else
                    {
                        Console.Write(stringmap[1]);
                    }

            
                    

                }
                
           }
        }
        static void Main(string[] args)
        {
            while(gamestate)
            {

            }
             ShowPanel();
        }
        static void Init()
        {

        }
        static void Update()
        {

        }
        static void Render() { }
        static void PlayerTurn()
        {
            if(playHorse>0&&fieldplayer<=0)
            {
                CreateHorse(1);
            }
        }
        static void CreateHorse(int number)
        {

        }
        static void ThrowYut(int horseNumber)                     //추가해야할 기능
        {                                                         //1. 윷,모,말을 잡았을때 한번더 던지기
            int[] yut = new int[3];                               //2. 2번이상 던졌을때 뭘로 어떻게 움직일지 정하기
            int hiddenyut;                                        //3. 말 업기
            Random rand = new Random();                           //4. 말 이동
            for(int i=0;i<4;i++)                                  //5. 말 생성
            { yut[i]=rand.Next(0,1); }                            //6. ui만들기
            hiddenyut = rand.Next(0, 1);
            if((yut[1]+ yut[2] + yut[3] +hiddenyut)==4)
            {
                Move(horseNumber, 5);
            }
            if ((yut[1] + yut[2] + yut[3] + hiddenyut) == 3)
            {
                Move(horseNumber, 3);
            }
            if ((yut[1] + yut[2] + yut[3] + hiddenyut) == 2)
            {
                Move(horseNumber, 2);
            }
            if ((yut[1] + yut[2] + yut[3] + hiddenyut) == 1)
            {
               if(hiddenyut==1)
                { Move(horseNumber, -1); }
               else
                Move(horseNumber, 1);
            }
            if ((yut[1] + yut[2] + yut[3] + hiddenyut) == 0)
            {
                Move(horseNumber, 4);
            }

        }
        static void Move(int HorseNumber, int moveCount)
        {
            int moveTargetX=0;
            int moveTargetY=0;
            for (int i=0;i<map.GetLength(0);i++)
            {
                for(int j=0;j<map.GetLength(1);i++)
                {
                    if(HorseNumber==map[i,j])
                    {
                        moveTargetX = i;
                        moveTargetY = j;
                    }
                }
            }
            for(int i=0; i<moveCount;i++)
            {
                if(moveTargetX == 8&& moveTargetY == 0)
                {
                    map[moveTargetX-1, moveTargetY +1] = HorseNumber;
                    map[moveTargetX, moveTargetY] = BackUpmap[moveTargetX, moveTargetY];
                }

                    if (moveTargetX==8)
                {
                    if(map[moveTargetX,moveTargetY-1]==0)
                    {
                        map[moveTargetX, moveTargetY -2] = HorseNumber;
                        map[moveTargetX, moveTargetY] = BackUpmap[moveTargetX, moveTargetY];
                    }
                    else if(map[moveTargetX, moveTargetY - 1] == 1)
                    {
                        map[moveTargetX, moveTargetY - 1] = HorseNumber;
                        map[moveTargetX, moveTargetY] = BackUpmap[moveTargetX, moveTargetY];

                    }
                    else if (map[moveTargetX, moveTargetY - 1] == 2)
                    {
                        map[moveTargetX, moveTargetY - 1] = HorseNumber;
                        map[moveTargetX, moveTargetY] = BackUpmap[moveTargetX, moveTargetY];
                    }
                }
            }
        }
    }
}
