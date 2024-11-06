
/* Docker Commands:

docker build -t nwapi_server -f ./Apps/Assignment.Api/Dockerfile .

docker run --rm -it -p 8080:80 -p 8081:443 -e ASPNETCORE_ENVIRONMENT=Development -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORTS=8081 -e ASPNETCORE_Kestrel__Certificates__Default__Password="ZwarteRidder007" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/app/certificates/aspnetapp.pfx -v %USERPROFILE%\.aspnet\https:/https/ nwapi_server
 */

using Microsoft.Extensions.Options;
using System.Net;

namespace Assignment.Api
{
    public class IPWhitelistMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPWhitelistOptions _iPWhitelistOptions;
        private readonly ILogger<IPWhitelistMiddleware> _logger;

        public IPWhitelistMiddleware(RequestDelegate next,
        ILogger<IPWhitelistMiddleware> logger,
            IOptions<IPWhitelistOptions> applicationOptionsAccessor)
        {
            _iPWhitelistOptions = applicationOptionsAccessor.Value;
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method != HttpMethod.Get.Method)
            {
                var ipAddress = context.Connection.RemoteIpAddress;
                List<string> whiteListIPList =
                _iPWhitelistOptions.Whitelist;
                var isIPWhitelisted = whiteListIPList.Where(ip => IPAddress.Parse(ip).Equals(ipAddress)).Any();
                if (!isIPWhitelisted)
                {
                    _logger.LogWarning( "Request from Remote IP address: {RemoteIp} is forbidden.", ipAddress);
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    return;
                }
            }
            await _next.Invoke(context);
        }
    }
}
