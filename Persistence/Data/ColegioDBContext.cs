using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class ColegioDBContext : DbContext
    {
        public ColegioDBContext(DbContextOptions<ColegioDBContext> options) : base(options)
        {
    
        }
        public DbSet<Boletin> Boletines { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Corte> Cortes { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<GrupoMateria> GrupoMaterias { get; set; }
        public DbSet<GrupoProfesor> GrupoProfesores { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<MateriaProfesor> MateriaProfesores { get; set; }
        public DbSet<Matricula> Matriculaes { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Padre> Padres { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<TipoNota> TipoNotas { get; set; }
        public DbSet<Archivo> Archivos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    
        }
    }
}  