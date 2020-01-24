using ProjectHub.Domain.Environment;
using System.Collections.Generic;

namespace ProjectHub.Domain.Common
{
    public class HashTag
    {
        /// <summary>
        /// Unique identifier of the hash tag within the system.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Hash tag name. Must contain no spaces.
        /// </summary>
        public string Name { get; set; }

        public List<SiteLinkHashTag> SiteLinkHashTags { get; set; }
    }
}
