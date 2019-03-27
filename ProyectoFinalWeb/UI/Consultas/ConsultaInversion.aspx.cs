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
    public partial class ConsultaInversion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {
                PrestamoGridView.DataBind();
                Expression<Func<Inversionn, bool>> filtro = x => true;
                InversionBLL entrada = new InversionBLL();

                int id;



                switch (TipodeFiltro.SelectedIndex)
                {
                    case 0://ID
                        id = Utilities.Utils.ToInt(TextCriterio.Text);
                        filtro = c => c.InversionID == id;
                        if (InversionBLL.GetList(filtro).Count() == 0)
                        {
                            Utilities.Utils.ShowToastr(this, " Prestamo ID No Existe", "Fallido", "success");
                            return;
                        }

                        break;

                    case 1:// Monto

                        int balance = Utilities.Utils.ToInt(TextCriterio.Text);
                    
                        filtro = c => c.Monto == balance;

                        if (InversionBLL.GetList(filtro).Count() == 0)
                        {
                            Utilities.Utils.ShowToastr(this, "Dicho Balance No existe", "Fallido", "success");
                            return;
                        }
                        break;


                    case 2://Todos

                        filtro = x => true;
                        if (InversionBLL.GetList(filtro).Count() == 0)
                        {
                            Utilities.Utils.ShowToastr(this, "No existen Dichas Cuentas", "Fallido", "success");
                        }
                        break;

                }
                PrestamoGridView.DataSource = InversionBLL.GetList(filtro);
                PrestamoGridView.DataBind();
            }
        }
    }
    