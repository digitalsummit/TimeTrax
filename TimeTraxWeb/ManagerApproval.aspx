<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerApproval.aspx.cs" Inherits="TimeTrax.ManagerApproval" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manager Approval</title>
     <link rel="stylesheet" href="StyleSheet1.css"/>
</head>
<body>
    <form id="form1" runat="server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
              <asp:Button ID="btnHome" runat="server" Text="Home" OnClick="btnHome_Click" CssClass="submitButton" />
            <asp:Label ID="Label1" runat="server" Text="Approve Time for:"></asp:Label><asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID" OnRowDataBound="GridView1_RowDataBound" ForeColor="Black" GridLines="None" AutoGenerateEditButton="false" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  >
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Employee" HeaderText="Employee" SortExpression="Employee" />
                <asp:BoundField DataField="DateWorked" HeaderText="DateWorked" SortExpression="DateWorked" ReadOnly="True" />
                <asp:BoundField DataField="ProjectNumber" HeaderText="ProjectNumber" SortExpression="ProjectNumber"   />
                <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" ItemStyle-Width="300px" />
                <asp:CheckBoxField DataField="PreProject" HeaderText="PreProject" SortExpression="PreProject" />
                 <asp:CheckBoxField DataField="StrategicInitiative" HeaderText="StrategicInitiative" SortExpression="StrategicInitiative" />
                <asp:CheckBoxField DataField="Training" HeaderText="Training" SortExpression="Training" />
                <asp:CheckBoxField DataField="Other" HeaderText="Other" SortExpression="Other" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" ItemStyle-Width="300px" />
                <asp:BoundField DataField="Hours" HeaderText="Hours" SortExpression="Hours" />
                <asp:CheckBoxField DataField="WageScale" HeaderText="WageScale" SortExpression="WageScale" />
                <asp:CheckBoxField DataField="DriveTime" HeaderText="DriveTime" SortExpression="DriveTime" />
                <asp:CommandField ShowSelectButton="True" SelectText="Approve"/>
            </Columns>
            <EmptyDataTemplate>
                No data found
            </EmptyDataTemplate>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        <p></p>

     </ContentTemplate>                                           
            </asp:UpdatePanel>
    </form>
</body>
</html>
