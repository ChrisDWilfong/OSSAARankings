<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Officials/Basketball.Master" CodeBehind="PrefEntry.aspx.vb" Inherits="OSSAARankings.PrefEntry" ClientTarget="uplevel" %>
<%@ Register src="PrefInfo.ascx" tagname="PrefInfo" tagprefix="uc1" %>
<%@ Register src="PrefEdit.ascx" tagname="PrefEdit" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="FB">

    <tr>
        <td align="left" valign="top">
            <uc1:PrefInfo ID="PrefInfo1" runat="server" />
        </td>
        <td align="left" valign="top">
            <a href="http://www.ossaarankings.com/Officials/EligibleOfficialsPlayoffs.aspx" target="_blank"><span style="font-family:Verdana; font-size:14px; font-weight:bold;">View Available Officials</span></a>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            <uc3:PrefEdit ID="PrefEdit1" runat="server" />
        </td>
        <td align="left" valign="top">
            &nbsp;
        </td>
    </tr>
</table>    
</asp:Content>
