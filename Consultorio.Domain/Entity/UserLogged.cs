using Consultorio.Domain.Entity.OutputDTOs;

namespace Consultorio.Domain.Entity
{
    public class UserLogged
    {
        public UserOutputDTO User { get; set; }
        public string Token {  get; set; }
    }
}
