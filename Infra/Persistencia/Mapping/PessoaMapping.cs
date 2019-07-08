using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prmToolkit.NotificationPattern;

namespace Infra.Persistencia.Mapping
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id)
                .IsUnique(true);

            builder
                .Property(x => x.Nome)
                .HasField("Nome")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasField("Email")
                .IsRequired();

            builder.Property(x => x.Cpf)
                .HasField("Cpf");

            builder.Property(x => x.Telefone)
                .HasField("Telefone");

            builder.Property(x => x.Endereco)
                .HasField("Endereco");
        }
    }
}
