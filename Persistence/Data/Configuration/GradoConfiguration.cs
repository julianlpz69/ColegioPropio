using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class GradoConfiguration : IEntityTypeConfiguration<Grado>
    {
        public void Configure(EntityTypeBuilder<Grado> builder){
    
            builder.ToTable("grado");

            builder.Property(u => u.NombreGrado).HasMaxLength(20);
    
            builder.HasData(
                new Grado {Id= 1, NombreGrado = "Sexto"},
                new Grado {Id= 2, NombreGrado = "Septimo"},
                new Grado {Id= 3, NombreGrado = "Octavo"},
                new Grado {Id= 4, NombreGrado = "Noveno"},
                new Grado {Id= 5, NombreGrado = "Decimo"},
                new Grado {Id= 6, NombreGrado = "Undecimo"}
            );
          
     
        }
    }
}