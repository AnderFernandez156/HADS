using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class InsertarTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Funcionalidades.Class1.conectar();
            
            
            if (Funcionalidades.Class1.existeTarea(TextBox1.Text) == true)
            {
                Label6.Text = "YA EXISTE UNA TAREA CON ESE CODIGO";
            }
            else {
                if (Funcionalidades.Class1.updateTable(TextBox1.Text, TextBox2.Text, DropDownList1.SelectedValue, Convert.ToInt32(TextBox3.Text), DropDownList2.SelectedValue))
                {
                    Label6.Text = "SE HA INCLUIDO LA TAREA";
                    
                }
                else {
                    Label6.Text = "ERROR AL INCLUIR LA TAREA";
                }
            }
            Funcionalidades.Class1.desconectar();
        }
    }
}