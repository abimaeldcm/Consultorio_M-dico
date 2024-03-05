namespace Consultorio.Domain.Entity.InputDTOs
{
    public class MedicoInputDTO : Usuario
    {
        public int IdEspecialidade { get; set; }
        public string RegistroCRM { get; set; }
    }
}
