using WorkatoTestAPI.Contracts;
using WorkatoTestAPI.Domain;

namespace WorkatoTestAPI.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly WorkatoApiOptions _workatoApiOptions;
        public HttpClientService(WorkatoApiOptions workatoApiOptions, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _workatoApiOptions = workatoApiOptions;
        }

        public async Task<string> GetResultAsync(string name, string phone, CancellationToken cancellationToken = default)
        {
            var client = _clientFactory.CreateClient();
            //
            client.DefaultRequestHeaders.Add("Name", name);
            client.DefaultRequestHeaders.Add("Phone", phone);
            client.DefaultRequestHeaders.Add("API-TOKEN", _workatoApiOptions.APITOKEN);
            //
            using var response = await client.GetAsync(_workatoApiOptions.ApiUrl, cancellationToken);
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound) throw new Exception("Recipe not found, Check Recipe is running");
                else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) throw new Exception ("Forbidden, Check IP address is while listed.");
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new Exception("Unauthorised.");
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError) throw new Exception("Internal Server Error.");
                else if (response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity) throw new Exception("Processing Error.");
                //
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync(cancellationToken);
                //
                
            }
        }

        public async Task<string> PostDataAsync<T>( T payload, CancellationToken cancellationToken = default) where T : class, new()
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("API-TOKEN", _workatoApiOptions.APITOKEN);
            using var response = await client.PostAsJsonAsync(_workatoApiOptions.ApiUrl, payload, cancellationToken);
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound) throw new Exception("Recipe not found, Check Recipe is running");
                else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) throw new Exception("Forbidden, Check IP address is while listed.");
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new Exception("Unauthorised.");
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError) throw new Exception("Internal Server Error.");
                else if (response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity) throw new Exception("Processing Error.");
                //
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync(cancellationToken);
                //

            }
        }

        public async Task<string> PutDataAsync<T>(T payload, CancellationToken cancellationToken = default) where T : class, new()
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("API-TOKEN", _workatoApiOptions.APITOKEN);
            using var response = await client.PutAsJsonAsync(_workatoApiOptions.ApiUrl, payload, cancellationToken);
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound) throw new Exception("Recipe not found, Check Recipe is running");
                else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) throw new Exception("Forbidden, Check IP address is while listed.");
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new Exception("Unauthorised.");
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError) throw new Exception("Internal Server Error.");
                else if (response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity) throw new Exception("Processing Error.");
                //
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync(cancellationToken);
                //

            }
        }
    }
}