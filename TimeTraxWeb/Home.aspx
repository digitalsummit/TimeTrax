<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TimeTrax.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
       <link rel="stylesheet" href="StyleSheet1.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div runat="server" style="width:100%">
        <asp:Table runat="server" ID="tblMenu" CssClass="tableLarge">
            <asp:TableRow runat="server" CssClass="tableRowLarge"><asp:TableCell CssClass="tableCellLarge"><asp:Label ID="Label1" runat="server" Text="Improve Group TimeTrax" CssClass="titlebar"></asp:Label></asp:TableCell></asp:TableRow>
            <asp:TableRow runat="server" Width="100%" Height="100%"><asp:TableCell><asp:Label ID="lblUserName" runat="server" CssClass="labelWide"></asp:Label></asp:TableCell></asp:TableRow>
            <asp:TableRow runat="server" Width="100%" Height="100%"><asp:TableCell><asp:Button ID="btnEnterTime" runat="server" Text="Submit My Time" OnClick="btnEnterTime_Click"  CssClass="optionButton"/></asp:TableCell></asp:TableRow>
            <asp:TableRow runat="server" Width="100%" Height="100%"><asp:TableCell><asp:Button ID="btnReview" runat="server" Text="REVIEW" OnClick="btnReview_Click" CssClass="optionButton"/></asp:TableCell></asp:TableRow>
            <asp:TableRow runat="server" Width="100%" Height="100%"><asp:TableCell><asp:Button ID="btnReports" runat="server" Text="Reports" OnClick="btnReports_Click" CssClass="optionButton" /></asp:TableCell></asp:TableRow>
            <asp:TableRow runat="server" Width="100%" Height="100%"><asp:TableCell><asp:Button ID="btnApproval" runat="server" Text="Manager Approval" OnClick="btnApproval_Click" CssClass="optionButton" /></asp:TableCell></asp:TableRow>
            <asp:TableRow runat="server" Width="100%" Height="100%"><asp:TableCell></asp:TableCell></asp:TableRow>
            <asp:TableRow runat="server" Width="100%" Height="100%"><asp:TableCell><asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="submitButton" />   </asp:TableCell></asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
