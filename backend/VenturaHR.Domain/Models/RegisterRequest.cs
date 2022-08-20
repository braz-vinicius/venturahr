namespace VenturaHR.Domain.Models;

using System.ComponentModel.DataAnnotations;
using VenturaHR.Domain.Entities.Usuario;

public class RegisterRequest
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Senha { get; set; }

    [Required]
    public UsuarioTipo Tipo { get; set; }

    public string Endereco { get; set; }

    [MaxLength(20)]
    public string Telefone { get; set; }
}