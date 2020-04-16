<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Officials/Soccer.Master" CodeBehind="PrefEntrySC.aspx.vb" Inherits="OSSAARankings.PrefEntrySC" ClientTarget="uplevel" %>
<%@ Register src="PrefInfoSC.ascx" tagname="PrefInfo" tagprefix="uc1" %>
<%@ Register src="PrefEditSC.ascx" tagname="PrefEdit" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="SC">

    <tr>
        <td align="left" valign="top">
            <uc1:PrefInfo ID="PrefInfo1" runat="server" />
        </td>
        <td align="left" valign="top">
            <a href="http://www.ossaarankings.com/Officials/EligibleOfficialsPlayoffsSC.aspx" target="_blank"><span style="font-family:Verdana; font-size:14px; font-weight:bold;">View Available Officials</span></a>
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
