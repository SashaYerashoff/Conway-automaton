using System;

namespace ConwayAutomaton
{
    public class BackgroundGameLauncher
    {
        public int aliveCells;
        public void StartGameInBackground(int height, int width, int position)
        {
            GameLogic game = new GameLogic();
            FieldModel field = new FieldModel(height, width);
            AliveCellCounter countCells = new AliveCellCounter();

            game.PopulateFieldRandomly(height, width, field.gameField);
            while (!(Console.KeyAvailable &&
                     Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                game.RepopulateField(height, width, field.gameField, field.gameFieldBuffer);
                game.OverwriteGameField(height, width, field.gameField, field.gameFieldBuffer);
                //Console.SetCursorPosition(0, position);
                //Console.WriteLine(aliveCells = countCells.CountAliveCells(field.gameField));
            }
            
        }   
    }
}
