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
    public class TruckMapping : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable(nameof(Truck)).HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName(nameof(Truck.Id))
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.PlateNumber)
                .HasColumnName(nameof(Truck.PlateNumber));

            builder.Property(x => x.Make)
                .HasColumnName(nameof(Truck.Make));

            builder.Property(x => x.Model)
                .HasColumnName(nameof(Truck.Model));

            builder.Property(x => x.DateCreated)
                .HasColumnName(nameof(Truck.DateCreated));

            builder.Property(x => x.IsArchived)
                .HasColumnName(nameof(Truck.IsArchived));
        }
    }
}
