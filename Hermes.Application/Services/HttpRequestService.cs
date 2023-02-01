﻿using Hermes.Application.Abstractions;
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

        public async Task<HttpResponseMessage> PostWithCredentials(object model, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            request.Content = JsonContent.Create(model);
            var response = await Http.SendAsync(request);
            return response;
        }
    }
}
