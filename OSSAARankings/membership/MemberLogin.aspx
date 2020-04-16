<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="SiteLogin.Master" CodeBehind="MemberLogin.aspx.vb" Inherits="OSSAARankings.MemberLogin" %>
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
        <tr>
            <td>
                <asp:Label ID="lblTitle" runat="server" Text="" Font-Bold="True" 
                    CssClass="objectTitle"></asp:Label>
            </td>
        </tr>
    </table>

    <table id="tableFooter" style="width: 100%;">
        <tr><td>&nbsp;</td></tr>
        <tr><td><span class="content">This is the login page for the OSSAA Membership Website for Superintendents, High School Principals and Athletic Directors only.
        </span></td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>
            <asp:Login ID="Login1" runat="server" Width="596px" Orientation="Horizontal" 
                TextLayout="TextOnTop" DisplayRememberMe="False" TabIndex="1">
                <CheckBoxStyle Font-Names="Century Gothic" />
                <LabelStyle Font-Names="Century Gothic" />
                <LoginButtonStyle Font-Names="Century Gothic" />
                <TextBoxStyle Font-Names="Century Gothic" Width="250px" />
                <TitleTextStyle Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" 
                    HorizontalAlign="Left" />
            </asp:Login>
            </td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>
            <asp:Button ID="cmdForgotLogin" runat="server" CssClass="button" 
                Text="Forgot or Need Login?" CausesValidation="False" />
                </td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td>
            <asp:Label ID="lblCopyright" runat="server" Font-Size="X-Small" Text="Copyright © 2014 OSSAA. All rights reserved.  "></asp:Label>
        </td>
        </tr>
    </table>
</asp:Content>
