using CineMaxColDal.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CineMaxColIOC
{
    public static class Dependencias
    {
         public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CineMaxColContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Connection")));
        }
    }
}