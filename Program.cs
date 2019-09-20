using System;
using GameOfLife;

namespace GameOfLife
{
    class Program
    {
        public static void Main(string[] args)
        {
            PopulateFieldRandomly();

            for (int i = 1; i < iterationsOfGame; i++)
            {
                printArray(fieldInitial);
                RepopulateField();   
            }
            Console.SetCursorPosition(0, fieldWidth);
            Console.WriteLine("Game iterated {0} times", iterationsOfGame);
            Console.ReadLine();
        }

        static int threadDelay = 30;
        static int iterationsOfGame = 100;
        static int fieldHeight = 28;
        static int fieldWidth = 28;
        static bool[,] fieldInitial = new bool[fieldHeight, fieldWidth];
        static bool[,] fieldOutput  = new bool[fieldHeight, fieldWidth];
        static int chanceToBeAlive = 2;
        const char livingCellSymbol = '*';
        const char deadCellSymbol = ' ';
        

        public static int FindNeighbours(int row, int column)
        {

            int count = 0;
            int rowLimit = fieldHeight - 1;
            int columnLimit = fieldWidth - 1;
            for (int rowToCheck = row - 1; rowToCheck <= row + 1; rowToCheck++)
            {
                for (int columnToCheck = column - 1; columnToCheck <= column + 1; columnToCheck++)
                {
                    if (!(rowToCheck < 0 || 
                          columnToCheck < 0 ||
                          rowToCheck > rowLimit ||
                          columnToCheck > columnLimit) && 
                          fieldInitial[rowToCheck, columnToCheck] == true)
                    {
                        count++;
                    }
                }
            } 
            return count;
        }

        public static bool PopulateCellRandomly(int amount)
        {
            var rand = new Random();

            if (rand.Next(amount) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void PopulateFieldRandomly()
        {
            for (int i = 0; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    fieldInitial[i, j] = PopulateCellRandomly(chanceToBeAlive);
                }
            }
        }

        public static void RepopulateField()
        {
            for (int i = 0; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    int cellNeighbours = FindNeighbours(i, j);

                    if ((cellNeighbours == 3 || 
                         cellNeighbours == 4) && 
                         fieldInitial[i, j] == true)
                    {     
                        fieldOutput[i,j] = true;
                    }
                    
                    else if (cellNeighbours == 3 && 
                             fieldInitial[i, j] == false)
                    {
                        fieldOutput[i, j] = true;
                    }
                    else
                    {
                        fieldOutput[i, j] = false;
                    }
                }
            }
            for (int i = 0; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    fieldInitial[i, j] = fieldOutput[i, j];
                }
            }                    
        }

        public static void printArray( bool[,] fieldToPrint)
        {
            for(int i = 0; i < fieldHeight; i++)
            {
                for ( int j = 0; j < fieldWidth; j++)
                {
                    if (fieldToPrint[i, j] == true)
                    {
                        Console.Write(livingCellSymbol + " ");
                    }
                    else
                    {
                        Console.Write(deadCellSymbol + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, Console.WindowTop);
            Console.CursorVisible = false;
            System.Threading.Thread.Sleep(threadDelay);
            //Console.ReadLine();
        }
    }
}