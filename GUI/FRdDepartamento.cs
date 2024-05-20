using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FRdDepartamento : Form
    {
        private BLL.DeparatamentoService deparatamentoService= new BLL.DeparatamentoService();
        public FRdDepartamento()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar(new Departamento(txtCodigo.Text, txtNombre.Text));
            CargarLista();
        }
        void Guardar(Departamento departamento)
        {
          var msg=  deparatamentoService.Guardar(departamento);
            MessageBox.Show(msg);
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarLista();
        }
        void CargarLista()
        {
            //lstDpto.Items.Clear();
            //foreach (var item in deparatamentoService.Consultar())
            //{
            //    lstDpto.Items.Add(item.NombreDpto);
            //}

            lstDpto.DataSource = deparatamentoService.Consultar();
            lstDpto.ValueMember = "CodigoDpto";
            lstDpto.DisplayMember= "NombreDpto";
        }

        private void lstDpto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar(lstDpto.SelectedValue.ToString());
        }
        void Buscar(string id)
        {
            var dpto= deparatamentoService.BuscarId(id);
            VerDpto (dpto);
        }
        void VerDpto(Departamento departamento)
        {
            if (departamento!=null)
            {
                txtCodigo.Text = departamento.CodigoDpto;
                txtNombre.Text = departamento.NombreDpto;
            }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar(txtCodigo.Text);
           
        }
    }
}
