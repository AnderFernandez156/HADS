using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class TareasAlumnos : System.Web.UI.Page
    {
        DataTable tareas;
        DataTable asignaturas;
        string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Funcionalidades.Class1.conectar();
                email = Session["UserName"].ToString();
                //Muestra las asignaturas disponibles
                asignaturas = Funcionalidades.Class1.getAsignaturasAlumnos(email);
                DropDownList1.DataTextField = "codigoasig";
                DropDownList1.DataValueField = "codigoasig";
                DropDownList1.DataSource = asignaturas;
                DropDownList1.DataBind();

                //Muestra las tareas genericas
                string asignatura = DropDownList1.SelectedValue;
                tareas = Funcionalidades.Class1.getTareasGenericas();
                Session["tareas"] = tareas;
                DataView dv = new DataView(tareas);
                dv.RowFilter = $"(CodAsig = '{asignatura}' and Explotacion=1)";
                
                GridView1.DataSource = dv;

                GridView1.DataBind();
                Funcionalidades.Class1.desconectar();
            }
            else {
                tareas = (DataTable)Session["tareas"] ;
            }
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string asignatura = DropDownList1.SelectedValue;
            DataTable temp = (DataTable)Session["tareas"];
            DataView dv = new DataView(temp);
            dv.RowFilter = $"(CodAsig = '{asignatura}' and Explotacion=1)";
            if (dv.Count == 0)
            {
                Label2.Text = "No hay tareas";
            }
            else { Label2.Text = ""; }
            GridView1.DataSource = dv;
            GridView1.DataBind();
            
            

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codigo = GridView1.SelectedRow.Cells[1].Text;
            string horas = GridView1.SelectedRow.Cells[4].Text;

            Response.Redirect($"InstanciarTarea.aspx?codigo={codigo}&horas={horas}");
        }
    }
}