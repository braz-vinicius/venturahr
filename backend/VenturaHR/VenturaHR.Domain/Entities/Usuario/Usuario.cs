using VenturaHR.Domain.Interfaces;

namespace VenturaHR.Domain.Entities.Usuario
{
    public abstract class Usuario : IEntity<int>
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }


    }
}
