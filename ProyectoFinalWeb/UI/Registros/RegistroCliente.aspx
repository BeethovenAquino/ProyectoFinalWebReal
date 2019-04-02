<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="ProyectoFinalWeb.UI.Registros.RegistroCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
      <div class="form-group container">
        <div class="row">
            <div class="col-sm-12">

                <div class="Container-fluid">
                    <div class="align-content-center">
                        <div class="panel-heading text-center">
                            <h1><ins>Registro Clientes</ins></h1>
                            <br />
                        </div>
                        <%--ClienteIDTextbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:label id="Label1" runat="server" text="ClienteID:"></asp:label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:textbox id="ClienteIDTextbox" runat="server" class="form-control" height="30" width="200" type="Number"></asp:textbox>
                                    </td>
                                    <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:button id="BuscarButton" validationgroup="Buscar" runat="server" class="btn btn-info" text="Buscar" onclick="BuscarButton_Click" />
                                        <asp:regularexpressionvalidator id="ValidaID" runat="server" errormessage='Campo " solo acepta numeros' controltovalidate="ClienteIDTextbox" validationexpression="^[0-9]*" text="*" forecolor="Red" display="Dynamic" tooltip="Solo se aceptan numeros" validationgroup="Guardar"></asp:regularexpressionvalidator>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />

                        <%--      NombreClienteTextbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:label id="Label4" runat="server" text="Nombre del Cliente:"></asp:label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:textbox id="NombreClienteTextbox" validationgroup="Guardar" runat="server" class="form-control" height="30" width="300" maxlength="50"></asp:textbox>
                                    </td>
                                    <td>
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" errormessage="Campos Obligatorios" controltovalidate="NombreClienteTextbox" font-bold="True" forecolor="Red" validationgroup="Guardar">*</asp:requiredfieldvalidator>
                                        <asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" errormessage="Solo Letras" controltovalidate="NombreClienteTextbox" font-bold="True" forecolor="Red" validationexpression="[A-Za-z ]*">*</asp:regularexpressionvalidator>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                        <br />

                        <%--Cedula--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:label id="Label5" runat="server" text="Cedula:"></asp:label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:textbox id="CedulaTextbox"  validationgroup="Guardar" runat="server" class="form-control" height="30" width="300" maxlength="50" type="Cedula "  ></asp:textbox>
                                        
                                    </td>
                                    <td>
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" errormessage="Campos Obligatorios" controltovalidate="CedulaTextbox" font-bold="True" forecolor="Red" validationgroup="Guardar">*</asp:requiredfieldvalidator>
                                        <asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" errormessage="Solo Letras" controltovalidate="CedulaTextbox" font-bold="True" forecolor="Red" validationexpression="[A-Za-z ]*">*</asp:regularexpressionvalidator>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                        <br />

                        <%-- FechadateTime--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:label id="Label8" runat="server" text="Fecha:"></asp:label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:textbox id="FechadateTime" validationgroup="Guardar" runat="server" class="form-control" type="date" height="30" width="300" maxlength="10"></asp:textbox>
                                        <asp:requiredfieldvalidator validationgroup="Guardar" id="RequiredFieldValidator1" cssclass="ErrorMessage" controltovalidate="FechadateTime" runat="server" errormessage="Seleccione una Fecha"></asp:requiredfieldvalidator>
                                    </td>

                                </tr>
                            </table>
                        </div>

                        <%--DireccionTextbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:label id="Label2" runat="server" text="Dirrecion:"></asp:label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:textbox id="DireccionTextbox"  validationgroup="Guardar" runat="server" class="form-control" height="30" width="300" maxlength="50"  ></asp:textbox>
                                    </td>
                                    <td>
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" errormessage="Campos Obligatorios" controltovalidate="DireccionTextbox" font-bold="True" forecolor="Red" validationgroup="Guardar">*</asp:requiredfieldvalidator>
                                        <asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" errormessage="Solo Letras" controltovalidate="DireccionTextbox" font-bold="True" forecolor="Red" validationexpression="[A-Za-z ]*">*</asp:regularexpressionvalidator>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                        <br />


                        <%--TelefonoTextbox--%>
                         <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:label id="Label3" runat="server" text="Telefono:"></asp:label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:textbox id="TelefonoTextbox"  validationgroup="Guardar" runat="server" class="form-control" type="Tel" height="30" width="300" maxlength="50"   ></asp:textbox>
                                        
                                    </td>
                                    <td>
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" errormessage="Campos Obligatorios" controltovalidate="TelefonoTextbox" font-bold="True" forecolor="Red" validationgroup="Guardar">*</asp:requiredfieldvalidator>
                                        <asp:regularexpressionvalidator id="RegularExpressionValidator4" runat="server" errormessage="Solo Letras" controltovalidate="TelefonoTextbox" font-bold="True" forecolor="Red" validationexpression="[A-Za-z ]*">*</asp:regularexpressionvalidator>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                        <br />


                        <%--DeudaTextbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:label id="Label6" runat="server" text="Total Deuda:"></asp:label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:textbox id="DeudaTextbox"  validationgroup="Guardar" runat="server" class="form-control" height="30" width="300" maxlength="50"  ></asp:textbox>
                                    </td>
                                    <td>
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" errormessage="Campos Obligatorios" controltovalidate="DeudaTextbox" font-bold="True" forecolor="Red" validationgroup="Guardar">*</asp:requiredfieldvalidator>
                                        <asp:regularexpressionvalidator id="RegularExpressionValidator5" runat="server" errormessage="Solo Letras" controltovalidate="DeudaTextbox" font-bold="True" forecolor="Red" validationexpression="[A-Za-z ]*">*</asp:regularexpressionvalidator>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                        <br />


                          <%--  <%-- Botones--%>
                        <div class="panel-footer">
                            <div class="text-center">

                                <asp:label class="text-center " id="ErrorLabel" runat="server" text=""></asp:label>

                                <asp:button id="NuevoButton" runat="server" class="btn btn-info" text="Nuevo" onclick="NuevoButton_Click" />
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                                <asp:button id="GuardarButton" runat="server" class="btn btn-success" text="Guardar" onclick="GuardarButton_Click" validationgroup="Guardar" />
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                                <asp:button id="EliminarButton" runat="server" class="btn btn-danger" text="Eliminar" onclick="EliminarButton_Click" />
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                                <%--<asp:button id="ReporteButton" runat="server" class="btn btn-success" text="Imrpimir" onclick="ReporteButton_Click" />--%>
                            </div>
                        </div>









                        </div>
                    </div>
                </div>
            </div>
         </div>

      <asp:validationsummary id="ValidationSummary1" runat="server" forecolor="Red" />
        <script src="/Scripts/bootstrap.min.js"></script>
        <script src="/Scripts/jquery-2.2.0.min.js"></script>
        <link href="/Content/toastr.min.css" rel="stylesheet" />
        <script src="/Scripts/toastr.min.js"></script>
        <script src="/Scripts/jquery-3.2.1.slim.min.js"></script>
</asp:Content>
