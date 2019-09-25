
namespace GameOfLife
{
    public class AliveCellCounter
    {
        public int CountAliveCells( bool[,] initialArray)
        {
            int counter = 0;
            foreach (bool position in initialArray)
            {
                if (position == true)
                { 
                    counter++;
                }
            }
            return counter;
        }
    }
}
