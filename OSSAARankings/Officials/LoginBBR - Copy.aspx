<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="LoginBBR.aspx.vb" Inherits="OSSAARankings.LoginBBR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr><td>&nbsp;</td></tr>
        <tr><td><asp:Label ID="Label2" runat="server" 
                Text="Head Basketball Coach Login (for Varsity Basketball Rating of Officials)" 
                Font-Names="Arial" Font-Bold="True" 
                    Font-Size="12pt"></asp:Label></td></tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Login Code : " Font-Names="Verdana" Font-Size="10pt" Width="150px"></asp:Label>
                <asp:TextBox
                    ID="txtUsername" runat="server" Font-Names="Verdana" Font-Size="10pt" 
                    Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Select School : " Font-Names="Verdana" Font-Size="10pt" Width="150px"></asp:Label>
                <asp:DropDownList ID="cboSchools" runat="server" Font-Names="Verdana" Font-Size="10pt" 
                    Width="350px" DataSourceID="SqlDataSource1" DataTextField="strSchoolName" 
                    DataValueField="schoolID"></asp:DropDownList>&nbsp;&nbsp;
                <asp:Button ID="cmdLogin" runat="server"
                        Text="Login" Font-Names="Verdana" Font-Size="10pt" />
            </td>
        </tr>
        <tr><td><asp:Label ID="lblMessage" runat="server" Font-Names="Verdana" 
                Font-Size="9pt" ForeColor="Red"></asp:Label></td></tr>
        
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT schoolID, SchoolName AS strSchoolName FROM [qryBasketballTeams] ORDER BY [SchoolName]"></asp:SqlDataSource>
</asp:Content>
