using System;
using System.IO;

namespace ConwayAutomaton
{
    public class FileHandler
    {
        public void SaveToFile(string fileName, bool[,] gameField)
        {
            if (File.Exists(fileName))
            {
                Console.WriteLine($"{fileName} already exists!");
                return;
            }

            using (FileStream fs = new FileStream(fileName, FileMode.CreateNew))
            {
                using (BinaryWriter saveGameField = new BinaryWriter(fs))
                {
                    foreach (bool cellState in gameField)
                    {
                        saveGameField.Write(cellState);
                    }
                }
            }
        }
        public bool[,] readFromFile(string fileName, bool[,] gameField)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader readGameField = new BinaryReader(fs))
                {
                    for (int cellRowPostion = 0; cellRowPostion < gameField.GetLength(0); cellRowPostion++)
                    {
                        for (int cellColumnPosition = 0; cellColumnPosition < gameField.GetLength(1); cellColumnPosition++)
                        {
                            gameField[cellRowPostion, cellColumnPosition] = readGameField.ReadBoolean();
                        }
                    }
                }
            }
            return gameField;
        }

    }
}
