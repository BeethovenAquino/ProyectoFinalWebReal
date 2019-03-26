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
    public partial class RegistroArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VigenciaTextbox.Text = 0.ToString();
            PrecioCompraTexbox.Text = 0.ToString();
            PrecioVentaTextbox.Text = 0.ToString();
            GananciaTextbox.Text = 0.ToString();
        }

        private Articulos LlenarClase()
        {

            Articulos articulos = new Articulos();

            articulos.ArticuloID = Utilities.Utils.ToInt(ArticuloIDTextbox.Text);
            articulos.Nombre = NombreArticuloTextbox.Text;
            articulos.Marca = MarcaArticuloTextbox.Text;
            articulos.PrecioCompra = Utilities.Utils.ToInt(PrecioCompraTexbox.Text);
            articulos.PrecioVenta = Utilities.Utils.ToInt(PrecioVentaTextbox.Text);
            articulos.Ganancia = GananciaTextbox.Text;
            articulos.Vigencia =Utilities.Utils.ToInt(VigenciaTextbox.Text);
            return articulos;
        }

        private void LlenaCampos(Articulos articulos)
        {
            NombreArticuloTextbox.Text = articulos.Nombre;
            MarcaArticuloTextbox.Text = articulos.Marca;
            PrecioCompraTexbox.Text = articulos.PrecioCompra.ToString();
            PrecioVentaTextbox.Text = articulos.PrecioVenta.ToString();
            GananciaTextbox.Text = articulos.Ganancia.ToString();
            VigenciaTextbox.Text = articulos.Vigencia.ToString();
        }

        private void Limpiar()
        {
            ArticuloIDTextbox.Text = "";
            NombreArticuloTextbox.Text = "";
            MarcaArticuloTextbox.Text = "";
            PrecioVentaTextbox.Text="0";
            PrecioCompraTexbox.Text = "0";
            GananciaTextbox.Text = "0";
            VigenciaTextbox.Text = "0";


        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
           
            Articulos articulos = LlenarClase();

            bool paso = false;

            if (Page.IsValid)
            {
                if (articulos.ArticuloID == 0)
                {
                    paso = ArticulosBLL.Guardar(articulos);

                }
                else
                {
                    var verificar = ArticulosBLL.Buscar(Utilities.Utils.ToInt(ArticuloIDTextbox.Text));

                    if (verificar != null)
                    {
                        paso = ArticulosBLL.Modificar(articulos);
                    }
                    else
                    {
                        //Utilities.Utils.ShowToastr(this, "Cuenta No Existe", "Fallido", "error");
                        return;
                    }
                }

                if (paso)

                {
                    //Utilities.Utils.ShowToastr(this, "Cuenta Registrada", "Exito", "Exito");
                }

                else

                {
                    //Utilities.Utils.ShowToastr(this, "No pudo Guardarse la cuenta", "ERROR", "error");
                }
                Limpiar();
                return;
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            

            int id = Utilities.Utils.ToInt(ArticuloIDTextbox.Text);
            var cuenta = ArticulosBLL.Buscar(id);


            if (cuenta == null)
            {
                //Utilities.Utils.ShowToastr(this, "No se puede Eliminar", "error");
            }
            
            else
            {
                ArticulosBLL.Eliminar(id);
                //Utilities.Utils.ShowToastr(this, "Cuenta Eliminada", "Exito");
                Limpiar();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            var cuentas = ArticulosBLL.Buscar(
               Utilities.Utils.ToInt(ArticuloIDTextbox.Text));
            if (cuentas != null)
            {
                LlenaCampos(cuentas);
                //Utilities.Utils.ShowToastr(this, "Busqueda exitosa", "Exito");
            }
            else
            {
                Limpiar();
                //Utilities.Utils.ShowToastr(this,
                //    "No se pudo encontrar la cuenta ",
                //    "Error", "error");
            }

        }
    }
}