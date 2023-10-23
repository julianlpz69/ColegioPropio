using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GrupoProfesor
    {
        public int IdGrupoFK {get; set;}
        public Grupo Grupo {get; set;}
        public int IdProfesorFK {get; set;}
        public Profesor Profesor {get; set;}
    }
}