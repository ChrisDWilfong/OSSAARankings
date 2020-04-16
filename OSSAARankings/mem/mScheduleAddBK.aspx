<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="mScheduleAddBK.aspx.vb" Inherits="OSSAARankings.mScheduleAddBK" ClientTarget="uplevel"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>OSSAARankings.com Schedule Entry</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" >
    <link href="../css/mbase.css" rel="stylesheet" type="text/css" />
    <link href="../css/mlayout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:Panel ID="PanelLogin" runat="server" >
<asp:UpdatePanel ID="UpdatePanelHome" runat="server" UpdateMode="Conditional">
 <ContentTemplate>
 <header class="mobile">
    <div class="row">
        <div class="col full">
            <h3 style="color:Yellow;">OSSAARANKINGS.COM</h3>
            <asp:Label ID="lblHeading" runat="server" Text="Schedule Entry" CssClass="section-head"></asp:Label>
            <asp:Label ID="lblHeader" runat="server" CssClass="headerSmall" Height="24px" style="text-align:center;" Text="Edit / Add Game Schedule" Width="100%"></asp:Label>
            <nav id="nav-wrap"> <a class="mobile-btn" href="#nav-wrap" title="Show navigation">Show navigation</a> <a class="mobile-btn" href="#" title="Hide navigation">Hide navigation</a>
                <ul id="nav" class="nav">
                    <li><a href="mTimeEntryList.aspx">Sports</a></li>
                    <li><a href="mWorkOrderList.aspx">Schedules</a></li>
                    <li><a href="mWorkOrderList.aspx">Logout</a></li>
                </ul>
            </nav>
        </div>
    </div>
