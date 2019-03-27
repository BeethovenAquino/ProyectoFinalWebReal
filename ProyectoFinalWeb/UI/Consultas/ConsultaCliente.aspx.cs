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
    public partial class ConsultaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {
            PrestamoGridView.DataBind();
            Expression<Func<Cliente, bool>> filtro = x => true;
            ClienteBLL cliente = new ClienteBLL();

            int id;

            

            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID
                    id = Utilities.Utils.ToInt(TextCriterio.Text);
                        filtro = c => c.ClienteID == id;
                    if (ClienteBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, " Prestamo ID No Existe", "Fallido", "success");
                        return;
                    }

                    break;

                case 1:// Nombre
                    
                        filtro = c => c.NombreCliente.Contains(TextCriterio.Text);
                    
                    if (ClienteBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Dicho Nombre no existe", "Fallido", "success");
                        return;
                    }

                    break;

                case 2:// Marcas
                    
                        filtro = c => c.Cedula.Contains(TextCriterio.Text);
                    if (ClienteBLL.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Dicho Nombre no existe", "Fallido", "success");
                        return;
                    }

                    break;
                case 3:// Cedula
                    
                        filtro = c => c.Telefono.Contains(TextCriterio.Text);
                    

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
        }
    }
}