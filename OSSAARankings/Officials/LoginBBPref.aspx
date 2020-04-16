<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Officials/Basketball.Master" CodeBehind="LoginBBPref.aspx.vb" Inherits="OSSAARankings.LoginBBPref" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 804px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr><td class="style1">&nbsp;</td></tr>
        <tr><td class="style1"><asp:Label ID="lblLoginType" runat="server" Text="Login" Font-Names="Arial" Font-Bold="True" Font-Size="12pt"></asp:Label></td></tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblEmail" runat="server" Text="Your Email : " Font-Names="Verdana" Font-Size="10pt" Width="150px"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" Font-Names="Verdana" Font-Size="10pt" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblSchool" runat="server" Text="Select your School : " Font-Names="Verdana" Font-Size="10pt" Width="150px"></asp:Label>
                <asp:DropDownList ID="cboSchools" runat="server" Font-Names="Verdana" Font-Size="10pt" Width="350px" DataTextField="strSchool" DataValueField="schoolID"></asp:DropDownList>&nbsp;&nbsp;
                <asp:Button ID="cmdLogin" runat="server" Text="Login" Font-Names="Verdana" Font-Size="10pt" />
            </td>
        </tr>
        <tr>
            <td class="style1">
            <asp:Label ID="lblGender" runat="server" Text="6A-5A Please select Boys or Girls : " CssClass="label" Visible="false"></asp:Label>
            <asp:DropDownList ID="cboGender" runat="server" CssClass="dropdown" Visible="false">
                <asp:ListItem>Select...</asp:ListItem>
                <asp:ListItem>Boys</asp:ListItem>
                <asp:ListItem>Girls</asp:ListItem>
            </asp:DropDownList>
            </td>
        </tr>
        <tr><td class="style1"><asp:Label ID="lblMessage" runat="server" Font-Names="Verdana" 
                Font-Size="9pt" ForeColor="Red"></asp:Label></td></tr>
        
    </table>
</asp:Content>
