using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Day_16
{
    class Chain
    {
        public string Symbols;
        public int X;
        public int Y;
    }
    class Program
    {
        static int cursorLeft;
        static int cursorTop;
        static char GenerateChainSymbol()
        {
            string symbolsChain = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            return symbolsChain[new Random().Next(0, 35)];
        }
        static List<Chain> chainsList = new List<Chain>();
        static int index = 0;
        static void OutChain()
        {
            object locker = new object();
            for (int i = 0; i < chainsList[index].Symbols.Length; i++)
            {
                lock (locker)
                {
                    Console.ResetColor();
                    Console.SetCursorPosition(cursorLeft + chainsList[index].X, Console.CursorTop + chainsList[index].Y);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if (i > chainsList[index].Symbols.Length - 2)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (i > chainsList[index].Symbols.Length - 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(chainsList[index].Symbols[i]);
                    Thread.Sleep(50);
                    Console.ResetColor();
                    Console.CursorTop = i;
                }
            }
        }
        static void ChainGenerator()
        {
            int counter = 0;
            object locker = new object();
            while (counter < 40)
            {
                lock (locker)
                {
                    int symbLen = new Random().Next(4, 20);
                    int interval = new Random().Next(3, 5);
                    Chain chain = new Chain();
                    chain.Symbols = "";
                    chain.X = counter * interval;
                    chain.Y = counter;
                    for (int i = 0; i < symbLen; i++)
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
            Thread chainGenerator = new Thread(ChainGenerator);
            chainGenerator.Start();
            chainGenerator.Join();
            Thread[] chainsTask = new Thread[40];
            for (int i = 0; i < chainsTask.Length; i++, index++)
            {
                chainsTask[i] = new Thread(OutChain);
                chainsTask[i].Start();
                chainsTask[i].Join();
            }
        }
    }
}