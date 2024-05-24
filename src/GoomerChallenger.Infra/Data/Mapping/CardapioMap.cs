using GoomerChallenger.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoomerChallenger.Infra.Data.Mapping
{
    public sealed class cardapioMap : IEntityTypeConfiguration<Cardapio>
    {
        public void Configure(EntityTypeBuilder<Cardapio> builder)
        {
            builder.ToTable("Cardapio");

            builder.Ignore(x => x.Id);
            builder.Ignore(x => x.Errors);
            builder.Ignore(x => x.Isvalid);

            builder.HasKey(x => x.idCardapio);

            builder.HasMany(p => p.Pratos)
                   .WithOne(c => c.Cardapio)
                   .HasForeignKey(p => p.idCardapio);
        }
    }
}
