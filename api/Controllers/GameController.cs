using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameService _gameService;

        public GameController(
            ILogger<GameController> logger,
            IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [HttpGet(Name = "GetGames")]
        public async Task<IActionResult> Get()
        {
            var result = await _gameService.GetAllGames();
            return Ok(result);
        }
    }
}