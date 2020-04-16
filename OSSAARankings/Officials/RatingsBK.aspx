<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RatingsBK.aspx.vb" Inherits="OSSAARankings.RatingsBK" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Basketball Officials Ratings</title>
    <link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Lukiest+Guy' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Michroma:400,700,300' rel='stylesheet' type='text/css'>
    <link href="RatingsBK.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ChangedName(textControl) {
            alert('Changed Name');
        }
        function ChangedEmail(textControl) {
            document.getElementById("txtName").disabled = true;
        }

        function CheckAllInfo() {
            document.getElementById("RadButtonSave").disabled = false;  
        }

        function CheckPersonalInfo(textControl) {
            var objName = document.getElementById("txtName");
            var objEmail = document.getElementById("txtEmail");
            var objSchool = document.getElementById("txtSchool");
            var objOSSAAID = document.getElementById("txtOSSAAID");

            if (objName.value != '' && objEmail.value != '' && objOSSAAID.value != '') {
                document.getElementById("txtHomeTeam").disabled = false;
                document.getElementById("txtAwayTeam").disabled = false;
            }
        }

        function CheckGameInfo(textControl) {
            var objGameDate = document.getElementById("RadDatePickerGameDate");
            var objHomeTeam = document.getElementById("txtHomeTeam");
            var objAwayTeam = document.getElementById("txtAwayTeam");
            var objOfficialsInfo = document.getElementById("tblOfficialsInfo");
            var objOfficialsInfo1 = document.getElementById("tblOfficialsInfo1");
            var objGameDate = document.getElementById("RadDatePickerGameDate");

            if (objHomeTeam.value != '' && objAwayTeam.value != '' && objGameDate.value != '') {
                if (objOfficialsInfo1 == null) {
                    document.getElementById("txtOfficialsNames").disabled = false;
                    document.getElementById("RadRatingOfficials").disabled = false;
                    document.getElementById("txtFeedback").disabled = false;
                } else {
                    document.getElementById("txtOfficial1").disabled = false;
                    document.getElementById("txtOfficial2").disabled = false;
                    document.getElementById("txtOfficial3").disabled = false;
                    document.getElementById("txtOSSAAID1").disabled = false;
                    document.getElementById("txtOSSAAID2").disabled = false;
                    document.getElementById("txtOSSAAID3").disabled = false;
                    document.getElementById("txtFeedback1").disabled = false;
                }
            }
        }

        function CheckOfficialsInfo(textControl) {
            var objOfficialsName = document.getElementById("txtOfficialsNames");
            var objFeedback = document.getElementById("txtFeedback");
            var objRatingOfficials = document.getElementById("RadRatingOfficials");
        }

        function CheckOfficialsInfo1(textControl) {
            var objOfficial1 = document.getElementById("txtOfficial1");
            var objOfficial2 = document.getElementById("txtOfficial2");
            var objOSSAA1 = document.getElementById("txtOSSAAID1");
            var objOSSAA2 = document.getElementById("txtOSSAAID2");
            var objRating1 = document.getElementById("RadRatingOfficial1");
            var objRating2 = document.getElementById("RadRatingOfficial2");

            if (objOfficial1.value != '' && objOfficial2.value != '' && objOSSAA1.value != '' && objOSSAA2.value != '') {
                document.getElementById("RadButtonSave").disabled = false;   
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" />
    <telerik:RadScriptManager ID="RadScriptManager2" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
<asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server" ClientIDMode="Inherit" ViewStateMode="Enabled">
    <ProgressTemplate>            
        <img alt="progress" src="../images/ajax-loader.gif"/><span style="font-family: Arial; font-size:12px; font-style:italic;">&nbsp;&nbsp;Processing...</span>
    </ProgressTemplate>
</asp:UpdateProgress>
<ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="ratingsBKPanel" Radius="10" BorderColor="gray"></ajax:RoundedCornersExtender>
<asp:Panel runat="server" BackColor="LightGray" Style="padding:15px;" Id="ratingsBKPanel" Width="800px">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
        <div class="innerPanel in" style="padding-left:10px; padding-top:10px;">
            <asp:Label ID="lblHeader1" runat="server" Text="OSSAA BASKETBALL OFFICIALS REPORTING SYSTEM" Font-Names="Oswald,Verdana" ForeColor="Maroon" Font-Size="24px" Font-Bold="true"></asp:Label> <br />
            <asp:Label ID="lblMessage" runat="server" Text="If you are a coach, log into OSSAARankings.com to submit your Officials ratings<br><strong>ITEMS IN RED ARE REQUIRED</strong>" Font-Size="Small" Font-Names="Lukiest+Guy" ForeColor="Red"></asp:Label>
        </div>    
        <div class="innerPanel in" style="padding-left:10px; padding-top:10px;">
            <asp:Table runat="server" ID="tblYouAreA" Width="900px">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblYouAreA" runat="server" Text="YOU ARE A : " Width="100px" ForeColor="Red"></asp:Label>
                        <telerik:RadDropDownList ID="RadDropDownListYouAreA" runat="server" AutoPostBack="true">
                            <Items>
                                <telerik:DropDownListItem Value="" Text="Select..."  Selected="true"/>
                                <telerik:DropDownListItem Value="FAN" Text="FAN" />
                                <telerik:DropDownListItem Value="ADMINISTRATOR" Text="ADMINISTRATOR" />
                                <telerik:DropDownListItem Value="OBSERVER" Text="OBSERVER" />
                                <telerik:DropDownListItem Value="ASSIGNOR" Text="AREA COORD/ASSIGNOR" />
                                <telerik:DropDownListItem Value="OFFICIAL" Text="OFFICIAL" />   
                            </Items>
                        </telerik:RadDropDownList>
                    </asp:TableCell>
                    <asp:TableCell>&nbsp;</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="rowYouAreASub" Visible="false">
                    <asp:TableCell>
                        <asp:Label ID="lblYouAreASub" runat="server" Text="&nbsp;" Width="100px"></asp:Label>
                        <telerik:RadDropDownList ID="RadDropDownListYouAreASub" runat="server" AutoPostBack="true" DataValueField="strTypeSub" DataTextField="strTypeSub" Width="200px" BackColor="#ffffcc" >
                            <Items>
                                <telerik:DropDownListItem Value="" Text="Select..."  Selected="true"/>
                            </Items>
                        </telerik:RadDropDownList>
                    </asp:TableCell>
                    <asp:TableCell>&nbsp;</asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <asp:Table runat="server" ID="tblPersonalInfo" Visible="false" Width="750px">
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2"><hr /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow BackColor="Gray" Width="100%">
                    <asp:TableCell ColumnSpan="2"><asp:Label ID="Label2" runat="server" Text="&nbsp;PERSONAL INFORMATION" ForeColor="White" ></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="300px" ColumnSpan="2">
                        <asp:Label ID="lblName" runat="server" Text="Your Name : " Width="105px" ForeColor="Red"></asp:Label>
                        <asp:TextBox ID="txtName" runat="server" Width="150px" BackColor="#ffffcc" OnTextChange="javascript: CheckAllInfo(this);"></asp:TextBox> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                     <asp:TableCell Width="300px" ColumnSpan="2">
                        <asp:Label ID="lblEmail" runat="server" Text="Your Email : " Width="105px" ForeColor="Red"></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" Width="250px" BackColor="#ffffcc" OnTextChange="javascript: CheckAllInfo(this);"></asp:TextBox> 
                    </asp:TableCell>               
                </asp:TableRow>
                <asp:TableRow ID="rowSchoolOSSAAID" Visible="false">
                    <asp:TableCell ID="cellSchool" Visible="false" ColumnSpan="2">
                         <asp:Label ID="lblSchool" runat="server" Text="Your School : " Width="105px"></asp:Label>
                        <asp:TextBox ID="txtSchool" runat="server" Width="200px" BackColor="#ffffcc" OnTextChange="javascript: CheckAllInfo(this);"></asp:TextBox>                       
                    </asp:TableCell>
                    <asp:TableCell ID="cellOSSAAID" Visible="false" ColumnSpan="2">
                         <asp:Label ID="lblOSSAAID" runat="server" Text="Your OSSAA ID# : " Width="105px" ForeColor="Red"></asp:Label>
                        <asp:TextBox ID="txtOSSAAID" runat="server" Width="100px" BackColor="#ffffcc" OnTextChange="javascript: CheckAllInfo(this);"></asp:TextBox>                       
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <asp:Table runat="server" ID="tblGameInfo" Visible="false" Width="750px">
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2"><hr /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow BackColor="Gray" Width="100%">
                    <asp:TableCell ColumnSpan="2"><asp:Label ID="Label1" runat="server" Text="&nbsp;GAME INFORMATION" ForeColor="White" ></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Label ID="lblGameDate" runat="server" Text="Game Date : " Width="105px" ForeColor="Red"></asp:Label>
                        <telerik:RadDatePicker ID="RadDatePickerGameDate" runat="server" MinDate="2019-09-01" MaxDate="2020-04-01" BackColor="#ffffcc">
                        </telerik:RadDatePicker>                       
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="300px">
                        <asp:Label ID="lblHomeTeam" runat="server" Text="Home Team : " Width="105px" ForeColor="Red"></asp:Label>
                        <asp:TextBox ID="txtHomeTeam" runat="server" Width="180px" BackColor="#ffffcc" ></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblAwayTeam" runat="server" Text="Opponent : " Width="105px" ForeColor="Red"></asp:Label>
                        <asp:TextBox ID="txtAwayTeam" runat="server" Width="180px" BackColor="#ffffcc" ></asp:TextBox>                
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <asp:Table runat="server" ID="tblOfficialsInfo" Visible="false" Width="750px">
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2"><hr /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow BackColor="Gray" Width="100%">
                    <asp:TableCell ColumnSpan="2"><asp:Label ID="lblHeaderOfficials" runat="server" Text="&nbsp;OFFICIALS INFORMATION" ForeColor="White"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="130px" VerticalAlign="Top">
                        <asp:Label ID="Label3" runat="server" Text="Official(s) Name : " Width="120px" ForeColor="Red"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtOfficialsNames" runat="server" Width="250px" TextMode="MultiLine" Rows="2" BackColor="#ffffcc" ></asp:TextBox>&nbsp;<asp:Label ID="Label18" runat="server" Text="Enter names or UNKNOWN"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="130px" VerticalAlign="Top">
                        <asp:Label ID="Label5" runat="server" Text="Officials Rating : " Width="120px" ForeColor="Red"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <telerik:RadRating ID="RadRatingOfficials" runat="server" ItemCount="5" width="200px" ></telerik:RadRating>
                        <asp:Label ID="Label20" runat="server" Text="(1 = Poor --> 5 = Superior)" Font-Italic="true" ></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="130px" VerticalAlign="Top">
                        <asp:Label ID="Label4" runat="server" Text="Other Feedback : " Width="120px" ForeColor="Red" VerticalAlign="Top"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtFeedback" runat="server" Width="600px" TextMode="MultiLine" Rows="8" BackColor="#ffffcc"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <asp:Table runat="server" ID="tblOfficialsInfo1" Visible="false" Width="750px">
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2"><hr /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow BackColor="Gray" Width="100%">
                    <asp:TableCell ColumnSpan="2"><asp:Label ID="Label6" runat="server" Text="&nbsp;OFFICIALS INFORMATION" ForeColor="White"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="130px" VerticalAlign="Top">
                        <asp:Label ID="Label7" runat="server" Text="Officials Name 1 : " Width="120px" ForeColor="Red" Font-Bold="true"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="100%">
                        <asp:TextBox ID="txtOfficial1" runat="server" Width="150px" BackColor="#ffffcc"></asp:TextBox>&nbsp;<asp:Label ID="Label22" runat="server" Text="Enter name or UNKNOWN" Font-Italic="true"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="130px" VerticalAlign="Top">
                        <asp:Label ID="Label10" runat="server" Text="OSSAA ID# : " Width="120px" ForeColor="Red"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtOSSAAID1" runat="server" Width="100px" MaxLength="5" BackColor="#ffffcc" ></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="130px" VerticalAlign="Top">
                        <asp:Label ID="Label8" runat="server" Text="Officials Rating : " Width="120px" ForeColor="Red"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <telerik:RadRating ID="RadRatingOfficial1" runat="server" ItemCount="5" width="200px"></telerik:RadRating>
                        <asp:Label ID="Label19" runat="server" Text="(1 = Poor --> 5 = Superior)" Font-Italic="true"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="130px" VerticalAlign="Top">
                        <asp:Label ID="Label11" runat="server" Text="Officials Name 2 : " Width="120px" ForeColor="Red" Font-Bold="true"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="100%">
                        <asp:TextBox ID="txtOfficial2" runat="server" Width="150px" BackColor="#ffffcc" ></asp:TextBox>&nbsp;
                        <asp:Label ID="Label23" runat="server" Text="Enter name or UNKNOWN" Font-Italic="true"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="130px" VerticalAlign="Top">
                        <asp:Label ID="Label12" runat="server" Text="OSSAA ID# : " Width="120px" ForeColor="Red"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtOSSAAID2" runat="server" Width="100px" MaxLength="5" BackColor="#ffffcc" ></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="130px" VerticalAlign="Top">
                        <asp:Label ID="Label13" runat="server" Text="Officials Rating : " Width="120px" ForeColor="Red"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <telerik:RadRating ID="RadRatingOfficial2" runat="server" ItemCount="5" width="200px"></telerik:RadRating>
                        <asp:Label ID="Label21" runat="server" Text="(1 = Poor --> 5 = Superior)" Font-Italic="true" ></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="130px" VerticalAlign="Top">
                        <asp:Label ID="Label14" runat="server" Text="Officials Name 3 : " Width="120px" Font-Bold="true"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="100%">
                        <asp:TextBox ID="txtOfficial3" runat="server" Width="150px" BackColor="#ffffcc" ></asp:TextBox>&nbsp;<asp:Label ID="Label24" runat="server" Text="Enter name or UNKNOWN" Font-Italic="true"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="130px" VerticalAlign="Top">
                        <asp:Label ID="Label15" runat="server" Text="OSSAA ID# : " Width="120px" ></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtOSSAAID3" runat="server" Width="100px" MaxLength="5" BackColor="#ffffcc" ></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="130px" VerticalAlign="Top">
                        <asp:Label ID="Label16" runat="server" Text="Officials Rating : " Width="120px" ></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <telerik:RadRating ID="RadRatingOfficial3" runat="server" ItemCount="5" width="200px" ></telerik:RadRating>
                        <asp:Label ID="Label25" runat="server" Text="(1 = Poor --> 5 = Superior)" Font-Italic="true" ></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="130px" VerticalAlign="Top">
                        <asp:Label ID="Label9" runat="server" Text="Other Feedback : " Width="120px" VerticalAlign="Top"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtFeedback1" runat="server" Width="600px" TextMode="MultiLine" Rows="8" BackColor="#ffffcc" ></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <asp:Table runat="server" ID="tblButtons" Visible="false" Width="750px">
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2"><hr /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <telerik:RadButton ID="RadButtonSave" runat="server" Text="SAVE CHANGES" Skin="Silk" BackColor="Olive" Font-Bold="true" Font-Names="Oswald" ForeColor="Green">
                        </telerik:RadButton>
                    </asp:TableCell>           
                </asp:TableRow>            
            </asp:Table>
        </div>
    </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>
    </form>
</body>
</html>
