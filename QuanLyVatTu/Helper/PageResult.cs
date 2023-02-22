namespace QuanLyVatTu.Helper
{
    public class PageResult<T>
    {
        public Pagination pagination { get; set; }
        public PageResult(Pagination pagination)
        {
            this.pagination = pagination;
        }
        public static IQueryable<T> ToPageResult(Pagination pagination,IQueryable<T> query)
        {
            query = query.Skip(pagination.PageSize * (pagination.PageNumber - 1)).Take(pagination.PageSize).AsQueryable();  
            return query;
        }
    }
}
