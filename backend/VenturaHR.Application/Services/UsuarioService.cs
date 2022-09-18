namespace VenturaHR.Application.Services;

using AutoMapper;
using BCrypt.Net;
using VenturaHR.Application.Helpers;
using VenturaHR.Domain.Entities.Usuario;
using VenturaHR.Domain.Interfaces;
using VenturaHR.Domain.Models;
using VenturaHR.Domain.Repositories;
using VenturaHR.Domain.Services;
using WebApi.Authorization;

public class UsuarioService : IUsuarioService
{
    private IRepository<Usuario, int> userRepository;
    private IJwtUtils jwtUtils;
    private readonly IMapper mapper;

    public UsuarioService(
        IUsuarioRepository userRepository,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        this.userRepository = userRepository;
        this.jwtUtils = jwtUtils;
        this.mapper = mapper;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = userRepository.Get(x => x.Email == model.Email);

        // valida senha
        if (user == null || !BCrypt.Verify(model.Senha, user.Senha))
            throw new AppException("Email e/ou senha incorretos");

        // autenticação realizada com sucesso
        var response = mapper.Map<AuthenticateResponse>(user);
        response.Token = jwtUtils.GenerateToken(user);
        return response;
    }

    public IEnumerable<Usuario> GetAllUsuarios()
    {
        return userRepository.GetAll();
    }

    public Usuario GetUsuarioById(int id)
    {
        var user = userRepository.Get(x => x.Id == id);
        if (user == null) throw new KeyNotFoundException("Usuário não encontrado");
        return user;
    }

    public void RegisterNewUsuario(RegisterRequest model)
    {
        if (userRepository.HasAny(x => x.Email == model.Email))
            throw new AppException("Email '" + model.Email + "' já está sendo utilizado");

        var user = mapper.Map<Usuario>(model);

        user.Senha = BCrypt.HashPassword(model.Senha);

        userRepository.Add(user);
    }

    public void UpdateUsuario(int id, UpdateRequest model)
    {
        var user = GetUsuarioById(id);

        if (model.Email != user.Email && userRepository.HasAny(x => x.Email == model.Email))
            throw new AppException("Email '" + model.Email + "' já está sendo utilizado");

        if (!string.IsNullOrEmpty(model.Senha))
            user.Senha = BCrypt.HashPassword(model.Senha);

        mapper.Map(model, user);
        userRepository.Update(user);
    }

    public void DeleteUsuario(int id)
    {
        var user = GetUsuarioById(id);

        userRepository.Delete(user);
    }

}