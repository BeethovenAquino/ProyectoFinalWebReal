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
    public partial class Inversion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Inversionn inversion = InversionBLL.Buscar(1);
            MontoLabel.Text = 0.ToString();
            MontoLabel.Text = $"${inversion.Monto.ToString()}";
             
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            Inversionn inversion = InversionBLL.Buscar(1);
            MontoLabel.Text = 0.ToString();
            MontoLabel.Text = $"${inversion.Monto.ToString()}";
            
        }
    }
}