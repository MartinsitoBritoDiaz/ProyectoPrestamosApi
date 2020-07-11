using Microsoft.EntityFrameworkCore;
using ProyectoPrestamosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPrestamosApi.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= C:\Base de datos\Persona.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personas>().HasData(new Personas
            {
                PersonaId = 1,
                Nombre = "Martinsito",
                Telefono = "8098010738",
                Cedula = "40233030523",
                Direccion = "Nagua",
                FechaNacimiento = DateTime.Now
            });
        }
    }
}
