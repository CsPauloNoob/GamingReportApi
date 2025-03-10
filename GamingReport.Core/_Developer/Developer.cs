using GamingReport.Core._Game;

namespace GamingReport.Core._Developer
{
    public class Developer : Entity
    {
        public string Name { get; set; }

        public List<Game> Games { get; set; }
    }
}