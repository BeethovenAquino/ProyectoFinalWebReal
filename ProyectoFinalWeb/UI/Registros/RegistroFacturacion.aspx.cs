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
            TotalTextBox.Text = 0.ToString();
            SubtotalTextBox.Text = 0.ToString();
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
            FacturacionGridView.DataSource = facturacion.Detalle;
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
            List<FacturacionDetalle> detalle = new List<FacturacionDetalle>();



            if (FacturacionGridView.DataSource != null)
            {
                detalle = (List<FacturacionDetalle>)FacturacionGridView.DataSource;
            }


            if (string.IsNullOrEmpty(ImporteTextbox.Text))
            {
                Utilities.Utils.ShowToastr(this, "Importe esta vacio", "Fallido", "error");
            }
            else
            {
                detalle.Add(
                    new FacturacionDetalle(iD: 0,
                    facturaID: (int)Convert.ToInt32(FacturacionIDTextbox.Text),
                    venta: (string)VentaDropDownList.Text,
                    clienteID: (int)ClienteDropDownList.SelectedIndex,
                       cliente: (string)ClienteDropDownList.Text,
                            articuloID: (int)ArticuloDropDownList.SelectedIndex,
                            articulo: (string)ArticuloDropDownList.Text,

                        cantidad: Convert.ToInt32(CantidadTexbox.Text),
                        precio: Convert.ToInt32(PrecioVentaTextbox.Text),
                        importe: Convert.ToInt32(ImporteTextbox.Text)
                    ));


                FacturacionGridView.DataSource = null;
                FacturacionGridView.DataSource = detalle;

                //this.ArticulosStock.Find(art => art.ArticuloID ==
                //    (int)ArticulocomboBox.SelectedValue).Vigencia -= Convert.ToInt32(CantidadnumericUpDown.Value);

                //ActualizarCombobox();

                if (VentaDropDownList.SelectedIndex == 0)
                {

                    FacturacionGridView.DataSource = null;
                    FacturacionGridView.DataSource = detalle;


                }
                else
                if (VentaDropDownList.SelectedIndex == 1)
                {

                }

                int subtotal = 0;
                int total = 0;
                foreach (var item in detalle)
                {
                    subtotal += item.Importe;

                }

                SubtotalTextBox.Text = subtotal.ToString();

                total += subtotal;

                TotalTextBox.Text = total.ToString();
            }
        }

        protected void CantidadTexbox_TextChanged(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt32(CantidadTexbox.Text.ToString());
            int precio = Convert.ToInt32(PrecioVentaTextbox.Text.ToString());
            int importe = Utilities.Utils.ToInt(ImporteTextbox.Text.ToString());

            importe = FacturacionBLL.CalcularImporte(precio, cantidad);
        }

        protected void PrecioVentaTextbox_TextChanged(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt32(CantidadTexbox.Text.ToString());
            int precio = Convert.ToInt32(PrecioVentaTextbox.Text.ToString());
            int importe = Utilities.Utils.ToInt(ImporteTextbox.Text.ToString());

            importe = FacturacionBLL.CalcularImporte(precio, cantidad);
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
            Inversion inversion = new Inversion();
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


            if (FacturacionGridView.SelectedIndex == 0)
            {
                if (VentaDropDownList.SelectedIndex == 1)
                {
                    MontoTextBox.Enabled = false;
                    DevueltaTextBox.Enabled = false;
                }
                Paso = BLL.FacturacionBLL.Guardar(facturacion);

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
            int id = Convert.ToInt32(FacturacionIDTextbox.Text);
            Facturacion facturacion = BLL.FacturacionBLL.Buscar(id);

            if (facturacion != null)
            {
                LlenarCampos(facturacion);

            }
            else
                Utilities.Utils.ShowToastr(this, "No se pudo Encontrar", "Fallido", "error");
        }
    }
    }

