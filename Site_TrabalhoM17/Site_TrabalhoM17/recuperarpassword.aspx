<%@ Page Title="" Language="C#" MasterPageFile="~/mP.Master" AutoEventWireup="true" CodeBehind="recuperarpassword.aspx.cs" Inherits="Site_TrabalhoM17.recuperarpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group" style="margin-top:10%">
        <label for="tbPassword">Nova Password</label>
        <asp:TextBox runat="server" ID="tbPassword" TextMode="Password" CssClass="form-control" /><br />
        <asp:Button runat="server" ID="btPassword" Text="Atualizar" CssClass="btn btn-info" OnClick="btPassword_Click" />
        <asp:Label runat="server" ID="lbErro"></asp:Label>
    </div>
</asp:Content>
