﻿using Consultorio.Web.Models;
using System.Text.Json;
using System.Text;
using Consultorio.Web.Services.Interfaces;

namespace Consultorio.Web.Servicos
{
    public class ServicoServico : ICRUD<ServiceEntity>
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/Servico/";
        private readonly JsonSerializerOptions _options;
        private ServiceEntity servico;
        private IEnumerable<ServiceEntity> servicos;

        public ServicoServico(IHttpClientFactory clientFactory)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<ServiceEntity> BuscarPorId(int id)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    servico = JsonSerializer.Deserialize<ServiceEntity>(apiResponse, _options);
                }
            }

            return servico;
        }

        public async Task<IEnumerable<ServiceEntity>> BuscarPorTexto(string termoPesquisa)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.GetAsync(apiEndpoint + "BuscarPorTexto/" + termoPesquisa))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    servicos = JsonSerializer.Deserialize<List<ServiceEntity>>(apiResponse, _options);
                }
            }

            return servicos;
        }
        public async Task<IEnumerable<ServiceEntity>> BuscarTodos()
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");
            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    servicos = (await JsonSerializer
                                .DeserializeAsync<List<ServiceEntity>>(apiResponse, _options));
                }
                else
                {

                }
            }

            return servicos;
        }
        public async Task<ServiceEntity> Cadastrar(ServiceEntity cadastrar)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var content = new StringContent(JsonSerializer.Serialize(cadastrar), Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    servico = JsonSerializer.Deserialize<ServiceEntity>(apiResponse, _options);
                }
            }

            return servico;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.DeleteAsync(apiEndpoint + id))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<object> Editar(int id, ServiceEntity editar)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var content = new StringContent(JsonSerializer.Serialize(editar), Encoding.UTF8, "application/json");

            using (var response = await client.PutAsync(apiEndpoint + id, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    servico = JsonSerializer.Deserialize<ServiceEntity>(apiResponse, _options);
                }
            }

            return servico;
        }
    }
}
