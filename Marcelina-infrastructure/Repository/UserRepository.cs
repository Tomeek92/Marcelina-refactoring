using Marcelina_Domain.Enties.Users;
using Marcelina_Domain.Interfaces;
using Marcelina_infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Marcelina_infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly MarcelinaRefactoringDbContext _context;

        public UserRepository(UserManager<User> userManager, MarcelinaRefactoringDbContext context, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<SignInResult> LoginAsync(string userName, string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userName, password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return SignInResult.Success;
                }
                else
                {
                    return SignInResult.Failed;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Błąd podczas logowania {ex.Message}");
            }

        }

        public async Task<IdentityResult> Create(User user, string password)
        {
            try
            {
                bool existinUser = await _context.Users.AnyAsync(t => t.UserName == user.UserName);
                if (existinUser)
                {
                    throw new Exception($"Użytkownik już istnieje w bazie danych");
                }
                var result = await _userManager.CreateAsync(user, password);
                if (result == null)
                {
                    throw new Exception($"Nie utworzono użytkownika");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Nieoczekiwany błąd podczas tworzenia użytkownika {ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                var getAll = await _context.Users.ToListAsync();
                if (getAll == null)
                {
                    throw new KeyNotFoundException($"Nie odnaleziono użytkowników");
                }
                return getAll;
            }
            catch (Exception ex)
            {
                throw new Exception($"Nieoczekiwany błąd podczas pobierania użytkowników {ex.Message}");
            }
        }

        public async Task<User> GetElementById(string id)
        {
            try
            {
                var findId = await _context.FindAsync<User>(id);
                if (findId == null)
                {
                    throw new Exception($"Nie odnaleziono użytkownika w bazie danych");
                }
                return findId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Nieoczekiwany błąd {ex.Message}");
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                await GetElementById(id);
                _context.Remove(id);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Nieczekiwany błąd podczas usuwania {ex.Message}");
            }
        }

        public async Task Update(User user)
        {
            try
            {
                var findUser = await GetElementById(user.Id);
                if (findUser == null)
                {
                    throw new KeyNotFoundException($"Nie odnaleziono użytkownika");
                }
                _context.Users.Update(findUser);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Nieoczekiwany błąd podczas aktualizowania użytkownika {ex.Message}");
            }
        }
    }
}