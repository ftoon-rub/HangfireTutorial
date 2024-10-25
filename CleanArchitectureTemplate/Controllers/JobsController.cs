using ApplicationLayer.Interfaces.InfrastructureLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HangfireApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService _jobsService;

        public JobsController(IJobsService jobsService)
        {
            _jobsService = jobsService;
        }

        // GET: api/<JobsController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetOneTime()
        {
            _jobsService.OneTime();
            return Ok();
        }

        // GET: api/<JobsController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetDelayed()
        {
            _jobsService.Delayed();

            return Ok();
        }

        // GET: api/<JobsController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetRecurring()
        {
            _jobsService.Recurring();

            return Ok();
        }

        // GET: api/<JobsController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetContinuation()
        {
            _jobsService.Continuation();

            return Ok();
        }
    }
}
