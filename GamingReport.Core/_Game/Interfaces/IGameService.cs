namespace GamingReport.Core._Game.Interfaces
{
    public interface IGameService
    {
        void AddGame(Game game);

        void UpdateGame(Game game);

        void DeleteGame(Game game);

        Game GetGameById(int id);
    }
}
