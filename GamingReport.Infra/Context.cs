using GamingReport.Core._Developer;
using GamingReport.Core._Game;
using GamingReport.Core._Game.Enums;
using GamingReport.Core.Reviews;
using Microsoft.EntityFrameworkCore;

namespace GamingReport.Infra
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var developer1 = new Developer
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Developer One"
            };

            var developer2 = new Developer
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Developer Two"
            };

            var game1 = new Game
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Game One",
                Description = "Description for Game One",
                Platform = new List<Platforms> { Platforms.Xbox, Platforms.Steam },
                DeveloperId = developer1.Id
            };

            var game2 = new Game
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Game Two",
                Description = "Description for Game Two",
                Platform = new List<Platforms> { Platforms.PlayStation, Platforms.Nintendo },
                DeveloperId = developer2.Id
            };

            var review1 = new Review
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Review One",
                Content = "Content for Review One",
                Score = 8.5m,
                UpPoints = 10,
                DownPoints = 2,
                GameId = game1.Id
            };

            var review2 = new Review
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Review Two",
                Content = "Content for Review Two",
                Score = 9.0m,
                UpPoints = 15,
                DownPoints = 1,
                GameId = game2.Id 
            };

            modelBuilder.Entity<Developer>().HasData(developer1, developer2);
            modelBuilder.Entity<Game>().HasData(game1, game2);
            modelBuilder.Entity<Review>().HasData(review1, review2);
        }

    }
}