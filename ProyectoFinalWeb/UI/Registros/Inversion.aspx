<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Inversion.aspx.cs" Inherits="ProyectoFinalWeb.UI.Registros.Inversion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="MontoLabel" runat="server"></asp:Label>
     <asp:button id="RefreshButton" runat="server" class="btn btn-info" text="Refrescar" onclick="RefreshButton_Click" />
</asp:Content>
