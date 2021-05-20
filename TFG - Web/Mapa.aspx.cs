using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace TFG___Web
{
    public partial class Mapa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public string SalvarCoordenadas(string dados)
        {
            Banco bd = new Banco();

            try
            {
               /* if (Session["id_local"] == null)
                {
                    //bd.CadastraLocal(Session["nome_local"].ToString(), dados);
                }
                else
                {
                    bd.DeletaCoordenadas((int)(Session["id_local"]));
                    //bd.CadastraCoordenadas(((int)(Session["id_local"])), dados);
                }*/
            }
            catch
            {
                return "0";
            }

            return "Sucesso!";
        }
    }
}