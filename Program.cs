using System;
using System.Collections.Generic;
using System.Threading;

namespace Day_16
{
    class Program
    {
        struct Chain
        {
            public string Symbols;
            public int X;
            public int Y;
        };
        static int cursorLeft;
        static int cursorTop;
        static char GenerateChainSymbol()
        {
            string symbolsChain = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            return symbolsChain[new Random().Next(0, 35)];
        }
        static List<Chain> chainsList = new List<Chain>();
        // static void OutChain(int indexChr, int x)
        // {
        //     Task taskChangeSymbol = new Task(() =>
        //     {
        //         Console.ResetColor();
        //         Console.ForegroundColor = otherChrColor;
        //         Console.SetCursorPosition(curLeft + x, 1);
        //         Console.Write(symbols[indexChr + 2]);
        //         Thread.Sleep(50);
        //         Console.SetCursorPosition(curLeft + x, 2);
        //         Console.Write(symbols[indexChr + 3]);
        //         Thread.Sleep(50);
        //         Console.SetCursorPosition(curLeft + x, 3);
        //         Console.Write(symbols[indexChr + 4]);
        //         Thread.Sleep(50);
        //         Console.ForegroundColor = secondChrColor;
        //         Console.SetCursorPosition(curLeft + x, 4);
        //         Console.Write(symbols[indexChr + 5]);
        //         Thread.Sleep(50);
        //         Console.ForegroundColor = firstChrColor;
        //         Console.SetCursorPosition(curLeft + x, 5);
        //         Console.Write(symbols[indexChr + 6]);

        //         Console.ResetColor();
        //     });
        //     taskChangeSymbol.Start();
        // }
        static void ChainGenerator()
        {
            int counter = 0;
            object locker = new object();
            while(counter < 10)
            {
                lock (locker)
                {
                    Chain chain = new Chain();
                    chain.Symbols = "";
                    chain.X = counter + 10;
                    chain.Y = 0;
                    for(int i = 0; i < 10; i++)
                    {
                        chain.Symbols += GenerateChainSymbol();
                    }
                    chainsList.Add(chain);
                    counter++;
                }
                
            }
        }

        static void InitCursors()
        {
            cursorLeft = Console.CursorLeft;
            cursorTop = Console.CursorTop;
        }
        static void Main(string[] args)
        {
            InitCursors();
            Console.WriteLine("Task 16...");
            Thread chainGenerator = new Thread(ChainGenerator);
            chainGenerator.Start();
            chainGenerator.Join();

            Console.WriteLine(chainsList.Count);
            Console.WriteLine(chainsList[4].Symbols);
        }
    }
}
