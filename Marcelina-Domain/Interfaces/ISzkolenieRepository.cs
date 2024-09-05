using Marcelina_Domain.Enties.Szkolenia;

namespace Marcelina_Domain.Interfaces
{
    public interface ISzkolenieRepository
    {
        Task<Szkolenie> GetElementById(int id);

        Task<IEnumerable<Szkolenie>> GetAll();

        Task Create(Szkolenie createSzkolenie);

        Task Delete(int id);

        Task Update(Szkolenie updateSzkolenie);
    }
}