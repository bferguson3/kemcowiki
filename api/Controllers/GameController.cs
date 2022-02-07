using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IDBService _dbService;

        public GameController(
            ILogger<GameController> logger,
            IDBService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _dbService.GetAllGames();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(string id)
        {
            var result = await _dbService.GetSingleGame(id);
            return Ok(result);
        }
    }
}
