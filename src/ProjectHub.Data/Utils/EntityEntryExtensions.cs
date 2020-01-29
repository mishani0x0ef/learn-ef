using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

namespace ProjectHub.Data.Utils
{
    /// <summary>
    /// Set of extensions for <see cref="EntityEntry"/>.
    /// </summary>
    public static class EntityEntryExtensions
    {
        /// <summary>
        /// Update value of the LastModified column if exists to the current date and time.
        /// <para>Useful when an entity is just being updated.</para>
        /// <para>Must be called before <see cref="Microsoft.EntityFrameworkCore.DbContext.SaveChanges()"/></para>
        /// </summary>
        /// <param name="entry">Entry to be updated.</param>
        public static EntityEntry<T> UpdateLastModified<T>(this EntityEntry<T> entry) where T : class
        {
            if (entry is null)
                throw new ArgumentNullException(nameof(entry));

            var containsLastModified = entry.Properties.Any(p => p.Metadata.Name == "LastModified");
            if (!containsLastModified)
                return entry;

            entry.Property<DateTime>("LastModified").CurrentValue = DateTime.Now;
            return entry;
        }
    }
}
