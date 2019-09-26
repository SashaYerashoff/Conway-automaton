using System;

namespace ConwayAutomaton
{
    public class ConsoleGameLauncher
    {
        public void Run()
        {
            int iterationCount = 0;

            ConsoleSupportOut consoleOut = new ConsoleSupportOut();
            ConsoleInput consoleIn = new ConsoleInput();
            consoleOut.WelcomeMessage();
            bool startFromFile = consoleIn.YesOrNo();
            FileHandler handleFile = new FileHandler();

            

            if (startFromFile == true)
            {
                consoleOut.AskForFileName();
                string gameFieldFileName = consoleIn.GetFileName();
                
                int[] heightWidth = handleFile.readExistingFieldDimensions(gameFieldFileName);
                int h = heightWidth[0];
                int w = heightWidth[1];
                FieldModel loadField = new FieldModel(h, w);
                loadField.gameField = handleFile.readFromFile(gameFieldFileName);

                //quickfix
                GameLogic game = new GameLogic();
                FieldDrawer drawer = new FieldDrawer();

                AliveCellCounter countCells = new AliveCellCounter();

                game.PopulateFieldRandomly(h, w, loadField.gameField);

                while (!(Console.KeyAvailable &&
                         Console.ReadKey(true).Key == ConsoleKey.Escape))
                {
                    int aliveCellsAmount = countCells.CountAliveCells(loadField.gameField);
                    drawer.PrintArray(loadField.gameField);
                    game.RepopulateField(h, w, loadField.gameField, loadField.gameFieldBuffer);
                    game.OverwriteGameField(h, w, loadField.gameField, loadField.gameFieldBuffer);
                    iterationCount++;
                    consoleOut.stopGameMessage(h);
                    consoleOut.PrintAliveCellsAmount(aliveCellsAmount, h);
                    consoleOut.PrintCountOfIterations(h, iterationCount);
                    System.Threading.Thread.Sleep(Constants.threadDelay);
                }

            }
            else
            {
                int height = consoleIn.GetHeight();
                int width = consoleIn.GetWidth();
                FieldModel field = new FieldModel(height, width);

                GameLogic game = new GameLogic();
                FieldDrawer drawer = new FieldDrawer();

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
                    consoleOut.stopGameMessage(height);
                    consoleOut.PrintAliveCellsAmount(aliveCellsAmount, height);
                    consoleOut.PrintCountOfIterations(height, iterationCount);
                    System.Threading.Thread.Sleep(Constants.threadDelay);
                }
                drawer.PrintArray(field.gameField);
                Console.Write("Input [y] to save automaton last state");
                bool saveYes = consoleIn.YesOrNo();
                if (saveYes)
                {
                    consoleOut.AskForFileName();
                    string fileName = consoleIn.GetFileName();
                    handleFile.SaveToNewFile(fileName, field.gameField);
                }
            }
            Console.ReadLine();

        }
    }
}
