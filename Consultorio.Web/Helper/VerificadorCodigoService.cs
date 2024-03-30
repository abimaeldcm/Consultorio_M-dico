using Microsoft.Extensions.Caching.Memory;

namespace PontoMVC.Helper
{
    public class VerificadorCodigoService
    {
        private readonly IMemoryCache _memoryCache;

        public VerificadorCodigoService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void GuardarEmailCache(string email)
        {
            _memoryCache.Set("EmailCache", email, TimeSpan.FromMinutes(10));
        }

        public bool ValidarEmailCache(string email)
        {
            _memoryCache.TryGetValue("EmailCache", out string storedCode);
            if (storedCode == email)
            {
                return true;
            }
            return false;
        }
        public string RecuperarEmailCache()
        {
            _memoryCache.TryGetValue("EmailCache", out string storedCode);
            return storedCode;
        }


        public int GerarCodigo()
        {
            Random rand = new Random();
            int codigo = rand.Next(100000, 999999); // Garantindo um código de 6 dígitos

            _memoryCache.Set("codigoCache", codigo.ToString(), TimeSpan.FromMinutes(10));

            return codigo;
        }

        public bool ValidarCodigoEnviado(string codigo)
        {
            _memoryCache.TryGetValue("codigoCache", out string storedCode);

            // Compare as strings, não os códigos inteiros
            if (storedCode == codigo)
            {
                return true; // Os códigos coincidem
            }
            return false; // Os códigos não coincidem
        }

    }
}
