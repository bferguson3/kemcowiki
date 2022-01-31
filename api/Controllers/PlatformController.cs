using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly ILogger<PlatformController> _logger;
        private readonly IDBService _dbService;

        public PlatformController(
            ILogger<PlatformController> logger,
            IDBService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _dbService.GetAllPlatforms();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(string id)
        {
            var result = await _dbService.GetSinglePlatform(id);
            return Ok(result);
        }
    }
}