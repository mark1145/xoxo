using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ballicon.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ballicon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public ValuesController(IUserRepository userRepository, ILogger<ValuesController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.GetUsersAsync();

            _logger.LogInformation("Info {users}", users);
            _logger.LogWarning("Warning {users}", users);
            _logger.LogError("Error {users}", users);
            _logger.LogCritical("Critical {users}", users);

            if (users != null)
                return Ok(users);

            return BadRequest("Could not access repository");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
