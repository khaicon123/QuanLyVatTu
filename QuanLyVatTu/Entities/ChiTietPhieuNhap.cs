namespace QuanLyVatTu.Entities
{
    public class ChiTietPhieuNhap
    {
        public int? ChiTietPhieuNhapId { get; set; }
        public int VatTuId { get; set; }
        public VatTu? VatTu { get; set; }
        public int? PhieuNhapId { get; set; }
        public PhieuNhap? PhieuNhap { get; set; }
        public int SoLuongNhap { get; set; }
        public double GiaTien { get; set; }
    }
}
