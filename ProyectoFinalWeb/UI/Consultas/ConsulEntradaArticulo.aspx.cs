using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb.UI.Consultas
{
    public partial class ConsulEntradaArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {
            PrestamoGridView.DataBind();
            Expression<Func<EntradaArticulos, bool>> filtro = x => true;
            EntradaArticulosBLL entrada = new EntradaArticulosBLL();

            int id;



            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID
                    id = Utilities.Utils.ToInt(TextCriterio.Text);
                    filtro = c => c.EntradaArticulosID == id;
                    if (EntradaArticulosBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, " Prestamo ID No Existe", "Fallido", "success");
                        return;
                    }

                    break;

                case 1:// Nombre

                    filtro = c => c.Articulo.Contains(TextCriterio.Text);

                    if (EntradaArticulosBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Dicho Nombre no existe", "Fallido", "success");
                        return;
                    }

                    break;

              
                case 2://Todos

                    filtro = x => true;
                    if (EntradaArticulosBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "No existen Dichas Cuentas", "Fallido", "success");
                    }
                    break;

            }
            PrestamoGridView.DataSource = EntradaArticulosBLL.GetList(filtro);
            PrestamoGridView.DataBind();
        }
    }
    }
