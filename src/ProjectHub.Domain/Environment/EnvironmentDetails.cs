using System;

namespace ProjectHub.Domain.Environment
{
    /// <summary>
    /// Provide detailed environment information.
    /// </summary>
    public class EnvironmentDetails
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

        /// <summary>
        /// Total count of available site links.
        /// </summary>
        public int SitesCount { get; set; }

        /// <summary>
        /// Date and time when the environment was last modified.
        /// </summary>
        public DateTime LastModified { get; set; }
    }
}
