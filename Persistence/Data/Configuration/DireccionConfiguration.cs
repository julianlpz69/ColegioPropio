using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder){
    
            builder.ToTable("direccion");
    
            
            builder.HasOne(p => p.Ciudad)
                .WithMany(p => p.Direcciones)
                .HasForeignKey(p => p.IdCiudadFK);

            builder.HasOne(p => p.Persona)
                .WithOne(p => p.Direccion)
                 .HasForeignKey<Persona>(d => d.Id);

            
 
            
    
        }
    }
}