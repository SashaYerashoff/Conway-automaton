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

            GameLogic game = new GameLogic(height, width);
            FieldDrawer drawer = new FieldDrawer();
            ConsoleSupportOut finalization = new ConsoleSupportOut();
            game.PopulateFieldRandomly(height, width);

            int iterationCount = 0;
            while (!(Console.KeyAvailable && 
                     Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                drawer.PrintArray(game.fieldInitial);
                game.RepopulateField(height, width);
                iterationCount++;
            }
            finalization.PrintFinalStats(height, iterationCount);
        }
    }
}
