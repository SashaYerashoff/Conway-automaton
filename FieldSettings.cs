
namespace GameOfLife
{
    public class FieldSettings
    {  
        public int FieldHeight { get; set; }
        public int FieldWidth { get; set; }

        public FieldSettings(int fieldHeight, int fieldWidth)
        {
            FieldHeight = fieldHeight;
            FieldWidth = fieldWidth;
        }
    }
}
