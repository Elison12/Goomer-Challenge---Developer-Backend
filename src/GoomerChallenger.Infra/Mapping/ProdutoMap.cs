﻿using GoomerChallenger.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoomerChallenger.Infra.Mapping
{
    public sealed class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.IdProduto);

            builder.Ignore(x => x.Id);
            builder.Ignore(x => x.Errors);
            builder.Ignore(x => x.Isvalid);

            builder.Property(x => x.Nome)
                   .HasColumnName("Nome")
                   .HasColumnType("Varchar(40)")
                   .IsRequired();
            builder.Property(x => x.Valor)
                   .HasColumnName("Valro")
                   .IsRequired();
            builder.Property(x => x.Codigo)
                   .HasColumnName("Codigo")
                   .HasColumnType("Varchar(10)")
                   .IsRequired();
            builder.Property(x => x.Categoria)
                   .HasColumnName("Categoria")
                   .HasColumnType("Varchar(20)")
                   .IsRequired();
            builder.Property(x => x.Departamento)
                   .HasColumnName("Departamento")
                   .HasColumnType("Varchar(20)")
                   .IsRequired();
            builder.Property(x => x.DtAquisicao)
                   .HasColumnName("DtAquisicao")
                   .HasColumnType("Date")
                   .IsRequired();
            builder.Property(x => x.DtValidade)
                   .HasColumnName("DtValidade")
                   .HasColumnType("Date")
                   .IsRequired();
            builder.Property(x => x.Lote)
                   .HasColumnName("Lote")
                   .IsRequired();
            builder.Property(x => x.IsPromocao)
                   .HasColumnName("IsPromocao");
            builder.Property(x => x.DescricaoPromocao)
                   .HasColumnName("DescricaoPromocao")
                   .HasColumnType("Varchar(40)");
            builder.Property(x => x.PrecoPromocional)
                   .HasColumnName("PrecoPromocional");
        }
    }
}
