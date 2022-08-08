using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [EnableCors("NativeOrigin")]
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

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] Game newEntry)
        {
            if (newEntry == null){
                return BadRequest();
            }
            var result = await _dbService.AddNewGame(newEntry);
            return Ok(result);
        }
    }
}
