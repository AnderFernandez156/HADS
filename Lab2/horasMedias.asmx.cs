using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Lab2
{
    /// <summary>
    /// Summary description for horasMedias
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class horasMedias : System.Web.Services.WebService
    {

        [WebMethod]
        public int getHorasMedias(string asignatura)
        {
            Funcionalidades.Class1.conectar();
            int horasmedias = Funcionalidades.Class1.getHorasMedias(asignatura);
            Funcionalidades.Class1.desconectar();
            return horasmedias;
        }
    }
}
