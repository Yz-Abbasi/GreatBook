
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.ProductAgg.Repository;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Infrastructure.Persistent.Ef.ProductAgg;

namespace Shop.Infrastructure
{
    public static class InfrastructureBootstraper
    {
        public static void Init(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient(_ => new DapperContext(connectionString));
            services.AddDbContext<ShopContext>(option =>
            {
                option.UseSqlServer();
            });
        }
    }
}