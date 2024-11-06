
/* Docker Commands:

docker build -t nwapi_server -f ./Apps/Assignment.Api/Dockerfile .

docker run --rm -it -p 8080:80 -p 8081:443 -e ASPNETCORE_ENVIRONMENT=Development -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORTS=8081 -e ASPNETCORE_Kestrel__Certificates__Default__Password="ZwarteRidder007" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/app/certificates/aspnetapp.pfx -v %USERPROFILE%\.aspnet\https:/https/ nwapi_server
 */

using Assignment.Core.Helpers;
using Assignment.Repository.Context;
using Assignment.Repository.Repositories;
using Assignment.REST.Mapping;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;

namespace Assignment.Api
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(MappingConfig));

            builder.Services.AddControllers();

            /* Security STEP 1 */
            /*******************/

            var headers = new Dictionary<string, string>() {
    {"X-Frame-Options", "DENY" },
    {"X-Xss-Protection", "1; mode=block"},
    {"X-Content-Type-Options", "nosniff"},
    {"Referrer-Policy", "no-referrer"},
    {"X-Permitted-Cross-Domain-Policies", "none"},
    {"Permissions-Policy", "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()"},
    {"Content-Security-Policy", "default-src 'self'"}
};

            // For full control
            builder.Services.AddAntiforgery(options =>
            {
                options.SuppressXFrameOptionsHeader = true;
            });


            builder.Services.AddRateLimiter(options =>
            {
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
                        factory: partition => new FixedWindowRateLimiterOptions
                        {
                            AutoReplenishment = true,
                            PermitLimit = 60,
                            QueueLimit = 0,
                            Window = TimeSpan.FromMinutes(1)
                        }));

                options.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.StatusCode = 418; // I'm a Teapot ... of 429;
                    if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                    {
                        await context.HttpContext.Response.WriteAsync(
                            $"Too many requests. Please try again after {retryAfter.TotalMinutes} minute(s).", cancellationToken: token);
                    }
                    else
                    {
                        await context.HttpContext.Response.WriteAsync(
                            "Too many requests. Please try again later.", cancellationToken: token);
                    }
                };
            });

            builder.Services.AddHealthChecks();
            builder.Services.AddHealthChecks().AddDbContextCheck<CarwashContext>();

            builder.Services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.DisableDatabaseMigrations();
                setup.SetEvaluationTimeInSeconds(5); // Configures the UI to poll for health checks updates every 5 seconds
                //setup.SetApiMaxActiveRequests(1); //Only one active request will be executed at a time. All the excedent requests will result in 429 (Too many requests)
                setup.MaximumHistoryEntriesPerEndpoint(50); // Set the maximum history entries by endpoint that will be served by the UI api middleware
                setup.SetNotifyUnHealthyOneTimeUntilChange(); // You will only receive one failure notification until the status changes

                setup.AddHealthCheckEndpoint("Healthy", "/working");

            }).AddInMemoryStorage();

            // Dockerfile: HEALTHCHECK CMD curl --fail http://localhost:5000/working || exit

            builder.Services.Configure<IPWhitelistOptions>(builder.Configuration.GetSection("IPWhitelistOptions"));

            builder.Services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                options.ExcludedHosts.Add("example.com");
                options.ExcludedHosts.Add("www.example.com");
            });

            /* END Security STEP 1 */
            /***********************/

            //Inject Identity to this project
            #region DataBase Configuration

            var cs = builder.Configuration.GetConnectionString("DefaultConnectionString");

            //BD Connection string
            builder.Services.AddDbContext<CarwashContext>(options => options.UseSqlServer(cs));

            #endregion

            #region Repository services

//#if EXAMPLE
            builder.Services.AddScoped<ISortHelper<Assignment.Repository.Models.Klanten>, SortHelper<Assignment.Repository.Models.Klanten>>();
            builder.Services.AddScoped<KlantenRepository>();
//#endif

            #endregion

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                /* SECURITY */
                app.UseHsts();
                app.UseHttpsRedirection();
                /* END SECURITY */
            }

            app.UseAuthorization();

            /* Security STEP 2 */
            /*******************/

            app.UseRateLimiter();
            //app.UseHealthChecks("/working"); // vaak: healthz in plaats van working

            app.UseHealthChecks("/working", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseIPWhitelist();

            // url: https://localhost:7144/healthchecks-ui#/healthchecks
            app.UseRouting().UseEndpoints(config =>
            {
                config.MapHealthChecksUI();
            });

            app.UseHttpsRedirection();

            // Middleware to control headers...
            app.Use(async (context, next) =>
            {
                foreach (var keyvalue in headers)
                {
                    if (!context.Response.Headers.ContainsKey(keyvalue.Key))
                    {
                        context.Response.Headers.Add(keyvalue.Key, keyvalue.Value);
                    }
                }
                await next(context);
            });

            /* END Security STEP 2 */
            /***********************/

            app.MapControllers();

            app.Run();
        }
    }
}
