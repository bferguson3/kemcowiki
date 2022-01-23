using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IDataService _dataService;

        public GameController(
            ILogger<GameController> logger,
            IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _dataService.GetAll<Game>();
            return Ok(result);
        }


        [HttpGet("{gameId}")]
        public async Task<IActionResult> GetSingle(string gameId)
        {
            var result = await _dataService.GetSingle<Game>(gameId);
            return Ok(result);
        }
    }
}