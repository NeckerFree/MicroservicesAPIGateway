using System.Net;

namespace Gateway.Handlers
{
    public class BlackListHandler: DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var customHeader = request.Headers.FirstOrDefault(c => c.Key == "CustomHeader");

            if (customHeader.Value != null && customHeader.Value.Any())
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var response = new HttpResponseMessage(HttpStatusCode.BadGateway);
            response.ReasonPhrase = "Header is not valid";
            return await Task.FromResult<HttpResponseMessage>(response);

        }
    }
}
