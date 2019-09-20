using System;

namespace GameOfLife
{
    public class ConsoleOutput
    {
        public void PrintArray(bool[,] fieldToPrint)
        {
            Console.Clear();

            for (int cellRowPosition = 0; cellRowPosition < Settings.FieldHeight; cellRowPosition++)
            {
                for (int cellColumnPosition = 0; cellColumnPosition < Settings.FieldWidth; cellColumnPosition++)
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
        public void PrintFinalStats()
        {
            Console.SetCursorPosition(0, Settings.FieldWidth);
            Console.WriteLine("Game iterated {0} times", Settings.amountOfGenerations);
            Console.ReadLine();
        }

        public void AskForHeight()
        {
            Console.Write("Please input field height: ");
        }

        public void AskForWidth()
        {
            Console.Write("Please input field width: ");
        }
    }

}
