<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="OfficialEdit.ascx.vb" Inherits="OSSAARankings.OfficialEdit" %>
<%@ Register Assembly="Infragistics4.WebUI.WebDateChooser.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanelOfficialsEdit" runat="server">
    <ProgressTemplate   >            
        <div style="position:absolute; top:150px;left:100px;">
            <img alt="progress" src="../images/ajax-loader1.gif"/><span style="font-family: Verdana; font-size:10px;">Processing...</span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanelOfficialsEdit" runat="server" UpdateMode="Always">
<ContentTemplate>
<table id="editOfficial" width="990px">
    <tr>
        <td colspan="3">
            <asp:Button ID="cmdAddNew" runat="server" Text="Add New" CssClass="button" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="cmdEditWeek" runat="server" Text="Edit Week" CssClass="button" />&nbsp;&nbsp;
            <asp:DropDownList CssClass="dropdown" ID="cboWeek" runat="server" DataSourceID="SqlDataSource5" DataTextField="Teams" DataValueField="Id"></asp:DropDownList>
        </td>
        <td align="right"><asp:Button ID="cmdSave" runat="server" Text="Save Changes" CssClass="buttonSave" /></td>
    </tr>
    <tr><td colspan="4" style="background-color:Yellow;"><asp:Label ID="lblMessage" CssClass="label" runat="server" Text="" style="color:Red; font-weight:bold; font-size:14pt;"></asp:Label></td></tr>
    <tr><td colspan="4"><hr /></td></tr>
    <tr><td colspan="4"><asp:Label ID="lblHeader" Width="100%" CssClass="shadedheader" runat="server" style="text-align:center;" Text="2017 OSSAA GAME REPORT FOR VARSITY GAMES"></asp:Label></td></tr>
    <tr><td colspan="2">
        <asp:Label ID="Label1" runat="server" Text="Week # : " CssClass="label"></asp:Label><br />
        <asp:DropDownList ID="cboWeekNew" runat="server" CssClass="dropdown" 
            DataSourceID="SqlDataSource7" DataTextField="strDescription" 
            DataValueField="intKey">
        </asp:DropDownList>
        <asp:TextBox ID="txtWeek" runat="server" Width="40px" Visible="false" Enabled="false" CssClass="textbox"></asp:TextBox>
        <asp:TextBox ID="txtKey" runat="server" Width="40px" Visible="false" Enabled="false" CssClass="textbox"></asp:TextBox>
    
        <span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span>
        </td>
        <td width="100px">
        <asp:Label ID="Label2" runat="server" Text="Game Date : " CssClass="label"></asp:Label><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span>
            <igsch:WebDateChooser ID="datGame" runat="server" CssClass="dropdown"></igsch:WebDateChooser>
        </td>
        <td>
            &nbsp;</td></tr>
    <tr><td colspan="2">
    <asp:Label ID="Label3" runat="server" Text="Select OSSAA Home Team : " CssClass="label"></asp:Label><br />
        <asp:DropDownList ID="cboHomeTeam" runat="server" DataSourceID="SqlDataSource6" 
            DataTextField="SchoolName" DataValueField="schoolID" CssClass="dropdown"></asp:DropDownList><br />
            <asp:Label ID="Label21" runat="server" Text="Or NON-OSSAA Home Team " CssClass="label"></asp:Label><br />
            <asp:TextBox ID="txtOtherHomeTeam" runat="server" Width="60%" CssClass="textbox"></asp:TextBox>
    </td>
    <td colspan="2">
    <asp:Label ID="Label4" runat="server" Text="Select OSSAA Visiting Team : " CssClass="label"></asp:Label><br />
        <asp:DropDownList ID="cboAwayTeam" runat="server" DataSourceID="SqlDataSource6" 
            DataTextField="SchoolName" DataValueField="schoolID" CssClass="dropdown"></asp:DropDownList><br />
            <asp:Label ID="Label22" runat="server" Text="Or NON-OSSAA Visiting Team " CssClass="label"></asp:Label><br />
            <asp:TextBox ID="txtOtherAwayTeam" runat="server" Width="60%" CssClass="textbox"></asp:TextBox>
    </td>
    </tr>
    <tr><td colspan="4"><asp:Label ID="Label5" runat="server" Text="Location (if different than home team) : " CssClass="label"></asp:Label><br /><asp:TextBox ID="txtLocation" runat="server" Width="50%" CssClass="textbox"></asp:TextBox></td></tr>
    <tr><td colspan="4"><hr /></td></tr>
    <tr><td colspan="4"><asp:Label ID="Label6" runat="server" Text="Field cleared and ready to start on time : " CssClass="label"></asp:Label><asp:DropDownList ID="cboFieldCleared" runat="server" CssClass="dropdown">
        <asp:ListItem Value="NONE">Select...</asp:ListItem>
        <asp:ListItem>YES</asp:ListItem>
        <asp:ListItem>NO</asp:ListItem>
        </asp:DropDownList><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span>
    </td></tr>
    <tr><td colspan="4"><asp:Label ID="Label7" runat="server" Text="Halftime Length: " CssClass="label"></asp:Label><asp:DropDownList ID="cboHalftimeLength" runat="server" CssClass="dropdown">
        <asp:ListItem Value="0">Select...</asp:ListItem>
        <asp:ListItem Value="10">10 min</asp:ListItem>
        <asp:ListItem Value="15">15 min</asp:ListItem>
        <asp:ListItem Value="20">20 min</asp:ListItem>
        </asp:DropDownList><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span>
    </td></tr>
    <tr><td colspan="2" style="margin-left: 40px" ><asp:Label ID="Label8" runat="server" Text="Home Team Ready for Start of Game/Halftime? " CssClass="label"></asp:Label><asp:DropDownList ID="cboHomeTeamReady" runat="server" CssClass="dropdown">
        <asp:ListItem Value="NONE">Select...</asp:ListItem>
        <asp:ListItem>YES</asp:ListItem>
        <asp:ListItem>NO</asp:ListItem>
        </asp:DropDownList><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span>
    </td>
    <td colspan="2"><asp:Label ID="Label9" runat="server" Text="Visiting Team Ready? " CssClass="label"></asp:Label><asp:DropDownList ID="cboAwayTeamReady" runat="server" CssClass="dropdown">
        <asp:ListItem Value="NONE">Select...</asp:ListItem>
        <asp:ListItem>YES</asp:ListItem>
        <asp:ListItem>NO</asp:ListItem>
        </asp:DropDownList><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span>
    </td></tr>
    <tr><td colspan="4"><asp:Label ID="Label10" runat="server" Text="Sideline Problems : " CssClass="label" style="vertical-align:top;" width="200px"></asp:Label>
        <asp:TextBox ID="txtSideLineProblems" Rows="3" TextMode="MultiLine" 
            runat="server" Width="740px" CssClass="textbox"></asp:TextBox></td></tr>
    <tr><td colspan="4"><hr /></td></tr>
    <tr><td colspan="4"><asp:Label ID="Label11" runat="server" Text="Any ejections? : " CssClass="label"></asp:Label><asp:DropDownList ID="cboEjections" runat="server" CssClass="dropdown">
        <asp:ListItem Value="NONE">Select...</asp:ListItem>
        <asp:ListItem>YES</asp:ListItem>
        <asp:ListItem>NO</asp:ListItem>
        </asp:DropDownList><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span>
        &nbsp;&nbsp;<asp:Label ID="lblMessage1" CssClass="label" runat="server" Text="Ejections need to be reported to OSSAA within 24 hours of game by email to ggower@ossaa.com" style="color:Maroon;"></asp:Label>
    </td></tr>
    <tr><td colspan="4"><asp:Label ID="Label12" runat="server" Text="Total number of Accepted Fouls Against :   Home : " CssClass="label"></asp:Label><asp:TextBox ID="txtTotalFoulsHome" runat="server" Width="45px" CssClass="textbox"></asp:TextBox><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span>
    <asp:Label ID="Label13" runat="server" Text="Visitor : " CssClass="label"></asp:Label><asp:TextBox ID="txtTotalFoulsAway" runat="server" Width="45px" CssClass="textbox"></asp:TextBox><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span>
    </td></tr>
    <tr><td colspan="4"><asp:Label ID="Label14" runat="server" Text="Total number of Unsportsmanlike Fouls Against :   Home : " CssClass="label"></asp:Label><asp:TextBox ID="txtTotalUnFoulsHome" runat="server" Width="45px" CssClass="textbox"></asp:TextBox><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span>
    <asp:Label ID="Label15" runat="server" Text="Visitor : " CssClass="label"></asp:Label><asp:TextBox ID="txtTotalUnFoulsAway" runat="server" Width="45px" CssClass="textbox"></asp:TextBox><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span>
    </td></tr>
    <tr><td colspan="4"><hr /></td></tr>
    <tr><td colspan="4"><asp:Label ID="Label17" CssClass="label" runat="server" Text="1 being the lowest and needs improvement to 5 being the best no improvement needed." style="color:Maroon;"></asp:Label></td></tr>
    <tr><td colspan="4"><asp:Label ID="Label16" runat="server" Text="How would you rate your experience with the school FACILITY? " CssClass="label"></asp:Label><asp:DropDownList ID="cboExperienceFacility" runat="server" CssClass="dropdown">
        <asp:ListItem Value="0">Select...</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span>
    </td></tr>
    <tr><td colspan="4"><asp:Label ID="Label18" runat="server" Text="How would you rate your experience with the HOME team coach/team? " CssClass="label"></asp:Label><asp:DropDownList ID="cboExperienceHomeTeam" runat="server" CssClass="dropdown">
        <asp:ListItem Value="0">Select...</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span>
    </td></tr>
    <tr><td colspan="4"><asp:Label ID="Label19" runat="server" Text="How would you rate your experience with the VISITORS team coach/team? " CssClass="label"></asp:Label><asp:DropDownList ID="cboExperienceVisitorsTeam" runat="server" CssClass="dropdown">
        <asp:ListItem Value="0">Select...</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span>
    </td></tr>
    <tr><td colspan="4"><hr /></td></tr>
    <tr><td colspan="4"><asp:Label ID="Label20" runat="server" Text="Additional Comments : " CssClass="label" style="vertical-align:top;" width="200px"></asp:Label>
        <asp:TextBox ID="strAdditionalComments" Rows="5" TextMode="MultiLine" 
            runat="server" Width="740px" CssClass="dropdown"></asp:TextBox></td></tr>
