using Marcelina_Application.CQRS.Command.Szkolenia.Create;
using Marcelina_Application.CQRS.Command.Szkolenia.Delete;
using Marcelina_Application.CQRS.Command.Szkolenia.Update;
using Marcelina_Application.CQRS.Command.Users.Create;
using Marcelina_Application.CQRS.Command.Users.Delete;
using Marcelina_Application.CQRS.Command.Users.Login;
using Marcelina_Application.CQRS.Command.Users.Update;
using Marcelina_Application.CQRS.Command.Uslugi.Create;
using Marcelina_Application.CQRS.Command.Uslugi.Delete;
using Marcelina_Application.CQRS.Command.Uslugi.Update;
using Marcelina_Application.CQRS.Query.Szkolenia.GetAll;
using Marcelina_Application.CQRS.Query.Szkolenia.GetId;
using Marcelina_Application.CQRS.Query.Users.GetAll;
using Marcelina_Application.CQRS.Query.Users.GetId;
using Marcelina_Application.CQRS.Query.Uslugi.GetAll;
using Marcelina_Application.CQRS.Query.Uslugi.GetId;
using Marcelina_Application.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Marcelina_Application.Extensions
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
        typeof(CreateSzkolenieCommand).Assembly,
        typeof(UpdateSzkolenieCommand).Assembly,
        typeof(DeleteSzkolenieCommand).Assembly,
         typeof(CreateUserCommand).Assembly,
         typeof(UpdateUserCommand).Assembly,
         typeof(DeleteUserCommand).Assembly,
         typeof(LoginUserCommand).Assembly,
         typeof(CreateUslugiCommand).Assembly,
         typeof(DeleteUslugiCommand).Assembly,
         typeof(UpdateUslugiCommand).Assembly,
         typeof(GetAllUslugiCommand).Assembly,
          typeof(GetUslugiIdCommand).Assembly,
         typeof(GetAllSzkoleniaCommand).Assembly,
         typeof(GetSzkolenieIdCommand).Assembly,
         typeof(GetAllUsersCommand).Assembly,
         typeof(GetUserIdCommand).Assembly

           ));
            services.AddAutoMapper(typeof(MapperProfile));
        }
    }
}