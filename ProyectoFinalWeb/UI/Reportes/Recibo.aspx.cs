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
    public partial class Recibo : System.Web.UI.Page
    {
        Expression<Func<FacturacionDetalle, bool>> filtro = C => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<FacturacionDetalle> prestamo = new List<FacturacionDetalle>();
            if (!Page.IsPostBack)
            {
                CuentaReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                CuentaReportViewer.Reset();

                CuentaReportViewer.LocalReport.ReportPath = Server.MapPath(@"../Reportes/ReciboFacturacion.rdlc");

                CuentaReportViewer.LocalReport.DataSources.Clear();

                CuentaReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReciboFacturacion", FacturacionBLL.GetList(x=>true).Last().Detalle));
                CuentaReportViewer.LocalReport.Refresh();
            }
        }
    }
}