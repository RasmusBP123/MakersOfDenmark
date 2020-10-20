using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Mappings
{
    public class WorkshopBuilder : IEntityTypeConfiguration<Workshop>
    {
        public void Configure(EntityTypeBuilder<Workshop> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Address);
            builder.OwnsOne(x => x.Phone);

            builder.HasOne(x => x.Calendar)
                   .WithOne(x => x.Workshop)
                   .HasForeignKey<Workshop>(x => x.CalendarId);

        }
    }
}
