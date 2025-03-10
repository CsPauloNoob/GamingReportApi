using GamingReport.Core._Developer;
using GamingReport.Core._Game.Enums;

namespace GamingReport.Core._Game
{
#pragma warning disable
    public class Game : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Platforms> Platform { get; set; } = new();

        public string DeveloperId { get; set; }
        public Developer Developer { get; set; }

        public Game() {}

    }
}
