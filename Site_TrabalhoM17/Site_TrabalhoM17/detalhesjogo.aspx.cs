using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_TrabalhoM17
{
    public partial class detalhesjogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"]);
                DataTable dados = BaseDados.Instance.DevolveDadosJogo(id);
                lbNome.Text = "Nome: " + dados.Rows[0]["nome"].ToString();
                lbPreco.Text = "Preço: " + string.Format(" {0:C}", decimal.Parse(dados.Rows[0]["preco"].ToString()));
                lbDescricao.Text = "Descrição: " + dados.Rows[0]["descricao"].ToString();
                lbAvaliacao.Text = "Avaliação: " + dados.Rows[0]["avaliacao"].ToString();
                lbSo.Text = "Sistema Operativo: " + dados.Rows[0]["sistema_operativo"].ToString();
                lbEmpresa.Text = "Empresa: " + dados.Rows[0]["empresa"].ToString();
                lbStock.Text = "Stock: " + dados.Rows[0]["stock"].ToString();
                lbAno.Text = "Ano de Lançamento: " + dados.Rows[0]["ano"].ToString();
                string ficheiro = @"~\Imagens\" + dados.Rows[0]["id_jogo"].ToString() + ".jpg";
                imgCapa.ImageUrl = ficheiro;
                imgCapa.Height = 200;
                imgCapa.Width = 200;
                //criar cookie com o id do livro
                HttpCookie cookie = new HttpCookie("ultimojogo", id.ToString());
                cookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(cookie);
            }
            catch
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btCarrinho_Click(object sender, EventArgs e)
        {
            string id = Request["id"];
            Session["produtos"] += (id + ",");
        }
    }
}