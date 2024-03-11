using Consultorio.Web.Models;
using Consultorio.Web.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace Consultorio.Web.Services
{
    public class AtendimentoService : ICRUD<Atendimento>
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/Atendimento/";
        private readonly JsonSerializerOptions _options;
        private Atendimento atendimento;
        private IEnumerable<Atendimento> atendimentos;

        public AtendimentoService(IHttpClientFactory clientFactory)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<Atendimento> BuscarPorId(int id)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    atendimento = JsonSerializer.Deserialize<Atendimento>(apiResponse, _options);
                }
            }

            return atendimento;
        }

        public async Task<IEnumerable<Atendimento>> BuscarPorTexto(string termoPesquisa)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.GetAsync(apiEndpoint + "BuscarPorTexto/" + termoPesquisa))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    atendimentos = JsonSerializer.Deserialize<List<Atendimento>>(apiResponse, _options);
                }
            }

            return atendimentos;
        }
        public async Task<IEnumerable<Atendimento>> BuscarTodos()
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");
            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    atendimentos = (await JsonSerializer
                                .DeserializeAsync<List<Atendimento>>(apiResponse, _options));
                }
                else
                {

                }
            }

            return atendimentos;
        }
        public async Task<Atendimento> Cadastrar(Atendimento cadastrar)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var content = new StringContent(JsonSerializer.Serialize(cadastrar), Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    atendimento = JsonSerializer.Deserialize<Atendimento>(apiResponse, _options);
                }
            }

            return atendimento;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.DeleteAsync(apiEndpoint + id))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<object> Editar(int id, Atendimento editar)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var content = new StringContent(JsonSerializer.Serialize(editar), Encoding.UTF8, "application/json");

            using (var response = await client.PutAsync(apiEndpoint + id, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    atendimento = JsonSerializer.Deserialize<Atendimento>(apiResponse, _options);
                }
                else 
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var validationErrors = JsonSerializer.Deserialize<Erros>(responseBody);
                    return validationErrors;
                }
            }

            return atendimento;
        }
    }
}
