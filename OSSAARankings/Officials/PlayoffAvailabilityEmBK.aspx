<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="PlayoffAvailabilityEmBK.aspx.vb" Inherits="OSSAARankings.PlayoffAvailabilityEmBK" %>
<%@ Register src="OfficialInfo.ascx" tagname="OfficialInfo" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table id="tableAvailibility" width="900px">  
    <link href="Officials.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .pnlCSS{
            font-weight: bold;
            cursor: pointer;
            border: solid 1px #c0c0c0;
            width:250px;
            font-family:Arial;
            font-size:11pt;
            vertical-align: top;
            text-align: left;
            color: Yellow;
    }
    </style>
    <ajax:toolkitscriptmanager ID="ScriptManager1" runat="server"></ajax:toolkitscriptmanager> 
<tr id="PageTitle" style="background-image:url('../images/red_bg.gif'); height:30px;"><td><asp:Label ID="lblPageHeader" runat="server" Text="&nbsp;&nbsp;OFFICIALS 2015 EMERGENCY BASKETBALL PLAYOFF AVAILABILITY" style="font-family:Arial; font-size:16px; font-weight:bold; background-image:url('../images/red_bg.gif'); color:Yellow;"></asp:Label></td></tr>
<tr><td> 
    <table>
        <tr>
            <td><uc1:OfficialInfo ID="OfficialInfo1" runat="server" /></td>
            <td>
                <asp:Button ID="cmdGoBack" runat="server" Text="Go Back to Main Menu" CssClass="button" Visible="False" />
                <asp:Button ID="cmdSave1" runat="server" Text="Save Changes" CssClass="button" BackColor="Lime" Font-Bold="true" />
            </td>
        </tr>
    </table>
</td></tr>    
<tr style="background-color: Yellow;">
    <td>
        <asp:Label ID="lblMessage" runat="server" Text="" Font-Names="Arial" Font-Size="16px" Font-Bold="true" ForeColor="Red" BackColor="Yellow"></asp:Label>
    
    </td>
</tr>
<tr id="trStep2">
    <td>
        <asp:Panel ID="panelStep2" runat="server" CssClass="pnlCSS" Width="100%">
        <div style="background-image:url('../images/black_bg.gif'); height:30px;">
        <div style="float:left; color:White; padding:5px 5px 0 0">&nbsp;&nbsp;</div>
        <div style="float:left; color:White; padding:5px 5px 0 0">
            <asp:Label ID="lblMessageStep2" runat="server" Text=""/>
            <asp:Image ID="imgArrowsStep2" runat="server" />
        </div>
        <div style="clear:both"></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="panelStep2Collapsable" runat="server" CssClass="pnlCSS" Width="95%" Height="700px" BorderStyle="None">
        <table width="75%" border="0">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblInstructionsStep2" runat="server" Text="" CssClass="panelInst">Check the days you WILL be available</asp:Label>
                </td>
            </tr>
            <tr style="background-color:Gray;">
                <td colspan="2">
                    <asp:Label ID="lblBlank3" runat="server" Text="&nbsp;Week #3 : 2A-6A REGIONAL & A-B AREA" CssClass="label" ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr style="background-color:Silver;">
                <td width="110px">
                    <asp:Label ID="lblSessionW3D1" runat="server" Text="&nbsp;Mon : Mar 2 : " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSessionW3D1" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="3">Both Sessions</asp:ListItem>
                    <asp:ListItem Value="2">Evening Only</asp:ListItem>
                    <asp:ListItem Value="1">Afternoon Only</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="110px">
                    <asp:Label ID="lblSessionW3D2" runat="server" Text="&nbsp;Tues : Mar 3 : " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSessionW3D2" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="3">Both Sessions</asp:ListItem>
                    <asp:ListItem Value="2">Evening Only</asp:ListItem>
                    <asp:ListItem Value="1">Afternoon Only</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr style="background-color:Silver;">
                <td width="110px">
                    <asp:Label ID="lblSessionW3D3" runat="server" Text="&nbsp;Wed : Mar 4 : " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSessionW3D3" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="3">Both Sessions</asp:ListItem>
                    <asp:ListItem Value="2">Evening Only</asp:ListItem>
                    <asp:ListItem Value="1">Afternoon Only</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr><td colspan="2">&nbsp;</td></tr>
            <tr style="background-color:Silver;">
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="&nbsp;Current Playoff Assignments" ForeColor="Navy"></asp:Label>
                </td>
            </tr>
             <tr><td colspan="2"><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://www.ossaaonline.com/docs/2014-15/Basketball/6A-5A/OfficialsList6A5ARegionals.pdf?id=1" Target="_blank" CssClass="textbox">Officials Assignment List : Class 6A-5A Regionals</asp:HyperLink></td></tr>
            <tr><td colspan="2"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.ossaaonline.com/docs/2014-15/Basketball/4A-2A/OfficialsList4A2ARegionals.pdf?id=1" Target="_blank" CssClass="textbox">Officials Assignment List : Class 4A-2A Regionals</asp:HyperLink></td></tr>
            <tr><td colspan="2"><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="http://www.ossaaonline.com/docs/2014-15/Basketball/A-B/OfficialsListABArea.pdf?id=1" Target="_blank" CssClass="textbox">Officials Assignment List : Class A-B Areas</asp:HyperLink></td></tr>
            <tr><td align="left" valign="top" colspan="2"><a href="http://www.ossaarankings.com/Officials/EligibleOfficialsPlayoffs.aspx" target="_blank"><span style="font-family:Verdana; font-size:14px; font-weight:bold;">View Available Officials</span></a></td></tr>
        </table>        
    </asp:Panel>
    </td>
</tr>
<tr id="trSave2"><td><asp:Button ID="cmdSave2" runat="server" Text="Save Changes" CssClass="button"  BackColor="Lime" Font-Bold="true"/></td></tr>
</table>  
</asp:Content>
