using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly ILogger<StaffController> _logger;
        private readonly IDBService _dbService;

        public StaffController(
            ILogger<StaffController> logger,
            IDBService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _dbService.GetAllStaff();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(string id)
        {
            var result = await _dbService.GetSingleStaff(id);
            return Ok(result);
        }
    }
}