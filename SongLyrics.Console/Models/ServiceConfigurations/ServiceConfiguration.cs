using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using SongLyrics.Console.Contract;
using SongLyrics.Console.Service;

namespace SongLyrics.Console.Models.ServiceConfigurations
{
    public static class ServiceConfiguration
    {
        public static IHostBuilder HostBuilder()
        {
            return new HostBuilder()
                 .ConfigureServices((httpContext, services) =>
                 {
                     services.AddHttpClient("APIClient", client =>
                     {
                         client.BaseAddress = new Uri("https://localhost:5000/");
                         client.DefaultRequestHeaders.Clear();
                         client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
                     });
                     services.AddScoped<IServiceManager, ServiceManager>();
                 }).UseConsoleLifetime();
        }     
           
    }
}
