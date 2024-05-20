using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositorioDeparatamento:Archivo
    {
        public RepositorioDeparatamento(string fileName) : base(fileName)
        {
        }

        public List<Departamento> ConsultarTodos()
        {
            try
            {
                List<Departamento> lista = new List<Departamento>();

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

        public Departamento BuscarId(string id)
        {
            var lista= ConsultarTodos();
            foreach (var item in lista)
            {
                if (item.CodigoDpto==id)
                {
                    return item;
                }

            }
            return null;
        }

        private Departamento Mapear(string datos)
        {
            var linea = datos.Split(';');
            Departamento departamento = new Departamento
            {
                CodigoDpto = linea[0],
                NombreDpto = linea[1]
            };
            return departamento;
        }
    }
}
