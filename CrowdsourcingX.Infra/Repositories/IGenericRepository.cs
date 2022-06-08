using CrowdsourcingX.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdsourcingX.Infra.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> AsQueryable();
        Task<T> GetByIdAsync(Guid id);
        void Add(T entity);
        void Add(List<T> entity);
        void Update(T entity);
        void Update(List<T> entity);
        void Delete(T entity);
    }
}
