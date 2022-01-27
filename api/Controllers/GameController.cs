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

        // these get injected into the constructor based on what we have set up in the Program.cs class
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
            // this is calling the data service with a type of Game, which is used in there
            //  where it has the <T> syntax
            var result = await _dataService.GetAll<Game>();
            return Ok(result);
        }


        [HttpGet("{gameId}")]
        public async Task<IActionResult> GetSingle(string gameId)
        {
            // this is calling the data service with a type of Game, which is used in there
            //  where it has the <T> syntax
            var result = await _dataService.GetSingle<Game>(gameId);
            return Ok(result);
        }
    }
}