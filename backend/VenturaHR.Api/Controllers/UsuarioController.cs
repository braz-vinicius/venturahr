namespace VenturaHR.Api.Controllers;

using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VenturaHR.Application.Helpers;
using VenturaHR.Domain.Models;
using VenturaHR.Domain.Services;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private IUsuarioService _userService;

    public UsuarioController(IUsuarioService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest model)
    {
        _userService.RegisterNewUsuario(model);
        return Ok(new { message = "Usuário registrado com sucesso" });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAllUsuarios();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetUsuarioById(id);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _userService.UpdateUsuario(id, model);
        return Ok(new { message = "Usuário atualizado com sucesso" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userService.DeleteUsuario(id);
        return Ok(new { message = "Usuário deletado com sucesso" });
    }
}
