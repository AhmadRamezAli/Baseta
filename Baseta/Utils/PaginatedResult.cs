namespace Baseta.Utils
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }

        public PaginatedResult()
        {
        }

        public PaginatedResult(IEnumerable<T> data, int totalCount, int page, int pageSize)
        {
            Data = data;
            TotalCount = totalCount;
            Page = page;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            HasNextPage = page < TotalPages;
            HasPreviousPage = page > 1;
        }

        public static PaginatedResult<T> Create(IEnumerable<T> data, int totalCount, int page, int pageSize)
        {
            return new PaginatedResult<T>(data, totalCount, page, pageSize);
        }
    }
}
