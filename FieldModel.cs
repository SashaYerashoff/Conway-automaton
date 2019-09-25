
namespace ConwayAutomaton
{
    public class FieldModel
    { 
        public bool[,] gameField { get; set; }
        public bool[,] gameFieldBuffer { get; set; }

        public FieldModel(int height, int width)
        {
            gameField = new bool[height, width];
            gameFieldBuffer = new bool[height, width];
        }

    }
}
