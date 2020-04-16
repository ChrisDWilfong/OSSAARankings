<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucHomePNew.ascx.vb" Inherits="OSSAARankings.ucHomePNew" %>
<%@ Register src="ucMenuDDNew.ascx" tagname="ucMenu" tagprefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Home Page Principals</title>
    <style type="text/css">
        .titleHeader
        {
            font-family: Century Gothic;
            font-size: 12px;
            color: Black;
            font-weight: bold;
        }
        .titleHeaderBlue
        {
            font-family: Century Gothic;
            font-size: 12px;
            color: Red;
            font-weight: bold;
            font-style: italic;
        }          
        .content
        {
            font-family: Century Gothic;
            font-size: 11px;
            color: Navy;
        }
    </style>
</head>
<body>
    <table id="tblContent">
        <tr><td><span class="titleHeader">WELCOME</span></td></tr>
        <tr><td><span class="content">Welcome to the "Members Only" side of the OSSAA website.  This portion of our website has been specifically designed to disseminate information to the membership, (Superintendents, Principals, and Athletic Directors)  that is not necessarily seen by the general public. The public information will still be available from our OSSAA.com website; however, on this side you will find additional information such as, OSSAA Board of Directors Minutes, Financial Information, and specific contact information regarding playoff series events throughout the year.
        <br />We hope you find this a useful tool for your school.  It is our mission to provide as much information as possible, as easily as possible.  
        <br /><br />Thank you,<br />The OSSAA Staff
        </span></td></tr>
        <tr><td><hr /></td></tr>
        <tr><td><asp:Label ID="lblVotingDelegate" runat="server" Text="Your current Voting Delegate Is : " CssClass="content" Font-Size="18px" Font-Bold="true" ForeColor="Red"></asp:Label></td></tr>
        <%= Session("membersLinksPRIN")%>
        <tr><td><br /><uc1:ucMenu ID="ucMenu1" runat="server" /></td></tr>
    </table>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</body>
</html>
