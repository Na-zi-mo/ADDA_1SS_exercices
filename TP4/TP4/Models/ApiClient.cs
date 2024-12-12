using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Models
{
    public class ApiClient
    {
        private string _urlBaseApi;
        private HttpClient _httpClient;

        public ApiClient(string urlBaseApi)
        {
            if (urlBaseApi.EndsWith('/'))
                urlBaseApi = urlBaseApi.Substring(0, urlBaseApi.Length - 1);
            _urlBaseApi = urlBaseApi;

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void SetHttpRequestHeader(string header, string val)
        {
            _httpClient.DefaultRequestHeaders.Remove(header);
            _httpClient.DefaultRequestHeaders.Add(header, val);
        }

        public async Task<string> RequeteGetAsync(string endpoint)
        {
            HttpResponseMessage hrm = await _httpClient.GetAsync(_urlBaseApi + endpoint);

            if (hrm.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new Exception($"{TP4.Properties.traduction.invalid_api_token_message}");

            return await hrm.Content.ReadAsStringAsync();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }

}
