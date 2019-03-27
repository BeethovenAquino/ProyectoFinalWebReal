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
    public partial class ConsultaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {
            PrestamoGridView.DataBind();
            Expression<Func<Usuarios, bool>> filtro = x => true;
            UsusariosBLL entrada = new UsusariosBLL();

            int id;



            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID
                    id = Utilities.Utils.ToInt(TextCriterio.Text);
                    filtro = c => c.UsuariosId == id;
                    if (UsusariosBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, " Prestamo ID No Existe", "Fallido", "success");
                        return;
                    }

                    break;

                case 1:// Nombre

                    filtro = c => c.Nombre.Contains(TextCriterio.Text);

                    if (UsusariosBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Dicho Nombre no existe", "Fallido", "success");
                        return;
                    }

                    break;

                case 2:// Usuario

                    filtro = c => c.Usuario.Contains(TextCriterio.Text);

                    if (UsusariosBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Dicho Nombre no existe", "Fallido", "success");
                        return;
                    }

                    break;

                case 3://Todos

                    filtro = x => true;
                    if (UsusariosBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "No existen Dichas Cuentas", "Fallido", "success");
                    }
                    break;

            }
            PrestamoGridView.DataSource = UsusariosBLL.GetList(filtro);
            PrestamoGridView.DataBind();
        }
    }
}