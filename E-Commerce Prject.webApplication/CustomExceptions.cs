using ServiceImplementationLayer.Exceptions;
using SharedDataLayer.ErrorModel;

namespace E_Commerce_Prject.webApplication
{
    public class CustomExceptions
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate next;

        public CustomExceptions(RequestDelegate Next, ILogger<CustomExceptions> logger)
        {
            _logger = logger;
            next = Next;
        }
        public async Task InvokeAsync(HttpContext httpcontext)
        {
            try
            {
                await next.Invoke(httpcontext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error custom Exception");

                var statusCode = ex switch
                {
                    NotFoundException=>StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };
                var Response = new ErrorToReturn
                {
                    StatusCode = statusCode,
                    Message = ex.Message
                };
                await httpcontext.Response.WriteAsJsonAsync(Response);
            }
        }
    }
}
