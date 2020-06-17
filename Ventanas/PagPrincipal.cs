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

namespace PersonalVicenteLeon.Ventanas
{
    public partial class PagPrincipal : Form
    {
        private Usuarios formUsuarios = null;
        private Instituto formInstituto = null;
        private Personal personal = null;
        private Jornadas jornadas = null;

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
        }

        private void institutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formInstituto == null)
            {
                formInstituto = new Instituto();
                formInstituto.MdiParent = this;
                formInstituto.FormClosed += new FormClosedEventHandler(CerrarFormaInsti);
                formInstituto.Show();
                formInstituto.WindowState = FormWindowState.Maximized;
            }
            else
            {
                formInstituto.Activate();
            }
        }

        private void CerrarFormaInsti(object sender, FormClosedEventArgs e)
        {
            formInstituto = null;
        }

        private void PagPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void personalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (personal == null)
            {
                personal = new Personal();
                personal.MdiParent = this;
                personal.FormClosed += new FormClosedEventHandler(CerrarFormaPersonal);
                personal.Show();
            }
            else
            {
                formUsuarios.Activate();
            }
        }

        private void CerrarFormaPersonal(object sender, FormClosedEventArgs e)
        {
            personal = null;
        }

        private void jornadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (jornadas == null)
            {
                jornadas = new Jornadas();
                jornadas.MdiParent = this;
                jornadas.FormClosed += new FormClosedEventHandler(CerrarFormaJornada);
                jornadas.Show();
                jornadas.WindowState = FormWindowState.Normal;
            }
            else
            {
                jornadas.Activate();
            }
        }
        private void CerrarFormaJornada(object sender, FormClosedEventArgs e)
        {
            jornadas = null;
        }
    }
}