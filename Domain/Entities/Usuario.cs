using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string CorreoUsuario { get; set; }
        public string ClaveUsuario { get; set;}
        public int IdRolFK {get; set;}
        public Rol Rol {get; set;}
        public Persona Persona {get; set;}
        public ICollection<RefreshToken> RefreshTokens { get; set;}
    }
}  