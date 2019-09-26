using System;

namespace ConwayAutomaton
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
        public bool YesOrNo()
        {
            consoleOut.AskForYesOrNo();
            string userInput = Console.ReadLine();
            if (userInput == "y")
            {
                return true;
            }
            return false;
        }
        public string GetFileName()
        {
            string fileName = Console.ReadLine();
            return fileName;
        }
    }
}
