namespace Minigames
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}
