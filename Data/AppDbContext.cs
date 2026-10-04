using FutbolcuKimApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FutbolcuKimApi.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<DailyGame> DailyGames { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<UserGuess> UserGuesses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserGame>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserGuess>()
                .HasOne(x => x.UserGame)
                .WithMany(x => x.Guesses)
                .HasForeignKey(x => x.UserGameId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserGuess>()
                .HasOne(x => x.Player)
                .WithMany()
                .HasForeignKey(x => x.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
