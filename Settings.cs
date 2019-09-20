
namespace GameOfLife
{
    public class Settings
    {  
        public static int FieldHeight { get; set; }
        public static int FieldWidth { get; set; }

        public const int chanceToBeAlive = 2;
        public const int aliveLowerLimit = 3;
        public const int aliveUpperLimit = 4;
        public const int aliveByReproduction = 3;
        public const int threadDelay = 1000;
        public const int amountOfGenerations = 60;
        public const char livingCellSymbol = '*';
        public const char deadCellSymbol = ' ';

        public Settings(int fieldHeight, int fieldWidth)
        {
            FieldHeight = fieldHeight;
            FieldWidth = fieldWidth;
        }
    }
}
