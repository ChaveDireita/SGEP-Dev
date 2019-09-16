﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGEP.Banco;

namespace SGEP.Migrations
{
    [DbContext(typeof(ContextoBD))]
    [Migration("20190916171235_Migracao")]
    partial class Migracao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SGEP.Models.AlocacaoPossui", b =>
                {
                    b.Property<ulong>("CodProjeto");

                    b.Property<ulong>("CodMaterial");

                    b.Property<ulong>("Quantidade");

                    b.HasKey("CodProjeto");

                    b.HasAlternateKey("CodMaterial");

                    b.ToTable("AlocacaoPossui");
                });

            modelBuilder.Entity("SGEP.Models.Funcionario", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cargo");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("SGEP.Models.Material", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(27, 2)");

                    b.Property<decimal>("Quantidade");

                    b.Property<string>("Unidade");

                    b.HasKey("Id");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("SGEP.Models.ParticipaProjeto", b =>
                {
                    b.Property<ulong>("IdProjeto")
                        .ValueGeneratedOnAdd();

                    b.Property<ulong>("IdFuncionario");

                    b.HasKey("IdProjeto");

                    b.HasAlternateKey("IdFuncionario");

                    b.ToTable("ParticipaProjeto");
                });

            modelBuilder.Entity("SGEP.Models.Projeto", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataFim");

                    b.Property<DateTime>("DataInicio");

                    b.Property<string>("Estado")
                        .IsRequired();

                    b.Property<string>("Nome");

                    b.Property<DateTime>("PrazoEstimado");

                    b.HasKey("Id");

                    b.ToTable("Projeto");
                });

            modelBuilder.Entity("SGEP.Models.AlocacaoPossui", b =>
                {
                    b.HasOne("SGEP.Models.Material", "Material")
                        .WithMany("Alocacoes")
                        .HasForeignKey("CodMaterial")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SGEP.Models.Projeto", "Projeto")
                        .WithMany("Alocacoes")
                        .HasForeignKey("CodProjeto")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
