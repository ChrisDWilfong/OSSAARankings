Public Class clsRankings

    Shared Function ShowRankingsStatus() As Boolean
        Return True
    End Function

    Shared Function IsEWWeek(intWeekID As Long) As Boolean      ' Added 2/11/2015...
        Return SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT EW FROM tblRankingsWeeks WHERE wID = " & intWeekID)
    End Function

    Shared Function GetRankingsStatus(ByVal sportID As String, ByVal intTeamID As Integer, ByVal intCurrentWeekIDRank As Integer, ByVal intCurrentWeekIDDisplay As Integer, ByVal intCurrentWeekIDPeriod As Integer, ByVal intCurrentWeekNoRank As Integer, ByVal intCurrentWeekNoDisplay As Integer, ByVal intPreviousWeekRankID As Integer, ByVal intCurrentWeek12to4 As Integer, ByVal intRankingsThisSeason As Integer, strEvent As String) As String

        Dim strMessage As String = ""
        Dim intRankings As Integer = 0
        Dim strRankingsThisSeason As String = "0"

        ' 12/3/2013 added...
        If sportID.Contains("Wrestling") Then
            strRankingsThisSeason = "Wrestling = " & clsRankings.GetCurrentRankCountTeamSport(intTeamID, sportID) & " - Wrestling (Dual) = " & clsRankings.GetCurrentRankCountTeamSport(intTeamID, sportID.Replace("Wrestling", "WrestlingDual"))
        Else
            strRankingsThisSeason = CStr(intRankingsThisSeason)
        End If

        intRankings = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT intRankings FROM tblSports WHERE sportID = '" & sportID & "'")

        If intRankings = 0 Then
            strMessage = ""
        ElseIf intCurrentWeek12to4 > 0 Then
            If HasCoachSubmittedRankings(intCurrentWeek12to4, intTeamID, strEvent) Then     ' Coach submitted rankings PREVIOUS WEEK?..
                strMessage = "Rankings are currently NOT OPEN.  <span style='color:green;'>Your rankings HAVE BEEN received and confirmed.</span><br><span style='color:gray;'>Rankings submitted this season : " & strRankingsThisSeason & "</span>"
            Else
                strMessage = "Rankings are currently NOT OPEN.  Your rankings HAVE NOT BEEN received and confirmed.<br><span style='color:gray;'>Rankings submitted this season : " & strRankingsThisSeason & "</span>"
            End If
            strMessage = strMessage & "<br><a href=http://www.ossaarankings.com/docs/RankingsSubmissionsConfirmations.pdf target=_blank>Indicators to Know if Your Rankings Have Been Submitted (click here)</a>"
        ElseIf intCurrentWeekIDRank = 0 Then            ' Ranking Window is NOT OPEN...
            If intCurrentWeekIDDisplay > 0 Then     ' Ranking Display Window IS OPEN...
                If HasCoachSubmittedRankings(intCurrentWeekIDDisplay, intTeamID, strEvent) Then     ' Coach submitted rankings PREVIOUS WEEK?..
                    strMessage = "Rankings are currently NOT OPEN.  <span style='color:green;'>You DID submit rankings last week.</span><br><span style='color:gray;'>Rankings submitted this season : " & strRankingsThisSeason & "</span>"
                Else
                    strMessage = "Rankings are currently NOT OPEN.  You DID NOT submit rankings last week.<br><span style='color:gray;'>Rankings submitted this season : " & strRankingsThisSeason & "</span>"
                End If
            Else
                strMessage = "Rankings are currently NOT OPEN."
            End If
            strMessage = strMessage & "<br><a href=http://www.ossaarankings.com/docs/RankingsSubmissionsConfirmations.pdf target=_blank>Indicators to Know if Your Rankings Have Been Submitted (click here)</a>"
        Else
            If strEvent = "EnterRankingsEW" Then
                If HasCoachSubmittedRankings(intCurrentWeekIDPeriod, intTeamID, strEvent) Then
                    strMessage = "<span style='color:green;'>Rankings for this week are currently OPEN.  Your rankings HAVE BEEN received and confirmed.</span><br><span style='color:gray;'>Rankings submitted this season : " & strRankingsThisSeason & "</span>"
                Else
                    strMessage = "<span style='color:green;'>Rankings for this week are currently OPEN.</span>  Your rankings HAVE NOT BEEN received and confirmed.<br><span style='color:gray;'>Rankings submitted this season : " & strRankingsThisSeason & "</span>"
                End If
            Else
                If HasCoachSubmittedRankings(intCurrentWeekIDPeriod, intTeamID, strEvent) Then
                    strMessage = "<span style='color:green;'>Rankings for this week are currently OPEN.  Your rankings HAVE BEEN received and confirmed.</span><br><span style='color:gray;'>Rankings submitted this season : " & strRankingsThisSeason & "</span>"
                Else
                    strMessage = "<span style='color:green;'>Rankings for this week are currently OPEN.</span>  Your rankings HAVE NOT BEEN received and confirmed.<br><span style='color:gray;'>Rankings submitted this season : " & strRankingsThisSeason & "</span>"
                End If
            End If
            strMessage = strMessage & "<br><a href=http://www.ossaarankings.com/docs/RankingsSubmissionsConfirmations.pdf target=_blank>Indicators to Know if Your Rankings Have Been Submitted (click here)</a>"
        End If

        Return strMessage

    End Function
    Shared Function GetSplitWeek(WeekID As Long) As Integer
        Dim intSplitWeek As Long = 0
        intSplitWeek = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT intSplitWeek FROM tblRankingsWeeks WHERE wID = " & WeekID)
        Return intSplitWeek
    End Function

    Shared Function GetCurrentRankCount(intTeamID As Integer) As Integer
        ' Get the Current number of rankings submitted by this team...
        Dim strSQL As String
        Dim intCount As Integer = 0
        Dim ds As DataSet

        strSQL = "SELECT DISTINCT CoachIDTeamID, WeekID AS intCount FROM tblCoachesRanks WHERE CoachIDTeamID = " & intTeamID
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            intCount = ds.Tables(0).Rows.Count
        End If

        Return intCount

    End Function

    Shared Function GetCurrentRankCountTeamSport(intTeamID As Integer, strSportID As String) As Integer
        '  Get the Current number of rankings submitted by this team and sport...
        Dim strSQL As String
        Dim intCount As Integer = 0
        Dim ds As DataSet

        strSQL = "SELECT DISTINCT CoachIDTeamID, WeekID AS intCount FROM tblCoachesRanks WHERE CoachIDTeamID = " & intTeamID
        strSQL = "SELECT DISTINCT dbo.tblCoachesRanks.CoachIDTeamID, dbo.tblCoachesRanks.WeekID "
        strSQL = strSQL & "FROM  dbo.tblCoachesRanks INNER JOIN dbo.tblRankingsWeeks ON dbo.tblCoachesRanks.WeekID = dbo.tblRankingsWeeks.wID "
        strSQL = strSQL & "WHERE (dbo.tblRankingsWeeks.sportID = '" & strSportID & "') AND (dbo.tblCoachesRanks.CoachIDTeamID = " & intTeamID & ")"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            intCount = ds.Tables(0).Rows.Count
        End If

        Return intCount

    End Function

    Shared Function GetLockoutCount(wID As Integer, sportID As String, intTeamID As Long, rankingEvent As String) As Integer
        ' 9/17/2013... Get the Lockout value of the Week ID...
        Dim intCount As Integer = 0
        If rankingEvent = "EnterRankings8" And (sportID = "Volleyball" Or sportID = "FPSoftball") Then
            ' This is the Playoff Count (are they in the state tourney)???
            intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT playoffsState FROM allCoachesDetail WHERE teamID = " & intTeamID)
            If intCount = 1 Then intCount = 0 Else intCount = 99
        Else
            intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT intLockout FROM tblRankingsWeeks WHERE wid = " & wID)
        End If
        Return intCount
    End Function

    Shared Function GetCurrentRank(ByVal strSportID As String, ByVal intTeamID As Integer, strDate As String) As Integer
        ' Get the Current Rank for the TeamID in this current ranking window...
        Dim sql As String
        Dim intCurrentRank As Integer
        Dim intWeekID As Integer = 0

        If strDate = "" Then
            'strDate = Format(Now, "MM/dd/yy")
            strDate = Now.ToString
        End If

        Try
            intWeekID = GetCurrentRankingWeekIDDisplayWindow(strSportID, strDate)
        Catch
            intWeekID = 0
        End Try

        If intWeekID = 0 Then
            intCurrentRank = 0
        Else
            sql = "SELECT Rank FROM tblRankings WHERE (WeekID = " & intWeekID & " AND TeamID = " & intTeamID & ")"

            intCurrentRank = 0
            intCurrentRank = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, sql)

            If intCurrentRank > 20 Then
                intCurrentRank = 0
            End If
        End If

        Return intCurrentRank

    End Function

    Shared Function GetRankingByDate(ByVal strSportID As String, ByVal intTeamID As Integer, strDate As String, intWeekIDLatest As Integer) As Integer
        ' Get the Current Rank for the TeamID by date..
        ' CDW added 12/19/2014...
        Dim sql As String
        Dim intCurrentRank As Integer
        Dim intWeekID As Integer = 0
        Dim intRankMax As Integer = 20

        If strDate = "" Then
            strDate = Now.ToString
        End If

        Try
            intWeekID = GetCurrentRankingWeekIDDisplayWindow(strSportID, strDate)
        Catch
            intWeekID = 0
        End Try

        If intWeekIDLatest = 0 Then
            intWeekIDLatest = GetCurrentRankingWeekIDDisplayWindow(strSportID, Now)
        End If

        If intWeekID = 0 Then
            intCurrentRank = 0
        Else
            ' If the Selected week is greater than the latest ranking week, use the ranking week...
            If intWeekID > intWeekIDLatest Then
                intWeekID = intWeekIDLatest
            End If

            sql = "SELECT Rank FROM tblRankings WHERE (WeekID = " & intWeekID & " AND TeamID = " & intTeamID & ")"

            intCurrentRank = 0
            intCurrentRank = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, sql)

            ' Added 12/11/2017...
            If strSportID.Contains("Wrestling") Or strSportID.Contains("Cheer") Or strSportID.Contains("CrossCountry") Or strSportID.Contains("Golf") Or strSportID.Contains("Soccer") Or strSportID.Contains("Tennis") Or strSportID.Contains("Track") Then
                intRankMax = 15
            ElseIf strSportID.Contains("Volleyball") Then
                intRankMax = 16
            ElseIf strSportID.Contains("Swimming") Then
                intRankMax = 8
            Else
                intRankMax = 20
            End If

            If intCurrentRank > intRankMax Then
                intCurrentRank = 0
            End If

        End If

        Return intCurrentRank

    End Function


    Shared Function GetPreviousRankingWeekID(ByVal strSportID As String, ByVal gYear As Integer, intWeekNo As Integer) As Integer               ' Added 12/16/2009...
        ' Added 4/17/2013...
        Dim intPreviouseWeekID As Integer = 0
        Dim strSQL As String

        ' 9/5/2013 removed...
        'If intWeekNo > 1 Then
        '    intWeekNo = intWeekNo - 1
        'End If

        strSQL = "SELECT wID FROM tblRankingsWeeks WHERE intYear = " & gYear & " AND intWeekNo = " & intWeekNo & " AND SportID = '" & strSportID & "'"
        intPreviouseWeekID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return intPreviouseWeekID

    End Function

    Shared Function GetCurrentRankingWeekIDRankingWindow(ByVal strSportID As String, dtmNow As String) As Integer
        ' Added 4/17/2013...
        Dim intWeek As Integer = 0
        Dim strSQL As String = ""

        ' DEBUG...
        'Dim dtmDate As Date
        'dtmDate = dtmNow
        'dtmNow = DateAdd(DateInterval.Hour, 3, dtmDate)

        strSQL = "SELECT wID FROM tblRankingsWeeks "
        strSQL = strSQL & " WHERE sportID = '" & strSportID & "' AND (StartDate <= '" & dtmNow & "') AND (EndDate >= '" & dtmNow & "') AND (intYear = " & clsFunctions.GetCurrentYear & ")"
        strSQL = strSQL & " ORDER BY startDate DESC"
        intWeek = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return intWeek

    End Function


    Shared Function GetCurrentRankingWeekID12to4(ByVal strSportID As String, dtmNow As String) As Integer
        ' Added 9/5/2013...
        Dim intWeek As Integer = 0
        Dim strSQL As String = ""

        ' DEBUG...
        'Dim dtmDate As Date
        'dtmDate = dtmNow
        'dtmNow = DateAdd(DateInterval.Hour, 3, dtmDate)

        strSQL = "SELECT wID FROM tblRankingsWeeks "
        strSQL = strSQL & " WHERE sportID = '" & strSportID & "' AND (endDate <= '" & dtmNow & "') AND (ShowStartDate >= '" & dtmNow & "') AND (intYear = " & clsFunctions.GetCurrentYear & ") AND Not (WeekNo = 'DEAD')"
        strSQL = strSQL & " ORDER BY startDate DESC"
        intWeek = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return intWeek

    End Function

    Shared Function GetCurrentRankingWeekIDDisplayWindow(ByVal strSportID As String, dtmNow As String) As Integer
        ' Added 4/17/2013...
        Dim intWeek As Integer = 0
        Dim strSQL As String = ""

        strSQL = "SELECT wID FROM tblRankingsWeeks "
        strSQL = strSQL & " WHERE sportID = '" & strSportID & "' AND (ShowStartDate <= '" & dtmNow & "') AND (ShowEndDate >= '" & dtmNow & "') AND (intYear = " & clsFunctions.GetCurrentYear & ")"
        strSQL = strSQL & " ORDER BY startDate DESC"
        intWeek = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return intWeek

    End Function

    Shared Function GetCurrentRankingWeekIDPeriodWindow(ByVal strSportID As String, dtmNow As String) As Integer
        ' Added 4/17/2013...
        Dim intWeek As Integer = 0
        Dim strSQL As String = ""

        ' DEBUG...
        'Dim dtmDate As Date
        'dtmDate = dtmNow
        'dtmNow = DateAdd(DateInterval.Hour, 3, dtmDate)

        strSQL = "SELECT TOP 1 wID FROM tblRankingsWeeks "
        strSQL = strSQL & " WHERE sportID = '" & strSportID & "' AND (StartDate <= '" & dtmNow & "') AND (ShowEndDate >= '" & dtmNow & "') AND (intYear = " & clsFunctions.GetCurrentYear & ")"
        strSQL = strSQL & " ORDER BY startDate DESC"
        intWeek = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return intWeek

    End Function

    Shared Function GetCurrentRankingintWeekNo(ByVal intWeekID As Integer) As Integer
        ' Added 4/17/2013...
        Dim intWeekNo As Integer
        Dim strSQL As String = ""

        If intWeekID > 0 Then
            strSQL = "SELECT intWeekNo FROM tblRankingsWeeks "
            strSQL = strSQL & " WHERE wID = " & intWeekID
            intWeekNo = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Else
            intWeekNo = 0
        End If

        Return intWeekNo

    End Function

    Shared Function GetRankingsForCoachDS(ByVal weekId As Long, ByVal teamID As Long, intSplitWeek As Integer, strEvent As String) As DataSet
        ' Added 4/17/2013...12/17/2009...
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = GetRankingsForCoachSQL(weekId, teamID, strEvent)
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return ds

    End Function

    Shared Function HasCoachSubmittedRankings(ByVal weekId As Long, ByVal teamID As Long, strEvent As String) As Boolean

        Dim ds As DataSet
        ds = GetRankingsForCoachDS(weekId, teamID, 0, strEvent)

        If ds Is Nothing Then
            Return False
        ElseIf ds.Tables.Count = 0 Then
            Return False
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Shared Function GetRankingsForCoachSQL(ByVal weekId As Long, ByVal teamID As Long, strEvent As String) As String
        ' Added 4/17/2013...
        Dim strSQL As String

        If strEvent = "EnterRankingsEW" Then
            strSQL = "SELECT tblTeams.SchoolName As School, tblCoachesRanksEW.teamID, tblCoachesRanksEW.Rank, tblTeams.WL FROM tblCoachesRanksEW INNER JOIN "
            strSQL = strSQL & "tblTeams ON tblCoachesRanksEW.teamID = tblTeams.teamID "
            strSQL = strSQL & "WHERE (tblCoachesRanksEW.WeekID = " & weekId & ") AND (tblCoachesRanksEW.CoachIDTeamID = " & teamID & ") "
            strSQL = strSQL & "ORDER BY tblCoachesRanksEW.Rank"
        Else
            strSQL = "SELECT tblTeams.SchoolName As School, tblCoachesRanks.teamID, tblCoachesRanks.Rank, tblTeams.WL FROM tblCoachesRanks INNER JOIN "
            strSQL = strSQL & "tblTeams ON tblCoachesRanks.teamID = tblTeams.teamID "
            strSQL = strSQL & "WHERE (tblCoachesRanks.WeekID = " & weekId & ") AND (tblCoachesRanks.CoachIDTeamID = " & teamID & ") "
            strSQL = strSQL & "ORDER BY tblCoachesRanks.Rank"
        End If

        Return strSQL

    End Function

    Shared Function GetRankingsSchedule(strSportID As String, intYear As Integer, ysnAll As Boolean)
        ' Added 5/15/2013...
        Dim strSQL As String
        Dim ds As DataSet

        If ysnAll Then
            strSQL = "SELECT WeekNo + ' (' + CONVERT(varchar(25), REPLACE(tblRankingsWeeks.startDate, ' 12:00PM', ' NOON') , 0) + ')' AS strDisplay, CASE WHEN WeekNo Like 'DEAD%' THEN '-' ELSE CONVERT(varchar(25), REPLACE(tblRankingsWeeks.startDate, ' 12:00PM', ' NOON'), 0) END AS startDate, CASE WHEN WeekNo Like 'DEAD%' THEN '-' ELSE CONVERT(varchar(25), REPLACE(tblRankingsWeeks.endDate, ' 12:00PM', ' NOON'), 0) END AS endDate, WeekNo, intWeekNo, wID, Notes, intSplitWeek FROM tblRankingsWeeks WHERE sportID = '" & strSportID & "' AND intYear = " & intYear & " ORDER BY intWeekNo"
        Else
            ' Only show the Weeks that are open...
            strSQL = "SELECT WeekNo + ' (' + CONVERT(varchar(25), REPLACE(tblRankingsWeeks.startDate, ' 12:00PM', ' NOON') , 0) + ')' AS strDisplay, CASE WHEN WeekNo Like 'DEAD%' THEN '-' ELSE CONVERT(varchar(25), REPLACE(tblRankingsWeeks.startDate, ' 12:00PM', ' NOON'), 0) END AS startDate, CASE WHEN WeekNo Like 'DEAD%' THEN '-' ELSE CONVERT(varchar(25), REPLACE(tblRankingsWeeks.endDate, ' 12:00PM', ' NOON'), 0) END AS endDate, WeekNo, intWeekNo, wID, Notes, intSplitWeek FROM tblRankingsWeeks WHERE sportID = '" & strSportID & "' AND intYear = " & intYear & " AND ShowstartDate < '" & Now.ToString & "' ORDER BY intWeekNo"
        End If
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return ds
    End Function
End Class
