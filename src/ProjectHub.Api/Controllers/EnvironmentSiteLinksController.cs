using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Data;
using ProjectHub.Domain.Environment;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHub.Api.Controllers
{
    [ApiController]
    [Route("api/environments")]
    public class EnvironmentSiteLinksController : ControllerBase
    {
        private readonly HubContext _context;

        public EnvironmentSiteLinksController(HubContext context)
        {
            _context = context;
        }

        [HttpGet("{environmentId}/siteLinks")]
        public async Task<IEnumerable<SiteLink>> GetLinks(int environmentId)
        {
            return await _context.SiteLinks
                .Where(link => link.EnvironmentId == environmentId)
                .ToListAsync();
        }

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
