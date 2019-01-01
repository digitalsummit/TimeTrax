<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TimeTrax.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Improve Group TimeTrax</title>
    <link rel="stylesheet" href="StyleSheet1.css"/>
</head>
<body>
    <form id="form1" runat="server" style="background-image:url(Images/Logo.png)">
        <div runat="server" id="divMessageBox" visible="false" style="width:100%; height:100%">
            <asp:Label ID="lblMessagebox" runat="server" Text="" Font-Size="36pt" BackColor="Red"></asp:Label>
            <asp:Button ID="btnMessagebox" runat="server" Text="OK" OnClick="btnMessagebox_Click" Font-Size="36pt" />
            </div>
    <div runat="server" id="divLogin" visible="true" style="width:100%; height:100%">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label7" runat="server" Text="Improve Group TimeTrax" Font-Size="36pt" Font-Bold="True" BackColor="#E2E2E2"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;
        <asp:Label ID="Label1" runat="server" Text="Email address:" Font-Bold="True" Font-Names="Utah" Font-Size="36pt" BackColor="#E2E2E2"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" Font-Size="36pt" Width="850px"></asp:TextBox>
    
        <br />
        <br />
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:Label ID="Label2" runat="server" Font-Size="36pt" Text="Password:" BackColor="#E2E2E2"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" Font-Size="36pt" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Button ID="btnLogin" runat="server"  Text="Login" OnClick="btnLogin_Click" Font-Bold="False" Font-Size="36pt" BackColor="#BBECE5"  />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnRegister" runat="server" Font-Size="36pt" Text=" OR Register" OnClick="btnRegister_Click" BackColor="#EACD94" />
        </div>
        <div runat="server" id="divRegister" visible="false" style="width:100%">
        
            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Register" Font-Bold="True" Font-Names="Utah" Font-Size="36pt" BackColor="#E2E2E2"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="Email Address:" Font-Bold="True" Font-Names="Utah" Font-Size="36pt" BackColor="#E2E2E2"></asp:Label>
            <asp:TextBox ID="txtRegisterEmail" runat="server" Font-Size="36pt" Width="850px"></asp:TextBox>
            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Font-Size="36pt" Text="Password:" BackColor="#E2E2E2"></asp:Label>
            <asp:TextBox ID="txtPassword1" runat="server" Font-Size="36pt" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Font-Size="36pt" Text="Confirm Password:" BackColor="#E2E2E2"></asp:Label>
            <asp:TextBox ID="txtPassword2" runat="server" Font-Size="36pt" TextMode="Password"></asp:TextBox>
            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Button ID="RegisterAndLogin" runat="server" Font-Bold="True" Font-Size="36pt" Text="Register and Login" OnClick="RegisterAndLogin_Click" BackColor="#BBECE5" />
            <br />
            <p>
            &nbsp;</p>
            <p>
            &nbsp;</p>
            <asp:Button ID="btnBackToLogin" runat="server" Text="Back to Login" OnClick="btnBackToLogin_Click" Font-Size="24" />
            </div>
        </form>
</body>
</html>
