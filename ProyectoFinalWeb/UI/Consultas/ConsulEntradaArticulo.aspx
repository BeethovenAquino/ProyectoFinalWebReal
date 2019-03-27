<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ConsulEntradaArticulo.aspx.cs" Inherits="ProyectoFinalWeb.UI.Consultas.ConsulEntradaArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <div class="container form-group ">
        <div class="row">

            <label for="TipodeFiltro" style="width: 50px">Filtro:</label>
            <div style="width: 220px">
                <asp:DropDownList class="form-control" ID="TipodeFiltro" runat="server" for="TipodeFiltro" Width="200px">
                    <asp:ListItem>EntradaID</asp:ListItem>
                    <asp:ListItem>Articulo</asp:ListItem>
                    <asp:ListItem>Todos</asp:ListItem>
                    


                    

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
                        <asp:BoundField DataField="EntradaArticulosID" HeaderText="EntradaArticulosID" />
                        <asp:BoundField DataField="Articulo" HeaderText="Articulo" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="ArticuloID" HeaderText="ArticuloID" />
                        <asp:BoundField DataField="PrecioCompra" HeaderText="PrecioCompra" />
                        <asp:BoundField DataField="PrecioVenta" HeaderText="PrecioVenta" />
                        <asp:BoundField DataField="Ganancia" HeaderText="Ganancia" />
                        

                    </Columns>
                    <HeaderStyle BackColor="LightCyan" Font-Bold="True" />
                </asp:GridView>

                 
            </div>
        </div>
    </div>

       <%-- <div class="panel-footer">
            <div class="modal-content">
                            <div class="text-center">
                        <asp:Button ID="ReporteButton" runat="server" class="btn btn-success" data-dismiss="modal" data-toggle="modal" Text="Imrpimir" OnClick="ReporteButton_Click" />
                                </div>
                            </div>--%>
            </div>

</asp:Content>
