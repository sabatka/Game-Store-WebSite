<%@ Page Title="" Language="C#" MasterPageFile="~/mP.Master" AutoEventWireup="true" CodeBehind="editarjogo.aspx.cs" Inherits="Site_TrabalhoM17.editarjogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 10%">
        <h1>Editar Jogo</h1>
        <div class="form-group">
            <label for="tbNomeJogo">Nome</label>
            <asp:TextBox runat="server" ID="tbNomeJogo" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbPreco">Preço</label>
            <div class="input-group">
                <span class="input-group-addon" id="basic-addon1">€</span>
                <asp:TextBox runat="server" ID="tbPreco" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="tbDescricao">Descrição</label>
            <asp:TextBox runat="server" ID="tbDescricao" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbAvaliacao">Avaliação</label>
            <asp:TextBox runat="server" ID="tbAvaliacao" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbData">Data Aquisição</label>
            <asp:TextBox runat="server" ID="tbData" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbSo">Sistema Operativo</label>
            <asp:TextBox runat="server" ID="tbSo" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbTag">Tag</label>
            <asp:TextBox runat="server" ID="tbTag" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbEmpresa">Empresa</label>
            <asp:TextBox runat="server" ID="tbEmpresa" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbStock">Stock</label>
            <asp:TextBox runat="server" ID="tbStock" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbAno">Ano</label>
            <asp:TextBox runat="server" ID="tbAno" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="cbEstado">Estado</label>
            <asp:CheckBox runat="server" ID="cbEstado" CssClass="form-control"></asp:CheckBox>
        </div>
        <asp:Image ID="imgCapa" runat="server" Width="100" /><br />
        <div class="form-group">
            <label for="fuCapa">Capa</label>
            <asp:FileUpload runat="server" ID="fuCapa" CssClass="form-control" />
        </div>
        <asp:Button runat="server" ID="btAtualizarJogo" Text="Atualizar" CssClass="btn btn-success" OnClick="btAtualizarJogo_Click" />
        <asp:Button runat="server" ID="btVoltar" Text="Voltar" CssClass="btn btn-info" OnClick="btVoltar_Click" />
        <asp:Label runat="server" ID="lbErroJogo"></asp:Label>
    </div>
</asp:Content>
