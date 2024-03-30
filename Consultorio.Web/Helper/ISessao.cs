using Consultorio.Web.Models;

namespace Consultorio.Web.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UserLogged usuario);
        void RemoverSessaoUsuario();
        UserLogged BuscarSessaoDoUsuario();
    }
}
