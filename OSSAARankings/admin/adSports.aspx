<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="adSports.aspx.vb" Inherits="OSSAARankings.adSports" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox runat="server" ID="txtLogin" BackColor="Yellow"></asp:TextBox>&nbsp;<asp:Button
        ID="cmdGo" runat="server" Text="Go" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" DataKeyNames="sportID" DataSourceID="SqlDataSource1" 
            ForeColor="Black" GridLines="Vertical" Font-Size="8pt" 
            Font-Names="Verdana" HeaderStyle-Font-Names="Verdana" 
            HeaderStyle-Font-Size="8pt" AllowPaging="True" AllowSorting="True" 
            AutoGenerateEditButton="True">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="sportID" HeaderText="sportID" ReadOnly="True" 
                    SortExpression="sportID" />
                <asp:BoundField DataField="Class" HeaderText="Class" SortExpression="Class" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" 
                    SortExpression="Gender" />
                <asp:BoundField DataField="SportGenderKey" HeaderText="SportGenderKey" 
                    SortExpression="SportGenderKey" />
                <asp:BoundField DataField="SportDisplay" HeaderText="SportDisplay" 
                    SortExpression="SportDisplay" />
                <asp:BoundField DataField="NumberofRankings" HeaderText="NumberofRankings" 
                    SortExpression="NumberofRankings" />
                <asp:BoundField DataField="Sort" HeaderText="Sort" 
                    SortExpression="Sort" />
                <asp:BoundField DataField="seasonSort" HeaderText="seasonSort" 
                    SortExpression="seasonSort" />
                <asp:BoundField DataField="NumberOfRankingsShow" HeaderText="NumberOfRankingsShow" 
                    SortExpression="NumberOfRankingsShow" />
                <asp:BoundField DataField="intRankings" HeaderText="intRankings" 
                    SortExpression="intRankings" />
                <asp:BoundField DataField="intRankingsSchedule" HeaderText="intRankingsSchedule" 
                    SortExpression="intRankingsSchedule" />
                <asp:BoundField DataField="intSchedules" HeaderText="intSchedules" 
                    SortExpression="intSchedules" />
                <asp:BoundField DataField="intDistrictStandings" HeaderText="intDistrictStandings" 
                    SortExpression="intDistrictStandings" />
                <asp:BoundField DataField="intShowRecord" 
                    HeaderText="intShowRecord" SortExpression="intShowRecord" />
                <asp:BoundField DataField="intResults" HeaderText="intResults" 
                    SortExpression="intResults" />
                <asp:BoundField DataField="GenderSport1" HeaderText="GenderSport1" 
                    SortExpression="GenderSport1" />
                <asp:BoundField DataField="strSchedulesTable" 
                    HeaderText="strSchedulesTable" 
                    SortExpression="strSchedulesTable" />
                <asp:BoundField DataField="strActivityAbb" 
                    HeaderText="strActivityAbb" 
                    SortExpression="strActivityAbb" />
                <asp:BoundField DataField="strActivityClassifyAbb" 
                    HeaderText="strActivityClassifyAbb" 
                    SortExpression="strActivityClassifyAbb" />
                <asp:BoundField DataField="strPostGender" 
                    HeaderText="strPostGender" 
                    SortExpression="strPostGender" />
                <asp:BoundField DataField="strRankingNote" 
                    HeaderText="strRankingNote" 
                    SortExpression="strRankingNote" />
                <asp:BoundField DataField="intPlayoffsScheduleShowDistricts" 
                    HeaderText="intPlayoffsScheduleShowDistricts" 
                    SortExpression="intPlayoffsScheduleShowDistricts" />
                <asp:BoundField DataField="strPlayoffsScheduleShowDistricts" 
                    HeaderText="strPlayoffsScheduleShowDistricts" 
                    SortExpression="strPlayoffsScheduleShowDistricts" />
                <asp:BoundField DataField="intPlayoffsScheduleShowRegionals" 
                    HeaderText="intPlayoffsScheduleShowRegionals" 
                    SortExpression="intPlayoffsScheduleShowRegionals" />
                <asp:BoundField DataField="strPlayoffsScheduleShowRegionals" 
                    HeaderText="strPlayoffsScheduleShowRegionals" 
                    SortExpression="strPlayoffsScheduleShowRegionals" />
                <asp:BoundField DataField="intPlayoffsScheduleShowAreas" 
                    HeaderText="intPlayoffsScheduleShowAreas" 
                    SortExpression="intPlayoffsScheduleShowAreas" />
                <asp:BoundField DataField="strPlayoffsScheduleShowAreas" 
                    HeaderText="strPlayoffsScheduleShowAreas" 
                    SortExpression="strPlayoffsScheduleShowAreas" />
                <asp:BoundField DataField="intPlayoffsScheduleShowState" 
                    HeaderText="intPlayoffsScheduleShowState" 
                    SortExpression="intPlayoffsScheduleShowState" />
                <asp:BoundField DataField="strPlayoffsScheduleShowState" 
                    HeaderText="strPlayoffsScheduleShowState" 
                    SortExpression="strPlayoffsScheduleShowState" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" 
                Font-Names="Verdana" Font-Size="8pt" />
            <PagerStyle BackColor="#999999" ForeColor="Yellow" Font-Bold="true" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        
        SelectCommand="SELECT [sportID], [Class], [Gender], [SportGenderKey], [SportDisplay], [NumberofRankings], [Sort], [seasonSort], [NumberOfRankingsShow], [intRankings], [intRankingsSchedule], [intSchedules], [intDistrictStandings], [intShowRecord], [intResults], [GenderSport1], [strSchedulesTable], [strActivityAbb], [strActivityClassifyAbb], [strPostGender], [strRankingNote], [intPlayoffsScheduleShowDistricts], [strPlayoffsScheduleShowDistricts], [intPlayoffsScheduleShowRegionals], [strPlayoffsScheduleShowRegionals], [intPlayoffsScheduleShowAreas], [strPlayoffsScheduleShowAreas], [intPlayoffsScheduleShowState], [strPlayoffsScheduleShowState] FROM [tblSports] ORDER BY [SportGenderKey]" 
        DeleteCommand="DELETE FROM [tblSports] WHERE [sportID] = @sportID" 
        InsertCommand="INSERT INTO [tblSports] ([sportID], [Class], [Gender], [SportGenderKey], [SportDisplay], [NumberofRankings], [Sort], [seasonSort], [NumberOfRankingsShow], [intRankings], [intRankingsSchedule], [intSchedules], [intDistrictStandings], [intShowRecord], [intResults], [GenderSport1], [strSchedulesTable], [strActivityAbb], [strActivityClassifyAbb], [strPostGender], [strRankingNote], [intPlayoffsScheduleShowDistricts], [strPlayoffsScheduleShowDistricts], [intPlayoffsScheduleShowRegionals], [strPlayoffsScheduleShowRegionals], [intPlayoffsScheduleShowAreas], [strPlayoffsScheduleShowAreas], [intPlayoffsScheduleShowState], [strPlayoffsScheduleShowState]) VALUES (@sportID, @Class, @Gender, @SportGenderKey, @SportDisplay, @NumberofRankings, @Sort, @seasonSort, @NumberOfRankingsShow, @intRankings, @intRankingsSchedule, @intSchedules, @intDistrictStandings, @intShowRecord, @intResults, @GenderSport1, @strSchedulesTable, @strActivityAbb, @strActivityClassifyAbb, @strPostGender, @strRankingNote, @intPlayoffsScheduleShowDistricts, @strPlayoffsScheduleShowDistricts, @intPlayoffsScheduleShowRegionals, @strPlayoffsScheduleShowRegionals, @intPlayoffsScheduleShowAreas, @strPlayoffsScheduleShowAreas, @intPlayoffsScheduleShowState, @strPlayoffsScheduleShowState)" 
        UpdateCommand="UPDATE [tblSports] SET [Class] = @Class, [Gender] = @Gender, [SportGenderKey] = @SportGenderKey, [SportDisplay] = @SportDisplay, [NumberofRankings] = @NumberofRankings, [Sort] = @Sort, [seasonSort] = @seasonSort, [NumberOfRankingsShow] = @NumberOfRankingsShow, [intRankings] = @intRankings, [intRankingsSchedule] = @intRankingsSchedule, [intSchedules] = @intSchedules, [intDistrictStandings] = @intDistrictStandings, [intShowRecord] = @intShowRecord, [intResults] = @intResults, [GenderSport1] = @GenderSport1, [strSchedulesTable] = @strSchedulesTable, [strActivityAbb] = @strActivityAbb, [strActivityClassifyAbb] = @strActivityClassifyAbb, [strPostGender] = @strPostGender, [strRankingNote] = @strRankingNote, [intPlayoffsScheduleShowDistricts] = @intPlayoffsScheduleShowDistricts, [strPlayoffsScheduleShowDistricts] = @strPlayoffsScheduleShowDistricts, [intPlayoffsScheduleShowRegionals] = @intPlayoffsScheduleShowRegionals, [strPlayoffsScheduleShowRegionals] = @strPlayoffsScheduleShowRegionals, [intPlayoffsScheduleShowAreas] = @intPlayoffsScheduleShowAreas, [strPlayoffsScheduleShowAreas] = @strPlayoffsScheduleShowAreas, [intPlayoffsScheduleShowState] = @intPlayoffsScheduleShowState, [strPlayoffsScheduleShowState] = @strPlayoffsScheduleShowState WHERE [sportID] = @sportID">
        <DeleteParameters>
            <asp:Parameter Name="sportID" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="sportID" Type="String" />
            <asp:Parameter Name="Class" Type="String" />
            <asp:Parameter Name="Gender" Type="String" />
            <asp:Parameter Name="SportGenderKey" Type="String" />
            <asp:Parameter Name="SportDisplay" Type="String" />
            <asp:Parameter Name="NumberofRankings" Type="Int32" />
            <asp:Parameter Name="Sort" Type="Int32" />
            <asp:Parameter Name="seasonSort" Type="Int16" />
            <asp:Parameter Name="NumberOfRankingsShow" Type="Int16" />
            <asp:Parameter Name="intRankings" Type="Int16" />
            <asp:Parameter Name="intRankingsSchedule" Type="Int16" />
            <asp:Parameter Name="intSchedules" Type="Int16" />
            <asp:Parameter Name="intDistrictStandings" Type="Int16" />
            <asp:Parameter Name="intShowRecord" Type="Int16" />
            <asp:Parameter Name="intResults" Type="Int16" />
            <asp:Parameter Name="GenderSport1" Type="String" />
            <asp:Parameter Name="strSchedulesTable" Type="String" />
            <asp:Parameter Name="strActivityAbb" Type="String" />
            <asp:Parameter Name="strActivityClassifyAbb" Type="String" />
            <asp:Parameter Name="strPostGender" Type="String" />
            <asp:Parameter Name="strRankingNote" Type="String" />
            <asp:Parameter Name="intPlayoffsScheduleShowDistricts" Type="Int16" />
            <asp:Parameter Name="strPlayoffsScheduleShowDistricts" Type="String" />
            <asp:Parameter Name="intPlayoffsScheduleShowRegionals" Type="Int16" />
            <asp:Parameter Name="strPlayoffsScheduleShowRegionals" Type="String" />
            <asp:Parameter Name="intPlayoffsScheduleShowAreas" Type="Int16" />
            <asp:Parameter Name="strPlayoffsScheduleShowAreas" Type="String" />
            <asp:Parameter Name="intPlayoffsScheduleShowState" Type="Int16" />
            <asp:Parameter Name="strPlayoffsScheduleShowState" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Class" Type="String" />
            <asp:Parameter Name="Gender" Type="String" />
            <asp:Parameter Name="SportGenderKey" Type="String" />
            <asp:Parameter Name="SportDisplay" Type="String" />
            <asp:Parameter Name="NumberofRankings" Type="Int32" />
            <asp:Parameter Name="Sort" Type="Int32" />
            <asp:Parameter Name="seasonSort" Type="Int16" />
            <asp:Parameter Name="NumberOfRankingsShow" Type="Int16" />
            <asp:Parameter Name="intRankings" Type="Int16" />
            <asp:Parameter Name="intRankingsSchedule" Type="Int16" />
            <asp:Parameter Name="intSchedules" Type="Int16" />
            <asp:Parameter Name="intDistrictStandings" Type="Int16" />
            <asp:Parameter Name="intShowRecord" Type="Int16" />
            <asp:Parameter Name="intResults" Type="Int16" />
            <asp:Parameter Name="GenderSport1" Type="String" />
            <asp:Parameter Name="strSchedulesTable" Type="String" />
            <asp:Parameter Name="strActivityAbb" Type="String" />
            <asp:Parameter Name="strActivityClassifyAbb" Type="String" />
            <asp:Parameter Name="strPostGender" Type="String" />
            <asp:Parameter Name="strRankingNote" Type="String" />
            <asp:Parameter Name="intPlayoffsScheduleShowDistricts" Type="Int16" />
            <asp:Parameter Name="strPlayoffsScheduleShowDistricts" Type="String" />
            <asp:Parameter Name="intPlayoffsScheduleShowRegionals" Type="Int16" />
            <asp:Parameter Name="strPlayoffsScheduleShowRegionals" Type="String" />
            <asp:Parameter Name="intPlayoffsScheduleShowAreas" Type="Int16" />
            <asp:Parameter Name="strPlayoffsScheduleShowAreas" Type="String" />
            <asp:Parameter Name="intPlayoffsScheduleShowState" Type="Int16" />
            <asp:Parameter Name="strPlayoffsScheduleShowState" Type="String" />
            <asp:Parameter Name="sportID" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
