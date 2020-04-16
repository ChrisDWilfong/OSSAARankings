<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="SiteMembership.Master" CodeBehind="MemberHelp.aspx.vb" Inherits="OSSAARankings.MemberHelp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table id="tableDetail" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblStep" runat="server" Text="" Font-Bold="True" ForeColor="Red" Font-Size="Large"
                    CssClass="objectTitle"></asp:Label>
            </td>
        </tr>
    </table>
   <table id="tableContent" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Purpose?" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="This portion of our website has been specifically designed to disseminate information to the membership, (Superintendents, Principals, and Athletic Directors)  that is not necessarily seen by the general public. The public information will still be available from our OSSAA.com website; however, on this side you will find additional information such as, OSSAA Board of Directors Minutes, Financial Information, and specific contact information regarding playoff series events throughout the year.  We hope you find this a useful tool for your school.  It is our mission to provide as much information as possible, as easily as possible."></asp:Label>
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Who has access to this site?" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Access to this site requires a username and password and is accessable only by Superintendents, High School Principals and Athletic Directors."></asp:Label>
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="I am a Superintendent, HS Principal, Athletic Director but don't have a login, what do I do?" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="You can request a login from our website by submitting your email address and contact information. "></asp:Label> <a href="MemberForgotLogin.aspx">Click Here</a>
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>

    </table>
    <table id="tableFooter" style="width: 100%;">
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td>
            <asp:Label ID="lblCopyright" runat="server" Font-Size="X-Small" Text="Copyright © 2014 OSSAA. All rights reserved.  "></asp:Label><a href="http://www.ossaa.com" target="_blank"><span style="font-family: Century Gothic; Font-Size:X-Small;">OSSAA Home Page</span></a>
        </td>
        </tr>
        <tr>
        <td>
            &nbsp;</td>
        </tr>
    </table>


</asp:Content>
