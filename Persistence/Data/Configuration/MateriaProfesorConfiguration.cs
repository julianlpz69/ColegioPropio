using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class MateriaProfesorConfiguration : IEntityTypeConfiguration<MateriaProfesor>
    {
        public void Configure(EntityTypeBuilder<MateriaProfesor> builder){
    
            builder.ToTable("materia_profesor");
    
          
        

         
    
        }
    }
}