using System;

namespace ConwayAutomaton
{
    public class ConsoleSupportOut
    {
        public void AskForHeight()
        {
            Console.Write("Please input field height: ");
        }

        public void AskForWidth()
        {
            Console.Write("Please input field width: ");
        }

        public void AskForYesOrNo()
        {
            Console.Write("Load existing automaton [y]? ");
        }

        public void AskForFileName()
        {
            Console.Write("Please input file name: ");
        }

        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the Conway`s automaton aka `Game of life`!");
        }
        public void stopGameMessage(int height)
        {
            Console.SetCursorPosition(0, height);
            Console.WriteLine("To stop automaton press `esc` button.");
        }
        public void PrintCountOfIterations(int height, int iterationCount)
        {
            Console.SetCursorPosition(0, height + 1);
            Console.WriteLine("Field iterated {0} times", iterationCount);   
        }
        public void PrintAliveCellsAmount (int aliveCells, int height)
        {
            Console.SetCursorPosition(0, height + 2);
            Console.WriteLine("Alive cells: {0}", aliveCells);
        }
    }
}
