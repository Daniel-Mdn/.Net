using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        ModoForm modoSeleccionado = ModoForm.Alta;
        public UsuarioDesktop(ModoForm modo):this()
        {
            modoSeleccionado = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            modoSeleccionado = modo;
            UsuarioLogic usr = new UsuarioLogic();
            UsuarioActual= usr.GetOne(ID);
            MapearDeDatos();
        }

        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        public virtual void MapearDeDatos() {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtEmail.Text = this.UsuarioActual.EMail;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;

            if (modoSeleccionado==ModoForm.Alta || modoSeleccionado == ModoForm.Modificacion){
                btnAceptar.Text = "Guardar";
            }
            else
            {
                if (modoSeleccionado == ModoForm.Consulta)
                {
                    txtApellido.ReadOnly = true;
                    txtClave.ReadOnly = true;
                    txtConfirmarClave.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtUsuario.ReadOnly = true;
                    txtNombre.ReadOnly = true;
                    btnAceptar.Text = "Aceptar";
                }
                else
                {
                    txtApellido.ReadOnly = true;
                    txtClave.ReadOnly = true;
                    txtConfirmarClave.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtUsuario.ReadOnly = true;
                    txtNombre.ReadOnly = true;
                    btnAceptar.Text = "Eliminar";
                }
            }
        }
        public virtual void MapearADatos()
        {
            if (modoSeleccionado == ModoForm.Alta)
            {
                Usuario nuevoUsuario = new Usuario();
                this.UsuarioActual = nuevoUsuario;
            }
            if (modoSeleccionado==ModoForm.Alta || modoSeleccionado == ModoForm.Modificacion)
            {
                if (modoSeleccionado == ModoForm.Modificacion)
                {
                    this.UsuarioActual.ID = int.Parse(txtID.Text);
                }
                this.UsuarioActual.Nombre = txtNombre.Text;
                this.UsuarioActual.Apellido = txtApellido.Text;
                this.UsuarioActual.Clave = txtClave.Text;
                this.UsuarioActual.EMail = txtEmail.Text;
                this.UsuarioActual.NombreUsuario = txtUsuario.Text;
                this.UsuarioActual.Habilitado = chkHabilitado.Checked;
            }
            if (modoSeleccionado == ModoForm.Alta)
            {
                UsuarioActual.State = BusinessEntity.States.New;
            }
            else
            {
                UsuarioActual.State = BusinessEntity.States.Modified;
            }

        }
        public virtual void GuardarCambios() {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(this.UsuarioActual);
        }
        public virtual bool Validar()
        {
            string message = "";
            if (txtApellido.Text!="" && txtEmail.Text != "" && txtNombre.Text != "" && txtUsuario.Text != ""&& txtClave.Text != "" && txtConfirmarClave.Text != "")
            {
                if (txtEmail.Text.Contains("@") && txtEmail.Text.Contains(".com"))
                {
                    if (txtClave.Text == txtConfirmarClave.Text && txtClave.Text.Length >= 8)
                    {
                        return true;
                    }
                    else
                    {
                        message = "La contraseña no es valida";
                    }
                }
                else
                {
                    message = "El mail no es valido";
                }
            }
            else
            {
                message = "Todos los campos deben estar completos";
            }
            Notificar("Error", message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon iconos)
        {
            this.Notificar(this.Text, mensaje, botones, iconos);
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (modoSeleccionado == ModoForm.Baja)
            {
                MapearADatos();
                UsuarioLogic ul = new UsuarioLogic();
                ul.Delete(UsuarioActual.ID);
                this.Close();
            }
            if (modoSeleccionado == ModoForm.Consulta)
            {
                MapearADatos();
                this.Close();
            }
            if (modoSeleccionado == ModoForm.Alta || modoSeleccionado == ModoForm.Modificacion)
            {
                if (Validar())
                {
                    GuardarCambios();
                    this.Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
