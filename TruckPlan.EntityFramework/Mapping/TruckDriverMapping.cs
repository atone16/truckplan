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
    public class TruckDriverMapping : IEntityTypeConfiguration<TruckDriver>
    {
        public void Configure(EntityTypeBuilder<TruckDriver> builder)
        {
            builder.ToTable(nameof(TruckDriver)).HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName(nameof(TruckDriver.Id))
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                .HasColumnName(nameof(TruckDriver.FirstName));

            builder.Property(x => x.LastName)
                .HasColumnName(nameof(TruckDriver.LastName));

            builder.Property(x => x.LicenseNumber)
                .HasColumnName(nameof(TruckDriver.LicenseNumber));

            builder.Property(x => x.IsArchived)
                .HasColumnName(nameof(TruckDriver.IsArchived));

            builder.Property(x => x.BirthDate)
                .HasColumnName(nameof(TruckDriver.BirthDate));

            builder.Property(e => e.DateCreated)
                .HasColumnName(nameof(TruckDriver.DateCreated));
        }
    }
}
