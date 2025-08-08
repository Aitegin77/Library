using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected LibraryDbContext libraryDbContext { get; init; }

        public Repository(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        protected DbSet<TEntity> Set => libraryDbContext.Set<TEntity>();

        public IQueryable<TEntity> GetSet() => Set;

        public void Update(TEntity entity) => Set.Update(entity);

        public void Delete(TEntity entity) => Set.Remove(entity);

        public async Task AddAsync(TEntity entity) => await Set.AddAsync(entity);

        public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await Set.AddRangeAsync(entities);

        public async Task<IEnumerable<TEntity>> GetAll() => await Set.ToListAsync();

        public async Task<TEntity?> GetByIdAsync(int id) => await Set.FindAsync(id);

        public IQueryable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter, int count = 5) =>
            Set.Where(filter).Take(count).AsNoTracking();

        public async Task SaveChangesAsync() => await libraryDbContext.SaveChangesAsync();

        public Task<int> UpdateAuditableEntitiesAsync(string userId, CancellationToken cancellationToken = default)
        {
            // Ensure the auditable entities are updated with the userId before saving
            //libraryDbContext.UpdateAuditableEntities(userId);
            return libraryDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> IsAnyAsync(Expression<Func<TEntity, bool>> filter) =>
            await Set.AnyAsync(filter);

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter) =>
            await Set.CountAsync(filter);

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter) =>
            await Set.FirstOrDefaultAsync(filter);

        public async Task<IReadOnlyList<TEntity>> GetItemsAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entities = await Set
                .Where(filter)
                .AsNoTracking()
                .ToListAsync();

            return entities.AsReadOnly();
        }
    }
}
