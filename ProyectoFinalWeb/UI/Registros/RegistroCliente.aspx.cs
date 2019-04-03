using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb.UI.Registros
{
    public partial class RegistroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeudaTextbox.Text = 0.ToString();
        }

        private Cliente LlenarClase()
        {

            Cliente cliente = new Cliente();

            cliente.ClienteID = Utilities.Utils.ToInt(ClienteIDTextbox.Text);
            cliente.NombreCliente = NombreClienteTextbox.Text;
            cliente.Cedula = CedulaTextbox.Text;
            cliente.Direccion = (DireccionTextbox.Text);
            cliente.Telefono = (TelefonoTextbox.Text);
            cliente.Total = Utilities.Utils.ToInt(DeudaTextbox.Text.ToString());
            return cliente;
        }

        private void Limpiar()
        {
            ClienteIDTextbox.Text = "";
            NombreClienteTextbox.Text = "";
            CedulaTextbox.Text = "";
            DireccionTextbox.Text = "";
            TelefonoTextbox.Text = "";
            DeudaTextbox.Text = "";
            
        }

        private void LlenaCampos(Cliente cliente)
        {
            NombreClienteTextbox.Text = cliente.NombreCliente;
            CedulaTextbox.Text = cliente.Cedula;
            DireccionTextbox.Text = cliente.Direccion;
            TelefonoTextbox.Text = cliente.Telefono;
            DeudaTextbox.Text = cliente.Total.ToString();
        }


        
        public bool VerificarCedula(string cedula)
        {
            Expression<Func<Cliente, bool>> filtro = x => true;
            bool paso = false;
            filtro = x => x.Cedula.Contains(cedula);

            if (ClienteBLL.GetList(filtro).Count() != 0)
            {

              Utilities.Utils.ShowToastr(this, "Ya Existe un Cliente con este Numero de Cedula", "Fallo", "error");

                paso = true;
            }

            return paso;

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Cliente cliente = LlenarClase();
            
            bool paso = false;

            
            

            if (Page.IsValid)
            {
                

                if (cliente.ClienteID == 0)
                {
                    

                    if (VerificarCedula(cliente.Cedula) == true)
                    {
                        return;
                    }
                    else { paso = ClienteBLL.Guardar(cliente); }
                        
                 
                    
                    
                    
                }
                else
                {
                    var verificar = ClienteBLL.Buscar(Utilities.Utils.ToInt(ClienteIDTextbox.Text));

                    if (verificar != null )
                    {
                        paso = ClienteBLL.Modificar(cliente);


                    }
                    else
                    {
                        Utilities.Utils.ShowToastr(this, "Cliente No Existe", "Fallido", "error");
                        return;
                    }
                }

                if (paso)

                {
                    Utilities.Utils.ShowToastr(this, "Cliente Registrada", "Exito", "Exito");
                }

                else

                {
                    Utilities.Utils.ShowToastr(this, "No pudo Guardarse la Cliente", "ERROR", "error");
                }
                Limpiar();
                return;
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Utilities.Utils.ToInt(ClienteIDTextbox.Text);
            var cuenta = ClienteBLL.Buscar(id);


            if (cuenta == null)
            {
                Utilities.Utils.ShowToastr(this, "No se puede Eliminar", "error");
            }

            else
            {
                ClienteBLL.Eliminar(id);
                Utilities.Utils.ShowToastr(this, "Cliente Eliminada", "Exito");
                Limpiar();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            var cuentas = ClienteBLL.Buscar(
              Utilities.Utils.ToInt(ClienteIDTextbox.Text));
            if (cuentas != null)
            {
                LlenaCampos(cuentas);
                Utilities.Utils.ShowToastr(this, "Busqueda exitosa", "Exito");
            }
            else
            {
                Limpiar();
                Utilities.Utils.ShowToastr(this, "No se pudo encontrar la Cliente ", "Error", "error");
            }

        }
    }
}