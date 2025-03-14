using GamingReport.Core._Game;
using GamingReport.Core._Game.Enums;

namespace GamingReport.Core.Reviews
{
    public class Review : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public decimal Score { get; set; }
        public Platforms GamePlatform { get; set; }

        public int UpPoints { get; set; }
        public int DownPoints { get; set; }

        public string GameId { get; set; }
        public Game Game { get; set; }
    }
}
