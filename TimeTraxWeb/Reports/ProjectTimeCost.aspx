<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectTimeCost.aspx.cs" Inherits="TimeTrax.Reports.ProjectTimeCost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label2" runat="server" Text="Project Time Cost Report"></asp:Label><br />
        <asp:Label ID="Label3" runat="server" Text="Project Number:"></asp:Label>
        <asp:TextBox ID="txtProjectNumber" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnGetProjectName" runat="server" Text="Check Project Title" OnClick="btnGetProjectName_Click" CssClass="optionButton" /><br />
        <asp:TextBox ID="txtProjectName" runat="server" Width="350px" BorderStyle="None"></asp:TextBox><br />
        <asp:Label ID="LabelProgress" runat="server" Text="" Visible="false" ></asp:Label> 
        <asp:Label ID="LabelProjectName" runat="server" Text="" Visible="false" ></asp:Label> 
        <asp:Button ID="btnRunRpt" runat="server" Text="Run Report" OnClick="btnRunRpt_Click" />
    </div>

</asp:Content>
