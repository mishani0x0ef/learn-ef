using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Data;
using ProjectHub.Data.Utils;
using ProjectHub.Domain.Environment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHub.Api.Controllers
{
    [ApiController]
    [Route("api/siteLinks")]
    public class SiteLinksController : ControllerBase
    {
        private readonly HubContext _context;

        public SiteLinksController(HubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<SiteLink>> GetLinks()
        {
            return await _context.SiteLinks.ToListAsync();
        }

        [HttpGet("linkId")]
        public async Task<SiteLink> GetLink(int linkId)
        {
            return await _context.SiteLinks.FindAsync(linkId);
        }

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
