<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="PlayoffAvailabilityVB.aspx.vb" Inherits="OSSAARankings.PlayoffAvailabilityVB" %>
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
<tr id="PageTitle" style="background-image:url('../images/red_bg.gif'); height:30px;"><td><asp:Label ID="lblPageHeader" runat="server" Text="&nbsp;&nbsp;&nbsp;OFFICIALS VOLLEYBALL PLAYOFF AVAILABILITY" style="font-family:Arial; font-size:16px; font-weight:bold; background-image:url('../images/red_bg.gif'); color:Yellow;"></asp:Label></td></tr>
<tr><td> 
    <table>
        <tr>
            <td><uc1:OfficialInfo ID="OfficialInfo1" runat="server" /></td>
            <td>
                <asp:Button ID="cmdSave1" runat="server" Text="Save Changes" CssClass="button" BackColor="Lime" ForeColor="Navy" Font-Bold="true" />
            </td>
        </tr>
    </table>
</td></tr>    
<tr style="background-color: Yellow;">
    <td>
        <asp:Label ID="lblMessage" runat="server" Text="" Font-Names="Arial" Font-Size="16px" Font-Bold="true" ForeColor="Red" BackColor="Yellow"></asp:Label>
    
    </td>
</tr>
<tr id="trStep1">
    <td>
        <asp:Panel ID="panelStep1" runat="server" CssClass="pnlCSS" Width="100%">
        <div style="background-image:url('../images/black_bg.gif'); height:30px;">
        <div style="float:left; color:White; padding:5px 5px 0 0">&nbsp;&nbsp;</div>
        <div style="float:left; color:White; padding:5px 5px 0 0">
            <asp:Label ID="lblMessageStep1" runat="server" Text=""/>
            <asp:Image ID="imgArrowsStep1" runat="server" />
        </div>
        <div style="clear:both"></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="panelStep1Collapsable" runat="server" CssClass="pnlCSS" Width="95%" Height="700px" BorderStyle="None">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblInstructionsStep1a" runat="server" Text="" CssClass="panelInst">Number of High School Dates worked THIS SEASON</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="cboHSGames" runat="server" CssClass="dropdown">
                        <asp:ListItem Selected="True">Select...</asp:ListItem>
                        <asp:ListItem>0-10</asp:ListItem>
                        <asp:ListItem>10-20</asp:ListItem>
                        <asp:ListItem>20 plus</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>        
    </asp:Panel>
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
            <tr style="background-color:Silver;">
                <td width="210px">
                    <asp:Label ID="lblSession3A4A1" runat="server" Text="&nbsp;Oct 9-10 : 3A-4A STATE : " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSession3A4A1" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="1">Available</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="210px">
                    <asp:Label ID="lblSession3A4A2" runat="server" Text="&nbsp;&nbsp;&nbsp;Willing to work as line judge? " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSession3A4A2" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="1">Available</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr style="background-color:Silver;">
                <td width="210px">
                    <asp:Label ID="lblSession5A6A1" runat="server" Text="&nbsp;Oct 16-17 : 5A-6A STATE : " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSession5A6A1" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="1">Available</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="210px">
                    <asp:Label ID="lblSession5A6A2" runat="server" Text="&nbsp;&nbsp;&nbsp;Willing to work as line judge? " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSession5A6A2" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="1">Available</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>        
    </asp:Panel>
    </td>
