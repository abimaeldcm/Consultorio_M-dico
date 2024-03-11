﻿using Consultorio.Web.Models;
using Consultorio.Web.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace Consultorio.Web.Services
{
    public class PacienteService : ICRUD<Paciente>
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/Paciente/";
        private readonly JsonSerializerOptions _options;
        private Paciente paciente;
        private IEnumerable<Paciente> pacientes;

        public PacienteService(IHttpClientFactory clientFactory)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        }

        public async Task<Paciente> BuscarPorId(int id)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    paciente = JsonSerializer.Deserialize<Paciente>(apiResponse, _options);
                }
            }

            return paciente;
        }

        public async Task<IEnumerable<Paciente>> BuscarPorTexto(string termoPesquisa)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.GetAsync(apiEndpoint + "BuscarPorTexto/" + termoPesquisa))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    pacientes = JsonSerializer.Deserialize<List<Paciente>>(apiResponse, _options);
                }
            }

            return pacientes;
        }
        public async Task<IEnumerable<Paciente>> BuscarTodos()
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");
            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    pacientes = (await JsonSerializer
                                .DeserializeAsync<List<Paciente>>(apiResponse, _options));
                }
                else
                {

                }
            }

            return pacientes;
        }
        public async Task<Paciente> Cadastrar(Paciente cadastrar)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var content = new StringContent(JsonSerializer.Serialize(cadastrar), Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    paciente = JsonSerializer.Deserialize<Paciente>(apiResponse, _options);
                }
            }

            return paciente;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.DeleteAsync(apiEndpoint + id))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<object> Editar(int id, Paciente editar)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var content = new StringContent(JsonSerializer.Serialize(editar), Encoding.UTF8, "application/json");

            using (var response = await client.PutAsync(apiEndpoint + id, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    paciente = JsonSerializer.Deserialize<Paciente>(apiResponse, _options);
                }
            }

            return paciente;
        }

    }
}