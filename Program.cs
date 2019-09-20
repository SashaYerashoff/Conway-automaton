using System;

namespace GameOfLife
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Please input field height: ");
            //dishHeight = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Please input field width: ");
            //dishWidth = Convert.ToInt32(Console.ReadLine());

            PopulatePetriDishRandomly();

            for (int i = 1; i < iterationsOfLife; i++)
            {
                printArray(petriDishInitial);
                RepopulatePetriDish();
                
            }
            Console.ReadLine();
        }

        static int threadDelay = 30;
        static int iterationsOfLife = 300;
        static int dishHeight = 28;
        static int dishWidth = 28;
        static bool[,] petriDishInitial = new bool[dishHeight, dishWidth];
        //{ 
        //    { false, false, false, false, false }, 
        //    { false, false, false, false, false }, 
        //    { false,  true,  true,  true, false }, 
        //    { false, false, false, false, false },
        //    { false, false, false, false, false }
        //};
        static bool[,] petriDishOutput = new bool[dishHeight, dishWidth];
        static int populationIntensity = 3;
        const char livingCellSymbol = '*';
        const char deadCellSymbol = ' ';
        

        public static int FindNeighbours(int row, int column)
        {

            int count = 0;
            int rowLimit = dishHeight - 1;
            int columnLimit = dishWidth - 1;
            for (int rowToCheck = row - 1; rowToCheck <= row + 1; rowToCheck++)
            {
                for (int columnToCheck = column - 1; columnToCheck <= column + 1; columnToCheck++)
                {
                    if (!(rowToCheck < 0 || 
                          columnToCheck < 0 ||
                          rowToCheck > rowLimit ||
                          columnToCheck > columnLimit) && 
                          petriDishInitial[rowToCheck, columnToCheck] == true)
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

        public static void PopulatePetriDishRandomly()
        {
            for (int i = 0; i < dishHeight; i++)
            {
                for (int j = 0; j < dishWidth; j++)
                {
                    petriDishInitial[i, j] = PopulateCellRandomly(populationIntensity);
                }
            }
        }

        public static void RepopulatePetriDish()
        {
            for (int i = 0; i < dishHeight; i++)
            {
                for (int j = 0; j < dishWidth; j++)
                {
                    int cellNeighbours = FindNeighbours(i, j);
                    //int deadCellNeighbours = 9 - cellNeighbours;
                    if ((cellNeighbours == 3 || cellNeighbours == 4) && petriDishInitial[i, j] == true)
                    {
                         
                        petriDishOutput[i,j] = true;
                    }
                    
                    else if (cellNeighbours == 3 && petriDishInitial[i, j] == false)
                    {
                        petriDishOutput[i, j] = true;
                    }
                    else
                    {
                        petriDishOutput[i, j] = false;
                    }
                }
            }
            for (int i = 0; i < petriDishInitial.GetLength(0); i++)
            {
                for (int j = 0; j < petriDishInitial.GetLength(1); j++)
                {

                    petriDishInitial[i, j] = petriDishOutput[i, j];
                }
            }                    
        }

        public static void printArray( bool[,] pofig)
        {
            for(int i = 0; i < dishHeight; i++)
            {
                for ( int j = 0; j < dishWidth; j++)
                {
                    if (pofig[i, j] == true)
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