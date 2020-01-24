using ProjectHub.Domain.Common;

namespace ProjectHub.Domain.Environment
{
    public class SiteLinkHashTag
    {
        public int SiteLinkId { get; set; }
        public SiteLink SiteLink { get; set; }
        public int HashTagId { get; set; }
        public HashTag HashTag { get; set; }
    }
}
 