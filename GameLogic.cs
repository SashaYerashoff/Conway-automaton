using System;

namespace GameOfLife
{
    public class GameLogic
    {
        public bool[,] fieldInitial;
        private bool[,] fieldOutput;

        public GameLogic(int height, int width)
        {
            fieldInitial = new bool[height, width];
            fieldOutput = new bool[height, width];
        }
        public bool PopulateCellRandomly(int amount)
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

        public void PopulateFieldRandomly(int height, int width)
        {
            for (int cellRowPosition = 0; cellRowPosition < height; cellRowPosition++)
            {
                for (int cellColumnPosition = 0; cellColumnPosition < width; cellColumnPosition++)
                {
                    fieldInitial[cellRowPosition, cellColumnPosition] = PopulateCellRandomly(Settings.chanceToBeAlive);
                }
            }
        }

        public int FindNeighbours(int row, int column)
        {
            int count = 0;
            int rowLimit = fieldInitial.GetLength(0) - 1;
            int columnLimit = fieldInitial.GetLength(1) - 1;

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

        public void RepopulateField(int height, int width)
        {
            for (int cellRowPosition = 0; cellRowPosition < height; cellRowPosition++)
            {
                for (int cellColumnPosition = 0; cellColumnPosition < width; cellColumnPosition++)
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
            for (int cellRowPosition = 0; cellRowPosition < height; cellRowPosition++)
            {
                for (int cellColumnPosition = 0; cellColumnPosition < width; cellColumnPosition++)
                {
                    fieldInitial[cellRowPosition, cellColumnPosition] = fieldOutput[cellRowPosition, cellColumnPosition];
                }
            }
        }
    }
}
