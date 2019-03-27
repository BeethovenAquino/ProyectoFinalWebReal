<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="RegistroPagoCliente.aspx.cs" Inherits="ProyectoFinalWeb.UI.Registros.RegistroPagoCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group container">
        <div class="row">
            <div class="col-sm-12">

                <div class="Container-fluid">
                    <div class="align-content-center">
                        <div class="panel-heading text-center">
                            <h1><ins>Registro Pago del Cliente</ins></h1>
                            <br />
                        </div>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label1" runat="server" Text="PagoID:"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="PagoIDTextbox" runat="server" class="form-control" Height="30" Width="200" type="Number"></asp:TextBox>
                                    </td>
                                     <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:button id="BuscarButton" validationgroup="Buscar" runat="server" class="btn btn-info" text="Buscar" onclick="BuscarButton_Click" />
                                    <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo " solo acepta numeros' ControlToValidate="PagoIDTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Solo se aceptan numeros" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                    
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


                        <%--Consulta de Pago--%>
                        <div class="container form-group ">
                            <div class="row">

                                <label for="TipodeFiltro" style="width: 50px">Filtro:</label>
                                <div style="width: 220px">
                                    <asp:DropDownList class="form-control" ID="TipodeFiltro" runat="server" for="TipodeFiltro" Width="200px">
                                        <asp:ListItem>ClienteID</asp:ListItem>
                                        <asp:ListItem>Todos</asp:ListItem>
                                        


                                    </asp:DropDownList>
                                </div>
                                <asp:Label ID="LabelCriterio" runat="server" Text="Criterio:" Style="width: 60px"></asp:Label>
                                <div style="width: 370px">
                                    <asp:TextBox class="form-control" ID="CriterioTextbox" runat="server" Style="width: 350px"></asp:TextBox>

                                </div>
                                <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" class="btn btn-info btn-md" OnClick="ButtonBuscar_Click1" />

                            </div>
                        </div>

                        <div>
                            <table>
                                <tr>
                                    <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    </td>
                                    <td>
                                        <asp:TextBox ID="DesdeTextBox" TextMode="Date" runat="server" class="form-control" Height="25" Width="175"></asp:TextBox>
                                    </td>
                                    <td>&nbsp<strong><asp:Label ID="Label4" runat="server" Text="Desde">  </asp:Label></strong>&nbsp
                                    </td>
                                    <td>
                                        <asp:TextBox ID="HastaTextBox" TextMode="Date" runat="server" Text="Hasta" class="form-control" Height="25" Width="175"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>


                        <div>
                            <table>
                                <tr>
                                    <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="FechaCheckBox" runat="server" Text="Fecha" />
                                    </td>

                                </tr>
                            </table>
                        </div>

                        <div class="container form-group ">
                            <div class="row">
                                <div class="form-row justify-content-center">
                                    <asp:GridView ID="PrestamoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="LightSkyBlue" />
                                        <Columns>
                                            <asp:BoundField DataField="ClienteID" HeaderText="PagoID" />
                                            <asp:BoundField DataField="NombreCliente" HeaderText="NombreCliente" />
                                            <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                                            <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                                         <asp:BoundField DataField="Total" HeaderText="Total" />
                                            

                                        </Columns>
                                        <HeaderStyle BackColor="LightCyan" Font-Bold="True" />
                                    </asp:GridView>


                                </div>
                            </div>
                        </div>

                        <div class="form-inline">
                        <%--AbonadoTexbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label3" runat="server" Text="Abonado:"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="AbonadoTexbox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="ValidaBalanceNUM" runat="server" ErrorMessage='Campo "Balance" solo acepta numeros' ControlToValidate="AbonadoTexbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="ValidaBalance" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="AbonadoTexbox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <%--Deuda--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label2" runat="server" Text="Deuda:"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="DeudaTextbox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator1" runat="server" ErrorMessage='Campo "Balance" solo acepta numeros' ControlToValidate="DeudaTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="DeudaTextbox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>
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
    </div>




    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    <script src="/Scripts/bootstrap.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>
    <link href="/Content/toastr.min.css" rel="stylesheet" />
    <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-3.2.1.slim.min.js"></script>
</asp:Content>
