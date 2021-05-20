using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TFG___Web
{
    public partial class Painel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((bool)Session["gerente"]) == true)
            {
                Response.Redirect("PainelGerencial.aspx");
                return;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produtos.aspx");
        }
    }
}