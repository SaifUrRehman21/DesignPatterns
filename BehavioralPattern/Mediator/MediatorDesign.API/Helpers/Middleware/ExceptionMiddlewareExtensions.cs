using MediatorDesign.Domain.Model.DTO;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace MediatorDesign.API.Helpers.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandlerFeature != null)
                    {
                        var logger = context.RequestServices.GetService<ILogger<Program>>();
                        logger.LogError($"An error occurred: {exceptionHandlerFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetailDTO
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error. Please try again later."
                        }.ToString());
                    }
                });
            });
        }
    }
}
