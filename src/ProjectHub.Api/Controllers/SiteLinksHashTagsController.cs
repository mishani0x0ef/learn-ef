using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Data;
using ProjectHub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHub.Api.Controllers
{
    [ApiController]
    [Route("api/siteLinks")]
    public class SiteLinksHashTagsController : ControllerBase
    {
        private readonly HubContext _context;

        public SiteLinksHashTagsController(HubContext context)
        {
            _context = context;
        }

        [HttpGet("{linkId}/hashtags")]
        public async Task<IEnumerable<HashTag>> GetHashTags(int linkId)
        {
            var link = await _context.SiteLinks
                .Include(link => link.SiteLinkHashTags)
                .ThenInclude(linkTag => linkTag.HashTag)
                .Where(link => link.Id == linkId)
                .FirstOrDefaultAsync();

            return link.GetHashTags();
        }
    }
}
