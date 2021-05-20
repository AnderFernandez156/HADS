<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="Lab2.CambiarPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label3" runat="server" Text="SOLICITAR CAMBIO DE CONTRASENA"></asp:Label>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Email"></asp:TextBox>
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Solicitar" OnClick="Button1_Click" />
        </p>
        
    </form>

</body>
</html>
