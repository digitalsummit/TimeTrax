<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ReviewCurrentTime.aspx.cs" Inherits="TimeTrax.ReviewCurrentTime" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <asp:Label Visible="false" ID="lblWelcome" runat="server" Text="Label" Font-Names="Arial"></asp:Label>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="align-content:center"><asp:Label ID="Label3" runat="server" Text="Review My Time" Font-Bold="true" Font-Size="X-Large" Font-Names="Arial"></asp:Label></div>
            <asp:Table ID="Table1" runat="server">
                <asp:TableHeaderRow BorderColor="LightCyan" BorderStyle="Solid" BorderWidth="5px" BackColor="LightCyan"><asp:TableHeaderCell Width="108px"><asp:Label ID="lblSumLastWeek" runat="server" Text="" BackColor="LightCyan"></asp:Label></asp:TableHeaderCell><asp:TableHeaderCell Width="108px"><asp:Label ID="lblSumThisWeek" runat="server" Text="" BackColor="LightCyan" Width="70px"></asp:Label></asp:TableHeaderCell><asp:TableHeaderCell Width="108px"><asp:Label ID="lblSumNextWeek" runat="server" Text="" BackColor="LightCyan"></asp:Label></asp:TableHeaderCell></asp:TableHeaderRow>
                </asp:Table>
            <asp:Table ID="Table2" runat="server">
                        <asp:TableRow><asp:TableCell><asp:Label ID="Label7" runat="server" Text="Select Week" CssClass="labelNormal" Font-Names="Arial"></asp:Label></asp:TableCell><asp:TableCell></asp:TableCell></asp:TableRow>
                      <asp:TableRow VerticalAlign="Middle" HorizontalAlign="Center">
                  <asp:TableCell><asp:ImageButton ID="btnPreviousWeek" ImageUrl="~/Images/leftArrow.png" runat="server" Height="30px" Width="30px" OnClick="btnPreviousWeek_Click" /></asp:TableCell>
                          <asp:TableCell></asp:TableCell>
                          <asp:TableCell><asp:ImageButton ID="btnNextWeek" ImageUrl="~/Images/RightArrow.png" runat="server" Height="30px" Width="30px" OnClick="btnNextWeek_Click" /></asp:TableCell>
                          <asp:TableCell Width="50px"></asp:TableCell>
                          <asp:TableCell></asp:TableCell>
                      </asp:TableRow> 
                <asp:TableRow><asp:TableCell>Prev</asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell>Next</asp:TableCell><asp:TableCell></asp:TableCell></asp:TableRow>
            </asp:Table><asp:Table runat="server">
                <asp:TableRow BorderColor="Cyan" BorderStyle="Solid" BorderWidth ="3px" BackColor="Cyan">
                    <asp:TableCell Width="45px"><asp:Label ID="lblSumCurrentMonday" runat="server" Text="" BackColor="LightCyan" Font-Names="Arial"></asp:Label>&nbsp;</asp:TableCell>
                    <asp:TableCell Width="45px"><asp:Label ID="lblSumCurrentTuesday" runat="server" Text="" BackColor="LightCyan" Font-Names="Arial"></asp:Label>&nbsp;</asp:TableCell>
                    <asp:TableCell Width="45px"><asp:Label ID="lblSumCurrentWednesday" runat="server" Text="" BackColor="LightCyan" Font-Names="Arial"></asp:Label>&nbsp;</asp:TableCell>
                    <asp:TableCell Width="45px"><asp:Label ID="lblSumCurrentThursday" runat="server" Text="" BackColor="LightCyan" Font-Names="Arial"></asp:Label>&nbsp;</asp:TableCell>
                    <asp:TableCell Width="45px"><asp:Label ID="lblSumCurrentFriday" runat="server" Text="" BackColor="LightCyan" Font-Names="Arial"></asp:Label>&nbsp;</asp:TableCell>
                    <asp:TableCell Width="45px"><asp:Label ID="lblSumCurrentSaturday" runat="server" Text="" BackColor="LightCyan" Font-Names="Arial"></asp:Label>&nbsp;</asp:TableCell>
                    <asp:TableCell Width="45px"><asp:Label ID="lblSumCurrentSunday" runat="server" Text="" BackColor="LightCyan" Font-Names="Arial"></asp:Label>&nbsp;</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <div runat="server" style="width:50%">
                <asp:Table ID="Table3" runat="server"><asp:TableRow>
                      <asp:TableCell><asp:Label for="txtDateBegin" CssClass="control-label col-sm-2" runat="server" Text="Beginning Date:" Width="150px" Font-Names="Arial"></asp:Label></asp:TableCell><asp:TableCell><asp:TextBox ID="txtDateBegin" runat="server" CssClass="form-control" Width="110px" Font-Names="Arial"></asp:TextBox></asp:TableCell>
                  <asp:TableCell><asp:Label for="txtDateEnd" CssClass="control-label col-sm-2" runat="server" Text="Ending Date:" Width="130px" Font-Names="Arial"></asp:Label></asp:TableCell><asp:TableCell><asp:TextBox ID="txtDateEnd" runat="server" CssClass="form-control" Width="110px" Font-Names="Arial"></asp:TextBox></asp:TableCell>
                  </asp:TableRow></asp:Table>
                </div>
            <asp:Label ID="Label2" runat="server" Text="Details:" Font-Names="Arial">
                                  </asp:Label>
            <div runat="server" style="width:100%">
            <asp:RadioButtonList ID="RadioButtonList1" RepeatColumns="3" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true"><asp:ListItem Text="Unapproved" Value="Unapproved" style="margin-right:20px" ></asp:ListItem> <asp:ListItem Text="Approved" style="margin-right:20px"></asp:ListItem> <asp:ListItem Text="All" style="margin-right:20px; padding-left:5px"></asp:ListItem></asp:RadioButtonList><br />
                <asp:Label ID="Label1" runat="server" Text="Hours:Decrease &#x2207; &nbsp;Increase &#x2206; Change Date: &#x2207; or  &#x2206;" BackColor="White" ForeColor="#428BCA" Font-Bold="true" Font-Size="Small" Font-Names="Arial" ></asp:Label>
                </div>
        <asp:GridView ID="GridView1" runat="server" Font-Names="Arial" Width="95%" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" AutoGenerateSelectButton="false" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID" OnSorting="GridView1_Sorting"  >
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="false" />
                <asp:TemplateField>
                <ItemTemplate>
                      <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("ID")%>' OnCommand="lnkDelete" Text="Delete">
                      </asp:LinkButton>
                </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="ProjectNumber" HeaderText="Project" SortExpression="ProjectNumber" ReadOnly="True"   />
                           <asp:TemplateField>
               <ItemTemplate>
                      <asp:LinkButton ID="btnSubtractDay" runat="server" CommandArgument='<%#Eval("ID")%>' OnCommand="btnSubtractDay_Command" Text="&#x2207">
                      </asp:LinkButton>
               </ItemTemplate>
               </asp:TemplateField>
                <asp:BoundField DataField="DateWorked" HeaderText="DateWorked" SortExpression="DateWorked" ReadOnly="false"  />
                <asp:TemplateField>
               <ItemTemplate>
                      <asp:LinkButton ID="btnAddDay" runat="server" CommandArgument='<%#Eval("ID")%>' OnCommand="btnAddDay_Command" Text="&#x2206">
                      </asp:LinkButton>
               </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" ItemStyle-Width="300px" ReadOnly="True"  />
                <asp:BoundField DataField="Day" HeaderText="Day" SortExpression="DateWorked" ReadOnly="True"  />
               <asp:BoundField DataField="Employee" HeaderText="Employee" SortExpression="Employee"  ReadOnly="True" Visible="false" />
               <asp:TemplateField>
               <ItemTemplate>
                      <asp:LinkButton ID="btnSubtractTime" runat="server" CommandArgument='<%#Eval("ID")%>' OnCommand="lnkSubstractTime" Text="&#x2207">
                      </asp:LinkButton>
               </ItemTemplate>
               </asp:TemplateField>
                <asp:BoundField DataField="Hours" HeaderText="Hours" SortExpression="Hours" />
                <asp:TemplateField>
                <ItemTemplate>
                      <asp:LinkButton ID="btnAddTime" runat="server" CommandArgument='<%#Eval("ID")%>' OnCommand="lnkAddTime" Text="&#x2206">
                      </asp:LinkButton>
               </ItemTemplate>
        </asp:TemplateField>
                
                <asp:CheckBoxField DataField="PreProject" HeaderText="PreProject" SortExpression="PreProject" ReadOnly="True"  />
                <asp:CheckBoxField DataField="CorporateEvents" HeaderText="CorpEvents" SortExpression="CorporateEvents" ReadOnly="True" />
                <%-- <asp:CheckBoxField DataField="Training" HeaderText="Training" SortExpression="Training" ReadOnly="True"  />--%>
                <asp:CheckBoxField DataField="PTO" HeaderText="PTO" SortExpression="PTO"  ReadOnly="True" />
                <asp:CheckBoxField DataField="Holiday" HeaderText="Holiday" SortExpression="Holiday" ReadOnly="True"  />
                 <asp:CheckBoxField DataField="WageScale" HeaderText="WageScale" SortExpression="WageScale" ReadOnly="True"  />
                <asp:CheckBoxField DataField="DriveTime" HeaderText="TravelTime" SortExpression="DriveTime" ReadOnly="True"  />
                <%--<asp:CheckBoxField DataField="Other" HeaderText="Other" SortExpression="Other" ReadOnly="True"  />--%>
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