using LibrarySystem.Repositories;
using LibrarySystem.Data.Models.core;
using LibrarySystem.Data.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : Entity<Guid>
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<PagedCollection<T>> GetPaginatedAsync(int pageNumber = Constants.PAGE_NUMBER, int pageSize = Constants.PAGE_SIZE)
        {
            var total = await _dbSet.CountAsync();
            var items = await _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedCollection<T>(items, total, pageNumber, pageSize);
        }

        public async Task<PagedCollection<T>> GetAllAsync(FilterQueryParameters filter, IQueryable<T> extendedQuery = null)
        {
            var query = extendedQuery ?? _dbSet.AsQueryable();

            int pageNumber = filter.PageableQuery?.PageNumber ?? Constants.PAGE_NUMBER;
            int pageSize = filter.PageableQuery?.PageSize ?? Constants.PAGE_SIZE;

            int total = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedCollection<T>(items, total, pageNumber, pageSize);
        }

        public T GetById(Guid id) => _dbSet.Find(id);

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetRangeAsync(List<Guid> ids)
        {
            return await _dbSet.Where(e => ids.Contains(e.Id)).ToListAsync();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            await _context.SaveChangesAsync();
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(Guid id, T entity)
        {
            var existing = await _dbSet.FindAsync(id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existing;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            _context.SaveChanges();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            _context.SaveChanges();
        }

        public async Task ExecuteDeleteRange(IEnumerable<Guid> ids)
        {
            var entities = await _dbSet.Where(e => ids.Contains(e.Id)).ToListAsync();
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Query() => _dbSet.AsQueryable();

        public async Task<bool> AnyAsync(Guid id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            return await AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
