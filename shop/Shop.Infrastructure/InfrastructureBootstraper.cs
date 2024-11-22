
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.ProductAgg.Repository;
using Shop.Infrastructure.Persistent.Ef.ProductAgg;

namespace Shop.Infrastructure
{
    public static class InfrastructureBootstraper
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}