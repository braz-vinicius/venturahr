using System.ComponentModel.DataAnnotations;
using VenturaHR.Domain.Entities.Usuario;

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

    [MaxLength(14)]
    public string CPF { get; set; }

    public string CNPJ { get; set; }

    [MaxLength(200)]
    public string RazaoSocial { get; set; }
}