using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class MateriaConfiguration : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder){
    
            builder.ToTable("materia");
    
            
           
           builder
           .HasMany(p => p.Profesores)
           .WithMany(r => r.Materias)
           .UsingEntity<MateriaProfesor>(

               j => j
               .HasOne(pt => pt.Profesor)
               .WithMany(t => t.MateriaProfesores)
               .HasForeignKey(ut => ut.IdProfesorFK),


               j => j
               .HasOne(et => et.Materia)
               .WithMany(et => et.MateriaProfesores)
               .HasForeignKey(el => el.IdMateriaFK),

               j =>
               {
                   j.ToTable("userRol");
                   j.HasKey(t => new { t.IdMateriaFK, t.IdProfesorFK });

               });

        

        }
    }
}