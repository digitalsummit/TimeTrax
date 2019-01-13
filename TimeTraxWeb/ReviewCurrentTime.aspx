<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ReviewCurrentTime.aspx.cs" Inherits="TimeTrax.ReviewCurrentTime" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <asp:Label Visible="false" ID="lblWelcome" runat="server" Text="Label"></asp:Label>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <div runat="server" style="width:100%">
            <asp:Label ID="lblSumHours" runat="server" Text="" BackColor="LightGoldenrodYellow" ></asp:Label>
            <asp:Label ID="lblSumLastWeek" runat="server" Text="" BackColor="Khaki"></asp:Label>
            <asp:Label ID="lblSumNextWeek" runat="server" Text="" BackColor="LightGoldenrodYellow"></asp:Label>
            <asp:Label ID="lblSumThisWeek" runat="server" Text="" BackColor="Khaki"></asp:Label>
                <p></p>
            <asp:Label ID="lblSumCurrentMonday" runat="server" Text="" BackColor="Khaki"></asp:Label>
            <asp:Label ID="lblSumCurrentTuesday" runat="server" Text="" BackColor="LightGoldenrodYellow"></asp:Label>
            <asp:Label ID="lblSumCurrentWednesday" runat="server" Text="" BackColor="Khaki"></asp:Label>
            <asp:Label ID="lblSumCurrentThursday" runat="server" Text="" BackColor="LightGoldenrodYellow" ></asp:Label>
            <asp:Label ID="lblSumCurrentFriday" runat="server" Text="" BackColor="Khaki"></asp:Label>
            <asp:Label ID="lblSumCurrentSaturday" runat="server" Text="" BackColor="LightGoldenrodYellow"></asp:Label>
            <asp:Label ID="lblSumCurrentSunday" runat="server" Text="" BackColor="Khaki"></asp:Label>
                <p></p>
            <asp:Label ID="Label1" runat="server" Text="Decrease Hours: ⮟ Increase Hours: ⮝ " BackColor="Tan" ForeColor="#428BCA" Font-Bold="true" ></asp:Label>
            </div>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" AutoGenerateSelectButton="false" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID" OnSorting="GridView1_Sorting"  >
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="false" />
                <asp:TemplateField>
                <ItemTemplate>
                      <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("ID")%>' OnCommand="lnkDelete" Text="Delete">
                      </asp:LinkButton>
                </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="ProjectNumber" HeaderText="ProjectNumber" SortExpression="ProjectNumber" ReadOnly="True"   />
               <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" ItemStyle-Width="300px" ReadOnly="True"  />
               <asp:BoundField DataField="DateWorked" HeaderText="DateWorked" SortExpression="DateWorked" ReadOnly="True"  />
               <asp:BoundField DataField="Employee" HeaderText="Employee" SortExpression="Employee"  ReadOnly="True" Visible="false" />
               <asp:TemplateField>
               <ItemTemplate>
                      <asp:LinkButton ID="btnSubtractTime" runat="server" CommandArgument='<%#Eval("ID")%>' OnCommand="lnkSubstractTime" Text="⮟">
                      </asp:LinkButton>
               </ItemTemplate>
               </asp:TemplateField>
                <asp:BoundField DataField="Hours" HeaderText="Hours" SortExpression="Hours" />
                <asp:TemplateField>
                <ItemTemplate>
                      <asp:LinkButton ID="btnAddTime" runat="server" CommandArgument='<%#Eval("ID")%>' OnCommand="lnkAddTime" Text="⮝">
                      </asp:LinkButton>
               </ItemTemplate>
        </asp:TemplateField>
                <asp:CheckBoxField DataField="DriveTime" HeaderText="DriveTime" SortExpression="DriveTime" ReadOnly="True"  />
                <asp:CheckBoxField DataField="PreProject" HeaderText="PreProject" SortExpression="PreProject" ReadOnly="True"  />
                <asp:CheckBoxField DataField="CorporateEvents" HeaderText="CorpEvents" SortExpression="CorporateEvents" ReadOnly="True" />
                 <asp:CheckBoxField DataField="Training" HeaderText="Training" SortExpression="Training" ReadOnly="True"  />
                <asp:CheckBoxField DataField="PTO" HeaderText="PTO" SortExpression="PTO"  ReadOnly="True" />
                <asp:CheckBoxField DataField="Holiday" HeaderText="Holiday" SortExpression="Holiday" ReadOnly="True"  />
                 <asp:CheckBoxField DataField="WageScale" HeaderText="WageScale" SortExpression="WageScale" ReadOnly="True"  />
                <asp:CheckBoxField DataField="Other" HeaderText="Other" SortExpression="Other" ReadOnly="True"  />
                <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" ReadOnly="True"  />
            </Columns>
            <EmptyDataTemplate>
                No data selected
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
       </ContentTemplate>                                           
            </asp:UpdatePanel>

    </asp:Content>