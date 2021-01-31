﻿// <auto-generated />
using System;
using Entregas.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entregas.Data.Migrations
{
    [DbContext(typeof(EntregasDBContext))]
    partial class EntregasDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Entregas.Domain.Model.Entrega", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("RecibidoPorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecibidoPorId");

                    b.ToTable("Entregas");
                });

            modelBuilder.Entity("Entregas.Domain.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Entregas.Domain.Model.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AutorizadoPorId")
                        .HasColumnType("int");

                    b.Property<int?>("EntregaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaAutorizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaCompletado")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SolicitadoPorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutorizadoPorId");

                    b.HasIndex("EntregaId");

                    b.HasIndex("SolicitadoPorId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Entregas.Domain.Model.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("Entregas.Domain.Model.Autorizador", b =>
                {
                    b.HasBaseType("Entregas.Domain.Model.Usuario");

                    b.HasDiscriminator().HasValue("Autorizador");
                });

            modelBuilder.Entity("Entregas.Domain.Model.Receptor", b =>
                {
                    b.HasBaseType("Entregas.Domain.Model.Usuario");

                    b.HasDiscriminator().HasValue("Receptor");
                });

            modelBuilder.Entity("Entregas.Domain.Model.Entrega", b =>
                {
                    b.HasOne("Entregas.Domain.Model.Receptor", "RecibidoPor")
                        .WithMany()
                        .HasForeignKey("RecibidoPorId");

                    b.Navigation("RecibidoPor");
                });

            modelBuilder.Entity("Entregas.Domain.Model.Item", b =>
                {
                    b.HasOne("Entregas.Domain.Model.Pedido", null)
                        .WithMany("Items")
                        .HasForeignKey("PedidoId");
                });

            modelBuilder.Entity("Entregas.Domain.Model.Pedido", b =>
                {
                    b.HasOne("Entregas.Domain.Model.Autorizador", "AutorizadoPor")
                        .WithMany()
                        .HasForeignKey("AutorizadoPorId");

                    b.HasOne("Entregas.Domain.Model.Entrega", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("EntregaId");

                    b.HasOne("Entregas.Domain.Model.Receptor", "SolicitadoPor")
                        .WithMany()
                        .HasForeignKey("SolicitadoPorId");

                    b.Navigation("AutorizadoPor");

                    b.Navigation("SolicitadoPor");
                });

            modelBuilder.Entity("Entregas.Domain.Model.Entrega", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Entregas.Domain.Model.Pedido", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
