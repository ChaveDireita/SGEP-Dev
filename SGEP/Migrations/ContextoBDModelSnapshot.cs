﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGEP.Banco;

namespace SGEP.Migrations
{
    [DbContext(typeof(ContextoBD))]
    partial class ContextoBDModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SGEP.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cargo");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("SGEP.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(27, 2)");

                    b.Property<decimal>("Quantidade");

                    b.Property<string>("Unidade");

                    b.HasKey("Id");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("SGEP.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
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

            modelBuilder.Entity("SGEP.Models.Unidades", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<string>("Unidade");

                    b.HasKey("Id");

                    b.ToTable("Unidades");
                });
#pragma warning restore 612, 618
        }
    }
}
