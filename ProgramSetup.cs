
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
            FieldDrawer consoleOut = new FieldDrawer();
            ConsoleSupportOut finalization = new ConsoleSupportOut();
            game.PopulateFieldRandomly(height, width);

            for (int generation = 0; generation < Constants.amountOfGenerations; generation++)
            {
                consoleOut.PrintArray(game.fieldInitial);
                game.RepopulateField(height, width);
            }
            finalization.PrintFinalStats(height);
        }
    }
}
