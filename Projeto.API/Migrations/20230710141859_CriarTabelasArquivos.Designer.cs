﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto.API.DataContext;

#nullable disable

namespace Projeto.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230710141859_CriarTabelasArquivos")]
    partial class CriarTabelasArquivos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projeto.API.Models.Arquivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Armario")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<int?>("Arquitetura")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Competencia")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataDescarte")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUltimAtualizacao")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("Gaveta")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<int>("NumCaixa")
                        .HasColumnType("int");

                    b.Property<string>("Pratelheira")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("PratelheiraColuna")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("PratelheiraLinha")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("PrimeiroUsuarioCadastro")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<int>("TipoArquivoId")
                        .HasColumnType("int");

                    b.Property<string>("UltimoUsuarioAtualizar")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoArquivoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Arquivos");
                });

            modelBuilder.Entity("Projeto.API.Models.ControleCaixa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumeroAtual")
                        .HasColumnType("int");

                    b.Property<int>("TipoArquivoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoArquivoId");

                    b.ToTable("ControleCaixas");
                });

            modelBuilder.Entity("Projeto.API.Models.ItemArquivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArquivoId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoItem")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.Property<bool>("NoArquivo")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ArquivoId");

                    b.ToTable("ItemArquivos");
                });

            modelBuilder.Entity("Projeto.API.Models.Processo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<int>("ItemArquivoId")
                        .HasColumnType("int");

                    b.Property<string>("ParaQuem")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.HasIndex("ItemArquivoId");

                    b.ToTable("Processos");
                });

            modelBuilder.Entity("Projeto.API.Models.TipoArquivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.Property<int>("Guardar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<bool>("SuporteControleCaixa")
                        .HasColumnType("bit");

                    b.Property<bool>("SuporteItem")
                        .HasColumnType("bit");

                    b.Property<int>("Tempo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TipoArquivos");
                });

            modelBuilder.Entity("Projeto.API.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Chave")
                        .IsRequired()
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Nivel")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR(MAX)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Projeto.API.Models.Arquivo", b =>
                {
                    b.HasOne("Projeto.API.Models.TipoArquivo", "TipoArquivo")
                        .WithMany()
                        .HasForeignKey("TipoArquivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto.API.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoArquivo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Projeto.API.Models.ControleCaixa", b =>
                {
                    b.HasOne("Projeto.API.Models.TipoArquivo", "TipoArquivo")
                        .WithMany()
                        .HasForeignKey("TipoArquivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoArquivo");
                });

            modelBuilder.Entity("Projeto.API.Models.ItemArquivo", b =>
                {
                    b.HasOne("Projeto.API.Models.Arquivo", "Arquivo")
                        .WithMany()
                        .HasForeignKey("ArquivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arquivo");
                });

            modelBuilder.Entity("Projeto.API.Models.Processo", b =>
                {
                    b.HasOne("Projeto.API.Models.ItemArquivo", "ItemArquivo")
                        .WithMany()
                        .HasForeignKey("ItemArquivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemArquivo");
                });
#pragma warning restore 612, 618
        }
    }
}
