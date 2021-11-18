using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.SeedData
{
    public class CompanySeed : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(new Company[] {
                new(){Id=1,CompanyName="Starbucks"},
                new(){Id=2,CompanyName="Portal"}
            });
        }
    }
}
