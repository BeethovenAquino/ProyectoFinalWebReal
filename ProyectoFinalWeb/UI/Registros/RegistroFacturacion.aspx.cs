using BLL;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb.UI.Registros
{
    public partial class RegistroFacturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenaComboArticulo();


        }

        private void LlenaComboArticulo()
        {

            ArticuloDropDownList.Items.Clear();
            ArticuloDropDownList.DataSource = ArticulosBLL.GetList(x => true);
            ArticuloDropDownList.DataValueField = "ArticuloID";
            ArticuloDropDownList.DataTextField = "Nombre";
            ArticuloDropDownList.DataBind();

            ClienteDropDownList.Items.Clear();
            ClienteDropDownList.DataSource = ClienteBLL.GetList(x => true);
            ClienteDropDownList.DataValueField = "ClienteID";
            ClienteDropDownList.DataTextField = "NombreCliente";
            ClienteDropDownList.DataBind();
        }

        private void Limpiar()
        {
            FacturacionIDTextbox.Text = "0";

            CantidadTexbox.Text = "0";
            PrecioVentaTextbox.Text = "0";
            ImporteTextbox.Text = " ";
            MontoTextBox.Text = "0";
            DevueltaTextBox.Text = "0";
            SubtotalTextBox.Text = "0";
            TotalTextBox.Text = "0";
            FacturacionGridView.DataSource = null;
            FacturacionGridView.DataBind();
            LlenaComboArticulo();
            ViewState["Facturacion"] = null;
        }
        private void LlenarCampos(Facturacion facturacion)
        {
            FacturacionDetalle detalle = new FacturacionDetalle();

            FacturacionIDTextbox.Text = facturacion.FacturaID.ToString();

            SubtotalTextBox.Text = facturacion.Subtotal.ToString();
            TotalTextBox.Text = facturacion.Total.ToString();


            //Cargar el detalle al Grid
            ViewState["Facturacion"] = facturacion.Detalle;
            FacturacionGridView.DataSource = ViewState["Facturacion"];
            FacturacionGridView.DataBind();
        }

        private Facturacion LlenaClase()
        {
            Facturacion facturacion = new Facturacion();
            FacturacionDetalle detalle = new FacturacionDetalle();
            facturacion.FacturaID = Utilities.Utils.ToInt(FacturacionIDTextbox.Text.ToString());
            facturacion.ClienteID = Utilities.Utils.ToInt(ClienteDropDownList.SelectedValue);
            facturacion.InversionID = 1;

            facturacion.Subtotal = Utilities.Utils.ToInt(SubtotalTextBox.Text.ToString());
            facturacion.Total = Utilities.Utils.ToInt(TotalTextBox.Text.ToString());
            facturacion.Abono = Utilities.Utils.ToInt(MontoTextBox.Text) - Utilities.Utils.ToInt(DevueltaTextBox.Text);
            facturacion.Monto = Utilities.Utils.ToInt(MontoTextBox.Text);
            facturacion.Devuelta = Utilities.Utils.ToInt(DevueltaTextBox.Text);
            facturacion.Detalle = (List<FacturacionDetalle>)ViewState["Facturacion"];



            return facturacion;

        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            List<FacturacionDetalle> facturacions = new List<FacturacionDetalle>();

            Facturacion facturacion = new Facturacion();



            if (string.IsNullOrEmpty(ImporteTextbox.Text))
            {
                Utilities.Utils.ShowToastr(this, "Importe esta vacio", "Fallido", "error");
            }

            if (FacturacionGridView.Rows.Count != 0)
            {
                facturacion.Detalle = (List<FacturacionDetalle>)ViewState["Facturacion"];
            }

            int cliente = Utilities.Utils.ToInt(ClienteDropDownList.SelectedValue);
            int articulo = Utilities.Utils.ToInt(ArticuloDropDownList.SelectedValue);
            int venta = Utilities.Utils.ToInt(VentaDropDownList.SelectedValue);
            int cantidad = Utilities.Utils.ToInt(CantidadTexbox.Text);
            int precio = Utilities.Utils.ToInt(PrecioVentaTextbox.Text);
            int Importe = Utilities.Utils.ToInt(ImporteTextbox.Text);


            facturacion.Detalle.Add(new FacturacionDetalle(0, Utilities.Utils.ToInt(FacturacionIDTextbox.Text), cliente, articulo, venta.ToString(), cliente.ToString(), articulo.ToString(), cantidad, precio, Importe));

            int subtotal = 0;
            int total = 0;
            foreach (var item in facturacion.Detalle)
            {
                subtotal += item.Importe;

            }

            SubtotalTextBox.Text = subtotal.ToString();

            total += subtotal;

            TotalTextBox.Text = total.ToString();

            ViewState["Facturacion"] = facturacion.Detalle;


            FacturacionGridView.DataSource = ViewState["Facturacion"];
            FacturacionGridView.DataBind();
            MontoTextBox.Text = "";
            if (VentaDropDownList.SelectedIndex == 0)
            {

                FacturacionGridView.DataSource = null;
                FacturacionGridView.DataSource = facturacions;


            }
            else
            if (VentaDropDownList.SelectedIndex == 1)
            {
                MontoTextBox.Text = "0";

            }



            //FacturacionGridView.DataSource = ViewState["Facturacion"];
            //FacturacionGridView.DataBind();



        }




        protected void CantidadTexbox_TextChanged(object sender, EventArgs e)
        {
            Precio();
            int cantidad = Utilities.Utils.ToInt(CantidadTexbox.Text.ToString());
            int precio = Utilities.Utils.ToInt(PrecioVentaTextbox.Text.ToString());
            int importe = Utilities.Utils.ToInt(ImporteTextbox.Text.ToString());

            importe = FacturacionBLL.CalcularImporte(precio, cantidad);

            ImporteTextbox.Text = importe.ToString();
        }

        protected void PrecioVentaTextbox_TextChanged(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt32(CantidadTexbox.Text.ToString());
            int precio = Convert.ToInt32(PrecioVentaTextbox.Text.ToString());
            int importe = Utilities.Utils.ToInt(ImporteTextbox.Text.ToString());

            importe = FacturacionBLL.CalcularImporte(precio, cantidad);
            ImporteTextbox.Text = importe.ToString();

        }

        protected void RemoverButton_Click(object sender, EventArgs e)
        {
            if (FacturacionGridView.Rows.Count > 0
             && FacturacionGridView.SelectedRow != null)
            {

                List<FacturacionDetalle> detalle = (List<FacturacionDetalle>)FacturacionGridView.DataSource;



                detalle.RemoveAt(FacturacionGridView.SelectedRow.RowIndex);


                int subtotal = 0;
                int total = 0;

                foreach (var item in detalle)
                {
                    subtotal += item.Importe;
                }

                SubtotalTextBox.Text = subtotal.ToString();

                total += Convert.ToInt32(SubtotalTextBox.Text);

                TotalTextBox.Text = total.ToString();

                FacturacionGridView.DataSource = null;
                FacturacionGridView.DataSource = detalle;



            }
        }

        protected void MontoTextBox_TextChanged(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(TotalTextBox.Text);
            int monto = Convert.ToInt32(MontoTextBox.Text);
            decimal devuelta = Utilities.Utils.ToInt(DevueltaTextBox.Text);

            if (monto < total)
            {
                Utilities.Utils.ShowToastr(this, "le falta dinero para pagar el articulo", "Fallido", "error");
            }
            else if (monto >= total)
            {
                devuelta = FacturacionBLL.CalcularDevuelta(monto, total);
            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Facturacion facturacion = LlenaClase();
            Contexto contexto = new Contexto();
            Inversionn inversion = new Inversionn();
            Cliente cliente = new Cliente();

            Facturacion Facturacion = new Facturacion();
            bool Paso = false;





            foreach (var item in BLL.InversionBLL.GetList(x => x.InversionID == 1))
            {

                if (item.Monto < Convert.ToDecimal(TotalTextBox.Text))
                {
                    Utilities.Utils.ShowToastr(this, "Mi empresa no contiene esa cantidad de dinero", "Fallido", "error");
                    return;
                }
            }


            if (VentaDropDownList.SelectedIndex == 0)
            {

                inversion.Monto += Facturacion.Total;
            }
            else
            {

                Facturacion.Total += cliente.Total;

            }


            if (Utilities.Utils.ToInt(FacturacionIDTextbox.Text) == 0)
            {
                if (VentaDropDownList.SelectedIndex == 1)
                {
                    MontoTextBox.Enabled = false;
                    DevueltaTextBox.Enabled = false;

                    MontoTextBox.Text = "0";
                    DevueltaTextBox.Text = "0";
                }

                Paso = BLL.FacturacionBLL.Guardar(facturacion);
                Limpiar();
            }
            else
            {
                var M = BLL.FacturacionBLL.Buscar(Convert.ToInt32(FacturacionIDTextbox.Text));

                if (M != null)
                {
                    Paso = BLL.FacturacionBLL.Modificar(facturacion);
                }

            }

            if (Paso)
            {

                Utilities.Utils.ShowToastr(this, "Guardado", "Fallido", "exito");

                Limpiar();
            }
            else
                Utilities.Utils.ShowToastr(this, "No se pudo Guardar", "Fallido", "error");
        }

        protected void VentaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VentaDropDownList.SelectedIndex == 0)
            {
                MontoTextBox.Enabled = true;
                DevueltaTextBox.Enabled = true;
                ClienteDropDownList.Enabled = false;
            }
            else
            {
                ClienteDropDownList.Enabled = true;
                MontoTextBox.Enabled = false;
                DevueltaTextBox.Enabled = false;

                MontoTextBox.Text = "0";
                DevueltaTextBox.Text = "0";

            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {


            int id = Convert.ToInt32(FacturacionIDTextbox.Text);
            if (BLL.FacturacionBLL.Eliminar(id))
            {
                Utilities.Utils.ShowToastr(this, "Eliminado", "exito", "exito");
                Limpiar();
            }

            else
                Utilities.Utils.ShowToastr(this, "No se pudo Eliminar", "Fallido", "error");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            Facturacion prestamo = FacturacionBLL.Buscar(Utilities.Utils.ToInt(FacturacionIDTextbox.Text));

            Limpiar();
            if (prestamo != null)
            {
                LlenarCampos(prestamo);

                Utilities.Utils.ShowToastr(this, "Se ha Encontrado su deposito", "Exito", "Exito");
            }
            else
            {
                Utilities.Utils.ShowToastr(this, "el ID registrado no existe", "Error", "error");
            }

        }

        //protected void ArticuloDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    Response.Write("<script> alert('Hola');</script>");


        //}

        private void Precio()
        {
            int articulo = Utilities.Utils.ToInt(ArticuloDropDownList.SelectedValue);

            List<Articulos> A = ArticulosBLL.GetList(x => x.ArticuloID == articulo);

            foreach (var item in A)

            {
                PrecioVentaTextbox.Text = item.PrecioVenta.ToString();


            }
        }

        protected void ArticuloDropDownList_TextChanged(object sender, EventArgs e)
        {
            Precio();
        }

        protected void ReporteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/Recibo.aspx");
        }

        protected void FacturacionGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("OnClick", "" + ClientScript.GetPostBackClientHyperlink(FacturacionGridView, "Select$" + e.Row.RowIndex.ToString()) + ";");
        }

        protected void FacturacionGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Tienes que darle clic a la fila para que se seleccione
            GridViewRow row = FacturacionGridView.SelectedRow;
            ViewState["IndexDetalle"] = row.RowIndex;
        }

        protected void EliminarButtonDetalle_Click(object sender, EventArgs e)
        {
            List<FacturacionDetalle> detalles = new List<FacturacionDetalle>();
            if (ViewState["IndexDetalle"] != null)
            {
                detalles = (List<FacturacionDetalle>)ViewState["Facturacion"];
                
               detalles.ElementAt((int)ViewState["IndexDetalle"]);


                //Todo: Con esta variable tienes que restarsela al el monto total 

                
                //Aqui estoy elimianndo de el ViewState 
                ((List<FacturacionDetalle>)ViewState["Facturacion"]).RemoveAt((int)ViewState["IndexDetalle"]) ;

                ViewState["Facturacion"] = detalles;


                int subtotal = 0;
                int total = 0;

                foreach (var item in detalles)
                {
                    subtotal += item.Importe;
                }

                SubtotalTextBox.Text = subtotal.ToString();

                total += Convert.ToInt32(SubtotalTextBox.Text);

                TotalTextBox.Text = total.ToString();
                FacturacionGridView.DataSource = ViewState["Facturacion"];
                FacturacionGridView.DataBind();

            }
            else
            {
                Utilities.Utils.ShowToastr(this, "Debe Seleccionar la fila", "Fallido", "error");
            }
        }
    }
}

