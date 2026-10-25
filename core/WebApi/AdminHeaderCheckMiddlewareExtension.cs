namespace WebApi
{
    public static class AdminHeaderCheckMiddlewareExtension
    {
        public static IApplicationBuilder UseAdminHeaderCheck(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AdminHeaderCheckMiddleware>();
        }
    }
}
