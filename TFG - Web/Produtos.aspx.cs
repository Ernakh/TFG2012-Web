using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TFG___Web
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id_user"] == null || (int)(Session["id_user"]) == 0)
            {
                Session.Abandon();
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "Atenção", "alert('Usuario não autenticado!'), document.location.href = 'Login.aspx';", true);
                return;
            }

            Banco bd = new Banco();

            DataSet dsLocais = new DataSet();
            DataSet dsCategorias = new DataSet();

            dsLocais = bd.executeQuery("select * from locais");
            dsCategorias = bd.executeQuery("select * from categorias");

            for (int i = 0; i < dsLocais.Tables[0].Rows.Count; i++)
            {
                CheckBox chk = new CheckBox();
                chk.ID = "_" + dsLocais.Tables[0].Rows[i][0].ToString();
                chk.Text = dsLocais.Tables[0].Rows[i][1].ToString();

                locais.Controls.Add(chk);
            }

            for (int i = 0; i < dsCategorias.Tables[0].Rows.Count; i++)
            {
                CheckBox chk = new CheckBox();
                chk.ID = dsCategorias.Tables[0].Rows[i][0].ToString();
                chk.Text = dsCategorias.Tables[0].Rows[i][1].ToString();

                categorias.Controls.Add(chk);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Painel.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<int> lCategorias = new List<int>();
            List<int> lLocais = new List<int>();

            foreach (Control x in categorias.Controls)
            {
                if (x is CheckBox)
                {
                    if (((CheckBox)x).Checked)
                    {
                        lCategorias.Add(int.Parse(x.ID));
                    }
                }
            }

            foreach (Control x in locais.Controls)
            {
                if (x is CheckBox)
                {
                    if (((CheckBox)x).Checked)
                    {
                        lLocais.Add(int.Parse(x.ID.Substring(1)));
                    }
                }
            }

            try
            {
                Banco bd = new Banco();
                int x = bd.gravaProduto(TextBox1.Text, TextBox2.Text, TextBox3.Text);

                foreach (int item in lCategorias)
                {
                    bd.cadastraPxC(x, item);
                }

                foreach (int item in lLocais)
                {
                    bd.cadastraPxL(x, item);
                }

                Page.ClientScript.RegisterClientScriptBlock(GetType(), "Atenção", "alert('Produto cadastrado com Sucesso!'), document.location.href = 'PainelGerencial.aspx';", true);
                return;
            }
            catch
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "Atenção", "alert('ERRO!!')", true);
            }
        }
    }
}