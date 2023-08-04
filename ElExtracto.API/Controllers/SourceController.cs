using Microsoft.AspNetCore.Mvc;

namespace ElExtracto.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SourceController : ControllerBase
    {
        private readonly ILogger<SourceController> _logger;

        public SourceController(ILogger<SourceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Array.Empty<string>();
        }
    }
}