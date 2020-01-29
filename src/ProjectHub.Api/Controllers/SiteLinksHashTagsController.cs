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
    /// <summary>
    /// Controller for managing hashtags for site links.
    /// </summary>
    [ApiController]
    [Route("api/siteLinks")]
    public class SiteLinksHashTagsController : ControllerBase
    {
        private readonly HubContext _context;

        /// <summary>
        /// Create a controller instance.
        /// </summary>
        public SiteLinksHashTagsController(HubContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all hashtags available for a specific link.
        /// </summary>
        /// <param name="linkId">Identity of the link to get tags for.</param>
        /// <returns>Collection of tags.</returns>
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

        /// <summary>
        /// Add tag to a specific link.
        /// <para>If tag doesn't exist yet - it will be created.</para>
        /// </summary>
        /// <param name="linkId">Identity of the link to add tag to.</param>
        /// <param name="tag">Tag that should be added to the link.</param>
        [HttpPost("{linkId}/hashtags")]
        public async Task<IActionResult> AddHashTag(int linkId, [FromBody]HashTag tag)
        {
            var link = await _context.SiteLinks
                .Include(l => l.SiteLinkHashTags)
                .FirstOrDefaultAsync(l => l.Id == linkId);

            if (link is null)
                return NotFound();

            // TODO: maybe it's better to match tag by name rather then id. MR
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

        /// <summary>
        /// Remove tag from the link.
        /// </summary>
        /// <param name="linkId">Identity of the link to remove tag from.</param>
        /// <param name="tagId">Identity of the tag to remove.</param>
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
