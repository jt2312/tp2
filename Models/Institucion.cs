using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tp2.Models
{
    public class Institucion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        //uno a muchos=Institucion y Estudiante(intitucion tiene varios estudiantes)
        public virtual List<Estudiante> Estudiantes { get; set; }

    }
}