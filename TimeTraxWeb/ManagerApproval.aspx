<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ManagerApproval.aspx.cs" Inherits="TimeTrax.ManagerApproval" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Text="Approve Time for:"></asp:Label><asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><asp:Button ID="btnApproveAll" runat="server" Text="Approve All" CssClass="submitButton" Visible="false" OnClick="btnApproveAll_Click" />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID" OnRowDataBound="GridView1_RowDataBound" ForeColor="Black" GridLines="None" AutoGenerateEditButton="false" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSorting="GridView1_Sorting" >
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="DateWorked" HeaderText="DateWorked" SortExpression="DateWorked" />
                <asp:BoundField DataField="ProjectNumber" HeaderText="ProjectNumber" SortExpression="ProjectNumber"   />
                <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" ItemStyle-Width="300px" />
                <asp:BoundField DataField="Hours" HeaderText="Hours" SortExpression="Hours" />
                <asp:BoundField DataField="PreProject" HeaderText="PreProject" SortExpression="PreProject" />
                <asp:BoundField DataField="CorporateEvents" HeaderText="CorporateEvents" SortExpression="CorporateEvents" />
                <asp:BoundField DataField="PTO" HeaderText="PTO" SortExpression="PTO" />
                <asp:BoundField DataField="Holiday" HeaderText="Holiday" SortExpression="Holiday" />
                <asp:BoundField DataField="WageScale" HeaderText="WageScale" SortExpression="WageScale" />
                <asp:BoundField DataField="DriveTime" HeaderText="DriveTime" SortExpression="DriveTime" />
                <asp:BoundField DataField="Other" HeaderText="Other" SortExpression="Other" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" ItemStyle-Width="300px" />

                <asp:CommandField ShowSelectButton="True" SelectText="Approve"/>
            </Columns>
            <EmptyDataTemplate>
                No records selected
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

    </asp:Content>