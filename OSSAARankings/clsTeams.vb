Imports OSSAARankings.SqlHelper

Public Class clsTeams

    Shared Function GetTeamUpdate(teamID As Long) As String
        Dim strTeamUpdate As String = ""
        Dim strSQL As String = "SELECT TOP 1 * FROM tblTeamsUpdate WHERE teamID = " & teamID & " ORDER BY Id DESC"
        Dim ds As DataSet
 
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            strTeamUpdate = "Last Update : " & ds.Tables(0).Rows(0).Item("dtmStamp") & "<br>" & ds.Tables(0).Rows(0).Item("strUpdate")
        End If

        Return strTeamUpdate
    End Function

    Shared Function GetSchoolNameFromTeamID(ByVal teamID As Long) As String
        Dim strSQL As String
        strSQL = "SELECT SchoolNameCoachName FROM allCoachesDetail WHERE teamID = " & teamID
        Return SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
    End Function

    Shared Function GetTeamPixLocation() As String
        Return ConfigurationManager.AppSettings("TeamPix")
    End Function


    Shared Function GetTeamID(strSportID As String, intSchoolID As Long, intYear As Integer) As Long
        Dim strSQL As String
        strSQL = "SELECT teamID FROM tblTeams WHERE sportID = '" & strSportID & "' AND schoolID = " & intSchoolID & " AND intYear = " & intYear
        Return SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
    End Function

    Shared Function GetSportIDForTeam(intTeamID As Long) As String
        ' Added 4/11/2013...
        Dim strSQL As String
        Dim strResult As String

        strSQL = "SELECT sportID FROM tblTeams WHERE teamID = " & intTeamID
        strResult = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return strResult

    End Function


    Shared Function GetSportTeamsForClass(ByVal strSportID As String, ByVal intYear As Long, intTeamID As Long, strEvent As String, intRegional As Integer) As DataSet
        Dim strSQL As String
        Dim ds As DataSet
        Dim strSGK As String

        Try
            strSGK = strSportID
        Catch
            strSGK = ""
        End Try

        ' This is a HACK... 12/18/2013...
        Select Case strSGK
            Case "SwimmingBoys", "SwimmingGirls", "CrossCountryBoys", "CrossCountryGirls", "BaseballFall", "Volleyball", "BasketballBoys", "BasketballGirls", "Football", "Wrestling", "Baseball", "SPSoftball", "Soccer", "FPSoftball", "TennisBoys", "TennisGirls", "GolfBoys", "GolfGirls", "TrackBoys", "TrackGirls", "SoccerGirls", "SoccerBoys"
                strSGK = "Ellen"
            Case Else
        End Select

        If strSGK.Contains("Select..") Then
            strSGK = "Ellen"
        End If

        If strSGK = "" Then
            strSQL = "SELECT TOP (100) PERCENT dbo.tblTeams.teamID, dbo.tblTeams.SchoolName + ' (' + dbo.tblSports.Class + ') (' + CAST(dbo.tblTeams.W AS varchar) + '-' + CAST(dbo.tblTeams.L AS varchar) + ')' AS School, dbo.tblTeams.SchoolName, "
        ElseIf strSGK.Contains("Cheer") Or strSGK.Contains("CrossCountry") Or strSGK.Contains("Swimming") Then
            strSQL = "SELECT TOP (100) PERCENT dbo.tblTeams.teamID, dbo.tblTeams.SchoolName + ' (' + dbo.tblSports.Class + ') ' AS School, dbo.tblTeams.SchoolName, "
        ElseIf strSGK.Contains("Golf") Then
            strSQL = "SELECT TOP (100) PERCENT dbo.tblTeams.teamID, dbo.tblTeams.SchoolName + ' (' + dbo.tblSports.Class + ') ' AS School, dbo.tblTeams.SchoolName, dbo.GolfScoreAverage(dbo.tblTeams.teamID) AS avgGolfScore, "
        Else
            strSQL = "SELECT TOP (100) PERCENT dbo.tblTeams.teamID, dbo.tblTeams.SchoolName + ' (' + dbo.tblSports.Class + ') (' + CAST(dbo.tblTeams.W AS varchar) + '-' + CAST(dbo.tblTeams.L AS varchar) + ')' AS School, dbo.tblTeams.SchoolName, "
        End If
        strSQL = strSQL & "dbo.tblTeams.SchoolName As SchoolAbb, '' AS strTeam, dbo.tblTeams.WL, dbo.tblMembers.FirstName, dbo.tblMembers.LastName "
        strSQL = strSQL & "FROM dbo.tblTeams INNER JOIN "
        strSQL = strSQL & "dbo.tblSchool ON dbo.tblTeams.schoolID = dbo.tblSchool.schoolID INNER JOIN "
        strSQL = strSQL & "dbo.tblSports ON dbo.tblTeams.sportID = dbo.tblSports.sportID LEFT OUTER JOIN "
        strSQL = strSQL & "dbo.tblMembers ON dbo.tblTeams.memberID = dbo.tblMembers.MemberID "

        If strSGK.Contains("WrestlingDual") Then
            If strEvent = "EnterRankings8" Then
                strSQL = strSQL & "WHERE (dbo.tblTeams.SportID1 = '" & strSGK & "') AND (dbo.tblTeams.intYear = " & intYear & ") AND (dbo.tblTeams.playoffsState = 1) "
            Else
                strSQL = strSQL & "WHERE (dbo.tblTeams.SportID1 = '" & strSGK & "') AND (dbo.tblTeams.intYear = " & intYear & ") "
            End If
        ElseIf strSGK.Contains("Volleyball") Or strSGK.Contains("FPSoftball") Then       ' CDW added 9/26/2019 FPSoftball ...CDW added 9/20/2018...
            If strEvent = "EnterRankings8" Then
                ' And Not TeamID = is for YOU CAN'T RANK YOURSELF...
                strSQL = strSQL & "WHERE (dbo.tblTeams.SportID = '" & strSGK & "') AND (dbo.tblTeams.intYear = " & intYear & ") AND (dbo.tblTeams.playoffsState = 1) AND Not (teamID = " & intTeamID & ")"
            Else
                strSQL = strSQL & "WHERE (dbo.tblTeams.SportID = '" & strSGK & "') AND (dbo.tblTeams.intYear = " & intYear & ") "
            End If
        Else
            If strEvent = "EnterRankingsEW" Then        ' 2 = East, 3 = West...
                strSQL = strSQL & "WHERE (dbo.tblTeams.SportID = '" & strSGK & "') AND (dbo.tblTeams.intYear = " & intYear & ") AND (dbo.tblTeams.playoffsRegional = " & intRegional & ")"
            Else
                strSQL = strSQL & "WHERE (dbo.tblTeams.SportID = '" & strSGK & "') AND (dbo.tblTeams.intYear = " & intYear & ") "
            End If
        End If

        ' DO NOT remove the team, Wrestling Dual 8 teams can rank themselves...
        If strEvent = "EnterRankings8" Then
            intTeamID = 0
        End If

        ' Remove My Team (for rankings)...
        If intTeamID > 0 Then
            strSQL = strSQL & " AND (tblTeams.teamID <> " & intTeamID & ")"
        End If

        strSQL = strSQL & " ORDER BY School"

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return ds
    End Function

    Shared Function GetSportTeamsForClassThatHaveRanked(ByVal strSportID As String, ByVal intYear As Long, intWeekID As Long, intTeamID As Long, ysnEW As Boolean) As DataSet
        ' Added 12/18/2013...
        Dim strSQL As String
        Dim ds As DataSet
        Dim strSGK As String

        Try
            strSGK = strSportID
        Catch
            strSGK = ""
        End Try

        ' This is a HACK... 12/18/2013...
        If strSGK = "BasketballBoys" Or strSGK = "BasketballGirls" Then
            strSGK = "Ellen"
        End If

        If strSGK = "" Then
            strSQL = "SELECT DISTINCT dbo.tblTeams.teamID, dbo.tblTeams.SchoolName + ' (' + dbo.tblSports.Class + ') (' + CAST(dbo.tblTeams.W AS varchar) + '-' + CAST(dbo.tblTeams.L AS varchar) + ')' AS School, dbo.tblTeams.SchoolName, "
        ElseIf strSGK.Contains("Cheer") Or strSGK.Contains("CrossCountry") Or strSGK.Contains("Swimming") Then
            strSQL = "SELECT DISTINCT dbo.tblTeams.teamID, dbo.tblTeams.SchoolName + ' (' + dbo.tblSports.Class + ') ' AS School, dbo.tblTeams.SchoolName, "
        Else
            strSQL = "SELECT DISTINCT dbo.tblTeams.teamID, dbo.tblTeams.SchoolName + ' (' + dbo.tblSports.Class + ') (' + CAST(dbo.tblTeams.W AS varchar) + '-' + CAST(dbo.tblTeams.L AS varchar) + ')' AS School, dbo.tblTeams.SchoolName, "
        End If
        strSQL = strSQL & "dbo.tblTeams.SchoolName As SchoolAbb, '' AS strTeam, dbo.tblTeams.WL, dbo.tblMembers.FirstName, dbo.tblMembers.LastName "
        strSQL = strSQL & "FROM dbo.tblTeams INNER JOIN "
        strSQL = strSQL & "dbo.tblSchool ON dbo.tblTeams.schoolID = dbo.tblSchool.schoolID INNER JOIN "
        strSQL = strSQL & "dbo.tblSports ON dbo.tblTeams.sportID = dbo.tblSports.sportID LEFT OUTER JOIN "

        If ysnEW Then
            strSQL = strSQL & "dbo.tblCoachesRanksEW ON dbo.tblTeams.teamID = dbo.tblCoachesRanksEW.CoachIDTeamID LEFT OUTER JOIN "
        Else
            strSQL = strSQL & "dbo.tblCoachesRanks ON dbo.tblTeams.teamID = dbo.tblCoachesRanks.CoachIDTeamID LEFT OUTER JOIN "
        End If

        strSQL = strSQL & "dbo.tblMembers ON dbo.tblTeams.memberID = dbo.tblMembers.MemberID "
        ' Changed 11/27/2013...
        If ysnEW Then
            If strSGK.Contains("WrestlingDual") Then
                strSQL = strSQL & "WHERE (dbo.tblTeams.SportID1 = '" & strSGK & "') AND (dbo.tblTeams.intYear = " & intYear & ") AND (dbo.tblCoachesRanksEW.WeekID = " & intWeekID & ") "
            Else
                strSQL = strSQL & "WHERE (dbo.tblTeams.SportID = '" & strSGK & "') AND (dbo.tblTeams.intYear = " & intYear & ") AND (dbo.tblCoachesRanksEW.WeekID = " & intWeekID & ") "
            End If
        Else
            If strSGK.Contains("WrestlingDual") Then
                strSQL = strSQL & "WHERE (dbo.tblTeams.SportID1 = '" & strSGK & "') AND (dbo.tblTeams.intYear = " & intYear & ") AND (dbo.tblCoachesRanks.WeekID = " & intWeekID & ") "
            Else
                strSQL = strSQL & "WHERE (dbo.tblTeams.SportID = '" & strSGK & "') AND (dbo.tblTeams.intYear = " & intYear & ") AND (dbo.tblCoachesRanks.WeekID = " & intWeekID & ") "
            End If
        End If

        ' Remove My Team (for rankings)...
        If intTeamID > 0 Then
            strSQL = strSQL & " AND (tblTeams.teamID <> " & intTeamID & ")"
        End If

        strSQL = strSQL & " ORDER BY School"

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return ds
    End Function

    Shared Function GetSportTeamsForSport(ByVal strSportGenderKey As String, ByVal intYear As Long, intTeamID As Long) As DataSet
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT tblTeams.teamID, tblTeams.SchoolName + ' (' + tblSports.Class + ')' AS School "
        strSQL = strSQL & "FROM tblTeams INNER JOIN "
        strSQL = strSQL & "tblSports ON tblTeams.sportID = tblSports.sportID INNER JOIN "
        strSQL = strSQL & "tblSchool ON tblTeams.schoolID = tblSchool.schoolID "
        strSQL = strSQL & " WHERE (tblSports.SportGenderKey = '" & strSportGenderKey & "') AND (tblTeams.intYear = " & intYear & ")"
        ' Remove My Team (for rankings)...
        If intTeamID > 0 Then
            strSQL = strSQL & " AND (tblTeams.teamID <> " & intTeamID & ")"
        End If

        strSQL = strSQL & " ORDER BY School"

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return ds

    End Function

    Shared Function GetTop20Record(ByVal intTeamID As Long, ByVal intRange As Integer, ByVal intYear As Integer) As String
        Dim strReturn As String = ""
        Dim intTotalW As Integer = 0
        Dim intTotalL As Integer = 0
        Dim intTop20W As Integer = 0
        Dim intTop20L As Integer = 0
        Dim intTop10W As Integer = 0
        Dim intTop10L As Integer = 0
        Dim intTop5W As Integer = 0
        Dim intTop5L As Integer = 0
        Dim isWL As String = ""
        Dim intHW As Integer = 0
        Dim intHL As Integer = 0
        Dim intTotal As Integer = 0
        Dim intGrandTotal As Integer = 0

        ' 101 for Home
        ' 102 for Away

        Dim ds As DataSet
        Dim strSQL As String
        Dim x As Integer

        Dim int6AW As Integer = 0
        Dim int5AW As Integer = 0
        Dim int4AW As Integer = 0
        Dim int3AW As Integer = 0
        Dim int2AW As Integer = 0
        Dim intAW As Integer = 0
        Dim intBW As Integer = 0

        Dim int6AL As Integer = 0
        Dim int5AL As Integer = 0
        Dim int4AL As Integer = 0
        Dim int3AL As Integer = 0
        Dim int2AL As Integer = 0
        Dim intAL As Integer = 0
        Dim intBL As Integer = 0

        Dim intLast7DaysW As Integer = 0
        Dim intLast7DaysL As Integer = 0

        Dim dat7Days As Date

        dat7Days = DateAdd(DateInterval.Day, -7, Now)

        strSQL = "SELECT tblSchedules.*, tblSports.Class, tblSports.Gender FROM tblSports INNER JOIN "
        strSQL = strSQL & "tblTeams ON tblSports.sportID = tblTeams.sportID RIGHT OUTER JOIN tblSchedules ON tblTeams.teamID = tblSchedules.oTeamID "
        strSQL = strSQL & "WHERE (tblSchedules.intYear = " & intYear & ") AND (tblSchedules.TeamID = " & intTeamID & ") AND (tblSchedules.ysnActive = 1) "
        strSQL = strSQL & "ORDER BY tblTeams.teamID"

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1

                With ds.Tables(0).Rows(x)

                    ' Grand total number of games...
                    intGrandTotal = intGrandTotal + 1

                    If .Item("WL") Is System.DBNull.Value Then
                        isWL = ""
                    ElseIf .Item("WL") = "W" Then
                        isWL = "W"
                    ElseIf .Item("WL") = "L" Then
                        isWL = "L"
                    ElseIf .Item("WL") = "T" Then
                        isWL = "T"
                    Else
                        isWL = ""
                    End If

                    If isWL = "W" Then
                        intTotalW = intTotalW + 1

                        ' Get RANKINGS wins...
                        If CInt(.Item("orank")) = 0 Then
                        Else
                            If CInt(.Item("orank")) <= intRange Then intTop20W = intTop20W + 1
                        End If

                        If CInt(.Item("orank")) = 0 Then
                        Else
                            If CInt(.Item("orank")) <= 10 Then intTop10W = intTop10W + 1
                        End If

                        If CInt(.Item("orank")) = 0 Then
                        Else
                            If CInt(.Item("orank")) <= 5 Then intTop5W = intTop5W + 1
                        End If

                        ' Get Home/Away wins...
                        If intRange = 101 Then
                            If .Item("location") = "Home" Or .Item("location") = "Homecoming" Then
                                intHW = intHW + 1
                                intTotal = intTotal + 1
                            End If
                        ElseIf intRange = 102 Then
                            If .Item("location") = "Away" Then
                                intHW = intHW + 1
                                intTotal = intTotal + 1
                            End If
                        ElseIf intRange = 103 Then
                            If .Item("location") = "Home" Or .Item("location") = "Homecoming" Or .Item("location") = "Away" Then
                            Else
                                intHW = intHW + 1
                                intTotal = intTotal + 1
                            End If
                        Else
                            If CInt(.Item("orank")) = 0 Then
                            Else
                                If .Item("orank") <= intRange Then intTotal = intTotal + 1
                            End If
                        End If

                        ' Get CLASS Wins...
                        If .Item("Class") Is System.DBNull.Value Then

                        Else
                            Select Case .Item("Class")
                                Case "6A"
                                    int6AW = int6AW + 1
                                Case "5A"
                                    int5AW = int5AW + 1
                                Case "4A"
                                    int4AW = int4AW + 1
                                Case "3A"
                                    int3AW = int3AW + 1
                                Case "2A"
                                    int2AW = int2AW + 1
                                Case "A"
                                    intAW = intAW + 1
                                Case "B"
                                    intBW = intBW + 1
                            End Select
                        End If

                        ' Get Last 7 days wins...
                        If .Item("gamedate") >= dat7Days Then
                            intLast7DaysW = intLast7DaysW + 1
                        End If

                    End If

                        If isWL = "L" Then
                            intTotalL = intTotalL + 1

                            ' Get RANKINGS losses...
                            If CInt(.Item("orank")) = 0 Then
                            Else
                                If .Item("orank") <= intRange Then intTop20L = intTop20L + 1
                            End If

                            If CInt(.Item("orank")) = 0 Then
                            Else
                                If .Item("orank") <= 10 Then intTop10L = intTop10L + 1
                            End If

                            If CInt(.Item("orank")) = 0 Then
                            Else
                                If .Item("orank") <= 5 Then intTop5L = intTop5L + 1
                            End If

                            ' Get Home/Away losses...
                            If intRange = 101 Then
                                If .Item("location") = "Home" Or .Item("location") = "Homecoming" Then
                                    intHL = intHL + 1
                                    intTotal = intTotal + 1
                                End If
                            ElseIf intRange = 102 Then
                                If .Item("location") = "Away" Then
                                    intHL = intHL + 1
                                    intTotal = intTotal + 1
                                End If
                            ElseIf intRange = 103 Then
                                If .Item("location") = "Home" Or .Item("location") = "Homecoming" Or .Item("location") = "Away" Then
                                Else
                                    intHL = intHL + 1
                                    intTotal = intTotal + 1
                                End If
                            Else
                                If CInt(.Item("orank")) = 0 Then
                                Else
                                    If .Item("orank") <= intRange Then intTotal = intTotal + 1
                                End If
                            End If

                        ' Get Class Losses...
                        If .Item("Class") Is System.DBNull.Value Then

                        Else
                            Select Case .Item("Class")
                                Case "6A"
                                    int6AL = int6AL + 1
                                Case "5A"
                                    int5AL = int5AL + 1
                                Case "4A"
                                    int4AL = int4AL + 1
                                Case "3A"
                                    int3AL = int3AL + 1
                                Case "2A"
                                    int2AL = int2AL + 1
                                Case "A"
                                    intAL = intAL + 1
                                Case "B"
                                    intBL = intBL + 1
                            End Select
                        End If

                        ' Get Last 7 days losses...
                        If .Item("gamedate") >= dat7Days Then
                            intLast7DaysL = intLast7DaysL + 1
                        End If

                    End If

                        If isWL = "" Then
                            If intRange = 101 Then
                                If .Item("location") = "Home" Or .Item("location") = "Homecoming" Then
                                    intTotal = intTotal + 1
                                End If
                            ElseIf intRange = 102 Then
                                If .Item("location") = "Away" Then
                                    intTotal = intTotal + 1
                                End If
                            ElseIf intRange = 103 Then
                                If .Item("location") = "Home" Or .Item("location") = "Homecoming" Or .Item("location") = "Away" Then
                                Else
                                    intTotal = intTotal + 1
                                End If
                            Else
                                If CInt(.Item("orank")) = 0 Then
                                Else
                                    If .Item("orank") <= intRange Then intTotal = intTotal + 1
                                End If
                            End If
                        End If

                End With
            Next
        End If

        ' Let's Put it all together...
        strReturn = "<hr><strong>Overall Record : </strong>" & intTotalW & "-" & intTotalL & "<br>"
        strReturn = strReturn & "<strong>Last 7 Days : </strong>" & intLast7DaysW & "-" & intLast7DaysL & "<br>"
        strReturn = strReturn & "<hr>"
        strReturn = strReturn & "<strong>vs TOP 5 : </strong>" & intTop5W & "-" & intTop5L & "<br>"
        strReturn = strReturn & "<strong>vs TOP 10 : </strong>" & intTop10W & "-" & intTop10L & "<br>"
        strReturn = strReturn & "<strong>vs TOP 20 : </strong>" & intTop20W & "-" & intTop20L & "<br>"
        strReturn = strReturn & "<hr>"
        strReturn = strReturn & "<strong>vs Class 6A: </strong>" & int6AW & "-" & int6AL & "<br>"
        strReturn = strReturn & "<strong>vs Class 5A: </strong>" & int5AW & "-" & int5AL & "<br>"
        strReturn = strReturn & "<strong>vs Class 4A: </strong>" & int4AW & "-" & int4AL & "<br>"
        strReturn = strReturn & "<strong>vs Class 3A: </strong>" & int3AW & "-" & int3AL & "<br>"
        strReturn = strReturn & "<strong>vs Class 2A: </strong>" & int2AW & "-" & int2AL & "<br>"
        strReturn = strReturn & "<strong>vs Class A: </strong>" & intAW & "-" & intAL & "<br>"
        strReturn = strReturn & "<strong>vs Class B: </strong>" & intBW & "-" & intBL & "<br>"

        'If intRange < 100 Then
        '    strReturn = intTop20W & "-" & intTop20L & "-" & intTotal & "-" & intGrandTotal
        'Else
        '    strReturn = intHW & "-" & intHL & "-" & intTotal & "-" & intGrandTotal
        'End If

        Return strReturn

    End Function

    Shared Function GetRecords(ByVal intTeamID As Long, ByVal wlo As Integer, ByVal intYear As Integer) As String
        Dim strReturn As String = ""
        Dim intTotalW As Integer = 0
        Dim intTotalL As Integer = 0
        Dim intTop20W As Integer = 0
        Dim intTop20L As Integer = 0
        Dim intTop10W As Integer = 0
        Dim intTop10L As Integer = 0
        Dim intTop5W As Integer = 0
        Dim intTop5L As Integer = 0
        Dim isWL As String = ""
        Dim intHW As Integer = 0
        Dim intHL As Integer = 0
        Dim intAW As Integer = 0
        Dim intAL As Integer = 0
        Dim intNW As Integer = 0
        Dim intNL As Integer = 0

        Dim ds As DataSet
        Dim strSQL As String
        Dim x As Integer

        strSQL = "SELECT tblSchedules.*, tblSports.Class, tblSports.Gender FROM tblSports INNER JOIN "
        strSQL = strSQL & "tblTeams ON tblSports.sportID = tblTeams.sportID RIGHT OUTER JOIN tblSchedules ON tblTeams.teamID = tblSchedules.opposingTeamID "
        strSQL = strSQL & "WHERE (tblSchedules.intYear = " & intYear & ") AND (tblSchedules.WL = 'W' OR tblSchedules.WL = 'L') AND (tblSchedules.TeamID = " & intTeamID & ") AND (tblSchedules.ysnActive = 1) "
        strSQL = strSQL & "ORDER BY tblTeams.teamID"

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strReturn = "<i>Records based on game results entered by coach:</i><br>"

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                With ds.Tables(0).Rows(x)
                    If .Item("WL") = "W" Then
                        isWL = "W"
                    ElseIf .Item("WL") = "L" Then
                        isWL = "L"
                    ElseIf .Item("WL") = "T" Then
                        isWL = "T"
                    Else
                        isWL = ""
                    End If
                    If isWL <> "" Then
                        If isWL = "W" Then
                            intTotalW = intTotalW + 1
                            If CInt(.Item("orank")) = 0 Then
                            Else
                                If CInt(.Item("orank")) <= 5 Then intTop5W = intTop5W + 1
                                If CInt(.Item("orank")) <= 10 Then intTop10W = intTop10W + 1
                                If CInt(.Item("orank")) <= 20 Then intTop20W = intTop20W + 1
                            End If
                            If .Item("location") = "Home" Or .Item("location") = "Homecoming" Then
                                intHW = intHW + 1
                            ElseIf .Item("location") = "Away" Then
                                intAW = intAW + 1
                            Else
                                intNW = intNW + 1
                            End If
                        End If
                        If isWL = "L" Then
                            intTotalL = intTotalL + 1
                            If CInt(.Item("orank")) = 0 Then
                            Else
                                If .Item("orank") <= 5 Then intTop5L = intTop5L + 1
                                If .Item("orank") <= 10 Then intTop10L = intTop10L + 1
                                If .Item("orank") <= 20 Then intTop20L = intTop20L + 1
                            End If
                            If Trim(.Item("location")) = "Home" Then
                                intHL = intHL + 1
                            ElseIf Trim(.Item("location")) = "Away" Then
                                intAL = intAL + 1
                            Else
                                intNL = intNL + 1
                            End If
                        End If
                    End If
                End With
            Next
        End If

        'strReturn = strReturn & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- Entered Results: " & intTotalW & "-" & intTotalL & "<br>"
        strReturn = strReturn & "&nbsp;&nbsp;&nbsp;&nbsp;<img src='/images/arrow_bluecircle.gif'>&nbsp;vs Top 5: " & intTop5W & "-" & intTop5L & "<br>"
        strReturn = strReturn & "&nbsp;&nbsp;&nbsp;&nbsp;<img src='/images/arrow_bluecircle.gif'>&nbsp;vs Top 10: " & intTop10W & "-" & intTop10L & "<br>"
        strReturn = strReturn & "&nbsp;&nbsp;&nbsp;&nbsp;<img src='/images/arrow_bluecircle.gif'>&nbsp;vs Top 20: " & intTop20W & "-" & intTop20L & "<br>"
        strReturn = strReturn & "&nbsp;&nbsp;&nbsp;&nbsp;<img src='/images/arrow_bluecircle.gif'>&nbsp;at Home: " & intHW & "-" & intHL & "<br>"
        strReturn = strReturn & "&nbsp;&nbsp;&nbsp;&nbsp;<img src='/images/arrow_bluecircle.gif'>&nbsp;Away: " & intAW & "-" & intAL & "<br>"
        strReturn = strReturn & "&nbsp;&nbsp;&nbsp;&nbsp;<img src='/images/arrow_bluecircle.gif'>&nbsp;Neutral: " & intNW & "-" & intNL & "<br>"

        Return strReturn

    End Function


    Shared Function GetSportTeamsBySportID1(ByVal intSportID1 As Long, ByVal intTeamID As Long, ByVal intYear As Integer) As DataSet
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT TOP (100) PERCENT tblTeams.teamID, REPLACE(tblSchools.School, 'High School', '') + ' (' + tblSports.Class + ') [' + tblTeams.WL + ']' AS School"
        strSQL = strSQL & " FROM tblTeams INNER JOIN"
        strSQL = strSQL & " tblCoachTeams ON tblTeams.teamID = tblCoachTeams.TeamID INNER JOIN"
        strSQL = strSQL & " tblSchools ON tblTeams.schoolID = tblSchools.schoolID INNER JOIN"
        strSQL = strSQL & " tblSports ON tblTeams.sportID1 = tblSports.sportID INNER JOIN"
        strSQL = strSQL & " tblMembers ON tblCoachTeams.CoachID = tblMembers.MemberID"
        strSQL = strSQL & " WHERE (tblTeams.sportID1 = " & intSportID1 & " AND tblTeams.intYear = " & intYear & ")"

        ' Remove My Team (for rankings)...
        If intTeamID > 0 Then
            strSQL = strSQL & " AND (tblTeams.teamID <> " & intTeamID & ")"
        End If

        strSQL = strSQL & " ORDER BY School"

        ds = ExecuteDataset(SQLConnection, CommandType.Text, strSQL)

        Return ds

    End Function


    Shared Function GetSportTeamsBySportID(ByVal intSportID As Long, ByVal intTeamID As Long, ByVal intYear As Integer) As DataSet
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT TOP (100) PERCENT tblTeams.teamID, REPLACE(tblSchools.School, 'High School', '') + ' (' + tblSports.Class + ')' AS School"
        strSQL = strSQL & " FROM tblTeams INNER JOIN"
        strSQL = strSQL & " tblCoachTeams ON tblTeams.teamID = tblCoachTeams.TeamID INNER JOIN"
        strSQL = strSQL & " tblSchools ON tblTeams.schoolID = tblSchools.schoolID INNER JOIN"
        strSQL = strSQL & " tblSports ON tblTeams.sportID = tblSports.sportID INNER JOIN"
        strSQL = strSQL & " tblMembers ON tblCoachTeams.CoachID = tblMembers.MemberID"
        strSQL = strSQL & " WHERE (tblSports.sportID = " & intSportID & " AND tblTeams.intYear = " & intYear & ")"

        ' Remove My Team (for rankings)...
        If intTeamID > 0 Then
            strSQL = strSQL & " AND (tblTeams.teamID <> " & intTeamID & ")"
        End If

        strSQL = strSQL & " ORDER BY School"

        ds = ExecuteDataset(SQLConnection, CommandType.Text, strSQL)

        Return ds

    End Function

    ' '' ''Shared Function GetSportTeams(ByVal strSport As String, ByVal strGender As String, ByVal strClass As String, ByVal intYear As Long, ByVal intTeamID As Long, ByVal ysnWL As Boolean, ByVal strEW As String) As DataSet
    ' '' ''    Dim strSQL As String
    ' '' ''    Dim ds As DataSet

    ' '' ''    If ysnWL Then
    ' '' ''        If strSport = "Soccer" Then
    ' '' ''            strSQL = "SELECT TOP (100) PERCENT tblTeams.teamID, REPLACE(tblSchools.School, 'High School', '') + ' (' + tblSports.Class + ') [' + tblTeams.WL + '-' + CONVERT(varchar, dbo.CalcTiesSoccer(tblTeams.teamID)) + ']' AS School"
    ' '' ''        Else
    ' '' ''            strSQL = "SELECT TOP (100) PERCENT tblTeams.teamID, REPLACE(tblSchools.School, 'High School', '') + ' (' + tblSports.Class + ') [' + tblTeams.WL + ']' AS School"
    ' '' ''        End If
    ' '' ''    Else
    ' '' ''        strSQL = "SELECT TOP (100) PERCENT tblTeams.teamID, REPLACE(tblSchools.School, 'High School', '') + ' (' + tblSports.Class + ')' AS School"
    ' '' ''    End If
    ' '' ''    strSQL = strSQL & " FROM tblTeams INNER JOIN"
    ' '' ''    strSQL = strSQL & " tblCoachTeams ON tblTeams.teamID = tblCoachTeams.TeamID INNER JOIN"
    ' '' ''    strSQL = strSQL & " tblSchools ON tblTeams.schoolID = tblSchools.schoolID INNER JOIN"
    ' '' ''    strSQL = strSQL & " tblSports ON tblTeams.sportID = tblSports.sportID INNER JOIN"
    ' '' ''    strSQL = strSQL & " tblMembers ON tblCoachTeams.CoachID = tblMembers.MemberID"
    ' '' ''    If strGender = "" Then
    ' '' ''        If strClass = "" Then
    ' '' ''            strSQL = strSQL & " WHERE (tblSports.Sport = '" & strSport & "') AND (tblTeams.intYear = " & intYear & ")"
    ' '' ''        Else
    ' '' ''            strSQL = strSQL & " WHERE (tblSports.Sport = '" & strSport & "') AND (tblTeams.intYear = " & intYear & ") AND (tblSports.Class = '" & strClass & "')"
    ' '' ''        End If
    ' '' ''    Else
    ' '' ''        If strClass = "" Then
    ' '' ''            strSQL = strSQL & " WHERE (tblSports.Sport = '" & strSport & "') AND (tblSports.Gender = '" & strGender & "') AND (tblTeams.intYear = " & intYear & ")"
    ' '' ''        Else
    ' '' ''            strSQL = strSQL & " WHERE (tblSports.Sport = '" & strSport & "') AND (tblSports.Gender = '" & strGender & "') AND (tblTeams.intYear = " & intYear & ") AND (tblSports.Class = '" & strClass & "')"
    ' '' ''        End If
    ' '' ''    End If
    ' '' ''    ' Remove My Team (for rankings)...
    ' '' ''    If intTeamID > 0 Then
    ' '' ''        strSQL = strSQL & " AND (tblTeams.teamID <> " & intTeamID & ")"
    ' '' ''    End If

    ' '' ''    ' Do we need East/West?
    ' '' ''    If strEW = "" Then
    ' '' ''    Else
    ' '' ''        strSQL = strSQL & " AND (tblTeams.EW = '" & strEW & "')"
    ' '' ''    End If

    ' '' ''    strSQL = strSQL & " ORDER BY School"

    ' '' ''    ds = ExecuteDataset(SQLConnection, CommandType.Text, strSQL)

    ' '' ''    Return ds

    ' '' ''End Function

    Shared Function GetTeamNameFromTeamID(ByVal teamID As Long) As String
        Dim strSQL As String
        Dim strSchool As String

        strSQL = "SELECT tblSchools.School FROM tblTeams INNER JOIN tblCoachTeams ON tblTeams.teamID = tblCoachTeams.TeamID INNER JOIN "
        strSQL = strSQL & "tblSchools ON tblTeams.schoolID = tblSchools.schoolID INNER JOIN tblMembers ON tblCoachTeams.CoachID = tblMembers.MemberID "
        strSQL = strSQL & "WHERE (tblTeams.teamID = " & teamID & ")"

        strSchool = ExecuteScalar(SQLConnection, CommandType.Text, strSQL)

        Return strSchool
    End Function

