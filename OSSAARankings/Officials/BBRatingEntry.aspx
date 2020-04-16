<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="BBRatingEntry.aspx.vb" Inherits="OSSAARankings.BBRatingEntry" %>
<%@ Register src="BBCoachInfo.ascx" tagname="BBCoachInfo" tagprefix="uc1" %>
<%@ Register src="BBCoachEdit.ascx" tagname="BBCoachEdit" tagprefix="uc3" %>
<%@ Register src="EligibleOfficialsBasketball.ascx" tagname="EligibleOfficialsBasketball" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="FB">

    <tr>
        <td align="left" valign="top">
            <uc1:BBCoachInfo ID="BBCoachInfo1" runat="server" />
        </td>
        <td align="left" valign="top">
            <asp:Button ID="cmdShowOfficials" runat="server" Text="Show Officials" CssClass="button" />
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            <uc3:BBCoachEdit ID="BBCoachEdit1" runat="server" />
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblEOff" runat="server" Text="Eligible Officials" CssClass="label" Visible="false"></asp:Label>
            <uc2:EligibleOfficialsBasketball ID="EligibleOfficialsBasketball1" runat="server" Visible="false" />
        </td>
    </tr>
</table>    
</asp:Content>
