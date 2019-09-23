
namespace GameOfLife
{
    class Program
    {
        public static void Main(string[] args)
        {
            ConsoleInput consoleIn = new ConsoleInput();

            int height = consoleIn.GetHeight();
            int width = consoleIn.GetWidth();
            Settings fieldSize = new Settings(height, width);

            GameLogic game = new GameLogic(height, width);
            ConsoleOutput consoleOut = new ConsoleOutput();
            game.PopulateFieldRandomly(height, width);

            for (int generation = 0; generation < Settings.amountOfGenerations; generation++)
            {
                consoleOut.PrintArray(game.fieldInitial);
                game.RepopulateField(height, width);   
            }
            consoleOut.PrintFinalStats(height);
        }   
    }
}