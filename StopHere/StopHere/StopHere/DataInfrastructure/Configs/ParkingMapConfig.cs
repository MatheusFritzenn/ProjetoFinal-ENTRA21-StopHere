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
    internal class ParkingMapConfig : IEntityTypeConfiguration<Parking>
    {
        public void Configure(EntityTypeBuilder<Parking> builder)
        {
            builder.Property(p => p.CEP).IsUnicode(false).HasMaxLength(8).IsRequired(); ;

            builder.Property(p => p.UF).IsRequired();

            builder.Property(p => p.Cidade).HasMaxLength(100).IsUnicode(false).IsRequired();

            builder.Property(p => p.Bairro).HasMaxLength(100).IsUnicode(false).IsRequired();

            builder.Property(p => p.Rua).HasMaxLength(100).IsUnicode(false).IsRequired();

            builder.Property(p => p.Numero).HasMaxLength(6).IsUnicode(false).IsRequired();

            builder.Property(p => p.Complemento).HasMaxLength(100).IsUnicode(false);

            builder.Property(p => p.IsCoberta).HasDefaultValue(false);
            builder.Property(p => p.IsVigiada).HasDefaultValue(false);
            builder.Property(p => p.DeixarChave).HasDefaultValue(false);
            builder.Property(p => p.Ativo).HasDefaultValue(true);
        }
    }
}
