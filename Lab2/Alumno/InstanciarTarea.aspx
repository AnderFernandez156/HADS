<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstanciarTarea.aspx.cs" Inherits="Lab2.InstanciarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="ALUMNO INSTANCIAR TAREA GENERICA"></asp:Label>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Usuario"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Enabled="False" ></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Tarea"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Enabled="False"></asp:TextBox>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Horas estimadas"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" Enabled="False"></asp:TextBox>
        </p>
        <asp:Label ID="Label5" runat="server" Text="Horas reales"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Instanciar tarea" OnClick="Button1_Click" />
        </p>
        <asp:Label ID="Label6" runat="server"></asp:Label>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Alumno/TareasAlumnos.aspx">Pagina anterior</asp:HyperLink>
    </form>
</body>
</html>
