namespace VenturaHR.Domain.Services;

using System.Collections.Generic;
using VenturaHR.Domain.Entities.Usuario;
using VenturaHR.Domain.Models;

public interface IUsuarioService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<Usuario> GetAllUsuarios();
    Usuario GetUsuarioById(int id);
    void RegisterNewUsuario(RegisterRequest model);
    void UpdateUsuario(int id, UpdateRequest model);
    void DeleteUsuario(int id);
}
