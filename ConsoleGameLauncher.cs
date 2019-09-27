using System;

namespace ConwayAutomaton
{
    public class ConsoleGameLauncher
    {
        int iterationCount = 0;

        ConsoleSupportOut consoleOut = new ConsoleSupportOut();
        ConsoleInput consoleIn = new ConsoleInput();
        FileHandler fileHandler = new FileHandler();
        GameLogic game = new GameLogic();
        FieldDrawer drawer = new FieldDrawer();

        public void StartConsoleGame()
        {
            int height = consoleIn.GetHeight();
            int width = consoleIn.GetWidth();
            FieldModel field = new FieldModel(height, width);
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
                consoleOut.StopGameMessage(height);
                consoleOut.PrintAliveCellsAmount(aliveCellsAmount, height);
                consoleOut.PrintCountOfIterations(height, iterationCount);
                System.Threading.Thread.Sleep(Constants.threadDelay);
            }

            drawer.PrintArray(field.gameField);
            consoleOut.PrintAliveCellsAmount(countCells.CountAliveCells(field.gameField), height - 2);
            consoleOut.PrintCountOfIterations(height, iterationCount);
            Console.SetCursorPosition(0, height + 2);
            Console.Write("Input [y] to save automaton last state: ");

            bool saveYes = consoleIn.YesOrNo();
            if (saveYes)
            {
                consoleOut.AskForFileName();
                string fileName = consoleIn.GetFileName();
                fileHandler.SaveToNewFile(fileName, field.gameField);
            }
        }
    }
}
