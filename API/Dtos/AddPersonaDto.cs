using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class AddPersonaDto
    {
        public string Nombres {get; set;}
        public string Apellidos {get; set;}
        public string CorreoElectronico {get; set;}
        public string Documento {get; set;}
        public string Telefono {get; set;}
        public AddUsuarioDto Usuario {get; set;}
        public AddDireccionDto Direccion {get; set;}
        public int IdTipoDocumentoFK {get; set;}

    }
}