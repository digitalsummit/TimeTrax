﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MgrCostRpt.aspx.cs" Inherits="TimeTrax.Reports.MgrCostRpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
           <div id="divNotAuthorized" runat="server" visible="false">
        <asp:Label ID="Label3" runat="server" Text="Sorry, your user role does not allow for running this report."></asp:Label>

    </div>
    <div id="divAuthorized" runat="server" visible="false" style="float:left">
         <asp:Label ID="Label4" runat="server" Text="Manager Project Cost Report" Font-Bold="true" Font-Size="X-Large"></asp:Label><br />
    <div class="form-group">
                 <asp:Table ID="Table1" runat="server" BorderStyle="None">
                      <asp:TableRow><asp:TableCell Width="5px"></asp:TableCell><asp:TableCell ColumnSpan="3"><asp:Label ID="Label1" CssClass="control-label col-sm-2" runat="server" Text="" Width="160"></asp:Label></asp:TableCell></asp:TableRow>
                      <asp:TableRow VerticalAlign="Middle" HorizontalAlign="Center"><asp:TableCell></asp:TableCell>
                  <asp:TableCell><asp:ImageButton ID="btnPreviousWeek" ImageUrl="~/Images/leftArrow.png" runat="server" Height="30px" Width="30px" OnClick="btnPreviousWeek_Click" /></asp:TableCell>
                          <asp:TableCell><asp:Label ID="Label7" runat="server" Text="Select Week"></asp:Label></asp:TableCell>
                          <asp:TableCell><asp:ImageButton ID="btnNextWeek" ImageUrl="~/Images/RightArrow.png" runat="server" Height="30px" Width="30px" OnClick="btnNextWeek_Click" /></asp:TableCell>
                      </asp:TableRow>
                  </asp:Table>
              <div class="form-group" style="float:left">
            <asp:Label for="txtDateBegin" CssClass="control-label col-sm-2" runat="server" Text="Beginning Date:"></asp:Label>
                <asp:TextBox ID="txtDateBegin" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label for="txtDateEnd" CssClass="control-label col-sm-2" runat="server" Text="Ending Date:"></asp:Label>
                <asp:TextBox ID="txtDateEnd" runat="server" CssClass="form-control"></asp:TextBox>
            </div></div>

    <div class="form-group" style="float:left">
             
                 <asp:Label ID="lblWarningSelectManager" runat="server" Text="Please Select a Manager from the drop down list." ForeColor="Red" Visible="false"></asp:Label>
            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        
        </div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>

    
    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
            <%--<asp:Button ID="btnCreateExcel" runat="server" Text="Create Excel Report File"  CssClass="btn btn-default" OnClick="btnCreateExcel_Click" /><br />--%>
            <asp:Label ID="Label2" runat="server" Text="This report calculates the number of hours for the manager based on the number of workdays between the date range (inclusive).  Don’t include today’s date in the range unless it is currently after 5 PM. Only project hours entered by the manager's staff are selected."></asp:Label>
        </div>
    </div>
          <div>
        <asp:Button ID="btnRunRpt" runat="server" Text="Create Excel Report" OnClick="btnRunRpt_Click" />
    </div>
        </div>
            <script type="text/javascript">
        $(function () {
            $('#MainContent_txtDateBegin').datepicker({
                autoclose: true
            });
        });
        $(function () {
            $('#MainContent_txtDateEnd').datepicker({
                autoclose: true
            });
        });
    </script>
   
</asp:Content>
