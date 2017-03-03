using System;
using System.Data;
using System.Web;

namespace Site_TrabalhoM17
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dados;
                HttpCookie cookie = Request.Cookies["ultimojogo"] as HttpCookie;
                try
                {
                    int id = int.Parse(cookie.Value);
                    dados = BaseDados.Instance.ListaLivrosComPrecoInferior(id);
                }
                catch
                {
                    dados = BaseDados.Instance.DevolveConsulta("SELECT id_jogo,nome,preco FROM Jogos WHERE estado=1");
                }
                AtualizaDivJogos(dados);
            }
        }

        public void AtualizaDivJogos(DataTable dados)
        {
            if (dados == null || dados.Rows.Count == 0)
            {
                divJogos.InnerHtml = "";
                return;
            }
            string grelha = "<div class='container-fluid'>";
            grelha += "<div class='row'>";
            foreach (DataRow jogo in dados.Rows)
            {
                grelha += "<div class='col-md-4 text-center'>";
                grelha += "<img width='225' height='200' src='/Imagens/" + jogo[0].ToString() + ".jpg'/>";
                grelha += "<span class='stat-title'>" + jogo[1].ToString() + "</span>";
                grelha += "<span class='stat-title'>" + string.Format(" | {0:C}", decimal.Parse(jogo["preco"].ToString())) + "</span>";
                grelha += "<br/><a href='detalhesjogo.aspx?id=" + jogo[0].ToString() + "'>Detalhes</a>";
                grelha += "</div>";
            }

            grelha += "</div></div>";
            divJogos.InnerHtml = grelha;
        }

        protected void btPesquisa_Click(object sender, EventArgs e)
        {
            string jogo = Session["pesquisaText"].ToString();
            DataTable dados = BaseDados.Instance.PesquisaJogosPeloNome(jogo);
            AtualizaDivJogos(dados);
        }

        protected void lbAcao_Click(object sender, EventArgs e)
        {
            DataTable dados;
            dados = BaseDados.Instance.ListarJogosAcao();
            AtualizaDivJogos(dados);
        }

        protected void lbAventura_Click(object sender, EventArgs e)
        {
            DataTable dados;
            dados = BaseDados.Instance.ListarJogosAventura();
            AtualizaDivJogos(dados);
        }

        protected void lbCasual_Click(object sender, EventArgs e)
        {
            DataTable dados;
            dados = BaseDados.Instance.ListarJogosCasual();
            AtualizaDivJogos(dados);
        }

        protected void lbIndie_Click(object sender, EventArgs e)
        {
            DataTable dados;
            dados = BaseDados.Instance.ListarJogosIndie();
            AtualizaDivJogos(dados);
        }

        protected void lbMMO_Click(object sender, EventArgs e)
        {
            DataTable dados;
            dados = BaseDados.Instance.ListarJogosMMO();
            AtualizaDivJogos(dados);
        }

        protected void lbCorrida_Click(object sender, EventArgs e)
        {
            DataTable dados;
            dados = BaseDados.Instance.ListarJogosCorrida();
            AtualizaDivJogos(dados);
        }

        protected void lbRPG_Click(object sender, EventArgs e)
        {
            DataTable dados;
            dados = BaseDados.Instance.ListarJogosRPG();
            AtualizaDivJogos(dados);
        }

        protected void lbEstrategia_Click(object sender, EventArgs e)
        {
            DataTable dados;
            dados = BaseDados.Instance.ListarJogosEstrategia();
            AtualizaDivJogos(dados);
        }

        protected void lbDemo_Click(object sender, EventArgs e)
        {
            DataTable dados;
            dados = BaseDados.Instance.ListarDemos();
            AtualizaDivJogos(dados);
        }

        protected void lbFTP_Click(object sender, EventArgs e)
        {
            DataTable dados;
            dados = BaseDados.Instance.ListarFreeToPlay();
            AtualizaDivJogos(dados);
        }
    }
}