namespace Consultorio.Application.Interface
{
    public interface ICRUDService<T, U> where T : class where U : class
    {
        Task<List<T>> BuscarTodos();
        Task<T> BuscarPorId(int id);
        Task<List<T>> BuscarPorTexto(string termoPesquisa);
        Task<T> Cadastrar(U cadastrar);
        Task<T> Editar(int id,U editar);
        Task<bool> Delete(int id);
    }
}
