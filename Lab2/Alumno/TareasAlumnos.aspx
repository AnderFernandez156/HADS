<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TareasAlumnos.aspx.cs" Inherits="Lab2.TareasAlumnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CerrarSesion.aspx">Cerrar Sesion</asp:HyperLink>
        </p>
        <p>
            ALUMNOS GESTION DE TAREAS</p>
        <asp:Label ID="Label1" runat="server" Text="Seleccionar asigntura"></asp:Label>
        <asp:DropDownList AutoPostBack="true" ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:GridView  ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="Instanciar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </form>
</body>
</html>
