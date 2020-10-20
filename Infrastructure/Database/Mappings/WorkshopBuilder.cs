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
            builder.OwnsOne(x => x.Location, y => 
            {
                y.Property(p => p.Address).HasColumnName("Address");
                y.Property(p => p.Zipcode).HasColumnName("Zipcode");
            });
            builder.OwnsOne(x => x.Phone, y => 
            {
                y.Property(p => p.Number).HasColumnName("Number");
            });

            builder.HasOne(x => x.Calendar)
                   .WithOne(x => x.Workshop)
                   .HasForeignKey<Workshop>(x => x.CalendarId);

        }
    }
}
