namespace PortalProgramacao.Web.Extensions
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
                throw ex;
            }
        }
        
        private static void HandleException(HttpContext context, Exception ex)
        {

        }
    }
}
