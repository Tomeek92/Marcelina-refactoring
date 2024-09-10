using Marcelina_Domain.Enties.Users;
using Marcelina_Domain.Interfaces;
using Marcelina_infrastructure.DbContext;
using Marcelina_infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
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

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
            })
    .AddEntityFrameworkStores<MarcelinaRefactoringDbContext>()
    .AddDefaultTokenProviders();

            services.AddScoped<ISzkolenieRepository, SzkolenieRepository>();
            services.AddScoped<IUslugaRepository, UslugaRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<SignInManager<User>>();
        }
    }
}