using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TFG___Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((bool)Session["gerente"]) == false)
            {
                Session.Abandon();
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "Atenção", "alert('Usuario não é gerente!'), document.location.href = 'Login.aspx';", true);
                return;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("PainelGerencial.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            if (bd.CadastraUsuario(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, RadioButton1.Checked?true:false))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "Atenção", "alert('Usuario cadastrado!'), document.location.href = 'PainelGerencial.aspx';", true);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "Atenção", "alert('Falha!')", true);
            }
        }
    }
}