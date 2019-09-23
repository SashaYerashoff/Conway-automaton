using System;

namespace GameOfLife
{
    public class ConsoleInput
    {
        ConsoleSupportOut consoleOut = new ConsoleSupportOut();
        
        public int GetHeight()
        {
            consoleOut.AskForHeight();
            int height = Convert.ToInt16(Console.ReadLine());
            return height;
        }

        public int GetWidth()
        {
            consoleOut.AskForWidth();
            int width = Convert.ToInt16(Console.ReadLine());
            return width;
        }
        
    }
}
