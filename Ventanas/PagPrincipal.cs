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
    public partial class PagPrincipal : Form
    {
        private Usuarios formUsuarios = null;
        private Pais pais = null;

        public PagPrincipal()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formUsuarios == null)
            {
                formUsuarios = new Usuarios();
                formUsuarios.MdiParent = this;
                formUsuarios.FormClosed += new FormClosedEventHandler(CerrarFormaUsuarios);
                formUsuarios.Show();
                formUsuarios.WindowState = FormWindowState.Normal;
            }
            else
            {
                formUsuarios.Activate();
            }
        }

        private void CerrarFormaUsuarios(object sender, FormClosedEventArgs e)
        {
            formUsuarios = null;
        }

        private void paisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pais == null)
            {
                pais = new Pais();
                pais.MdiParent = this;
                pais.FormClosed += new FormClosedEventHandler(CerrarFormaPais);
                pais.Show();
                pais.WindowState = FormWindowState.Normal;
            }
            else
            {
                pais.Activate();
            }
        }

        private void CerrarFormaPais(object sender, FormClosedEventArgs e)
        {
            pais = null;
        }
    }
}