using Consultorio.Domain.Entity;

namespace Consultorio.Infra.Data.Interfaces
{
    public interface ICRUDRepository<T> where T : class
    {
        Task<List<T>> BuscarTodos();
        Task<T> BuscarPorId(int id);
        Task<List<T>> BuscarPorTexto(string termoPesquisa);
        Task<T> Cadastrar(T cadastrar);
        Task<T> Editar(T editar);
        Task<bool> Delete(int id);
    }
}
