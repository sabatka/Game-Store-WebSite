<%@ Page Title="" Language="C#" MasterPageFile="~/mP.Master" AutoEventWireup="true" CodeBehind="areaadmin.aspx.cs" Inherits="Site_TrabalhoM17.areaadmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top:9%">
        <h1>Área admin</h1>
        <div class="btn-group">
            <asp:Button runat="server" ID="btLJogos" Text="Gerir Jogos" CssClass="btn btn-info" OnClick="btLJogos_Click" />
            <asp:Button runat="server" ID="btUtilizador" Text="Gerir Utilizadores" CssClass="btn btn-info" OnClick="btUtilizador_Click" />
            <asp:Button runat="server" ID="btConsultas" Text="Consultas" CssClass="btn btn-info" OnClick="btConsultas_Click" />
        </div>
        <div id="divJogos" runat="server">
            <h2>Jogos</h2>
            <asp:GridView runat="server" ID="gvJogos" CssClass="table table-responsive"></asp:GridView>
            <h3>Adicionar</h3>
            <div class="form-group">
                <label for="tbNomeJogo">Nome</label>
                <asp:TextBox runat="server" ID="tbNomeJogo" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="tbPreco">Preço</label>
                <asp:TextBox runat="server" ID="tbPreco" CssClass="form-control"></asp:TextBox>
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
                <label for="tbSo">Sistema Operativo</label>
                <asp:TextBox runat="server" ID="tbSo" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="tbTag">Tags</label>
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
                <label for="cbEstadoJogo">Estado</label>
                <asp:CheckBox runat="server" ID="cbEstadoJogo" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="fuCapa">Capa</label>
                <asp:FileUpload runat="server" ID="fuCapa" CssClass="form-control" />
            </div>
            <asp:Button runat="server" ID="btAdicionarJogo" Text="Adicionar" CssClass="btn btn-info" OnClick="btAdicionarJogo_Click" />
            <asp:Label runat="server" ID="lbErroJogo"></asp:Label>
        </div>
        <div id="divUtilizadores" runat="server">
            <h2>Utilizadores</h2>
            <asp:GridView runat="server" ID="gvUtilizadores" CssClass="table table-responsive"></asp:GridView>
            <h3>Adicionar</h3>
            <div class="form-group">
                <label for="tbNomeUtilizador">Nome</label>
                <asp:TextBox runat="server" ID="tbNomeUtilizador" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="tbEmail">Email</label>
                <asp:TextBox runat="server" ID="tbEmail" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="tbPassword">Password</label>
                <asp:TextBox runat="server" ID="tbPassword" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="tbMorada">Morada</label>
                <asp:TextBox runat="server" ID="tbMorada" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="tbNIF">NIF</label>
                <asp:TextBox runat="server" ID="tbNIF" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="cbEstado">Estado</label>
                <asp:CheckBox runat="server" ID="cbEstado" CssClass="form-control"></asp:CheckBox>
            </div>
            <div class="form-group">
                <label for="ddPerfil">Perfil</label>
                <asp:DropDownList runat="server" ID="ddPerfil" CssClass="form-control">
                    <asp:ListItem Value="0">Administrador</asp:ListItem>
                    <asp:ListItem Value="1" Selected="True">Utilizador</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Button OnClick="btAdicionarUtilizador_Click" runat="server" ID="btAdicionarUtilizador" Text="Adicionar" CssClass="btn btn-success" />
            <asp:Label runat="server" ID="lbErroUtilizador"></asp:Label>
        </div>
        <div id="divConsultas" runat="server"><br />
            <asp:DropDownList CssClass="form-control" runat="server" ID="ddEscolhaConsulta" AutoPostBack="true" OnSelectedIndexChanged="ddEscolhaConsulta_SelectedIndexChanged">
                <asp:ListItem Value="1">Jogos com a melhor avaliação</asp:ListItem>
                <asp:ListItem Value="2">Cliente que comprou mais jogos</asp:ListItem>
                <asp:ListItem Value="3">Jogos sem stock</asp:ListItem>
                <asp:ListItem Value="4">Jogos Com a pior avaliação</asp:ListItem>
            </asp:DropDownList>
            <asp:GridView CssClass="table table-responsive" ID="gvConsultas" runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>
