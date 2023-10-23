using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder){
    
            builder.ToTable("grupo");
    
            
            builder.HasOne(p => p.Grado)
                .WithMany(p => p.Grupos)
                .HasForeignKey(p => p.IdGradoFK);

        

            builder
           .HasMany(p => p.Materias)
           .WithMany(r => r.Grupos)
           .UsingEntity<GrupoMateria>(

               j => j
               .HasOne(pt => pt.Materia)
               .WithMany(t => t.GrupoMaterias)
               .HasForeignKey(ut => ut.IdMateriaFK),


               j => j
               .HasOne(et => et.Grupo)
               .WithMany(et => et.GrupoMaterias)
               .HasForeignKey(el => el.IdGrupoFK),

               j =>
               {
                   j.ToTable("userRol");
                   j.HasKey(t => new { t.IdGrupoFK, t.IdMateriaFK });

               });

           




            builder
           .HasMany(p => p.Profesores)
           .WithMany(r => r.Grupos)
           .UsingEntity<GrupoProfesor>(

               j => j
               .HasOne(pt => pt.Profesor)
               .WithMany(t => t.GrupoProfesores)
               .HasForeignKey(ut => ut.IdProfesorFK),


               j => j
               .HasOne(et => et.Grupo)
               .WithMany(et => et.GrupoProfesores)
               .HasForeignKey(el => el.IdGrupoFK),

               j =>
               {
                   j.ToTable("userRol");
                   j.HasKey(t => new { t.IdGrupoFK, t.IdProfesorFK });

               });

     
        }
    }
}