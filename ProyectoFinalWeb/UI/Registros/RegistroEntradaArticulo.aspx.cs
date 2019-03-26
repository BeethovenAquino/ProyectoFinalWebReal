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
    public partial class RegistroEntradaArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenaComboArticulo();
            EntradaArticuloIDTextbox.Text = "0";
        }
       

        private void LlenaComboArticulo()
        {
            
            ArticuloDropDownList.Items.Clear();
            ArticuloDropDownList.DataSource = ArticulosBLL.GetList(x => true);
            ArticuloDropDownList.DataValueField = "ArticuloID";
            ArticuloDropDownList.DataTextField = "Nombre";
            ArticuloDropDownList.DataBind();
        }

        private void LlenaCampos(EntradaArticulos entrada)
        {
            ArticuloDropDownList.Text = entrada.Articulo;
            PrecioCompraTexbox.Text = entrada.PrecioCompra.ToString();
            PrecioVentaTextbox.Text = entrada.PrecioVenta.ToString();
            GananciaTextbox.Text = entrada.Ganancia.ToString();
            CantArticuloTextbox.Text = entrada.Cantidad.ToString() ;
        }
        
        private EntradaArticulos LlenarClase()
        {

            EntradaArticulos articulo = new EntradaArticulos();

            articulo.EntradaArticulosID = Utilities.Utils.ToInt(EntradaArticuloIDTextbox.Text);
            articulo.Articulo = ArticuloDropDownList.Text;
            articulo.Cantidad = Utilities.Utils.ToInt(CantArticuloTextbox.Text.ToString());
            articulo.ArticuloID = Utilities.Utils.ToInt(ArticuloDropDownList.SelectedValue);
            articulo.PrecioCompra = Utilities.Utils.ToInt(PrecioCompraTexbox.Text.ToString());
            articulo.PrecioVenta = Utilities.Utils.ToInt(PrecioVentaTextbox.Text.ToString());
            articulo.Ganancia = Utilities.Utils.ToInt(GananciaTextbox.Text.ToString());
            articulo.Cantidad = Utilities.Utils.ToInt(CantArticuloTextbox.Text.ToString());
            return articulo;
        }

        private void Limpiar()
        {
           EntradaArticuloIDTextbox.Text = "0";
            CantArticuloTextbox.Text = "0";
            PrecioCompraTexbox.Text = "0";
            PrecioVentaTextbox.Text = "0";
            GananciaTextbox.Text = "0";
            CantArticuloTextbox.Text = "0";
            LlenaComboArticulo(); 
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            EntradaArticulos entradaArticulos = LlenarClase();

            bool paso = false;

            if (Page.IsValid)
            {
                if (entradaArticulos.EntradaArticulosID == 0)
                {
                    paso = EntradaArticulosBLL.Guardar(entradaArticulos);

                }
                else
                {
                    var verificar = EntradaArticulosBLL.Buscar(Utilities.Utils.ToInt(EntradaArticuloIDTextbox.Text));

                    if (verificar != null)
                    {
                        paso = EntradaArticulosBLL.Modificar(entradaArticulos);
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
            int id = Utilities.Utils.ToInt(EntradaArticuloIDTextbox.Text);
            var cuenta = EntradaArticulosBLL.Buscar(id);


            if (cuenta == null)
            {
                //Utilities.Utils.ShowToastr(this, "No se puede Eliminar", "error");
            }

            else
            {
                EntradaArticulosBLL.Eliminar(id);
                //Utilities.Utils.ShowToastr(this, "Cuenta Eliminada", "Exito");
                Limpiar();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            var entradaArticulos= EntradaArticulosBLL.Buscar(
            Utilities.Utils.ToInt(EntradaArticuloIDTextbox.Text));
            if (entradaArticulos != null)
            {
                LlenaCampos(entradaArticulos);
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

        protected void PrecioCompraTexbox_TextChanged(object sender, EventArgs e)
        {
            int precioVenta = Convert.ToInt32(PrecioVentaTextbox.Text.ToString());
            int precioCompra = Convert.ToInt32(PrecioCompraTexbox.Text.ToString());
            int ganancia = Utilities.Utils.ToInt(GananciaTextbox.Text.ToString());

            if (Utilities.Utils.ToInt(PrecioCompraTexbox.Text) != 0 && Utilities.Utils.ToInt(PrecioVentaTextbox.Text)!= 0)
            {
               ganancia  = EntradaArticulosBLL.CalcularGanancia(precioVenta, precioCompra);
            }
        }

        protected void PrecioVentaTextbox_TextChanged(object sender, EventArgs e)
        {
            int precioVenta = Convert.ToInt32(PrecioVentaTextbox.Text.ToString());
            int precioCompra = Convert.ToInt32(PrecioCompraTexbox.Text.ToString());
            int ganancia = Utilities.Utils.ToInt(GananciaTextbox.Text.ToString());

            if (precioVenta < precioCompra)
            {
                //Utilities.Utils.ShowToastr(this, "Va a tener perdida", "error");
            }

            else
            {
                if (Utilities.Utils.ToInt(PrecioCompraTexbox.Text) != 0 && Utilities.Utils.ToInt(PrecioVentaTextbox.Text) != 0)
                {
                    ganancia = BLL.EntradaArticulosBLL.CalcularGanancia(precioVenta, precioCompra);
                }

            }
        }
    }
}