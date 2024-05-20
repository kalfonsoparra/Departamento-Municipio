using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositorioMunicipio : Archivo
    {
        public RepositorioMunicipio(string fileName) : base(fileName)
        {
        }
        public List<Municipio> ConsultarTodos()
        {
            try
            {
                List<Municipio> lista = new List<Municipio>();

                StreamReader sr = new StreamReader(fileName);
                while (!sr.EndOfStream)
                {
                    lista.Add(Mapear(sr.ReadLine()));
                }
                sr.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }
        }

        private Municipio Mapear(string datos)
        {
            if (datos=="" || datos==null)
            {
                return null;
            }
            var linea = datos.Split(';');
            Municipio municipio = new Municipio
            {
                CodigoMunicipio = linea[0],
                NombreMunicipio = linea[1],
                Departamento= new RepositorioDeparatamento("dpto.txt").BuscarId(linea[2])
                
            };
            return municipio;
        }
        public void Eliminar ()
        {

        }

        public static void Guardar(List<Municipio> listaFiltrada)
        {
            throw new NotImplementedException();
        }
    }
}
