using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Lab5
{
    public class HttpClient
    {
        private readonly string _baseUrl;
        private readonly System.Net.Http.HttpClient _client;

        public HttpClient(string baseUrl)
        {
            _baseUrl = baseUrl;
            _client = new System.Net.Http.HttpClient();
        }

        public async Task<ResponseModel<FactModel>> GetAsync<T>()
        {
            var response = await _client.GetAsync(_baseUrl);
            return await BuildResponseModel<FactModel>(response);
        }

        public async Task<ResponseModel<FactModel>> PostAsync<T>(object requestObject)
        {
            var response = await _client.PostAsJsonAsync(_baseUrl, requestObject);
            return await BuildResponseModel<FactModel>(response);
        }

        private async Task<ResponseModel<T>> BuildResponseModel<T>(HttpResponseMessage response)
        {
            try
            {
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsAsync<T>();
                return new ResponseModel<T>(result, response.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                return new ResponseModel<T>(default, System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}