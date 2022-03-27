

namespace Minigames.Pages
{
    public partial class HangmanChooseGame
    {
       public void StartEasyGame()
        {
            RandomWord word = new RandomWord();
            word.GenerateEasyRandomWord();
            Hangman hangman = new Hangman();
            hangman.Word = word.CurrentWord;
            
        }

        public void StartHardGame()
        {
            RandomWord word = new RandomWord();
            word.GenerateDifficultRandomWord();
            Hangman hangman = new Hangman();
            hangman.Word = word.CurrentWord;
        }
    }
}
