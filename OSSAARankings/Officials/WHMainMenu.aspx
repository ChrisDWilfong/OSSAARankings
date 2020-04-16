<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="WHMainMenu.aspx.vb" Inherits="OSSAARankings.WHMainMenu" %>
<%@ Register src="OfficialInfo.ascx" tagname="OfficialInfo" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="FB" width="500px">
    <tr>
        <td align="left" valign="top" colspan="2">
            <uc1:OfficialInfo ID="OfficialInfo1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width="50%">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/WH1.png" AlternateText="Report" />
        </td>
        <td width="50%">
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/WH2.png" AlternateText="Availability for Playoffs" Visible="true"/>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td align="left" class="style2"><asp:Label ID="lblNote" runat="server" Text="In order to enter your Playoff Availibility, you must have a Crew Test submitted." style="color: Red; font-family: Verdana; font-size:9px;" visible="false"></asp:Label></td>
    </tr>
    <tr>
        <td align="left" valign="top" colspan="2">
            <asp:Label ID="lblMessage" runat="server" Text="" style="color: Red; font-family: Verdana; font-size:12px; font-weight:bold;"></asp:Label>
        </td>
        
    </tr>
</table>    
</asp:Content>
