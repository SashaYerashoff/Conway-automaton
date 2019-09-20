using System;

namespace GameOfLife
{
    public class ConsoleInput
    {
        ConsoleOutput consoleOut = new ConsoleOutput();
        
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
