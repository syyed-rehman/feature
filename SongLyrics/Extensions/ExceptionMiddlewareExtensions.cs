using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Repository.Contracts;

namespace SongLyrics.Extensions
{
    /// <summary>    
    /// Exception Middleware Extensions class is a static class which is used for global error handle in web api.
    /// Configure Exception Handler is static method which uses built in Exception Handler middlware to catch exceptions 
    /// and it uses Custom Error Details class to produce the well formated response in json formate 
    /// We do not need try catch block inside our controllers, which makes controller more neat and clean
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {                    
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        { 
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException=>StatusCodes.Status400BadRequest,
                            _=>StatusCodes.Status500InternalServerError
                        };

                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
