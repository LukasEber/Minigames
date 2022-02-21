using System.Diagnostics;

namespace Minigames

{
    public class RandomWord
    {
        public int Difficulty { get; set; }

        public RandomWord(int difficulty)
        {
            this.Difficulty = difficulty;
        }

        private List<string> wordsEasy = new List<string>
        {
             "time", "year", "people", "way", "day", "man", "thing", "woman", "life", "child", "world", "school", "state",
             "family", "student", "group", "problem", "hand", "part", "place", "case", "week", "system",
             "program", "work", "number", "night", "point", "home", "water", "room", "mother", "area",
             "money", "story", "fact", "month", "lot", "right", "study", "book", "eye", "job", "word", "issue", "side",
             "kind", "head", "house", "friend", "father", "power", "hour", "game", "line", "end", "member", "law", "car",
             "city", "name", "team", "minute", "idea", "kid", "body", "back", "parent",
             "face", "others", "level", "office", "door", "person", "art", "war", "history", "party", "result", "reason"
        };

        private List<string> wordsHard = new List<string>
        {
            "country",  "company", "government", "community", "health", "president", "question", "business", "service",
            "information", "absolutely", "academic", "accomplish", "basically", "campaign", "environmental", "capability"
        };
        public void GenerateEasyRandomWord()
        {
            Random rnd = new Random();
            int index = rnd.Next(wordsEasy.Count());
            string randomWord = wordsEasy[index];
        }

        public void GenerateDifficultRandomWord()
        {
            Random rnd = new Random();
            int index = rnd.Next(wordsHard.Count());
            string randomWord = wordsHard[index];
        }
    }
}
