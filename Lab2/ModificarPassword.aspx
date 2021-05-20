<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarPassword.aspx.cs" Inherits="Lab2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label4" runat="server" Text="MODIFICAR CONTRASENA"></asp:Label>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Email"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="*"></asp:RequiredFieldValidator>
        </p>
        <asp:Label ID="Label6" runat="server" Text="Codigo"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="*"></asp:RequiredFieldValidator>
        <p>
            <asp:Label ID="Label7" runat="server" Text="Nueva contrasena"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression=".{6,}" ControlToValidate="TextBox4">Contrasena invalida</asp:RegularExpressionValidator>
        </p>
        <asp:Label ID="Label8" runat="server" Text="Repetir contrasena"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox5" ErrorMessage="*"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox4" ControlToValidate="TextBox5" ErrorMessage="CompareValidator">Las contrasenas no coinciden</asp:CompareValidator>
        <p>
            <asp:Button ID="Button2" runat="server" Text="Modificar contrasena" OnClick="Button2_Click" />
            <asp:Label ID="Label9" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
