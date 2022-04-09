namespace Minigames.Pages
{
    public partial class Hangman
    {
        private string word;
        private List<string> UnderscoreWord = new List<string>() { };
        private List<char> letters = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private List<char> wrongLetters = new List<char>() { };
        private List<string> remainingAttempts = new List<string>() { "❌", "❌", "❌", "❌", "❌" };

        protected override void OnInitialized()
        {
            ReplaceLetterToUnderscore();
            SetFirstLetter();
            base.OnInitialized();
        }
        public void GetWord()
        {
            RandomWord randomword = new RandomWord();
            randomword.GenerateRandomWord();
            word = randomword.CurrentWord;

        }
        public void ReplaceLetterToUnderscore()
        {
            GetWord();
            int count = 0;
            while (count < this.word.Length)
            {
                UnderscoreWord.Add("▃");
                count++;
            }
        }
        public void ReadLetter(char letter)
        {
            if (word.Contains(letter))
            {
                var foundIndexes = new List<int>();
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == letter)
                        foundIndexes.Add(i);
                }
                foreach (var i in foundIndexes)
                {
                    UnderscoreWord[i] = letter.ToString();
                }
                PlayerWon();
            }
            else
            {
                if (!wrongLetters.Contains(letter))
                {
                    remainingAttempts.RemoveAt(1);
                    AddWrongLetter(letter);
                    PlayerLost();
                }
            }
        }
        public void PlayerWon()
        {
            if (!UnderscoreWord.Contains("▃"))
            {
                remainingAttempts.Clear();
                remainingAttempts.Add("✯ You won! ✯");
                letters.Clear();
            }
        }
        public void NewGame()
        {
            wrongLetters.Clear();
            UnderscoreWord.Clear();
            List<string> remaining = new List<string>() { "❌", "❌", "❌", "❌", "❌" };
            List<char> let = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            remainingAttempts = remaining;
            letters = let;
            OnInitialized();
        }
        public void PlayerLost()
        {
            if (wrongLetters.Count == 4)
            {
                remainingAttempts.Clear();
                remainingAttempts.Add($" You lost!  the word was {word}.");
                letters.Clear();
            }
        }
        public void SetFirstLetter()
        {
            int index = word.IndexOf(word.First());
            UnderscoreWord[0] = word[index].ToString();
        }
        public void AddWrongLetter(char letter)
        {
            wrongLetters.Add(letter);
        }
    }
}
