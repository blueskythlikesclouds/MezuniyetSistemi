namespace Core.Entities.Concrete
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }

        public PagedList(List<T> items, int count, int currentPage, int pageSize)
        {
            MetaData = new()
            {
                TotalCount = count,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalPage = (int)Math.Ceiling(count / (double)pageSize)
            };

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int currentPage, int pageSize)
        {
            var count = source.Count();
            var items = source
                .Skip((currentPage -1)* pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedList<T>(items,count, currentPage, pageSize);
        }
    }
}
