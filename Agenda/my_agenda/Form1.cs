using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace my_agenda
{
    public partial class Principal : Form
    {
        private int id;
        Agenda age = new Agenda();
        DataTable dt;
        public Principal()
        {
            InitializeComponent();
            RestablecerControles();
            Consultar();
            dgbAgenda.Columns["id"].Visible = false;
        }
        private void Consultar()
        {
            dgbAgenda.DataSource = dt = age.Consultar();
        }
        private void ObtenerId()
        {
            id = Convert.ToInt32(dgbAgenda.CurrentRow.Cells["id"].Value);
        }
        private void ObtenerDatos()
        {
            ObtenerId();
            txtNombre.Text = dgbAgenda.CurrentRow.Cells["nombre"].Value.ToString();
            txtTelefono.Text = dgbAgenda.CurrentRow.Cells["telefono"].Value.ToString();
        }
        private void RestablecerControles()
        {
            this.txtNombre.Clear();
            this.txtTelefono.Clear();
            this.txtFiltrar.Clear();
            this.btnEliminar.Enabled = false;
            this.btnModificar.Enabled = false;
        }

        private void brnRegistrar_Click(object sender, EventArgs e)
        {
            bool rs = age.Insertar(txtNombre.Text, txtTelefono.Text);
            if (rs)
            {
                MessageBox.Show("Registro insertado correctamente");
                RestablecerControles();
                Consultar();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool rs = age.Actualizar(id,txtNombre.Text, txtTelefono.Text);
            if (rs)
            {
                MessageBox.Show("Resgistro actualizado correctamente");
                Consultar();
            }
            RestablecerControles();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Eliminar",
                "Esta seguro que decea Eliminar este resgistro?",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if(r == DialogResult.OK)
            {
                bool rs = age.Eliminar(id);
                if (rs)
                {
                    MessageBox.Show("Registro Eliminado corecctamente");
                    Consultar();
                }
                RestablecerControles();
            }
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $"Nombre LIKE '%{txtFiltrar.Text}%'";
        }

        private void dgbAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RestablecerControles();
            ObtenerId();
            this.btnEliminar.Enabled = true;
        }

        private void dgbAgenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerId();
            this.btnEliminar.Enabled = false;
            this.btnModificar.Enabled = true;
        }
    }
}
