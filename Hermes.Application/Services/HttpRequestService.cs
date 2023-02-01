using Hermes.Application.Abstractions;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace Hermes.Application.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        private HttpClient Http { get; set; }
        public HttpRequestService(HttpClient client)
        {
            Http = client;
        }

        /// <summary>
        /// Post request to the server with the given model
        /// Credentials is needed for the Set-Cookie response header (if it's not set, the cookie will not be saved)
        /// </summary>
        /// <param name="model">DTO or ViewModel</param>
        /// <param name="url">URL to post to</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> PostWithCredentials(object model, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            request.Content = JsonContent.Create(model);
            var response = await Http.SendAsync(request);
            return response;
        }

        /// <summary>
        /// Post request to the server with the given model
        /// </summary>
        /// <param name="model">DTO or ViewModel</param>
        /// <param name="url">URL to post to</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> Post(object model, string url)
        {
            var response = await Http.PostAsJsonAsync(url, model);
            return response;
        }

        /// <summary>
        /// GET request to server
        /// </summary>
        /// <param name="url">URL</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> Get(string url)
        {
            var response = await Http.GetAsync(url);
            return response;
        }

        /// <summary>
        /// PUT request
        /// </summary>
        /// <param name="model">DTO or ViewModel</param>
        /// <param name="url"></param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> Put(object model, string url)
        {
            var response = await Http.PutAsJsonAsync(url, model);
            return response;
        }
    }
}
