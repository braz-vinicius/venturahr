using VenturaHR.Domain.Interfaces;

namespace VenturaHR.Domain.Entities.Usuario
{
    public class Empresa : Usuario
    {
        public string CNPJ { get; set; }

        public string RazaoSocial { get; set; }

    }
}
