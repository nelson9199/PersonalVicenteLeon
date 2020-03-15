using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace PersonalVicenteLeon.Ventanas
{
    public partial class Pais : Form
    {
        private readonly Repository repository = new Repository();

        public Pais()
        {
            InitializeComponent();
        }

        private void dataGridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Pais_Load(object sender, EventArgs e)
        {
            panelUsuarios.Visible = false;
            Mostrar();
        }

        private async void Mostrar()
        {
            try
            {
                var paises = await repository.ObtenerPaises();

                dataGridUsuarios.DataSource = paises;

                dataGridUsuarios.Columns[0].DisplayIndex = 3;
                dataGridUsuarios.Columns[1].HeaderText = "N";
                dataGridUsuarios.Columns[3].Visible = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private pais ObtenerDatosUpdate()
        {
            pais pais = new pais();

            pais.idPais = Convert.ToInt32(lblId.Text);
            pais.Nombre = txtNombre.Text;

            return pais;
        }

        private pais ObtenerDatosInsert()
        {
            pais pais = new pais();

            pais.Nombre = txtNombre.Text;

            return pais;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            panelUsuarios.Visible = true;
            btnGuardarCambios.Enabled = false;
            btnGuardar.Enabled = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelUsuarios.Visible = false;
        }

        private void dataGridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dataGridUsuarios.Columns["eliminar"].Index)
            {
                DialogResult result;

                result = MessageBox.Show("¿Realmente desea eliminar este País?", "Eliminando Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        var IsOk = repository.EliminarPaises(
                            Convert.ToInt32(dataGridUsuarios.SelectedCells[1].Value));

                        MessageBox.Show("Pais Eliminado");
                        Mostrar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void dataGridUsuarios_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void dataGridUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panelUsuarios.Visible = true;
            btnGuardarCambios.Enabled = true;
            btnGuardar.Enabled = false;

            lblId.Text = dataGridUsuarios.SelectedCells[1].Value?.ToString();
            txtNombre.Text = dataGridUsuarios.SelectedCells[2].Value?.ToString();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var pais = ObtenerDatosInsert();

                await repository.InsertrtarPaises(pais);

                MessageBox.Show("Pais Guardado");
                panelUsuarios.Visible = false;
                Mostrar();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private async void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                var pais = ObtenerDatosUpdate();

                await repository.ModificarPaises(pais);

                MessageBox.Show("Pais Modificado");
                panelUsuarios.Visible = false;
                Mostrar();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}