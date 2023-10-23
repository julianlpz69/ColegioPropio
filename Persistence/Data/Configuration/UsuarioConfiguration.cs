using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder){
    
              builder.ToTable("usuario");

            builder.Property(p => p.ClaveUsuario)
           .HasColumnName("password")
           .HasColumnType("varchar")
           .HasMaxLength(255)
           .IsRequired();

            builder.Property(p => p.CorreoUsuario)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

           builder.HasOne(p => p.Rol)
            .WithMany(p => p.Usuarios)
            .HasForeignKey(p => p.IdRolFK);

            builder.HasOne(p => p.Persona)
                .WithOne(p => p.Usuario)
                 .HasForeignKey<Persona>(d => d.Id);

            
   
        }
    }
}