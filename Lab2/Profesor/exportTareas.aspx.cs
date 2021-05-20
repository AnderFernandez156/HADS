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
    public partial class exportTareas : System.Web.UI.Page
    {
        private DataTable tareas;
        DataView view;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList1.DataTextField = "codigoasig";
                DropDownList1.DataValueField = "codigoasig";
                DropDownList1.DataSource = Funcionalidades.Class1.getAsignaturas(Session["UserName"].ToString());
                DropDownList1.DataBind();
                
            }
            tareas = Funcionalidades.Class1.getTareasGenericas();
            view = new DataView(tareas);
            string codigo = DropDownList1.SelectedValue;
            view.RowFilter = $"(CodAsig = '{codigo}')";
            GridView1.DataSource = view;
            GridView1.DataBind();
            

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string codigo = DropDownList1.SelectedValue;
            view.RowFilter = $"(CodAsig = '{codigo}')";
            GridView1.DataSource = view;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = Funcionalidades.Class1.TareasGenericasAdapterCodigo(DropDownList1.SelectedValue);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "tareas");
            string guardado = Server.MapPath("../APP_DATA/" + DropDownList1.SelectedValue + ".xml");
            dataset.DataSetName = "tareas";
            dataset.Tables[0].TableName ="tarea" ;
            dataset.Tables[0].Columns["Codigo"].ColumnName = "codigo";
            dataset.Tables[0].Columns["Descripcion"].ColumnName = "descripcion";
            dataset.Tables[0].Columns["CodAsig"].ColumnName = "codasig";
            dataset.Tables[0].Columns["HEstimadas"].ColumnName = "hestimadas";
            dataset.Tables[0].Columns["Explotacion"].ColumnName = "explotacion";
            dataset.Tables[0].Columns["TipoTarea"].ColumnName = "tipotarea";
            dataset.Tables[0].Columns[0].ColumnMapping = MappingType.Attribute;
            dataset.Tables[0].WriteXml(guardado);
            Label3.Text = "guardado en el servidor";
        }
    }
}