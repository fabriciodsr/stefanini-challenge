using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StefaniniChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StefaniniChallenge.Data.Mapping
{
    public class RegionMap : BaseMap<Region>
    {
        public override void Configure(EntityTypeBuilder<Region> builder)
        {
            base.Configure(builder);

            builder.ToTable("Region");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");
        }
    }
}
