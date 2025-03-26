using GamingReport.Core._Game.Interfaces;
using GamingReportApi.InputModels;
using GamingReportApi.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace GamingReportApi.Controllers
{
    [ApiController]
    [Route("api/game")]
    public class GameController : ControllerBase
    {

        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }


        //Para testes apenas
        [HttpPost]
        public async Task<IActionResult> PostGame([FromBody] GameIM gameIM)
        {
            var response = _gameService.GetGameByName(gameIM.Name);

            if(response.IsSuccess)
            {
                response.Data.Id = new Guid().ToString();

                _gameService.AddGame(response.Data);
            }

            return Created();
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetGameByName(string name)
        {
            var response = _gameService.GetGameByName(name);
            if (response.IsSuccess)
            {
                return Ok(response.Data.Adapt<GameVM>());
            }


            return NotFound(response.Message);
        }
    }
}