<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RankingsOthers.aspx.vb" Inherits="OSSAARankings.RankingsOthers" ClientTarget="uplevel"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="mem.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title>OSSAARankings.com : Others Rankings</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="panelRankingsOthers">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Panel ID="PanelHome" runat="server" CssClass="panelHome">
        <asp:UpdateProgress ID="updProgress1" AssociatedUpdatePanelID="UpdatePanelHome" runat="server" ViewStateMode="Enabled">
            <ProgressTemplate>  
                <div style="position:absolute; top:250px;left:250px;">
                    <img alt="Loading..." src="../images/ajax-loader1.gif" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanelHome" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                    <asp:Table ID="TableHome" runat="server" Width="100%">
                        <asp:TableRow BackColor="Maroon" VerticalAlign="Middle" Height="32"><asp:TableCell><asp:Label ID="lblHeader" runat="server" Text="&nbsp;OSSAARankings.com - Members" CssClass="memHeader" ForeColor="White" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow BackColor="Navy" VerticalAlign="Middle" Height="32"><asp:TableCell><asp:Label ID="Label2" runat="server" Text="&nbsp;Select 'Enter Rankings' from the dropdown below to submit your rankings." CssClass="memHeader" ForeColor="Yellow" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell>
                        <asp:DropDownList ID="cboSports" runat="server" AutoPostBack="True" Font-Names="Segoe UI, Helvetica, Helvetica Neue, Lucida Grande, Arial, Verdana, Sans-serif;" Width="200px" Font-Bold="true" Font-Size="18px" BackColor="OrangeRed" DataTextField="SportDisplay" DataValueField="teamID" style="border-style:solid;border-width:1px;">
                        </asp:DropDownList>
                        </asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell>
                            <asp:DropDownList ID="cboAction" runat="server" AutoPostBack="True" Font-Names="Segoe UI, Helvetica, Helvetica Neue, Lucida Grande, Arial, Verdana, Sans-serif;" Width="250px" Font-Bold="true" Font-Size="18px" BackColor="Orange" style="border-style:solid;border-width:1px;">
                                <asp:ListItem Value="">Select Option...</asp:ListItem>
                                <asp:ListItem Value="Schedule">Schedule</asp:ListItem>
                                <asp:ListItem Value="Roster">Roster</asp:ListItem>
                                <asp:ListItem Value="EnterRankings">Enter Rankings</asp:ListItem>
                                <asp:ListItem Value="EnterRankings1" Enabled="false">Enter Rankings (Dual)</asp:ListItem>
                                <asp:ListItem Value="EnterRankings8" Enabled="false">Enter Rankings (Dual-8)</asp:ListItem>
                                <asp:ListItem Value="EnterRankingsEW" Enabled="false">Enter Rankings (E-W)</asp:ListItem>
                                <asp:ListItem Value="PersonalInfo">Personal Info</asp:ListItem>
                                <asp:ListItem Value="MyDistrict">My District</asp:ListItem>
                                <asp:ListItem Value="RankingsSchedule">Rankings Schedule</asp:ListItem>
                                <asp:ListItem Value="RankingsOthers">Others Rankings</asp:ListItem>
                                <asp:ListItem Value="RankingsOthers1" Enabled="false">Others Rankings (Dual)</asp:ListItem>
                                <asp:ListItem Value="RankingsPrevious">Previous Rankings</asp:ListItem>
                                <asp:ListItem Value="RankingsPrevious1" Enabled="false">Previous Rankings (Dual)</asp:ListItem>
                                <asp:ListItem Value="PitchCount" Enabled="false">Pitch Count</asp:ListItem>
                                <asp:ListItem Value="SwimResults" Enabled="false">Swim Results</asp:ListItem>
                                <asp:ListItem Value="TeamUpdate" Enabled="false">My Team Update</asp:ListItem>
                                <asp:ListItem Value="TeamUpdateAll" Enabled="false">OTHER  Team Updates</asp:ListItem>
                                <asp:ListItem Value="ContactUs">Contact Us</asp:ListItem>
                                <asp:ListItem Value="Logout">Logout</asp:ListItem>
                                <asp:ListItem Value="MemberLoginLog" Enabled="false">Coaches Login Log</asp:ListItem>
                                <asp:ListItem Value="EntryForms" Enabled="true">On-Line Entry & Facility Forms</asp:ListItem>
                                <asp:ListItem Value="Assigners" Enabled="true">Assigners</asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:Label ID="lblCoach" runat="server" Text="" CssClass="infoCoach" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:Label ID="lblSchool" runat="server" Text="" CssClass="infoSchool" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:Label ID="lblSport" runat="server" Text="" CssClass="infoSport" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Table runat="server" ID="tblRO1">
                                    <asp:TableRow>
                                        <asp:TableCell ColumnSpan="2">
                                            <asp:TableRow><asp:TableCell><asp:Label ID="Label1" runat="server" Text="OTHER COACHES RANKINGS (for your class)" CssClass="infoSchool" ></asp:Label></asp:TableCell></asp:TableRow>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell ColumnSpan="2">
                                            <asp:Label ID="lblMessage" runat="server" Text="This weeks rankings are available for view after the rankings are released.<br>Only the teams that submitted rankings for the selected week will be listed." CssClass="labelMessage" Font-Bold="true"></asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell><asp:Label ID="lblSelectWeek" runat="server" Text="Select Week :&nbsp;&nbsp;" CssClass="rankingsLabel"></asp:Label></asp:TableCell>
                                        <asp:TableCell><asp:DropDownList runat="server" ID="cboSelectWeek" CssClass="rankingsDropdown" DataValueField="wID" DataTextField="strDisplay" BackColor="LightGreen" Font-Bold="true" AutoPostBack="true"></asp:DropDownList></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell><asp:Label ID="lblSelectSchool" runat="server" Text="Select School :&nbsp;&nbsp;" CssClass="rankingsLabel"></asp:Label></asp:TableCell>
                                        <asp:TableCell><asp:DropDownList runat="server" ID="cboSelectSchool" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" BackColor="LightGreen" Font-Bold="true"></asp:DropDownList>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell>&nbsp;</asp:TableCell>
                                        <asp:TableCell><asp:Button runat="server" Text="Load Rankings" cssclass="buttonSave" id="cmdGo" ></asp:Button></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell ColumnSpan="2">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SQLDataSource1"
                                                CaptionAlign="Left" CellPadding="4" 
                                                Font-Names="Verdana" Font-Size="8pt" 
                                                UseAccessibleHeader="False" Width="320px"
                                                EmptyDataText="No Rankings Submitted" ForeColor="#333333" GridLines="Both"
                                                BorderColor="#CC9966" BorderStyle="None" BorderWidth="1pt">
                                                <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="Rank" HeaderText="Rank">
                                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="School" HeaderText="School" >
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="WL" HeaderText="W-L" />
                                                </Columns>
                                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                                <SortedDescendingHeaderStyle BackColor="#820000" />
                                            </asp:GridView>                                        
                                        </asp:TableCell>
                                    </asp:TableRow>
                                   <asp:TableRow>
                                        <asp:TableCell ColumnSpan="2">
                                            <br />
                                            <asp:Label ID="lblHeader2" runat="server" Text="E/W Split Rankings" CssClass="infoRankings" Visible="false"></asp:Label><br />
                                              <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SQLDataSource2"
                                                CaptionAlign="Left" CellPadding="4" 
                                                Font-Names="Verdana" Font-Size="8pt" 
                                                UseAccessibleHeader="False" Width="320px"
                                                EmptyDataText="No Rankings Available" ForeColor="#333333" GridLines="Both"
                                                BorderColor="#CC9966" BorderStyle="None" BorderWidth="1pt">
                                                <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="Rank" HeaderText="Rank">
                                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="School" HeaderText="School" >
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="WL" HeaderText="W-L" />
                                                </Columns>
                                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                                <SortedDescendingHeaderStyle BackColor="#820000" />
                                            </asp:GridView>                                        
                                        </asp:TableCell>
                                    </asp:TableRow>
                                 </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cboAction" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        </asp:Panel>
    </div>
