namespace Minigames.Pages
{
    public partial class Hangman
    {
        private string currentword;

        private List<string> wordAsUnderscore = new List<string>() { };

        private List<char> alphabet = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        private List<char> wrongLetters = new List<char>() { };

        private List<string> remainingAttempts = new List<string>() { "❌", "❌", "❌", "❌", "❌", "❌", "❌", "❌" };

        private bool gameover = false;

        private string? lostMessage;

        protected override void OnInitialized()
        {
            ReplaceLetterToUnderscore();
            SetFirstLetter();
            base.OnInitialized();
        }
        
        private void ReplaceLetterToUnderscore()
        {
            GetWord();
            int count = 0;
            while (count < this.currentword.Length)
            {
                wordAsUnderscore.Add("▃");
                count++;
            }
        }

        private void GetWord()
        {
            RandomWord randomword = new RandomWord();
            randomword.GenerateRandomWord();
            currentword = randomword.CurrentWord;
        }

        private void SetFirstLetter()
        {
            GetAllIndexes(currentword[0]);
        }
        private void GetAllIndexes(char letter)
        {
            var foundIndexes = new List<int>();
            for (int i = 0; i < currentword.Length; i++)
            {
                if (currentword[i] == letter)
                    foundIndexes.Add(i);
            }
            foreach (var i in foundIndexes)
            {
                wordAsUnderscore[i] = letter.ToString();
            }
        }

        private void ReadLetter(char letter)
        {
            if (currentword.Contains(letter))
            {
                CurrentWordContainsUserInput(letter);
            }
            else
            {
                CurrentWordDoesNotContainUnserInput(letter);
            }
        }

        private void CurrentWordContainsUserInput(char letter)
        {
            GetAllIndexes(letter);
            PlayerWon();
        }

        private void CurrentWordDoesNotContainUnserInput(char letter)
        {
            if (!wrongLetters.Contains(letter))
            {
                remainingAttempts.RemoveAt(1);
                AddWrongLetterToList(letter);
                PlayerLost();
            }
        }
        private void AddWrongLetterToList(char letter)
        {
            wrongLetters.Add(letter);
        }

        private void PlayerWon()
        {
            if (!wordAsUnderscore.Contains("▃"))
            {
                remainingAttempts.Clear();
                remainingAttempts.Add("✯ You won! ✯");
                alphabet.Clear();
            }
        }

        private void PlayerLost()
        {
            if (wrongLetters.Count == 7)
            {
                gameover = true;
                remainingAttempts.Clear();
                lostMessage = $" You lost! The word was {currentword}.";
            }
        }

        private void NewGame()
        {
            wrongLetters.Clear();
            wordAsUnderscore.Clear();
            List<string> remaining = new List<string>() { "❌", "❌", "❌", "❌", "❌", "❌", "❌", "❌" };
            List<char> letters = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            remainingAttempts = remaining;
            alphabet = letters;
            gameover = false;
            OnInitialized();
        }
    }
}

