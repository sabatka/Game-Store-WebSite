<%@ Page Title="" Language="C#" MasterPageFile="~/mP.Master" AutoEventWireup="true" CodeBehind="areacliente.aspx.cs" Inherits="Site_TrabalhoM17.areacliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 10%">
        <h1>Área Cliente</h1>
        <div class="btn-group">
            <%
                if (Session["produtos"].ToString() != "")
                {%>
            <asp:Button runat="server" ID="btCarrinho" Text="Carrinho" CssClass="btn btn-info" OnClick="btCarrinho_Click" />
            <%}
            %>

            <asp:Button runat="server" ID="btEncomendas" Text="Encomendas" CssClass="btn btn-info" OnClick="btEncomendas_Click" />
        </div>
        <div id="divCarrinho" runat="server">
            <h2>Jogos a comprar</h2>
            <%
                string produtos = Session["produtos"].ToString();
                string produtosSemBug = produtos.Remove(produtos.Length - 1);
                string[] produtosArray = produtosSemBug.Split(',');
                foreach (var item in produtosArray)
                {
                    if (GetProdutosCarrinho(int.Parse(item)) == null || GetProdutosCarrinho(int.Parse(item)).Rows.Count == 0)
                    {
                        Response.Write("Este produto não tem comentários!");
                        return;
                    }
                    foreach (System.Data.DataRow jogos in GetProdutosCarrinho(int.Parse(item.ToString())).Rows)
                    {
            %>
            <div class="col-sm-2 col-lg-2 col-md-2">
                <div class="thumbnail">
                    <img src="/Imagens/<% Response.Write(jogos["id_jogo"].ToString() + ".jpg"); %>" alt="" class="img-responsive">
                    <div class="caption">
                        <h4 class="pull-right"><% Response.Write(String.Format("{0:C}", Decimal.Parse(jogos["preco"].ToString()))); %></h4>
                        <h4><%Response.Write(jogos["nome"].ToString()); %>
                        </h4>
                        <p><% Response.Write(jogos["descricao"].ToString()); %></p>

                    </div>
                </div>
            </div>
            <%
                    }
                }
            %>
            <asp:Button runat="server" ID="btConfirmar" Text="Confirmar compras" CssClass="btn btn-info" OnClick="btConfirmar_Click" />
            <asp:Button runat="server" ID="btCancelar" Text="Cancelar compras" CssClass="btn btn-info" OnClick="btCancelar_Click" />
        </div>
    <div id="divEncomendas" runat="server">
        <h2>Encomendas</h2>
        <asp:GridView runat="server" ID="gvEncomendas" CssClass="table table-responsive"></asp:GridView>
    </div>
    </div>
</asp:Content>
