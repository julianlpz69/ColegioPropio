using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class GrupoProfesorConfiguration : IEntityTypeConfiguration<GrupoProfesor>
    {
        public void Configure(EntityTypeBuilder<GrupoProfesor> builder){
    
            builder.ToTable("grupo_profesor");
    
            
             

    
        }
    }
}