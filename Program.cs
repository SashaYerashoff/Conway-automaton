using System;

namespace GameOfLife
{
    class Program
    {
        public static void Main(string[] args)
        {
            GameLogic.PopulateFieldRandomly();

            for (int i = 1; i < Settings.amountOfGenerations; i++)
            {
                ConsoleOutput.PrintArray(GameLogic.fieldInitial);
                GameLogic.RepopulateField();   
            }
            ConsoleOutput.PrintFinalStats();
        }   
    }
}