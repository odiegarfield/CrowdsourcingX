using CrowdsourcingX.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrowdsourcingX.Infra.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CrowdsourcingContext _context;
        private DbSet<T> DbSet;
        public GenericRepository(CrowdsourcingContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }
        
        public IQueryable<T> AsQueryable()
        {
            return DbSet.AsQueryable().Where(x => x.Active);
        }

        public async Task<T> GetByIdAsync(Guid id) => await DbSet.SingleOrDefaultAsync(e => e.Id == id && e.Active);

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Add(List<T> entityList)
        {
            DbSet.AddRange(entityList);
        }

        public void Update(T entity)
        {
            this.DbSet.Update(entity);
        }

        public void Update(List<T> entityList)
        {
            DbSet.UpdateRange(entityList);
        }

        public void Delete(T entity)
        {
            entity.Active = false;
        }
    }
}
