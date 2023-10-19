using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Repositories.Interfaces;
using StaffSightAPI.Data;

namespace StaffSightAPI.Repositories.Implementations
{
    public interface IHasPreHireID
    {
        int PreHireID { get; set; }
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<List<T>> GetByPreHireIdAsync(int? preHireID)
        {
            // Ensure T implements IHasPreHireID
            if (typeof(IHasPreHireID).IsAssignableFrom(typeof(T)))
            {
                return await _context.Set<T>().Where(e => (e as IHasPreHireID).PreHireID == preHireID).ToListAsync();
            }
            throw new InvalidOperationException("Entity does not have a PreHireID property.");
        }
    }
}
