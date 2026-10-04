namespace FutbolcuKimApi.Models
{
    public class DailyGame
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public DateTime Date { get; set; }

        public Player Player { get; set; }
    }
}
