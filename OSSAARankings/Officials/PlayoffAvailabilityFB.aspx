<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="PlayoffAvailabilityFB.aspx.vb" Inherits="OSSAARankings.PlayoffAvailabilityFB" %>
<%@ Register src="OfficialInfo.ascx" tagname="OfficialInfo" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
    <ProgressTemplate   >            
        <div ><img alt="progress" src="../images/ajax-loader1.gif"/><span style="font-family: Verdana; font-size:10px;">Processing...</span></div>
    </ProgressTemplate>
</asp:UpdateProgress>
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
<tr id="PageTitle" style="background-image:url('../images/red_bg.gif'); height:30px;"><td><asp:Label ID="lblPageHeader" runat="server" Text="&nbsp;&nbsp;WHITE HAT 2014 FOOTBALL PLAYOFF AVAILABILITY" style="font-family:Arial; font-size:16px; font-weight:bold; background-image:url('../images/red_bg.gif'); color:Yellow;"></asp:Label></td></tr>
<tr><td> 
    <table>
        <tr>
            <td><uc1:OfficialInfo ID="OfficialInfo1" runat="server" /></td>
            <td><asp:Button ID="cmdGoBack" runat="server" Text="Go Back to Main Menu" CssClass="button" /></td>
        </tr>
    </table>
