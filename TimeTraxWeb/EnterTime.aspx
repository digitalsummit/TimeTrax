<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EnterTime.aspx.cs" Inherits="TimeTrax.EnterTime" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enter Time</title>
        <link rel="stylesheet" href="StyleSheet1.css"/>
</head>
<body>--%>

    <div runat="server" style="height: 50px"></div>
    <div style="width: 100%;" runat="server">
        <%--<asp:Label ID="Label4" runat="server" Text="Improve Group TimeTrax" CssClass="titlebar"></asp:Label><p></p>--%>
        <asp:Label ID="lblWelcome" Visible="false" runat="server" Text="Label" CssClass="labelWide"></asp:Label>
       
        <%--        <p></p>--%>


        <div class="form-group">
            <asp:Label for="txtDateWorked" CssClass="control-label col-sm-2" runat="server" Text="Date submitted for:"></asp:Label>
            <div class="col-sm-10" style="max-width: 200px">
                <asp:TextBox ID="txtDateWorked" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label3" CssClass="control-label col-sm-2" runat="server" Text="Hours:"></asp:Label>
            <div class="col-sm-10" style="max-width: 200px">
                <asp:DropDownList ID="ddlHours" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlHours_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label2" CssClass="control-label col-sm-2" for="cbTravelTime" runat="server" Text="Travel Time:"></asp:Label>
            <div class="col-sm-10">
                <asp:CheckBox ID="cbTravelTime" runat="server" CssClass="CheckboxTravelTime" OnCheckedChanged="cbTravelTime_CheckedChanged" AutoPostBack="true" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label1" CssClass="control-label col-sm-2" for="cbWageScale" runat="server" Text="Wage Scale:"></asp:Label>
            <div class="col-sm-10">
                <asp:CheckBox ID="cbWageScale" runat="server" OnCheckedChanged="cbWageScale_CheckedChanged" AutoPostBack="true" />
            </div>
        </div>

        <%--  <div class="form-group">
    <label for="pwd">Password:</label>
    <input type="password" class="form-control" id="pwd">
  </div>


                            <div style="float: right" id="divCalendar" runat="server">
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Arial" Font-Size="24pt" ForeColor="#003399" Height="400px" Width="427px" OnPreRender="Calendar1_PreRender" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender">
                            <DayHeaderStyle BackColor="#D5F9EF" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" Font-Size="Medium" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="White" Height="25px" />
                            <WeekendDayStyle BackColor="#FBECEA" />
                        </asp:Calendar>
                        <p></p>
                    </div>
            <div style="width: 100%; float: left" runat="server">
            <asp:Table runat="server" ID="tblDateTime" Width="100%">
                   <asp:TableRow>
                                <asp:TableCell Width="17%">
                                    <asp:Label ID="lblDateWorked" runat="server" Text="Date submitted for:" CssClass="labelStandard"></asp:Label>
                                </asp:TableCell><asp:TableCell Width="20%">
                                    <asp:TextBox ID="txtDateWorked" runat="server" CssClass="textBoxDate"></asp:TextBox>
                                </asp:TableCell><asp:TableCell>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/CalendarButton.png" OnClick="ImageButton1_Click" />
                                </asp:TableCell>
                            </asp:TableRow>-
                <asp:TableRow Height="150px">
                    <asp:TableCell>
                                <asp:Label ID="Label1" runat="server" Text="Hours" CssClass="labelStandard"></asp:Label>
                            </asp:TableCell><asp:TableCell>
                                <asp:DropDownList ID="ddlHours" runat="server" CssClass="DropDownStandard" OnSelectedIndexChanged="ddlHours_SelectedIndexChanged"></asp:DropDownList>
                            </asp:TableCell>
                  <asp:TableCell>
                        <asp:CheckBox ID="cbWageScale" runat="server" Text="Wage Scale" CssClass="CheckboxStandard" OnCheckedChanged="cbWageScale_CheckedChanged" AutoPostBack="true" />
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>--%>
    </div>
    <div style="float: left; width: 100%" runat="server" id="divTabButtons">
        <asp:Button Text="Project Based" BorderStyle="Solid" BorderWidth="3px" BorderColor="DarkGray" ID="Tab1" CssClass="add-on" runat="server" ValidationGroup="None"
            OnClick="Tab1_Click" />

        <asp:Button Text="Overhead" BorderStyle="Solid" BorderWidth="3px" BorderColor="LightGray" ID="Tab2" CssClass="Initial" runat="server" ValidationGroup="None"
            OnClick="Tab2_Click" />
    </div>
    <p></p>
    <div style="float: left; width: 100%" runat="server" id="divMultiView">
        <asp:MultiView ID="MainView" runat="server">
            <asp:View ID="View1" runat="server">
                <div style="border: solid 3px gray;" >
                <div id="scaled" class="scaled">
                    <asp:Table runat="server" CssClass="SelectedView" ID="tblView1" >
                        <asp:TableRow>
                            <asp:TableCell>

                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <%--<asp:RadioButton ID="rbProjectNumber" Text="Project Number" runat="server" GroupName="rbProjectBased" />--%>
                                        <asp:CheckBox ID="cbProjectNumber" runat="server" Text="Project#:" Checked="true" AutoPostBack="true" OnCheckedChanged="cbProjectNumber_CheckedChanged" CssClass="CheckboxOther" />
                                    </div>
                                    <div class="form-group col-md-6">
                                        <asp:TextBox ID="txtProjectNumber" runat="server" CssClass="form-control" PlaceHolder="Project Number"></asp:TextBox>
                                    </div>
                                </div>

                                <%--                                <div class="form-group">
                                    <%--                                    <asp:Label ID="Label4" CssClass="control-label col-sm-2" for="rbProjectNumber" runat="server" Text="Project Number:"></asp:Label>--%>
                                <%--                                 <label class="radio-inline">
                                        Project Number</label>--%>
                                <%--                               <div class="col-sm-10">
                                        
                                    </div>--%>

                                <%--                                    <div class="col-sm-10">--%>

                                <%--</div>
                                </div>--%>
                            </asp:TableCell>

                            <%--  <asp:CheckBox ID="cbProjectNumber" runat="server" Text="Project#:" Checked="true" AutoPostBack="true" OnCheckedChanged="cbProjectNumber_CheckedChanged" CssClass="CheckboxOther" />
                            </asp:TableCell><asp:TableCell>
                                <asp:TextBox ID="txtProjectNumber" runat="server" CssClass="textNote" Font-Size="36pt" Width="300px" OnTextChanged="txtProjectNumber_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </asp:TableCell><asp:TableCell Width="300px"></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            --%>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <asp:Table runat="server" CssClass="SelectedView" ID="Table1">
                    <asp:TableRow>
                        <asp:TableCell>
                            <%--<asp:CheckBox ID="cbTravelTime" runat="server" Text="Travel Time" CssClass="CheckboxTravelTime" OnCheckedChanged="cbTravelTime_CheckedChanged" AutoPostBack="true" />--%>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button ID="btnGetProjectName" runat="server" Text="Check Project Title" OnClick="btnGetProjectName_Click" CssClass="optionButton" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:TextBox ID="txtProjectName" runat="server" CssClass="textShortAnswer" BorderStyle="None"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Height="150px" CssClass="tableRowLarge">
                        <asp:TableCell Width="100%">
                            <asp:CheckBox ID="cbPreProject" runat="server" Text="Preproject / BD / Prospecting" CssClass="CheckboxWide" AutoPostBack="true" OnCheckedChanged="cbPreProject_CheckedChanged" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblShortNote" runat="server" Text="Enter up to 50 character note:" CssClass="labelStandard" Visible="false">
                                <%--<asp:Label ID="lblcharCountOutput" runat="server" Text="Enter up to 50 characters"></asp:Label>--%>

                            </asp:Label><asp:TextBox ID="txtPreProjectNotes" runat="server" TextMode="SingleLine" MaxLength="50" Width="80%" Text="" Visible="false"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table></div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div style="border: solid 3px gray; ">
                <asp:Table runat="server" ID="tblView2" CssClass="UnselectedView" >
                    <asp:TableRow Height="100px">
                        <asp:TableCell Width="200px">
                            <asp:CheckBox ID="cbCorporateEvents" runat="server" Text="Corporate Events" AutoPostBack="true" OnCheckedChanged="cbCorporateEvents_CheckedChanged" CssClass="CheckboxStandard" />
                        </asp:TableCell><asp:TableCell>
                            <asp:CheckBox ID="cbPTO" runat="server" Text="PTO" AutoPostBack="true" OnCheckedChanged="cbPTO_CheckedChanged" CssClass="CheckboxStandard" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:CheckBox ID="cbHoliday" runat="server" Text="Holiday" AutoPostBack="true" OnCheckedChanged="cbHoliday_CheckedChanged" CssClass="CheckboxWide" />
                        </asp:TableCell>
                    </asp:TableRow>
         <%--           <asp:TableRow>
                        <asp:TableCell>
                            <asp:CheckBox ID="cbOther" runat="server" Text="Other:" AutoPostBack="true" OnCheckedChanged="cbOther_CheckedChanged" CssClass="CheckboxOther" />
                        </asp:TableCell><asp:TableCell>
                            <asp:Label ID="lblOtherNote" runat="server" Text="Enter up to 50 character note:" Visible="false"></asp:Label>
                            <asp:TextBox ID="txtOther" runat="server" CssClass="textNote" Font-Size="36pt" TextMode="SingleLine" MaxLength="50" Width="80%" Visible="false"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>--%>
                 <%--   <asp:TableRow>
                        <asp:TableCell></asp:TableCell><asp:TableCell><p></p></asp:TableCell>
                    </asp:TableRow>--%>
                </asp:Table></div>
            </asp:View>
        </asp:MultiView>
    </div>
    <div style="float: left; width: 100%" runat="server" id="btnDiv">
        <asp:Table runat="server" ID="tblButtons" HorizontalAlign="Left">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic" Text="Note required if no project#" ControlToValidate="txtPreProjectNotes" Enabled="false" Font-Bold="True" ForeColor="Red" ValidationGroup="ProjectBased"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic" Text="Enter Project# or Select another option" ControlToValidate="txtProjectNumber" Enabled="false" Font-Bold="True" ForeColor="Red" ValidationGroup="ProjectBased"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Must choose hours" ControlToValidate="ddlHours" ValueToCompare="0" Operator="NotEqual" Type="Double" ForeColor="Red" Font-Bold="true" ValidationGroup="ProjectBased"></asp:CompareValidator>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic" Text="Note required" ControlToValidate="txtOther" Enabled="false" Font-Bold="True" ForeColor="Red" ValidationGroup="Overhead"></asp:RequiredFieldValidator>--%>
                    <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" OnClick="btnSubmit_Click" CssClass="submitButton" ValidationGroup="ProjectBased" />
                     <asp:Label ID="lblSubmitView2" runat="server" Text="" Font-Size="20pt"></asp:Label>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Must choose hours" ControlToValidate="ddlHours" ValueToCompare="0" Operator="NotEqual" Type="Double" ForeColor="Red" Font-Bold="true" ValidationGroup="Overhead"></asp:CompareValidator>
                </asp:TableCell><asp:TableCell>
                  <%--  <asp:Label ID="lblSubmitView2" runat="server" Text="" Font-Size="36pt"></asp:Label>--%>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>
    </div>

    <script type="text/javascript">
        $(function () {
            $('#MainContent_txtDateWorked').datepicker({
                autoclose: true
            });
        });
    </script>

</asp:Content>

<%--</body>
</html>--%>
