namespace QuanLyVatTu.Helper
{
    public class Pagination
    {
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int TotalPage {
            get
            {
                if (this.PageSize == 0) return 0;
                var total=this.TotalCount/PageSize;
                if (this.TotalCount % PageSize != 0) total += 1;
                return total;
            }
        }
    }
}
