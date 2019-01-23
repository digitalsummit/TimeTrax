<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ExcelReport1.aspx.cs" Inherits="TimeTrax.ExcelReport1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div id="divNotAuthorized" runat="server" visible="false">
        <asp:Label ID="Label5" runat="server" Text="Sorry, your user role does not allow for running this report."></asp:Label>

    </div>
    <div id="divAuthorized" runat="server" visible="false" class="form-group">
        <asp:Label ID="Label1" CssClass="control-label col-sm-2" runat="server" Text="Create Excel Report for:"></asp:Label>
        <div class="col-sm-10">
            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
    </div>

       <div class="form-group">
        <asp:Label ID="Label6" CssClass="control-label col-sm-2" runat="server" Text="Project Cost Report (Excel)"></asp:Label><br />
              <div class="form-group" style="float:left">
            <asp:Label for="txtDateBegin" CssClass="control-label col-sm-2" runat="server" Text="Beginning Date:"></asp:Label>
                <asp:TextBox ID="txtDateBegin" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label for="txtDateEnd" CssClass="control-label col-sm-2" runat="server" Text="Ending Date:"></asp:Label>
                <asp:TextBox ID="txtDateEnd" runat="server" CssClass="form-control"></asp:TextBox>
            </div></div>

    <div class="form-group">
        <asp:Label ID="Label2" CssClass="control-label col-sm-2" runat="server" Text="Approved or Not Approved time or All:"></asp:Label>
        <div class="col-sm-10">
            <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group">
        <asp:Label ID="Label3" CssClass="control-label col-sm-2" runat="server" Text="Project Report:"></asp:Label>
        <div class="col-sm-10">
            <asp:CheckBox ID="cbByProject" runat="server" OnCheckedChanged="cbByProject_CheckedChanged" AutoPostBack="true" />
        </div>
    </div>


    <div class="form-group">
        <asp:Label ID="Label4" CssClass="control-label col-sm-2" runat="server" Text="Employee Report:"></asp:Label>
        <div class="col-sm-10">
            <div class="checkbox">
                <asp:CheckBox ID="cbByEmployee" runat="server" OnCheckedChanged="cbByEmployee_CheckedChanged" AutoPostBack="true" />
            </div>
        </div>
    </div>

    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
            <asp:Button ID="btnCreateExcel" runat="server" Text="Create Excel Report File"  CssClass="btn btn-default" OnClick="btnCreateExcel_Click" />
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
