<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucScheduleAdd.ascx.vb" Inherits="OSSAARankings.ucScheduleAdd" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Infragistics4.Web.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link rel="stylesheet" type="text/css" href="mem.css">
<asp:UpdatePanel ID="UpdatePanelScheduleAdd" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="lblHeader" Radius="3" BorderColor="gray"></ajax:RoundedCornersExtender>
    <asp:Table runat="server" ID="tblHome" Width="100%">
        <asp:TableRow ID="rowHeader">
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblHeader" runat="server" CssClass="headerSmall" Height="24px" style="text-align:center;" Text="Edit / Add Game Schedule" Width="100%"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowButtons">
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="cmdCancel" runat="server" CssClass="button" Text="Cancel" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="cmdSaveChanges" runat="server" Text="SAVE CHANGES" CssClass="buttonSave" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="cmdDelete" runat="server" Text="DELETE" CssClass="buttonDelete" />
                <asp:Label ID="lblID" runat="server" ForeColor="Gray" Width="120px" Font-Names="Verdana" Font-Size="X-Small">&nbsp;</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowScoreH" Visible="true">
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblScoreMy" runat="server" CssClass="perInfoLabel" Width="62px">MY SCORE</asp:Label>
                <asp:Label ID="lblScoreTheirs" runat="server" CssClass="perInfoLabel" Width="75px">OPP SCORE</asp:Label>
                <asp:Label ID="lblStatus" runat="server" CssClass="perInfoLabel">STATUS</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowScore" Visible="true">
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox ID="txtScoreMy" runat="server" CssClass="score" Width="40px" ></asp:TextBox>
                <asp:Label ID="lblSpace1" runat="server" CssClass="perInfoLabel" Width="10px">&nbsp;</asp:Label>
                <asp:TextBox ID="txtScoreOpp" runat="server" CssClass="score" Width="40px" ></asp:TextBox>
                <asp:Label ID="lblSpace2" runat="server" CssClass="perInfoLabel" Width="20px">&nbsp;</asp:Label>
                <asp:DropDownList ID="cboStatus" runat="server" CssClass="DropDown" >
                    <asp:ListItem Selected="True">Select...</asp:ListItem>                                    
                    <asp:ListItem>Final</asp:ListItem>
                    <asp:ListItem>Final (OT/Ext)</asp:ListItem>
                    <asp:ListItem>Final (Ext Inn)</asp:ListItem>
                    <asp:ListItem>Rain Out</asp:ListItem>
                    <asp:ListItem>Suspended</asp:ListItem>
                    <asp:ListItem>Postponed</asp:ListItem>
                    <asp:ListItem>Canceled</asp:ListItem>
                    <asp:ListItem>Forfeit</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowPostGender">
            <asp:TableCell ColumnSpan="2">
                <asp:CheckBox ID="cbPostGender" runat="server" Visible="false" />&nbsp;<asp:Label ID="lblPostGender" style="vertical-align:middle;" runat="server" Font-Names="Verdana" Font-Size="14px" Font-Bold="true" Text="Post to Schedule?" Visible="false"></asp:Label>
                <asp:Label ID="lblMessage" runat="server" CssClass="labelMessage" ForeColor="Red" Font-Bold="True"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowGameType1">
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="Label2" runat="server" CssClass="perInfoLabel">TYPE<span style="color:Red;"> *</span></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowGameType2">
            <asp:TableCell ColumnSpan="2">
                <asp:DropDownList ID="cboGameType" runat="server" CssClass="DropDown" DataTextField="strDescription" DataValueField="strType" AutoPostBack="true" >              
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowGameDateLabel">
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblGameDate" runat="server" CssClass="perInfoLabel">GAME DATE (MM/DD/YYYY)<span style="color:Red;"> *</span></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowGameDate">
            <asp:TableCell ColumnSpan="2">
                <telerik:RadDatePicker ID="RadDatePicker1" runat="server" MinDate="8/1/2019" MaxDate="5/30/2020" Width="180px"></telerik:RadDatePicker>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowGameTimeLabel">
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblGameTime" runat="server" CssClass="perInfoLabel">START TIME<span style="color:Red;"> *</span></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowGameTime">
            <asp:TableCell ColumnSpan="2">
                <asp:DropDownList ID="cboGameTimeHour" runat="server" CssClass="DropDown">
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
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="cboGameTimeMinute" runat="server" CssClass="DropDown">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="cboGameAMPM" runat="server" CssClass="DropDown">
                    <asp:ListItem>PM</asp:ListItem>
                    <asp:ListItem>AM</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowTourney1" Visible="false">
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="Label1" runat="server" CssClass="perInfoLabel">SELECT TOURNAMENT (or)&nbsp;<a href="Home.aspx?sel=ScheduleEditT">Add New Tournament</a> <span style="color:Red;"> *</span></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowTourney2" Visible="false">
            <asp:TableCell ColumnSpan="2">
                <asp:DropDownList ID="cboTourneys" runat="server" CssClass="DropDown" >
                    <asp:ListItem Selected="True">Select...</asp:ListItem>                                    
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowTourney3" Visible="false">
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="Label3" runat="server" CssClass="perInfoLabel">TOURNAMENT NAME / LOCATION</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowTourney4" Visible="false">
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox ID="txtTournament" runat="server" CssClass="perInfoText" Width="200px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowSite">
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblSite" runat="server" CssClass="perInfoLabel">SITE<span style="color:Red;"> *</span></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowGameLocation">
            <asp:TableCell ColumnSpan="2">
                <asp:DropDownList ID="cboGameLocation" runat="server" CssClass="DropDown" >
                    <asp:ListItem Selected="True">Select...</asp:ListItem>                                    
                    <asp:ListItem>Home</asp:ListItem>
                    <asp:ListItem>Away</asp:ListItem>
                    <asp:ListItem>Neutral</asp:ListItem>
                    <asp:ListItem>Scrimmage (H)</asp:ListItem>
                    <asp:ListItem>Scrimmage (A)</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowSchools1">
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblOSSAATeam" runat="server" CssClass="perInfoLabel" Text="OPPOSING OSSAA TEAM"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowSchools2">
            <asp:TableCell ColumnSpan="2">
                <asp:DropDownList ID="cboSchools" runat="server" CssClass="DropDown" AutoPostBack="true">
                    <asp:ListItem>Select School...</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowSchools3">
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblNonOSSAATeam" runat="server" CssClass="perInfoLabel" Text="or NON-OSSAA TEAM (or TBA)"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowSchools4">
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox ID="txtSchool" runat="server" CssClass="perInfoText" Width="175px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowResults1" Visible="false">
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblResults" runat="server" CssClass="perInfoLabel" Text="RESULTS"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowResults2" Visible="false">
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox ID="txtResults" runat="server" CssClass="perInfoText" Width="90%" TextMode="MultiLine" Rows="5"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowPitchers" Visible="false">
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblPitchCounts" runat="server" CssClass="perInfoLabel">ENTER PITCH COUNT(S)</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowPitcher1" Visible="false">
            <asp:TableCell ColumnSpan="2">
                <asp:DropDownList ID="DropDownListPitchers1" runat="server" CssClass="DropDown" DataTextField="PlayerName" DataValueField="rosterID" Width="200px" >
                </asp:DropDownList>&nbsp;
                <asp:TextBox ID="txtPitchCount1" runat="server" CssClass="perInfoText" Width="30px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowPitcher2" Visible="false">
            <asp:TableCell ColumnSpan="2">
                <asp:DropDownList ID="DropDownListPitchers2" runat="server" CssClass="DropDown" DataTextField="PlayerName" DataValueField="rosterID" Width="200px" >
                </asp:DropDownList>&nbsp;
                <asp:TextBox ID="txtPitchCount2" runat="server" CssClass="perInfoText" Width="30px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowPitcher3" Visible="false">
            <asp:TableCell ColumnSpan="2">
                <asp:DropDownList ID="DropDownListPitchers3" runat="server" CssClass="DropDown" DataTextField="PlayerName" DataValueField="rosterID" Width="200px" >
                </asp:DropDownList>&nbsp;
                <asp:TextBox ID="txtPitchCount3" runat="server" CssClass="perInfoText" Width="30px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowPitcher4" Visible="false">
            <asp:TableCell ColumnSpan="2">
                <asp:DropDownList ID="DropDownListPitchers4" runat="server" CssClass="DropDown" DataTextField="PlayerName" DataValueField="rosterID" Width="200px" >
                </asp:DropDownList>&nbsp;
                <asp:TextBox ID="txtPitchCount4" runat="server" CssClass="perInfoText" Width="30px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowPitcher5" Visible="false">
            <asp:TableCell ColumnSpan="2">
                <asp:DropDownList ID="DropDownListPitchers5" runat="server" CssClass="DropDown" DataTextField="PlayerName" DataValueField="rosterID" Width="200px" >
                    </asp:DropDownList>&nbsp;
                <asp:TextBox ID="txtPitchCount5" runat="server" CssClass="perInfoText" Width="30px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowPitcher6" Visible="false">
            <asp:TableCell ColumnSpan="2">
                <asp:DropDownList ID="DropDownListPitchers6" runat="server" CssClass="DropDown" DataTextField="PlayerName" DataValueField="rosterID" Width="200px" >
                    </asp:DropDownList>&nbsp;
                <asp:TextBox ID="txtPitchCount6" runat="server" CssClass="perInfoText" Width="30px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowPitcher7" Visible="false">
            <asp:TableCell ColumnSpan="2">
                <asp:DropDownList ID="DropDownListPitchers7" runat="server" CssClass="DropDown" DataTextField="PlayerName" DataValueField="rosterID" Width="200px" >
                    </asp:DropDownList>&nbsp;
                <asp:TextBox ID="txtPitchCount7" runat="server" CssClass="perInfoText" Width="30px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowScheduleID">
            <asp:TableCell ColumnSpan="2">
                <asp:HiddenField ID="txtSchduleID" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowGame">
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox ID="intGame" runat="server" CssClass="perInfoText"  Width="5px" Enabled="false" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
    </asp:Table>
</ContentTemplate>
</asp:UpdatePanel>


