namespace Minigames
{
    public class Player
    {
        public string Name { get; set; }

        public string Symbol { get; set; }

        public int WinCount { get; set; }

        public Player(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}
