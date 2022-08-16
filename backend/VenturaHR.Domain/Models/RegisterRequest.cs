namespace VenturaHR.Domain.Models;

using System.ComponentModel.DataAnnotations;

public class RegisterRequest
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Senha { get; set; }

    public string Endereco { get; set; }

    [MaxLength(20)]
    public string Telefone { get; set; }
}