using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyVatTu.Migrations
{
    public partial class version1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuNhap",
                columns: table => new
                {
                    PhieuNhapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhieuNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhap", x => x.PhieuNhapId);
                });

            migrationBuilder.CreateTable(
                name: "PhieuXuat",
                columns: table => new
                {
                    PhieuXuatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhieuXuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayXuat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuXuat", x => x.PhieuXuatId);
                });

            migrationBuilder.CreateTable(
                name: "VatTus",
                columns: table => new
                {
                    VatTuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVatTu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    GiaNhap = table.Column<double>(type: "float", nullable: false),
                    GiaXuat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatTus", x => x.VatTuId);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuNhaps",
                columns: table => new
                {
                    ChiTietPhieuNhapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VatTuId = table.Column<int>(type: "int", nullable: false),
                    PhieuNhapId = table.Column<int>(type: "int", nullable: false),
                    SoLuongNhap = table.Column<int>(type: "int", nullable: false),
                    GiaTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuNhaps", x => x.ChiTietPhieuNhapId);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhaps_PhieuNhap_PhieuNhapId",
                        column: x => x.PhieuNhapId,
                        principalTable: "PhieuNhap",
                        principalColumn: "PhieuNhapId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhaps_VatTus_VatTuId",
                        column: x => x.VatTuId,
                        principalTable: "VatTus",
                        principalColumn: "VatTuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuXuats",
                columns: table => new
                {
                    ChiTietPhieuXuatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VatTuId = table.Column<int>(type: "int", nullable: false),
                    PhieuXuatId = table.Column<int>(type: "int", nullable: false),
                    SoLuongXuat = table.Column<int>(type: "int", nullable: false),
                    GiaTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuXuats", x => x.ChiTietPhieuXuatId);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuXuats_PhieuXuat_PhieuXuatId",
                        column: x => x.PhieuXuatId,
                        principalTable: "PhieuXuat",
                        principalColumn: "PhieuXuatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuXuats_VatTus_VatTuId",
                        column: x => x.VatTuId,
                        principalTable: "VatTus",
                        principalColumn: "VatTuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_PhieuNhapId",
                table: "ChiTietPhieuNhaps",
                column: "PhieuNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_VatTuId",
                table: "ChiTietPhieuNhaps",
                column: "VatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuXuats_PhieuXuatId",
                table: "ChiTietPhieuXuats",
                column: "PhieuXuatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuXuats_VatTuId",
                table: "ChiTietPhieuXuats",
                column: "VatTuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietPhieuNhaps");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuXuats");

            migrationBuilder.DropTable(
                name: "PhieuNhap");

            migrationBuilder.DropTable(
                name: "PhieuXuat");

            migrationBuilder.DropTable(
                name: "VatTus");
        }
    }
}
