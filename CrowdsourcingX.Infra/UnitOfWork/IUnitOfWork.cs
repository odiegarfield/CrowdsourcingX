using CrowdsourcingX.Infra.Entities;
using CrowdsourcingX.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdsourcingX.Infra.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<User> UserRepository
        {
            get;
        }
        GenericRepository<Picture> PictureRepository
        {
            get;
        }
        Task SaveChangesAsync();
    }
}
