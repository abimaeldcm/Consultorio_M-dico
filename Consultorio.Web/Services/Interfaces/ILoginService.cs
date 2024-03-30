using Consultorio.Web.Models;

namespace Consultorio.Web.Services.Interfaces
{
    public interface ILoginService
    {
        Task<UserLogged> FindLogin(User user);
    }
}
