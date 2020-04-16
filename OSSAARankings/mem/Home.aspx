<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Home.aspx.vb" Inherits="OSSAARankings.Home" ClientTarget="uplevel" %>

<%@ Register src="ucPersonalInfo.ascx" tagname="ucPersonalInfo" tagprefix="uc1" %>
<%@ Register src="ucRankings.ascx" tagname="ucRankings" tagprefix="uc2" %>
<%@ Register src="ucSchedule.ascx" tagname="ucSchedule" tagprefix="uc3" %>
<%@ Register src="ucRoster.ascx" tagname="ucRoster" tagprefix="uc4" %>
<%@ Register src="ucTeamUpdate.ascx" tagname="ucTeamUpdate" tagprefix="uc5" %>
<%@ Register src="ucTeamUpdateAll.ascx" tagname="ucTeamUpdateAll" tagprefix="uc6" %>
<%@ Register Src="~/mem/EntryFormsList2.ascx" TagName="ucEntryFormsList" TagPrefix="uc7" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<!-- Google Tag Manager -->
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','GTM-5SVGP75');</script>
<!-- End Google Tag Manager -->
    <title>OSSAARankings.com Membership Home Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link href="mem.css" rel="stylesheet" type="text/css" />
    <link href="popup.css" rel="stylesheet" type="text/css" />
    <link href="entryform.css" rel="stylesheet" type="text/css" />
