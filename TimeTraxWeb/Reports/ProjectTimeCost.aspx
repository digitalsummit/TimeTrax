<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectTimeCost.aspx.cs" Inherits="TimeTrax.Reports.ProjectTimeCost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div id="divNotAuthorized" runat="server" visible="false">
        <asp:Label ID="Label1" runat="server" Text="Sorry, your user role does not allow for running this report."></asp:Label>
    </div>
     <div id="divAuthorized" runat="server" visible="false">
        <asp:Label ID="Label2" runat="server" Text="Project Time Cost Report" Font-Bold="true" Font-Size="X-Large" ></asp:Label><br />
        <asp:Label ID="Label3" runat="server" Text="Project Number:"></asp:Label>
        <asp:TextBox ID="txtProjectNumber" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnGetProjectName" runat="server" Text="Check Project Title" OnClick="btnGetProjectName_Click" CssClass="optionButton" /><br />
        <asp:TextBox ID="txtProjectName" runat="server" Width="350px" BorderStyle="None" ForeColor="Blue"></asp:TextBox><br />
        <asp:Label ID="LabelProjectName" runat="server" Text="" Visible="false" ></asp:Label> <br />
         <asp:Label ID="LabelProgress" runat="server" Text="" Visible="false" ></asp:Label> <br />
        <asp:Button ID="btnRunRpt" runat="server" Text="Run Report" OnClick="btnRunRpt_Click" />
    </div>

</asp:Content>
