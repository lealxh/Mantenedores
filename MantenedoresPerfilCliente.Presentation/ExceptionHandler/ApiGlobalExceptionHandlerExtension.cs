using MantenedoresPerfilCliente.Application.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace MantenedoresPerfilCliente.Presentation.ExceptionHandler
{
  public static class ApiGlobalExceptionHandlerExtension
  {
    public static IApplicationBuilder UseWebApiExceptionHandler(this IApplicationBuilder app)
    {
      var loggerFactory = app.ApplicationServices.GetService(typeof(ILoggerFactory)) as ILoggerFactory;

      return app.UseExceptionHandler(HandleApiException(loggerFactory));
    }

    public static Action<IApplicationBuilder> HandleApiException(ILoggerFactory loggerFactory)
    {
      int statusCode = 500;
      string message = "An unexpected fault happened. Try again later.";

      return appBuilder =>
      {
        appBuilder.Run(async context =>
        {
          var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

          if (exceptionHandlerFeature != null)
          {
            var logger = loggerFactory.CreateLogger("Serilog Global exception logger");

            statusCode = exceptionHandlerFeature.Error.GetType() == typeof(EntityNotFoundException) ? 404 : 500;
            message = exceptionHandlerFeature.Error.Message;
            logger.LogError(statusCode, exceptionHandlerFeature.Error, message);

          
        
        }
          context.Response.StatusCode = statusCode;
          await context.Response.WriteAsync(message);

        });
      };
    }
  }
}
