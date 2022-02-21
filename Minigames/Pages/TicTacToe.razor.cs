namespace Minigames.Pages
{
    public partial class TicTacToe
    {
        List<ElementOfMatchField> MatchField;

        List<Player> players;

        Player CurrentPlayer;

        string playerWon;

        const int FieldCount = 3;

        static string Count;

        protected override void OnInitialized()
        {
            InitializingGame();
            NewGame();
            base.OnInitialized();
        }

        public void PrintSymbolOnButton(ElementOfMatchField field)
        {
            if (CurrentPlayer != null)
            {
                field.Symbol = CurrentPlayer.Symbol;
                CurrentPlayer = players.First(x => x != CurrentPlayer);
                var calculate = CalculatePlayerWon();
                //check if game is finished without a winner
                var both = MatchField.Where(x => x.WasClicked == true);
                if (both.Count() == MatchField.Count() && CalculatePlayerWon() != true)
                {
                    playerWon = " ❌ 🔵 ";
                }
                //check if a player has won => lock the entire matchfield

                if (calculate == true)
                {
                    LockField(field);
                }
            }
        }

        public void InitializingGame()
        {
            Player player1 = new Player("Player1", "❌");
            Player player2 = new Player("Player2", "🔵");

            players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
        }

        public void NewGame()
        {
            MatchField = new List<ElementOfMatchField>();
            for (int i = 0; i < FieldCount; i++)
            {
                for (int j = 0; j < FieldCount; j++)
                {
                    MatchField.Add(new ElementOfMatchField(i, j));
                }
            }
            CurrentPlayer = players[0];
            playerWon = null;
        }

        public bool CalculatePlayerWon()
        {
            foreach (var player in players)
            {
                for (int i = 0; i < FieldCount; i++)
                {
                    var allRow1 = MatchField.Where(x => x.Row == i && x.Symbol == player.Symbol);
                    var allRow2 = MatchField.Where(x => x.Column == i && x.Symbol == player.Symbol);

                    if (allRow1.Count() == FieldCount || allRow2.Count() == FieldCount)
                    {
                        playerWon = player.Symbol + " has won.";
                        player.WinCount += 1;
                        return true;
                    }
                }
                var diagonale1 = MatchField.Where(x => (x.Row == 0 && x.Column == 0) || (x.Row == 1 && x.Column == 1) || (x.Row == 2 && x.Column == 2));
                var diagonale2 = MatchField.Where(x => (x.Row == 0 && x.Column == 2) || (x.Row == 1 && x.Column == 1) || (x.Row == 2 && x.Column == 0));

                bool hasWonDiag1 = diagonale1.All(x => x.Symbol == player.Symbol);
                bool hasWonDiag2 = diagonale2.All(x => x.Symbol == player.Symbol);

                if (hasWonDiag1 || hasWonDiag2)
                {
                    playerWon = player.Symbol + " has won.";
                    player.WinCount += 1;
                    return true;
                }
            }
            return false;
        }

        public void LockField(ElementOfMatchField field)
        {
            var fieldNotFilled = MatchField.Where(x => string.IsNullOrEmpty(x.Symbol));
            if (fieldNotFilled != null)
            {
                foreach (var element in fieldNotFilled)
                {
                    element.Symbol = " ";
                }
            }
        }
    }
}
