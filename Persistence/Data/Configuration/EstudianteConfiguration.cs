using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class EstudianteConfiguration : IEntityTypeConfiguration<Estudiante>
    {
        public void Configure(EntityTypeBuilder<Estudiante> builder){
    
            builder.ToTable("estudiante");
    
            
            builder.HasOne(p => p.Grupo)
                .WithMany(p => p.Estudiantes)
                .HasForeignKey(p => p.IdGrupoFK);

            
            
    
        }
    }
}