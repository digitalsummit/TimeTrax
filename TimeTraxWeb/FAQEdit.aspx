<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FAQEdit.aspx.cs" Inherits="TimeTrax.FAQEdit" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID">
        <HeaderTemplate> <asp:Label ID="lblHeader" runat="server" Text="FAQ Add/Edit" Font-Bold="true" Font-Size="X-Large"></asp:Label><br /></HeaderTemplate>
        <ItemTemplate>
            <asp:Table runat="server"><asp:TableRow><asp:TableCell><asp:Label ID="Label1" CssClass="labelNormal" runat="server" Text="Question:"></asp:Label></asp:TableCell><asp:TableCell><asp:TextBox ID="txtQuestion" runat="server" AutoPostBack="true" TextMode="MultiLine" Height="50px" Width="450px" Text=<%#Eval("Question") %>></asp:TextBox></asp:TableCell></asp:TableRow>
              <asp:TableRow>
<asp:TableCell><asp:Label ID="Label2" runat="server" Text="Answer:" CssClass="labelNormal"></asp:Label></asp:TableCell>
<asp:TableCell><asp:TextBox ID="txtAnswer" runat="server" AutoPostBack="true" TextMode="MultiLine" CssClass="textBoxNormal" Height="100px" Width="450px" Text=<%#Eval("Answer") %>></asp:TextBox></asp:TableCell></asp:TableRow>
<asp:TableRow>
<asp:TableCell><asp:Label ID="Label3" runat="server" CssClass="labelNormal" Text="VideoLink:"></asp:Label></asp:TableCell>
<asp:TableCell><asp:TextBox ID="txtVideoLink" runat="server" AutoPostBack="true" CssClass="textBoxNormal" Width="450px" TextMode="MultiLine" Text=<%#Eval("VideoLink") %>></asp:TextBox></asp:TableCell></asp:TableRow>
<asp:TableRow>
<asp:TableCell><asp:Label ID="Label4" runat="server" CssClass="labelNormal" Text="SortOrder:"></asp:Label></asp:TableCell>
<asp:TableCell><asp:TextBox ID="txtSortOrder" CssClass="textBoxNormal" Width="30px" AutoPostBack="true" runat="server" Text=<%#Eval("SortOrder") %>></asp:TextBox></asp:TableCell></asp:TableRow>
                <asp:TableRow>

<asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell></asp:TableRow>
                <asp:TableRow>
<asp:TableCell><asp:CheckBox ID="cbActive" runat="server" AutoPostBack="true" CssClass="checkboxPad" Text="Active" Checked=<%#Eval("Active") %> /></asp:TableCell>
<asp:TableCell>  </asp:TableCell></asp:TableRow>
 </asp:Table><asp:Label ID="lblID" runat="server" Visible="false" CssClass="label" Text=<%#Eval("ID") %>></asp:Label></ItemTemplate>
    </asp:FormView>
            <div runat="server" id="divButtonArea" style="float:left">
            <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
<asp:TableRow Height="70px"><asp:TableCell Width="80px">
                    <asp:ImageButton ID="btnFirstRecord" runat="server" Height="30px" Width="30px" ImageUrl="~/Images/FirstRecord.png" OnClick="btnFirstRecord_Click" /> </asp:TableCell><asp:TableCell Width="80px">
<asp:ImageButton ID="btnPrevious" ImageUrl="~/Images/leftArrow.png" runat="server" Height="30px" Width="30px" OnClick="btnPrevious_Click" /></asp:TableCell>
<asp:TableCell Width="80px"><asp:ImageButton ID="btnNext" ImageUrl="~/Images/RightArrow.png" runat="server" Height="30px" Width="30px" OnClick="btnNext_Click" /></asp:TableCell><asp:TableCell Width="80px"><asp:ImageButton ID="btnLastRecord" runat="server" Height="30px" Width="30px" ImageUrl="~/Images/LastRecord.png" OnClick="btnLastRecord_Click" /></asp:TableCell>
</asp:TableRow></asp:Table>
<asp:Table runat="server" HorizontalAlign="Center">
              <asp:TableRow Height="50px"><asp:TableCell Width="90px"></asp:TableCell><asp:TableCell Width="90px"><asp:Button ID="btnAddNew" Visible="true" runat="server" Text="Add New" BackColor="Yellow" OnClick="btnAddNew_Click" /></asp:TableCell> 
<asp:TableCell Width="90px"><asp:Button ID="btnDelete" Visible="true" runat="server" Text="Delete" BackColor="Pink" OnClick="btnDelete_Click" /></asp:TableCell> 
<asp:TableCell Width="90px"><asp:Button ID="btnSave" Visible="true" runat="server" BackColor="LightGreen" Text="Save" OnClick="btnSave_Click" /></asp:TableCell>
<asp:TableCell><asp:Label runat="server" ID="lblSaved" Text="" ForeColor="Green"></asp:Label></asp:TableCell> 
</asp:TableRow>
</asp:Table>
                <asp:Label runat="server" ID="lblBottom" CssClass="label"></asp:Label>
</div>
    <div runat="server" id="divWarning" visible="false">
        <asp:Button ID="btnDeleteOK" runat="server" Text="Delete Record" OnClick="btnDeleteOK_Click" /> <asp:Button ID="btnCancelDelete" runat="server" Text="Cancel" OnClick="btnCancelDelete_Click" /></div>
</asp:Content>
