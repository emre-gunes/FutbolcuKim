
using FutbolcuKimApi.Data;
using FutbolcuKimApi.Models;

namespace FutbolcuKimApi.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Players.Any())
            {
                var players = new List<Player>
                {
                    new Player
                    {
                        Name = "Hakan Çalhanoğlu",
                        Nationality = "Turkey",
                        Position = "Midfielder",
                        Age = 32,
                        Height = 178,
                        PreferredFoot = "Right",
                        CurrentClub = "Inter"
                    },

                    new Player
                    {
                        Name = "Kylian Mbappe",
                        Nationality = "France",
                        Position = "Forward",
                        Age = 27,
                        Height = 178,
                        PreferredFoot = "Right",
                        CurrentClub = "Real Madrid"
                    },

                    new Player
                    {
                        Name = "Erling Haaland",
                        Nationality = "Norway",
                        Position = "Forward",
                        Age = 26,
                        Height = 195,
                        PreferredFoot = "Left",
                        CurrentClub = "Manchester City"
                    },

                    new Player
                    {
                        Name = "Jude Bellingham",
                        Nationality = "England",
                        Position = "Midfielder",
                        Age = 23,
                        Height = 186,
                        PreferredFoot = "Right",
                        CurrentClub = "Real Madrid"
                    },

                    new Player
                    {
                        Name = "Vinicius Junior",
                        Nationality = "Brazil",
                        Position = "Forward",
                        Age = 26,
                        Height = 176,
                        PreferredFoot = "Right",
                        CurrentClub = "Real Madrid"
                    },

                    new Player
                    {
                        Name = "Kevin De Bruyne",
                        Nationality = "Belgium",
                        Position = "Midfielder",
                        Age = 35,
                        Height = 181,
                        PreferredFoot = "Right",
                        CurrentClub = "Napoli"
                    },

                    new Player
                    {
                        Name = "Mohamed Salah",
                        Nationality = "Egypt",
                        Position = "Forward",
                        Age = 34,
                        Height = 175,
                        PreferredFoot = "Left",
                        CurrentClub = "Liverpool"
                    },

                    new Player
                    {
                        Name = "Lautaro Martinez",
                        Nationality = "Argentina",
                        Position = "Forward",
                        Age = 29,
                        Height = 174,
                        PreferredFoot = "Right",
                        CurrentClub = "Inter"
                    },

                    new Player
                    {
                        Name = "Pedri",
                        Nationality = "Spain",
                        Position = "Midfielder",
                        Age = 23,
                        Height = 174,
                        PreferredFoot = "Right",
                        CurrentClub = "Barcelona"
                    },

                    new Player
                    {
                        Name = "Bukayo Saka",
                        Nationality = "England",
                        Position = "Forward",
                        Age = 25,
                        Height = 178,
                        PreferredFoot = "Left",
                        CurrentClub = "Arsenal"
                    }
                };

                context.Players.AddRange(players);
                context.SaveChanges();
            }

        }
    }
}