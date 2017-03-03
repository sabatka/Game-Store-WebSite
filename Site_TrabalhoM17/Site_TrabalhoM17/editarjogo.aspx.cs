using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_TrabalhoM17
{
    public partial class editarjogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] == null || !Session["perfil"].Equals("0"))
                Response.Redirect("index.aspx");
            //dados do livro
            if (!IsPostBack)
            {
                try
                {
                    int id_jogo = int.Parse(Request["id_jogo"].ToString());
                    DataTable dados = BaseDados.Instance.DevolveDadosJogo(id_jogo);
                    if (dados == null || dados.Rows.Count == 0)
                        throw new Exception("Erro");
                    tbNomeJogo.Text = dados.Rows[0]["nome"].ToString();
                    tbPreco.Text = string.Format("{0}", decimal.Parse(dados.Rows[0]["preco"].ToString()));
                    tbDescricao.Text = dados.Rows[0]["descricao"].ToString();
                    tbAvaliacao.Text = dados.Rows[0]["avaliacao"].ToString();
                    tbData.Text = DateTime.Parse(dados.Rows[0]["data_registo"].ToString()).ToShortDateString();
                    tbSo.Text = dados.Rows[0]["sistema_operativo"].ToString();
                    tbEmpresa.Text = dados.Rows[0]["empresa"].ToString();
                    tbStock.Text = dados.Rows[0]["stock"].ToString();
                    tbAno.Text = dados.Rows[0]["ano"].ToString();
                    cbEstado.Checked = Convert.ToBoolean(dados.Rows[0]["estado"]);
                    tbTag.Text = dados.Rows[0]["tag"].ToString();

                    //capa
                    string ficheiro = @"~\Imagens\" + dados.Rows[0]["id_jogo"].ToString() + ".jpg";
                    imgCapa.ImageUrl = ficheiro;
                    imgCapa.Width = 100;
                }
                catch (Exception error)
                {
                    Response.Redirect("areaadmin.aspx");
                }
            }
        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("areaadmin.aspx");
        }

        protected void btAtualizarJogo_Click(object sender, EventArgs e)
        {
            int id_jogo = int.Parse(Request["id_jogo"].ToString());
            string nome = tbNomeJogo.Text;
            decimal preco = Decimal.Parse(tbPreco.Text);
            string descricao = tbDescricao.Text;
            decimal avaliacao = Decimal.Parse(tbAvaliacao.Text);
            DateTime data = DateTime.Now;
            string so = tbSo.Text;
            string empresa = tbEmpresa.Text;
            int stock = int.Parse(tbStock.Text);
            int ano = int.Parse(tbAno.Text);
            int estado = cbEstado.Checked == true ? 1 : 0;
            string tag = tbTag.Text;

            BaseDados.Instance.AtualizaJogo(id_jogo, nome, preco, descricao, avaliacao, data, so, empresa, stock, ano, estado,tag);
            if (fuCapa.HasFile)
            {
                if (fuCapa.PostedFile.ContentLength > 0 && fuCapa.PostedFile.ContentType == "image/jpeg")
                {
                    string ficheiro = Server.MapPath(@"~\Imagens\" + id_jogo + ".jpg");
                    fuCapa.SaveAs(ficheiro);
                }
            }
            Response.Redirect("areaadmin.aspx");
        }
    }
}