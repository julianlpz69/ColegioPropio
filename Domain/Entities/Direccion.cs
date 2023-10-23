using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Direccion : BaseEntity
    {
        public string DireccionEscrita {get; set;}
        public string Barrio {get; set;}
        public int Estrato {get; set;}
        public int IdCiudadFK {get; set;}
        public Ciudad Ciudad {get; set;}
        public Persona Persona {get; set;}
    }
}