<%@ Page Title="" Language="C#" MasterPageFile="~/mP.Master" AutoEventWireup="true" CodeBehind="removerjogo.aspx.cs" Inherits="Site_TrabalhoM17.removerjogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top:10%">
        <h1>Remover jogo</h1>
        Nome:<asp:Label ID="lbNome" runat="server" /><br />
        Preço:<asp:Label ID="lbPreco" runat="server" /><br />
        Descrição:<asp:Label ID="lbDescricao" runat="server" /><br />
        Avaliação:<asp:Label ID="lbAvaliacao" runat="server" /><br />
        Data de Aquisição:<asp:Label ID="lbData" runat="server" /><br />
        Sistema Operativo:<asp:Label ID="lbSo" runat="server" /><br />
        Empresa:<asp:Label ID="lbEmpresa" runat="server" /><br />
        Stock:<asp:Label ID="lbStock" runat="server" /><br />
        Ano:<asp:Label ID="lbAno" runat="server" /><br />
        Estado:<asp:Label ID="lbEstado" runat="server" /><br />
        <asp:Image ID="imgCapa" runat="server" Width="100" /><br />
        <asp:Button CssClass="btn btn-danger" ID="btEliminar" runat="server" Text="Eliminar" OnClick="btEliminar_Click" />
        <asp:Button CssClass="btn btn-info" ID="btVoltar" runat="server" Text="Voltar" OnClick="btVoltar_Click" />
    </div>
</asp:Content>
