using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MunicipioService
    {
        private string fileName = "municipio.txt";
        RepositorioMunicipio repositorio;

        private List<Municipio> municipios;
        public MunicipioService()
        {
            repositorio = new RepositorioMunicipio(fileName);
            RefrescarLista();
        }
        void RefrescarLista()
        {
            municipios = repositorio.ConsultarTodos();
        }
        public string Guardar(Municipio municipio)
        {
            var msg = repositorio.Guardar(municipio.ToString());
            RefrescarLista();
            return msg;
        }
        public List<Municipio> Consultar()
        {
            return municipios;
        }

        public Municipio BuscarId(string id)
        {
            foreach (var item in municipios)
            {
                if (item.CodigoMunicipio == id)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Municipio> BuscarX(string valor)
        {
            List<Municipio> listaFiltrada = new List<Municipio>();

            foreach (var item in municipios)
            {
                if (item.CodigoMunicipio == valor || item.NombreMunicipio.Contains(valor) || item.Departamento.NombreDpto.Contains(valor))
                {
                    listaFiltrada.Add(item);
                }
            }
            return listaFiltrada;
        }
        public string EliminarRegistro(string idAEliminar)
        {
            List<Municipio> listaFiltrada = new List<Municipio>();
            try
            {
                var municipioAEliminar = listaFiltrada.FirstOrDefault(p => p.CodigoMunicipio == idAEliminar);

                if (municipioAEliminar != null)
                {
                    listaFiltrada.Remove(municipioAEliminar);
                    RepositorioMunicipio.Guardar(listaFiltrada);
                    return "Registro eliminado con éxito.";
                }
                else
                {
                    return "No se encontró un registro con el ID proporcionado.";
                }
            }
            catch (IOException)
            {
                return "Ocurrió un error al intentar eliminar el registro.";
            }
        }


    }
}
