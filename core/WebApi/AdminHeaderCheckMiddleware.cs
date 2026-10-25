namespace WebApi
{
    public class AdminHeaderCheckMiddleware
    {
        private readonly RequestDelegate _next;
        public AdminHeaderCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var isAdminPath = context.Request.Path.StartsWithSegments("/api/admin");
            var isValidHeader = context.Request.Headers.TryGetValue("X-Order-Admin", out var header) && header == "true";
            if (isAdminPath && !isValidHeader)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Forbidden: Missing or invalid X-Order-Admin header.");
                return;
            }
            await _next(context);
        }
    }
}
