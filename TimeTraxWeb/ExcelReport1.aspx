<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ExcelReport1.aspx.cs" Inherits="TimeTrax.ExcelReport1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group">
        <asp:Label ID="Label1" CssClass="control-label col-sm-2" runat="server" Text="Create Excel Report for:"></asp:Label>
        <div class="col-sm-10">
            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
    </div>

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

    <%--div runat="server" class="scaled7">
        <%--<asp:Label ID="Label1" runat="server" Text="Create Excel Report for:"></asp:Label><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>--%>
    <%--<asp:Label ID="Label2" runat="server" Text="Approved or Not Apprved time or All"></asp:Label><asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>--%>
    <%--        <asp:CheckBox ID="cbByProject" runat="server" CssClass="CheckboxStandard" Text="Project Report" OnCheckedChanged="cbByProject_CheckedChanged" AutoPostBack="true" />
        <asp:CheckBox ID="cbByEmployee" runat="server" CssClass="CheckboxStandard" Text="Employee Report" OnCheckedChanged="cbByEmployee_CheckedChanged" AutoPostBack="true" />
    </div>
    <div>
        <asp:Button ID="btnCreateExcel" runat="server" Text="Create Excel Report File" Font-Size="36pt" CssClass="optionButton" OnClick="btnCreateExcel_Click" />
        <asp:Button ID="Button2" runat="server" Text="Home" OnClick="Button2_Click" CssClass="submitButton" />
    </div>--%>
</asp:Content>
