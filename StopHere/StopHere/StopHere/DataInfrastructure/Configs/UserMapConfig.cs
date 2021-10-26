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
    internal class UserMapConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(np => np.Email).IsUnicode(false).HasMaxLength(100).IsRequired();
            builder.HasIndex(np => np.Email).IsUnique();

            builder.Property(np => np.Senha).IsUnicode(false).HasMaxLength(255).IsRequired();

            builder.Property(np => np.Telefone).IsUnicode(false).HasMaxLength(20).IsRequired();

            builder.Property(np => np.CEP).IsUnicode(false).HasMaxLength(9);

            builder.Property(np => np.UF).IsRequired();

            builder.Property(np => np.Cidade).HasMaxLength(100).IsUnicode(false).IsRequired();

            builder.Property(np => np.Bairro).HasMaxLength(100).IsUnicode(false).IsRequired();

            builder.Property(np => np.Rua).HasMaxLength(100).IsUnicode(false).IsRequired();

            builder.Property(np => np.Numero).HasMaxLength(6).IsUnicode(false).IsRequired();

            builder.Property(np => np.Ativo).HasDefaultValue(true);

            builder.HasMany(u => u.Vagas).WithOne(v => v.User).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.Veiculos).WithOne(v => v.User).OnDelete(DeleteBehavior.NoAction);

            // Um usuário pode ter várias vagas mas cada vaga só pode ter apenas um dono e se deletado, não afetara em nada.
            builder.HasMany(u => u.Vagas).WithOne(c => c.User).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.Veiculos).WithOne(c => c.User).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
