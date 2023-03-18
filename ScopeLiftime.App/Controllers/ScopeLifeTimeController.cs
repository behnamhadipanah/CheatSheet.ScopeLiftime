using Microsoft.AspNetCore.Mvc;
using ScopeLiftime.Logic.Interfaces;

namespace ScopeLiftime.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScopeLifeTimeController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ITransientService _transientService;
        private readonly ISingletonService _singletonService;
        private readonly IScopedService _scopedService;

        public ScopeLifeTimeController(ILogger logger, ITransientService transientService, ISingletonService singletonService, IScopedService scopedService)
        {
            _logger = logger;
            _transientService = transientService;
            _singletonService = singletonService;
            _scopedService = scopedService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Transient: " + _transientService.InstanceId);
            _logger.LogInformation("Scoped: " + _scopedService.InstanceId);
            _logger.LogInformation("Singleton: " + _singletonService.InstanceId);
            return Ok();
        }
    }
}
