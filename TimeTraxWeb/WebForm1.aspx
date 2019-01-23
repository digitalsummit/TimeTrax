<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TimeTrax.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Enter Project Number"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="Answer here"></asp:Label> <br />
        <asp:Button ID="Button1" runat="server" Text="Get Project Title" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
