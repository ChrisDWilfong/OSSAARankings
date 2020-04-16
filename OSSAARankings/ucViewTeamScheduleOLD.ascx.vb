Imports System.Data

Partial Class ucViewTeamScheduleOLD
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objTeamInfo As New clsTeam(Session("gTeamID"))
        InitializeGrid(objTeamInfo.getSport, Session("gTeamID"))

    End Sub

    Public Sub InitializeGrid(ByVal sport As String, ByVal tmID As Integer)
        Dim sql As String
        Dim ds As DataSet

        ' TODO : Replace tblSchedules & sport with table name from object above...
        If sport = "Golf" Or sport = "Soccer" Or sport = "Track" Or sport = "Tennis" Or sport = "Football" Then
            'sql = "SELECT dbo.tblSchools.School AS School, dbo.tblSchedules" & sport & ".*, dbo.tblSports.Class AS Class "
            'sql = sql & "FROM dbo.tblSchools INNER JOIN "
            sql = "SELECT 'Date' AS [Date], tblSchedules" & sport & ".gameTime AS [Time], tblSchools.School AS [Opposing Team], tblSchedules" & sport & ".Location AS [Location], 'Results' AS [Results], 'Game Results' AS [View], 'Opponent' AS [Hyperlink], "
            sql = sql & "tblSchedules" & sport & ".OtherTeam, tblSchedules" & sport & ".Tournament, tblSchedules" & sport & ".TotalScore, tblSchedules" & sport & ".opposingTeamID, tblSchedules" & sport & ".oTotalScore, tblSchedules" & sport & ".gameDate, tblSports.Class, tblSports.sportID, tblTeams.teamID  "
            sql = sql & "FROM tblSchools INNER JOIN "
            sql = sql & "tblTeams ON tblSchools.schoolID = tblTeams.schoolID INNER JOIN "
            sql = sql & "tblSports ON tblTeams.sportID = tblSports.sportID RIGHT OUTER JOIN "
            sql = sql & "tblSchedules" & sport & " ON tblTeams.teamID = tblSchedules" & sport & ".opposingTeamID "
            sql = sql & "WHERE (tblSchedules" & sport & ".teamID = " & tmID & ") "
            sql = sql & "ORDER BY tblSchedules" & sport & ".gamedate, tblSchedules" & sport & ".gametime, tblSchedules" & sport & ".Tournament "

        ElseIf sport = "Baseball" Or sport = "SPSoftball" Or sport = "FPSoftball" Then
            sql = "SELECT 'Date' AS [Date], tblSchedulesBaseball.gameTime AS [Time], tblSchools.School AS [Opposing Team], tblSchedulesBaseball.Location AS [Location], 'Results' AS [Results], 'Game Results' AS [View], 'Opponent' AS [Hyperlink], "
            sql = sql & "tblSchedulesBaseball.OtherTeam, tblSchedulesBaseball.Tournament, tblSchedulesBaseball.TotalScore, tblSchedulesBaseball.opposingTeamID, tblSchedulesBaseball.oTotalScore, tblSchedulesBaseball.gameDate, tblSports.Class, tblSports.sportID, tblTeams.teamID  "
            sql = sql & "FROM tblSchools INNER JOIN "
            sql = sql & "tblTeams ON tblSchools.schoolID = tblTeams.schoolID INNER JOIN "
            sql = sql & "tblSports ON tblTeams.sportID = tblSports.sportID RIGHT OUTER JOIN "
            sql = sql & "tblSchedulesBaseball ON tblTeams.teamID = tblSchedulesBaseball.opposingTeamID "
            sql = sql & "WHERE (tblSchedulesBaseball.teamID = " & tmID & ") "
            sql = sql & "ORDER BY tblSchedulesBaseball.gamedate, tblSchedulesBaseball.gametime, tblSchedulesBaseball.Tournament "
        Else
            sql = "SELECT 'Date' AS [Date], tblSchedules.gameTime AS [Time], tblSchools.School AS [Opposing Team], tblSchedules.Location AS [Location], 'Results' AS [Results], 'Game Results' AS [View], 'Opponent' AS [Hyperlink], "
            sql = sql & "tblSchedules.OtherTeam, tblSchedules.Tournament, tblSchedules.TotalScore, tblSchedules.opposingTeamID, tblSchedules.oTotalScore, tblSchedules.gameDate, tblSports.Class, tblSports.sportID, tblTeams.teamID  "
            sql = sql & "FROM tblSchools INNER JOIN "
            sql = sql & "tblTeams ON tblSchools.schoolID = tblTeams.schoolID INNER JOIN "
            sql = sql & "tblSports ON tblTeams.sportID = tblSports.sportID RIGHT OUTER JOIN "
            sql = sql & "tblSchedules ON tblTeams.teamID = tblSchedules.opposingTeamID "
            sql = sql & "WHERE (dbo.tblSchedules.teamID = " & tmID & ") "
            sql = sql & "ORDER BY tblSchedules.gamedate, tblSchedules.gametime, tblSchedules.Tournament "
        End If

        ' Get initial dataset...
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, sql)

        ' Change the dataset...
        ds = ChangeDataset(ds)

        ' Bind new dataset ....
        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()

    End Sub

    Public Function ChangeDataset(ByVal ds As DataSet) As DataSet
        Dim x As Integer
        Dim strOpposingTeam As String
        Dim strShortDate As String
        Dim strWL As String
        Dim intCurrentRanking As Integer

        For x = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(x)
                ' Date...
                strShortDate = Format(.Item("gameDate"), "MM/dd/yyyy")
                .Item("Date") = strShortDate.Replace("12:00:00 AM", "")

                ' Opposing Team...
                ' TODO : Add Hyperlink...
                If .Item("Opposing Team") Is System.DBNull.Value Then
                    strOpposingTeam = .Item("OtherTeam")
                Else
                    intCurrentRanking = clsRankings.GetCurrentRank(.Item("sportID"), .Item("teamID"))
                    If intCurrentRanking > 0 Then
                        strOpposingTeam = .Item("Opposing Team") & " (" & .Item("Class") & ") #" & intCurrentRanking
                    Else
                        strOpposingTeam = "<a href='?sel=teamschedule&t=" & .Item("OpposingteamID") & "' target='_self'>" & .Item("Opposing Team") & " (" & .Item("Class") & ") " & "</a>"
                    End If
                End If
                strOpposingTeam = strOpposingTeam.Replace(" High School", "")
                If .Item("Tournament") Is System.DBNull.Value Then
                Else
                    strOpposingTeam = strOpposingTeam & " @ " & .Item("Tournament")
                End If

                .Item("Opposing Team") = strOpposingTeam
                ' Results...
                strWL = ""
                If .Item("TotalScore") = 0 And .Item("oTotalScore") = 0 Then
                    .Item("Results") = "No Score"
                Else
                    If .Item("TotalScore") > .Item("oTotalScore") Then
                        strWL = "W"
                    Else
                        strWL = "L"
                    End If
                    .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & strWL
                End If
            End With
        Next

        Return ds
    End Function

End Class
