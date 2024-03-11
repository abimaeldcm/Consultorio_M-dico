namespace Consultorio.Web.Services.Interfaces
{
    public interface ICRUD<T> where T : class
    {
        Task<T> BuscarPorId(int id);
        Task<IEnumerable<T>> BuscarPorTexto(string termoPesquisa);
        Task<IEnumerable<T>> BuscarTodos();
        Task<T> Cadastrar(T cadastrar);
        Task<bool> Delete(int id);
        Task<object> Editar(int id, T editar);
    }
}
