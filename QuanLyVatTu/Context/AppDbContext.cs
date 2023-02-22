using Microsoft.EntityFrameworkCore;
using QuanLyVatTu.Entities;

namespace QuanLyVatTu.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<PhieuNhap> PhieuNhap { get;set; }
        public DbSet<PhieuXuat> PhieuXuat { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
        public DbSet<VatTu> VatTus { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = localhost;Initial Catalog = QuanLyVatTu;User ID = sa; Password = 1231234;encrypt=true;trustservercertificate=true");
        }
    }
}
