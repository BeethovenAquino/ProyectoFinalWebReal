<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="ProyectoFinalWeb.UI.Registros.RegistroUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="form-group container">
        <div class="row">
            <div class="col-sm-12">

                <div class="Container-fluid">
                    <div class="align-content-center">
                        <div class="panel-heading text-center">
                            <h1><ins>Registro Usuario</ins></h1>
                            <br />
                        </div>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label1" runat="server" Text="UsuarioID:"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="UsuarioIDTextbox" runat="server" class="form-control" Height="30" Width="200" type="Number"></asp:TextBox>
                                    </td>
                                     <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:button id="BuscarButton" validationgroup="Buscar" runat="server" class="btn btn-info" text="Buscar" onclick="BuscarButton_Click" />
                                    <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo " solo acepta numeros' ControlToValidate="UsuarioIDTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Solo se aceptan numeros" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />

                        <%--      NombreArticuloTextbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label4" runat="server" Text="Nombre:"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="NombreArticuloTextbox" ValidationGroup="Guardar" runat="server" class="form-control" Height="30" Width="300" MaxLength="50"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campos Obligatorios" ControlToValidate="NombreArticuloTextbox" Font-Bold="True" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo Letras" ControlToValidate="NombreArticuloTextbox" Font-Bold="True" ForeColor="Red" ValidationExpression="[A-Za-z ]*">*</asp:RegularExpressionValidator>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                        <br />

                        <%--MarcaArticuloTextbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label5" runat="server" Text="Usuario:"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="UsuarioTextbox" ValidationGroup="Guardar" runat="server" class="form-control" Height="30" Width="300" MaxLength="50"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campos Obligatorios" ControlToValidate="UsuarioTextbox" Font-Bold="True" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Solo Letras" ControlToValidate="UsuarioTextbox" Font-Bold="True" ForeColor="Red" ValidationExpression="[A-Za-z ]*">*</asp:RegularExpressionValidator>
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
                                            <asp:Label ID="Label8" runat="server" Text="Fecha:"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="FechadateTime" ValidationGroup="Guardar" runat="server" class="form-control" type="date" Height="30" Width="300" MaxLength="10"></asp:TextBox>
                                        <asp:RequiredFieldValidator ValidationGroup="Guardar" ID="RequiredFieldValidator1" CssClass="ErrorMessage" ControlToValidate="FechadateTime" runat="server" ErrorMessage="Seleccione una Fecha"></asp:RequiredFieldValidator>
                                    </td>

                                </tr>
                            </table>
                        </div>

                        <%--ContraseñaTextBox--%>
                         <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label9" runat="server" Text="Contraseña:"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="ContraseñaTextBox" ValidationGroup="Guardar" runat="server" class="form-control" Height="30" Width="300" MaxLength="50" type="password"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Campos Obligatorios" ControlToValidate="ContraseñaTextBox" Font-Bold="True" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Solo Letras" ControlToValidate="ContraseñaTextBox" Font-Bold="True" ForeColor="Red" ValidationExpression="[A-Za-z ]*">*</asp:RegularExpressionValidator>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                        <br />

                        <%--ConfirContraTextbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label10" runat="server" Text="Confirmar Contraseña:"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="ConfirContraTextbox" ValidationGroup="Guardar" runat="server" class="form-control" Height="30" Width="300" MaxLength="50" type="password"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Campos Obligatorios" ControlToValidate="ConfirContraTextbox" Font-Bold="True" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Solo Letras" ControlToValidate="ConfirContraTextbox" Font-Bold="True" ForeColor="Red" ValidationExpression="[A-Za-z ]*">*</asp:RegularExpressionValidator>
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




    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    <script src="/Scripts/bootstrap.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>
    <link href="/Content/toastr.min.css" rel="stylesheet" />
    <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-3.2.1.slim.min.js"></script>
</asp:Content>
