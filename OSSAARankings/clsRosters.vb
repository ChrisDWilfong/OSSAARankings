Public Class clsRosters

    ' UPDATED 4/24/2013...
    Shared Function GetRosterSQL(ByVal teamID As Integer)
        Dim strSQL As String = ""

        'strSQL = "SELECT [Jersey], [LastName] AS Last, [FirstName] AS First, [LastName] + ', ' + [FirstName] AS DisplayName, [Pos], [Height], [Weight], [Grade], [rosterID], [ysnStarter] AS Starter, [ysnPitcher] AS Pitcher FROM [tblRosters] WHERE ([teamID] = " & teamID & ") AND ysnActive <> 0 ORDER BY [LastName], [FirstName]"
        strSQL = "SELECT [Jersey], [LastName] AS Last, [FirstName] AS First, [LastName] + ', ' + [FirstName] AS DisplayName, [Pos], [Height], [Weight], [Grade], [rosterID], [ysnStarter] AS Starter, [ysnPitcher] AS Pitcher FROM [tblRosters] WHERE ([teamID] = " & teamID & ") AND ysnActive <> 0"

        Return strSQL

    End Function

    ' ADDED 4/26/2013...
    Shared Function LoadRostersList(schoolID As Integer) As DataSet
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT DISTINCT tblTeams.teamID, tblTeams.sportID, tblSports.SportGenderKey, tblSports.GenderSport1, dbo.tblSports.Class AS strClass "
        strSQL = strSQL & "FROM tblTeams INNER JOIN tblSports ON tblTeams.sportID = tblSports.sportID INNER JOIN tblRosters ON tblTeams.teamID = tblRosters.teamID "
        strSQL = strSQL & "WHERE tblTeams.schoolID = " & schoolID & " AND tblTeams.intYear = " & clsFunctions.GetCurrentYear
        strSQL = strSQL & " ORDER BY tblSports.GenderSport1"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return ds
    End Function

    Shared Function ChangeDatasetRoster(ByVal ds As DataSet, ysnPublic As Boolean) As DataSet
        Dim x As Integer
        Dim strResults As String = ""

        For x = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(x)
                strResults = .Item("DisplayName")
                strResults = "<a href='?sel=RosterEdit&r=" & .Item("rosterID") & "' target='_self'>" & strResults & "</a>"
                ' Write the Results...
                .Item("DisplayName") = strResults
            End With
        Next

        Return ds
    End Function


    Shared Function GetRosterSQLPlayer(ByVal intSchoolID As Integer, ByVal strSport As String, ByVal strGender As String)
        Dim strSQL As String = ""

        'Select Case strSport
        '    Case "Basketball"
        If strGender = "Girls" Then
            strSQL = "SELECT [Jersey], [LastName] + ', ' + [FirstName] AS Player, [Pos], [Height], [Grade], [strStats] AS LastStats "
            strSQL = strSQL & "FROM  tblRosters INNER JOIN tblTeams ON tblRosters.teamID = tblTeams.teamID INNER JOIN tblSports ON tblTeams.sportID = tblSports.sportID WHERE (tblTeams.intYear = 10) AND (tblTeams.schoolID = " & intSchoolID & " ) AND (tblSports.Gender = '" & strGender & "') AND (tblSports.Sport = '" & strSport & "') AND (tblRosters.ysnActive=1) "
            strSQL = strSQL & "ORDER BY [LastName], [FirstName]"
        Else
            strSQL = "SELECT [Jersey], [LastName] + ', ' + [FirstName] AS Player, [Pos], [Height], [Weight], [Grade], [strStats] AS LastStats "
            strSQL = strSQL & "FROM  tblRosters INNER JOIN tblTeams ON tblRosters.teamID = tblTeams.teamID INNER JOIN tblSports ON tblTeams.sportID = tblSports.sportID WHERE (tblTeams.intYear = 10) AND (tblTeams.schoolID = " & intSchoolID & " ) AND (tblSports.Gender = '" & strGender & "') AND (tblSports.Sport = '" & strSport & "') AND (tblRosters.ysnActive=1) "
            strSQL = strSQL & "ORDER BY [LastName], [FirstName]"
        End If
        '    Case "Football"
        '    Case Else
        'strSQL = "SELECT [Jersey], [LastName] + ', ' + [FirstName] AS Player, [Pos], [Height], [Weight], [Grade], [rosterID], [ysnStarter] AS Starter, [strStats] AS LastStats, [ysnPitcher] AS Pitcher FROM [tblRosters] WHERE ([teamID] = " & teamID & ") AND ysnActive = 1 ORDER BY [LastName], [FirstName]"
        'End Select

        Return strSQL
    End Function

    Shared Sub DeleteAPlayer(ByVal intRosterID As Long)
        Dim strSQL As String
        strSQL = "UPDATE tblRosters SET ysnActive = 0 WHERE rosterID = " & intRosterID
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
    End Sub

 
End Class
