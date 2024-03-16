using Consultorio.Web.Models;
using Consultorio.Web.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace Consultorio.Web.Services
{
    public class AtendimentoService : ICRUD<Consult>
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/Atendimento/";
        private readonly JsonSerializerOptions _options;
        private Consult atendimento;
        private IEnumerable<Consult> atendimentos;

        public AtendimentoService(IHttpClientFactory clientFactory)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<Consult> BuscarPorId(int id)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    atendimento = JsonSerializer.Deserialize<Consult>(apiResponse, _options);
                }
            }

            return atendimento;
        }

        public async Task<IEnumerable<Consult>> BuscarPorTexto(string termoPesquisa)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.GetAsync(apiEndpoint + "BuscarPorTexto/" + termoPesquisa))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    atendimentos = JsonSerializer.Deserialize<List<Consult>>(apiResponse, _options);
                }
            }

            return atendimentos;
        }
        public async Task<IEnumerable<Consult>> BuscarTodos()
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");
            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    atendimentos = (await JsonSerializer
                                .DeserializeAsync<List<Consult>>(apiResponse, _options));
                }
                else
                {

                }
            }

            return atendimentos;
        }
        public async Task<Consult> Cadastrar(Consult cadastrar)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var content = new StringContent(JsonSerializer.Serialize(cadastrar), Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    atendimento = JsonSerializer.Deserialize<Consult>(apiResponse, _options);
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

        public async Task<object> Editar(int id, Consult editar)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

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

            return atendimento;
        }
    }
}
