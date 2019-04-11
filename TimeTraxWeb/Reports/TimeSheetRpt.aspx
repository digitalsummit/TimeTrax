<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TimeSheetRpt.aspx.cs" Inherits="TimeTrax.Reports.TimeSheetRpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divNotAuthorized" runat="server" visible="false">
        <asp:Label ID="Label5" runat="server" Text="Sorry, your user role does not allow for running this report."></asp:Label>
    </div>
    <div id="divAuthorized" runat="server" visible="false" class="form-group" style="float:left; width:110%">
        <asp:Label ID="Label6" runat="server" Text="Timesheet Report" Font-Bold="true" Font-Size="X-Large" Width="100%"></asp:Label>
        <asp:Label ID="Label1" CssClass="control-label col-sm-2" runat="server" Text=""></asp:Label>
        <div style="float:left; width:100%">
            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
    

       <div class="form-group">
              <div class="form-group" style="float:left">
                  <asp:Table ID="Table1" runat="server">
                      
                      <asp:TableRow VerticalAlign="Middle" HorizontalAlign="Left"><asp:TableCell Width="30px"></asp:TableCell>
                  <asp:TableCell><asp:ImageButton ID="btnPreviousWeek" ImageUrl="~/Images/leftArrow.png" runat="server" Height="30px" Width="30px" OnClick="btnPreviousWeek_Click" /></asp:TableCell>
                          <asp:TableCell HorizontalAlign="Right"><asp:Label ID="Label7" runat="server" Text="Select Week"></asp:Label></asp:TableCell>
                          <asp:TableCell><asp:ImageButton ID="btnNextWeek" ImageUrl="~/Images/RightArrow.png" runat="server" Height="30px" Width="30px" OnClick="btnNextWeek_Click" /></asp:TableCell>
                      </asp:TableRow>
                  </asp:Table>
                  <br />
                  <asp:Table ID="Table2" runat="server"><asp:TableRow>
                      <asp:TableCell><asp:Label for="txtDateBegin" CssClass="control-label col-sm-2" runat="server" Text="Beginning Date:" Width="150px"></asp:Label></asp:TableCell><asp:TableCell><asp:TextBox ID="txtDateBegin" runat="server" CssClass="form-control" Width="110px"></asp:TextBox></asp:TableCell>
                  <asp:TableCell><asp:Label for="txtDateEnd" CssClass="control-label col-sm-2" runat="server" Text="Ending Date:" Width="130px"></asp:Label></asp:TableCell><asp:TableCell><asp:TextBox ID="txtDateEnd" runat="server" CssClass="form-control" Width="110px"></asp:TextBox></asp:TableCell>
                  </asp:TableRow></asp:Table>
                
            </div></div>

    <div class="form-group" style="width:100%">
        <asp:Label ID="Label2" CssClass="control-label col-sm-2" runat="server" Width="270px" Text="Approved or Not Approved time or All:"></asp:Label>
        <div class="col-sm-10">
            <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group">
        <div class="col-sm-10">
            <asp:CheckBox ID="cbByProject" runat="server" CssClass="checkboxPad" OnCheckedChanged="cbByProject_CheckedChanged" Text="Sort by Project"  AutoPostBack="true" />
        </div>
    </div>


    <div class="form-group">
        <div class="col-sm-10">
            <div class="checkbox">
                <asp:CheckBox ID="cbByEmployee" runat="server" CssClass="checkboxPad" OnCheckedChanged="cbByEmployee_CheckedChanged" Text="Sort by Employee" AutoPostBack="true" />
            </div>
        </div>
    </div>

    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
            <asp:Button ID="btnCreateExcel" runat="server" Text="Create Excel Report File" BorderStyle="Outset"  CssClass="btn btn-default" OnClick="btnCreateExcel_Click" />
        </div>
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
