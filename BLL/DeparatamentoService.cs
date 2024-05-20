using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.ComponentModel;

namespace BLL
{
    public class DeparatamentoService
    {
        private string fileName = "dpto.txt";
        RepositorioDeparatamento repositorio;

        private List<Departamento> departamentos;
        public DeparatamentoService()
        {
            repositorio = new RepositorioDeparatamento(fileName);
            RefrescarLista();
        }
        void RefrescarLista()
        {
            departamentos = repositorio.ConsultarTodos();
        }
        public string Guardar(Departamento departamento)
        {
           var msg= repositorio.Guardar(departamento.ToString());
            RefrescarLista();
            return msg;
        }
        public List<Departamento> Consultar()
        {
            return departamentos;
        }

        public Departamento BuscarId(string id)
        {
            foreach (var item in departamentos)
            {
                if (item.CodigoDpto==id)
                {
                    return item;
                }
            }
            return null;
        }

        //public 
    }
}
