using Consultorio.Web.Models;
using Consultorio.Web.Services.Interfaces;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using Consultorio.Web.Helper;

namespace Consultorio.Web.Services
{
    public class MedicoService : ICRUD<Doctor>
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/Doctor/";
        private readonly JsonSerializerOptions _options;
        private Doctor medico;
        private IEnumerable<Doctor> medicos;
        private readonly ISessao _isessao;


        public MedicoService(IHttpClientFactory clientFactory, ISessao isessao)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _isessao = isessao;
        }

        public async Task<Doctor> BuscarPorId(int id)
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
                        medico = JsonSerializer.Deserialize<Doctor>(apiResponse, _options);
                    }
                }
            }

            return medico;
        }

        public async Task<IEnumerable<Doctor>> BuscarPorTexto(string termoPesquisa)
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
                        medicos = JsonSerializer.Deserialize<List<Doctor>>(apiResponse, _options);
                    }
                }
            }

            return medicos;
        }

        public async Task<IEnumerable<Doctor>> BuscarTodos()
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
                        medicos = (await JsonSerializer.DeserializeAsync<IEnumerable<Doctor>>(apiResponse, _options));
                    }
                }
            }

            return medicos;
        }

        public async Task<Doctor> Cadastrar(Doctor cadastrar)
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
                        medico = JsonSerializer.Deserialize<Doctor>(apiResponse, _options);
                    }
                }
            }

            return medico;
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

        public async Task<object> Editar(int id, Doctor editar)
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
                        medico = JsonSerializer.Deserialize<Doctor>(apiResponse, _options);
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

