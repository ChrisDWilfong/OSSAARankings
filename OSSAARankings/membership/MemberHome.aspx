<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="SiteLogin.Master" CodeBehind="MemberHome.aspx.vb" Inherits="OSSAARankings.MemberHome" validateRequest="false" %>
<%@ Register src="ucHomeADNew.ascx" tagname="ucHomeAD" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table id="tableFooter" style="width: 100%;">
        <tr style="height: 400px; vertical-align: top;">
            <td>
                <asp:PlaceHolder ID="myPlaceHolder" runat="server"></asp:PlaceHolder>
             </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td>
            <asp:Label ID="lblCopyright" runat="server" Font-Size="X-Small" Text="Copyright © 2019 OSSAA. All rights reserved.  "></asp:Label><a href="http://www.ossaa.com" target="_blank"><span style="font-family: Century Gothic; Font-Size:X-Small;">OSSAA Home Page</span></a>
        </td>
        </tr>
    </table>
</asp:Content>
