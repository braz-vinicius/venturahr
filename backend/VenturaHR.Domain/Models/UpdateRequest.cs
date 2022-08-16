using System.ComponentModel.DataAnnotations;

namespace VenturaHR.Domain.Models;

public class UpdateRequest
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public string Email { get; set; }

    public string Senha { get; set; }

    public string Endereco { get; set; }

    [MaxLength(20)]
    public string Telefone { get; set; }
}