</td></tr>    
<tr id="trSave1"><td><asp:Button ID="cmdSave1" runat="server" Text="Save Changes" CssClass="button" BackColor="Green" ForeColor="Yellow" Font-Bold="true" Font-Size="12pt" /><asp:Label ID="lblMessage" CssClass="label" runat="server" Text="" style="color:Red; font-weight:bold; font-size:14pt; background-color:Yellow;"></asp:Label></td></tr>
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
    <asp:Panel ID="panelStep1Collapsable" runat="server" CssClass="pnlCSS" Width="95%" Height="800px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table width="50%">
            <tr style="background-color:Gray;">
                <td width="25%" align="center"><asp:Label ID="Label1" runat="server" Text="OSSAA ID#" CssClass="shadedheader"></asp:Label></td>
                <td width="65%" align="center"><asp:Label ID="Label2" runat="server" Text="OFFICIAL (CLASSIFICATION-RATING)" CssClass="shadedheader" style="font-size:14px"></asp:Label></td>
            </tr>
            <tr style="background-color:Silver;">
                <td width="25%" valign="top" align="right"><asp:Label ID="lblNo1" runat="server" Text="&nbsp;R :" CssClass="label"></asp:Label>&nbsp;
                <asp:TextBox ID="txtOSSAAID1" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox></td>
                <td width="65%" valign="top">&nbsp;<i><asp:Label ID="lblOfficialName1" runat="server" Text="" CssClass="label"></asp:Label></i></td>
            </tr>
            <tr>
                <td width="25%" valign="top" align="right"><asp:Label ID="lblNo2" runat="server" Text="&nbsp;U :" CssClass="label"></asp:Label>&nbsp;
                <asp:TextBox ID="txtOSSAAID2" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox></td>
                <td width="65%" valign="top">&nbsp;<i><asp:Label ID="lblOfficialName2" runat="server" Text="" CssClass="label"></asp:Label></i></td>
            </tr>
            <tr style="background-color:Silver;">
                <td width="25%" valign="top" align="right"><asp:Label ID="lblNo3" runat="server" Text="&nbsp;HL:" CssClass="label"></asp:Label>&nbsp;
                <asp:TextBox ID="txtOSSAAID3" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox></td>
                <td width="65%" valign="top">&nbsp;<i><asp:Label ID="lblOfficialName3" runat="server" Text="" CssClass="label"></asp:Label></i></td>
            </tr>
            <tr>
                <td width="25%" valign="top" align="right"><asp:Label ID="lblNo4" runat="server" Text="&nbsp;LJ:" CssClass="label"></asp:Label>&nbsp;
                <asp:TextBox ID="txtOSSAAID4" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox></td>
                <td width="65%" valign="top">&nbsp;<i><asp:Label ID="lblOfficialName4" runat="server" Text="" CssClass="label"></asp:Label></i></td>
            </tr>
            <tr style="background-color:Silver;">
                <td width="25%" valign="top" align="right"><asp:Label ID="lblNo5" runat="server" Text="&nbsp;BJ:" CssClass="label"></asp:Label>&nbsp;
                <asp:TextBox ID="txtOSSAAID5" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox></td>
                <td width="65%" valign="top">&nbsp;<i><asp:Label ID="lblOfficialName5" runat="server" Text="" CssClass="label"></asp:Label></i></td>
            </tr>
        </table>
        </ContentTemplate>
        </asp:UpdatePanel>
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
    <asp:Panel ID="panelStep2Collapsable" runat="server" CssClass="pnlCSS" Width="95%" Height="700px">
        <table>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblInstructionsStep2" runat="server" Text="" CssClass="panelInst">Select your experience from THIS SEASON (check all that apply)</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;<asp:CheckBox CssClass="checkbox" ID="cb6A" runat="server" Text="&nbsp;&nbsp;6A" />
                </td>
                <td>
                    &nbsp;&nbsp;<asp:CheckBox CssClass="checkbox" ID="cb2A" runat="server" Text="&nbsp;&nbsp;2A" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;<asp:CheckBox CssClass="checkbox" ID="cb5A" runat="server" Text="&nbsp;&nbsp;5A" />
                </td>
                <td>
                    &nbsp;&nbsp;<asp:CheckBox CssClass="checkbox" ID="cbA" runat="server" Text="&nbsp;&nbsp;A" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;<asp:CheckBox CssClass="checkbox" ID="cb4A" runat="server" Text="&nbsp;&nbsp;4A" />
                </td>
                <td>
                    &nbsp;&nbsp;<asp:CheckBox CssClass="checkbox" ID="cbB" runat="server" Text="&nbsp;&nbsp;B" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;<asp:CheckBox CssClass="checkbox" ID="cb3A" runat="server" Text="&nbsp;&nbsp;3A" />
                </td>
                <td>
                    &nbsp;&nbsp;<asp:CheckBox CssClass="checkbox" ID="cbC" runat="server" Text="&nbsp;&nbsp;C" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;&nbsp;<asp:CheckBox CssClass="checkbox" ID="cb8Man" runat="server" Text="&nbsp;&nbsp;Do you have 8-man experience (in the past 2 years)?" />
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
    <asp:Panel ID="panelStep3Collapsable" runat="server" CssClass="pnlCSS" Width="95%" Height="700px">
        <table width="75%" border="0">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblInstructionsStep3" runat="server" Text="" CssClass="panelInst">Check the days you WILL NOT be available</asp:Label>
                </td>
            </tr>
            <tr style="background-color:Silver;">
                <td>
                    <asp:Label ID="lblWeek1" runat="server" Text="Week #1 : " CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="cbWeek11" runat="server" Text="Thurs, Nov 13" CssClass="checkbox" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbWeek12" runat="server" Text="Fri, Nov 14" CssClass="checkbox" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbWeek13" runat="server" Text="Sat, Nov 15" CssClass="checkbox" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblWeek2" runat="server" Text="Week #2 : " CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="cbWeek21" runat="server" Text="Thurs, Nov 20" CssClass="checkbox" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbWeek22" runat="server" Text="Fri, Nov 21" CssClass="checkbox" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbWeek23" runat="server" Text="Sat, Nov 22" CssClass="checkbox" />
                </td>
            </tr>
            <tr style="background-color:Silver;">
                <td>
                    <asp:Label ID="lblWeek3" runat="server" Text="Week #3 : " CssClass="label"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbWeek31" runat="server" Text="Fri, Nov 28" CssClass="checkbox" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbWeek32" runat="server" Text="Sat, Nov 29" CssClass="checkbox" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblWeek4" runat="server" Text="Week #4 : " CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="cbWeek41" runat="server" Text="Thurs, Dec 4" CssClass="checkbox" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbWeek42" runat="server" Text="Fri, Dec 5" CssClass="checkbox" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbWeek43" runat="server" Text="Sat, Dec 6" CssClass="checkbox" />
                </td>
            </tr>
            <tr style="background-color:Silver;">
                <td>
                    <asp:Label ID="lblWeek5" runat="server" Text="Week #5 : " CssClass="label"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbWeek51" runat="server" Text="Fri, Dec 12" CssClass="checkbox" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbWeek52" runat="server" Text="Sat, Dec 13" CssClass="checkbox" />
                </td>
            </tr>
        </table>        

    </asp:Panel>
    </td>
