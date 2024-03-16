namespace Consultorio.Application.Email
{
    public interface ISeedEmail
    {
        Task<bool> Seed(string email, string assunto, string mensagem);
    }
}
