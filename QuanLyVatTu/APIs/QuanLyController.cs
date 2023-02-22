using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyVatTu.Entities;
using QuanLyVatTu.Helper;
using QuanLyVatTu.Service;

namespace QuanLyVatTu.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLyController : ControllerBase
    {
        private readonly Service.Service Service=new Service.Service();
        [HttpPost("/ThemPhieuNhap")]
        public IActionResult ThemPhieuNhap(PhieuNhap nhap)
        {
            var res = Service.ThemPhieuNhap(nhap);
            return Ok(res);
        }
        [HttpGet("/XuatPhieuNhap")]
        public IActionResult XuatPhieuNhap( Pagination pagination,
                                            int year,
                                            int month,
                                            double? TongTien = null)
        {
            var query=Service.XuatPhieuNhap(year, month, TongTien);
            var res=PageResult<PhieuNhap>.ToPageResult(pagination, query);
            return Ok(res);
        }

        [HttpPost("/ThemPhieuXuat")]
        public IActionResult ThemPhieuXuat(PhieuXuat xuat)
        {
            var res = Service.ThemPhieuXuat(xuat);
            return Ok(res);
        }
        [HttpGet("/XuatPhieuXuat")]
        public IActionResult XuatPhieuXuat(Pagination pagination,
                                           int? year = null,
                                           int? month = null,
                                           double? TongTien = null)
        {
            var query = Service.XuatPhieuXuat(year, month, TongTien);
            var res=PageResult<PhieuXuat>.ToPageResult(pagination, query);
            return Ok(res);
        }
        [HttpDelete("/XoaPhieuNhap")]
        public IActionResult XoaPhieuNhap(int PhieuNhapId)
        {
            Service.XoaPhieuNhap(PhieuNhapId);
            return Ok();
        }
        [HttpDelete("/XoaPhieuXuat")]
        public IActionResult XoaPhieuXuat(int PhieuXuatId)
        {
            Service.XoaPhieuXuat(PhieuXuatId);
            return Ok();
        }
    }
}
