using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Municipio
    {
        public string CodigoMunicipio { get; set; }
        public string NombreMunicipio { set; get; }
        public Departamento Departamento { get; set; }

        public override string ToString()
        {
            return $"{CodigoMunicipio};{NombreMunicipio};{Departamento.CodigoDpto}";
        }
    }
}
