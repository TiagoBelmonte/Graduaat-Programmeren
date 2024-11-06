/* Docker Commands:

docker build -t nwapi_server -f ./Apps/Assignment.Api/Dockerfile .

docker run --rm -it -p 8080:80 -p 8081:443 -e ASPNETCORE_ENVIRONMENT=Development -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORTS=8081 -e ASPNETCORE_Kestrel__Certificates__Default__Password="ZwarteRidder007" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/app/certificates/aspnetapp.pfx -v %USERPROFILE%\.aspnet\https:/https/ nwapi_server
 */

namespace Assignment.Api
{
    public static class IPWhitelistMiddlewareExtensions
    {
        public static IApplicationBuilder UseIPWhitelist(this
        IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IPWhitelistMiddleware>();
        }
    }
}
