using Microsoft.EntityFrameworkCore;
using StudentGradebookApi.Data;

namespace StudentGradebookApi.Repositories.Main
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly SchoolDbContext _context;
        private readonly DbSet<T> _dbSet;
        public RepositoryBase(SchoolDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<T?> GetByEmailAsync(string email) =>await _dbSet.FirstOrDefaultAsync(e => EF.Property<string>(e, "Email") == email);
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
