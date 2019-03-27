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
    public partial class ConsultaArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }

        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {
            PrestamoGridView.DataBind();
            Expression<Func<Articulos, bool>> filtro = x => true;
            ArticulosBLL articulos = new ArticulosBLL(); 

            int id;

            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID

                    id = Utilities.Utils.ToInt(TextCriterio.Text);
                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.ArticuloID == id && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.ArticuloID == id;
                    }

                    if (ArticulosBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, " Prestamo ID No Existe", "Fallido", "success");
                        return;
                    }

                    break;

                case 1:// Nombre

                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.Nombre.Contains(TextCriterio.Text) && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.Nombre.Contains(TextCriterio.Text);
                    }

                    if (ArticulosBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Dicho Nombre no existe", "Fallido", "success");
                        return;
                    }

                    break;

                case 2:// Marca
                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.Marca.Contains(TextCriterio.Text) && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.Marca.Contains(TextCriterio.Text);
                    }

                    if (ArticulosBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Dicho Nombre no existe", "Fallido", "success");
                        return;
                    }

                    break;
                    
                case 3://Todos

                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => true && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = x => true;
                    }

                    if (ArticulosBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "No existen Dichas Cuentas", "Fallido", "success");
                    }
                    break;

            }

            PrestamoGridView.DataSource = ArticulosBLL.GetList(filtro);
            PrestamoGridView.DataBind();
        }

        protected void ReporteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ReporteArticulo.aspx");
        }
    }
}