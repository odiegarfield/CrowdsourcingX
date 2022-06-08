using CrowdsourcingX.Infra.Entities;
using CrowdsourcingX.Infra.Repositories;

namespace CrowdsourcingX.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private CrowdsourcingContext context;
        public GenericRepository<User> UserRepository { get; private set; }
        public GenericRepository<Picture> PictureRepository { get; private set; }
        public UnitOfWork(CrowdsourcingContext context)
        {
            this.context = context;
            UserRepository = new GenericRepository<User>(this.context);
            PictureRepository = new GenericRepository<Picture>(this.context);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
