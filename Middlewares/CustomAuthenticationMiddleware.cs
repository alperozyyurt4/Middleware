using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;

namespace CustomAuthDemo.Middleware
{
    public class CustomAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ValidToken = "valid-token"; 

        public CustomAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api"))
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                // Token doğrulaması yapılacak
                if (token == ValidToken)
                {
                    await _next(context);
                    return;
                }

                // Yanıt: Unauthorized
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            await _next(context);
        }
    }
}