</tr>
<tr id="trStep4">
    <td>
    <asp:Panel ID="panelStep4" runat="server" CssClass="pnlCSS" Width="100%">
        <div style="background-image:url('../images/black_bg.gif'); height:30px;">
        <div style="float:left; color:White; padding:5px 5px 0 0">&nbsp;&nbsp;</div>
        <div style="float:left; color:White; padding:5px 5px 0 0">
            <asp:Label ID="lblMessageStep4" runat="server" Text=""/>
            <asp:Image ID="imgArrowsStep4" runat="server" />
        </div>
        <div style="clear:both"></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="panelStep4Collapsable" runat="server" CssClass="pnlCSS" Width="95%" Height="700px">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblHomeTeam" runat="server" Text="&nbsp;Home Team :&nbsp;&nbsp;" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboHomeTeam" runat="server" DataTextField="strTeam" DataValueField="idTeam" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAwayTeam" runat="server" Text="&nbsp;Visiting Team :&nbsp;&nbsp;" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboAwayTeam" runat="server" DataTextField="strTeam" DataValueField="idTeam" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    </td>
</tr>
<tr id="trStep5">
    <td>
        <asp:Panel ID="panelStep5" runat="server" CssClass="pnlCSS" Width="100%">
        <div style="background-image:url('../images/black_bg.gif'); height:30px;">
        <div style="float:left; color:White; padding:5px 5px 0 0">&nbsp;&nbsp;</div>
        <div style="float:left; color:White; padding:5px 5px 0 0">
            <asp:Label ID="lblMessageStep5" runat="server" Text=""/>
            <asp:Image ID="imgArrowsStep5" runat="server" />
        </div>
        <div style="clear:both"></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="panelStep5Collapsable" runat="server" CssClass="pnlCSS" Width="95%" Height="700px">
        <table id="Step4">
            <tr>
                <td>
                    <asp:Label ID="lblTeamConflict1" runat="server" Text="&nbsp;Team Conflict #1 :&nbsp;&nbsp;" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboTeamConflict1" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="strTeam" DataValueField="idTeam" CssClass="dropdown" >
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
                        DataTextField="strTeam" DataValueField="idTeam" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>   
            <tr>
                <td>
                    <asp:Label ID="lblTeamConflict3" runat="server" Text="&nbsp;Team Conflict #3 :&nbsp;&nbsp;" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboTeamConflict3" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="strTeam" DataValueField="idTeam" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>  
            <tr>
                <td>
                    <asp:Label ID="lblTeamConflict4" runat="server" Text="&nbsp;Team Conflict #4 :&nbsp;&nbsp;" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboTeamConflict4" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="strTeam" DataValueField="idTeam" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>  
            <tr>
                <td>
                    <asp:Label ID="lblTeamConflict5" runat="server" Text="&nbsp;Team Conflict #5 :&nbsp;&nbsp;" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboTeamConflict5" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="strTeam" DataValueField="idTeam" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>         
        </table>                                               
    </asp:Panel>
    </td>
