using System.ComponentModel.DataAnnotations;
using VenturaHR.Domain.Interfaces;

namespace VenturaHR.Domain.Entities.Usuario
{
    public class Usuario : IEntity<int>
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Senha { get; set; }

        [MaxLength(200)]
        public string Endereco { get; set; }
        
        [MaxLength(20)]
        public string Telefone { get; set; }

        public UsuarioTipo Tipo { get; set; }
    }
}
