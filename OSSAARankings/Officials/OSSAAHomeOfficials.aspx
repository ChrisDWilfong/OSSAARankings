<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="OSSAAHomeOfficials.aspx.vb" Inherits="OSSAARankings.OSSAAHomeOfficials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="960px">
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="OSSAA Website Home Page" CssClass="header"></asp:Label></td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td><asp:HyperLink ID="HyperLink8" runat="server" CssClass="textbox" NavigateUrl="http://www.ossaarankings.com/officials/EligibleOfficials.aspx?l=ossaastaff" Target="_blank">List of Eligible Officials (Regular Season)</asp:HyperLink></td></tr>
        <tr><td><asp:Label ID="Label4" runat="server" Text="&nbsp;- No login needed." CssClass="labelSmall"></asp:Label></td></tr>
        <tr><td><asp:HyperLink ID="HyperLink7" runat="server" CssClass="textbox" NavigateUrl="http://www.ossaarankings.com/officials/Login.aspx" Target="_blank">List of Eligible Officials - Login Page (Regular Season)</asp:HyperLink></td></tr>
        <tr><td><asp:Label ID="Label5" runat="server" Text="&nbsp;- Login : ossaa2014" CssClass="labelSmall"></asp:Label></td></tr>
        <tr><td><hr /></td></tr>
        <tr><td><asp:HyperLink ID="HyperLink10" runat="server" CssClass="textbox" NavigateUrl="http://ossaamembers.ossaa.net/memberlogin.aspx" Target="_blank">OSSAA Membership Website</asp:HyperLink></td></tr>
        <tr><td><asp:Label ID="Label11" runat="server" Text="&nbsp;- Username and Password login by Superintendent, Principal or A/D" CssClass="labelSmall"></asp:Label></td></tr>
        <tr><td><asp:HyperLink ID="HyperLink11" runat="server" CssClass="textbox" NavigateUrl="http://ossaamembers.ossaa.net/admin/unpw.aspx" Target="_blank">OSSAA Membership Admin</asp:HyperLink></td></tr>
        <tr><td><asp:Label ID="Label12" runat="server" Text="&nbsp;- No login needed." CssClass="labelSmall"></asp:Label></td></tr>
        <tr><td><hr /></td></tr>
        <tr><td><asp:HyperLink ID="HyperLink9" runat="server" CssClass="textbox" NavigateUrl="http://www.ossaarankings.com/Officials/LoginWH.aspx" Target="_blank">Football Officials : White Hat Login (for Varsity Football Game Reports and Playoff Availability)</asp:HyperLink></td></tr>
        <tr><td><asp:Label ID="Label9" runat="server" Text="&nbsp;- Email login by White Hats" CssClass="labelSmall"></asp:Label></td></tr>
        <tr><td><asp:HyperLink ID="HyperLink6" runat="server" CssClass="textbox" NavigateUrl="http://www.ossaarankings.com/Officials/LoginFBR.aspx" Target="_blank">Football Coaches : Rating of Officials and Scratch List</asp:HyperLink></td></tr>
        <tr><td><asp:Label ID="Label10" runat="server" Text="&nbsp;- ossaa2014 login and select school" CssClass="labelSmall"></asp:Label></td></tr>
        <tr><td><hr /></td></tr>
        <tr><td><asp:HyperLink ID="HyperLink13" runat="server" CssClass="textbox" NavigateUrl="http://www.ossaarankings.com/Officials/LoginBAO.aspx" Target="_blank" Enabled="true">Baseball Officials : Entry of Playoff Availability (for Public)</asp:HyperLink></td></tr>
        <tr><td><asp:Label ID="Label14" runat="server" Text="&nbsp;- Email login for Eligible Baseball Official" CssClass="labelSmall"></asp:Label></td></tr>
        <tr><td><asp:HyperLink ID="HyperLink14" runat="server" CssClass="textbox" NavigateUrl="http://www.ossaarankings.com/Officials/LoginBAOSheree.aspx" Target="_blank" Enabled="true">Baseball Officials : Entry of Playoff Availability (for Sheree)</asp:HyperLink></td></tr>
        <tr><td><asp:Label ID="Label15" runat="server" Text="&nbsp;- Email or OSSAAID login for Eligible Baseball Official" CssClass="labelSmall"></asp:Label></td></tr>
        <tr><td><hr /></td></tr>
        <tr><td><asp:HyperLink ID="HyperLink3" runat="server" CssClass="textbox" NavigateUrl="http://www.ossaarankings.com/Officials/LoginBBOSheree.aspx" Target="_blank" Enabled="false">Basketball Officials : Entry of Playoff Availability (for Sheree)</asp:HyperLink></td></tr>
        <tr><td><asp:Label ID="Label6" runat="server" Text="&nbsp;- Email or OSSAAID login for Eligible Basketball Official" CssClass="labelSmall"></asp:Label></td></tr>
        <tr><td><asp:HyperLink ID="HyperLink4" runat="server" CssClass="textbox" NavigateUrl="http://www.ossaarankings.com/Officials/LoginBBO.aspx" Target="_blank" Enabled="false">Basketball Officials : Entry of Playoff Availability (for Public)</asp:HyperLink></td></tr>
        <tr><td><asp:Label ID="Label7" runat="server" Text="&nbsp;- Email login for Eligible Basketball Official (currently unavailable)" CssClass="labelSmall"></asp:Label></td></tr>
        <tr><td><asp:HyperLink ID="HyperLink5" runat="server" CssClass="textbox" NavigateUrl="http://www.ossaarankings.com/Officials/LoginBBR.aspx" Target="_blank" Enabled="false">Basketball Coaches : Rating of Officials</asp:HyperLink></td></tr>
        <tr><td><asp:Label ID="Label8" runat="server" Text="&nbsp;- Email login by Basketball Coach (if entered in our OSSAA Membership website by the A/D)" CssClass="labelSmall"></asp:Label></td></tr>
        <tr><td><asp:HyperLink ID="HyperLink1" runat="server" CssClass="textbox" NavigateUrl="http://www.ossaarankings.com/Officials/LoginBBPref.aspx" Target="_blank" Enabled="false">Basketball District : Preferential List Entry</asp:HyperLink></td></tr>
        <tr><td><asp:Label ID="Label2" runat="server" Text="&nbsp;- Must be a District teams Basketball coach, A/D or High School Principal (in our OSSAA Membership website)" CssClass="labelSmall"></asp:Label></td></tr>
        <tr><td><asp:HyperLink ID="HyperLink12" runat="server" CssClass="textbox" NavigateUrl="http://www.ossaarankings.com/Officials/LoginPlayoffE.aspx?login=ossaastaff" Target="_blank" Enabled="false">List of Available Officials (Playoffs) (for Sheree)</asp:HyperLink></td></tr>
        <tr><td><asp:Label ID="Label13" runat="server" Text="&nbsp;- Must be a Basketball coach, A/D or High School Principal (in our OSSAA Membership website)" CssClass="labelSmall"></asp:Label></td></tr>
        <tr><td><asp:HyperLink ID="HyperLink2" runat="server" CssClass="textbox" NavigateUrl="http://www.ossaarankings.com/Officials/LoginPlayoffE.aspx" Target="_blank" Enabled="false">List of Available Officials (Playoffs) (for Public)</asp:HyperLink></td></tr>
        <tr><td><asp:Label ID="Label3" runat="server" Text="&nbsp;- Must be a Basketball coach, A/D or High School Principal (in our OSSAA Membership website)" CssClass="labelSmall"></asp:Label></td></tr>
        <tr><td><hr /></td></tr>
    </table>
</asp:Content>
