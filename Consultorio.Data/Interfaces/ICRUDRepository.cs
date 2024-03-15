using Consultorio.Domain.Entity;

namespace Consultorio.Infra.Data.Interfaces
{
    public interface ICRUDRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> FindById(int id);
        Task<List<T>> FindByText(string query);
        Task<T> Create(T create);
        Task<T> Update(T update);
        Task<bool> Delete(int id);
    }
}
