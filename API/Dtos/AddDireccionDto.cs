using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AddDireccionDto
    {
        public string DireccionEscrita {get; set;}
        public string Barrio {get; set;}
        public int Estrato {get; set;}
        public int IdCiudadFK {get; set;}
    }
}