<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="Login1718.aspx.vb" Inherits="OSSAARankings.Login1718" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr><td>&nbsp;</td></tr>
        <tr><td><asp:Label ID="Label2" runat="server" Text="OFFICIALS LOGIN" Font-Names="Segoe UI" Font-Bold="true" Font-Size="14pt"></asp:Label></td></tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Arbiter Email Address : " Font-Names="Verdana" Font-Size="10pt" Width="200px"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" Font-Names="Verdana" Font-Size="10pt" BorderColor="LightGray" BorderWidth="1px" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="OSSAA ID# : " Font-Names="Verdana" Font-Size="10pt" Width="200px"></asp:Label>
                <asp:TextBox ID="txtOSSAAID" runat="server" Font-Names="Verdana" Font-Size="10pt" BorderColor="LightGray" BorderWidth="1px" Width="100px" MaxLength="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="cmdLogin" runat="server" Text="Login" Font-Names="Verdana" Font-Size="10pt" />
            </td>
        </tr>
        <tr><td><asp:Label ID="lblMessage" runat="server" Font-Names="Verdana" Font-Size="9pt" ForeColor="Red"></asp:Label></td></tr>
        
    </table>
</asp:Content>
