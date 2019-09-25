using System;
namespace GameOfLife
{
    public class ProgramSetup
    {
        public void Run()
        {
            ConsoleInput consoleIn = new ConsoleInput();

            int height = consoleIn.GetHeight();
            int width = consoleIn.GetWidth();
            int iterationCount = 0;
            //int aliveCellsAmount = 0;

            GameLogic game = new GameLogic(height, width);
            FieldDrawer drawer = new FieldDrawer();
            ConsoleSupportOut ConsoleOut = new ConsoleSupportOut();
            AliveCellCounter countCells = new AliveCellCounter();

            game.PopulateFieldRandomly(height, width);

            while (!(Console.KeyAvailable && 
                     Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                int aliveCellsAmount = countCells.CountAliveCells(game.fieldInitial);
                drawer.PrintArray(game.fieldInitial);
                game.RepopulateField(height, width);
                iterationCount++; 

                ConsoleOut.PrintAliveCellsAmount(aliveCellsAmount, height);
                ConsoleOut.PrintCountOfIterations(height, iterationCount);
                System.Threading.Thread.Sleep(Constants.threadDelay);
            } 
            Console.ReadLine();
        }
    }
}
