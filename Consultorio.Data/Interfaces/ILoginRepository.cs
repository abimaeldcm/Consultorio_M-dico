using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.OutputDTOs;

namespace Consultorio.Infra.Data.Interfaces
{
    public interface ILoginRepository
    {
        Task<User> FindLogin(string name, string password);
    }
}
