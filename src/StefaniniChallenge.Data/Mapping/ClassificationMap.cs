using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StefaniniChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StefaniniChallenge.Data.Mapping
{
    public class ClassificationMap : BaseMap<Classification>
    {
        public override void Configure(EntityTypeBuilder<Classification> builder)
        {
            base.Configure(builder);

            builder.ToTable("Classification");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");
        }
    }
}
