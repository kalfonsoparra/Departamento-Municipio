using BLL;
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
    public partial class FRmMunicipio : Form
    {
        private MunicipioService municipioService= new MunicipioService();
        private DeparatamentoService dptoService = new DeparatamentoService();
        int fila;
        public FRmMunicipio()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Municipio municipio = new Municipio();
            municipio.CodigoMunicipio= txtCodigo.Text;
            municipio.NombreMunicipio= txtNombre.Text;
            //municipio.Departamento = dptoService.BuscarId(
            //    cbDpto.SelectedValue.ToString());
            Guardar(municipio);
            CargarGrilla(municipioService.Consultar());
            CargarMunicipios();
        }
        void Guardar(Municipio municipio)
        {
            var msg = municipioService.Guardar(municipio);
            MessageBox.Show(msg);

        }

        private void FRmMunicipio_Load(object sender, EventArgs e)
        {
            CargarDptos();
            CargarMunicipios();
            CargarGrilla(municipioService.Consultar());
        }

        void CargarGrilla(List<Municipio> lista)
        {
            grillaMunicipios.Rows.Clear();
            
            foreach (var item in lista)
            {
                grillaMunicipios.Rows.Add(item.CodigoMunicipio, item.NombreMunicipio, item.Departamento.NombreDpto);
            }

        }
        void CargarMunicipios()
        {
            lstMunicipio.DataSource = municipioService.Consultar();
            lstMunicipio.ValueMember = "CodigoMunicipio";
            lstMunicipio.DisplayMember = "NombreMunicipio";
        }
        void CargarDptos()
        {
            cbDpto.DataSource = dptoService.Consultar();
            cbDpto.ValueMember = "CodigoDpto";
            cbDpto.DisplayMember= "NombreDpto";
        }

        private void grillaMunicipios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           fila= e.RowIndex;
            string codigo= grillaMunicipios.Rows[fila].Cells[0].Value.ToString();
            Buscar(codigo);
            //tabPage1.Select();
            tabControl1.SelectTab(0);
        }
        void Buscar(string id)
        {
            var municipio = municipioService.BuscarId(id);
            Ver(municipio);
        }
        void Ver(Municipio municipio)
        {
            if (municipio != null)
            {
                txtCodigo.Text = municipio.CodigoMunicipio;
                txtNombre.Text = municipio.NombreMunicipio;
                cbDpto.Text = municipio.Departamento.NombreDpto;
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
        }

        private void lstMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text=lstMunicipio.SelectedIndex.ToString();

            //Ver(municipioService.Consultar()[lstMunicipio.SelectedIndex]);
          
            string codigo = lstMunicipio.SelectedValue.ToString();
            Buscar(codigo);
            ////tabPage1.Select();
            //tabControl1.SelectTab(0);
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            var filtro= txtFiltro.Text;
            var lista =municipioService.BuscarX(filtro);
            CargarGrilla(lista);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void verDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string codigo = grillaMunicipios.Rows[fila].Cells[0].Value.ToString();
            Buscar(codigo);
            //tabPage1.Select();
            tabControl1.SelectTab(0);
        }

        private void grillaMunicipios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila=e.RowIndex;
        }

        private void cbDpto_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
