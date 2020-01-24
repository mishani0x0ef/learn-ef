using System;
using System.Collections.Generic;

namespace ProjectHub.Domain.Environment
{
    public class SiteLink
    {
        /// <summary>
        /// Unique identifier of the link.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// URI of the resource.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Display name of the link.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the link. Additional information about it.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id of the environment current link belong to.
        /// </summary>
        public int EnvironmentId { get; set; }

        /// <summary>
        /// The environment current link belong to.
        /// </summary>
        public Environment Environment { get; set; }

        public List<SiteLinkHashTag> SiteLinkHashTags { get; set; }
    }
}
