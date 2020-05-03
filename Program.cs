using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Day_16
{
    class Program
    {
        static char GenerateChainSymbol()
        {
            string symbolsChain = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            return symbolsChain[new Random().Next(0, 35)];
        }
        static void OutChain()
        {
            object locker = new object();
            int maxStep = 0;
            while (maxStep < 10)
            {
                Console.CursorTop = maxStep;
                //lock (locker)
                //{
                    for (int i = 0; i < 25; i++)
                    {
                        Console.ResetColor();
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + i);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        if (maxStep > 8)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (maxStep > 7)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.Write(GenerateChainSymbol());
                        Console.ResetColor();
                    }
                    maxStep++;
                //}
            }
        }
        static void Main(string[] args)
        {
            Console.CursorTop = 0;
            Thread[] chainsTask = new Thread[30];
            for (int i = 0; i < chainsTask.Length; i++)
            {
                Thread.Sleep(100);
                chainsTask[i] = new Thread(OutChain);
                chainsTask[i].Start();
                chainsTask[i].Join();
            }
            Console.Read();
        }
    }
}