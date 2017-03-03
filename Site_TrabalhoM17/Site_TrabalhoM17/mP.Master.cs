using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_TrabalhoM17
{
    public partial class mP : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Guid g = Guid.NewGuid();

            HttpCookie cookie = new HttpCookie("avisoT1", g.ToString());
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);
            div_aviso.Visible = false;
        }

        protected void tbPesquisa_TextChanged(object sender, EventArgs e)
        {
            Session["pesquisaText"] = tbPesquisa.Text;
        }
    }
}