<tr><td colspan="4"><hr /></td></tr>
<tr><td colspan="4">
    <table>
        <tr>
            <td width="195px">&nbsp;</td>
            <td width="150px" style="background-color:Gray;"><asp:Label ID="Label25" runat="server" Text="&nbsp;Crew Information" CssClass="shadedheader"></asp:Label></td>
            <td width="200px" style="background-color:Gray;">
                <asp:Label ID="Label24" runat="server" Text="OSSAA ID" CssClass="shadedheader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><asp:Label ID="lblCrew1" runat="server" Text="Crew Member (R) :" CssClass="label"></asp:Label></td>
            <td><asp:TextBox ID="txtCrew1" runat="server" CssClass="textbox"></asp:TextBox><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span></td>
        </tr>         
        <tr>
            <td>&nbsp;</td>
            <td><asp:Label ID="lblCrew2" runat="server" Text="Crew Member (U) :" CssClass="label"></asp:Label></td>
            <td><asp:TextBox ID="txtCrew2" runat="server" CssClass="textbox"></asp:TextBox><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><asp:Label ID="lblCrew3" runat="server" Text="Crew Member (LJ) :" CssClass="label"></asp:Label></td>
            <td><asp:TextBox ID="txtCrew3" runat="server" CssClass="textbox"></asp:TextBox><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><asp:Label ID="lblCrew4" runat="server" Text="Crew Member (BJ) :" CssClass="label"></asp:Label></td>
            <td><asp:TextBox ID="txtCrew4" runat="server" CssClass="textbox"></asp:TextBox><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span></td>
        </tr>       
        <tr>
            <td>&nbsp;</td>
            <td><asp:Label ID="lblCrew5" runat="server" Text="Crew Member (HL) :" CssClass="label"></asp:Label></td>
            <td><asp:TextBox ID="txtCrew5" runat="server" CssClass="textbox"></asp:TextBox><span style="color: Red; font-size:12pt; font-weight:bold;">&nbsp;*</span></td>
        </tr>                           
               
    </table>

