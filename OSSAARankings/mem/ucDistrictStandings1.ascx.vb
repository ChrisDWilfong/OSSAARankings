Public Class ucDistrictStandings1
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strSQL As String = ""
        Dim ds As DataSet

        ' Set the Datasource and the title...
        Select Case Session("memgSportGenderKey")
            Case "Baseball"
                lblHeader.Text = "<b>OSSAA Baseball (5A-6A) District Standings</b>"
                lblHeader1.Text = "Class " & Session("memgClass") & " - District " & Session("memgDistrict")
                strSQL = "SELECT * FROM [ossaauser].[viewDistrictStandingsBaseball] WHERE ([Class] = '" & Session("memgClass") & "') AND (District = " & Session("memgDistrict") & ") ORDER BY [Class], District, DistrictWins DESC, DistrictLosses, HeadToHead DESC, DistrictPoints DESC, Wins DESC, SchoolName"
            Case "Football"
                lblHeader.Text = "<b>Official OSSAA Football District Standings</b>"
                lblHeader1.Text = "Class " & Session("memgClass") & " - District " & Session("memgDistrict")
                strSQL = "SELECT * FROM [ossaauser].[viewDistrictStandingsFootball] WHERE (([Class] = '" & Session("memgClass") & "') AND (District = " & Session("memgDistrict") & ")) ORDER BY [Class], District, DistrictWins DESC, DistrictLosses, HeadToHeadOverride DESC, HeadToHead DESC, DistrictPoints DESC, Wins DESC, SchoolName"
            Case "FPSoftball"
                lblHeader.Text = "<b>Official OSSAA Fast-Pitch (5A-6A) District Standings</b>"
                lblHeader1.Text = "Class " & Session("memgClass") & " - District " & Session("memgDistrict")
                lblDate.Text = "(games through " & ConfigurationManager.AppSettings("DistrictStandingsDateFP") & ")"
                strSQL = "SELECT * FROM [ossaauser].[viewDistrictStandingsFastPitch] WHERE ([Class] = '" & Session("memgClass") & "') AND (District = " & Session("memgDistrict") & ") ORDER BY [Class], District, DistrictWins DESC, DistrictLosses, HeadToHead DESC, DistrictPoints DESC, Wins DESC, SchoolName"
            Case "SoccerBoys"
                lblHeader.Text = "<b>OSSAA Soccer (Boys) District Standings</b>"
                lblHeader1.Text = "Class " & Session("memgClass") & " - District " & Session("memgDistrict")
                strSQL = "SELECT * FROM [ossaauser].[viewDistrictStandingsSoccerBoys] WHERE ([Class] = '" & Session("memgClass") & "') AND (District = " & Session("memgDistrict") & ") ORDER BY [Class], District, DistrictWins DESC, DistrictLosses, HeadToHead DESC, DistrictPoints DESC, Wins DESC, SchoolName"
            Case "SoccerGirls"
                lblHeader.Text = "<b>OSSAA Soccer (Girls) District Standings</b>"
                lblHeader1.Text = "Class " & Session("memgClass") & " - District " & Session("memgDistrict")
                strSQL = "SELECT * FROM [ossaauser].[viewDistrictStandingsSoccerGirls] WHERE ([Class] = '" & Session("memgClass") & "') AND (District = " & Session("memgDistrict") & ") ORDER BY [Class], District, DistrictWins DESC, DistrictLosses, HeadToHead DESC, DistrictPoints DESC, Wins DESC, SchoolName"
            Case "WrestlingDual"
                lblHeader.Text = "<b>OSSAA Wrestling (Dual) District Standings</b>"
                lblHeader1.Text = "Class " & Session("memgClass") & " - District " & Session("memgDistrict")
                strSQL = "SELECT * FROM [ossaauser].[viewDistrictStandingsWrestlingDual] WHERE ([Class] = '" & Session("memgClass") & "') AND (District = " & Session("memgDistrict") & ") ORDER BY [Class], District, DistrictWins DESC, DistrictLosses, HeadToHead DESC, SchoolName"
        End Select
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        GridView1.DataSource = ds
        GridView1.DataBind()

    End Sub

End Class