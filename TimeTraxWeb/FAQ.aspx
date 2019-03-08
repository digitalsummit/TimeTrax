<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="TimeTrax.FAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color:lightyellow; border-color:tan; border-style:solid; padding:14px;">
        <div style="align-content:center; margin-left:450px;">
        <asp:Label ID="Label1" runat="server" Text="TimeTrax FAQ" Font-Bold="true" Font-Size="X-Large"></asp:Label><br />
            </div>
        <br />
        <asp:Repeater ID="Repeater1" runat="server" >
            <ItemTemplate>
                <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question")%>' Font-Bold="true" Font-Size="Larger"></asp:Label><br />
                <asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("Answer")%>'></asp:Label><br />
                <br />

            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
