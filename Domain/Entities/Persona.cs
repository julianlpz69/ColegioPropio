using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona : BaseEntity
    {
        public string Nombres {get; set;}
        public string Apellidos {get; set;}
        public string CorreoElectronico {get; set;}
        public string Documento {get; set;}
        public string Telefono {get; set;}
        public DateOnly FechaNacimiento {get; set;}
        public Usuario Usuario {get; set;}
        public Direccion Direccion {get; set;}
        public int IdTipoDocumentoFK {get; set;}
        public TipoDocumento TipoDocumento {get; set;}
        public Profesor Profesor {get; set;}
        public Estudiante Estudiante {get; set;}
        public Padre Padre {get; set;}
        public ICollection<Archivo> Archivos {get; set;}

        
    }
}