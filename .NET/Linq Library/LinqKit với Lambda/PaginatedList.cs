namespace Project.Application.Common.Models
{
    public class PaginatedList<T>
    {
        public IEnumerable<T> Items {get; }
        public int PageIndex {get; }
        public int TotalPages {get; }
        public int TotalCount {get; }

        public PaginatedList(IEnumerable<T> items, int pageIndex, int totalPages, int totalCount)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)totalPages);
            TotalCount = totalCount;
            Items = items;
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
    }
}