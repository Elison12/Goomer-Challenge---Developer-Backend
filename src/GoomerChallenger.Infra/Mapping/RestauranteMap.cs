using GoomerChallenger.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoomerChallenger.Infra.Mapping
{
    public sealed class RestauranteMap : IEntityTypeConfiguration<Restaurante>
    {
        public void Configure(EntityTypeBuilder<Restaurante> builder)
        {
            builder.ToTable("Restaurante");

            builder.Ignore(x => x.Id);
            builder.Ignore(x => x.Errors);
            builder.Ignore(x => x.Isvalid);

            builder.HasKey(x => x.idRestaurante);

            builder.Property(x => x.idRestaurante)
                   .IsRequired()
                   .HasColumnName("IdRestaurante");
            builder.Property(x => x.Nome)
                   .HasColumnName("Nome")
                   .HasColumnType("Varchar(20)")
                   .IsRequired();
            builder.Property(x => x.Endereco)
                   .HasColumnName("Endereco")
                   .HasColumnType("Varchar(80)")
                   .IsRequired();
            builder.Property(x => x.Telefone)
                   .HasColumnName("Telefone")
                   .HasColumnType("Varchar(15)")
                   .IsRequired();
            builder.Property(x => x.NumFuncionarios)
                   .HasColumnName("NumFuncionarios");
            builder.Property(x => x.Gerente)
                   .HasColumnName("Gerente");
            builder.HasMany(r => r.Cardapio)
                   .WithOne(p => p.Restaurante)
                   .HasForeignKey(p => p.IdPrato)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
