﻿// <auto-generated />
using System;
using Fiap.Api.Trash.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Fiap.Api.Trash.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fiap.Api.Trash.Models.DescarteModel", b =>
                {
                    b.Property<int>("DescarteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DescarteId"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR2(500)");

                    b.Property<string>("Endereco")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("DescarteId");

                    b.ToTable("Descartes", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.Trash.Models.EletronicoModel", b =>
                {
                    b.Property<int>("EletronicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EletronicoId"));

                    b.Property<string>("Descricao")
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR2(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("EletronicoId");

                    b.HasIndex("UserId");

                    b.ToTable("Eletronicos", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.Trash.Models.NotificacaoModel", b =>
                {
                    b.Property<int>("NotificacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificacaoId"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("date");

                    b.Property<string>("Mensagem")
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR2(500)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("NotificacaoId");

                    b.HasIndex("UserId");

                    b.ToTable("Notificacoes", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.Trash.Models.UsuarioModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("UserId");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.Trash.Models.EletronicoModel", b =>
                {
                    b.HasOne("Fiap.Api.Trash.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Fiap.Api.Trash.Models.NotificacaoModel", b =>
                {
                    b.HasOne("Fiap.Api.Trash.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
