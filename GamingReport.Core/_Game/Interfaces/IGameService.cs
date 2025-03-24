using GamingReport.Core.Response;


namespace GamingReport.Core._Game.Interfaces
{
    public interface IGameService
    {
        void AddGame(Game game);

        void UpdateGame(Game game);

        void DeleteGame(Game game);

        ServiceResponse<Game> GetGameById(int id);

        ServiceResponse<Game> GetGameByName(string name);
    }
}
