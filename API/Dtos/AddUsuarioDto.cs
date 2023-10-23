using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AddUsuarioDto
    {
        public string CorreoUsuario { get; set; }
        public string ClaveUsuario { get; set;}
        public int IdRolFK {get; set;}
    }
}