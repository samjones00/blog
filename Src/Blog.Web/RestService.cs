using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Blog.Web.Models;
using Blog.Web.Interfaces;

namespace Blog.Web
{
    public class RestService:IRestService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true };

    public RestService()
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            _client = new HttpClient(handler);

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ApiResponse<T>> GetAsync<T>(string url)
        {
            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var contentStream = await response.Content.ReadAsStreamAsync();

                var responseData = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(contentStream, jsonSerializerOptions);

                var apiResponse = new ApiResponse<T>
                {
                    Data = responseData,
                    Success = true
                };

                return apiResponse;
            }

            return new ApiResponse<T>();
        }

        public async Task<ApiResponse<T>> PostAsync<T>(string url, object data)
        {
            var json = JsonConvert.SerializeObject(data);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var contentStream = await response.Content.ReadAsStreamAsync();

                var responseData = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(contentStream, jsonSerializerOptions);

                var apiResponse = new ApiResponse<T>
                {
                    Data = responseData,
                    Success = true
                };

                return apiResponse;
            }

            return new ApiResponse<T>();
        }
    }
}
