using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tp2.Models
{
    public class Direccion
    {
        public int Id  { get; set; }
        public string Calle { get; set; }
       
        public int EstudianteId { get; set; }
        public Estudiante Estudiante{ get; set; }
        
    }
}