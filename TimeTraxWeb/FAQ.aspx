<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="TimeTrax.FAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Stylesheet1.css" />
    <div style="background-color:lightyellow; border-color:tan; border-style:solid; padding:14px;">
        <div>
        <asp:Label ID="Label1" runat="server" Text="FAQ" Font-Bold="true" Font-Size="X-Large"></asp:Label><br />
            </div>
        <br />
        <asp:Repeater ID="Repeater1" runat="server" >
            <ItemTemplate>
                <asp:Table ID="Table1" runat="server" CssClass="tableFAQ">
                    <asp:TableRow>
                        <asp:TableCell Width="110px"></asp:TableCell>
                        <asp:TableCell><asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question")%>' Font-Bold="true" Font-Size="Larger"></asp:Label></asp:TableCell>
                        </asp:TableRow><asp:TableRow><asp:TableCell><asp:HyperLink ID="HyperLink1" runat="server" ImageUrl=<%#Eval("VideoLink") == DBNull.Value ? "" : "~/Images/VideoBlue.png"%>  NavigateUrl='<%#Eval("VideoLink")%>' Target="_blank"></asp:HyperLink></asp:TableCell>
                        <asp:TableCell><asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("Answer")%>'></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Height="15px"> <asp:TableCell></asp:TableCell></asp:TableRow>
                    </asp:Table>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
