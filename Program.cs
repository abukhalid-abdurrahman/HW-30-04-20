using System;
using System.Threading;
using System.Threading.Tasks;

namespace Day_16
{
    class Program
    {
        static int curLeft;
        static int curTop;
        static ConsoleColor firstChrColor = ConsoleColor.White;
        static ConsoleColor secondChrColor = ConsoleColor.Green;
        static ConsoleColor otherChrColor = ConsoleColor.DarkGreen;
        static string symbols = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890";
        static void OutChain(int indexChr, int x, int y)
        {
            Task taskChangeSymbol = new Task(() =>
            {
                Console.ResetColor();
                Console.ForegroundColor = otherChrColor;
                Console.SetCursorPosition(curLeft + x, curTop + y + 2);
                Console.Write(symbols[indexChr + 2]);

                Console.SetCursorPosition(curLeft + x, curTop + y + 3);
                Console.Write(symbols[indexChr + 3]);

                Console.SetCursorPosition(curLeft + x, curTop + y + 4);
                Console.Write(symbols[indexChr + 4]);

                Console.ForegroundColor = secondChrColor;
                Console.SetCursorPosition(curLeft + x, curTop + y + 5);
                Console.Write(symbols[indexChr + 5]);

                Console.ForegroundColor = firstChrColor;
                Console.SetCursorPosition(curLeft + x, curTop + y + 6);
                Console.Write(symbols[indexChr + 6]);

                Console.ResetColor();
            });
            taskChangeSymbol.Start();
        }
        static void Main(string[] args)
        {
            curLeft = Console.CursorLeft;
            curTop = Console.CursorTop;
            Task taskChainDrawer = new Task(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    int randIndex = new Random().Next(0, symbols.Length - 6);
                    int randX = new Random().Next(5, 100);
                    int randY = new Random().Next(0, 5);
                    for (int j = 0; j < 10; j++)
                    {
                        OutChain(randIndex, randX + i, randY + j);
                        Thread.Sleep(50);
                    }
                    Thread.Sleep(100);
                }
            });
            taskChainDrawer.Start();
            taskChainDrawer.Wait();
            Console.Read();
        }
    }
}
