using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VenturaHR.Domain.Entities.Usuario;
using VenturaHR.Domain.Repositories;
using VenturaHR.Infrastructure.Data.Providers;

namespace VenturaHR.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : SqlRepository<Usuario, int>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
