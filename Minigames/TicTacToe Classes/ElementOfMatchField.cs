namespace Minigames
{
    public class ElementOfMatchField
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public string Symbol { get; set; }

        public bool WasClicked => !string.IsNullOrEmpty(Symbol);
        public bool Test => !string.IsNullOrEmpty(Symbol);

        public ElementOfMatchField(int row, int column)
        {
            this.Row = row;
            this.Column = column;

        }


    }
}
