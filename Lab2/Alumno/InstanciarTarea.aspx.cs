using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class InstanciarTarea : System.Web.UI.Page
    {
        DataSet tareas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Funcionalidades.Class1.conectar();
                string tarea = Request.QueryString["codigo"];
                string horas = Request.QueryString["horas"];
                TextBox1.Text = Session["UserName"].ToString();
                TextBox2.Text = tarea;
                TextBox3.Text = horas;
                tareas = Funcionalidades.Class1.getInstancias(TextBox1.Text);
                Session["instancias"] = tareas;
                GridView1.DataSource = tareas.Tables[0];
                GridView1.DataBind();
                Funcionalidades.Class1.desconectar();
            }
            else {
                tareas = (DataSet)Session["instancias"];
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string horas = TextBox4.Text;
            if (horas == "")
            {
                Label6.Text = "HORAS INVALIDAS";
            }
            else {
                Funcionalidades.Class1.conectar();
                bool a = Funcionalidades.Class1.Instanciar(TextBox1.Text, TextBox2.Text, Convert.ToInt32(TextBox3.Text), Convert.ToInt32(TextBox4.Text),(DataSet)Session["instancias"]);
                if (a)
                {
                    DataTable datatable = tareas.Tables[0];
                    DataRow row = datatable.NewRow();
                    row[0] = TextBox1.Text;
                    row[1] = TextBox2.Text;
                    row[2] = TextBox3.Text;
                    row[3] = TextBox4.Text;
                    datatable.Rows.Add(row);
                    GridView1.DataSource = datatable;
                    GridView1.DataBind();
                    Label6.Text = "SE HA INSTANCIADO SIN PROBLEMAS";
                }
                else { Label6.Text = "YA HAS INSTANCIADO LA TAREA"; }
                Funcionalidades.Class1.desconectar();
            }
        }
    }
}