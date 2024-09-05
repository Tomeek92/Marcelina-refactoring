using Marcelina_Domain.Uslugi;

namespace Marcelina_Domain.Interfaces
{
    public interface IUslugaRepository
    {
        Task<Usluga> GetElementById(int id);

        Task Create(Usluga createUsluga);

        Task Delete(int id);

        Task<IEnumerable<Usluga>> GetAll();

        Task Update(Usluga updateUsluga);
    }
}