using System;

namespace GameOfLife
{
    public class ConsoleOutput
    {
        public void PrintArray(bool[,] fieldToPrint)
        {
            Console.Clear();
            for (int cellRowPosition = 0; cellRowPosition < fieldToPrint.GetLength(0); cellRowPosition++)
            {
                for (int cellColumnPosition = 0; cellColumnPosition < fieldToPrint.GetLength(1); cellColumnPosition++)
                {
                    if (fieldToPrint[cellRowPosition, cellColumnPosition] == true)
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
        public void PrintFinalStats(int height)
        {
            Console.SetCursorPosition(0, height);
            Console.WriteLine("Field iterated {0} times", Settings.amountOfGenerations);
            Console.ReadLine();
        }

       
    }

}
