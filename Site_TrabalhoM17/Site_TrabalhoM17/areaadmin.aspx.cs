using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_TrabalhoM17
{
    public partial class areaadmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] == null || !Session["perfil"].Equals("0"))
                Response.Redirect("index.aspx");

            if (!IsPostBack)
            {
                divJogos.Visible = false;
                divUtilizadores.Visible = false;
                divConsultas.Visible = false;
            }

            gvJogos.PageSize = 5;
            gvJogos.PageIndexChanging += new GridViewPageEventHandler(gvJogos_PageIndexChanging);

            //grelha dos utilizadores
            gvUtilizadores.RowDeleting += new GridViewDeleteEventHandler(gvUtilizadores_RowDeleting);
            gvUtilizadores.RowEditing += new GridViewEditEventHandler(gvUtilizadores_RowEditing);
            gvUtilizadores.RowCancelingEdit += new GridViewCancelEditEventHandler(gvUtilizadores_RowCancelingEdit);
            gvUtilizadores.RowUpdating += new GridViewUpdateEventHandler(gvUtilizadores_RowUpdating);
            gvUtilizadores.RowCreated += new GridViewRowEventHandler(gvUtilizadores_RowCreated);
            gvUtilizadores.RowCommand += new GridViewCommandEventHandler(gvUtilizadores_RowCommand);

        }

        private void gvUtilizadores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int linha = int.Parse(e.CommandArgument as string);
            int id = int.Parse(gvUtilizadores.Rows[linha].Cells[3].Text);
            if (e.CommandName == "estado")
            {
                BaseDados.Instance.AtivarDesativarUtilizador(id);
                AtualizaGrelhaUtilizadores();
            }
            if (e.CommandName == "histórico")
            {
                Response.Redirect("historicoutilizador.aspx?id=" + id);
            }
        }

        private void gvUtilizadores_RowCreated(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell coluna in e.Row.Cells)
            {
                if (coluna.Text != "" && coluna.Text != "&nbsp;" && coluna.Text != "Ativar/Desativar"
                    && coluna.Text != "Histórico")
                {
                    BoundField campo = (BoundField)((DataControlFieldCell)coluna).ContainingField;
                    if (campo.DataField == "id" || campo.DataField == "estado" || campo.DataField == "perfil")
                        campo.ReadOnly = true;
                }
            }
        }

        private void gvUtilizadores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int linha = e.RowIndex;
            int id = int.Parse(gvUtilizadores.Rows[linha].Cells[3].Text);
            string email = ((TextBox)gvUtilizadores.Rows[linha].Cells[4].Controls[0]).Text;
            string nome = ((TextBox)gvUtilizadores.Rows[linha].Cells[3].Controls[0]).Text;
            string morada = ((TextBox)gvUtilizadores.Rows[linha].Cells[5].Controls[0]).Text;
            string nif = ((TextBox)gvUtilizadores.Rows[linha].Cells[6].Controls[0]).Text;
            BaseDados.Instance.AtualizarUtilizador(id, nome, email, morada, nif);

            gvUtilizadores.EditIndex = -1;
            AtualizaGrelhaUtilizadores();
        }

        private void gvUtilizadores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUtilizadores.EditIndex = -1;
            AtualizaGrelhaUtilizadores();
        }

        private void gvUtilizadores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int linha = e.NewEditIndex;
            gvUtilizadores.EditIndex = linha;
            AtualizaGrelhaUtilizadores();
        }

        private void gvUtilizadores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int linha = e.RowIndex;
            string id = gvUtilizadores.Rows[linha].Cells[3].Text;
            BaseDados.Instance.RemoverUtilizador(int.Parse(id));
            AtualizaGrelhaUtilizadores();
        }

        private void gvJogos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvJogos.PageIndex = e.NewPageIndex;
            AtualizaGrelhaJogos();
        }

        protected void btLJogos_Click(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            divJogos.Visible = true;
            divUtilizadores.Visible = false;
            divConsultas.Visible = false;
            btLJogos.CssClass = "btn btn-info active";
            btUtilizador.CssClass = "btn btn-info";
            btConsultas.CssClass = "btn btn-info";
            AtualizaGrelhaJogos();
        }

        protected void btUtilizador_Click(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            divJogos.Visible = false;
            divUtilizadores.Visible = true;
            divConsultas.Visible = false;
            btLJogos.CssClass = "btn btn-info";
            btUtilizador.CssClass = "btn btn-info active";
            btConsultas.CssClass = "btn btn-info";
            AtualizaGrelhaUtilizadores();
        }

        protected void btConsultas_Click(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            divJogos.Visible = false;
            divUtilizadores.Visible = false;
            divConsultas.Visible = true;
            btLJogos.CssClass = "btn btn-info";
            btUtilizador.CssClass = "btn btn-info";
            btConsultas.CssClass = "btn btn-info active";
        }

        protected void btAdicionarJogo_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeJogo = tbNomeJogo.Text;
                decimal preco = Decimal.Parse(tbPreco.Text);
                string descricao = tbDescricao.Text;
                decimal avaliacao = Decimal.Parse(tbAvaliacao.Text);
                string so = tbSo.Text;
                string empresa = tbEmpresa.Text;
                int stock = int.Parse(tbStock.Text);
                string tag = tbStock.Text;
                int ano = int.Parse(tbAno.Text);
                int estado = cbEstadoJogo.Checked == true ? 1 : 0;

                if (nomeJogo == String.Empty)
                    throw new Exception("Indique o nome do jogo");
                if (ano < 0 || ano > DateTime.Now.Year)
                    throw new Exception("O ano indicado não é válido.");
                if (preco < 0) throw new Exception("O preço não pode ser inferior a zero");
                //verificar se existe imagem
                if (fuCapa.HasFile == false) throw new Exception("Tem que indicar uma capa");
                int id = BaseDados.Instance.AdicionarJogo(nomeJogo, preco, descricao, avaliacao, so, empresa, stock, ano, estado, tag);
                //guardar imagem
                if (fuCapa.PostedFile.ContentLength > 0 &&
                    fuCapa.PostedFile.ContentType == "image/jpeg")
                {
                    string ficheiro = Server.MapPath(@"~\Imagens\");
                    ficheiro += id + ".jpg";
                    fuCapa.SaveAs(ficheiro);
                }

                tbNomeJogo.Text = "";
                tbPreco.Text = "";
                tbDescricao.Text = "";
                tbAvaliacao.Text = "";
                tbSo.Text = "";
                tbEmpresa.Text = "";
                tbStock.Text = "";
                tbAno.Text = "";

                AtualizaGrelhaJogos();
            }
            catch (Exception erro)
            {
                lbErroJogo.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErroJogo.CssClass = "alert alert-danger";
            }
        }

        protected void btAdicionarUtilizador_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = tbNomeUtilizador.Text;
                string email = tbEmail.Text;
                if (email.Contains("@") == false)
                    throw new Exception("O email indicado não é válido");
                string password = tbPassword.Text;
                string morada = tbMorada.Text;
                string nif = tbNIF.Text;
                int estado = cbEstado.Checked == true ? 1 : 0;
                int perfil = int.Parse(ddPerfil.SelectedValue);
                //guardar na bd
                BaseDados.Instance.RegistarUtilizador(nome, email, password, morada, nif, estado, perfil);
                //atualizar grelha
                AtualizaGrelhaUtilizadores();
                //limpar o form
                tbEmail.Text = "";
                tbNomeUtilizador.Text = "";
                tbMorada.Text = "";
                tbNIF.Text = "";
            }
            catch (Exception erro)
            {
                lbErroUtilizador.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErroUtilizador.CssClass = "alert alert-danger";
            }
        }

        private void AtualizaGrelhaUtilizadores()
        {
            gvUtilizadores.Columns.Clear();
            gvUtilizadores.DataSource = null;
            gvUtilizadores.DataBind();

            DataTable dados = BaseDados.Instance.ListaUtilizadoresDisponiveis();
            if (dados == null || dados.Rows.Count == 0) return;

            gvUtilizadores.DataSource = dados;
            gvUtilizadores.AutoGenerateColumns = true;
            gvUtilizadores.AutoGenerateEditButton = true;
            gvUtilizadores.AutoGenerateDeleteButton = true;

            //coluna para ativar/desativar
            ButtonField btEstado = new ButtonField();
            btEstado.HeaderText = "Ativar/Desativar";
            btEstado.Text = "Ativar/Desativar";
            btEstado.ButtonType = ButtonType.Button;
            btEstado.CommandName = "estado";
            gvUtilizadores.Columns.Add(btEstado);

            //coluna para ver histórico
            ButtonField btHistorico = new ButtonField();
            btHistorico.HeaderText = "Histórico";
            btHistorico.Text = "Histórico";
            btHistorico.ButtonType = ButtonType.Button;
            btHistorico.CommandName = "histórico";
            gvUtilizadores.Columns.Add(btHistorico);

            gvUtilizadores.DataBind();
        }

        protected void ddEscolhaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaGrelhaConsultas();
        }

        private void AtualizaGrelhaConsultas()
        {
            gvConsultas.Columns.Clear();
            int iconsulta = int.Parse(ddEscolhaConsulta.SelectedValue);
            DataTable dados;
            string sql = "";

            switch (iconsulta)
            {
                case 1:
                    sql = @"Select nome,avaliacao AS Avaliação
                            FROM Jogos
                            ORDER BY avaliacao DESC";
                    break;
                case 2:
                    sql = @"SELECT utilizadores.nome,count(*) as NºCompras
                            FROM utilizadores inner join Compras
                            ON utilizadores.id=compras.id_utilizador
                            GROUP by compras.id_utilizador,nome
                            ORDER by NºCompras DESC";
                    break;
                case 3:
                    sql = @"SELECT nome,estado
                            FROM Jogos
                            WHERE stock = 0";
                    break;
                case 4:
                    sql = @"Select nome,avaliacao
                            FROM Jogos
                            ORDER BY avaliacao DESC";
                    break;
            }
            dados = BaseDados.Instance.DevolveConsulta(sql);
            gvConsultas.DataSource = dados;
            gvConsultas.DataBind();

        }

        private void AtualizaGrelhaJogos()
        {
            gvJogos.Columns.Clear();
            gvJogos.DataSource = null;
            gvJogos.DataBind();

            DataTable dados = BaseDados.Instance.ListaJogos();
            if (dados == null || dados.Rows.Count == 0) return;

            DataColumn dcRemover = new DataColumn();
            dcRemover.ColumnName = "Remover";
            dcRemover.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcRemover);

            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);


            gvJogos.DataSource = dados;
            gvJogos.AutoGenerateColumns = false;

            HyperLinkField hlRemover = new HyperLinkField();
            hlRemover.HeaderText = "Remover";
            hlRemover.DataTextField = "Remover";
            hlRemover.Text = "Remover jogo";
            hlRemover.DataNavigateUrlFormatString = "removerjogo.aspx?id_jogo={0}";
            hlRemover.DataNavigateUrlFields = new string[] { "id_jogo" };
            gvJogos.Columns.Add(hlRemover);

            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";
            hlEditar.Text = "Editar jogo";
            hlEditar.DataNavigateUrlFormatString = "editarjogo.aspx?id_jogo={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "id_jogo" };
            gvJogos.Columns.Add(hlEditar);

            BoundField bfIdJogo = new BoundField();
            bfIdJogo.DataField = "id_jogo";
            bfIdJogo.HeaderText = "NºJogo";
            gvJogos.Columns.Add(bfIdJogo);

            BoundField bfNome = new BoundField();
            bfNome.DataField = "nome";
            bfNome.HeaderText = "Nome";
            gvJogos.Columns.Add(bfNome);

            BoundField bfPreco = new BoundField();
            bfPreco.DataField = "preco";
            bfPreco.HeaderText = "Preço";
            gvJogos.Columns.Add(bfPreco);

            BoundField bfDescricao = new BoundField();
            bfDescricao.DataField = "descricao";
            bfDescricao.HeaderText = "Descrição";
            gvJogos.Columns.Add(bfDescricao);

            BoundField bfAvaliacao = new BoundField();
            bfAvaliacao.DataField = "avaliacao";
            bfAvaliacao.HeaderText = "Avaliação";
            gvJogos.Columns.Add(bfAvaliacao);

            BoundField bfSo = new BoundField();
            bfSo.DataField = "sistema_operativo";
            bfSo.HeaderText = "Sistema Operativo";
            gvJogos.Columns.Add(bfSo);

            BoundField bfTag = new BoundField();
            bfTag.DataField = "tag";
            bfTag.HeaderText = "Tag";
            gvJogos.Columns.Add(bfTag);

            BoundField bfEmpresa = new BoundField();
            bfEmpresa.DataField = "empresa";
            bfEmpresa.HeaderText = "Empresa";
            gvJogos.Columns.Add(bfEmpresa);

            BoundField bfStock = new BoundField();
            bfStock.DataField = "stock";
            bfStock.HeaderText = "Stock";
            gvJogos.Columns.Add(bfStock);

            BoundField bfAno = new BoundField();
            bfAno.DataField = "ano";
            bfAno.HeaderText = "Ano";
            gvJogos.Columns.Add(bfAno);

            BoundField bfEstado = new BoundField();
            bfEstado.DataField = "estado";
            bfEstado.HeaderText = "Estado";
            gvJogos.Columns.Add(bfEstado);

            //capa
            ImageField ifCapa = new ImageField();
            ifCapa.HeaderText = "Capa";
            int rand = new Random().Next(999999999);
            ifCapa.DataImageUrlFormatString = "~/Imagens/{0}.jpg?" + rand;
            ifCapa.DataImageUrlField = "id_jogo";
            ifCapa.ControlStyle.Width = 100;
            gvJogos.Columns.Add(ifCapa);

            //databind
            gvJogos.DataBind();
        }
    }
}