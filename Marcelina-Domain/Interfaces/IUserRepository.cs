using Marcelina_Domain.Enties.Users;
using Microsoft.AspNetCore.Identity;

namespace Marcelina_Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> Create(User user, string password);

        Task<IEnumerable<User>> GetAll();

        Task<User> GetElementById(string id);

        Task Delete(string id);

        Task Update(User user);

        Task<User?> FindByEmailAsync(string? email);

        Task<SignInResult> LoginAsync(string userName, string password);
    }
}