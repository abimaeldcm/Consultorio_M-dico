using Consultorio.Web.Models;
using Consultorio.Web.Services.Interfaces;
using System.Text.Json;
using System.Text;

namespace Consultorio.Web.Services
{
    public class MedicoService : ICRUD<Medico>
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/Medico/";
        private readonly JsonSerializerOptions _options;
        private Medico medico;
        private IEnumerable<Medico> medicos;

        public MedicoService(IHttpClientFactory clientFactory)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<Medico> BuscarPorId(int id)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    medico = JsonSerializer.Deserialize<Medico>(apiResponse, _options);
                }
            }

            return medico;
        }

        public async Task<IEnumerable<Medico>> BuscarPorTexto(string termoPesquisa)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.GetAsync(apiEndpoint + "BuscarPorTexto/" + termoPesquisa))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    medicos = JsonSerializer.Deserialize<List<Medico>>(apiResponse, _options);
                }
            }

            return medicos;
        }
        public async Task<IEnumerable<Medico>> BuscarTodos()
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");
            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    medicos = (await JsonSerializer
                                .DeserializeAsync<List<Medico>>(apiResponse, _options));
                }
                else
                {

                }
            }

            return medicos;
        }
        public async Task<Medico> Cadastrar(Medico cadastrar)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var content = new StringContent(JsonSerializer.Serialize(cadastrar), Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    medico = JsonSerializer.Deserialize<Medico>(apiResponse, _options);
                }
            }

            return medico;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.DeleteAsync(apiEndpoint + id))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<object> Editar(int id, Medico editar)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var content = new StringContent(JsonSerializer.Serialize(editar), Encoding.UTF8, "application/json");

            using (var response = await client.PutAsync(apiEndpoint + id, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    medico = JsonSerializer.Deserialize<Medico>(apiResponse, _options);
                }
            }

            return medico;
        }
    }
}
