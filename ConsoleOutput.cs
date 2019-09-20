using System;

namespace GameOfLife
{
    public class ConsoleOutput
    {
        public static void PrintArray(bool[,] fieldToPrint)
        {
            for (int i = 0; i < Settings.fieldHeight; i++)
            {
                for (int j = 0; j < Settings.fieldWidth; j++)
                {
                    if (fieldToPrint[i, j] == true)
                    {
                        Console.Write(Settings.livingCellSymbol + " ");
                    }
                    else
                    {
                        Console.Write(Settings.deadCellSymbol + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, Console.WindowTop);
            Console.CursorVisible = false;
            System.Threading.Thread.Sleep(Settings.threadDelay);
        }
        public static void PrintFinalStats()
        {
            Console.SetCursorPosition(0, Settings.fieldWidth);
            Console.WriteLine("Game iterated {0} times", Settings.amountOfGenerations);
            Console.ReadLine();
        }
    }

}
