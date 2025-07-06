using LibrarySystem.Data.DTOs;
using LibrarySystem.Data.Models.core;

namespace LibrarySystem.Repositories
{
    public partial interface IRepository<T>
        where T : Entity<Guid>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<PagedCollection<T>> GetPaginatedAsync(int pageNumber = Constants.PAGE_NUMBER, int pageSize = Constants.PAGE_SIZE);


        Task<PagedCollection<T>> GetAllAsync(FilterQueryParameters filter, IQueryable<T> extendedQuery = null);
        T GetById(Guid id);
        Task<IEnumerable<T>> GetRangeAsync(List<Guid> ids);
        Task<T> GetByIdAsync(Guid id);
        void Add(T entity);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        T Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        void DeleteById(Guid id);
        Task DeleteByIdAsync(Guid id);
        void DeleteRange(IEnumerable<T> entities);
        void UpdateRange(IEnumerable<T> entities);
        Task ExecuteDeleteRange(IEnumerable<Guid> Ids);
        IQueryable<T> Query();
        Task<bool> AnyAsync(Guid id);
        Task<T> CreateAsync(T entity);                      
        Task<T> UpdateAsync(Guid id, T entity);             
        Task<bool> DeleteAsync(Guid id);                    

    }
}

