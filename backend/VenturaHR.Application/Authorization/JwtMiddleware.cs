namespace WebApi.Authorization;

using Microsoft.AspNetCore.Http;
using VenturaHR.Domain.Services;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUsuarioService userService, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = jwtUtils.ValidateToken(token);
        if (userId != null)
        {
            context.Items["User"] = userService.GetUsuarioById(userId.Value);
        }

        await _next(context);
    }
}