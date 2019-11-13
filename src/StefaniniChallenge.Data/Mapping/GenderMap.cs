using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StefaniniChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StefaniniChallenge.Data.Mapping
{
    public class GenderMap : BaseMap<Gender>
    {
        public override void Configure(EntityTypeBuilder<Gender> builder)
        {
            base.Configure(builder);

            builder.ToTable("Gender");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");
        }
    }
}
