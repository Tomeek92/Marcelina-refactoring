using Marcelina_Domain.Interfaces;
using Marcelina_infrastructure.DbContext;
using Marcelina_infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marcelina_infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MarcelinaRefactoringDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("MarcelinaRefactoringDbContext")));

            services.AddScoped<ISzkolenieRepository, SzkolenieRepository>();
            services.AddScoped<IUslugaRepository, UslugaRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}