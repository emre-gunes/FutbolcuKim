using FutbolcuKimApi.Data;
using FutbolcuKimApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FutbolcuKimApi.Services
{
    public class GameService
    {
        private readonly AppDbContext _context;

        public GameService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Player?> GetTodayPlayer()
        {
            // Tüm futbolcuları ID sırasına göre al
            var players = await _context.Players
                .OrderBy(x => x.Id)
                .ToListAsync();

            // Futbolcu yoksa null döndür
            if (!players.Any())
                return null;

            // Bugünün yıl içindeki sıra numarası
            int dayOfYear = DateTime.Today.DayOfYear;

            // Her gün farklı futbolcu seç
            int playerIndex = (dayOfYear - 1) % players.Count;

            return players[playerIndex];
        }

        public async Task<GuessResult?> MakeGuess(int playerId,string userId)
        {
            var targetPlayer = await GetTodayPlayer();

            var guessedPlayer = await _context.Players
                .FirstOrDefaultAsync(x => x.Id == playerId);

            if (targetPlayer == null || guessedPlayer == null)
                return null;

            bool isCorrect = guessedPlayer.Id == targetPlayer.Id;

            return new GuessResult
            {
                Name = guessedPlayer.Name,

                Nationality = new GuessAttribute
                {
                    Value = TranslateNationality(guessedPlayer.Nationality),
                    Color = guessedPlayer.Nationality == targetPlayer.Nationality
                        ? "🟢"
                        : "🔴"
                },

                Position = new GuessAttribute
                {
                    Value = TranslatePosition(guessedPlayer.Position),
                    Color = guessedPlayer.Position == targetPlayer.Position
                        ? "🟢"
                        : "🔴"
                },

                Age = new GuessAttribute
                {
                    Value = guessedPlayer.Age.ToString(),
                    Color = guessedPlayer.Age == targetPlayer.Age
                        ? "🟢"
                        : guessedPlayer.Age < targetPlayer.Age
                            ? "🟡 ↑"
                            : "🟡 ↓"
                },

                Height = new GuessAttribute
                {
                    Value = guessedPlayer.Height.ToString(),
                    Color = guessedPlayer.Height == targetPlayer.Height
                        ? "🟢"
                        : guessedPlayer.Height < targetPlayer.Height
                            ? "🟡 ↑"
                            : "🟡 ↓"
                },

                PreferredFoot = new GuessAttribute
                {
                    Value = TranslateFoot(guessedPlayer.PreferredFoot),
                    Color = guessedPlayer.PreferredFoot == targetPlayer.PreferredFoot
                        ? "🟢"
                        : "🔴"
                },

                CurrentClub = new GuessAttribute
                {
                    Value = guessedPlayer.CurrentClub,
                    Color = guessedPlayer.CurrentClub == targetPlayer.CurrentClub
                        ? "🟢"
                        : "🔴"
                },

                IsCorrect = isCorrect,
                GameWon = isCorrect
            };
        }


        // =========================
        // ÜLKE ÇEVİRİLERİ
        // =========================

        private string TranslateNationality(string nationality)
        {
            return nationality switch
            {
                "Turkey" => "Türkiye",
                "France" => "Fransa",
                "Norway" => "Norveç",
                "England" => "İngiltere",
                "Brazil" => "Brezilya",
                "Belgium" => "Belçika",
                "Egypt" => "Mısır",
                "Argentina" => "Arjantin",
                "Spain" => "İspanya",

                _ => nationality
            };
        }
        public string TranslateNationalityForHint(string nationality)
        {
            return TranslateNationality(nationality);
        }


        // =========================
        // MEVKİ ÇEVİRİLERİ
        // =========================

        private string TranslatePosition(string position)
        {
            return position switch
            {
                "Midfielder" => "Orta Saha",
                "Forward" => "Forvet",
                "Defender" => "Defans",
                "Goalkeeper" => "Kaleci",

                _ => position
            };
        }


        // =========================
        // AYAK ÇEVİRİLERİ
        // =========================

        private string TranslateFoot(string foot)
        {
            return foot switch
            {
                "Right" => "Sağ",
                "Left" => "Sol",

                _ => foot
            };
        }
    }
}