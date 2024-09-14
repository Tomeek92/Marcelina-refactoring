using Marcelina_Domain.Interfaces;
using Marcelina_Domain.Uslugi;
using Marcelina_infrastructure.DbContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Marcelina_infrastructure.Repository
{
    public class UslugaRepository : IUslugaRepository
    {
        private readonly MarcelinaRefactoringDbContext _context;

        public UslugaRepository(MarcelinaRefactoringDbContext context)
        {
            _context = context;
        }

        public async Task<Usluga> GetElementById(int id)
        {
            try
            {
                var findId = await _context.FindAsync<Usluga>(id);
                if (findId == null)
                {
                    throw new KeyNotFoundException($"Nie odnaleziono rekordu");
                }
                return findId;
            }
            catch (SqlException sql)
            {
                throw new InvalidOperationException("Błąd połączenia z bazą danych", sql);
            }
        }

        public async Task Create(Usluga createUsluga)
        {
            try
            {
                bool existingUsluga = await _context.Uslugi.AnyAsync(t => t.Name == createUsluga.Name);
                if (existingUsluga)
                {
                    throw new Exception($"Istnieje już taka usługa z tą nazwą");
                }
                _context.Add(createUsluga);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Błąd podczas dodawania zadania {ex.Message}");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var findId = await GetElementById(id);
                if (findId == null)
                {
                    throw new KeyNotFoundException($"Rekord o podanym {id} nie został znaleziony");
                }
                _context.Remove(findId);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Nieoczekiwany błąd", ex);
            }
        }

        public async Task<IEnumerable<Usluga>> GetAll()
        {
            try
            {
                var allUslugi = await _context.Uslugi.ToListAsync();
                if (allUslugi == null)
                {
                    throw new Exception($"Nie odnaleziono usług");
                }
                return allUslugi;
            }
            catch (Exception ex)
            {
                throw new Exception($"Nieoczekiwany błąd", ex);
            }
        }

        public async Task Update(Usluga updateUsluga)
        {
            try
            {
                var existingUsluga = await GetElementById(updateUsluga.Id);
                if (existingUsluga == null)
                {
                    throw new KeyNotFoundException($"Nie znaleziono takiej usługi z tym numere id {updateUsluga.Id}");
                }
                _context.Uslugi.Update(existingUsluga);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Nieoczekiwany błąd podczas aktualizowania {ex.Message}");
            }
        }
    }
}