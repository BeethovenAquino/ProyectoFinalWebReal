using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb.UI.Registros
{
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private Usuarios Llenaclase()
        {
            Usuarios usuarios = new Usuarios();
            usuarios.UsuariosId = Convert.ToInt32(UsuarioIDTextbox.Text);
            usuarios.Nombre = NombreArticuloTextbox.Text;
            usuarios.Usuario = UsuarioIDTextbox.Text;
            usuarios.Contraseña = ContraseñaTextBox.Text;
            return usuarios;
        }

        private void Limpiar()
        {
            UsuarioIDTextbox.Text = "0";
            NombreArticuloTextbox.Text = "";
            UsuarioIDTextbox.Text = "";
            ContraseñaTextBox.Text = "";
            ConfirContraTextbox.Text = "";

        }

        private void LlenaCampos(Usuarios usuarios)
        {

            UsuarioIDTextbox.Text = usuarios.UsuariosId.ToString();
            NombreArticuloTextbox.Text = usuarios.Nombre;
            UsuarioTextbox.Text = usuarios.Usuario;
            ContraseñaTextBox.Text = usuarios.Contraseña;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Usuarios usuarios = Llenaclase();
            int id = Convert.ToInt32(UsuarioIDTextbox.Text);



            if (Utilities.Utils.ToInt(UsuarioIDTextbox.Text) == 0)
            {
                paso = UsusariosBLL.Guardar(usuarios);
            }
            else
            {

                var usuario = UsusariosBLL.Buscar(id);

                if (usuario != null)
                {
                    paso = BLL.UsusariosBLL.Editar(usuarios);
                }
                else
                    Utilities.Utils.ShowToastr(this, "No existe", "Fallido", "error");


                Limpiar();

                if (paso)
                {
                    Utilities.Utils.ShowToastr(this, "Guardado", "Fallido", "error");
                }
                else
                {
                    Utilities.Utils.ShowToastr(this, "No se pudo Guardar", "Fallido", "error");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(UsuarioIDTextbox.Text);

            if (UsusariosBLL.Eliminar(id))
            {
                Utilities.Utils.ShowToastr(this, "Eliminado", "Fallido", "error");
                Limpiar();
            }
            else
            { Utilities.Utils.ShowToastr(this, "No se pudo Eliminar", "Fallido", "error"); }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(UsuarioIDTextbox.Text);
            Usuarios usuarios = BLL.UsusariosBLL.Buscar(id);

            if (usuarios != null)
            {
                LlenaCampos(usuarios);

            }
            else
            {
                Utilities.Utils.ShowToastr(this, "No se pudo encontrarse", "Fallido", "error");
            }
        }
    }
}