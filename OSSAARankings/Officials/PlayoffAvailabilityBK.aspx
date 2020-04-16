<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="PlayoffAvailabilityBK.aspx.vb" Inherits="OSSAARankings.PlayoffAvailabilityBK" %>
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
<tr id="PageTitle" style="background-image:url('../images/red_bg.gif'); height:30px;"><td><asp:Label ID="lblPageHeader" runat="server" Text="&nbsp;&nbsp;OFFICIALS BASKETBALL PLAYOFF AVAILABILITY" style="font-family:Arial; font-size:16px; font-weight:bold; background-image:url('../images/red_bg.gif'); color:Yellow;"></asp:Label></td></tr>
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
                    <asp:Label ID="lblInstructionsStep1" runat="server" Text="" CssClass="panelInst">Select your Regular Season Experience from THIS SEASON</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="cboExperienceThisSeason" runat="server" CssClass="dropdown">
                        <asp:ListItem Selected="True">Select...</asp:ListItem>
                        <asp:ListItem >None</asp:ListItem>
                        <asp:ListItem>3-Man Only</asp:ListItem>
                        <asp:ListItem>A/B and 3-Man</asp:ListItem>
                        <asp:ListItem>2A through 6A</asp:ListItem>
                        <asp:ListItem>B through 4A</asp:ListItem>
                        <asp:ListItem>A/B Only</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblInstructionsStep11a" runat="server" Text="" CssClass="panelInst">I would prefer to work</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="cboPreferToWork" runat="server" CssClass="dropdown">
                        <asp:ListItem Selected="True">Select...</asp:ListItem>
                        <asp:ListItem>A/B</asp:ListItem>
                        <asp:ListItem>2A through 4A</asp:ListItem>
                        <asp:ListItem>5A/6A</asp:ListItem>
                        <asp:ListItem>2-Man Only</asp:ListItem>
                        <asp:ListItem>2-Man & 3-Man</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblInstructionsStep1a" runat="server" Text="" CssClass="panelInst">Number of 3 PERSON High School Dates worked THIS SEASON</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="cboHSGames" runat="server" CssClass="dropdown">
                        <asp:ListItem Selected="True">Select...</asp:ListItem>
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20 plus</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblInstructionsStep1b" runat="server" Text="" CssClass="panelInst">Jr College/College Basketball THIS SEASON</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="cboCollegeExp" runat="server" CssClass="dropdown">
                        <asp:ListItem Selected="True">Select...</asp:ListItem>
                        <asp:ListItem>None</asp:ListItem>
                        <asp:ListItem>MEN only</asp:ListItem>
                        <asp:ListItem>WOMEN only</asp:ListItem>
                        <asp:ListItem>BOTH</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="" CssClass="panelInst">I would be able to work an afternoon session AND evening session on the same day if needed</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="cboDayNight" runat="server" CssClass="dropdown">
                        <asp:ListItem Selected="True">Select...</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="" CssClass="panelInst">Level of play you worked LAST PLAYOFF SEASON (<u>check all that apply</u>)</asp:Label>
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
                    &nbsp;&nbsp;<asp:CheckBox CssClass="checkbox" ID="cbLevel4" runat="server" Text="&nbsp;&nbsp;Area" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;<asp:CheckBox CssClass="checkbox" ID="cbLevel5" runat="server" Text="&nbsp;&nbsp;State" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPartners" runat="server" Text="" CssClass="panelInst">List no more than 3 regular season partners (not required)</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="txtPartners" Text="" MaxLength="100" Width="600px"></asp:TextBox>
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
        <table width="75%" border="0">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblInstructionsStep2" runat="server" Text="" CssClass="panelInst">Check the days you WILL be available</asp:Label>
                </td>
            </tr>
            <tr style="background-color:Gray;">
                <td colspan="2">
                    <asp:Label ID="lblHeaderW1" runat="server" Text="&nbsp;Week #1 : A/B DISTRICT" CssClass="label" ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr style="background-color:Silver;">
                <td width="110px">
                    <asp:Label ID="lblSessionW1D1" runat="server" Text="&nbsp;Day 1 : Feb 13 : " CssClass="label" ></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSessionW1D1" runat="server" CssClass="dropdown" >
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="3">Both Sessions</asp:ListItem>
                    <asp:ListItem Value="2">Evening Only</asp:ListItem>
                    <asp:ListItem Value="1">Afternoon Only</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="110px">
                    <asp:Label ID="lblSessionW1D2" runat="server" Text="&nbsp;Day 2 : Feb 14 : " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSessionW1D2" runat="server" CssClass="dropdown" >
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="3">Both Sessions</asp:ListItem>
                    <asp:ListItem Value="2">Evening Only</asp:ListItem>
                    <asp:ListItem Value="1">Afternoon Only</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr style="background-color:Gray;">
                <td colspan="2">
                    <asp:Label ID="lblHeaderW2" runat="server" Text="&nbsp;Week #2 : 2A-4A DISTRICT & A-B REGIONAL" CssClass="label" ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr style="background-color:Silver;">
                <td width="110px">
                    <asp:Label ID="lblSessionW2D1" runat="server" Text="&nbsp;Day 1 : Feb 19 : " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSessionW2D1" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="3">Both Sessions</asp:ListItem>
                    <asp:ListItem Value="2">Evening Only</asp:ListItem>
                    <asp:ListItem Value="1">Afternoon Only</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="110px">
                    <asp:Label ID="lblSessionW2D2" runat="server" Text="&nbsp;Day 2 : Feb 20 : " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSessionW2D2" runat="server" CssClass="dropdown" >
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="3">Both Sessions</asp:ListItem>
                    <asp:ListItem Value="2">Evening Only</asp:ListItem>
                    <asp:ListItem Value="1">Afternoon Only</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="110px">
                    <asp:Label ID="lblSessionW2D3" runat="server" Text="&nbsp;Day 3 : Feb 21 : " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSessionW2D3" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="3">Both Sessions</asp:ListItem>
                    <asp:ListItem Value="2">Evening Only</asp:ListItem>
                    <asp:ListItem Value="1">Afternoon Only</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr style="background-color:Gray;">
                <td colspan="2">
                    <asp:Label ID="lblHeaderW3" runat="server" Text="&nbsp;Week #3 : 2A-6A REGIONAL & A-B AREA" CssClass="label" ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr style="background-color:Silver;">
                <td width="110px">
                    <asp:Label ID="lblSessionW3D1" runat="server" Text="&nbsp;Day 1 : Feb 26 : " CssClass="label"></asp:Label>
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
                    <asp:Label ID="lblSessionW3D2" runat="server" Text="&nbsp;Day 2 : Feb 27 : " CssClass="label"></asp:Label>
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
            <tr>
                <td width="110px">
                    <asp:Label ID="lblSessionW3D3" runat="server" Text="&nbsp;Day 3 : Feb 28 : " CssClass="label"></asp:Label>
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
            <tr style="background-color:Gray;">
                <td colspan="2">
                    <asp:Label ID="lblHeaderW4" runat="server" Text="&nbsp;Week #4 : 2A-6A AREA & A-B STATE" CssClass="label" ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr style="background-color:Silver;">
                <td width="110px">
                    <asp:Label ID="lblSessionW4D1" runat="server" Text="&nbsp;Day 1 : Mar 5 : " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSessionW4D1" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="3">Both Sessions</asp:ListItem>
                    <asp:ListItem Value="2">Evening Only</asp:ListItem>
                    <asp:ListItem Value="1">Afternoon Only</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="110px">
                    <asp:Label ID="lblSessionW4D2" runat="server" Text="&nbsp;Day 2 : Mar 6 : " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSessionW4D2" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="3">Both Sessions</asp:ListItem>
                    <asp:ListItem Value="2">Evening Only</asp:ListItem>
                    <asp:ListItem Value="1">Afternoon Only</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="110px">
                    <asp:Label ID="lblSessionW4D3" runat="server" Text="&nbsp;Day 3 : Mar 7 : " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSessionW4D3" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="3">Both Sessions</asp:ListItem>
                    <asp:ListItem Value="2">Evening Only</asp:ListItem>
                    <asp:ListItem Value="1">Afternoon Only</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr style="background-color:Gray;">
                <td colspan="2">
                    <asp:Label ID="lblHeaderW5" runat="server" Text="&nbsp;Week #5 : 2A-6A State" CssClass="label" ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr style="background-color:Silver;">
                <td width="110px">
                    <asp:Label ID="lblSessionW5D1" runat="server" Text="&nbsp;Day 1 : Mar 12 : " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSessionW5D1" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="3">Both Sessions</asp:ListItem>
                    <asp:ListItem Value="2">Evening Only</asp:ListItem>
                    <asp:ListItem Value="1">Afternoon Only</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="110px">
                    <asp:Label ID="lblSessionW5D2" runat="server" Text="&nbsp;Day 2 : Mar 13 : " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSessionW5D2" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="3">Both Sessions</asp:ListItem>
                    <asp:ListItem Value="2">Evening Only</asp:ListItem>
                    <asp:ListItem Value="1">Afternoon Only</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="110px">
                    <asp:Label ID="lblSessionW5D3" runat="server" Text="&nbsp;Day 3 : Mar 14 : " CssClass="label"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="cboSessionW5D3" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">Not Available</asp:ListItem>
                    <asp:ListItem Value="3">Both Sessions</asp:ListItem>
                    <asp:ListItem Value="2">Evening Only</asp:ListItem>
                    <asp:ListItem Value="1">Afternoon Only</asp:ListItem>
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
                    <asp:Label ID="lblInstructionsStep3" runat="server" Text="" CssClass="panelInst" Font-Size="Small">A conflict with a school would be defined on two levels:  <br />1) A conflict of interests (being an alumni of school, having a relative that works for the school, having a relative that attends the school or having a school that is a business client, etc.) <strong><i></i>IF YOU THINK YOU MIGHT HAVE A CONFLICT; YOU HAVE A CONFLICT.</u></strong>  <br />2)  A team/coach conflict as in a problem with a basketball coach or basketball team in the past.</asp:Label>
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
<tr id="trSave2"><td><asp:Button ID="cmdSave2" runat="server" Text="Save Changes" CssClass="button"  BackColor="Lime" Font-Bold="true"/></td></tr>
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
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT [schoolID], [SchoolName] FROM [qryBasketballTeams] ORDER BY SchoolName">
    </asp:SqlDataSource>  
</asp:Content>
