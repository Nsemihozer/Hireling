﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Calisanlar", b =>
                {
                    b.Property<int>("CalisanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CalisanID"), 1L, 1);

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BirimID")
                        .HasColumnType("int");

                    b.Property<decimal>("BrutMaas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte>("Cinsiyet")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("FirmaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("IseGirisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("IzinGun")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IzinSaat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("KullaniciAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("KullanilanIzinGun")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("KullanilanIzinSaat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte>("Medeni")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("NetMaas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SSkNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnvanID")
                        .HasColumnType("int");

                    b.HasKey("CalisanID");

                    b.ToTable("Calisanlar");
                });
#pragma warning restore 612, 618
        }
    }
}