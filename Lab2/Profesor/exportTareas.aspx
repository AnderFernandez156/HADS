<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="exportTareas.aspx.cs" Inherits="Lab2.exportTareas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="PROFESOR EXPORTAR TAREA"></asp:Label>
        </div>
        <asp:Label ID="Label2" runat="server" Text="Seleccionar asignatura a exportar:"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="EXPORT XML" />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesor/Profesor.aspx">Menu</asp:HyperLink>
        <p>
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
