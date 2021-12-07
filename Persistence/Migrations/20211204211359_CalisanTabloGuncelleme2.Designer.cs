﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211204211359_CalisanTabloGuncelleme2")]
    partial class CalisanTabloGuncelleme2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("BirimID")
                        .HasColumnType("int");

                    b.Property<decimal?>("BrutMaas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte?>("Cinsiyet")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("FirmaID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("IseGirisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("IzinGun")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("IzinSaat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("KullaniciAdi")
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("KullanilanIzinGun")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("KullanilanIzinSaat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte?>("Medeni")
                        .HasColumnType("tinyint");

                    b.Property<decimal?>("NetMaas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SSkNo")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sifre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Soyadi")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TcNo")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UnvanID")
                        .HasColumnType("int");

                    b.HasKey("CalisanID");

                    b.ToTable("Calisanlar");
                });

            modelBuilder.Entity("Domain.Departmanlar", b =>
                {
                    b.Property<int>("DepartmanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmanID"), 1L, 1);

                    b.Property<string>("DepartmanAdi")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("SorumluId")
                        .HasColumnType("int");

                    b.HasKey("DepartmanID");

                    b.ToTable("Departmanlar");
                });

            modelBuilder.Entity("Domain.Unvanlar", b =>
                {
                    b.Property<int>("UnvanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnvanID"), 1L, 1);

                    b.Property<string>("UnvanAdi")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UnvanID");

                    b.ToTable("Unvanlar");
                });
#pragma warning restore 612, 618
        }
    }
}