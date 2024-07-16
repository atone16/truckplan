using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckPlan.Data;

namespace TruckPlan.EntityFramework.Mapping
{
    public class JourneyMapping : IEntityTypeConfiguration<Journey>
    {
        public void Configure(EntityTypeBuilder<Journey> builder)
        {
            builder.ToTable(nameof(Journey)).HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName(nameof(Journey.Id))
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.TruckDriverId)
                .HasColumnName(nameof(Journey.TruckDriverId));

            builder.Property(x => x.TruckId)
                .HasColumnName(nameof(Journey.TruckId));

            builder.Property(x => x.StartDate)
                .HasColumnName(nameof(Journey.StartDate));

            builder.Property(x => x.EndDate)
                .HasColumnName(nameof(Journey.EndDate));

            builder.Property(x => x.StartCountry)
                .HasColumnName(nameof(Journey.StartCountry));

            builder.Property(x => x.EndCountry)
                .HasColumnName(nameof(Journey.EndCountry));

            builder.Property(x => x.IsArchived)
                .HasColumnName(nameof(Journey.IsArchived));

            builder.Property(e => e.DateCreated)
                .HasColumnName(nameof(Journey.DateCreated));
        }
    }
}