</div>
<section id="timeentry">
   <div class="row">
    <div class="services-wrapper">
      <div class="col first">
            <asp:Button ID="cmdCancel" runat="server" Text="Cancel" />
            <asp:Button ID="cmdSaveChanges" runat="server" Text="SAVE CHANGES" />
            <asp:Button ID="cmdDelete" runat="server" Text="DELETE" />
        </div>
        <div class="col first">
                <h3>MY SCORE</h3>
                <asp:Label ID="lblScoreMy" runat="server" CssClass="h3">MY SCORE</asp:Label>
        </div>
        <div class="col first">
                <asp:Label ID="lblScoreTheirs" runat="server" CssClass="perInfoLabel" Width="75px">OPP SCORE</asp:Label>
        </div>
        <div class="col first">
                <asp:Label ID="lblStatus" runat="server" CssClass="perInfoLabel">STATUS</asp:Label>
        </div>
        <div class="col first">
                <asp:TextBox ID="txtScoreMy" runat="server" ></asp:TextBox>
                <asp:TextBox ID="txtScoreOpp" runat="server" ></asp:TextBox>
        </div>
        <div class="col first">
                <asp:DropDownList ID="cboStatus" runat="server"  CssClass="col" >
                    <asp:ListItem Selected="True">Select...</asp:ListItem>                                    
                    <asp:ListItem>Final</asp:ListItem>
                    <asp:ListItem>Final (OT/Ext)</asp:ListItem>
                    <asp:ListItem>Rain Out</asp:ListItem>
                    <asp:ListItem>Suspended</asp:ListItem>
                    <asp:ListItem>Postponed</asp:ListItem>
                    <asp:ListItem>Canceled</asp:ListItem>
                    <asp:ListItem>Forfeit</asp:ListItem>
                </asp:DropDownList>
        </div>
        <div class="col first">
                <asp:Label ID="lblMessage" runat="server" CssClass="labelMessage" ForeColor="Red" Font-Bold="True"></asp:Label>
        </div>
        <div class="col first">
                <asp:Label ID="Label2" runat="server" CssClass="perInfoLabel">TYPE<span style="color:Red;"> *</span></asp:Label>
        </div>
        <div class="col first">
                <asp:DropDownList ID="cboGameType" runat="server" CssClass="DropDown" DataTextField="strDescription" DataValueField="strType" AutoPostBack="true" >              
                </asp:DropDownList>
        </div>
        <div class="col first">
                <asp:Label ID="lblGameDate" runat="server" CssClass="perInfoLabel">GAME DATE (MM/DD/YYYY)<span style="color:Red;"> *</span></asp:Label>
        </div>
        <div class="col first">
                <telerik:RadDatePicker ID="RadDatePicker1" runat="server" MinDate="8/1/2019" MaxDate="5/31/2020" Width="180px"></telerik:RadDatePicker>
        </div>
        <div class="col first">
                <asp:Label ID="lblGameTime" runat="server" CssClass="perInfoLabel">START TIME<span style="color:Red;"> *</span></asp:Label>
        </div>
        <div class="col first">
                <asp:DropDownList ID="cboGameTimeHour" runat="server" CssClass="DropDown">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="cboGameTimeMinute" runat="server" CssClass="DropDown">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="cboGameAMPM" runat="server" CssClass="DropDown">
                    <asp:ListItem>PM</asp:ListItem>
                    <asp:ListItem>AM</asp:ListItem>
                </asp:DropDownList>
            </div>
        <div class="col first">
                <asp:Label ID="Label1" runat="server" CssClass="perInfoLabel">SELECT TOURNAMENT (or)&nbsp;<a href="Home.aspx?sel=ScheduleEditT">Add New Tournament</a> <span style="color:Red;"> *</span></asp:Label>
                <asp:DropDownList ID="cboTourneys" runat="server" CssClass="DropDown" >
                    <asp:ListItem Selected="True">Select...</asp:ListItem>                                    
                </asp:DropDownList>
        </div>
        <div class="col first">
                <asp:Label ID="Label3" runat="server" CssClass="perInfoLabel">TOURNAMENT NAME / LOCATION</asp:Label>
                <asp:TextBox ID="txtTournament" runat="server" CssClass="perInfoText" Width="200px"></asp:TextBox>
        </div>
        <div class="col first">
                <asp:Label ID="lblSite" runat="server" CssClass="perInfoLabel">SITE<span style="color:Red;"> *</span></asp:Label>
                <asp:DropDownList ID="cboGameLocation" runat="server" CssClass="DropDown" >
                    <asp:ListItem Selected="True">Select...</asp:ListItem>                                    
                    <asp:ListItem>Home</asp:ListItem>
                    <asp:ListItem>Away</asp:ListItem>
                    <asp:ListItem>Neutral</asp:ListItem>
                    <asp:ListItem>Scrimmage (H)</asp:ListItem>
                    <asp:ListItem>Scrimmage (A)</asp:ListItem>
                </asp:DropDownList>
        </div>
        <div class="col first">
                <asp:Label ID="lblOSSAATeam" runat="server" CssClass="perInfoLabel" Text="OPPOSING OSSAA TEAM"></asp:Label>
                <asp:DropDownList ID="cboSchools" runat="server" CssClass="DropDown" AutoPostBack="true">
                    <asp:ListItem>Select School...</asp:ListItem>
                </asp:DropDownList>
        </div>
        <div class="col first">
                <asp:Label ID="lblNonOSSAATeam" runat="server" CssClass="perInfoLabel" Text="or NON-OSSAA TEAM (or TBA)"></asp:Label>
                <asp:TextBox ID="txtSchool" runat="server" CssClass="perInfoText" Width="175px"></asp:TextBox>
        </div>
        <div class="col first">
                <asp:Label ID="lblResults" runat="server" CssClass="perInfoLabel" Text="RESULTS"></asp:Label>
                <asp:TextBox ID="txtResults" runat="server" CssClass="perInfoText" Width="90%" TextMode="MultiLine" Rows="5"></asp:TextBox>
        </div>
        <div class="col first">
                <asp:HiddenField ID="txtSchduleID" runat="server" />
        </div>
    </div>
    </div>
</section> 
</ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>
</form>
</body>
</html>
