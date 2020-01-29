using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Data;
using ProjectHub.Domain.Common;
using ProjectHub.Domain.Environment;
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

        [HttpPost("{linkId}/hashtags")]
        public async Task<IActionResult> AddHashTag(int linkId, [FromBody]HashTag tag)
        {
            var link = await _context.SiteLinks
                .Include(l => l.SiteLinkHashTags)
                .FirstOrDefaultAsync(l => l.Id == linkId);

            if (link is null)
                return NotFound();

            var tagAlreadyExists = link.SiteLinkHashTags
                .Select(lt => lt.HashTagId)
                .Contains(tag.Id);

            if (tagAlreadyExists)
                return Ok();

            _context.Attach(link);
            _context.Update(new SiteLinkHashTag
            {
                SiteLinkId = linkId,
                HashTag = tag,
            });

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{linkId}/hashtags/{tagId}")]
        public async Task RemoveHashTag(int linkId, int tagId)
        {
            var linkTag = _context.SiteLinks
                .Include(l => l.SiteLinkHashTags)
                .FirstOrDefault(l => l.Id == linkId)
                .SiteLinkHashTags
                .Where(lt => lt.HashTagId == tagId)
                .FirstOrDefault();

            if (linkTag is null)
                return;

            _context.Remove(linkTag);
            await _context.SaveChangesAsync();
        }
    }
}
