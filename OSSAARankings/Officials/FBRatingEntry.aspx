<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="FBRatingEntry.aspx.vb" Inherits="OSSAARankings.FBRatingEntry" %>
<%@ Register src="FBCoachInfo.ascx" tagname="FBCoachInfo" tagprefix="uc1" %>
<%@ Register src="FBCoachEdit.ascx" tagname="FBCoachEdit" tagprefix="uc3" %>
<%@ Register src="EligibleOfficialsFootball.ascx" tagname="EligibleOfficialsFootball" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="FB">

    <tr>
        <td align="left" valign="top">
            <uc1:FBCoachInfo ID="FBCoachInfo1" runat="server" />
        </td>
        <td align="left" valign="top">
            <asp:Button ID="cmdShowOfficials" runat="server" Text="Show Officials" CssClass="button" />
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            <uc3:FBCoachEdit ID="FBCoachEdit1" runat="server" />
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblEOff" runat="server" Text="Eligible Officials" CssClass="label" Visible="false"></asp:Label>
            <uc2:EligibleOfficialsFootball ID="EligibleOfficialsFootball1" runat="server" Visible="false" />
        </td>
    </tr>
</table>    
</asp:Content>
