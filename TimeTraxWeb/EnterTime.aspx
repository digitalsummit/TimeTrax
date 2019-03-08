<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EnterTime.aspx.cs" Inherits="TimeTrax.EnterTime" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enter Time</title>
        <link rel="stylesheet" href="StyleSheet1.css"/>
</head>
<body>--%>

    <div runat="server" style="height: 50px; float:left"></div>
    <div style="width: 100%; float:left" runat="server">
        <%--<asp:Label ID="Label4" runat="server" Text="Improve Group TimeTrax" CssClass="titlebar"></asp:Label><p></p>--%>
        <asp:Label ID="lblWelcome" Visible="false" runat="server" Text="Label" CssClass="leftAlign"></asp:Label>
       
        <%--        <p></p>--%>


        <div class="form-group" style="float:left; padding-left:15px">

            <asp:Table ID="Table2" runat="server">
                <asp:TableRow>
                    <asp:TableCell CssClass="midAlign"><asp:Label for="txtDateWorked" runat="server" Text="Date Worked:" Width="150px"></asp:Label></asp:TableCell><asp:TableCell><asp:TextBox ID="txtDateWorked" runat="server" CssClass="form-control" Width="95px"></asp:TextBox></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell> 
                    <%--  CssClass="form-control"--%>
                </asp:TableRow>
                  <asp:TableRow>
                    <asp:TableCell>
                        <asp:TextBox ID="txtHoursAndMinutes" runat="server" Visible="true" Width="1px" ForeColor="White" BackColor="White" BorderStyle="None"></asp:TextBox></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="midAlign"><asp:Label ID="lblHoursWorked" CssClass="midAlign" runat="server" Text="Hours Worked:" Width="150px"></asp:Label></asp:TableCell><asp:TableCell><asp:DropDownList ID="ddlHours" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlHours_SelectedIndexChanged" Width="60px" AutoPostBack="true"></asp:DropDownList></asp:TableCell><asp:TableCell> 
                        <asp:DropDownList ID="ddlMinutes" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlMinutes_SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:DropDownList> </asp:TableCell><asp:TableCell></asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow Height="7px">
                    <asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell>
                </asp:TableRow>
                     <asp:TableRow>
                    <asp:TableCell CssClass="midAlign">
                                    <asp:Label ID="lblTravelTime" CssClass="midAlign" for="cbTravelTime" runat="server" Text="Travel Time:" Width="150px" Visible="false"></asp:Label>
                    </asp:TableCell>
                         <asp:TableCell>
                                             <asp:CheckBox ID="cbTravelTime" runat="server" CssClass="CheckboxTravelTime" OnCheckedChanged="cbTravelTime_CheckedChanged" AutoPostBack="true" Visible="false" />

                         </asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="midAlign"><asp:Label ID="lblWageScale" CssClass="midAlign" for="cbWageScale" runat="server" Text="Wage Scale:" Width="150px" Visible="false"></asp:Label>

