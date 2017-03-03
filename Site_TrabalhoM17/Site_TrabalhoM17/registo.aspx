<%@ Page Title="" Language="C#" MasterPageFile="~/mP.Master" AutoEventWireup="true" CodeBehind="registo.aspx.cs" Inherits="Site_TrabalhoM17.registo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://www.google.com/recaptcha/api.js"></script>
    <link href="login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top:10%" class="grid">
        <div class="form-group">
            <asp:TextBox runat="server" ID="tbEmail" placeholder="Email" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:TextBox runat="server" ID="tbNome" placeholder="Nome" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:TextBox runat="server" ID="tbMorada" placeholder="Morada" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:TextBox runat="server" ID="tbNIF" placeholder="NIF" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:TextBox TextMode="Password" runat="server" ID="tbPassword" placeholder="Password" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="g-recaptcha" style="margin-left:2.5%" data-sitekey="6Lc1vvoSAAAAAFjyIsG88_b-SoYcW5n89amtzucB"></div>
        <asp:Label ID="lbErro" runat="server" /><br />
        <asp:Button ID="btRegistar" runat="server" Text="Registar" Width="50%" CssClass="btn btn-info center-block" OnClick="btRegistar_Click" />
    </div>
</asp:Content>
