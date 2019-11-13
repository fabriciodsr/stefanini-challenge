using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StefaniniChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StefaniniChallenge.Data.Mapping
{
    public class CityMap : BaseMap<City>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            base.Configure(builder);

            builder.ToTable("City");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");
        }
    }
}
