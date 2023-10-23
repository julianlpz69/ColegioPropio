using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class GrupoMateriaConfiguration : IEntityTypeConfiguration<GrupoMateria>
    {
        public void Configure(EntityTypeBuilder<GrupoMateria> builder){
    
            builder.ToTable("grupo_materia");
    
            

            
    
        }
    }
}