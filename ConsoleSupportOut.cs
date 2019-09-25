using System;

namespace GameOfLife
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

        public void PrintFinalStats(int height, int iterationCount)
        {
            Console.SetCursorPosition(0, height);
            Console.WriteLine("Field iterated {0} times", iterationCount);
            Console.ReadLine();
        }
    }
}
