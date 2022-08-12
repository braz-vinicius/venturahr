using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenturaHR.Domain.Entities.Resposta;
using VenturaHR.Domain.Entities.Usuario;
using VenturaHR.Domain.Entities.Vaga;

namespace VenturaHR.Infrastructure.Data
{
    public class VenturaDbContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Empresa> Empresas { get; set; }
        
        public DbSet<Candidato> Candidatos { get; set; }

        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<Vaga> Vagas { get; set; }

        public DbSet<VagaCriterio> VagaCriterios { get; set; }

        public DbSet<Resposta> Respostas { get; set; }

        public DbSet<RespostaCriterio> RespostaCriterios { get; set; }

        public VenturaDbContext()
        {
        }

        public VenturaDbContext(DbContextOptions<VenturaDbContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Initial Catalog=VenturaHR;Integrated Security=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                 .HasDiscriminator<UsuarioTipo>("Tipo")
                 .HasValue<Usuario>(UsuarioTipo.Usuario)
                 .HasValue<Administrador>(UsuarioTipo.Administrador)
                 .HasValue<Candidato>(UsuarioTipo.Candidato)
                 .HasValue<Empresa>(UsuarioTipo.Empresa);


        }
    }
}
