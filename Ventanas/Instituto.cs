using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using AutoMapper;

namespace PersonalVicenteLeon.Ventanas
{
    public partial class Instituto : Form
    {
        private Repository repository = new Repository();

        public Instituto()
        {
            InitializeComponent();

        }


        private void Instituto_Load(object sender, EventArgs e)
        {
            panelUsuarios.Visible = false;

            Mostrar();
        }

        private async void Mostrar()
        {
            try
            {
                var insti = await repository.ObtenerInsti();

                dataGridUsuarios.DataSource = insti;

                dataGridUsuarios.Columns[6].DisplayIndex = 1;

                dataGridUsuarios.Columns[1].Visible = false;
                dataGridUsuarios.Columns[0].Visible = false;
                dataGridUsuarios.Columns[11].Visible = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panelUsuarios.Visible = true;
            txtNombre.Text = "";
            txtCodIess.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtParroquia.Text = "";
            txtProvincia.Text = "";
            txtTelefono.Text = "";
            txtZona.Text = "";
            btnGuardarCambios.Enabled = false;
            btnGuardar.Enabled = true;
        }

        private instituto ObtenerDatosInsert()
        {
            instituto instituto = new instituto();

            instituto.Nombre = txtNombre.Text;
            instituto.Parroquia = txtParroquia.Text;
            try
            {
                instituto.COD_IES = Convert.ToInt32(txtCodIess.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show("Debe ingresar un valor Numerico");
            }

            try
            {
                instituto.Zona = Convert.ToInt32(txtZona.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show("Debe ingresar un valor Numerico");
            }

            instituto.Dirección = txtDireccion.Text;
            instituto.Financiamiento = dropFinaciamiento.Text;
            instituto.Provincia = txtProvincia.Text;
            instituto.Telefono = txtTelefono.Text;
            instituto.Correo = txtCorreo.Text;
            instituto.Canton = txtCanton.Text;

            return instituto;
        }

        private instituto ObtenerDatosUpdate()
        {
            instituto instituto = new instituto();

            instituto.id_instituto = Convert.ToInt32(lblId.Text);
            instituto.Nombre = txtNombre.Text;
            instituto.Parroquia = txtParroquia.Text;
            try
            {
                instituto.COD_IES = Convert.ToInt32(txtCodIess.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show("Debe ingresar un valor Numerico");
            }

            try
            {
                instituto.Zona = Convert.ToInt32(txtZona.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show("Debe ingresar un valor Numerico");
            }

            instituto.Dirección = txtDireccion.Text;
            instituto.Financiamiento = dropFinaciamiento.Text;
            instituto.Provincia = txtProvincia.Text;
            instituto.Telefono = txtTelefono.Text;
            instituto.Correo = txtCorreo.Text;
            instituto.Canton = txtCanton.Text;

            return instituto;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelUsuarios.Visible = false;
        }

        private void dataGridUsuarios_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dropFinaciamiento.Text == "SELECCIONE...")
            {
                errorProvider1.SetError(dropFinaciamiento, "Debe seleccionar un Valor");
                return;
            }

            try
            {
                var insti = ObtenerDatosInsert();

                await repository.InsertarInsti(insti);

                MessageBox.Show("Datos Guardados");
                panelUsuarios.Visible = false;
                Mostrar();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void dataGridUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridUsuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panelUsuarios.Visible = true;
            btnGuardar.Enabled = false;
            btnGuardarCambios.Enabled = true;

            lblId.Text = dataGridUsuarios.SelectedCells[1].Value?.ToString();
            txtCodIess.Text = dataGridUsuarios.SelectedCells[2].Value?.ToString();
            txtZona.Text = dataGridUsuarios.SelectedCells[3].Value?.ToString();
            txtProvincia.Text = dataGridUsuarios.SelectedCells[4].Value?.ToString();
            txtParroquia.Text = dataGridUsuarios.SelectedCells[5].Value?.ToString();
            txtNombre.Text = dataGridUsuarios.SelectedCells[6].Value?.ToString();
            txtDireccion.Text = dataGridUsuarios.SelectedCells[7].Value?.ToString();
            txtTelefono.Text = dataGridUsuarios.SelectedCells[8].Value?.ToString();
            txtCorreo.Text = dataGridUsuarios.SelectedCells[9].Value?.ToString();
            dropFinaciamiento.Text = dataGridUsuarios.SelectedCells[10].Value?.ToString();
            txtCanton.Text = dataGridUsuarios.SelectedCells[11].Value?.ToString();
        }

        private async void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (dropFinaciamiento.Text == "SELECCIONE...")
            {
                errorProvider1.SetError(dropFinaciamiento, "Debe seleccionar un Valor");
                return;
            }

            try
            {
                var insti = ObtenerDatosUpdate();

                await repository.ModificarInsti(insti);

                MessageBox.Show("Datos Actualizados");
                panelUsuarios.Visible = false;
                Mostrar();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void dropFinaciamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(dropFinaciamiento, "");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}