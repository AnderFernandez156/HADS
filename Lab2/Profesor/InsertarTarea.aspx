<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarTarea.aspx.cs" Inherits="Lab2.InsertarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Codigo"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator">Es necesario rellenar</asp:RequiredFieldValidator>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="RequiredFieldValidator">Es necesario rellenar</asp:RequiredFieldValidator>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Asignaturas"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="codigo" DataValueField="codigo" DataSourceID="SqlDataSource1">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Hads21FernandezConnectionString %>" SelectCommand="SELECT [Asignaturas].[codigo] FROM ([Asignaturas] INNER JOIN [GruposClase] ON [Asignaturas].[codigo]=[GruposClase].[codigoasig]) INNER JOIN [ProfesoresGrupo] ON [ProfesoresGrupo].[codigogrupo]=[GruposClase].[codigo] WHERE ([ProfesoresGrupo].[email] = @email)">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="UserName" />
            </SelectParameters>
        </asp:SqlDataSource>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Horas Estimadas"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="RequiredFieldValidator">Es necesario rellenar</asp:RequiredFieldValidator>
        </p>
        <asp:Label ID="Label5" runat="server" Text="Tipo Tarea"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem>Trabajo</asp:ListItem>
            <asp:ListItem>Examen</asp:ListItem>
            <asp:ListItem>Laboratorio</asp:ListItem>
            <asp:ListItem>Ejercicio</asp:ListItem>
        </asp:DropDownList>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Crear Tarea" OnClick="Button1_Click" />
            <asp:Label ID="Label6" runat="server"></asp:Label>
        </p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesor/TareasProfesor.aspx">Ver Tareas</asp:HyperLink>
        
    </form>
</body>
</html>
