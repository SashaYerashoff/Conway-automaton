using System;
using System.Threading.Tasks;

namespace ConwayAutomaton
{
    public class Menu
    {
        public void run()
        {
            ConsoleSupportOut consoleOut = new ConsoleSupportOut();
            ConsoleInput consoleIn = new ConsoleInput();
            FileHandler fileHandler = new FileHandler();

            consoleOut.WelcomeMessage();
            consoleOut.AskForLoadGame();

            bool startFromFile = consoleIn.YesOrNo();
            if (startFromFile)
            {
                SavedGameLauncher savedGame = new SavedGameLauncher();
                savedGame.startGameFromFile();
            }

            else
            {
                ConsoleGameLauncher consoleGame = new ConsoleGameLauncher();
                consoleGame.StartConsoleGame();

                Parallel.For(0, 10, (i, state) =>
                {
                    Console.WriteLine($"game {i} statred.");
                    BackgroundGameLauncher backgroundGame = new BackgroundGameLauncher();
                    backgroundGame.StartGameInBackground(10, 10, i);
                    //Console.SetCursorPosition(0, 25+i);
                    Console.WriteLine($"game {i} Stopped. amount of alive cells: " + backgroundGame.aliveCells);
                });
            }
        }
    }
}
