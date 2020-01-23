using System.Collections.Generic;

namespace ProjectHub.Domain.Environment
{
    public class Environment
    {
        /// <summary>
        /// Unique identifier of the environment within the system.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Display name of the environment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Details about the environment.
        /// </summary>
        public string Description { get; set; }

        public ICollection<SiteLink> SiteLinks { get; set; }
    }
}
