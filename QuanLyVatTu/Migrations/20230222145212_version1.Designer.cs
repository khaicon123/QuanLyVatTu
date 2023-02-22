﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyVatTu.Context;

#nullable disable

namespace QuanLyVatTu.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230222145212_version1")]
    partial class version1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuanLyVatTu.Entities.ChiTietPhieuNhap", b =>
                {
                    b.Property<int>("ChiTietPhieuNhapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChiTietPhieuNhapId"), 1L, 1);

                    b.Property<double>("GiaTien")
                        .HasColumnType("float");

                    b.Property<int>("PhieuNhapId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongNhap")
                        .HasColumnType("int");

                    b.Property<int>("VatTuId")
                        .HasColumnType("int");

                    b.HasKey("ChiTietPhieuNhapId");

                    b.HasIndex("PhieuNhapId");

                    b.HasIndex("VatTuId");

                    b.ToTable("ChiTietPhieuNhaps");
                });

            modelBuilder.Entity("QuanLyVatTu.Entities.ChiTietPhieuXuat", b =>
                {
                    b.Property<int>("ChiTietPhieuXuatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChiTietPhieuXuatId"), 1L, 1);

                    b.Property<double>("GiaTien")
                        .HasColumnType("float");

                    b.Property<int>("PhieuXuatId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongXuat")
                        .HasColumnType("int");

                    b.Property<int>("VatTuId")
                        .HasColumnType("int");

                    b.HasKey("ChiTietPhieuXuatId");

                    b.HasIndex("PhieuXuatId");

                    b.HasIndex("VatTuId");

                    b.ToTable("ChiTietPhieuXuats");
                });

            modelBuilder.Entity("QuanLyVatTu.Entities.PhieuNhap", b =>
                {
                    b.Property<int>("PhieuNhapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhieuNhapId"), 1L, 1);

                    b.Property<string>("MaPhieuNhap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("datetime2");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TongTien")
                        .HasColumnType("float");

                    b.HasKey("PhieuNhapId");

                    b.ToTable("PhieuNhap");
                });

            modelBuilder.Entity("QuanLyVatTu.Entities.PhieuXuat", b =>
                {
                    b.Property<int>("PhieuXuatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhieuXuatId"), 1L, 1);

                    b.Property<string>("MaPhieuXuat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayXuat")
                        .HasColumnType("datetime2");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TongTien")
                        .HasColumnType("float");

                    b.HasKey("PhieuXuatId");

                    b.ToTable("PhieuXuat");
                });

            modelBuilder.Entity("QuanLyVatTu.Entities.VatTu", b =>
                {
                    b.Property<int>("VatTuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VatTuId"), 1L, 1);

                    b.Property<double>("GiaNhap")
                        .HasColumnType("float");

                    b.Property<double>("GiaXuat")
                        .HasColumnType("float");

                    b.Property<int>("SoLuongTon")
                        .HasColumnType("int");

                    b.Property<string>("TenVatTu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VatTuId");

                    b.ToTable("VatTus");
                });

            modelBuilder.Entity("QuanLyVatTu.Entities.ChiTietPhieuNhap", b =>
                {
                    b.HasOne("QuanLyVatTu.Entities.PhieuNhap", "PhieuNhap")
                        .WithMany("ChiTiet")
                        .HasForeignKey("PhieuNhapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyVatTu.Entities.VatTu", "VatTu")
                        .WithMany()
                        .HasForeignKey("VatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhieuNhap");

                    b.Navigation("VatTu");
                });

            modelBuilder.Entity("QuanLyVatTu.Entities.ChiTietPhieuXuat", b =>
                {
                    b.HasOne("QuanLyVatTu.Entities.PhieuXuat", "PhieuXuat")
                        .WithMany("ChiTietPhieuXuats")
                        .HasForeignKey("PhieuXuatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyVatTu.Entities.VatTu", "VatTu")
                        .WithMany()
                        .HasForeignKey("VatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhieuXuat");

                    b.Navigation("VatTu");
                });

            modelBuilder.Entity("QuanLyVatTu.Entities.PhieuNhap", b =>
                {
                    b.Navigation("ChiTiet");
                });

            modelBuilder.Entity("QuanLyVatTu.Entities.PhieuXuat", b =>
                {
                    b.Navigation("ChiTietPhieuXuats");
                });
#pragma warning restore 612, 618
        }
    }
}