﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="LoginBAOSheree.aspx.vb" Inherits="OSSAARankings.LoginBAOSheree" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr><td>&nbsp;</td></tr>
        <tr><td><asp:Label ID="Label2" runat="server" Text="Baseball Umpires Login (for Playoff Availability)" Font-Names="Arial" Font-Bold="true" Font-Size="12pt"></asp:Label></td></tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Email Address or OSSAA ID# : " Font-Names="Verdana" Font-Size="10pt"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" Font-Names="Verdana" Font-Size="10pt" Width="250px"></asp:TextBox>
                <asp:Button ID="cmdLogin" runat="server" Text="Login" Font-Names="Verdana" Font-Size="10pt" />
            </td>
        </tr>
        <tr><td><asp:Label ID="lblMessage" runat="server" Font-Names="Verdana" Font-Size="9pt" ForeColor="Red"></asp:Label></td></tr>
    </table>
</asp:Content>
