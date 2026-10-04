using System.ComponentModel.DataAnnotations;

namespace FutbolcuKimApi.Models
{
    public class UserGame
    {
        public int Id { get; set; }

        public string UserId { get; set; } = "";

        public ApplicationUser User { get; set; } = null!;

        public DateTime GameDate { get; set; } = DateTime.Today;

        public int GuessCount { get; set; }

        public bool IsWon { get; set; }

        public DateTime PlayedAt { get; set; } = DateTime.UtcNow;

        public ICollection<UserGuess> Guesses { get; set; } = new List<UserGuess>();
    }
}
