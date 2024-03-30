using Consultorio.Web.Models;
using System.Text.Json;
using System.Text;
using Consultorio.Web.Services.Interfaces;
using System.Net.Http.Headers;
using Consultorio.Web.Helper;

namespace Consultorio.Web.Services
{
    public class ServiceService : ICRUD<ServiceEntity>
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/Service/";
        private readonly JsonSerializerOptions _options;
        private ServiceEntity servico;
        private IEnumerable<ServiceEntity> servicos;
        private readonly ISessao _isessao;


        public ServiceService(IHttpClientFactory clientFactory, ISessao isessao)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _isessao = isessao;
        }

        public async Task<ServiceEntity> BuscarPorId(int id)
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
                        servico = JsonSerializer.Deserialize<ServiceEntity>(apiResponse, _options);
                    }
                }
            }

            return servico;
        }
        public async Task<IEnumerable<ServiceEntity>> BuscarPorTexto(string termoPesquisa)
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
                        servicos = JsonSerializer.Deserialize<List<ServiceEntity>>(apiResponse, _options);
                    }
                }
            }

            return servicos;
        }

        public async Task<IEnumerable<ServiceEntity>> BuscarTodos()
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                var tokenJwt = sessaoUser.Token;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.GetAsync(apiEndpoint))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStreamAsync();
                        servicos = await JsonSerializer.DeserializeAsync<List<ServiceEntity>>(apiResponse, _options);
                    }
                }
            }

            return servicos;
        }

        public async Task<ServiceEntity> Cadastrar(ServiceEntity cadastrar)
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
                        servico = JsonSerializer.Deserialize<ServiceEntity>(apiResponse, _options);
                    }
                }
            }

            return servico;
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

        public async Task<object> Editar(int id, ServiceEntity editar)
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
                        servico = JsonSerializer.Deserialize<ServiceEntity>(apiResponse, _options);
                    }
                    else
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var validationErrors = JsonSerializer.Deserialize<Erros>(responseBody);
                        return validationErrors;
                    }
                }
            }

            return servico;
        }
    }
}
