using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Data;
using ProjectHub.Data.Utils;
using ProjectHub.Domain.Environment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHub.Api.Controllers
{
    /// <summary>
    /// Controller to manage<see cref="SiteLink"/>.
    /// </summary>
    [ApiController]
    [Route("api/siteLinks")]
    public class SiteLinksController : ControllerBase
    {
        private readonly HubContext _context;

        /// <summary>
        /// Create new instance of the controller.
        /// </summary>
        public SiteLinksController(HubContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all available links in the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<SiteLink>> GetLinks()
        {
            return await _context.SiteLinks.ToListAsync();
        }

        /// <summary>
        /// Get details about a specific link by it's identity.
        /// </summary>
        /// <param name="linkId">Identity of the link to get.</param>
        /// <returns>Link details.</returns>
        [HttpGet("linkId")]
        public async Task<SiteLink> GetLink(int linkId)
        {
            return await _context.SiteLinks.FindAsync(linkId);
        }

        /// <summary>
        /// Update a specific link with new info.
        /// </summary>
        /// <param name="linkId">Identity of the link to be updated.</param>
        /// <param name="link">New info about the link.</param>
        [HttpPost("{linkId}")]
        public async Task<IActionResult> UpdateLink(int linkId, [FromBody]SiteLink link)
        {
            if (linkId != link.Id)
                return BadRequest();

            _context.SiteLinks
                .Update(link)
                .UpdateLastModified();

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
