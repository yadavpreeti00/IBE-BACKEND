using IBE_BACKEND.DTOs;
using IBE_BACKEND.Exceptions;

namespace IBE_BACKEND.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) 
        { 
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (CustomException ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                context.Response.ContentType = "application/json";
                string jsonErrorResponse = GenerateErrorResponse(ex.Message, context.Request.Path, ex.StatusCode);
                _logger.LogError(jsonErrorResponse);
                await context.Response.WriteAsync(jsonErrorResponse);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                string jsonErrorResponse = GenerateErrorResponse(ex.Message, context.Request.Path, 500);
                _logger.LogError(jsonErrorResponse);
                await context.Response.WriteAsync(jsonErrorResponse);
            }
        }

        private string GenerateErrorResponse(string message, string path, int statusCode)
        {
            ErrorResponseDTO errorResponse = new ErrorResponseDTO(message, path, statusCode, DateTime.Now);
            return System.Text.Json.JsonSerializer.Serialize(errorResponse);
        }
    }
}