</head>
<body>
<!-- Google Tag Manager (noscript) -->
<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-P6NSRTN"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<!-- End Google Tag Manager (noscript) -->
    <form id="form1" runat="server">
    <div class="panelHome">
     <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
     <asp:Panel ID="PanelHome" runat="server" CssClass="panelHome" >
        <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanelHome" runat="server" ViewStateMode="Enabled">
            <ProgressTemplate>  
                <div style="position:absolute; top:400px;left:250px;">
                    <img alt="Loading..." src="../images/ajax-loader1.gif" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanelHome" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                    <asp:Table ID="TableHome" runat="server" Width="100%">
                        <asp:TableRow BackColor="Maroon" VerticalAlign="Middle" Height="32"><asp:TableCell><asp:Label ID="lblHeader" runat="server" Text="&nbsp;OSSAARankings.com - Members" CssClass="memHeader" ForeColor="White" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow BackColor="Navy" VerticalAlign="Middle" Height="32"><asp:TableCell><asp:Label ID="Label1" runat="server" Text="&nbsp;Select 'Enter Rankings' from the dropdown below to submit your rankings." CssClass="memHeader" ForeColor="Yellow" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow BackColor="Navy" VerticalAlign="Middle" Height="24"><asp:TableCell><asp:Label ID="Label2" runat="server" Text="&nbsp;&nbsp;&nbsp;If you coach multiple sports, you must select a sport first." CssClass="memHeader" ForeColor="Yellow" Font-Size="Small" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow ID="rowSchools" Visible="false"><asp:TableCell>
                            <asp:DropDownList ID="cboSchools" runat="server" AutoPostBack="True" Font-Names="Segoe UI, Helvetica, Helvetica Neue, Lucida Grande, Arial, Verdana, Sans-serif;" Width="200px" Font-Bold="true" Font-Size="18px" BackColor="Blue" ForeColor="White" DataTextField="SchoolDisplay" DataValueField="schoolID" style="border-style:solid;border-width:1px;" >
                        </asp:DropDownList>
                        </asp:TableCell></asp:TableRow>
                        <asp:TableRow ID="rowSports"><asp:TableCell>
                        <asp:DropDownList ID="cboSports" runat="server" AutoPostBack="True" Font-Names="Segoe UI, Helvetica, Helvetica Neue, Lucida Grande, Arial, Verdana, Sans-serif;" Width="200px" Font-Bold="true" Font-Size="18px" BackColor="OrangeRed" DataTextField="SportDisplay" DataValueField="teamID" style="border-style:solid;border-width:1px;" >
                        </asp:DropDownList>
                        </asp:TableCell></asp:TableRow>
                        <asp:TableRow ID="rowAction"><asp:TableCell>
                            <asp:DropDownList ID="cboAction" runat="server" AutoPostBack="True" Font-Names="Segoe UI, Helvetica, Helvetica Neue, Lucida Grande, Arial, Verdana, Sans-serif;" Width="200px" Font-Bold="true" Font-Size="18px" BackColor="Orange" style="border-style:solid;border-width:1px;">
                                <asp:ListItem Value="">Select Option...</asp:ListItem>
                                <asp:ListItem Value="Schedule">Schedule</asp:ListItem>
                                <asp:ListItem Value="Roster">Roster</asp:ListItem>
                                <asp:ListItem Value="EnterRankings">Enter Rankings</asp:ListItem>
                                <asp:ListItem Value="EnterRankings1" Enabled="false">Enter Rankings (Dual)</asp:ListItem>
                                <asp:ListItem Value="EnterRankings8" Enabled="false">Enter Rankings (Dual-8)</asp:ListItem>
                                <asp:ListItem Value="EnterRankingsEW" Enabled="false">Enter Rankings (E-W)</asp:ListItem>
                                <asp:ListItem Value="PersonalInfo">Personal Info</asp:ListItem>
                                <asp:ListItem Value="MyDistrict">My District</asp:ListItem>
                                <asp:ListItem Value="RankingsSchedule">Rankings Schedule</asp:ListItem>
                                <asp:ListItem Value="RankingsOthers">Others Rankings</asp:ListItem>
                                <asp:ListItem Value="RankingsOthers1" Enabled="false">Others Rankings (Dual)</asp:ListItem>
                                <asp:ListItem Value="RankingsOthers8" Enabled="false">Others Rankings (Dual)</asp:ListItem>
                                <asp:ListItem Value="RankingsPrevious" Enabled="false">Previous Rankings</asp:ListItem>
                                <asp:ListItem Value="RankingsPrevious1" Enabled="false">Previous Rankings (Dual)</asp:ListItem>
                                <asp:ListItem Value="RankingsPrevious8" Enabled="false">Previous Rankings (Dual)</asp:ListItem>
                                <asp:ListItem Value="PitchCount" Enabled="false">Pitch Count</asp:ListItem>
                                <asp:ListItem Value="SwimResults" Enabled="false">Swim Results</asp:ListItem>
                                <asp:ListItem Value="TeamUpdate" Enabled="false">My Team Update</asp:ListItem>
                                <asp:ListItem Value="TeamUpdateAll" Enabled="false">OTHER Team Updates</asp:ListItem>
                                <asp:ListItem Value="ContactUs">Contact Us</asp:ListItem>
                                <asp:ListItem Value="EntryForms" Enabled="true">On-Line Entry & Facility Forms</asp:ListItem>
                                <asp:ListItem Value="Logout">Logout</asp:ListItem>
                                <asp:ListItem Value="MemberLoginLog" Enabled="false">Coaches Login Log</asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:HyperLink ID="hlSport" runat="server" Visible="false" CssClass="schedLabel" Target="_blank">HyperLink</asp:HyperLink></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:HyperLink ID="hlPrefs" runat="server" Visible="false" CssClass="schedLabel" Target="_blank">HyperLink</asp:HyperLink></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:HyperLink ID="hlInstructions" runat="server" Visible="false" CssClass="schedLabel" Target="_blank">HyperLink</asp:HyperLink></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:Label ID="lblCoach" runat="server" Text="" CssClass="infoCoach" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:Label ID="lblSchool" runat="server" Text="" CssClass="infoSchool" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:Label ID="lblSport" runat="server" Text="" CssClass="infoSport" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:Label ID="lblRankingsStatus" runat="server" Text="" CssClass="infoRankings" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell>
                            <asp:PlaceHolder runat="server" ID="PlaceHolder"></asp:PlaceHolder>
                            <uc2:ucRankings ID="ucRankings1" runat="server" Visible="false" />
                            <uc3:ucSchedule ID="ucSchedule1" runat="server" Visible="false" />
                            <uc1:ucPersonalInfo ID="ucPersonalInfo1" runat="server" Visible="false" />
                            <uc4:ucRoster ID="ucRoster1" runat="server" Visible="false" />
                            <uc5:ucTeamUpdate ID="ucTeamUpdate1" runat="server"  Visible="false"/>
                            <uc6:ucTeamUpdateAll ID="ucTeamUpdate2" runat="server"  Visible="false"/>
                            <uc7:ucEntryFormsList ID="ucEntryFormsList2" runat="server" Visible="false" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cboAction" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
</asp:Panel>
</div>
    <asp:Label ID="lblFooter" runat="server" Text="" CssClass="labelMessage"></asp:Label>
<div>
    <asp:Image ID="imgFooter" runat="server" src="../images/EnterRankingsEW.png" Visible="false" />
</div>
    </form>
</body>
</html>
