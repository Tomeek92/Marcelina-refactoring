using Marcelina_Domain.Enties.Szkolenia;
using Marcelina_Domain.Interfaces;
using Marcelina_infrastructure.DbContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Marcelina_infrastructure.Repository
{
    public class SzkolenieRepository : ISzkolenieRepository
    {
        private readonly MarcelinaRefactoringDbContext _context;

        public SzkolenieRepository(MarcelinaRefactoringDbContext context)
        {
            _context = context;
        }

        public async Task<Szkolenie> GetElementById(int id)
        {
            try
            {
                var findId = await _context.FindAsync<Szkolenie>(id);
                if (findId == null)
                {
                    throw new KeyNotFoundException($"Nie odnaleziono rekordu");
                }
                return findId;
            }
            catch (SqlException sql)
            {
                throw new InvalidOperationException($"Nieoczekiwany błąd {sql.Message}");
            }
        }

        public async Task<IEnumerable<Szkolenie>> GetAll()
        {
            try
            {
                var getAll = await _context.Szkolenia.ToListAsync();
                if (getAll == null)
                {
                    throw new Exception($"Brak Szkoleń w bazie danych");
                }
                return getAll;
            }
            catch (Exception ex)
            {
                throw new Exception($"Nieoczekiwany błąd {ex.Message}");
            }
        }

        public async Task Create(Szkolenie createSzkolenie)
        {
            try
            {
                bool existingSzkolenie = await _context.Szkolenia.AnyAsync(t => t.Name == createSzkolenie.Name);
                if (existingSzkolenie)
                {
                    throw new Exception($"Istnieje już taki rekord w bazie danych!");
                }
                _context.Add(createSzkolenie);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Nieoczekiwany błąd {ex.Message}");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var findId = await GetElementById(id);
                _context.Remove(id);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Nieoczekiwany błąd podczas usuwania {ex.Message}");
            }
        }

        public async Task Update(Szkolenie updateSzkolenie)
        {
            try
            {
                var existingUsluga = await GetElementById(updateSzkolenie.Id);
                if (existingUsluga == null)
                {
                    throw new KeyNotFoundException($"Nie odnaleziono rekordu do aktualizacji");
                }
                _context.Szkolenia.Update(existingUsluga);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Nieoczekiwany błąd podczas aktualizowania rekordu {ex.Message}");
            }
        }
    }
}