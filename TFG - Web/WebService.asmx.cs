using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TFG___Web
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(EnableSession = true)]
        public string SalvarCoordenadas(string dados)
        {
            string[] x = dados.Split('&');

            List<string> coordenadas = new List<string>();

            for (int i = 0; i < x.Length; i = i + 2)
            {
                coordenadas.Add(x[i].Substring(5) + ";" + x[i+1].Substring(6));
            }

            Banco bd = new Banco();

            try
            {
                if (Session["id_local"] == null)
                {
                    if (bd.CadastraLocal(Session["nome_local"].ToString(), coordenadas))
                    {
                        return "true";
                    }
                }
                else
                {
                    bd.DeletaCoordenadas((int)(Session["id_local"]));
                    //bd.CadastraCoordenadas(((int)(Session["id_local"])), coordenadas);
                }
            }
            catch
            {
                return "0";
            }

            return "Sucesso!";
        }
    }
}
