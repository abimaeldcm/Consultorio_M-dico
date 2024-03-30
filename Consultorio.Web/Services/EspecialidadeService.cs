using System.Text.Json;
using System.Text;
using Consultorio.Web.Models;
using Consultorio.Web.Services.Interfaces;
using System.Net.Http.Headers;
using Consultorio.Web.Helper;

namespace Specialityorio.Web.Services
{
    public class EspecialidadeService : ICRUD<Speciality>
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/Speciality";
        private readonly JsonSerializerOptions _options;
        private Speciality especialidade;
        private IEnumerable<Speciality> especialidades;
        private readonly ISessao _isessao;


        public EspecialidadeService(IHttpClientFactory clientFactory, ISessao isessao)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _isessao = isessao;
        }
        public async Task<Speciality> BuscarPorId(int id)
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
                        especialidade = JsonSerializer.Deserialize<Speciality>(apiResponse, _options);
                    }
                }
            }

            return especialidade;
        }

        public async Task<IEnumerable<Speciality>> BuscarPorTexto(string termoPesquisa)
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
                        especialidades = JsonSerializer.Deserialize<List<Speciality>>(apiResponse, _options);
                    }
                }
            }

            return especialidades;
        }

        public async Task<IEnumerable<Speciality>> BuscarTodos()
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
                        especialidades = (await JsonSerializer.DeserializeAsync<List<Speciality>>(apiResponse, _options));
                    }
                }
            }

            return especialidades;
        }

        public async Task<Speciality> Cadastrar(Speciality cadastrar)
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
                        especialidade = JsonSerializer.Deserialize<Speciality>(apiResponse, _options);
                    }
                }
            }

            return especialidade;
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

        public async Task<object> Editar(int id, Speciality editar)
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
                        especialidade = JsonSerializer.Deserialize<Speciality>(apiResponse, _options);
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
