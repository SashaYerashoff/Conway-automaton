using System;

namespace ConwayAutomaton
{
    class SavedGameLauncher
    {
        ConsoleSupportOut consoleOut = new ConsoleSupportOut();
        ConsoleInput consoleIn = new ConsoleInput();
        int iterationCount = 0;
        public void startGameFromFile()
        {
            FileHandler handleFile = new FileHandler();

            consoleOut.AskForFileName();
            string gameFieldFileName = consoleIn.GetFileName();

            int[] heightWidth = handleFile.readExistingFieldDimensions(gameFieldFileName);
            int height = heightWidth[0];
            int width = heightWidth[1];
            FieldModel loadField = new FieldModel(height, width);
            loadField.gameField = handleFile.readFromFile(gameFieldFileName);

            //quickfix
            GameLogic game = new GameLogic();
            FieldDrawer drawer = new FieldDrawer();

            AliveCellCounter countCells = new AliveCellCounter();

            game.PopulateFieldRandomly(height, width, loadField.gameField);

            while (!(Console.KeyAvailable &&
                     Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                int aliveCellsAmount = countCells.CountAliveCells(loadField.gameField);
                drawer.PrintArray(loadField.gameField);
                game.RepopulateField(height, width, loadField.gameField, loadField.gameFieldBuffer);
                game.OverwriteGameField(height, width, loadField.gameField, loadField.gameFieldBuffer);
                iterationCount++;
                consoleOut.StopGameMessage(height);
                consoleOut.PrintAliveCellsAmount(aliveCellsAmount, height);
                consoleOut.PrintCountOfIterations(height, iterationCount);
                System.Threading.Thread.Sleep(Constants.threadDelay);
            }
        }
    }
}
