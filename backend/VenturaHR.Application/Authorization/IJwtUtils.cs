namespace WebApi.Authorization;
using VenturaHR.Domain.Entities.Usuario;

public interface IJwtUtils
{
    public string GenerateToken(Usuario user);
    public int? ValidateToken(string token);
}
