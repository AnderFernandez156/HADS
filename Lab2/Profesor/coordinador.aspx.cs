using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class coordinador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HorasMediasService.horasMediasSoapClient service = new HorasMediasService.horasMediasSoapClient();
            int horas = service.getHorasMedias(DropDownList1.SelectedValue);
            Label3.Text = horas.ToString();
        }
    }
}