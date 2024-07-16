using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckPlan.Data;

namespace TruckPlan.EntityFramework.Mapping
{
    public class TruckGPSMapping : IEntityTypeConfiguration<TruckGPS>
    {
        public void Configure(EntityTypeBuilder<TruckGPS> builder)
        {
            builder.ToTable(nameof(TruckGPS)).HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName(nameof(TruckGPS.Id))
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.JourneyId)
                .HasColumnName(nameof(TruckGPS.JourneyId));

            builder.Property(x => x.Longitude)
                .HasColumnName(nameof(TruckGPS.Longitude));

            builder.Property(x => x.Latitude)
                .HasColumnName(nameof(TruckGPS.Latitude));

            builder.Property(x => x.IsArchived)
                .HasColumnName(nameof(TruckGPS.IsArchived));

            builder.Property(e => e.DateCreated)
                .HasColumnName(nameof(TruckGPS.DateCreated));
        }
    }
}
