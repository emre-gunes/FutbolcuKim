namespace FutbolcuKimApi.Models
{
    public class GuessResult
    {
        public string Name { get; set; } = "";

        public GuessAttribute Nationality { get; set; } = new();
        public GuessAttribute Position { get; set; } = new();
        public GuessAttribute Age { get; set; } = new();
        public GuessAttribute Height { get; set; } = new();
        public GuessAttribute PreferredFoot { get; set; } = new();
        public GuessAttribute CurrentClub { get; set; } = new();

        public bool IsCorrect { get; set; }
        public bool GameWon { get; set; }
    }

    public class GuessAttribute
    {
        public string Value { get; set; } = "";
        public string Color { get; set; } = "";
    }
}
