﻿// <auto-generated />
using System;
using GoomerChallenger.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GoomerChallenger.Infra.Migrations
{
    [DbContext(typeof(GoomerContext))]
    partial class GoomerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("GoomerContext")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GoomerChallenger.Domain.Models.Cardapio", b =>
                {
                    b.Property<int>("idCardapio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idCardapio"));

                    b.Property<int>("idRestaurante")
                        .HasColumnType("integer");

                    b.HasKey("idCardapio");

                    b.HasIndex("idRestaurante")
                        .IsUnique();

                    b.ToTable("Cardapio", "GoomerContext");
                });

            modelBuilder.Entity("GoomerChallenger.Domain.Models.Prato", b =>
                {
                    b.Property<int>("IdPrato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPrato"));

                    b.Property<string>("CaminhoFoto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Codigo")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("RestauranteId")
                        .HasColumnType("integer");

                    b.Property<int>("idCardapio")
                        .HasColumnType("integer");

                    b.Property<float>("valor")
                        .HasColumnType("real");

                    b.HasKey("IdPrato");

                    b.HasIndex("RestauranteId");

                    b.HasIndex("idCardapio");

                    b.ToTable("Prato", "GoomerContext");
                });

            modelBuilder.Entity("GoomerChallenger.Domain.Models.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdProduto"));

                    b.Property<string>("CaminhoFoto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("Varchar(20)")
                        .HasColumnName("Categoria");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("Varchar(10)")
                        .HasColumnName("Codigo");

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasColumnType("Varchar(20)")
                        .HasColumnName("Departamento");

                    b.Property<string>("DescricaoPromocao")
                        .IsRequired()
                        .HasColumnType("Varchar(40)")
                        .HasColumnName("DescricaoPromocao");

                    b.Property<DateTime>("DtAquisicao")
                        .HasColumnType("Date")
                        .HasColumnName("DtAquisicao");

                    b.Property<DateTime>("DtValidade")
                        .HasColumnType("Date")
                        .HasColumnName("DtValidade");

                    b.Property<bool>("IsPromocao")
                        .HasColumnType("boolean")
                        .HasColumnName("IsPromocao");

                    b.Property<int>("Lote")
                        .HasColumnType("integer")
                        .HasColumnName("Lote");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(40)")
                        .HasColumnName("Nome");

                    b.Property<float>("PrecoPromocional")
                        .HasColumnType("real")
                        .HasColumnName("PrecoPromocional");

                    b.Property<float>("Valor")
                        .HasColumnType("real")
                        .HasColumnName("Valro");

                    b.HasKey("IdProduto");

                    b.ToTable("Produto", "GoomerContext");
                });

            modelBuilder.Entity("GoomerChallenger.Domain.Models.Restaurante", b =>
                {
                    b.Property<int>("idRestaurante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdRestaurante");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idRestaurante"));

                    b.Property<string>("CaminhoFoto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("Varchar(80)")
                        .HasColumnName("Endereco");

                    b.Property<string>("Gerente")
                        .IsRequired()
                        .HasColumnType("Varchar(20)")
                        .HasColumnName("Gerente");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(20)")
                        .HasColumnName("Nome");

                    b.Property<int>("NumFuncionarios")
                        .HasColumnType("integer")
                        .HasColumnName("NumFuncionarios");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("Varchar(15)")
                        .HasColumnName("Telefone");

                    b.HasKey("idRestaurante");

                    b.ToTable("Restaurante", "GoomerContext");
                });

            modelBuilder.Entity("GoomerChallenger.Domain.Models.Cardapio", b =>
                {
                    b.HasOne("GoomerChallenger.Domain.Models.Restaurante", "Restaurante")
                        .WithOne("cardapio")
                        .HasForeignKey("GoomerChallenger.Domain.Models.Cardapio", "idRestaurante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurante");
                });

            modelBuilder.Entity("GoomerChallenger.Domain.Models.Prato", b =>
                {
                    b.HasOne("GoomerChallenger.Domain.Models.Restaurante", "Restaurante")
                        .WithMany()
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoomerChallenger.Domain.Models.Cardapio", "Cardapio")
                        .WithMany("Pratos")
                        .HasForeignKey("idCardapio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cardapio");

                    b.Navigation("Restaurante");
                });

            modelBuilder.Entity("GoomerChallenger.Domain.Models.Cardapio", b =>
                {
                    b.Navigation("Pratos");
                });

            modelBuilder.Entity("GoomerChallenger.Domain.Models.Restaurante", b =>
                {
                    b.Navigation("cardapio")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