#Region "Wins and Losses"

    Shared Function GetWLTeamString(ByVal enteredWins As Integer, ByVal enteredLoses As Integer, ByVal teamID As Long, ByVal sportSchedule As String) As String
        Dim intCountWins As Integer
        Dim intCountLosses As Integer
        Dim strSQL As String
        Dim strReturn As String

        strSQL = "SELECT COUNT(scheduleID) AS Wins FROM tblSchedules" & sportSchedule & " WHERE (teamID = " & teamID & ") AND (WL = 'W') AND (ysnActive=1)"
        intCountWins = ExecuteScalar(SQLConnection, CommandType.Text, strSQL)

        strSQL = "SELECT COUNT(scheduleID) AS Wins FROM tblSchedules" & sportSchedule & " WHERE (teamID = " & teamID & ") AND (WL = 'L') AND (ysnActive=1)"
        intCountLosses = ExecuteScalar(SQLConnection, CommandType.Text, strSQL)

        If intCountWins = 0 And intCountLosses = 0 Then
            strReturn = enteredWins & "-" & enteredLoses
        Else
            If intCountWins > enteredWins Then
                strReturn = intCountWins & "-" & intCountLosses
            Else
                strReturn = enteredWins & "-" & enteredLoses
            End If
        End If

        Return strReturn

    End Function

    Shared Sub GetCalcWLTeam(ByVal teamID As Long, ByRef intWins As Integer, ByRef intLosses As Integer, ysnUpdate As Boolean)
        Dim intCountWins As Integer
        Dim intCountLosses As Integer
        Dim strSQL As String

        strSQL = "SELECT COUNT(scheduleID) AS Wins FROM tblSchedules WHERE (teamID = " & teamID & ") AND (WL = 'W') AND (ysnActive=1) AND (NOT (strType = 'SCRIM'))"
        intCountWins = ExecuteScalar(SQLConnection, CommandType.Text, strSQL)

        strSQL = "SELECT COUNT(scheduleID) AS Wins FROM tblSchedules WHERE (teamID = " & teamID & ") AND (WL = 'L') AND (ysnActive=1) AND (NOT (strType = 'SCRIM'))"
        intCountLosses = ExecuteScalar(SQLConnection, CommandType.Text, strSQL)

        If ysnUpdate Then
            strSQL = "UPDATE tblTeams SET W = " & intCountWins & ", L = " & intCountLosses & ", WL = '" & intCountWins & "-" & intCountLosses & "' WHERE teamID = " & teamID
            ExecuteNonQuery(SQLConnection, CommandType.Text, strSQL)
        End If

        intWins = intCountWins
        intLosses = intCountLosses

    End Sub

    Shared Function GetCalcWLTeamDisplay(teamID As Long, ysnUpdate As Boolean) As String
        ' Added 4/23/2013...
        Dim strResult As String = "0-0"
        Dim intWins As Integer = 0
        Dim intLosses As Integer = 0

        GetCalcWLTeam(teamID, intWins, intLosses, ysnUpdate)

        strResult = intWins & "-" & intLosses

        Return strResult

    End Function

    Shared Function GetTiesTeam(ByVal teamID As Long) As Integer
        Dim intCountTies As Integer
        Dim strSQL As String

        ' ''If sportSchedule = "Soccer" Then
        ' ''    strSQL = "SELECT COUNT(scheduleID) AS Ties FROM tblSchedules WHERE (teamID = " & teamID & ") AND (WL = 'T') AND (ysnActive=1) AND (NOT (Location LIKE '%Scrimmage%') AND gameDate >= '3/1/2010')"
        ' ''Else
        strSQL = "SELECT COUNT(scheduleID) AS Ties FROM tblSchedules WHERE (teamID = " & teamID & ") AND (WL = 'T') AND (ysnActive=1) AND (NOT (Location LIKE '%Scrimmage%'))"
        ' ''End If
        intCountTies = ExecuteScalar(SQLConnection, CommandType.Text, strSQL)

        Return intCountTies
    End Function


    Shared Function SetWL(ByVal teamID As Long, ByVal wins As String, ByVal losses As String) As String
        Dim strSQL As String
        Dim intWins As Integer
        Dim intLosses As Integer
        Dim strWL As String

        If teamID = 0 Then
            strWL = "0-0"
        Else
            Try
                intWins = CInt(wins)
            Catch
                intWins = 0
            End Try

            Try
                intLosses = CInt(losses)
            Catch
                intLosses = 0
            End Try

            strWL = intWins & "-" & intLosses
            If intWins > 0 Or intLosses > 0 Then
                strSQL = "UPDATE tblTeams SET W = " & intWins & ", L=" & intLosses & ", WL = '" & intWins & "-" & intLosses & "' WHERE teamID = " & teamID
                ExecuteNonQuery(SQLConnection, CommandType.Text, strSQL)
            End If
        End If

        Return strWL
    End Function

    Shared Sub UpdateWL(ByVal teamID As Long)
        Dim intWins As Integer = 0
        Dim intLosses As Integer = 0

        GetCalcWLTeam(teamID, intWins, intLosses, True)

    End Sub

#End Region

End Class
