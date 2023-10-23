using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GrupoMateria
    {
        public int IdGrupoFK {get; set;}
        public Grupo Grupo {get; set;}
        public int IdMateriaFK {get; set;}
        public Materia Materia {get; set;}

    }
}