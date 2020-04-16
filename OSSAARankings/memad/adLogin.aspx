﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="adLogin.aspx.vb" Inherits="OSSAARankings.adLogin" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../mem/mem.css" rel="stylesheet" type="text/css" />
<head runat="server">
<!-- Google Tag Manager -->
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','GTM-5SVGP75');</script>
<!-- End Google Tag Manager -->
    <title>OSSAARankings.com : A/D Login Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
</head>
<body>
<!-- Google Tag Manager (noscript) -->
<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-P6NSRTN"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<!-- End Google Tag Manager (noscript) -->
    <form id="form1" runat="server">
    <div class="panelHome">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Panel ID="PanelLogin" runat="server" CssClass="panelHome">
        <asp:UpdatePanel ID="UpdatePanelHome" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                    <asp:Table ID="TableHome" runat="server" Width="100%">
                        <asp:TableRow BackColor="Navy" VerticalAlign="Middle" Height="32"><asp:TableCell><asp:Label ID="lblHeader" runat="server" Text="&nbsp;OSSAARankings.com - A/D Login" CssClass="memHeader" ForeColor="White" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:Label ID="lblHeading" runat="server" Text="Enter Login Information" CssClass="memHeader"></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblUserName" runat="server" CssClass="perInfoLabel">Username :<span style="color:Red;"> *</span></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="perInfoText2"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblPassword" runat="server" CssClass="perInfoLabel">Password :<span style="color:Red;"> *</span></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="perInfoText2" TextMode="Password"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            <asp:Button ID="cmdLogin" runat="server" Text="&nbsp;&nbsp;Login&nbsp;&nbsp;" CssClass="buttonSave" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="cmdForgot" runat="server" Text="&nbsp;&nbsp;Forgot Password&nbsp;&nbsp;" CssClass="button"/><br />
                            <asp:Label ID="lblMessage" runat="server" CssClass="labelMessage"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="Label1" runat="server" CssClass="perInfoLabel" Text="<strong>YOUR LOGIN INFORMATION IS THE SAME AS YOUR OSSAA MEMBERSHIP LOGIN</strong><br>If you are a NEW Athletic Director, click here for the <a href='http://www.ossaarankings.com/membership/MemberLogin.aspx' target='_blank'>OSSAA Membership Website</a> and then click 'Forgot/Need Login', fill out the 'New Membership Request' and submit."></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
            </ContentTemplate>
        </asp:UpdatePanel>
        </asp:Panel>
    </div>
    <div>
        <asp:Image ID="Image1" runat="server" src="../images/sponsors/adSponsor.gif" />
    </div>
    </form>
</body>
</html>