</td></tr>
<tr><td colspan="4"><asp:Label ID="Label23" CssClass="label" runat="server" Text="Click Save to Keep Your Changes..." style="color:Red; font-weight:bold; font-size:14pt;"></asp:Label>&nbsp;&nbsp;<asp:Button ID="cmdSave1" runat="server" Text="Save Changes" CssClass="buttonSave" /></td></tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>

    <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT [id], [intKey], 'Week #' + CONVERT(varchar, [intWeek]) + ' : ' + [strTeamHome] + '/' + [strTeamAway] As Teams, [intWhiteHatOSSAAID] FROM [tblOfficialsReportsFootball] WHERE ([intWhiteHatOSSAAID] = @OSSAAID OR [strWhiteHatName] = 'None') AND intYear = @year ORDER BY [intWeek]" >
        <SelectParameters>
            <asp:SessionParameter Name="OSSAAID" SessionField="OSSAAID" />
            <asp:SessionParameter Name="year" SessionField="gYear" />
        </SelectParameters>
    </asp:SqlDataSource>

<asp:SqlDataSource ID="SqlDataSource6" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
    SelectCommand="SELECT [schoolID], [SchoolName] FROM [tblSchool] WHERE OrganizationType = 'SCHOOL' OR OrganizationType = 'SELECT' ORDER BY [SchoolName]"></asp:SqlDataSource>

<asp:SqlDataSource ID="SqlDataSource7" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
    SelectCommand="SELECT [intKey], [strDescription] FROM [tblOfficialsWeeksFootball] WHERE intActive <> 0 AND intKey <> ALL (SELECT intKey FROM tblOfficialsReportsFootball WHERE intWhiteHatOSSAAID=@intWhiteHatOSSAAID AND intYear = @year)">
    <SelectParameters>
        <asp:SessionParameter Name="intWhiteHatOSSAAID" SessionField="OSSAAID" Type="Int32" />
        <asp:Parameter DefaultValue="2" Name="Id" Type="Int32" />
        <asp:SessionParameter Name="year" SessionField="gYear" />
    </SelectParameters>
</asp:SqlDataSource>

