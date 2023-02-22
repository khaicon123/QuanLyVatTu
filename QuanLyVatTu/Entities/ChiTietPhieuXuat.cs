namespace QuanLyVatTu.Entities
{
    public class ChiTietPhieuXuat
    {
        public int? ChiTietPhieuXuatId { get; set; }
        public int VatTuId { get; set; }
        public VatTu VatTu { get; set; }
        public int PhieuXuatId { get; set; }
        public PhieuXuat PhieuXuat { get; set; }
        public int SoLuongXuat { get; set; }
        public double GiaTien { get; set; }
    }
}
