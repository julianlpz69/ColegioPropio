using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder){
    
            builder.ToTable("matricula");
    
            
            builder.HasOne(p => p.Estudiante)
                .WithMany(p => p.Matriculas)
                .HasForeignKey(p => p.IdEstudianteFK);

        

         
    
        }
    }
}