using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Nota : BaseEntity
    {
        public double Valor {get; set;}
        public string Descripcion {get; set;}
        public int IdTipoNotaFK {get; set;}
        public TipoNota TipoNota {get; set;}
    }
}