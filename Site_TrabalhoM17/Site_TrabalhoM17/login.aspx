<%@ Page Title="" Language="C#" MasterPageFile="~/mP.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Site_TrabalhoM17.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:400,700" rel="stylesheet">
    <link href="login.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:400,700" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" class="align">
    <div id="divLogin" class="grid" style="margin-top: 20%">
        <asp:TextBox runat="server" ID="tbEmail" CssClass="form-control" placeholder="Email"></asp:TextBox><br />
        <asp:TextBox runat="server" ID="tbPassword" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox><br />
        <asp:Button ID="btLogin" runat="server" Text="Login" type="submit" Width="48%" CssClass="btn btn-info" OnClick="btLogin_Click" />
        <asp:Button ID="btRecuperar" runat="server" Text="Recuperar Password" type="submit" Width="50%" CssClass="btn btn-danger" OnClick="btRecuperar_Click" /><br />
        <br />
        <asp:Label ID="lbErro" runat="server"></asp:Label>
        <br />
        <br />
    </div>
</asp:Content>
