<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteFacturacion.aspx.cs" Inherits="ProyectoFinalWeb.UI.Reportes.ReporteFacturacion" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Reporte Facturacion</title>
     <style>
        html, body, form, #div1 {
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
      <div id="div1">
              <!-- Cuerpo del modal puede tener un formulario manin -->
            
              <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="CuentaReportViewer" runat="server" Height="100%" Width="100%"></rsweb:ReportViewer>
            
        
        </div>
    </form>
</body>
</html>
