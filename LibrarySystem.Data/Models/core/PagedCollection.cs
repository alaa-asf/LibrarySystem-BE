using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data.Models.core
{
    public class PagedCollection<T>
    {

        public List<T> Items { get; set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage + 1 > 1;
        public bool HasNext => CurrentPage + 1 < TotalPages;

        public PagedCollection(IEnumerable<T> list, int count, int pageNumber, int pageSize)
        {
            Items = list.ToList();
            CurrentPage = pageNumber;
            TotalPages = count == 0 ? 0 : (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            TotalCount = count;
        }

        public static PagedCollection<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var items = ToPagedListAsync(source, pageNumber, pageSize).Result;
            return items;
        }

        public async static Task<PagedCollection<T>> ToPagedListAsync(IQueryable<T> source, int pageNumber = Constants.PAGE_NUMBER, int pageSize = Constants.PAGE_SIZE)
        {
            var count = await source.CountAsync();
            var items = await GetPageableQueryable(source, pageNumber, pageSize).ToListAsync();
            return new PagedCollection<T>(items, count, pageNumber, pageSize);
        }
        public async static Task<PagedCollection<T>> ToListAsync(IQueryable<T> source)
        {
            var count = await source.CountAsync();
            var items = await source.ToListAsync();
            return new PagedCollection<T>(items, count, Constants.PAGE_NUMBER, Constants.PAGE_SIZE);
        }

        private static IQueryable<T> GetPageableQueryable(IQueryable<T> source, int pageNumber, int pageSize)
        {
            if (pageNumber >= 0)
                return source.Skip(pageNumber * pageSize).Take(pageSize);
            return source;
        }






    }
}

