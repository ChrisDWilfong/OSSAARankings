Public Class clsMembers

    Shared Function LogScoreEntered(scheduleID As Long, sportID As String, memberID As Long, TeamID As Long, oTeamID As Long, strScoreByWho As String, dtmScore As String, TotalScore As Integer, oTotalScore As Integer, gameDate As String) As String
        ' CDW added 9/26/2019...
        On Error Resume Next

        Dim strReturn As String = "OK"
        Dim strSQL As String = ""

        strSQL = "INSERT INTO tblLOGScoresEntered (scheduleID, sportID, memberID, teamID, oTeamID, strScoreByWho, dtmScore, TotalScore, oTotalScore, gameDate) VALUES ("
        strSQL = strSQL & scheduleID & ", "
        strSQL = strSQL & "'" & sportID & "', "
        strSQL = strSQL & memberID & ", "
        strSQL = strSQL & TeamID & ", "
        strSQL = strSQL & oTeamID & ", "
        strSQL = strSQL & "'" & strScoreByWho & "', "
        strSQL = strSQL & "'" & dtmScore & "', "
        strSQL = strSQL & TotalScore & ", "
        strSQL = strSQL & oTotalScore & ", "
        strSQL = strSQL & "'" & gameDate & "')"

        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return strReturn
    End Function
    Shared Function GetUserName(strEmail As String, strSport As String) As String
        Dim strSQL As String
        Dim strFullName As String = ""
        Dim ds As DataSet
        strSQL = "SELECT * FROM allCoachesDetail WHERE strEmail = '" & strEmail & "' AND intYear = " & clsFunctions.GetCurrentYear & " AND sportID Like '" & strSport & "%'"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        If ds Is Nothing Then
            Return ""
        ElseIf ds.Tables.Count = 0 Then
            Return ""
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            Return ""
        Else
            Return ds.Tables(0).Rows(0).Item("FirstName") & " " & ds.Tables(0).Rows(0).Item("LastName")
        End If
    End Function
    Shared Function IsDuplicateEmail(intMemberID As Long, strEmailIn As String) As Boolean
        Dim ysnDuplicate As Boolean = False
        Dim strSQL As String
        Dim memberID As Long = 0

        strSQL = "SELECT memberID FROM tblMembers WHERE emailMain = '" & strEmailIn & "' AND memberID <> " & intMemberID & " AND intYear = " & clsFunctions.GetCurrentYear & " AND intActive <> 0"
        memberID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If memberID = 0 Then Return False Else Return True

    End Function

    Shared Function GetMembersFromSchoolSQL(schoolID As Long, intYear As Integer) As String
        Dim strSQL As String
        strSQL = "SELECT *, [FirstName] + ' ' + [LastName] AS FullName FROM tblMembers WHERE schoolID = " & schoolID & " AND intYear = " & intYear & " AND intActive <> 0"
        Return strSQL
    End Function

    Shared Sub LogMember(ByVal strMemberID As Long, ByVal strIP As String, ByVal strWins As String, ByVal strLosses As String)
        Dim strSQL As String
        strSQL = "INSERT INTO tblMembersLogin (memberID, WL, IP) VALUES (" & strMemberID & ", '" & strWins & "-" & strLosses & "', '" & strIP & "')"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
    End Sub

    Shared Function GetMemberIDFromTeam(ByVal intTeamID As Long) As Integer
        Dim strSQL As String
        Dim intMemberID As Long = 0
        strSQL = "SELECT CoachID FROM tblCoachTeams WHERE teamID = " & intTeamID
        intMemberID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Return intMemberID
    End Function

    Shared Function GetSchoolFromMember(ByVal intMemberID As Long) As String
        Dim strSQL As String = "SELECT tblSchools.School FROM tblMembers INNER JOIN tblSchools ON tblMembers.SchoolID = tblSchools.schoolID WHERE tblMembers.MemberID = " & intMemberID
        Return SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
    End Function

    Shared Function GetCoachesDatasetFromSchool(intSchoolID As Long, intYear As Integer) As DataSet
        ' 5/2/2013 Added...
        Dim ds As DataSet
        Dim strSQL As String
        strSQL = "SELECT MemberID, FirstName + ' ' + LastName AS FullName FROM tblMembers WHERE schoolID = " & intSchoolID & " AND intYear = " & intYear & " AND intActive = 1 ORDER BY LastName"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Return ds

    End Function

    Shared Function GetTeamsDatasetFromCoach(intSchoolID As Long, intYear As Integer, intMemberID As Long) As DataSet
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT tblTeams.teamID, GenderSport1 AS SportDisplay, memberID, tblSports.sportID, tblTeams.SportGenderKey AS SportGenderKey "
        strSQL = strSQL & "FROM tblTeams INNER JOIN "
        strSQL = strSQL & "tblSports ON tblTeams.sportID = tblSports.sportID "
        strSQL = strSQL & "WHERE tblTeams.schoolID = " & intSchoolID & " AND tblTeams.intYear = " & intYear & " And memberID = " & intMemberID

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return ds

    End Function

    ' Added 12/9/2014...
    Shared Function DoesMemberCoachBoysAndGirlsBasketball(intMemberID As Long, strSportGenderKeyIn As String) As String
        Dim strReturn As String = ""
        Dim intCount As Integer = 0
        Dim strSQL As String = "SELECT COUNT(teamID) As intCount FROM allCoachesDetail WHERE memberID = " & intMemberID & " AND sport = 'Basketball' AND intYear = " & clsFunctions.GetCurrentYear

        Try
            intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Catch ex As Exception
            intCount = 0
        End Try

        If intCount > 1 Then
            strReturn = "BasketballBOTH"
        Else
            strReturn = strSportGenderKeyIn
        End If

        Return strReturn
    End Function


End Class
