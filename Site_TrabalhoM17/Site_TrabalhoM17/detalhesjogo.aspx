<%@ Page Title="" Language="C#" MasterPageFile="~/mP.Master" AutoEventWireup="true" CodeBehind="detalhesjogo.aspx.cs" Inherits="Site_TrabalhoM17.detalhesjogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body  style="background-color: #2C3338;">
    <div style="margin-top: 10%; color:#fff">
        <div>
            <asp:Image ID="imgCapa" runat="server" /><br />
            <asp:Label ID="lbNome" runat="server" /><br />
            <asp:Label ID="lbPreco" runat="server" /><br />
            <asp:Label ID="lbDescricao" runat="server" /><br />
            <asp:Label ID="lbAvaliacao" runat="server" /><br />
            <asp:Label ID="lbSo" runat="server" /><br />
            <asp:Label ID="lbEmpresa" runat="server" /><br />
            <asp:Label ID="lbStock" runat="server" /><br />
            <asp:Label ID="lbAno" runat="server" /><br />
        </div>
        <div>
            <asp:Button runat="server" ID="btVoltar" CssClass="btn btn-danger" Text="Voltar" OnClick="btVoltar_Click" />
            <asp:Button runat="server" ID="btCarrinho" Text="Adicionar ao Carrinho" CssClass="btn btn-info" OnClick="btCarrinho_Click" />
        </div>
    </div>
        </body>
</asp:Content>