</asp:TableCell>
<asp:TableCell>
<asp:CheckBox ID="cbWageScale" runat="server" OnCheckedChanged="cbWageScale_CheckedChanged" AutoPostBack="true" Visible="false" />
</asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell>
                </asp:TableRow>

            </asp:Table>
            
          
        </div>
        <div class="form-group" style="float:left">
            
            <div class="col-sm-10" style="max-width: 200px">
                
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
                <div style="border: solid 3px gray; padding-left:7px"" >
                <div id="scaled" class="scaled" >
                    <asp:Table runat="server" CssClass="SelectedView" ID="tblView1" >
                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top">

                                <div class="form-row" >
                                    <div class="form-group col-md-6" style="float:left; padding-left:15px" >
                                        <asp:CheckBox ID="cbProjectNumber" runat="server" Text="Project#:" Checked="true" AutoPostBack="true" OnCheckedChanged="cbProjectNumber_CheckedChanged" CssClass="checkboxPad" />
                                    </div>
                                    <div class="form-group col-md-6">
                                        <asp:TextBox ID="txtProjectNumber" runat="server" CssClass="form-control" PlaceHolder="Project Number"></asp:TextBox>
                                    </div>
                                </div>

                            </asp:TableCell>
                              <asp:TableCell VerticalAlign="Top">
                            <asp:Button ID="btnGetProjectName" runat="server" Text="Check Project Title" OnClick="btnGetProjectName_Click" CssClass="optionButton" />
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
                      
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:TextBox ID="txtProjectName" runat="server" CssClass="textShortAnswer" Width="400px" BorderStyle="None"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Height="50px" CssClass="tableRowLarge">
                        <asp:TableCell Width="100%">
                            <asp:CheckBox ID="cbShareAcross" runat="server" Text="Share Across Projects" CssClass="checkboxPad" AutoPostBack="true" OnCheckedChanged="cbShareAcross_CheckedChanged"  />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Height="50px" CssClass="tableRowLarge">
                        <asp:TableCell Width="100%">
                            <asp:CheckBox ID="cbPreProject" runat="server" Text="Preproject (BD / Sales)" CssClass="checkboxPad" AutoPostBack="true" OnCheckedChanged="cbPreProject_CheckedChanged" />
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
                    <asp:TableRow >
                        <asp:TableCell Width="200px">
                            <asp:CheckBox ID="cbCorporateEvents" runat="server" Text="Corporate Events" AutoPostBack="true" OnCheckedChanged="cbCorporateEvents_CheckedChanged" CssClass="checkboxPad" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Height="50px" >
                        <asp:TableCell><asp:CheckBox ID="cbPTO" runat="server" Text="PTO" AutoPostBack="true" OnCheckedChanged="cbPTO_CheckedChanged" CssClass="checkboxPad" /></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:CheckBox ID="cbHoliday" runat="server" Text="Holiday" AutoPostBack="true" OnCheckedChanged="cbHoliday_CheckedChanged" CssClass="checkboxPad" />
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
                    <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" OnClick="btnSubmit_Click" CssClass="submitButton" ValidationGroup="ProjectBased" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic" Text="Note required if no project#" ControlToValidate="txtPreProjectNotes" Enabled="false" Font-Bold="True" ForeColor="Red" ValidationGroup="ProjectBased"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic" Text="Enter Project# or Select another option" ControlToValidate="txtProjectNumber" Enabled="false" Font-Bold="True" ForeColor="Red" ValidationGroup="ProjectBased"></asp:RequiredFieldValidator>
                    <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Must choose hours" ControlToValidate="txtHoursAndMinutes" ValueToCompare="0" Operator="NotEqual" Type="Double" ForeColor="Red" Font-Bold="true" ValidationGroup="ProjectBased"></asp:CompareValidator>--%>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Must choose hours" ControlToValidate="ddlHours" ValueToCompare="0" Operator="NotEqual" Type="Double" ForeColor="Red" Font-Bold="true" ValidationGroup="ProjectBased"></asp:CompareValidator>
                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer"  ControlToValidate="txtProjectNumber" ErrorMessage="Project Number must be a Number" ValidationGroup="ProjectBased" ForeColor="Red" Display="Dynamic" Enabled="true" />
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic" Text="Note required" ControlToValidate="txtOther" Enabled="false" Font-Bold="True" ForeColor="Red" ValidationGroup="Overhead"></asp:RequiredFieldValidator>--%>
                    <asp:CustomValidator ControlToValidate="txtProjectNumber" OnServerValidate="IsTextboxValid"  Display="Dynamic" Text="Enter Project# " runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="ProjectBased" ValidateEmptyText="True" />
                    <asp:Label ID="lblSubmitView2" runat="server" Text="" Font-Size="20pt"></asp:Label>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Must choose hours" ControlToValidate="txtHoursAndMinutes" ValueToCompare="0" Operator="NotEqual" Type="Double" ForeColor="Red" Font-Bold="true" ValidationGroup="Overhead"></asp:CompareValidator>
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
