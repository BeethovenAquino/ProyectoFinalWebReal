using BLL;
using Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb.UI.Reportes
{
    public partial class ReporteUsuario : System.Web.UI.Page
    {
        Expression<Func<Usuarios, bool>> filtro = C => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CuentaReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                CuentaReportViewer.Reset();

                CuentaReportViewer.LocalReport.ReportPath = Server.MapPath(@"../Reportes/Usuario.rdlc");

                CuentaReportViewer.LocalReport.DataSources.Clear();

                CuentaReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Usuario", UsusariosBLL.GetList(filtro)));
                CuentaReportViewer.LocalReport.Refresh();
            }
        }
    }
}