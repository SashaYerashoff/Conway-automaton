using System;

namespace ConwayAutomaton
{
    public class FieldDrawer
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
                        Console.Write(Constants.livingCellSymbol + " ");
                    }
                    else
                    {
                        Console.Write(Constants.deadCellSymbol + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, Console.WindowTop);
            Console.CursorVisible = false;

        }
    }
}
