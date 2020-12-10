﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VendasWPF.Models;

namespace VendasWPF.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201025050505_CriarBanco")]
    partial class CriarBanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VendasWPF.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("VendasWPF.Models.ItemVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int?>("VendaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("VendaId");

                    b.ToTable("ItensVenda");
                });

            modelBuilder.Entity("VendasWPF.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("VendasWPF.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<int?>("VendedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("VendasWPF.Models.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salario")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("VendasWPF.Models.ItemVenda", b =>
                {
                    b.HasOne("VendasWPF.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.HasOne("VendasWPF.Models.Venda", null)
                        .WithMany("Itens")
                        .HasForeignKey("VendaId");
                });

            modelBuilder.Entity("VendasWPF.Models.Venda", b =>
                {
                    b.HasOne("VendasWPF.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("VendasWPF.Models.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId");
                });
#pragma warning restore 612, 618
        }
    }
}
