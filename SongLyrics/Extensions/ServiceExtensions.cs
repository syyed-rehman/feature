using LoggerService;
using Repository;
using Repository.Contracts;
using Service;
using Service.Contracts;

namespace SongLyrics.Extensions
{
    /// <summary>
    /// Service Extenions is static class which contains all required services.
    /// We need to configure all required services at one place and registered it in program file.   
    /// </summary>
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection servcies) =>
          servcies.AddCors(options =>
          {
              options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                  .WithMethods("GET")
                  .AllowAnyHeader());
          });

        public static void ConfigureIISIntegration(this IServiceCollection servcies) =>
            servcies.Configure<IISOptions>(options => { 
            
            });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
       
    }
}
