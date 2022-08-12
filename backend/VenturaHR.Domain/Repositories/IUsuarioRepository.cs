using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenturaHR.Domain.Entities.Usuario;
using VenturaHR.Domain.Interfaces;

namespace VenturaHR.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario, int>
    {
    }
}
