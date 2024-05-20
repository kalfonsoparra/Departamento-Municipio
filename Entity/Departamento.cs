using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Departamento
    {
        public Departamento()
        {

        }
        public Departamento(string codigoDpto, string nombreDpto)
        {
            CodigoDpto = codigoDpto;
            NombreDpto = nombreDpto;
        }

        public string CodigoDpto { get; set; }
        public String NombreDpto { get; set; }

        public override string ToString()
        {
            return $"{CodigoDpto};{NombreDpto}";
        }
    }
}
