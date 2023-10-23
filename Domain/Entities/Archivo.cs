using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Archivo : BaseEntity
    {
        public string Ruta {get; set;}
        public int IdPersonaFK {get; set;}
        public Persona Persona {get; set;}
    }
}