<asp:SqlDataSource runat="server" ID="SQLDataSource1" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
    SelectCommand="SELECT tblTeams.SchoolName AS School, tblCoachesRanks.teamID, tblCoachesRanks.Rank, tblTeams.WL FROM tblCoachesRanks INNER JOIN tblTeams ON tblCoachesRanks.teamID = tblTeams.teamID 
        WHERE (tblCoachesRanks.WeekID = @WeekID) AND (tblCoachesRanks.CoachIDTeamID = @CoachID) ORDER BY tblCoachesRanks.Rank">
        <SelectParameters>
            <asp:ControlParameter ControlID="cboSelectWeek" Name="WeekID" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="cboSelectSchool" Name="CoachID" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
<asp:SqlDataSource runat="server" ID="SQLDataSource2" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
    SelectCommand="SELECT tblTeams.SchoolName AS School, tblCoachesRanksEW.teamID, tblCoachesRanksEW.Rank, tblTeams.WL FROM tblCoachesRanksEW INNER JOIN tblTeams ON tblCoachesRanksEW.teamID = tblTeams.teamID 
        WHERE (tblCoachesRanksEW.WeekID = @WeekID) AND (tblCoachesRanksEW.CoachIDTeamID = @CoachID) AND (playoffsRegional = @memgPlayoffsRegionals) ORDER BY tblCoachesRanksEW.Rank">
        <SelectParameters>
            <asp:ControlParameter ControlID="cboSelectWeek" Name="WeekID" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="cboSelectSchool" Name="CoachID" PropertyName="SelectedValue" Type="String" />
            <asp:SessionParameter Name="memgPlayoffsRegionals" SessionField="memgPlayoffsRegionals" DefaultValue="0" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
