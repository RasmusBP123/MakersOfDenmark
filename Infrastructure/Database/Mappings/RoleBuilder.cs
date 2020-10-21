using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Mappings
{
    public class RoleBuilder : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole
            {
                Id = "1",
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = "62b0f3e4-fa81-4b33-a5b4-9c21e8aa577f",
            });
            builder.HasData(new IdentityRole
            {
                Id = "2",
                Name = "WorkspaceAdmin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "C2A4B11D-221E-41D4-94A7-77747CD1B1DD",
            });
            builder.HasData(new IdentityRole
            {
                Id = "100",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "9be42a72-8ca8-42fb-a61c-bc8e323f523e",
            });
        }
    }
}
