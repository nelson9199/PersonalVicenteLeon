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
using AutoMapper;
using Bunifu.Framework.UI;

namespace PersonalVicenteLeon.Ventanas
{
    public partial class Personal : Form
    {
        private Repository repository = new Repository();

        public Personal()
        {
            InitializeComponent();
        }

        private async void Personal_Load(object sender, EventArgs e)
        {
            panelPersonal.Visible = false;

            try
            {
                var jornadas = await repository.ObtenerJornadas();

                foreach (var VARIABLE in jornadas)
                {
                    dropJornada.Items.Add(VARIABLE.Jornada_laboral);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                var insti = await repository.ObtenerInsti();

                lblIdInsti.Text = insti[0].id_instituto.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Mostrar();
        }

        private async void Mostrar()
        {
            try
            {
                var personal = await repository.ObtenerPersonal();

                dataGridUsuarios.DataSource = personal;

                dataGridUsuarios.Columns[0].DisplayIndex = 42;

                dataGridUsuarios.Columns[1].Visible = false;
                dataGridUsuarios.Columns[2].HeaderText = "Primer Nombre";
                dataGridUsuarios.Columns[3].HeaderText = "Segundo Nombre";
                dataGridUsuarios.Columns[4].HeaderText = "Primer Apellido";
                dataGridUsuarios.Columns[5].HeaderText = "Segundo Apellido";
                dataGridUsuarios.Columns[6].HeaderText = "Tipo Identificacion";
                dataGridUsuarios.Columns[7].HeaderText = "Numero Identificacion";
                dataGridUsuarios.Columns[8].Visible = false;
                dataGridUsuarios.Columns[9].Visible = false;
                dataGridUsuarios.Columns[10].Visible = false;
                dataGridUsuarios.Columns[11].Visible = false;
                dataGridUsuarios.Columns[12].Visible = false;
                dataGridUsuarios.Columns[13].Visible = false;
                dataGridUsuarios.Columns[14].Visible = false;
                dataGridUsuarios.Columns[15].Visible = false;
                dataGridUsuarios.Columns[16].Visible = false;
                dataGridUsuarios.Columns[17].Visible = false;
                dataGridUsuarios.Columns[18].Visible = false;
                dataGridUsuarios.Columns[19].Visible = false;
                dataGridUsuarios.Columns[20].Visible = false;
                dataGridUsuarios.Columns[21].Visible = false;
                dataGridUsuarios.Columns[22].Visible = false;
                dataGridUsuarios.Columns[23].Visible = false;
                dataGridUsuarios.Columns[24].Visible = false;
                dataGridUsuarios.Columns[25].Visible = false;
                dataGridUsuarios.Columns[26].Visible = false;
                dataGridUsuarios.Columns[27].Visible = false;
                dataGridUsuarios.Columns[28].Visible = false;
                dataGridUsuarios.Columns[29].Visible = false;
                dataGridUsuarios.Columns[30].Visible = false;
                dataGridUsuarios.Columns[31].Visible = false;
                dataGridUsuarios.Columns[32].Visible = false;
                dataGridUsuarios.Columns[33].Visible = false;
                dataGridUsuarios.Columns[34].Visible = false;
                dataGridUsuarios.Columns[35].Visible = false;
                dataGridUsuarios.Columns[36].Visible = false;
                dataGridUsuarios.Columns[37].HeaderText = "Nombre del Instituto";
                dataGridUsuarios.Columns[38].Visible = false;
                dataGridUsuarios.Columns[39].Visible = false;
                dataGridUsuarios.Columns[40].Visible = false;
                dataGridUsuarios.Columns[41].Visible = false;
                dataGridUsuarios.Columns[42].Visible = false;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        personal ObternerDatosInsertPersonal()
        {
            personal personal = new personal();

            personal.Canton_residencia = txtCanton.Text;
            personal.Correo_institucional = txtCorreoInsti.Text;
            personal.Correo_personal = txtCorreoConv.Text;
            personal.Direccion_domiciliaria = txtDireccion.Text;
            personal.Discapacidad = dropDisca.Text;
            personal.Edad = Convert.ToInt32(txtEdad.Text ?? "0");
            personal.Encontrado = txtEncontrado.Text;
            personal.Fecha_de_ingreso_al_instituto = dateInsti.Value;
            personal.Fecha_nacimiento = dropFecNa.Value;
            personal.Grupo_ocupacional = Convert.ToInt32(txtGrupOp.Text ?? "0"
            );
            personal.Sector_domicilio = txtSector.Text;
            personal.Numero_celular = txtNumCel.Text;
            personal.Numero_convencional = txtTeleConv.Text;
            personal.Parroquia_residencia = txtParroquiaResi.Text;
            personal.Primer_apellido = txtPrimerAp.Text;
            personal.Numero_identificacion = txtIdentificacion.Text;
            personal.Tipo_identificacion = dropTipoIden.Text;
            personal.Primer_nombre = txtPrimerN.Text;
            personal.Provincia_nacimiento = txtProvNaci.Text;
            personal.Provincia_residencia = txtProvResi.Text;
            personal.Sector_domicilio = txtSector.Text;
            personal.Segundo_apellido = txtSegundoAp.Text;
            personal.Segundo_nombre = txtSegundoN.Text;
            personal.Tipo_discapaciad = txtDiscap.Text;
            personal.Tipo_sexo = dropSexo.Text;
            personal.cargo = txtCargo.Text;
            personal.dominios_info = txtDomInfo.Text;
            personal.paisNacimiento = txtPaisNac.Text;
            personal.id_insti = Convert.ToInt32(lblIdInsti.Text ?? "0");
            personal.tipo_contrato = txtTipoContr.Text;
            personal.titulo_profesion = txtTituloPro.Text;
            personal.disponible_finde = dropDispoFin.Text;
            personal.motivo = txtMotivo.Text;
            personal.parti_bachi = dropSerbA.Text;
            personal.num_veces = txtNumeroVeces.Text;
            personal.id_jornada = Convert.ToInt32(lblJornada.Text);
            personal.nivel_forma = txtNivelFormacion.Text;

            return personal;
        }

        personal ObternerDatosUpdatePersonal()
        {

            personal personal = new personal();

            personal.id_personal = Convert.ToInt32(lblId.Text ?? "0");
            personal.Canton_residencia = txtCanton.Text;
            personal.Correo_institucional = txtCorreoInsti.Text;
            personal.Correo_personal = txtCorreoConv.Text;
            personal.Direccion_domiciliaria = txtDireccion.Text;
            personal.Discapacidad = dropDisca.Text;
            personal.Edad = Convert.ToInt32(txtEdad.Text ?? "0");
            personal.Encontrado = txtEncontrado.Text;
            personal.Fecha_de_ingreso_al_instituto = dateInsti.Value;
            personal.Fecha_nacimiento = dropFecNa.Value;
            personal.Grupo_ocupacional = Convert.ToInt32(txtGrupOp.Text ?? "0"
            );
            personal.Sector_domicilio = txtSector.Text;
            personal.Numero_celular = txtNumCel.Text;
            personal.Numero_convencional = txtTeleConv.Text;
            personal.Parroquia_residencia = txtParroquiaResi.Text;
            personal.Primer_apellido = txtPrimerAp.Text;
            personal.Numero_identificacion = txtIdentificacion.Text;
            personal.Tipo_identificacion = dropTipoIden.Text;
            personal.Primer_nombre = txtPrimerN.Text;
            personal.Provincia_nacimiento = txtProvNaci.Text;
            personal.Provincia_residencia = txtProvResi.Text;
            personal.Sector_domicilio = txtSector.Text;
            personal.Segundo_apellido = txtSegundoAp.Text;
            personal.Segundo_nombre = txtSegundoN.Text;
            personal.Tipo_discapaciad = txtDiscap.Text;
            personal.Tipo_sexo = dropSexo.Text;
            personal.cargo = txtCargo.Text;
            personal.dominios_info = txtDomInfo.Text;
            personal.paisNacimiento = txtPaisNac.Text;
            personal.id_insti = Convert.ToInt32(lblIdInsti.Text ?? "0");
            personal.tipo_contrato = txtTipoContr.Text;
            personal.titulo_profesion = txtTituloPro.Text;
            personal.disponible_finde = dropDispoFin.Text;
            personal.motivo = txtMotivo.Text;
            personal.parti_bachi = dropSerbA.Text;
            personal.num_veces = txtNumeroVeces.Text;
            personal.id_jornada = Convert.ToInt32(lblJornada.Text);
            personal.nivel_forma = txtNivelFormacion.Text;

            return personal;
        }


        private void txtEncontrado_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panelPersonal.Visible = true;
            btnGuardar.Enabled = true;
            btnGuardarCambios.Enabled = false;
            errorProvider1.SetError(dropTipoIden, "");
            errorProvider1.SetError(dropDispoFin, "");
            errorProvider1.SetError(dropDisca, "");
            errorProvider1.SetError(dropSexo, "");
            errorProvider1.SetError(dropSerbA, "");
            errorProvider1.SetError(dropJornada, "");
            errorProvider1.SetError(txtGrupOp, "");
            errorProvider1.SetError(txtEdad, "");
            errorProvider1.SetError(txtIdentificacion, "");
            dropDisca.Text = "SELECCIONE...";
            dropDispoFin.Text = "SELECCIONE...";
            dropJornada.Text = "SELECCIONE...";
            dropSexo.Text = "SELECCIONE...";
            dropTipoIden.Text = "SELECCIONE...";
            txtCanton.Text = "";
            txtCargo.Text = "";
            txtCorreoConv.Text = "";
            txtCorreoInsti.Text = "";
            txtDireccion.Text = "";
            txtDiscap.Text = "";
            txtDomInfo.Text = "";
            txtEdad.Text = "";
            txtEncontrado.Text = "";

            txtGrupOp.Text = "";
            txtIdentificacion.Text = "";

            txtMotivo.Text = "";
            txtNivelFormacion.Text = "";
            txtNumCel.Text = "";
            txtNumeroVeces.Text = "";
            txtPaisNac.Text = "";
            txtParroquiaResi.Text = "";
            txtPrimerAp.Text = "";
            txtPrimerN.Text = "";
            txtProvNaci.Text = "";
            txtProvResi.Text = "";
            txtSegundoAp.Text = "";
            txtSegundoN.Text = "";
            txtTeleConv.Text = "";
            txtTipoContr.Text = "";
            txtTituloPro.Text = "";
            txtSector.Text = "";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelPersonal.Visible = false;
        }

        private void txtCorreoInsti_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCorreoConv_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtProvNaci_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dropDisca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panelPersonal.Visible = true;

            btnGuardar.Enabled = false;
            btnGuardarCambios.Enabled = true;
            errorProvider1.SetError(dropTipoIden, "");
            errorProvider1.SetError(dropDispoFin, "");
            errorProvider1.SetError(dropDisca, "");
            errorProvider1.SetError(dropSexo, "");
            errorProvider1.SetError(dropSerbA, "");
            errorProvider1.SetError(dropJornada, "");
            errorProvider1.SetError(txtGrupOp, "");
            errorProvider1.SetError(txtEdad, "");
            errorProvider1.SetError(txtIdentificacion, "");

            lblId.Text = dataGridUsuarios.SelectedCells[1].Value?.ToString();
            txtPrimerN.Text = dataGridUsuarios.SelectedCells[2].Value?.ToString();
            txtSegundoN.Text = dataGridUsuarios.SelectedCells[3].Value?.ToString();
            txtPrimerAp.Text = dataGridUsuarios.SelectedCells[4].Value?.ToString();
            txtSegundoAp.Text = dataGridUsuarios.SelectedCells[5].Value?.ToString();
            dropTipoIden.Text = dataGridUsuarios.SelectedCells[6].Value?.ToString();
            txtIdentificacion.Text = dataGridUsuarios.SelectedCells[7].Value?.ToString();
            dropSexo.Text = dataGridUsuarios.SelectedCells[8].Value?.ToString();
            txtCorreoInsti.Text = dataGridUsuarios.SelectedCells[9].Value?.ToString();
            txtCorreoConv.Text = dataGridUsuarios.SelectedCells[10].Value?.ToString();
            txtTeleConv.Text = dataGridUsuarios.SelectedCells[11].Value?.ToString();
            txtNumCel.Text = dataGridUsuarios.SelectedCells[12].Value?.ToString();
            dropFecNa.Text = dataGridUsuarios.SelectedCells[13].Value?.ToString();
            txtEdad.Text = dataGridUsuarios.SelectedCells[14].Value?.ToString();
            txtProvNaci.Text = dataGridUsuarios.SelectedCells[15].Value?.ToString();
            txtProvResi.Text = dataGridUsuarios.SelectedCells[16].Value?.ToString();
            txtCanton.Text = dataGridUsuarios.SelectedCells[17].Value?.ToString();
            txtParroquiaResi.Text = dataGridUsuarios.SelectedCells[18].Value?.ToString();
            txtDireccion.Text = dataGridUsuarios.SelectedCells[19].Value?.ToString();
            txtSector.Text = dataGridUsuarios.SelectedCells[20].Value?.ToString();
            dropDisca.Text = dataGridUsuarios.SelectedCells[21].Value?.ToString();
            txtDiscap.Text = dataGridUsuarios.SelectedCells[22].Value?.ToString();
            txtGrupOp.Text = dataGridUsuarios.SelectedCells[23].Value?.ToString();
            dateInsti.Text = dataGridUsuarios.SelectedCells[24].Value?.ToString();
            txtCargo.Text = dataGridUsuarios.SelectedCells[25].Value?.ToString();
            txtNivelFormacion.Text = dataGridUsuarios.SelectedCells[26].Value?.ToString();
            txtDomInfo.Text = dataGridUsuarios.SelectedCells[27].Value?.ToString();
            txtTituloPro.Text = dataGridUsuarios.SelectedCells[28].Value?.ToString();
            txtTipoContr.Text = dataGridUsuarios.SelectedCells[29].Value?.ToString();
            txtPaisNac.Text = dataGridUsuarios.SelectedCells[30].Value?.ToString();
            txtEncontrado.Text = dataGridUsuarios.SelectedCells[31].Value?.ToString();
            dropDispoFin.Text = dataGridUsuarios.SelectedCells[32].Value?.ToString();
            txtMotivo.Text = dataGridUsuarios.SelectedCells[33].Value?.ToString();
            dropJornada.Text = dataGridUsuarios.SelectedCells[34].Value?.ToString();
            dropSerbA.Text = dataGridUsuarios.SelectedCells[38].Value?.ToString();
            txtNumeroVeces.Text = dataGridUsuarios.SelectedCells[39].Value?.ToString();
            lblIdDispo.Text = dataGridUsuarios.SelectedCells[40].Value?.ToString();
            lblIdInsti.Text = dataGridUsuarios.SelectedCells[41].Value?.ToString();
            lblJornada.Text = dataGridUsuarios.SelectedCells[42].Value?.ToString();

        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dropTipoIden.SelectedItem?.ToString() == "SELECCIONE..." || dropTipoIden.Text == "SELECCIONE...")
            {
                errorProvider1.SetError(dropTipoIden, "Debe seleccionar un valor");
                return;
            }
            if (dropDispoFin.SelectedItem?.ToString() == "SELECCIONE..." || dropDispoFin.Text == "SELECCIONE...")
            {
                errorProvider1.SetError(dropDispoFin, "Debe seleccionar un valor");
                return;
            }
            if (dropDisca.SelectedItem?.ToString() == "SELECCIONE..." || dropDisca.Text == "SELECCIONE...")
            {
                errorProvider1.SetError(dropDisca, "Debe seleccionar un valor");
                return;
            }
            if (dropSexo.SelectedItem?.ToString() == "SELECCIONE..." || dropSexo.Text == "SELECCIONE...")
            {
                errorProvider1.SetError(dropSexo, "Debe seleccionar un valor");
                return;
            }
            if (dropSerbA.SelectedItem?.ToString() == "SELECCIONE..." || dropSerbA.Text == "SELECCIONE...")
            {
                errorProvider1.SetError(dropSerbA, "Debe seleccionar un valor");
                return;
            }
            if (dropJornada.SelectedItem?.ToString() == "SELECCIONE..." || dropJornada.Text == "SELECCIONE...")
            {
                errorProvider1.SetError(dropJornada, "Debe seleccionar un valor");
                return;
            }
            if (txtIdentificacion.Text == "")
            {
                errorProvider1.SetError(txtIdentificacion, "Debe llenar este campo");
                return;
            }
            if (txtGrupOp.Text == "")
            {
                errorProvider1.SetError(txtGrupOp, "Debe llenar este campo");
                return;
            }
            if (txtEdad.Text == "")
            {
                errorProvider1.SetError(txtEdad, "Debe llenar este campo");
                return;
            }
            try
            {
                var personalG = ObternerDatosInsertPersonal();

                var isOK = await repository.InsertarPersonal(personalG);

                if (isOK)
                {
                    MessageBox.Show("Datos Guardados");
                    Mostrar();
                    panelPersonal.Visible = false;
                }
                else
                {
                    MessageBox.Show("No se pudo guardar los datos");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private async void dropJornada_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var jornadas = await repository.ObtenerJornadas();

            foreach (var item in jornadas)
            {
                if (dropJornada.SelectedItem?.ToString() == item.Jornada_laboral)
                {
                    lblJornada.Text = item.id_jornada.ToString();
                }
            }
        }

        private void txtGrupOp_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (dropTipoIden.SelectedItem?.ToString() == "SELECCIONE..." || dropTipoIden.Text == "SELECCIONE...")
            {
                errorProvider1.SetError(dropTipoIden, "Debe seleccionar un valor");
                return;
            }
            if (dropDispoFin.SelectedItem?.ToString() == "SELECCIONE..." || dropDispoFin.Text == "SELECCIONE...")
            {
                errorProvider1.SetError(dropDispoFin, "Debe seleccionar un valor");
                return;
            }
            if (dropDisca.SelectedItem?.ToString() == "SELECCIONE..." || dropDisca.Text == "SELECCIONE...")
            {
                errorProvider1.SetError(dropDisca, "Debe seleccionar un valor");
                return;
            }
            if (dropSexo.SelectedItem?.ToString() == "SELECCIONE..." || dropSexo.Text == "SELECCIONE...")
            {
                errorProvider1.SetError(dropSexo, "Debe seleccionar un valor");
                return;
            }
            if (dropSerbA.SelectedItem?.ToString() == "SELECCIONE..." || dropSerbA.Text == "SELECCIONE...")
            {
                errorProvider1.SetError(dropSerbA, "Debe seleccionar un valor");
                return;
            }
            if (dropJornada.SelectedItem?.ToString() == "SELECCIONE..." || dropJornada.Text == "SELECCIONE...")
            {
                errorProvider1.SetError(dropJornada, "Debe seleccionar un valor");
                return;
            }
            if (txtGrupOp.Text == "")
            {
                errorProvider1.SetError(txtGrupOp, "Debe llenar este campo");
                return;
            }
            if (txtEdad.Text == "")
            {
                errorProvider1.SetError(txtEdad, "Debe llenar este campo");
                return;
            }
            if (txtIdentificacion.Text == "")
            {
                errorProvider1.SetError(txtIdentificacion, "Debe llenar este campo");
                return;
            }

            try
            {
                var personalU = ObternerDatosUpdatePersonal();

                var isOK = await repository.ModificarPersonal(personalU);

                if (isOK)
                {
                    MessageBox.Show("Datos Modificados");
                    Mostrar();
                    panelPersonal.Visible = false;
                }
                else
                {
                    MessageBox.Show("No se pudo modificar los datos");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void Numeros(Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox textBox, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtGrupOp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Numeros(txtGrupOp, e);
        }

        private async void dataGridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dataGridUsuarios.Columns["eliminar"].Index)
            {
                DialogResult result;

                result = MessageBox.Show("¿Realmente desea eliminar esta Persona?", "Eliminando Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        var eliminado = await repository.EliminarPersonal(Convert.ToInt32(dataGridUsuarios.SelectedCells[1].Value));

                        if (eliminado)
                        {
                            MessageBox.Show("Persona eliminada");
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
}
