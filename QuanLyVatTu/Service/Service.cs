using QuanLyVatTu.Context;
using QuanLyVatTu.Entities;
using QuanLyVatTu.Helper;
using QuanLyVatTu.Iserface;

namespace QuanLyVatTu.Service
{
    public class Service:IService
    {
        private readonly AppDbContext _db = new AppDbContext();
        public string TaoMaNhap()
        {
            string res = DateTime.Now.ToString("yyyyMMdd") + "_";
            var SoGDHomNay = _db.PhieuNhap.Count(x => x.NgayNhap.Date == DateTime.Now.Date);
            if (SoGDHomNay > 0)
            {
                int tmp = SoGDHomNay + 1;
                if (tmp < 10) res = res + "00" + tmp;
                if (tmp < 100) res = res + "0" + tmp;

            }
            else res = res + "001";
            return res;
        }
        public PhieuNhap ThemPhieuNhap(PhieuNhap nhap)
        {
            using (var trans = _db.Database.BeginTransaction())
            {
                nhap.MaPhieuNhap=TaoMaNhap();
                nhap.NgayNhap=DateTime.Now;
                var lstChiTiet=nhap.ChiTiet;
                _db.Add(nhap);
                _db.SaveChanges();
                foreach(var chitiet in lstChiTiet)
                {
                    if (_db.VatTus.Any(x => x.VatTuId == chitiet.VatTuId))
                    {
                        chitiet.ChiTietPhieuNhapId = null;
                        chitiet.PhieuNhapId=nhap.PhieuNhapId;
                        var vattu = _db.VatTus.FirstOrDefault(x => x.VatTuId == chitiet.VatTuId);
                        vattu.SoLuongTon=vattu.SoLuongTon+chitiet.SoLuongNhap;
                        chitiet.GiaTien = vattu.GiaNhap * chitiet.SoLuongNhap;
                        _db.Update(vattu);
                        _db.Add(chitiet);
                        _db.SaveChanges();
                    }else throw new Exception($"Vat tu khong ton tai kiem tra vat tu co id la {chitiet.VatTuId}");

                }
                nhap.TongTien = lstChiTiet.Sum(x => x.GiaTien);
                _db.SaveChanges();
                trans.Commit();
                return nhap;
            }

        }
        public IQueryable<PhieuNhap> XuatPhieuNhap(int? year = null,
                                                   int? month = null,
                                                   double? TongTien = null
                                                   
                                                   )
        {
            var query = _db.PhieuNhap.OrderByDescending(x => x.TongTien).AsQueryable();
            if (year != null) query=query.Where(x=>x.NgayNhap.Year== year);
            if(month!=null) query=query.Where(x=>x.NgayNhap.Month== month);
            if (TongTien != null) query = query.Where(x => x.TongTien == TongTien);
            return query;
        }
        public string TaoMaXuat()
        {
            string res = DateTime.Now.ToString("yyyyMMdd") + "_";
            var SoGDHomNay = _db.PhieuXuat.Count(x => x.NgayXuat.Date == DateTime.Now.Date);
            if (SoGDHomNay > 0)
            {
                int tmp = SoGDHomNay + 1;
                if (tmp < 10) res = res + "00" + tmp;
                if (tmp < 100) res = res + "0" + tmp;

            }
            else res = res + "001";
            return res;
        }
        public PhieuXuat ThemPhieuXuat(PhieuXuat xuat)
        {
            using (var trans = _db.Database.BeginTransaction())
            {
                xuat.MaPhieuXuat = TaoMaNhap();
                xuat.NgayXuat = DateTime.Now;
                var lstChiTiet = xuat.ChiTietPhieuXuats;
                _db.Add(xuat);
                _db.SaveChanges();
                foreach (var chitiet in lstChiTiet)
                {
                    if (_db.VatTus.Any(x => x.VatTuId == chitiet.VatTuId))
                    {
                        chitiet.ChiTietPhieuXuatId = null;
                        chitiet.PhieuXuatId = xuat.PhieuXuatId;
                        var vattu = _db.VatTus.FirstOrDefault(x => x.VatTuId == chitiet.VatTuId);
                        vattu.SoLuongTon = vattu.SoLuongTon - chitiet.SoLuongXuat;
                        chitiet.GiaTien = vattu.GiaNhap * chitiet.SoLuongXuat;
                        _db.Update(vattu);
                        _db.Add(chitiet);
                        _db.SaveChanges();
                    }
                    else throw new Exception($"Vat tu khong ton tai kiem tra vat tu co id la {chitiet.VatTuId}");

                }
                xuat.TongTien = lstChiTiet.Sum(x => x.GiaTien);
                _db.SaveChanges();
                trans.Commit();
                return xuat;
            }
        }
        public IQueryable<PhieuXuat> XuatPhieuXuat(int? year = null, int? month = null, double? TongTien = null)
        {
            var query = _db.PhieuXuat.OrderByDescending(x => x.TongTien).AsQueryable();
            if (year != null) query = query.Where(x => x.NgayXuat.Year == year);
            if (month != null) query = query.Where(x => x.NgayXuat.Month == month);
            if (TongTien != null) query = query.Where(x => x.TongTien == TongTien);
            return query;

        }
        public void XoaPhieuNhap(int PhieuNhapId)
        {
            PhieuNhap nhap=_db.PhieuNhap.FirstOrDefault(x=>x.PhieuNhapId== PhieuNhapId);
            if (nhap != null)
            {
                _db.Remove(nhap);
                _db.SaveChanges();
            }
            else throw new Exception($"Id khong ton tai kiem tra lai Id {PhieuNhapId}");
        }
        public void XoaPhieuXuat(int PhieuXuatId)
        {
            PhieuXuat xuat = _db.PhieuXuat.FirstOrDefault(x => x.PhieuXuatId == PhieuXuatId);
            if (xuat != null)
            {
                _db.Remove(xuat);
                _db.SaveChanges();
            }
            else throw new Exception($"Id khong ton tai kiem tra lai Id {PhieuXuatId}");
        }
    }

}

