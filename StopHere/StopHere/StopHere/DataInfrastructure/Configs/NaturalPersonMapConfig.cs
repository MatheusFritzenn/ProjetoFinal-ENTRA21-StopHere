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
    internal class NaturalPersonMapConfig : IEntityTypeConfiguration<NaturalPerson>
    {
        public void Configure(EntityTypeBuilder<NaturalPerson> builder)
        {
            builder.Property(np => np.Nome).IsUnicode(false).HasMaxLength(70).IsRequired();

            builder.Property(np => np.CPF).IsFixedLength().IsUnicode(false).HasMaxLength(11).IsRequired();
            builder.HasIndex(np => np.CPF).IsUnique();
        }
    }
}
