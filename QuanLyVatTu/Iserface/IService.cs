using QuanLyVatTu.Entities;
using QuanLyVatTu.Helper;

namespace QuanLyVatTu.Iserface
{
    public interface IService
    {
        public string TaoMaNhap();
        public PhieuNhap ThemPhieuNhap(PhieuNhap nhap);
        public IQueryable<PhieuNhap> XuatPhieuNhap(int? year = null,
                                                   int? month = null,
                                                   double? TongTien = null
                                                   );
        public string TaoMaXuat();
        public PhieuXuat ThemPhieuXuat(PhieuXuat xuat);
        public IQueryable<PhieuXuat> XuatPhieuXuat(int? year = null, int? month = null, double? TongTien = null);
        public void XoaPhieuNhap(int PhieuNhapId);
    }
}
