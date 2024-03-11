namespace Consultorio.Application.Email
{
    public interface IEnviarEmail
    {
        Task<bool> Enviar(string email, string assunto, string mensagem);
    }
}
