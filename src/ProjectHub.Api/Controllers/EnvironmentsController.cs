using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Data;
using ProjectHub.Data.Utils;
using ProjectHub.Domain.Environment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHub.Api.Controllers
{
    // TODO: currently I use fat controllers. It should be changed in the future. MR
    /// <summary>
    /// Controller for manipulations with <see cref="Environment"/>.
    /// </summary>
    [ApiController]
    [Route("api/environments")]
    public class EnvironmentsController : ControllerBase
    {
        private readonly HubContext _context;

        /// <summary>
        /// Create a new instance of the controller.
        /// </summary>
        public EnvironmentsController(HubContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a list of all available environments.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<Environment>> GetEnvironments()
        {
            return await _context.Environments.ToListAsync();
        }

        /// <summary>
        /// Get a specific environment by it's unique identifier.
        /// </summary>
        /// <param name="environmentId">ID of the environment to retrieve.</param>
        [HttpGet("{environmentId}")]
        public async Task<Environment> GetEnvironment(int environmentId)
        {
            return await _context.Environments.FindAsync(environmentId);
        }

        /// <summary>
        /// Get extended info about the environment by it's identifier.
        /// </summary>
        /// <param name="environmentId">ID of the environment to retrieve</param>
        [HttpGet("{environmentId}/details")]
        public async Task<EnvironmentDetails> GetEnvironmentDetails(int environmentId)
        {
            return await _context.EnvironmentDetails.FirstOrDefaultAsync(e => e.Id == environmentId);
        }

        /// <summary>
        /// Get an environment that was added latest.
        /// It's quite synthetic method just for EF concepts testing.
        /// TODO: remove in the future.
        /// </summary>
        /// <returns></returns>
        [HttpGet("latest")]
        public async Task<Environment> GetLatestEnvironment()
        {
            return await _context.Environments
                .FirstOrDefaultAsync(e => e.Id == _context.GetLatestEnvironment());
        }

        /// <summary>
        /// Add new environment.
        /// </summary>
        /// <param name="environment">The environment to be added.</param>
        /// <returns>Created environment including identity of newly created entity.</returns>
        [HttpPut]
        public async Task<Environment> AddEnvironment([FromBody]Environment environment)
        {
            // TODO: validate before insert. MR
            var result = _context.Environments.Add(environment);
            
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        /// <summary>
        /// Update an existing environment with new data.
        /// </summary>
        /// <param name="environmentId">Identity of the environment to be updated.</param>
        /// <param name="environment">New data to update the environment.</param>
        [HttpPost("{environmentId}")]
        public async Task<IActionResult> UpdateEnvironment(int environmentId, [FromBody]Environment environment)
        {
            if (environmentId != environment.Id)
                return BadRequest();

            // TODO: validate before insert. MR
            _context.Environments
                .Update(environment)
                .UpdateLastModified();
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Delete an environment by it's identity.
        /// </summary>
        /// <param name="environmentId">Identity of the environment to be deleted.</param>
        /// <returns>Details about the environment that was deleted.</returns>
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