</tr>
<tr id="trSave2"><td><asp:Button ID="cmdSave2" runat="server" Text="Save Changes" CssClass="button" BackColor="Green" ForeColor="Yellow" Font-Bold="true" Font-Size="12pt" /></td></tr>
<ajax:CollapsiblePanelExtender
    ID="CollapsiblePanelExtenderStep1"
    runat="server"
    CollapseControlID="panelStep1"
    Collapsed="false"
    ExpandControlID="panelStep1"
    TextLabelID="lblMessageStep1"
    CollapsedText="Step 1 : Enter Your Crew for the Playoffs..."
    ExpandedText="Step 1 : Enter Your Crew for the Playoffs"
    ImageControlID="imgArrowsStep1"
    CollapsedImage="blank.gif"
    ExpandedImage="blank.gif"
    ExpandDirection="Vertical"
    TargetControlID="panelStep1Collapsable"
    ScrollContents="false">
</ajax:CollapsiblePanelExtender>
<ajax:CollapsiblePanelExtender
    ID="CollapsiblePanelExtenderStep3"
    runat="server"
    CollapseControlID="panelStep3"
    Collapsed="false"
    ExpandControlID="panelStep3"
    TextLabelID="lblMessageStep3"
    CollapsedText="Step 3 : Playoff Availability..."
    ExpandedText="Step 3 : Playoff Availability"
    ImageControlID="imgArrowsStep3"
    CollapsedImage="blank.gif"
    ExpandedImage="blank.gif"
    ExpandDirection="Vertical"
    TargetControlID="panelStep3Collapsable"
    ScrollContents="false">
</ajax:CollapsiblePanelExtender>
<ajax:CollapsiblePanelExtender
    ID="CollapsiblePanelExtenderStep2"
    runat="server"
    CollapseControlID="panelStep2"
    Collapsed="false"
    ExpandControlID="panelStep2"
    TextLabelID="lblMessageStep2"
    CollapsedText="Step 2 : Your Level of Officiating..."
    ExpandedText="Step 2 : Your Level of Officiating"
    ImageControlID="imgArrowsStep2"
    CollapsedImage="blank.gif"
    ExpandedImage="blank.gif"
    ExpandDirection="Vertical"
    TargetControlID="panelStep2Collapsable"
    ScrollContents="false">
</ajax:CollapsiblePanelExtender>
<ajax:CollapsiblePanelExtender
    ID="CollapsiblePanelExtenderStep4"
    runat="server"
    CollapseControlID="panelStep4"
    Collapsed="false"
    ExpandControlID="panelStep4"
    TextLabelID="lblMessageStep4"
    CollapsedText="Step 4 : Game #10 Game..."
    ExpandedText="Step 4 : Game #10 Game"
    ImageControlID="imgArrowsStep4"
    CollapsedImage="blank.gif"
    ExpandedImage="blank.gif"
    ExpandDirection="Vertical"
    TargetControlID="panelStep4Collapsable"
    ScrollContents="false">
</ajax:CollapsiblePanelExtender>
<ajax:CollapsiblePanelExtender
    ID="CollapsiblePanelExtenderStep5"
    runat="server"
    CollapseControlID="panelStep5"
    Collapsed="false"
    ExpandControlID="panelStep5"
    TextLabelID="lblMessageStep5"
    CollapsedText="Step 5 : School Conflicts..."
    ExpandedText="Step 5 : School Conflicts"
    ImageControlID="imgArrowsStep5"
    CollapsedImage="blank.gif"
    ExpandedImage="blank.gif"
    ExpandDirection="Vertical"
    TargetControlID="panelStep5Collapsable"
    ScrollContents="false">
</ajax:CollapsiblePanelExtender>
</table>  
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT [schoolID] AS idTeam, [SchoolDisplay] AS strTeam FROM qryTeamsFootball ORDER BY [School]">
    </asp:SqlDataSource>  
</asp:Content>

