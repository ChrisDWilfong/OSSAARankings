<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="adHome.aspx.vb" Inherits="OSSAARankings.adHome" %>
<%@ Register src="ucPersonalInfoAD.ascx" tagname="ucPersonalInfoAD" tagprefix="uc1" %>
<%@ Register src="ucCoachesSports.ascx" tagname="ucCoachesSports" tagprefix="uc2" %>
<%@ Register src="ucCoaches.ascx" tagname="ucCoaches" tagprefix="uc3" %>
<%@ Register Src="~/mem/EntryFormsList2.ascx" TagName="ucEntryFormsList" TagPrefix="uc4" %>
<%@ Register Src="ucAssigners.ascx" TagName="ucAssigners" TagPrefix="uc5" %>

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
    <title>OSSAARankings.com : A/D Home Page</title>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Panel ID="PanelHome" runat="server" CssClass="panelHome">
        <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanelHome" runat="server" ViewStateMode="Enabled">
            <ProgressTemplate>  
                <div style="position:absolute; top:250px; left:250px;">
                    <img alt="Loading..." src="../images/ajax-loader1.gif" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanelHome" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                    <asp:Table ID="TableHome" runat="server" Width="100%">
                        <asp:TableRow BackColor="Maroon" VerticalAlign="Middle" Height="32"><asp:TableCell><asp:Label ID="lblHeader" runat="server" Text="&nbsp;OSSAARankings.com - Members" CssClass="memHeader" ForeColor="White" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell>
                        <asp:Label ID="lblContent" runat="server" Text="Contact Info : cwilfong@ossaa.com" Font-Bold="true" CssClass="contentLine"></asp:Label><br />
                        </asp:TableCell></asp:TableRow>
                        <asp:TableRow ID="rowSchools" Visible="false"><asp:TableCell>
                            <asp:DropDownList ID="cboSchools" runat="server" AutoPostBack="True" Font-Names="Segoe UI, Helvetica, Helvetica Neue, Lucida Grande, Arial, Verdana, Sans-serif;" Width="200px" Font-Bold="true" Font-Size="18px" BackColor="Blue" ForeColor="White" DataTextField="SchoolDisplay" DataValueField="schoolID" style="border-style:solid;border-width:1px;" >
                        </asp:DropDownList>
                        </asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell>
                            <asp:DropDownList ID="cboAction" runat="server" AutoPostBack="True" Font-Names="Segoe UI, Helvetica, Helvetica Neue, Lucida Grande, Arial, Verdana, Sans-serif;" Width="200px" Font-Bold="true" Font-Size="18px" BackColor="Orange" style="border-style:solid;border-width:1px;">
                                <asp:ListItem Value="">Select Option...</asp:ListItem>
                                <asp:ListItem Value="HeadCoaches">Head Coaches</asp:ListItem>
                                <asp:ListItem Value="CoachesSports">Coaches Sports</asp:ListItem>
                                <asp:ListItem Value="EntryForms">On-Line Entry & Facility Forms</asp:ListItem>
                                <asp:ListItem Value="Assigners">Assigners</asp:ListItem>
                                <asp:ListItem Value="PersonalInfo" Enabled="true">Personal Info</asp:ListItem>
                                <asp:ListItem Value="ContactUs" Enabled="false">Contact Us</asp:ListItem>
                                <asp:ListItem Value="Logout">Logout</asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:HyperLink ID="hlPrefs" runat="server" Visible="false" CssClass="schedLabel" Target="_blank">HyperLink</asp:HyperLink></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:Label ID="lblCoach" runat="server" Text="" CssClass="infoCoach" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:Label ID="lblSchool" runat="server" Text="" CssClass="infoSchool" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell>
                            <asp:PlaceHolder runat="server" ID="PlaceHolder"></asp:PlaceHolder>
                            <uc3:ucCoaches ID="ucCoaches1" runat="server" Visible="false" />
                            <uc2:ucCoachesSports ID="ucCoachesSports1" runat="server" Visible="false" />
                            <uc1:ucPersonalInfoAD ID="ucPersonalInfoAD1" runat="server" Visible="false" />
                            <uc4:ucEntryFormsList ID="ucEntryFormsList" runat="server" Visible="false" />
                            <uc5:ucAssigners ID="ucAssigners1" runat="server" Visible="false" />
                        </asp:TableCell></asp:TableRow>
                    </asp:Table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cboAction" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
</asp:Panel>
    </div>
    <div>
        <asp:Image ID="Image1" runat="server" src="../images/sponsors/adSponsor.gif" />
    </div>
    </form>
</body>
</html>