</tr>
<tr id="trStep3">
    <td>
        <asp:Panel ID="panelStep3" runat="server" CssClass="pnlCSS" Width="100%">
        <div style="background-image:url('../images/black_bg.gif'); height:30px;">
        <div style="float:left; color:White; padding:5px 5px 0 0">&nbsp;&nbsp;</div>
        <div style="float:left; color:White; padding:5px 5px 0 0">
            <asp:Label ID="lblMessageStep3" runat="server" Text=""/>
            <asp:Image ID="imgArrowsStep3" runat="server" />
        </div>
        <div style="clear:both"></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="panelStep3Collapsable" runat="server" CssClass="pnlCSS" Width="95%" Height="700px" BorderStyle="None">
        <table id="Step4">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblInstructionsStep3" runat="server" Text="" CssClass="panelInst" Font-Size="Small">A conflict with a school would be defined on two levels:  <br />1) A conflict of interests (being an alumni of school, having a relative that works for the school, having a relative that attends the school or having a school that is a business client, etc.)  <strong><u>If you think you might have a conflict; YOU HAVE A CONFLICT.</u></strong>  <br />2)  A team/coach conflict as in a problem with a VOLLEYBALL coach or VOLLEYBALL team in the past.</asp:Label>
                </td>
            </tr>
            <tr>
                <td width="210px">
                    <asp:Label ID="lblTeamConflict1" runat="server" Text="&nbsp;Team Conflict #1 :&nbsp;&nbsp;" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboTeamConflict1" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="SchoolName" DataValueField="schoolID" CssClass="dropdown" >
                        <asp:ListItem Value="0" Text="Select..."></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="210px">
                    <asp:Label ID="lblTeamConflict2" runat="server" Text="&nbsp;Team Conflict #2 :&nbsp;&nbsp;" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboTeamConflict2" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="SchoolName" DataValueField="schoolID" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>   
            <tr>
                <td width="210px">
                    <asp:Label ID="lblTeamConflict3" runat="server" Text="&nbsp;Team Conflict #3 :&nbsp;&nbsp;" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboTeamConflict3" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="SchoolName" DataValueField="schoolID" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>  
            <tr>
                <td width="210px">
                    <asp:Label ID="lblTeamConflict4" runat="server" Text="&nbsp;Team Conflict #4 :&nbsp;&nbsp;" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboTeamConflict4" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="SchoolName" DataValueField="schoolID" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>  
            <tr>
                <td width="210px">
                    <asp:Label ID="lblTeamConflict5" runat="server" Text="&nbsp;Team Conflict #5 :&nbsp;&nbsp;" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboTeamConflict5" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="SchoolName" DataValueField="schoolID" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>         
        </table>                                               
    </asp:Panel>
    </td>
</tr>
<tr id="trSave2"><td><asp:Button ID="cmdSave2" runat="server" Text="Save Changes" CssClass="button"  BackColor="Lime" ForeColor="Navy" Font-Bold="true"/></td></tr>
<ajax:CollapsiblePanelExtender
    ID="CollapsiblePanelExtenderStep1"
    runat="server"
    CollapseControlID="panelStep1"
    Collapsed="false"
    ExpandControlID="panelStep1"
    TextLabelID="lblMessageStep1"
    CollapsedText="Step 1 : Your Level of Officiating..."
    ExpandedText="Step 1 : Your Level of Officiating"
    ImageControlID="imgArrowsStep1"
    CollapsedImage="blank.gif"
    ExpandedImage="blank.gif"
    ExpandDirection="Vertical"
    TargetControlID="panelStep1Collapsable"
    ScrollContents="false">
</ajax:CollapsiblePanelExtender>
<ajax:CollapsiblePanelExtender
    ID="CollapsiblePanelExtenderStep2"
    runat="server"
    CollapseControlID="panelStep2"
    Collapsed="false"
    ExpandControlID="panelStep2"
    TextLabelID="lblMessageStep2"
    CollapsedText="Step 2 : Playoff Availability..."
    ExpandedText="Step 2 : Playoff Availability"
    ImageControlID="imgArrowsStep2"
    CollapsedImage="blank.gif"
    ExpandedImage="blank.gif"
    ExpandDirection="Vertical"
    TargetControlID="panelStep2Collapsable"
    ScrollContents="false">
</ajax:CollapsiblePanelExtender>
<ajax:CollapsiblePanelExtender
    ID="CollapsiblePanelExtenderStep3"
    runat="server"
    CollapseControlID="panelStep3"
    Collapsed="false"
    ExpandControlID="panelStep3"
    TextLabelID="lblMessageStep3"
    CollapsedText="Step 3 : School Conflicts..."
    ExpandedText="Step 3 : School Conflicts"
    ImageControlID="imgArrowsStep3"
    CollapsedImage="blank.gif"
    ExpandedImage="blank.gif"
    ExpandDirection="Vertical"
    TargetControlID="panelStep3Collapsable"
    ScrollContents="false">
</ajax:CollapsiblePanelExtender>
</table>  
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAServerConnectionString %>" 
        SelectCommand="SELECT [schoolID], [SchoolName] FROM [qryTeamsVolleyball] ORDER BY SchoolName">
    </asp:SqlDataSource>  
</asp:Content>
