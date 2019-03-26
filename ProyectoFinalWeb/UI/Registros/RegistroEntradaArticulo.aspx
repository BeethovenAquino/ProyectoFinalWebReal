<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="RegistroEntradaArticulo.aspx.cs" Inherits="ProyectoFinalWeb.UI.Registros.RegistroEntradaArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="form-group container">
        <div class="row">
            <div class="col-sm-12">

                <div class="Container-fluid">
                    <div class="align-content-center">
                        <div class="panel-heading text-center">
                            <h1><ins>Registro Entrada a los articulos</ins></h1>
                            <br />
                        </div>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label1" runat="server" Text="EntradaArticuloID:"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="EntradaArticuloIDTextbox" runat="server" class="form-control" Height="30" Width="200" type="Number"></asp:TextBox>
                                    </td>
                                     <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:button id="BuscarButton" validationgroup="Buscar" runat="server" class="btn btn-info" text="Buscar" onclick="BuscarButton_Click" />
                                    <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo " solo acepta numeros' ControlToValidate="EntradaArticuloIDTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Solo se aceptan numeros" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                    
                                    
                                </tr>
                            </table>
                        </div>
                        <br />

                             </div>
                    <%--ArticuloDropDownList--%>
                <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="articulo" runat="server" Text="Articulo: "></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ArticuloDropDownList" runat="server"></asp:DropDownList>
                                    </td>
                                    <td>
                                       <%--<asp:DropDownList  ValidationGroup="Guardar" AutoPostBack="true" ID="Cuenta_Id_DropDownList" AppendDataBoundItems="true" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        <asp:CustomValidator ValidationGroup="Guardar" ID="CustomValidator2" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="DropDownList" runat="server" ErrorMessage="Seleccione una cuenta" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>--%>
                                    </td>
                                </tr>
                            </table>
                        </div>



                        <%--PrecioCompraTexbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label3" runat="server" Text="Precio Compra:"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="PrecioCompraTexbox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80" type="Number" OnTextChanged="PrecioCompraTexbox_TextChanged"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="ValidaBalanceNUM" runat="server" ErrorMessage='Campo "Balance" solo acepta numeros' ControlToValidate="PrecioCompraTexbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="ValidaBalance" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="PrecioCompraTexbox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <%--PrecioVentaTextbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label2" runat="server" Text="Precio Venta:"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="PrecioVentaTextbox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80" type="Number" OnTextChanged="PrecioVentaTextbox_TextChanged"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator1" runat="server" ErrorMessage='Campo "Balance" solo acepta numeros' ControlToValidate="PrecioVentaTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="PrecioVentaTextbox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>


                        <%--GananciaTextbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label6" runat="server" Text="Ganancia:"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="GananciaTextbox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80" type="Number"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator4" runat="server" ErrorMessage='Campo "Balance" solo acepta numeros' ControlToValidate="GananciaTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator5" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="GananciaTextbox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>


                        <%--VigenciaTextbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label7" runat="server" Text="Cantidad del articulo:"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="CantArticuloTextbox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator5" runat="server" ErrorMessage='Campo "Balance" solo acepta numeros' ControlToValidate="CantArticuloTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator6" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="CantArticuloTextbox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>

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





    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    <script src="/Scripts/bootstrap.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>
    <link href="/Content/toastr.min.css" rel="stylesheet" />
    <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-3.2.1.slim.min.js"></script>
</asp:Content>
