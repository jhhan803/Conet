using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace Conet_StopWatch
{
    class Program
    {
        //static Stopwatch stopwatch = new Stopwatch();
        //static bool gamestate = false;
        //static long Now { get; set; } = 0;
        //static long Before { get; set; } = 0;
        //static int frameTime = 100;
        //static Random random = new Random();
        //static void Main(string[] args)
        //{
        //    int min = 0;
        //    int sec = 0;
        //    int sec_10 = 0;
        //    int min_10 = 0;
        //    int milsec = 0;
        //    Init();
        //    while (gamestate)
        //    {
        //        //Update();
        //        //Render();
        //        Update(ref min, ref sec, ref sec_10, ref min_10, ref milsec);
        //        Render(min, sec, sec_10, min_10, milsec);
        //    }
        //    Release();
        //}
        //static void Init()
        //{
        //    Console.WriteLine("스페이스바를 눌러 스톱워치를 시작");
        //    while (Console.ReadKey().Key !=ConsoleKey.Spacebar) { }
        //    stopwatch.Start();
        //    gamestate = true;
        //}
        //static void Update(ref int Min, ref int Sec, ref int Sec_10,ref int Min_10, ref int Milsec)
        //{
        //    while (!isRenderState()) {
        //        Console.SetCursorPosition(2, 2);
        //        Console.Write($"{random.Next()}");
        //    }
        //   Thread.Sleep(100);
        //    Milsec += 1;
        //    if (Milsec >= 10)
        //    {
        //        Milsec = 0;
        //        Sec += 1;
        //    }
        //    if (Sec >= 10)
        //    {
        //        Sec = 0;
        //        Sec_10 += 1;
        //    }
        //    if (Sec_10 >= 6)
        //    {
        //        Sec_10 = 0;
        //        Min += 1;
        //    }
        //    if (Min >= 10)
        //    {
        //        Min = 0;
        //        Min_10 += 1;
        //    }
        //}
        //static void Render(int Min,int Sec,int Sec_10, int Min_10,int milsec)
        //{
        //   Console.Write($"{Min_10}{Min}:{Sec_10}{Sec}:{milsec}");
        //   Console.SetCursorPosition(0, 1);
        //}
        //static void Release()
        //{

        //}
        //static bool isRenderState()
        //{
        //    Now = stopwatch.ElapsedMilliseconds;
        //    if(Now-Before>frameTime)
        //    {
        //        Before += frameTime;
        //        return true;
        //    }

        //    return false;
        //}
        static bool gamestate = false;
        static Stopwatch myStopWatch = new Stopwatch();
        static long Now { get; set; } = 0;
        static long Before { get; set; } = 0;
        static int frameTime = 100;
        static Random myrand = new Random();
        static int MonsterHp = 100;
        static void Main(string[] args)
        {

            //0번째 요소가 min, 1번째 요소가 sec, 2번째 요소가 sec1_10이라고 생각하자.
            int[] myclock = new int[3];
            Init();
            while (gamestate)
            {
                Update(myclock);
                Render(myclock);
            }
            Release();
        }
        static void Init()
        {
            // 초기화 코드들
            gamestate = true;
            myStopWatch.Start();
        }
        static void Update(int[] myarray)
        {
        //    ConsoleKeyInfo consoleKeyInfo;
            while (!isRenderTime())
            {
                Console.SetCursorPosition(2, 2);
                Console.Write($"{myrand.Next()}");
            }
            // 0.1초단위 증가
            myarray[2]++;

            //0.1초단위가 증가했더니 9에서 10으로 바뀌는 순간, 초 단위를 1 증가해야 한다.
            if (myarray[2] == 10)
            {
                myarray[1]++;
                myarray[2] = 0;
            }
            // 초단위가 60이 되면, 초단위는 0으로, 분단위는 1 증가
            if (myarray[1] == 60)
            {
                myarray[1] = 0;
                myarray[0]++;
            }
            if (Console.KeyAvailable)
            {
                if (Console.ReadKey().Key == ConsoleKey.A)
                {
                    MonsterHp += 10;
                }
            }
            if (MonsterHp <= 0)
            {
                gamestate = false;
            }
            else
            {
                MonsterHp--;
                Console.SetCursorPosition(0, 3);
                Console.Write(MonsterHp);

            }
        }
        static void Render(int[] myarray)
        {
            Console.SetCursorPosition(1, 0);
            Console.WriteLine($"{myarray[0]}:{myarray[1]}:{myarray[2]}");
        }
        static void Release()
        {
            Console.Clear();
            Console.WriteLine("게임오버");
        }
        static bool isRenderTime()
        {
            // 시계를 보는 행위
            Now = myStopWatch.ElapsedMilliseconds;
            if (Now - Before > frameTime)
            {
                // 13:00 -> 14:00
                Before += frameTime;
                return true;
            }
            return false;
        }
    }
}
