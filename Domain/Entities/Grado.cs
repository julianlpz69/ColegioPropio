using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Grado : BaseEntity
    {
        public string NombreGrado {get; set;}
        public ICollection<Grupo> Grupos {get; set;}
    }
}