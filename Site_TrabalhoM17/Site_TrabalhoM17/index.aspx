<%@ Page Title="" Language="C#" MasterPageFile="~/mP.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Site_TrabalhoM17.index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <nav class="navbar navbar-inverse navbar-fixed-bottom" role="navigation">
            <!-- Sidebar Menu Items - These collapse to the responsive navigation menu on small screens -->
            <div class="collapse navbar-collapse navbar-ex1-collapse">
                <ul class="nav navbar-nav side-nav">
                    <li class="active">
                        <a href="index.aspx"><i class=""></i>Página Inicial</a>
                    </li>
                    <li>
                        <a href="javascript:;" data-toggle="collapse" data-target="#generos"><i class=""></i>
                            Géneros <i class="fa fa-fw fa-caret-down"></i></a>
                        <ul id="generos" class="collapse">
                            <li>
                                <asp:LinkButton runat="server" ID="lbAcao" OnClick="lbAcao_Click">Ação</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton runat="server" ID="lbAventura" OnClick="lbAventura_Click">Aventura</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton runat="server" ID="lbCasual" OnClick="lbCasual_Click">Casual</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton runat="server" ID="lbIndie" OnClick="lbIndie_Click">Indie</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton runat="server" ID="lbMMO" OnClick="lbMMO_Click">MMO</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton runat="server" ID="lbCorrida" OnClick="lbCorrida_Click">Corrida</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton runat="server" ID="lbRPG" OnClick="lbRPG_Click">RPG</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton runat="server" ID="lbEstrategia" OnClick="lbEstrategia_Click">Estratégia</asp:LinkButton>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="javascript:;" data-toggle="collapse" data-target="#ftp"><i class=""></i>
                            Free to play <i class="fa fa-fw fa-caret-down"></i></a>
                        <ul id="ftp" class="collapse">
                            <li>
                                <asp:LinkButton runat="server" ID="lbFTP" OnClick="lbFTP_Click" >Free to play</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton runat="server" ID="lbDemo" OnClick="lbDemo_Click">Demo</asp:LinkButton>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </nav>
    </div>
    <div>
        <span class="input-group-btn">
            <asp:Button ID="btPesquisa" Width="0" Height="0" CssClass="hidden" runat="server" OnClick="btPesquisa_Click" />
        </span>
    </div>
    <div id="divJogos" runat="server" class="pull-left col-md-9" style="margin-top: 20%"></div>
</asp:Content>
