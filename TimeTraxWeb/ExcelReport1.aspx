<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelReport1.aspx.cs" Inherits="TimeTrax.ExcelReport1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Excel Reports</title>
        <link rel="stylesheet" href="StyleSheet1.css"/>
</head>
<body>
    <form id="form1" runat="server">
    
       <div runat="server" class="scaled7">
       <asp:Label ID="Label1" runat="server" Text="Create Excel Report for:"></asp:Label><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
       <asp:Label ID="Label2" runat="server" Text="Approved or Not Apprved time or All"></asp:Label><asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
       <asp:CheckBox ID="cbByProject" runat="server" CssClass="CheckboxStandard" Text="Project Report" OnCheckedChanged="cbByProject_CheckedChanged" AutoPostBack="true"/>
       <asp:CheckBox ID="cbByEmployee" runat="server" CssClass="CheckboxStandard" Text="Employee Report" OnCheckedChanged="cbByEmployee_CheckedChanged" AutoPostBack="true" />
       </div>
        <div>
        <asp:Button ID="btnCreateExcel" runat="server" Text="Create Excel Report File" Font-Size="36pt" CssClass="optionButton" OnClick="btnCreateExcel_Click" />
        <asp:Button ID="Button2" runat="server" Text="Home" OnClick="Button2_Click" CssClass="submitButton" />
        </div>
    </form>
</body>
</html>
