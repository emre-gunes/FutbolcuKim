namespace FutbolcuKimApi.Models
{
    public class UserGuess
    {
    public int Id { get; set; }

    public int UserGameId { get; set; }

    public UserGame UserGame { get; set; } = null!;

    public int PlayerId { get; set; }

    public Player Player { get; set; } = null!;

    public int GuessNumber { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
