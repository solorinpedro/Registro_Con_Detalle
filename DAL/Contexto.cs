using Microsoft.EntityFrameworkCore;
using Registro_Con_Detalle.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Con_Detalle.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permisos> Permisos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\RegistroRolesDetalle.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permisos>().HasData(new Permisos
            {
                PermisoID = 1,
                Nombre = "Pedro Solorin",
                Descripcion = "Area Ciberseguridad",
                VecesAsignado = 0
            });
            modelBuilder.Entity<Permisos>().HasData(new Permisos
            {
                PermisoID = 2,
                Nombre = "Carlos Herrera",
                Descripcion = "Administrador",
                VecesAsignado = 0
            });
        }
    }
}


