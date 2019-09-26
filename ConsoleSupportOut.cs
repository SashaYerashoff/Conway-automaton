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
