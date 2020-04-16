<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="FBScratchList.aspx.vb" Inherits="OSSAARankings.FBScratchList" %>
<%@ Register src="FBCoachInfo.ascx" tagname="FBCoachInfo" tagprefix="uc1" %>
<%@ Register src="ucFBScratchList.ascx" tagname="ucFBScratchList" tagprefix="uc3" %>
<%@ Register src="EligibleOfficialsFootballPlayoffs.ascx" tagname="EligibleOfficialsFootball" tagprefix="uc2" %>

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
            <uc3:ucFBScratchList ID="ucFBScratchList1" runat="server" />
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblEOff" runat="server" Text="Eligible/Available Officials" CssClass="label" Visible="false"></asp:Label>
            <uc2:EligibleOfficialsFootball ID="EligibleOfficialsFootball1" runat="server" Visible="false" />
        </td>
    </tr>
</table>    
</asp:Content>
