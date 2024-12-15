namespace Shop.Api.Infrastructure;
public static class DependencyRegister
{
    public static void RegisterApiDependency(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapperProfile).Assembly);

        services.AddCors(option =>
        {
            option.AddPolicy(name: "ShopApi", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod();
            });
        });
    }
}