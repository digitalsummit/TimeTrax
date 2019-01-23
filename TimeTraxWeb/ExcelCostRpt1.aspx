<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExcelCostRpt1.aspx.cs" Inherits="TimeTrax.ExcelCostRpt1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divNotAuthorized" runat="server" visible="false">
        <asp:Label ID="Label3" runat="server" Text="Sorry, your user role does not allow for running this report."></asp:Label>

    </div>
    <div id="divAuthorized" runat="server" visible="false">
    <div class="form-group">
        <asp:Label ID="Label1" CssClass="control-label col-sm-2" runat="server" Text="Project Cost Report (Excel)"></asp:Label><br />
              <div class="form-group" style="float:left">
            <asp:Label for="txtDateBegin" CssClass="control-label col-sm-2" runat="server" Text="Beginning Date:"></asp:Label>
                <asp:TextBox ID="txtDateBegin" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label for="txtDateEnd" CssClass="control-label col-sm-2" runat="server" Text="Ending Date:"></asp:Label>
                <asp:TextBox ID="txtDateEnd" runat="server" CssClass="form-control"></asp:TextBox>
            </div></div>

    <div class="form-group">
             <div class="col-sm-10">
            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
        </div>
        </div>


    
    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
            <asp:Button ID="btnCreateExcel" runat="server" Text="Create Excel Report File"  CssClass="btn btn-default" OnClick="btnCreateExcel_Click" /><br />
            <asp:Label ID="Label2" runat="server" Text="This report calculates the number of hours for the manager based on the number of workdays between the date range (inclusive).  Don’t include today’s date in the range unless it is currently after 5 PM. Only project hours entered by the manager's staff are selected."></asp:Label>
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

