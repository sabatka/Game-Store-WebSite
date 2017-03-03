using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_TrabalhoM17
{
    public partial class removerjogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] == null || !Session["perfil"].Equals("0"))
                Response.Redirect("index.aspx");

            if (!IsPostBack)
            {
                try
                {
                    int id_jogo = int.Parse(Request["id_jogo"].ToString());
                    DataTable dados = BaseDados.Instance.DevolveDadosJogo(id_jogo);
                    if (dados == null || dados.Rows.Count == 0)
                        throw new Exception("Erro");
                    lbNome.Text = dados.Rows[0]["nome"].ToString();
                    lbPreco.Text = String.Format("{0:C}", Decimal.Parse(dados.Rows[0]["preco"].ToString()));
                    lbDescricao.Text = dados.Rows[0]["descricao"].ToString();
                    lbAvaliacao.Text = dados.Rows[0]["avaliacao"].ToString();
                    lbData.Text = DateTime.Parse(dados.Rows[0]["data_registo"].ToString()).ToShortDateString();
                    lbSo.Text = dados.Rows[0]["sistema_operativo"].ToString();
                    lbEmpresa.Text = dados.Rows[0]["empresa"].ToString();
                    lbStock.Text = dados.Rows[0]["stock"].ToString();
                    lbAno.Text = dados.Rows[0]["ano"].ToString();
                    lbEstado.Text = dados.Rows[0]["estado"].ToString();
                    //capa
                    string ficheiro = @"~\Imagens\" + dados.Rows[0]["id_jogo"].ToString() + ".jpg";
                    imgCapa.ImageUrl = ficheiro;
                    imgCapa.Width = 100;
                }
                catch
                {
                    Response.Redirect("areaadmin.aspx");
                }
            }

        }

        protected void btEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id_jogo = int.Parse(Request["id_jogo"].ToString());
                BaseDados.Instance.RemoverJogo(id_jogo);
                //apagar ficheiro
                string ficheiro = Server.MapPath(@"~\Imagens\" + id_jogo + ".jpg");
                File.Delete(ficheiro);
            }
            catch
            {

            }
            Response.Redirect("areaadmin.aspx");
        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("areaadmin.aspx");
        }
    }
}