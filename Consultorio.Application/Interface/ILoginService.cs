using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.OutputDTOs;

namespace Consultorio.Application.Interface
{
    public interface ILoginService
    {
        Task<UserOutputDTO> FindLogin(string name, string password);
    }
}
