namespace Minigames
{
    public class Gameplayer
    {
        public string Name { get; set; }

        public int RemainingCount { get; set; }

        public int CountOfWin { get; set; }

        public bool WinOrLoose { get; set; }

        public Gameplayer(string name, int remainingCount)
        {
            this.Name = name;
            this.RemainingCount = remainingCount;
        }
    }
}
