using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_TrabalhoM17
{
    public partial class recuperarpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btPassword_Click(object sender, EventArgs e)
        {
            try
            {
                //guid
                string guid = Server.UrlDecode(Request["id"].ToString());
                //atualizar a password
                string novaPassword = tbPassword.Text;
                if (novaPassword == string.Empty)
                    throw new Exception("tem de preencher a senha.");
                if (novaPassword.Length < 3)
                    throw new Exception("a password é muito pequena.");
                BaseDados.Instance.AtualizarPassword(guid, novaPassword);
                Response.Redirect("index.aspx");
            }
            catch (Exception erro)
            {
                lbErro.CssClass = "alert alert-danger";
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
            }
        }
    }
}