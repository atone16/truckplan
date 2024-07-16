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
    public class JourneySummaryMapping : IEntityTypeConfiguration<JourneySummary>
    {
        public void Configure(EntityTypeBuilder<JourneySummary> builder)
        {
            builder.ToTable(nameof(JourneySummary)).HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName(nameof(JourneySummary.Id))
                .IsRequired();

            builder.Property(x => x.StartDate)
                .HasColumnName(nameof(JourneySummary.StartDate));

            builder.Property(x => x.EndDate)
                .HasColumnName(nameof(JourneySummary.EndDate));

            builder.Property(x => x.StartCountry)
                .HasColumnName(nameof(JourneySummary.StartCountry));

            builder.Property(x => x.EndCountry)
                .HasColumnName(nameof(JourneySummary.EndCountry));

            builder.Property(x => x.IsArchived)
                .HasColumnName(nameof(JourneySummary.IsArchived));

            builder.Property(e => e.DateCreated)
                .HasColumnName(nameof(JourneySummary.DateCreated));

            builder.Property(x => x.TotalDistanceKm)
                .HasColumnName(nameof(JourneySummary.TotalDistanceKm));
            
            builder.Property(x => x.Truck)
                .HasColumnName(nameof(JourneySummary.Truck));

            builder.Property(x => x.DriverName)
                .HasColumnName(nameof(JourneySummary.DriverName));

            builder.Property(x => x.DriverBirthdate)
                .HasColumnName(nameof(JourneySummary.DriverBirthdate));

            builder.Property(x => x.JourneyDuration)
                .HasColumnName(nameof(JourneySummary.JourneyDuration));

        }
    }

}
