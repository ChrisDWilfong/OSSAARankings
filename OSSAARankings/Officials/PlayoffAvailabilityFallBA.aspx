<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="PlayoffAvailabilityFallBA.aspx.vb" Inherits="OSSAARankings.PlayoffAvailabilityFallBA" %>
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
<tr id="PageTitle" style="background-image:url('../images/red_bg.gif'); height:30px;"><td><asp:Label ID="lblPageHeader" runat="server" Text="&nbsp;&nbsp;OFFICIALS 2014 FALL BASEBALL PLAYOFF AVAILABILITY" style="font-family:Arial; font-size:16px; font-weight:bold; background-image:url('../images/red_bg.gif'); color:Yellow;"></asp:Label></td></tr>
<tr><td> 
    <table>
        <tr>
            <td><uc1:OfficialInfo ID="OfficialInfo1" runat="server" /></td>
            <td><asp:Button ID="cmdGoBack" runat="server" Text="Go Back to Main Menu" 
                    CssClass="button" Visible="False" />
                    <asp:Button ID="cmdSave1" runat="server" Text="Save Changes" CssClass="buttonSave" />
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
                    <asp:Label ID="lblInstructionsStep1aa" runat="server" Text="" CssClass="panelInst">Number of State Baseball Tournaments worked</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="intNumberOfStateTournaments" runat="server" Width="30px" CssClass="dropdown"></asp:TextBox>
                </td>
            </tr>
            <tr><td><asp:Label ID="lblHatSize" runat="server" Text="" CssClass="panelInst">Fitted Hat Size</asp:Label></td></tr>
            <tr>
                <td>
                    <asp:DropDownList ID="cboHatSize" runat="server" CssClass="dropdown">
                        <asp:ListItem Selected="True">Select...</asp:ListItem>
                        <asp:ListItem>6 7/8</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>7 1/8</asp:ListItem>
                        <asp:ListItem>7 1/4</asp:ListItem>
                        <asp:ListItem>7 3/8</asp:ListItem>
                        <asp:ListItem>7 1/2</asp:ListItem>
                        <asp:ListItem>7 5/8</asp:ListItem>
                        <asp:ListItem>7 3/4</asp:ListItem>
                        <asp:ListItem>7 7/8</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblInstructionsStep1a" runat="server" Text="" CssClass="panelInst">Number of BASEBALL High School Dates worked THIS FALL</asp:Label>
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
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="" CssClass="panelInst">Level of play you worked LAST BASEBALL (SPRING OR FALL) PLAYOFF SEASON (check all that apply)</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;<asp:CheckBox CssClass="checkbox" ID="cbLevel1" runat="server" Text="&nbsp;&nbsp;None" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;<asp:CheckBox CssClass="checkbox" ID="cbLevel2" runat="server" Text="&nbsp;&nbsp;District" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;<asp:CheckBox CssClass="checkbox" ID="cbLevel3" runat="server" Text="&nbsp;&nbsp;Regional" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;<asp:CheckBox CssClass="checkbox" ID="cbLevel4" runat="server" Text="&nbsp;&nbsp;State" />
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
        <table width="70%" border="0">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblInstructionsStep2" runat="server" Text="" CssClass="panelInst">Check all you WILL be available</asp:Label>
                </td>
            </tr>
            <tr style="background-color:Gray;">
                <td colspan="2">
                    <asp:Label ID="lblBlank1" runat="server" Text="&nbsp;Fall Baseball Tournament" CssClass="label" ForeColor="Yellow"></asp:Label>
                </td>
            </tr>
            <tr style="background-color:Silver;">
                <td width="375px">
                    <asp:Label ID="lblThursAB1" runat="server" Text="&nbsp;Thursday, Oct 9, OKC Area : 11am/1:30pm : " CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="cbThursAB1" runat="server" />
                </td>
            </tr>
            <tr style="background-color:Silver;">
                <td width="375px">
                    <asp:Label ID="lblThursAB2" runat="server" Text="&nbsp;Thursday, Oct 9, OKC Area : 5pm/7:30pm : " CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="cbThursAB2" runat="server" />
                </td>
            </tr>
            <tr style="background-color:WhiteSmoke;">
                <td width="375px">
                    <asp:Label ID="lblFriAB1" runat="server" Text="&nbsp;Friday, Oct 10, OKC Area : 11am/1:30pm : " CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="cbFriAB1" runat="server" />
                </td>
            </tr>
            <tr style="background-color:WhiteSmoke;">
                <td width="375px">
                    <asp:Label ID="lblFriAB2" runat="server" Text="&nbsp;Friday, Oct 10, OKC Area : 5pm/7:30pm : " CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="cbFriAB2" runat="server" />
                </td>
            </tr>
            <tr style="background-color:Silver;">
                <td width="375px">
                    <asp:Label ID="lblSatAB" runat="server" Text="&nbsp;Saturday, Oct 11, Bricktown (OKC) : NOON/2:30pm : " CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="cbSatAB" runat="server" />
                </td>
            </tr>
            <tr><td colspan="2"><hr /></td></tr>
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
                    <asp:Label ID="lblInstructionsStep3" runat="server" Text="" CssClass="panelInst" Font-Size="Small">A conflict with a school would be defined on two levels:  <br />1) A conflict of interests (being an alumni of school, having a relative that works for the school, having a relative that attends the school or having a school that is a business client, etc.)  <br />2)  A team/coach conflict as in a problem with a baseball coach or baseball team in the past.</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
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
                <td>
                    <asp:Label ID="lblTeamConflict2" runat="server" Text="&nbsp;Team Conflict #2 :&nbsp;&nbsp;" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboTeamConflict2" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="SchoolName" DataValueField="schoolID" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>   
            <tr>
                <td>
                    <asp:Label ID="lblTeamConflict3" runat="server" Text="&nbsp;Team Conflict #3 :&nbsp;&nbsp;" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboTeamConflict3" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="SchoolName" DataValueField="schoolID" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>  
            <tr>
                <td>
                    <asp:Label ID="lblTeamConflict4" runat="server" Text="&nbsp;Team Conflict #4 :&nbsp;&nbsp;" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboTeamConflict4" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="SchoolName" DataValueField="schoolID" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>  
            <tr>
                <td>
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
<tr id="trSave2"><td><asp:Button ID="cmdSave2" runat="server" Text="Save Changes" CssClass="buttonSave" /></td></tr>
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
        SelectCommand="SELECT [schoolID], [SchoolName] FROM [qryTeamsBaseballFall] ORDER BY SchoolName">
    </asp:SqlDataSource>  
</asp:Content>
