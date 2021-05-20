using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TFG___Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            int id_user = bd.UsuarioAutenticado(TextBox1.Text, TextBox2.Text);

            if (id_user == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "Atenção", "alert('Usuário não autenticado!')", true);
                return;
            }

            if ((bd.EhGerente(id_user)))
            {
                Session["id_user"] = id_user;
                Session["gerente"] = true;
                Response.Redirect("PainelGerencial.aspx");
            }
            else
            {
                Session["id_user"] = id_user;
                Session["gerente"] = false;
                Response.Redirect("Painel.aspx");
            }
        }
    }
}