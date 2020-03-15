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
using PersonalVicenteLeon.Ventanas;

namespace PersonalVicenteLeon.Ventanas
{
    public partial class Login : Form
    {
        private Repository repository = new Repository();
        private PagPrincipal pagPrincipal = null;

        public Login()
        {
            InitializeComponent();
        }

        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            var isOk = repository.ComprobarLogin(txtUser.Text, txtPassword.Text);

            if (isOk)
            {
                MessageBox.Show("Acceso Exitoso");
                this.Hide();
                pagPrincipal = new PagPrincipal();
                pagPrincipal.Show();
            }
            else
            {
                MessageBox.Show("Usuario y/o Contraseña Incorrectos");
            }
        }
    }
}