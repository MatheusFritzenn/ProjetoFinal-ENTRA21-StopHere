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
    internal class LegalPersonMapConfig : IEntityTypeConfiguration<LegalPerson>
    {
        public void Configure(EntityTypeBuilder<LegalPerson> builder)
        {
            builder.Property(lp => lp.CNPJ).IsUnicode(false).HasMaxLength(20).IsRequired().IsFixedLength();
            builder.HasIndex(lp => lp.CNPJ).IsUnique();

            builder.Property(lp => lp.InscricaoEstadual).IsUnicode(false).HasMaxLength(20).IsRequired().IsFixedLength();
            builder.HasIndex(lp => lp.InscricaoEstadual).IsUnique();

            builder.Property(lp => lp.NomeFantasia).HasMaxLength(100).IsUnicode(false).IsRequired();

            builder.Property(lp => lp.RazaoSocial).HasMaxLength(100).IsUnicode(false);
        }
    }
}
