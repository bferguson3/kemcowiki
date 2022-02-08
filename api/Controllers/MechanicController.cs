using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MechanicController : ControllerBase
    {
        private readonly ILogger<MechanicController> _logger;
        private readonly IDBService _dbService;

        public MechanicController(
            ILogger<MechanicController> logger,
            IDBService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _dbService.GetAllMechanics();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(string id)
        {
            var result = await _dbService.GetSingleMechanic(id);
            return Ok(result);
        }

    }
}