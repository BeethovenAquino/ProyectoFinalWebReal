<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ConsultaCliente.aspx.cs" Inherits="ProyectoFinalWeb.UI.Consultas.ConsultaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container form-group ">
        <div class="row">

            <label for="TipodeFiltro" style="width: 50px">Filtro:</label>
            <div style="width: 220px">
                <asp:DropDownList class="form-control" ID="TipodeFiltro" runat="server" for="TipodeFiltro" Width="200px">
                    <asp:ListItem>ClienteID</asp:ListItem>
                    <asp:ListItem>Nombre</asp:ListItem>
                    <asp:ListItem>Direccion</asp:ListItem>
                    <asp:ListItem>Cedula</asp:ListItem>
                    <asp:ListItem>Telefono</asp:ListItem>
                    <asp:ListItem Selected="true">Todos</asp:ListItem>


                    

                </asp:DropDownList>
            </div>
            <asp:Label ID="LabelCriterio" runat="server" Text="Criterio:" Style="width: 60px"></asp:Label>
            <div style="width: 370px">
                <asp:TextBox class="form-control" ID="TextCriterio" runat="server" Style="width: 350px"></asp:TextBox>

            </div>
            <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" class="btn btn-info btn-md" OnClick="ButtonBuscar_Click1" />

        </div>
    </div>

   
    <div class="container form-group ">
        <div class="row">
            <div class="form-row justify-content-center">
                <asp:GridView ID="PrestamoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="LightSkyBlue" />
                    <Columns>
                        <asp:BoundField DataField="ClienteID" HeaderText="ClienteID" />
                        <asp:BoundField DataField="NombreCliente" HeaderText="Nombre de Cliente" />
                        <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                        <asp:BoundField DataField="Direccion" HeaderText="Direecion" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="Total" HeaderText="Total" />
                        

                    </Columns>
                    <HeaderStyle BackColor="LightCyan" Font-Bold="True" />
                </asp:GridView>

                 
            </div>
        </div>
    </div>

        <div class="panel-footer">
            <div class="modal-content">
                            <div class="text-center">
                        <asp:Button ID="ReporteButton" runat="server" class="btn btn-success" data-dismiss="modal" data-toggle="modal" Text="Imrpimir" OnClick="ReporteButton_Click" />
                                </div>
                            </div>
            </div>
</asp:Content>
