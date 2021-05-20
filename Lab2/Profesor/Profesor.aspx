<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="Lab2.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CerrarSesion.aspx">Cerrar Sesion</asp:HyperLink>
        </div>
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Profesor/TareasProfesor.aspx">Tareas</asp:HyperLink>
                </td>
                <td><span style="color: rgb(0, 0, 0); font-family: &quot;Times New Roman&quot;; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Gestion Web de Tareas-Dedicacion</span></td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Profesor/coordinador.aspx">Coordinador</asp:HyperLink>
                </td>
                <td>Profesor</td>
            </tr>
        </table>
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Profesor/ImportarTareaProfesor.aspx">Importar XMLDocument</asp:HyperLink>
        <p>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Profesor/exportTareas.aspx">Exportar</asp:HyperLink>
        </p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" Interval="1000">
        </asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="Gente conectada:"></asp:Label>
                <asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
                <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
