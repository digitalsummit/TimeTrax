
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EnterTime.aspx.cs" Inherits="TimeTrax.EnterTime" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enter Time</title>
        <link rel="stylesheet" href="StyleSheet1.css"/>
</head>
<body>--%>


        <div style="float:left; width:100%">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div style="width:100%" runat="server">
        <%--<asp:Label ID="Label4" runat="server" Text="Improve Group TimeTrax" CssClass="titlebar"></asp:Label><p></p>--%>
        <asp:Label ID="lblWelcome" Visible="false" runat="server" Text="Label" CssClass="labelWide"></asp:Label>
<%--        <p></p>--%>
        
            <div style="float:right" id="divCalendar" runat="server" >
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Arial" Font-Size="24pt" ForeColor="#003399" Height="400px" Width="427px" OnPreRender="Calendar1_PreRender" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender" >
                <DayHeaderStyle BackColor="#D5F9EF" ForeColor="#336666" Height="1px" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#009999" Font-Bold="True" Font-Size="Medium" ForeColor="#CCFF99" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="White" Height="25px" />
                <WeekendDayStyle BackColor="#FBECEA" />
            </asp:Calendar><p></p>
                 </div>
        <div style="width:100%; float:left" runat="server">
            <asp:Table runat="server" ID="tblDateTime" Width="100%">
                <asp:TableRow><asp:TableCell Width="17%"><asp:Label ID="lblDateWorked" runat="server" Text="Date submitted for:" CssClass="labelStandard"></asp:Label></asp:TableCell><asp:TableCell Width="20%"><asp:TextBox ID="txtDateWorked" runat="server" CssClass="textBoxDate"></asp:TextBox></asp:TableCell><asp:TableCell><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/CalendarButton.png" OnClick="ImageButton1_Click" /></asp:TableCell></asp:TableRow>
                <asp:TableRow Height="150px"><asp:TableCell><asp:Label ID="Label1" runat="server" Text="Hours" CssClass="labelStandard" ></asp:Label></asp:TableCell><asp:TableCell><asp:DropDownList ID="ddlHours" runat="server" CssClass="DropDownStandard" OnSelectedIndexChanged="ddlHours_SelectedIndexChanged"> </asp:DropDownList></asp:TableCell><asp:TableCell>
                    <asp:CheckBox ID="cbWageScale" runat="server" Text="Wage Scale" CssClass="CheckboxStandard"  OnCheckedChanged="cbWageScale_CheckedChanged" AutoPostBack="true" /></asp:TableCell>
                 <asp:TableCell></asp:TableCell></asp:TableRow>
            </asp:Table>
         </div>
    </div>
            <div style="float:left;width:100%" runat="server" id="divTabButtons">
          <asp:Button Text="Project Based" BorderStyle="None" ID="Tab1" CssClass="Initial" runat="server"
                     OnClick="Tab1_Click" />

          <asp:Button Text="Overhead" BorderStyle="None" ID="Tab2" CssClass="Initial" runat="server"
                            OnClick="Tab2_Click" /></div><p></p>
