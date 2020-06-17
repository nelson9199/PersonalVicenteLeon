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
    public partial class Usuarios : Form
    {
        private Repository repository = new Repository();

        public Usuarios()
        {
            InitializeComponent();
        }

        private void Mostrar()
        {
            try
            {
                var usuarios = repository.ObtenerUsuarios();

                dataGridUsuarios.DataSource = usuarios;

                dataGridUsuarios.Columns[0].DisplayIndex = 4;

                dataGridUsuarios.Columns[1].HeaderText = "N";
                dataGridUsuarios.Columns[2].HeaderText = "Nombre";
                dataGridUsuarios.Columns[3].Visible = false;
                dataGridUsuarios.Columns[4].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            panelUsuarios.Visible = false;
            Mostrar();
        }

        private void dataGridUsuarios_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtClave, "");
            errorProvider1.SetError(txtUser, "");
            txtUser.Text = "";
            txtClave.Text = "";
            panelUsuarios.Visible = true;
            btnGuardar.Enabled = true;
            btnGuardarCambios.Enabled = false;
            txtUser.Enabled = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelUsuarios.Visible = false;
        }

        private usuarios ObtenerDatosDelGridInsert()
        {
            usuarios usuarios = new usuarios();

            usuarios.user = txtUser.Text;
            usuarios.clave = txtClave.Text;

            return usuarios;
        }

        private usuarios ObtenerDatosDelGridUpdate()
        {
            usuarios usuarios = new usuarios();

            usuarios.id = Convert.ToInt32(lblId.Text);
            usuarios.user = txtUser.Text;
            usuarios.clave = txtClave.Text;

            return usuarios;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtClave.Text == "")
            {
                errorProvider1.SetError(txtClave, "Debe llenar este campo");
                return;
            }
            if (txtUser.Text == "")
            {
                errorProvider1.SetError(txtUser, "Debe llenar este campo");
                return;
            }

            try
            {
                var usuarioInsert = ObtenerDatosDelGridInsert();

                var isOK = await repository.IngresarUsuario(usuarioInsert);

                if (isOK)
                {
                    MessageBox.Show("Usuario Guardado");
                    panelUsuarios.Visible = false;
                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dataGridUsuarios.Columns["eliminar"].Index)
            {
                DialogResult result;

                result = MessageBox.Show("¿Realmente desea eliminar este Usuario?", "Eliminando Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    if (dataGridUsuarios.SelectedCells[2].Value.ToString() == "admin")
                    {
                        MessageBox.Show("No puede eliminar al Admin");
                        return;
                    }
                    else
                    {
                        try
                        {
                            var IsOk = repository.EliminarUsuarios(
                                Convert.ToInt32(dataGridUsuarios.SelectedCells[1].Value));

                            if (IsOk)
                            {
                                MessageBox.Show("Usuario Eliminado");
                                Mostrar();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void dataGridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panelUsuarios.Visible = true;
            btnGuardar.Enabled = false;
            btnGuardarCambios.Enabled = true;
            txtClave.Text = "";
            errorProvider1.SetError(txtClave, "");

            try
            {
                lblId.Text = dataGridUsuarios.SelectedCells[1].Value?.ToString();

                txtUser.Text = dataGridUsuarios.SelectedCells[2].Value?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay registros que mostrar");
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (txtClave.Text == "")
            {
                errorProvider1.SetError(txtClave, "Debe llenar este campo");
                return;
            }
            if (txtUser.Text == "")
            {
                errorProvider1.SetError(txtUser, "Debe llenar este campo");
                return;
            }

            try
            {
                var usuarioInsert = ObtenerDatosDelGridUpdate();

                var isOK = repository.ModificarUsuarios(usuarioInsert);

                if (isOK)
                {
                    MessageBox.Show("Usuario Modificado");
                    panelUsuarios.Visible = false;
                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}