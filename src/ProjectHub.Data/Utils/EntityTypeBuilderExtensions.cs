using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ProjectHub.Data.Utils
{
    internal static class EntityTypeBuilderExtensions
    {
        public static EntityTypeBuilder<T> AddCreatedAtProperty<T>(this EntityTypeBuilder<T> builder) where T : class
            => AddDateTimeProperty(builder, "CreatedAt");

        public static EntityTypeBuilder<T> AddLastModifiedProperty<T>(this EntityTypeBuilder<T> builder) where T : class
            => AddDateTimeProperty(builder, "LastModified");

        private static EntityTypeBuilder<T> AddDateTimeProperty<T>(EntityTypeBuilder<T> builder, string name) where T : class
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            builder
                .Property<DateTime>(name)
                .HasDefaultValueSql("getdate()");

            return builder;
        }
    }
}
