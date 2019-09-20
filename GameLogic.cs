using System;

namespace GameOfLife
{
    public class GameLogic
    {
        public static bool[,] fieldInitial = new bool[Settings.fieldHeight, Settings.fieldWidth];
        private static bool[,] fieldOutput = new bool[Settings.fieldHeight, Settings.fieldWidth];



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
            for (int cellRowPosition = 0; cellRowPosition < Settings.fieldHeight; cellRowPosition++)
            {
                for (int cellColumnPosition = 0; cellColumnPosition < Settings.fieldWidth; cellColumnPosition++)
                {
                    fieldInitial[cellRowPosition, cellColumnPosition] = PopulateCellRandomly(Settings.chanceToBeAlive);
                }
            }
        }

        public static int FindNeighbours(int row, int column)
        {
            int count = 0;
            int rowLimit = Settings.fieldHeight - 1;
            int columnLimit = Settings.fieldWidth - 1;

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

        public static void RepopulateField()
        {
            for (int cellRowPosition = 0; cellRowPosition < Settings.fieldHeight; cellRowPosition++)
            {
                for (int cellColumnPosition = 0; cellColumnPosition < Settings.fieldWidth; cellColumnPosition++)
                {
                    int cellNeighbours = FindNeighbours(cellRowPosition, cellColumnPosition);

                    if ((cellNeighbours == Settings.aliveLowerLimit ||
                         cellNeighbours == Settings.aliveUpperLimit) &&
                         fieldInitial[cellRowPosition, cellColumnPosition] == true)
                    {
                        fieldOutput[cellRowPosition, cellColumnPosition] = true;
                    }

                    else if (cellNeighbours == Settings.aliveByReproduction &&
                             fieldInitial[cellRowPosition, cellColumnPosition] == false)
                    {
                        fieldOutput[cellRowPosition, cellColumnPosition] = true;
                    }
                    else
                    {
                        fieldOutput[cellRowPosition, cellColumnPosition] = false;
                    }
                }
            }
            for (int cellRowPosition = 0; cellRowPosition < Settings.fieldHeight; cellRowPosition++)
            {
                for (int cellColumnPosition = 0; cellColumnPosition < Settings.fieldWidth; cellColumnPosition++)
                {
                    fieldInitial[cellRowPosition, cellColumnPosition] = fieldOutput[cellRowPosition, cellColumnPosition];
                }
            }
        }
    }
}
