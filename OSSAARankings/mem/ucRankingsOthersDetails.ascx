<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucRankingsOthersDetails.ascx.vb" Inherits="OSSAARankings.ucRankingsOthersDetails" %>
<link href="mem.css" rel="stylesheet" type="text/css" />
    <asp:Table ID="tblRO" runat="server">
        <asp:TableRow>
            <asp:TableCell RowSpan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                    CaptionAlign="Left" CellPadding="4" 
                    Font-Names="Verdana" Font-Size="8pt" 
                    UseAccessibleHeader="False" Width="400px"
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
                        <asp:BoundField DataField="Points" HeaderText="Points" />
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
<asp:SqlDataSource runat="server" ID="SQLDataSource1" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
    SelectCommand="SELECT tblSchools.School, tblCoachesRanks.teamID, tblCoachesRanks.Rank, tblTeams.WL FROM tblCoachesRanks INNER JOIN tblTeams ON tblCoachesRanks.teamID = tblTeams.teamID INNER JOIN tblSchools ON tblTeams.schoolID = tblSchools.schoolID 
        WHERE (tblCoachesRanks.WeekID = @WeekID) AND (tblCoachesRanks.CoachID = @CoachID) ORDER BY tblCoachesRanks.Rank">
        <SelectParameters>
            <asp:ControlParameter ControlID="cboSelectWeek" Name="WeekID" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="cboSelectSchool" Name="CoachID" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>