using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Data;
using ProjectHub.Domain.Environment;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHub.Api.Controllers
{
    /// <summary>
    /// Controller to manipulate with <see cref="SiteLink"/> related to a specific environment.
    /// </summary>
    [ApiController]
    [Route("api/environments")]
    public class EnvironmentSiteLinksController : ControllerBase
    {
        private readonly HubContext _context;

        /// <summary>
        /// Create new instance of the controller.
        /// </summary>
        public EnvironmentSiteLinksController(HubContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all links assigned to a specific environment.
        /// </summary>
        /// <param name="environmentId">Identity of the environment to get links for.</param>
        /// <returns>Collection of links.</returns>
        [HttpGet("{environmentId}/siteLinks")]
        public async Task<IEnumerable<SiteLink>> GetLinks(int environmentId)
        {
            return await _context.SiteLinks
                .Where(link => link.EnvironmentId == environmentId)
                .ToListAsync();
        }

        /// <summary>
        /// Add site link to a specific environment.
        /// </summary>
        /// <param name="environmentId">Identity of the environment to add link to.</param>
        /// <param name="link">Link that should be added to the environment.</param>
        /// <returns>Newly added link including it's identity.</returns>
        [HttpPut("{environmentId}/siteLinks")]
        public async Task<SiteLink> AddSiteLinkToEnvironment(int environmentId, [FromBody]SiteLink link)
        {
            link.EnvironmentId = environmentId;
            var linkEntry = _context.SiteLinks.Add(link);
            await _context.SaveChangesAsync();
            return linkEntry.Entity;
        }
    }
}
