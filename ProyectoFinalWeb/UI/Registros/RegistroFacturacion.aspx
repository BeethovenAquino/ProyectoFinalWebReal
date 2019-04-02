<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="RegistroFacturacion.aspx.cs" Inherits="ProyectoFinalWeb.UI.Registros.RegistroFacturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group container">
        <div class="row">

            <div class="Container-fluid">
                <div class="align-content-center">
                    <div class="panel-heading text-center">
                        <h1><ins>Registro Facturacion</ins></h1>
                        <br />
                    </div>
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <strong>
                                        <asp:Label ID="Label1" runat="server" Text="FacturacionID:"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="FacturacionIDTextbox" runat="server" class="form-control col-md-12" type="Number"></asp:TextBox>
                                </td>
                                <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="BuscarButton" ValidationGroup="Buscar" runat="server" class="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" />
                                    <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo " solo acepta numeros' ControlToValidate="FacturacionIDTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Solo se aceptan numeros" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                            </tr>
                        </table>
                    </div>
                    <br />

                </div>
                <%--VentaDropDownList--%>
                <div>
                    <table>
                        <tr>
                            <td>
                                <strong>
                                    <asp:Label ID="venta" runat="server" Text="Venta: "></asp:Label></strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="VentaDropDownList" CssClass="col-md-12" runat="server" OnSelectedIndexChanged="VentaDropDownList_SelectedIndexChanged">
                                    <asp:ListItem>Contado</asp:ListItem>
                                    <asp:ListItem>Credito</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <%--<asp:DropDownList  ValidationGroup="Guardar" AutoPostBack="true" ID="Cuenta_Id_DropDownList" AppendDataBoundItems="true" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        <asp:CustomValidator ValidationGroup="Guardar" ID="CustomValidator2" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="DropDownList" runat="server" ErrorMessage="Seleccione una cuenta" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>--%>
                            </td>
                        </tr>
                    </table>
                </div>

                <%--ClienteDropDownList1--%>
                <div>
                    <table>
                        <tr>
                            <td>
                                <strong>
                                    <asp:Label ID="Label4" runat="server" Text="Cliente: "></asp:Label></strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ClienteDropDownList" CssClass="col-md-12" runat="server"></asp:DropDownList>
                            </td>
                            <td>
                                <%--<asp:DropDownList  ValidationGroup="Guardar" AutoPostBack="true" ID="Cuenta_Id_DropDownList" AppendDataBoundItems="true" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        <asp:CustomValidator ValidationGroup="Guardar" ID="CustomValidator2" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="DropDownList" runat="server" ErrorMessage="Seleccione una cuenta" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>--%>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="form-inline">
                    <%--ArticuloDropDownList--%>
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <strong>
                                        <asp:Label ID="Label5" runat="server" Text="Articulo: "></asp:Label></strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ArticuloDropDownList" CssClass="col-md-12" runat="server" AutoPostBack="true" OnTextChanged="ArticuloDropDownList_TextChanged"></asp:DropDownList>
                                </td>
                                <td>
                                    <%--<asp:DropDownList  ValidationGroup="Guardar" AutoPostBack="true" ID="Cuenta_Id_DropDownList" AppendDataBoundItems="true" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        <asp:CustomValidator ValidationGroup="Guardar" ID="CustomValidator2" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="DropDownList" runat="server" ErrorMessage="Seleccione una cuenta" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>--%>
                                </td>
                            </tr>
                        </table>
                    </div>


                    <%--CantidadTexbox--%>
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <strong>
                                        <asp:Label ID="Label3" runat="server" Text="Cantidad:"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="CantidadTexbox" runat="server" class="form-control col-md-12" Height="30" Width="300" MaxLength="80" type="Number" AutoPostBack="true" OnTextChanged="CantidadTexbox_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="ValidaBalanceNUM" runat="server" ErrorMessage='Campo "Balance" solo acepta numeros' ControlToValidate="CantidadTexbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="ValidaBalance" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="CantidadTexbox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
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
                                    <asp:TextBox ID="PrecioVentaTextbox" runat="server" class="form-control col-md-12" Height="30" Width="300" MaxLength="80" AutoPostBack="true" type="Number" OnTextChanged="PrecioVentaTextbox_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="Regularexpressionvalidator1" runat="server" ErrorMessage='Campo "Balance" solo acepta numeros' ControlToValidate="PrecioVentaTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="PrecioVentaTextbox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>


                    <%--ImporteTextbox--%>
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <strong>
                                        <asp:Label ID="Label6" runat="server" Text="Importe:"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="ImporteTextbox" runat="server" class="form-control col-md-12" Height="30" Width="300" MaxLength="80" AutoPostBack="true" type="Number"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="Regularexpressionvalidator4" runat="server" ErrorMessage='Campo "Balance" solo acepta numeros' ControlToValidate="ImporteTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator5" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="ImporteTextbox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="AgregarButton" ValidationGroup="Buscar" runat="server" class="btn btn-info" Text="Agregar" OnClick="AgregarButton_Click" />
                    <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="RemoverButton" ValidationGroup="Buscar" runat="server" class="btn btn-info" Text="Remover" OnClick="RemoverButton_Click" />
                </div>

                <%--FacturacionGridView--%>
                <div class="form-group">
                    <div class="table-responsive col-md-12 col-sm-12">

                        <asp:GridView ID="FacturacionGridView" OnRowDataBound="FacturacionGridView_RowDataBound" OnSelectedIndexChanged="FacturacionGridView_SelectedIndexChanged" AllowPaging="true" PageSize="12" runat="server" Height="100%" Width="100%" class="table text-center" AutoGenerateColumns="False"
                            CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />

                            <Columns>
                                <asp:BoundField DataField="FacturaID" HeaderText="FacturaID " />
                                <asp:BoundField DataField="ClienteID" HeaderText="ClienteID" />
                                <asp:BoundField DataField="ArticuloID" HeaderText="ArticuloID" />
                                <asp:BoundField DataField="Venta" HeaderText="Venta" />
                                <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                                <asp:BoundField DataField="Articulo" HeaderText="Articulo" />
                                <asp:BoundField DataField="cantidad" HeaderText="cantidad" />
                                <asp:BoundField DataField="precio" HeaderText="precio" />
                                <asp:BoundField DataField="importe" HeaderText="importe" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="EliminarButtonDetalle" CommandName="Select" CssClass="btn btn-dark form-control" runat="server"
                                            Text="Eliminar" OnClick="EliminarButtonDetalle_Click" />



                                    </ItemTemplate>
                                </asp:TemplateField>
                                

                            </Columns>

                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </div>


                </div>

                <div class="form-inline">
                    <%--MontoTextBox--%>
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <strong>
                                        <asp:Label ID="Label7" runat="server" Text="Monto:"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="MontoTextBox" runat="server" class="form-control col-md-12" Height="30" Width="300" MaxLength="80" type="Number" OnTextChanged="MontoTextBox_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server" ErrorMessage='Campo "Monto" solo acepta numeros' ControlToValidate="MontoTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="MontoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>

                    <%--DevueltaTextBox--%>
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <strong>
                                        <asp:Label ID="Label8" runat="server" Text="Devuelta:"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="DevueltaTextBox" runat="server" class="form-control col-md-12" Height="30" Width="300" MaxLength="80" type="Number"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="Regularexpressionvalidator3" runat="server" ErrorMessage='Campo "Devuelta" solo acepta numeros' ControlToValidate="DevueltaTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="DevueltaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>

                    <%--SubtotalTextBox--%>
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <strong>
                                        <asp:Label ID="Label9" runat="server" Text="Subtotal:"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="SubtotalTextBox" runat="server" class="form-control col-md-12" Height="30" Width="300" AutoPostBack="true" MaxLength="80" type="Number"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="Regularexpressionvalidator5" runat="server" ErrorMessage='Campo "Devuelta" solo acepta numeros' ControlToValidate="SubtotalTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator4" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="SubtotalTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>

                    <%--TotalTextBox--%>
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <strong>
                                        <asp:Label ID="Label10" runat="server" Text="Total:"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TotalTextBox" runat="server" class="form-control col-md-12" Height="30" Width="300" MaxLength="80" AutoPostBack="true" type="Number"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="Regularexpressionvalidator6" runat="server" ErrorMessage='Campo "Total" solo acepta numeros' ControlToValidate="TotalTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator6" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="TotalTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>



                <%--  <%-- Botones--%>
                <div class="panel-footer">
                    <div class="text-center">

                        <asp:Label class="text-center " ID="ErrorLabel" runat="server" Text=""></asp:Label>

                        <asp:Button ID="NuevoButton" runat="server" class="btn btn-info" Text="Nuevo" OnClick="NuevoButton_Click" />
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                                <asp:Button ID="GuardarButton" runat="server" class="btn btn-success" Text="Guardar" OnClick="GuardarButton_Click" ValidationGroup="Guardar" />
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                                <asp:Button ID="EliminarButton" runat="server" class="btn btn-danger" Text="Eliminar" OnClick="EliminarButton_Click" />
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                                <asp:Button ID="ReporteButton" runat="server" class="btn btn-success" Text="Recibo" OnClick="ReporteButton_Click" />
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




