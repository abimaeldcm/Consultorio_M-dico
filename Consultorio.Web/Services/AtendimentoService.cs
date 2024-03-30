using Consultorio.Web.Helper;
using Consultorio.Web.Models;
using Consultorio.Web.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Consultorio.Web.Services
{
    public class AtendimentoService : ICRUD<Consult>
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/Consult/";
        private readonly JsonSerializerOptions _options;
        private Consult atendimento;
        private IEnumerable<Consult> atendimentos;
        private readonly ISessao _isessao;

        public AtendimentoService(IHttpClientFactory clientFactory, ISessao isessao)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _isessao = isessao;
        }

        public async Task<Consult> BuscarPorId(int id)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                var tokenJwt = sessaoUser.Token;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.GetAsync(apiEndpoint + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        atendimento = JsonSerializer.Deserialize<Consult>(apiResponse, _options);
                    }
                }
            }

            return atendimento;
        }

        public async Task<IEnumerable<Consult>> BuscarPorTexto(string termoPesquisa)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                var tokenJwt = sessaoUser.Token;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.GetAsync(apiEndpoint + "BuscarPorTexto/" + termoPesquisa))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        atendimentos = JsonSerializer.Deserialize<List<Consult>>(apiResponse, _options);
                    }
                }
            }

            return atendimentos;
        }

        public async Task<IEnumerable<Consult>> BuscarTodos()
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            // Obter a sessão do usuário
            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            // Verificar se a sessão e o token são válidos
            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                // Obter o token JWT da sua aplicação
                var tokenJwt = sessaoUser.Token;

                // Adicionar o token JWT ao cabeçalho Authorization
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.GetAsync(apiEndpoint))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStreamAsync();
                        var atendimentos = await JsonSerializer.DeserializeAsync<List<Consult>>(apiResponse, _options);
                        return atendimentos;
                    }
                    else
                    {
                        // Tratar erros de requisição
                        return Enumerable.Empty<Consult>();
                    }
                }
            }
            else
            {
                // Tratar caso a sessão ou o token sejam inválidos
                return Enumerable.Empty<Consult>();
            }
        }

        public async Task<Consult> Cadastrar(Consult cadastrar)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                var tokenJwt = sessaoUser.Token;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                var content = new StringContent(JsonSerializer.Serialize(cadastrar), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync(apiEndpoint, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        atendimento = JsonSerializer.Deserialize<Consult>(apiResponse, _options);
                    }
                }
            }

            return atendimento;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                var tokenJwt = sessaoUser.Token;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.DeleteAsync(apiEndpoint + id))
                {
                    return response.IsSuccessStatusCode;
                }
            }

            return false;
        }

        public async Task<object> Editar(int id, Consult editar)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                var tokenJwt = sessaoUser.Token;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                var content = new StringContent(JsonSerializer.Serialize(editar), Encoding.UTF8, "application/json");

                using (var response = await client.PutAsync(apiEndpoint + id, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        atendimento = JsonSerializer.Deserialize<Consult>(apiResponse, _options);
                    }
                    else
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var validationErrors = JsonSerializer.Deserialize<Erros>(responseBody);
                        return validationErrors;
                    }
                }
            }

            return null;
        }

    }
}
