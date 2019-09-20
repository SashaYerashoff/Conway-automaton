using System;

namespace GameOfLife
{
    class Program
    {
        public void Main(string[] args)
        {
            ConsoleInput consoleIn = new ConsoleInput();
            Settings setField = new Settings(consoleIn.GetHeight(), consoleIn.GetWidth());
            ConsoleOutput consoleOut = new ConsoleOutput();
            GameLogic.PopulateFieldRandomly();

            for (int generation = 1; generation < Settings.amountOfGenerations; generation++)
            {
                consoleOut.PrintArray(GameLogic.fieldInitial);
                GameLogic.RepopulateField();   
            }
            consoleOut.PrintFinalStats();
        }   
    }
}