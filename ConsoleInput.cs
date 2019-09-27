using System;

namespace ConwayAutomaton
{
    public class ConsoleInput
    {
        ConsoleSupportOut consoleOut = new ConsoleSupportOut();
        Validation validateDimensions = new Validation();


        public int GetHeight()
        {
            consoleOut.AskForHeight();
            int height = validateDimensions.ValidateDimensions();
            return height;
        }

        public int GetWidth()
        {
            consoleOut.AskForWidth();
            int width = validateDimensions.ValidateDimensions();
            return width;
        }

        public bool YesOrNo()
        {
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
