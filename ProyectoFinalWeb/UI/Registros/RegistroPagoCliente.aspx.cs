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
    public partial class RegistroPagoCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {
            Expression<Func<Cliente, bool>> filtrar = x => true;

            PrestamoGridView.DataBind();
            Expression<Func<Cliente, bool>> filtro = x => true;
            ClienteBLL cliente = new ClienteBLL();

            int id;



            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID
                    id = Utilities.Utils.ToInt(CriterioTextbox.Text);
                    filtro = c => c.ClienteID == id;
                    if (ClienteBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, " Prestamo ID No Existe", "Fallido", "success");
                        return;
                    }

                    break;

                case 1:// Nombre

                    filtro = c => c.NombreCliente.Contains(CriterioTextbox.Text);

                    if (ClienteBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Dicho Nombre no existe", "Fallido", "success");
                        return;
                    }

                    break;

                case 2:// Marcas

                    filtro = c => c.Cedula.Contains(CriterioTextbox.Text);
                    if (ClienteBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Dicho Nombre no existe", "Fallido", "success");
                        return;
                    }

                    break;
                case 3:// Cedula

                    filtro = c => c.Telefono.Contains(CriterioTextbox.Text);


                    if (ClienteBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Dicho Nombre no existe", "Fallido", "success");
                        return;
                    }

                    break;

                case 4://Todos

                    filtro = x => true;
                    if (ClienteBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "No existen Dichas Cuentas", "Fallido", "success");
                    }
                    break;

            }
            PrestamoGridView.DataSource = ClienteBLL.GetList(filtro);
            PrestamoGridView.DataBind();

            if (TipodeFiltro.SelectedItem != null)
            {
                PrestamoGridView.DataSource = ClienteBLL.GetList(filtrar);

                if (TipodeFiltro.SelectedIndex == 0)
                {
                    foreach (var item in ClienteBLL.GetList(filtrar))
                    {
                        int deuda = Utilities.Utils.ToInt(DeudaTextbox.Text.ToString());
                        deuda = item.Total - Utilities.Utils.ToInt( AbonadoTexbox.Text);
                        AbonadoTexbox.Text = item.Total.ToString();

                    }
                }

               

            }
        }

        private void Limpiar()
        {
            PagoIDTextbox.Text = "0";
            
            PrestamoGridView.DataSource = null;
            CriterioTextbox.Text= " ";
          
            AbonadoTexbox.Text = "0";
            DeudaTextbox.Text = "0";

        }

        private void LlenaCampos(Pagos cobros)
        {
            PagoIDTextbox.Text = cobros.PagoID.ToString();
            AbonadoTexbox.Text = cobros.Abono.ToString();

            PrestamoGridView.DataSource = BLL.ClienteBLL.GetList(x => x.ClienteID == cobros.ClienteID);
        }
        private Pagos Llenaclase()
        {
            Pagos pagos = new Pagos();
            List<Cliente> detalle = (List<Cliente>)PrestamoGridView.DataSource;

            int id = detalle.ElementAt(PrestamoGridView.SelectedRow.RowIndex).ClienteID;


            pagos.PagoID = Convert.ToInt32(PagoIDTextbox.Text.ToString());
            pagos.InversionID = 1;
            
            pagos.Abono = Convert.ToInt32(AbonadoTexbox.Text.ToString());
            pagos.ClienteID = Convert.ToInt32(id);
            pagos.Deuda = Convert.ToInt32(AbonadoTexbox.Text.ToString());


            return pagos;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(PagoIDTextbox.Text);

            if (BLL.PagosBLL.Eliminar(id))
            {
                Utilities.Utils.ShowToastr(this, "Elminado", "exito", "exito");
                Limpiar();
            }
            else
            {
                Utilities.Utils.ShowToastr(this, "No se pudo eliminar", "Fallido", "error");
            }
        }

       

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            Pagos cobros = Llenaclase();
            bool paso = false;
            if (Utilities.Utils.ToInt(PagoIDTextbox.Text) == 0)
            {
                paso = BLL.PagosBLL.Guardar(Llenaclase());
            }
            else
            {
                int id = Convert.ToInt32(PagoIDTextbox.Text);
                var entry = BLL.PagosBLL.Buscar(id);

                if (entry != null)
                {
                    paso = BLL.PagosBLL.Editar(Llenaclase());
                }
                else
                {
                    Utilities.Utils.ShowToastr(this, "No se pudo encontrar", "Fallido", "error");
                }
            }

            Limpiar();
            if (paso)
            {
                Utilities.Utils.ShowToastr(this, "guardado", "Exito", "exito");
            }
            else
            {
                Utilities.Utils.ShowToastr(this, "No se pudo Guardar", "Fallido", "error");
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(PagoIDTextbox.Text);
            Pagos cobros = BLL.PagosBLL.Buscar(id);


            if (cobros != null)
            {

                LlenaCampos(cobros);


            }
            else
            {

                Utilities.Utils.ShowToastr(this, "No se pudo encontrar", "Fallido", "error");
                Limpiar();
            }
        }
    }
    }
