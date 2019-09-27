using System;

namespace ConwayAutomaton
{
    public class GameLogic
    {
        public bool PopulateCellRandomly(int chance)
        {
            var rand = new Random();

            if (rand.Next(chance) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PopulateFieldRandomly(int height, int width, bool[,] gameField)
        {
            for (int cellRowPosition = 0; cellRowPosition < height; cellRowPosition++)
            {
                for (int cellColumnPosition = 0; cellColumnPosition < width; cellColumnPosition++)
                {
                    gameField[cellRowPosition, cellColumnPosition] = PopulateCellRandomly(Constants.chanceToBeAlive);
                }
            }
        }

        public int FindNeighbours(int row, int column, bool[,] gameField)
        {
            int count = 0;
            int rowLimit = gameField.GetLength(0) - 1;
            int columnLimit = gameField.GetLength(1) - 1;

            for (int rowToCheck = row - 1; rowToCheck <= row + 1; rowToCheck++)
            {
                for (int columnToCheck = column - 1; columnToCheck <= column + 1; columnToCheck++)
                {
                    if (!(rowToCheck < 0 ||
                          columnToCheck < 0 ||
                          rowToCheck > rowLimit ||
                          columnToCheck > columnLimit) &&
                          gameField[rowToCheck, columnToCheck] == true)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void RepopulateField(int height, int width, bool[,] gameField, bool[,] gameFieldBuffer)
        {
            for (int cellRowPosition = 0; cellRowPosition < height; cellRowPosition++)
            {
                for (int cellColumnPosition = 0; cellColumnPosition < width; cellColumnPosition++)
                {
                    int cellNeighbours = FindNeighbours(cellRowPosition, cellColumnPosition, gameField);
                    bool aliveLow = cellNeighbours == Constants.aliveLowerLimit;
                    bool aliveHigh = cellNeighbours == Constants.aliveUpperLimit;
                    bool reproduce = cellNeighbours == Constants.aliveByReproduction;
                    bool cellIsAlive = gameField[cellRowPosition, cellColumnPosition] == true;

                    if ((aliveLow || aliveHigh) && cellIsAlive)
                    {
                        gameFieldBuffer[cellRowPosition, cellColumnPosition] = true;
                    }
                    else if (reproduce && !cellIsAlive)
                    {
                        gameFieldBuffer[cellRowPosition, cellColumnPosition] = true;
                    }
                    else
                    {
                        gameFieldBuffer[cellRowPosition, cellColumnPosition] = false;
                    }
                }
            }
        }

        public void OverwriteGameField(int height, int width, bool[,] gameField, bool[,] gameFieldBuffer)
        {
            for (int cellRowPosition = 0; cellRowPosition < height; cellRowPosition++)
            {
                for (int cellColumnPosition = 0; cellColumnPosition < width; cellColumnPosition++)
                {
                    gameField[cellRowPosition, cellColumnPosition] = gameFieldBuffer[cellRowPosition, cellColumnPosition];
                }
            }
        }
    }
}
