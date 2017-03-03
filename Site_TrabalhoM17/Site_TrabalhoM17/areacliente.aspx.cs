using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_TrabalhoM17
{
    public partial class areacliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] == null)
                Response.Redirect("index.aspx");
            //verificar se é a primeira vez que a página é pedida
            if (!IsPostBack)
            {
                divEncomendas.Visible = false;
                divCarrinho.Visible = false;
            }
            //eventos
            gvEncomendas.RowCommand += new GridViewCommandEventHandler(gvEncomendas_RowCommand);
        }

        private void gvComprar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        private void gvEncomendas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        private void AtualizaGrelhaCarrinho()
        {

        }

        protected void btEncomendas_Click(object sender, EventArgs e)
        {

        }

        private void AtualizaGrelhaEncomendas()
        {
        }

        protected void btConfirmar_Click(object sender, EventArgs e)
        {
            if (Session["produtos"].ToString() != "")
            {
                BaseDados.Instance.Compra(Session["produtos"].ToString(), int.Parse(Session["id"].ToString()));
                Response.Redirect("index.aspx");
                Session["produtos"] = "";
            }
        }

        public DataTable GetProdutosCarrinho(int id)
        {
            return BaseDados.Instance.GetProdutosCarrinho(id);
        }

        protected void btCarrinho_Click(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            divEncomendas.Visible = false;
            divCarrinho.Visible = true;
            btEncomendas.CssClass = "btn btn-info";
            btCarrinho.CssClass = "btn btn-info active";
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            Session["produtos"] = "";
            Response.Redirect("areacliente.aspx");
        }
    }
}