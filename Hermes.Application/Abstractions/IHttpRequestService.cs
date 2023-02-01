namespace Hermes.Application.Abstractions
{
    public interface IHttpRequestService
    {
        Task<HttpResponseMessage> PostWithCredentials(object model, string url);
    }
}