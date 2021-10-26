using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInfrastructure.Configs
{
    internal class VehicleMapConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(v => v.Ativo).HasDefaultValue(true).IsRequired();

            builder.Property(v => v.Cor).IsUnicode(false).HasMaxLength(20).IsRequired();

            builder.Property(v => v.Marca).IsUnicode(false).HasMaxLength(50).IsRequired();

            builder.Property(v=>v.Modelo).IsUnicode(false).HasMaxLength(50).IsRequired();

            builder.Property(v => v.Observacao).IsUnicode(false).HasMaxLength(150);

            builder.Property(c => c.Placa).IsUnicode(false).HasMaxLength(8).IsRequired();
            builder.HasIndex(c => c.Placa).IsUnique();

            builder.HasOne(v => v.User).WithMany(u => u.Veiculos).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(v=>v.Locations).WithOne(l=>l.Vehicle).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
