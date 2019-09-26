using System;

namespace ConwayAutomaton
{
    public class ConsoleGameLauncher
    {
        public void Run()
        {
            ConsoleInput consoleIn = new ConsoleInput();

            int height = consoleIn.GetHeight();
            int width = consoleIn.GetWidth();
            int iterationCount = 0;
            
            FieldModel field = new FieldModel(height, width);
            GameLogic game = new GameLogic();
            FieldDrawer drawer = new FieldDrawer();
            ConsoleSupportOut ConsoleOut = new ConsoleSupportOut();
            AliveCellCounter countCells = new AliveCellCounter();

            game.PopulateFieldRandomly(height, width, field.gameField);

            while (!(Console.KeyAvailable && 
                     Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                int aliveCellsAmount = countCells.CountAliveCells(field.gameField);
                drawer.PrintArray(field.gameField);
                game.RepopulateField(height, width, field.gameField, field.gameFieldBuffer);
                game.OverwriteGameField(height, width, field.gameField, field.gameFieldBuffer);
                iterationCount++;
                ConsoleOut.stopGameMessage(height);
                ConsoleOut.PrintAliveCellsAmount(aliveCellsAmount, height);
                ConsoleOut.PrintCountOfIterations(height, iterationCount);
                System.Threading.Thread.Sleep(Constants.threadDelay);
            } 
            Console.ReadLine();
        }
    }
}
