<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ManagerApproval.aspx.cs" Inherits="TimeTrax.ManagerApproval" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <asp:Table ID="Table1" runat="server">
            <asp:TableRow> <asp:TableCell Width="255px">
                <asp:Label ID="Label1" runat="server" Text="Approve Time for:"></asp:Label><asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><p></p>
                </asp:TableCell><asp:TableCell  Width="200px"> <asp:RadioButton ID="rbUnapprovedTime" runat="server" Text="Show Unapproved Time" Checked="true" GroupName="approvedType" OnCheckedChanged="rbUnapprovedTime_CheckedChanged" AutoPostBack="true" /> </asp:TableCell><asp:TableCell><asp:RadioButton ID="rbIncludeApprovedTime" runat="server" Text="Include Approved Time" GroupName="approvedType" OnCheckedChanged="rbIncludeApprovedTime_CheckedChanged" AutoPostBack="true" /></asp:TableCell></asp:TableRow>
                 </asp:Table>
            <asp:Table ID="Table2" runat="server">
                <asp:TableRow> <asp:TableCell>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Visible="false" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Last Week" Value="Last Week" Selected="True"></asp:ListItem>
                <asp:ListItem Text="This Week" Value="This Week" Selected="False"></asp:ListItem>
                <asp:ListItem Text="Next Week" Value="Next Week" Selected="False"></asp:ListItem>
            </asp:RadioButtonList>
            </asp:TableCell>
                <asp:TableCell> <asp:GridView ID="GridView2" runat="server" AlternatingRowStyle-BackColor="PaleGoldenrod" BackColor="LightGoldenrodYellow" HeaderStyle-BackColor="Tan"></asp:GridView>  </asp:TableCell>

            </asp:TableRow>
            </asp:Table>

            <asp:Button ID="btnApproveAll" runat="server" Text="Approve All" CssClass="submitButton" Visible="false" BorderColor="Tan" BackColor="LightGreen" BorderWidth="2px" BorderStyle="Ridge" OnClick="btnApproveAll_Click" />


        <asp:GridView ID="GridView1" runat="server" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID" OnRowDataBound="GridView1_RowDataBound" ForeColor="Black" GridLines="None" AutoGenerateEditButton="false" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSorting="GridView1_Sorting" >
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="DateWorked" HeaderText="DateWorked" SortExpression="DateWorked" />
                <asp:BoundField DataField="Day" HeaderText="Day" SortExpression="DateWorked" />
                <asp:BoundField DataField="ProjectNumber" HeaderText="Project" SortExpression="ProjectNumber"   />
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
                <asp:BoundField DataField="Approved" HeaderText="Approved" SortExpression="Approved" />
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