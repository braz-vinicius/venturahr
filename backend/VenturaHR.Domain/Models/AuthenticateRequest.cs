namespace VenturaHR.Domain.Models;

using System.ComponentModel.DataAnnotations;

public class AuthenticateRequest
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Senha { get; set; }
}