using CrowdsourcingX.Infra;
using CrowdsourcingX.Infra.Repositories;
using CrowdsourcingX.Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CrowdsourcingX.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CrowdsourcingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime)
        {
        }
    }
}