<div style="float:left;width:100%" runat="server" id="divMultiView" >
          <asp:MultiView ID="MainView" runat="server">
            <asp:View ID="View1" runat="server"><div id="scaled" class="scaled">
                <asp:Table runat="server" CssClass="SelectedView" ID="tblView1">
                        <asp:TableRow><asp:TableCell ><asp:CheckBox ID="cbProjectNumber" runat="server" Text="Project#:" Checked="true" AutoPostBack="true"  OnCheckedChanged="cbProjectNumber_CheckedChanged" CssClass="CheckboxOther" /> </asp:TableCell><asp:TableCell><asp:TextBox ID="txtProjectNumber" runat="server" CssClass="textNote" Font-Size="36pt" Width="300px"></asp:TextBox></asp:TableCell><asp:TableCell Width="300px"></asp:TableCell></asp:TableRow>
                    <asp:TableRow > </asp:TableRow> </asp:Table>
                </div>
                <asp:Table runat="server" CssClass="SelectedView" ID="Table1"><asp:TableRow>
                             <asp:TableCell><asp:CheckBox ID="cbDriveTime" runat="server" Text="Travel Time" CssClass="CheckboxTravelTime" OnCheckedChanged="cbDriveTime_CheckedChanged" AutoPostBack="true" /></asp:TableCell></asp:TableRow>
                    <asp:TableRow><asp:TableCell>
                      <asp:Button ID="btnGetProjectName" runat="server" Text="Get Project Title" OnClick="btnGetProjectName_Click" CssClass="optionButton"/></asp:TableCell></asp:TableRow>
                    <asp:TableRow><asp:TableCell>
                <asp:TextBox ID="txtProjectName" runat="server" CssClass="textShortAnswer"></asp:TextBox></asp:TableCell></asp:TableRow>
                <asp:TableRow Height="150px" CssClass="tableRowLarge"><asp:TableCell Width="100%"><asp:CheckBox ID="cbPreProject" runat="server" Text="No Project Number Yet" CssClass="CheckboxWide" AutoPostBack="true" OnCheckedChanged="cbPreProject_CheckedChanged" /></asp:TableCell></asp:TableRow>
                   <asp:TableRow><asp:TableCell> <asp:Label ID="Label2" runat="server" Text="Short Note:" CssClass="labelStandard"></asp:Label><asp:TextBox ID="txtPreProjectNotes" runat="server" TextMode="MultiLine" CssClass="textNote" Text=""></asp:TextBox>
        </asp:TableCell></asp:TableRow>
                    </asp:Table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:Table runat="server" ID="tblView2" CssClass="UnselectedView"><asp:TableRow Height="250px"><asp:TableCell Width="650px"><asp:CheckBox ID="cbTraining" runat="server" Text="Training"  AutoPostBack="true" OnCheckedChanged="cbTraining_CheckedChanged" CssClass="CheckboxStandard" /></asp:TableCell><asp:TableCell><asp:CheckBox ID="cbPTO" runat="server" Text="PTO/Holiday"  AutoPostBack="true" OnCheckedChanged="cbPTO_CheckedChanged" CssClass="CheckboxStandard" /></asp:TableCell></asp:TableRow>
                    <asp:TableRow><asp:TableCell><asp:CheckBox ID="cbStrategicInitiative" runat="server" Text="Strategic Initiative"  AutoPostBack="true" OnCheckedChanged="cbStrategicInitiative_CheckedChanged" CssClass="CheckboxWide"  /></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:CheckBox ID="cbOther" runat="server" Text="Other:" AutoPostBack="true"  OnCheckedChanged="cbOther_CheckedChanged" CssClass="CheckboxOther" /> </asp:TableCell><asp:TableCell><asp:TextBox ID="txtOther" runat="server" CssClass="textNote" Font-Size="36pt"></asp:TextBox></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell></asp:TableCell><asp:TableCell><p></p></asp:TableCell></asp:TableRow>
                </asp:Table>=
            </asp:View>
          </asp:MultiView>
</div>
    <div style="float:left; width:100%" runat="server" id="btnDiv">
        <asp:Table runat="server" ID="tblButtons" HorizontalAlign="Left"><asp:TableRow><asp:TableCell><asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" OnClick="btnSubmit_Click"  CssClass="submitButton"/></asp:TableCell><asp:TableCell><asp:Label ID="lblSubmitView2" runat="server" Text="" Font-Size="36pt"></asp:Label></asp:TableCell></asp:TableRow>
            <asp:TableRow><asp:TableCell><asp:Button ID="btnHome" runat="server" Text="Home" OnClick="btnHome_Click" CssClass="homeButton" /></asp:TableCell><asp:TableCell></asp:TableCell></asp:TableRow>
        </asp:Table>
    </div>
                </ContentTemplate>
        </asp:UpdatePanel>
</div>


</asp:Content>

<%--</body>
</html>--%>
