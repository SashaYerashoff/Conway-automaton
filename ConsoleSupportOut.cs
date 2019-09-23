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
    }
}
