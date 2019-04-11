<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EnterTime.aspx.cs" Inherits="TimeTrax.EnterTime" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="align-content:center"><asp:Label ID="Label3" runat="server" Text="Submit Time" Font-Bold="true" Font-Size="X-Large" Font-Names="Arial"></asp:Label></div>
    <%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enter Time</title>
        <link rel="stylesheet" href="StyleSheet1.css"/>
</head>
<body>--%>
    <asp:Table ID="Table3" runat="server"><asp:TableRow><asp:TableCell Width="120px"><asp:Button ID="btnOpenImpersonate" runat="server" Text="Impersonate" OnClick="btnOpenImpersonate_Click" /></asp:TableCell><asp:TableCell><asp:Label ID="lblNowImpersonating" runat="server" Text="" BackColor="Yellow"></asp:Label></asp:TableCell></asp:TableRow></asp:Table>
    <div id="divAuthorized" runat="server" style="border:double; width:90%" visible="false">
    <asp:Label ID="Label2" runat="server" Text="Choose User to Impersonate"></asp:Label><br />
    <asp:DropDownList ID="DropDownListEmployees" runat="server" OnSelectedIndexChanged="DropDownListEmployees_SelectedIndexChanged" AutoPostBack="true" BackColor="Yellow"></asp:DropDownList><br />
        <asp:Button ID="btnImpersonateOK" runat="server" Text="Confirm" OnClick="btnImpersonateOK_Click" Visible="false" BackColor="Yellow" BorderStyle="Outset" BorderWidth="5px" />
        <asp:Button ID="btnCancelImpersonate" runat="server" Text="Cancel Impersonation" OnClick="btnCancelImpersonate_Click" />
        </div>

    <div style="width: 100%; float:left" runat="server">
        <asp:Button ID="btnImpersonate" runat="server" Text="Impersonate" Visible="false" OnClick="btnImpersonate_Click" />
        <%--<asp:Label ID="Label4" runat="server" Text="Improve Group TimeTrax" CssClass="titlebar"></asp:Label><p></p>--%>
        <asp:Label ID="lblWelcome" Visible="false" runat="server" Text="Label" CssClass="leftAlign" Font-Names="Arial"></asp:Label>
       
        <%--        <p></p>--%>


        <div class="form-group" style="float:left; padding-left:15px">

            <asp:Table ID="Table2" runat="server">
                <asp:TableRow>
                    <asp:TableCell CssClass="midAlign"><asp:Label for="txtDateWorked" runat="server" Text="Date Worked:" Font-Names="Arial" Width="150px"></asp:Label></asp:TableCell><asp:TableCell><asp:TextBox ID="txtDateWorked" runat="server" CssClass="form-control" Width="95px" Font-Names="Arial"></asp:TextBox></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell> 
                    <%--  CssClass="form-control"--%>
                </asp:TableRow>
                  <asp:TableRow>
                    <asp:TableCell>
                        <asp:TextBox ID="txtHoursAndMinutes" runat="server" Visible="true" Width="1px" ForeColor="White" BackColor="White" BorderStyle="None" Font-Names="Arial"></asp:TextBox></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="midAlign"><asp:Label ID="lblHoursWorked" CssClass="midAlign" runat="server" Text="Hours Worked:" Width="150px" Font-Names="Arial"></asp:Label></asp:TableCell><asp:TableCell><asp:DropDownList ID="ddlHours" runat="server" CssClass="form-control" Font-Names="Arial" OnSelectedIndexChanged="ddlHours_SelectedIndexChanged" Width="60px" AutoPostBack="true"></asp:DropDownList></asp:TableCell><asp:TableCell> 
                        <asp:DropDownList ID="ddlMinutes" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlMinutes_SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:DropDownList> </asp:TableCell><asp:TableCell></asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow Height="7px">
                    <asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell>
                </asp:TableRow>
                     <asp:TableRow>
                    <asp:TableCell CssClass="midAlign">
                                    <asp:Label ID="lblTravelTime" CssClass="midAlign" for="cbTravelTime" runat="server" Text="Travel Time:" Font-Names="Arial" Width="150px" Visible="false"></asp:Label>
                    </asp:TableCell>
                         <asp:TableCell>
                                             <asp:CheckBox ID="cbTravelTime" runat="server" CssClass="CheckboxTravelTime" OnCheckedChanged="cbTravelTime_CheckedChanged" AutoPostBack="true" Visible="false" />

                         </asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="midAlign"><asp:Label ID="lblWageScale" CssClass="midAlign" for="cbWageScale" runat="server" Text="Wage Scale:" Width="150px" Visible="false" Font-Names="Arial"></asp:Label>

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



    </div>
    <div style="float: left; width: 100%" runat="server" id="divTabButtons">
        <asp:Button Text="Project Based" BorderStyle="Solid" BorderWidth="3px" BorderColor="DarkGray" ID="Tab1" CssClass="add-on" runat="server" Font-Names="Arial" ValidationGroup="None"
            OnClick="Tab1_Click" />

        <asp:Button Text="Overhead" BorderStyle="Solid" BorderWidth="3px" BorderColor="LightGray" ID="Tab2" CssClass="Initial" runat="server" Font-Names="Arial" ValidationGroup="None"
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
                                        <asp:CheckBox ID="cbProjectNumber" runat="server" Text="Project#:" Checked="true" AutoPostBack="true" OnCheckedChanged="cbProjectNumber_CheckedChanged" Font-Names="Arial" CssClass="checkboxPad" />
                                    </div>
                                    <div class="form-group col-md-6">
                                        <asp:TextBox ID="txtProjectNumber" runat="server" CssClass="form-control" Font-Names="Arial" PlaceHolder="Project Number"></asp:TextBox>
                                    </div>
                                </div>

                            </asp:TableCell>
                              <asp:TableCell VerticalAlign="Top">
                            <asp:Button ID="btnGetProjectName" runat="server" Text="Check Project Title" Height="32px" OnClick="btnGetProjectName_Click" Font-Names="Arial" CssClass="optionButton" />
                        </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <asp:Table runat="server" CssClass="SelectedView" ID="Table1">
                    <asp:TableRow>
                        <asp:TableCell>
                            
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                      <asp:TableCell>
                          <div runat="server" id="divPopupMessage" style="height:80px; border:dotted; border-color:red" >
                          <asp:Label ID="lblMessage" runat="server" Text="" Font-Names="Arial"></asp:Label><br />
                              <asp:Label ID="Label1" runat="server" Text="CLICK OK TO CONTINUE" Font-Names="Arial"></asp:Label><br />
                              <asp:Button ID="btnMessageOK" runat="server" Text="OK" OnClick="btnMessageOK_Click" Width="150px" BackColor="#ff6666" Font-Bold="true" Font-Names="Arial" />
                              </div>
                      </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:TextBox ID="txtProjectName" runat="server" CssClass="textShortAnswer" Font-Names="Arial" Width="400px" BorderStyle="None"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Height="50px" CssClass="tableRowLarge">
                        <asp:TableCell Width="100%">
                            <asp:CheckBox ID="cbShareAcross" runat="server" Text="Share Across Projects" Font-Names="Arial" CssClass="checkboxPad" AutoPostBack="true" OnCheckedChanged="cbShareAcross_CheckedChanged"  />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Height="50px" CssClass="tableRowLarge">
                        <asp:TableCell Width="100%">
                            <asp:CheckBox ID="cbPreProject" runat="server" Text="Pre-Project (BD / Sales)" CssClass="checkboxPad" AutoPostBack="true" Font-Names="Arial" OnCheckedChanged="cbPreProject_CheckedChanged" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblShortNote" runat="server" Text="Enter up to 50 character note:" CssClass="labelStandard" Font-Names="Arial" Visible="false">
                            </asp:Label><asp:TextBox ID="txtPreProjectNotes" runat="server" TextMode="SingleLine" MaxLength="50" Width="80%" Text="" Visible="false" Font-Names="Arial"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table></div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div style="border: solid 3px gray;padding-left:7px ">
                <asp:Table runat="server" ID="tblView2" CssClass="UnselectedView" >
                    <asp:TableRow >
                        <asp:TableCell Width="200px">
                            <asp:CheckBox ID="cbCorporateEvents" runat="server" Text="Corporate Events" Font-Names="Arial" AutoPostBack="true" OnCheckedChanged="cbCorporateEvents_CheckedChanged" CssClass="checkboxPad" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Height="50px" >
                        <asp:TableCell><asp:CheckBox ID="cbPTO" runat="server" Text="PTO" AutoPostBack="true" Font-Names="Arial" OnCheckedChanged="cbPTO_CheckedChanged" CssClass="checkboxPad" /></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:CheckBox ID="cbHoliday" runat="server" Text="Holiday" AutoPostBack="true" Font-Names="Arial" OnCheckedChanged="cbHoliday_CheckedChanged" CssClass="checkboxPad" />
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
                    <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" OnClick="btnSubmit_Click" Font-Names="Arial" CssClass="submitButton" ValidationGroup="ProjectBased" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Font-Names="Arial" Display="Dynamic" Text="Note required if no project#" ControlToValidate="txtPreProjectNotes" Enabled="false" Font-Bold="True" ForeColor="Red" ValidationGroup="ProjectBased"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" Font-Names="Arial" Display="Dynamic" Text="Enter Project# or Select another option" ControlToValidate="txtProjectNumber" Enabled="false" Font-Bold="True" ForeColor="Red" ValidationGroup="ProjectBased"></asp:RequiredFieldValidator>
                    <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Must choose hours" ControlToValidate="txtHoursAndMinutes" ValueToCompare="0" Operator="NotEqual" Type="Double" ForeColor="Red" Font-Bold="true" ValidationGroup="ProjectBased"></asp:CompareValidator>--%>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Must choose hours" Font-Names="Arial" ControlToValidate="ddlHours" ValueToCompare="0" Operator="NotEqual" Type="Double" ForeColor="Red" Font-Bold="true" ValidationGroup="ProjectBased"></asp:CompareValidator>
                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer"  ControlToValidate="txtProjectNumber" Font-Names="Arial" ErrorMessage="Project Number must be a Number" ValidationGroup="ProjectBased" ForeColor="Red" Display="Dynamic" Enabled="true" />
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic" Text="Note required" ControlToValidate="txtOther" Enabled="false" Font-Bold="True" ForeColor="Red" ValidationGroup="Overhead"></asp:RequiredFieldValidator>--%>
                    <asp:CustomValidator ControlToValidate="txtProjectNumber" OnServerValidate="IsTextboxValid"  Display="Dynamic" Text="Enter Project# " runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="Red" ValidationGroup="ProjectBased" ValidateEmptyText="True" />
                    <asp:Label ID="lblSubmitView2" runat="server" Text="" Font-Size="20pt" Font-Names="Arial"></asp:Label>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" Font-Names="Arial" ErrorMessage="Must choose hours" ControlToValidate="txtHoursAndMinutes" ValueToCompare="0" Operator="NotEqual" Type="Double" ForeColor="Red" Font-Bold="true" ValidationGroup="Overhead"></asp:CompareValidator>
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
