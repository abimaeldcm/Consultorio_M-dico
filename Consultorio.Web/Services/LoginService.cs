using Consultorio.Web.Models;
using Consultorio.Web.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace Consultorio.Web.Services
{
    public class LoginService : ICRUD<User>, ILoginService
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/Login/";
        private const string apiEndpointLogin = "api/User/Login";
        private readonly JsonSerializerOptions _options;
        private dynamic Login;
        private User LoginAction;
        private IEnumerable<User> LoginActions;

        public LoginService(IHttpClientFactory clientFactory)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<UserLogged> FindLogin(User user)
        {
            user.Role = "Role";
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpointLogin, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    Login = JsonSerializer.Deserialize<UserLogged>(apiResponse, _options);
                }
            }

            return Login;
        }
        public async Task<User> BuscarPorId(int id)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    LoginAction = JsonSerializer.Deserialize<User>(apiResponse, _options);
                }
            }

            return LoginAction;
        }

        public async Task<IEnumerable<User>> BuscarPorTexto(string termoPesquisa)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.GetAsync(apiEndpoint + "BuscarPorTexto/" + termoPesquisa))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    LoginActions = JsonSerializer.Deserialize<List<User>>(apiResponse, _options);
                }
            }

            return LoginActions;
        }
        public async Task<IEnumerable<User>> BuscarTodos()
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");
            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    LoginActions = (await JsonSerializer
                                .DeserializeAsync<List<User>>(apiResponse, _options));
                }
                else
                {

                }
            }

            return LoginActions;
        }
        public async Task<User> Cadastrar(User cadastrar)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var content = new StringContent(JsonSerializer.Serialize(cadastrar), Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    LoginAction = JsonSerializer.Deserialize<User>(apiResponse, _options);
                }
            }

            return LoginAction;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            using (var response = await client.DeleteAsync(apiEndpoint + id))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<object> Editar(int id, User editar)
        {
            var client = _ClientFactory.CreateClient("ConsultorioAPI");

            var content = new StringContent(JsonSerializer.Serialize(editar), Encoding.UTF8, "application/json");

            using (var response = await client.PutAsync(apiEndpoint + id, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    LoginAction = JsonSerializer.Deserialize<User>(apiResponse, _options);
                }
            }

            return LoginAction;
        }


    }
}

