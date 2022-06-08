using CrowdsourcingX.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace CrowdsourcingX.Infra
{
    public class CrowdsourcingContext : DbContext
    {
        public CrowdsourcingContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(
                    Assembly.GetExecutingAssembly(),
                    t => t.GetInterfaces().Any(i =>
                         i.IsGenericType &&
                         i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>) &&
                            typeof(BaseEntity).IsAssignableFrom(i.GenericTypeArguments[0]))
                    );
        }
        public DbSet<User> User { get; set; }
        public DbSet<Picture> Picture { get; set; }
    }
}
