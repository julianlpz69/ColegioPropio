using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder){
    
            builder.ToTable("ciudad");
    
            builder.Property(e => e.NombreCiudad)
                .HasMaxLength(50);

                
            builder.HasOne(p => p.Departamento)
                .WithMany(p => p.Ciudades)
                .HasForeignKey(p => p.IdDepartamentoFK);
    
        }
    }
}