namespace VenturaHR.Application.Services;

using AutoMapper;
using BCrypt.Net;
using VenturaHR.Application.Helpers;
using VenturaHR.Domain.Entities.Usuario;
using VenturaHR.Domain.Interfaces;
using VenturaHR.Domain.Models;
using VenturaHR.Domain.Services;
using WebApi.Authorization;

public class UsuarioService : IUsuarioService
{
    private IRepository<Usuario, int> _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public UsuarioService(
        IRepository<Usuario, int> context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _context.Get(x => x.Email == model.Email);

        // valida senha
        if (user == null || !BCrypt.Verify(model.Senha, user.Senha))
            throw new AppException("Email e/ou senha incorretos");

        // autenticação realizada com sucesso
        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = _jwtUtils.GenerateToken(user);
        return response;
    }

    public IEnumerable<Usuario> GetAllUsuarios()
    {
        return _context.GetAll();
    }

    public Usuario GetUsuarioById(int id)
    {
        var user = _context.Get(x => x.Id == id);
        if (user == null) throw new KeyNotFoundException("Usuário não encontrado");
        return user;
    }

    public void RegisterNewUsuario(RegisterRequest model)
    {
        if (_context.HasAny(x => x.Email == model.Email))
            throw new AppException("Email '" + model.Email + "' já está sendo utilizado");

        var user = _mapper.Map<Usuario>(model);

        user.Senha = BCrypt.HashPassword(model.Password);

        _context.Add(user);
    }

    public void UpdateUsuario(int id, UpdateRequest model)
    {
        var user = GetUsuarioById(id);

        if (model.Email != user.Email && _context.HasAny(x => x.Email == model.Email))
            throw new AppException("Email '" + model.Email + "' já está sendo utilizado");

        if (!string.IsNullOrEmpty(model.Senha))
            user.Senha = BCrypt.HashPassword(model.Senha);

        _mapper.Map(model, user);
        _context.Update(user);
    }

    public void DeleteUsuario(int id)
    {
        var user = GetUsuarioById(id);

        _context.Delete(user);
    }

}