<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportarTareaProfesor.aspx.cs" Inherits="Lab2.ImportarTareaProfesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="PROFESOR IMPORTAR TAREAS GENERICAS"></asp:Label>
        <div>
        </div>
        <asp:Label ID="Label2" runat="server" Text="Seleccionar Asignatura a Importar"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="72px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1"  runat="server" ConnectionString="<%$ ConnectionStrings:Hads21FernandezConnectionString %>" OnSelecting="DropDownList1_SelectedIndexChanged" SelectCommand="SELECT GruposClase.codigoasig FROM GruposClase INNER JOIN ProfesoresGrupo ON GruposClase.codigo = ProfesoresGrupo.codigogrupo WHERE (ProfesoresGrupo.email = @email)">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="UserName" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="IIMPORTAR TAREAS" />
        <asp:Label ID="Label3" runat="server" Text="Lista de tareas de la asignatura seleccionada"></asp:Label>
        <asp:Xml ID="Xml1" runat="server"></asp:Xml>
    </form>
</body>
</html>
