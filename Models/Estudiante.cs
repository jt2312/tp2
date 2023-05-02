using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tp2.Models
{
    public class Estudiante
    {   
        public int Id  { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public int InstitucionId { get; set; }
        public virtual Institucion Institucion { get; set; }
    }
}