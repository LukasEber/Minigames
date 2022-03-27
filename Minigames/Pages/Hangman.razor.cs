

namespace Minigames.Pages
{
    public partial class Hangman
    {
        public string Word { get; set; }

        List<char> letters = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        List<string> wrongLetters = new List<string>() { "a", "d" };
    }
}
