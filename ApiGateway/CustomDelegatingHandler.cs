namespace ApiGateway
{
    public class CustomDelegatingHandler : DelegatingHandler
    {
        private readonly ILogger<CustomDelegatingHandler> _logger;

        public CustomDelegatingHandler(ILogger<CustomDelegatingHandler> logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Log the outgoing request
            _logger.LogInformation($"Outgoing Request: {request.Method} {request.RequestUri}");

            // Call the base handler to send the request to the downstream service
            var response = await base.SendAsync(request, cancellationToken);

            // Log the response status from the downstream service
            _logger.LogInformation($"Downstream Response Status: {response.StatusCode}");

            return response;
        }
    }

}
