namespace QuanLyVatTu.Entities
{
    public class PhieuXuat
    {
        public int PhieuXuatId { get; set; }
        public string MaPhieuXuat { get; set; }
        public string TieuDe { get; set; }
        public DateTime NgayXuat { get; set; }
        public double TongTien { get; set; }
        public List<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
    }
}
