using GamingReport.Core._Game.Interfaces;
using GamingReport.Core.Interfaces;
using GamingReport.Core.Response;


namespace GamingReport.Core._Game.Services
{
    public class GameServices : IGameService
    {
        private readonly IRepository<Game> _repository;


        public GameServices(IRepository<Game> repository)
        {
            _repository = repository;
        }



        public void AddGame(Game game)
        {
            _repository.Add(game);
        }

        public void DeleteGame(Game game)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Game> GetGameById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Game> GetGameByName(string name)
        {
            Game game = _repository?.GetByName(name);

            if(game is null)
                return ServiceResponse<Game>.NotFound();

            return ServiceResponse<Game>.Success(game);
        }

        public void UpdateGame(Game game)
        {
            
        }
    }
}
