namespace Minigames
{
    public class Gameplayer
    {
        public int RemainingCount { get; set; }

        public string WinOrLoose { get; set; }

        public Gameplayer(int remainingCount)
        {
            this.RemainingCount = remainingCount;
        }
    }
}
