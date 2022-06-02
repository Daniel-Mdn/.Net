﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void toolStripContainer1_Click(object sender, EventArgs e)
        {

        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop ud = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            ud.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop ud = new UsuarioDesktop(id, ApplicationForm.ModoForm.Modificacion);
            ud.ShowDialog();
            this.Listar();

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            
            int id=((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop ud = new UsuarioDesktop(id, ApplicationForm.ModoForm.Baja);
            ud.ShowDialog();
            this.Listar();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int id = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop ud = new UsuarioDesktop(id, ApplicationForm.ModoForm.Consulta);
            ud.ShowDialog();
            this.Listar();
        }
    }
}
