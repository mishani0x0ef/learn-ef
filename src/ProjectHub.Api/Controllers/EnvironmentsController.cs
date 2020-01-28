using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Data;
using ProjectHub.Domain.Environment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHub.Api.Controllers
{
    // TODO: currently I use fat controllers. It should be changed in the future. MR
    [ApiController]
    [Route("api/environments")]
    public class EnvironmentsController : ControllerBase
    {
        private readonly HubContext _context;

        public EnvironmentsController(HubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Environment>> GetEnvironments()
        {
            return await _context.Environments.ToListAsync();
        }

        [HttpGet("{environmentId}")]
        public async Task<Environment> GetEnvironment(int environmentId)
        {
            return await _context.Environments.FindAsync(environmentId);
        }

        [HttpPut]
        public async Task<Environment> AddEnvironment([FromBody]Environment environment)
        {
            // TODO: validate before insert. MR
            var result = _context.Environments.Add(environment);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        [HttpPost("{environmentId}")]
        public async Task<IActionResult> UpdateEnvironment(int environmentId, [FromBody]Environment environment)
        {
            if (environmentId != environment.Id)
                return BadRequest();

            // TODO: validate before insert. MR
            _context.Environments.Update(environment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{environmentId}")]
        public async Task<ActionResult<Environment>> DeleteEnvironment(int environmentId)
        {
            // TODO: use a better way to delete things (stored procedure). MR
            var environment = await _context.Environments.FindAsync(environmentId);

            if (environment is null)
                return NotFound();

            _context.Environments.Remove(environment);
            await _context.SaveChangesAsync();

            return environment;
        }
    }
}
