﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReviewCurrentTime.aspx.cs" Inherits="TimeTrax.ReviewCurrentTime" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Review Time</title>
    <link rel="stylesheet" href="StyleSheet1.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblWelcome" runat="server" Text="Label"></asp:Label>
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound" ForeColor="Black" GridLines="None" AutoGenerateEditButton="true">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="ProjectNumber" HeaderText="ProjectNumber" SortExpression="ProjectNumber"   />
                <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" ItemStyle-Width="300px" />
                <asp:BoundField DataField="DateWorked" HeaderText="DateWorked" SortExpression="DateWorked" />
                <asp:BoundField DataField="Employee" HeaderText="Employee" SortExpression="Employee" />
                <asp:BoundField DataField="Hours" HeaderText="Hours" SortExpression="Hours" />
                <asp:CheckBoxField DataField="PreProject" HeaderText="PreProject" SortExpression="PreProject" />
                <asp:CheckBoxField DataField="StrategicInitiative" HeaderText="StrategicInitiative" SortExpression="StrategicInitiative" />
                <asp:CheckBoxField DataField="Training" HeaderText="Training" SortExpression="Training" />
                <asp:CheckBoxField DataField="WageScale" HeaderText="WageScale" SortExpression="WageScale" />
                <asp:CheckBoxField DataField="DriveTime" HeaderText="DriveTime" SortExpression="DriveTime" />
                <asp:CheckBoxField DataField="Other" HeaderText="Other" SortExpression="Other" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TimeTraxConnectionString %>" DeleteCommand="DELETE FROM [TimeSheet] WHERE [ID] = @ID" InsertCommand="INSERT INTO [TimeSheet] ([ProjectNumber], [ProjectName], [DateWorked], [Employee], [Hours], [WageScale], [DriveTime]) VALUES (@ProjectNumber, @ProjectName, @DateWorked, @Employee, @Hours, @WageScale, @DriveTime)" UpdateCommand="UPDATE [TimeSheet] SET [ProjectNumber] = @ProjectNumber, [ProjectName] = @ProjectName, [DateWorked] = @DateWorked, [Employee] = @Employee, [Hours] = @Hours, [PreProject] = @PreProject,[StrategicInitiative] = @StrategicInitiative,[Training] = @Training, [WageScale] = @WageScale, [DriveTime] = @DriveTime, [Other] = @Other, [Notes] = @Notes WHERE [ID] = @ID" SelectCommand="GetMyCurrentTimeSheet" SelectCommandType="StoredProcedure" >
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int64" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ProjectNumber" Type="String" />
                <asp:Parameter Name="ProjectName" Type="String" />
                <asp:Parameter Name="DateWorked"  DbType="Date"/>
                <asp:Parameter Name="Employee" Type="String" />
                <asp:Parameter Name="Hours" Type="Double" />
                <asp:Parameter Name="PreProject" Type="Boolean" />
                <asp:Parameter Name="StrategicInitiative" Type="Boolean" />
                <asp:Parameter Name="Training" Type="Boolean" />
                <asp:Parameter Name="WageScale" Type="Boolean" />
                <asp:Parameter Name="DriveTime" Type="Boolean" />
                <asp:Parameter Name="Other" Type="Boolean" />
                <asp:Parameter Name="Notes" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="lblWelcome" Name="Employee" PropertyName="Text" Type="String" />
                <asp:Parameter Name="Approved" Type="String" DefaultValue="Not Approved" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProjectNumber" Type="String" />
                <asp:Parameter Name="ProjectName" Type="String" />
                <asp:Parameter Name="DateWorked" DbType="Date"  />
                <asp:Parameter Name="Employee" Type="String" />
                <asp:Parameter Name="Hours" Type="Double" />
                <asp:Parameter Name="WageScale" Type="Boolean" />
                <asp:Parameter Name="DriveTime" Type="Boolean" />
                <asp:Parameter Name="PreProject" Type="Boolean" />
                <asp:Parameter Name="StrategicInitiative" Type="Boolean" />
                <asp:Parameter Name="Training" Type="Boolean" />
                <asp:Parameter Name="Other" Type="Boolean" />
                <asp:Parameter Name="Notes" Type="String" />
                <asp:Parameter Name="ID" Type="Int64" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <p></p>
                <div runat="server" style="width:100%">
        <asp:Label ID="lblTotalHours" runat="server" Text="" Font-Size="36pt"></asp:Label><p></p>
                </div>
        <%--<asp:Button ID="btnEnterTime" runat="server" Text="Enter Time" Width="300px" Height="150px" Font-Size="36pt" OnClick="btnEnterTime_Click"  CssClass="optionButton" />--%>
        <p></p>
        <asp:Button ID="Button2" runat="server" Text="Home" OnClick="Button2_Click" CssClass="submitButton" />
       </ContentTemplate>                                           
            </asp:UpdatePanel>
    </form>
</body>
</html>
