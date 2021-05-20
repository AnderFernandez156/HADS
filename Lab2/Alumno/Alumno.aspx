<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="Lab2.Alumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 132px;
        }
        .auto-style4 {
            width: 311px;
        }
        .auto-style5 {
            width: 74%;
        }
        .auto-style6 {
            width: 132px;
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/CerrarSesion.aspx">Cerrar Sesion</asp:HyperLink>
        <table class="auto-style1">
            <tr>
                <td class="auto-style4">
                    <table class="auto-style5">
                        <tr>
                            <td class="auto-style6">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Alumno/TareasAlumnos.aspx">Tareas Genericas</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                                <asp:HyperLink ID="HyperLink2" runat="server">Tareas Propias</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:HyperLink ID="HyperLink3" runat="server">Grupos</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Gestion Web de Tareas-Dedicacion"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Alumnos"></asp:Label>
                </td>
            </tr>
        </table>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" Interval="1000">
        </asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                <asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" />
            </Triggers>
        </asp:UpdatePanel>
        
    </form>
</body>
</html>
