using AccesoDatos;
using AutoMapper;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalVicenteLeon.Ventanas
{
    public partial class Jornadas : Form
    {

        private Repository repository = new Repository();

        public Jornadas()
        {
            InitializeComponent();
            bunifuShadowPanel1.Visible = false;
            Mostrar();

        }

        async void Mostrar()
        {
            var jornadas = await repository.ObtenerJornadas();

            dataGridJornada.DataSource = jornadas;

            dataGridJornada.Columns[0].DisplayIndex = 5;
            dataGridJornada.Columns[1].Visible = false;
            dataGridJornada.Columns[2].HeaderText = "Jornada Laboral";
            dataGridJornada.Columns[3].HeaderText = "Hora Inicio";
            dataGridJornada.Columns[4].HeaderText = "Hora Fin";
            dataGridJornada.Columns[5].Visible = false;


        }

        jornada ObetenrJornadaInsert()
        {
            jornada jornada = new jornada();

            jornada.Hora_fin = TimeSpan.Parse(txtFinJ.Text);
            jornada.Hora_inicio = TimeSpan.Parse(txtInicioJ.Text);
            jornada.Jornada_laboral = txtJornada.Text;

            return jornada;
        }
        jornada ObetenrJornadaUpdate()
        {
            jornada jornada = new jornada();

            jornada.id_jornada = Convert.ToInt32(lblIdJ.Text);
            jornada.Hora_fin = TimeSpan.Parse(txtFinJ.Text);
            jornada.Hora_inicio = TimeSpan.Parse(txtInicioJ.Text);
            jornada.Jornada_laboral = txtJornada.Text;

            return jornada;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel1.Visible = true;
            btnGuardar.Enabled = true;
            btnGuardarCambios.Enabled = false;
            txtFinJ.Text = "";
            txtInicioJ.Text = "";
            txtJornada.Text = "";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel1.Visible = false;
        }

        private void dataGridJornada_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuShadowPanel1.Visible = true;
            btnGuardar.Enabled = false;
            btnGuardarCambios.Enabled = true;

            lblIdJ.Text = dataGridJornada.SelectedCells[1].Value?.ToString();
            txtFinJ.Text = dataGridJornada.SelectedCells[4].Value?.ToString();
            txtInicioJ.Text = dataGridJornada.SelectedCells[3].Value?.ToString();
            txtJornada.Text = dataGridJornada.SelectedCells[2].Value?.ToString();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtFinJ.Text == "")
            {
                errorProvider1.SetError(txtFinJ, "Debe llenar este campo");
                return;
            }
            if (txtInicioJ.Text == "")
            {
                errorProvider1.SetError(txtInicioJ, "Debe llenar este campo");
                return;
            }
            if (txtJornada.Text == "")
            {
                errorProvider1.SetError(txtJornada, "Debe llenar este campo");
                return;
            }

            try
            {
                var jorna = ObetenrJornadaInsert();

                var isOK = await repository.InsertarJornada(jorna);

                if (isOK)
                {
                    MessageBox.Show("Datos guardados");
                    Mostrar();
                    bunifuShadowPanel1.Visible = false;
                }
                else
                {
                    MessageBox.Show("No se pudo guardar los datos");
                    Mostrar();
                }
            }
            catch
            {
                MessageBox.Show("Debe ingresar la hora en el formato correcto: 'HH:MM:SS, ejemplo: 08:30:00'");
            }
        }

        private async void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (txtFinJ.Text == "")
            {
                errorProvider1.SetError(txtFinJ, "Debe llenar este campo");
                return;
            }
            if (txtInicioJ.Text == "")
            {
                errorProvider1.SetError(txtInicioJ, "Debe llenar este campo");
                return;
            }
            if (txtJornada.Text == "")
            {
                errorProvider1.SetError(txtJornada, "Debe llenar este campo");
                return;
            }


            try
            {
                var jorna = ObetenrJornadaUpdate();

                var isOK = await repository.ModificarJornada(jorna);

                if (isOK)
                {
                    MessageBox.Show("Datos Modificados");
                    Mostrar();
                    bunifuShadowPanel1.Visible = false;
                }
                else
                {
                    MessageBox.Show("No se pudo modificar los datos");
                    Mostrar();
                }
            }
            catch
            {
                MessageBox.Show("Debe ingresar la hora en el formato correcto: 'HH:MM:SS, ejemplo: 08:30:00'");
            }
        }

        private async void dataGridJornada_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dataGridJornada.Columns["eliminar"].Index)
            {
                DialogResult result;

                result = MessageBox.Show("¿Realmente desea eliminar este Usuario?", "Eliminando Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        var eliminado = await repository.EliminarJornada(Convert.ToInt32(dataGridJornada.SelectedCells[1].Value));

                        if (eliminado)
                        {
                            MessageBox.Show("Jornada eliminada");
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

        private void dataGridJornada_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
