namespace QuanLyVatTu.Entities
{
    public class PhieuNhap
    {
        public int PhieuNhapId { get; set; }
        public string? MaPhieuNhap { get; set; }
        public string? TieuDe { get; set; }
        public DateTime NgayNhap { get; set; }
        public double? TongTien { get; set; }
        public List<ChiTietPhieuNhap>? ChiTiet { get; set;}
    }
}
