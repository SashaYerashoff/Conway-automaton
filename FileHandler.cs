﻿using System;
using System.IO;

namespace ConwayAutomaton
{
    public class FileHandler
    {
        public void SaveToNewFile(string fileName, bool[,] gameField)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    throw new Exception();

                }
            }
            catch (Exception)
            {
                Console.WriteLine($"{fileName} already exists!");
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
            saveNewFieldDimensions(fileName, gameField);
        }

        public bool[,] readFromFile(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"There is no such file as `{fileName}`!");
            }

            int[] heightWidth = readExistingFieldDimensions(fileName);
            int height = heightWidth[0];
            int width = heightWidth[1];
            bool[,] gameField = new bool[height, width];

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

        public void saveNewFieldDimensions(string fileName, bool[,] gameField)
        {
            string fieldSizeFileName = fileName + "_fieldsize";
            using (FileStream fs = new FileStream(fieldSizeFileName, FileMode.CreateNew))
            {
                using (BinaryWriter saveGameFieldSize = new BinaryWriter(fs))
                {
                    saveGameFieldSize.Write(gameField.GetLength(0));
                    saveGameFieldSize.Write(gameField.GetLength(1));
                }
            }
        }

        public int[] readExistingFieldDimensions(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"There is no such file as `{fileName}`!");
            }
            string fieldSizeFileName = fileName + "_fieldsize";
            int[] dimensions = new int[2];
            using (FileStream fs = new FileStream(fieldSizeFileName, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader readGameFieldSize = new BinaryReader(fs))
                {
                    dimensions[0] = readGameFieldSize.ReadInt32();
                    dimensions[1] = readGameFieldSize.ReadInt32();
                }
            }
            return dimensions;
        }
    }
}
