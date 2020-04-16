Imports OSSAARankings.SqlHelper

Public Class clsSchedules

    Shared Function FilterGameStatus(strStatus As String, sportID As String) As String
        ' Added 5/11/2017...
        Dim strResult As String = strStatus

        If sportID.Contains("Soccer") Or sportID.Contains("Basketball") Then
            If strStatus.Contains("OT") Then
                strResult = "OT"
            End If
        End If

        Return strResult
    End Function

    Shared Function FindSwapGame(SportID As String, TeamID As Long, oTeamID As Long, dtmDate As Date) As Long
        Dim strSQL As String = ""
        Dim intReturn As Long = 0

        Try
            strSQL = "SELECT scheduleID FROM tblSchedules WHERE TeamID = " & oTeamID & " AND oTeamID = " & TeamID & " AND gameDate = '" & Format(dtmDate, "yyyy-MM-dd") & " 00:00:00.000'"
            intReturn = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Catch
        End Try

        Return intReturn

    End Function

    Shared Function FindSwapGameTOSSAA(SportID As String, TeamID As Long, oTeamID As Long, strType As String) As Long
        Dim strSQL As String = ""
        Dim intReturn As Long = 0

        Try
            strSQL = "SELECT scheduleID FROM tblSchedules WHERE TeamID = " & oTeamID & " AND oTeamID = " & TeamID & " AND strType = '" & strType & "' AND intYear = " & clsFunctions.GetCurrentYear
            intReturn = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Catch
        End Try

        Return intReturn

    End Function


    Shared Function CalculateDistrictPoints(ByVal strType As String, ByVal intScore As Integer, ByVal intoScore As Integer, ByVal strStatus As String, ByVal strSportID As String) As Integer
        ' Added 10/30/2013...
        Dim intDistPoints As Integer = 0
        Dim intDistMax As Integer = GetDistrictPointsMax(strSportID)

        If strType = "DIST" Then
            If strStatus = "Final (OT)" Or strStatus = "Final (ExInn)" Or strStatus = "Final (Ext Inn)" Or strStatus = "Final (OT/Ext)" Then
                If intScore > intoScore Then
                    intDistPoints = 1
                ElseIf intoScore > intScore Then
                    intDistPoints = -1
                Else
                    intDistPoints = 0
                End If
            ElseIf strStatus = "Forfeit" Then
                If intScore > intoScore Then
                    intDistPoints = intDistMax
                ElseIf intoScore > intScore Then
                    intDistPoints = -intDistMax
                Else
                    intDistPoints = 0
                End If
            Else
                intDistPoints = intScore - intoScore
                If intDistPoints > intDistMax Then
                    intDistPoints = intDistMax
                ElseIf intDistPoints < -intDistMax Then
                    intDistPoints = -intDistMax
                End If
            End If
        Else
            intDistPoints = 0
        End If

        Return intDistPoints

    End Function

    Shared Function GetDistrictPointsMax(ByVal strSportGenderKey As String) As Integer
        ' 10/30/2013 added...
        Dim intMax As Integer = 0

        If strSportGenderKey.Contains("FPSoftball") Then
            intMax = 10
        ElseIf strSportGenderKey.Contains("Football") Then
            intMax = 15
        ElseIf strSportGenderKey.Contains("Soccer") Then
            intMax = 4
        Else
            intMax = 1
        End If

        Return intMax

    End Function

    Shared Function GetOSSAATourneyType(ByVal strType As String, ByVal intGame As Integer, objSite As Object) As String
        Dim strTournament As String = ""
        Dim strSite As String = ""

        ' Added 2/27/2014...
        Try
            strSite = objSite.ToString
        Catch ex As Exception
            strSite = ""
        End Try

        Select Case strType
            Case "TOSSAA1"
                strTournament = " - OSSAA Playoffs 1st Round " & strSite
            Case "TOSSAA32"
                strTournament = " - OSSAA Playoffs 1st Round " & strSite
            Case "TOSSAA16"
                strTournament = " - OSSAA Playoffs 2nd Round " & strSite
            Case "TOSSAA8"
                strTournament = " - OSSAA Quarter-Finals " & strSite
            Case "TOSSAA4"
                If strSite = "" Then
                    strTournament = " - OSSAA Semi-Finals " & strSite
                Else
                    strTournament = " - OSSAA Semi-Finals @ " & strSite
                End If
            Case "TOSSAA2"
                If strSite = "" Then
                    strTournament = " - <strong>OSSAA State Championship</strong>"
                Else
                    strTournament = " - <strong>OSSAA State Championship</strong> @ " & strSite
                End If

            Case "TOSSAAD"
                If strSite = "" Then
                    strTournament = " - OSSAA District Tournament"
                Else
                    strTournament = " - Districts @ " & strSite
                End If
            Case "TOSSAAR"
                If strSite = "" Then
                    strTournament = " - OSSAA Regional Tournament"
                Else
                    strTournament = " - Regionals @ " & strSite
                End If
            Case "TOSSAAA"
                If strSite = "" Then
                    strTournament = " - OSSAA Area Tournament"
                Else
                    strTournament = " - Area @ " & strSite
                End If
            Case "TOSSAASD"
                strTournament = " - OSSAA Dual State"
            Case "TOSSAAS"
                If intGame = 7 Then
                    strTournament = " - <strong>OSSAA State Championship</strong>"
                Else
                    If strSite = "" Then
                        strTournament = " - OSSAA State Tournament"
                    Else
                        strTournament = " - State Tournament @ " & strSite
                    End If
                End If
            Case Else
        End Select
        Return strTournament
    End Function

    Shared Function ChangeDatasetSchedule(ByVal ds As DataSet, ByVal ysnPublic As Boolean, ByVal intResultsOnly As Integer, ByVal intShowRanking As Integer, ByVal ysnReturnHyperlinks As Boolean) As DataSet
        Dim x As Integer
        Dim strOpposingTeam As String
        'Dim strShortDate As String
        Dim strWL As String
        Dim intCurrentRanking As Integer
        Dim strRanking As String
        Dim strAt As String
        Dim strResults As String
        Dim strResultsTemp As String
        Dim strGameDate As String = ""
        Dim strSportID As String = ""
        Dim gStatus As String = ""

        For x = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(x)

                ' Date...
                strGameDate = Format(.Item("gameDate"), "MM/dd/yy")

                Try
                    ' Removed 11/21/2017..
                    'gStatus = clsSchedules.FilterGameStatus(.Item("gStatus"), .Item("sportID"))
                    gStatus = .Item("gStatus")
                Catch ex As Exception
                    gStatus = ""
                End Try

                ' Opposing Team...
                If .Item("Opposing Team") Is System.DBNull.Value Then
                    Try
                        strOpposingTeam = .Item("OtherTeam")
                    Catch
                        strOpposingTeam = ""
                    End Try
                ElseIf .Item("Opposing Team") = "" Then
                    strOpposingTeam = ""
                Else
                    ' Get the ranking....
                    intCurrentRanking = .Item("orank")
                    If intCurrentRanking > 0 Then
                        strRanking = " #" & intCurrentRanking
                    Else
                        strRanking = ""
                    End If
                    ' Get the location...
                    If .Item("location") Is System.DBNull.Value Then
                        strAt = ""
                    ElseIf .Item("location") = "Away" Then
                        strAt = "@ "
                    Else
                        strAt = ""
                    End If
                    If .Item("oTeamID") = 0 Then
                        strOpposingTeam = strAt & .Item("Opposing Team")
                    Else
                        If ysnReturnHyperlinks = True Then
                            strOpposingTeam = strAt & "<a href='?sel=ScheduleTeam&t=" & .Item("oTeamID") & "' target='_self'>" & .Item("Opposing Team") & " (" & .Item("Class") & ")" & strRanking & "</a>"
                        Else
                            strOpposingTeam = strAt & .Item("Opposing Team") & " (" & .Item("Class") & ")" & strRanking
                        End If
                    End If
                End If

                ' Tournament info...
                strOpposingTeam = strOpposingTeam.Replace(" High School", "")
                If .Item("strType").ToString.Contains("TOSSAA") Then
                    strOpposingTeam = strOpposingTeam & clsSchedules.GetOSSAATourneyType(.Item("strType"), .Item("intGame"), .Item("NeutralSiteCoor"))
                ElseIf .Item("Tournament") Is System.DBNull.Value Then
                ElseIf .Item("Tournament") = "" Then
                Else
                    strOpposingTeam = strOpposingTeam & " @ " & .Item("Tournament")
                End If

                ' Results...
                strWL = ""
                If .Item("TotalScore") = 0 And .Item("oTotalScore") = 0 Then
                    ' A SHOW RESULTS SPORT...
                    strSportID = ""
                    Try
                        strSportID = .Item("sportID")
                    Catch ex As Exception

                    End Try

                    Try
                        strResultsTemp = .Item("strResults")
                    Catch ex As Exception
                        strResultsTemp = ""
                    End Try

                    If intResultsOnly = 1 Or intResultsOnly = 2 Then
                        If intResultsOnly = 2 Then
                            If Left(.Item("strType"), 1) = "T" Then
                                If strResultsTemp <> "" Then
                                    strResults = "Results"
                                    If ysnPublic = False Then ' Show to Membership...
                                        strResults = "<a href='?sel=ScheduleEdit&g=" & .Item("scheduleId") & "' target='_self' title='" & strResultsTemp & "'>" & strResults & "</a>"
                                    End If
                                Else
                                    strGameDate = strGameDate & " @ " & .Item("Time")
                                    Try
                                        strResults = clsSports.GetNoScore(.Item("sportID"), .Item("strType"), gStatus, False, "", "")
                                    Catch
                                        strResults = "No Results"
                                    End Try
                                    If ysnPublic = False Then ' Show to Membership...
                                        strResults = "<a href='?sel=ScheduleEdit&g=" & .Item("scheduleId") & "' target='_self'>" & strResults & "</a>"
                                    End If
                                End If
                            Else
                                ' NOT A SHOW RESULTS SPORT...
                                strGameDate = strGameDate & " @ " & .Item("Time")
                                If .Item("strType") = "SCRIM" Then
                                    strResults = "Scrimmage"
                                ElseIf gStatus = "Rain Out" Or gStatus = "Suspended" Or gStatus = "Postponed" Or gStatus = "Canceled" Or gStatus = "Forfeit" Or gStatus = "Terminated" Then
                                    strResults = .Item("gStatus")
                                Else
                                    strResults = "No Score"
                                End If
                                If ysnPublic = False Then ' Show to Membership...
                                    strResults = "<a href='?sel=ScheduleEdit&g=" & .Item("scheduleId") & "' target='_self'>" & strResults & "</a>"
                                End If
                            End If
                        Else
                            Dim strResults1 As String = ""
                            If .Item("strResults") Is System.DBNull.Value Then
                                strResults1 = ""
                            Else
                                Try
                                    strResults1 = .Item("strResults")
                                Catch
                                    strResults1 = ""
                                End Try
                            End If
                            If strResults1 <> "" Then
                                strResults = "Results"
                                If ysnPublic = False Then ' Show to Membership...
                                    strResults = "<a href='?sel=ScheduleEdit&g=" & .Item("scheduleId") & "' target='_self' title='" & strResults1 & "'>" & strResults & "</a>"
                                End If
                            Else
                                strGameDate = strGameDate & " @ " & .Item("Time")
                                Try
                                    strResults = clsSports.GetNoScore(.Item("sportID"), .Item("strType"), gStatus, False, "", "")
                                Catch
                                    strResults = "No Results"
                                End Try
                                If ysnPublic = False Then ' Show to Membership...
                                    strResults = "<a href='?sel=ScheduleEdit&g=" & .Item("scheduleId") & "' target='_self'>" & strResults & "</a>"
                                End If
                            End If
                        End If
                    Else
                        ' NOT A SHOW RESULTS SPORT...
                        strGameDate = strGameDate & " @ " & .Item("Time")
                        If .Item("strType") = "SCRIM" Then
                            strResults = "Scrimmage"
                        ElseIf gStatus = "Rain Out" Or gStatus = "Suspended" Or gStatus = "Postponed" Or gStatus = "Canceled" Or gStatus = "Forfeit" Or gStatus = "Terminated" Then
                            strResults = .Item("gStatus")
                        Else
                            strResults = "No Score"
                        End If
                        If ysnPublic = False Then ' Show to Membership...
                            strResults = "<a href='?sel=ScheduleEdit&g=" & .Item("scheduleId") & "' target='_self'>" & strResults & "</a>"
                        End If
                    End If
                Else
                    If intResultsOnly = 2 Then
                        strWL = ""
                    Else
                        If .Item("TotalScore") > .Item("oTotalScore") Then
                            strWL = "W"
                        ElseIf .Item("TotalScore") = .Item("oTotalScore") Then
                            strWL = "T"
                        Else
                            strWL = "L"
                        End If
                    End If
                    ' Show to public...

                    Dim strTeamSportID As String = ""
                    Try
                        strTeamSportID = .Item("teamSportID")
                    Catch ex As Exception
                        strTeamSportID = ""
                    End Try

                    If intResultsOnly = 1 And .Item("strType") = "TOURNEY" And (.Item("TotalScore") > 0 And .Item("oTotalScore") = 0) And strTeamSportID.Contains("Golf") Then      ' Added 3/9/2015...
                        strResults = "Score : " & .Item("TotalScore")
                    ElseIf gStatus.Contains("Final") Or gStatus.Contains("Forfeit") Then
                        If intResultsOnly = 2 And .Item("strType") = "TOURNEY" And (.Item("oTotalScore") = 0) Then
                            strResults = "Place : " & .Item("TotalScore")
                        Else
                            strResults = .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & strWL & " " & gStatus
                        End If
                    Else
                        strResults = .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & strWL & " " & gStatus     ' Added gStatus 11/21/2017...
                    End If
                    If ysnPublic = False Then ' Show to Membership...
                        strResults = "<a href='?sel=ScheduleEdit&g=" & .Item("scheduleId") & "' target='_self'>" & strResults & "</a>"
                    End If
                End If

                ' Write the Results...
                .Item("Date") = strGameDate
                If .Item("strType") Is System.DBNull.Value Then

                Else
                    If .Item("strType") = "DIST" Then
                        strOpposingTeam = strOpposingTeam & " **"
                    End If
                End If
                .Item("Opposing Team") = strOpposingTeam
                .Item("Results") = strResults

            End With
        Next

        Return ds
    End Function

    Shared Function ChangeDatasetSmall(ByVal ds As DataSet, ByVal ysnShowHL As Integer, strSportID As String) As DataSet
        Dim x As Integer
        Dim strShortDate As String
        Dim strWL As String
        Dim intCurrentRanking As Integer
        Dim strRanking As String
        Dim strAt As String
        Dim strResults As String

        Dim strGameDate As String = ""
        Dim strOpposingTeam As String
        Dim strStatus As String = ""

        Dim intShowHL As Integer = 1

        Try
            intShowHL = ysnShowHL
        Catch ex As Exception
            intShowHL = 1
        End Try

        For x = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(x)
                ' Date...
                strShortDate = Format(.Item("gameDate"), "MM/dd/yy")
                intCurrentRanking = .Item("orank")

                If intCurrentRanking > 0 Then
                    strRanking = " # " & intCurrentRanking
                Else
                    strRanking = ""
                End If
                ' Get the location...
                If .Item("location") Is System.DBNull.Value Then
                    strAt = ""
                ElseIf .Item("location") = "Away" Then
                    strAt = "@ "
                Else
                    strAt = ""
                End If
                If .Item("oTeamID") = 0 Then
                    If .Item("Class") Is System.DBNull.Value Then
                        strOpposingTeam = strAt & .Item("Opposing Team") & " "
                    Else
                        strOpposingTeam = strAt & .Item("Opposing Team") & " (" & .Item("Class") & ")"
                    End If
                    'strOpposingTeam = strAt & "<a href='?sel=ScheduleTeam&t=0' target='_self'>" & .Item("Opposing Team") & " (" & .Item("Class") & ")</a>"
                Else
                    If intShowHL > 0 Then
                        If strRanking = "" Then
                            strOpposingTeam = strAt & "<a href='?sel=ScheduleTeam&t=" & .Item("oTeamID") & "' target='_self'>" & .Item("Opposing Team") & " (" & .Item("Class") & ")</a>"
                        Else
                            strOpposingTeam = strAt & "<a href='?sel=ScheduleTeam&t=" & .Item("oTeamID") & "' target='_self'>" & .Item("Opposing Team") & " <strong>(" & .Item("Class") & "-#" & .Item("orank") & ")</strong></a>"
                        End If
                    Else
                        ' Added 8/27/2013...
                        If strRanking = "" Then
                            strOpposingTeam = strAt & .Item("Opposing Team") & " (" & .Item("Class") & ")</a>"
                        Else
                            strOpposingTeam = strAt & .Item("Opposing Team") & " <strong>(" & .Item("Class") & "-#" & .Item("orank") & ")</strong></a>"
                        End If
                    End If
                End If
                'End If

                strOpposingTeam = strOpposingTeam.Replace(" High School", "")
                If .Item("strType").ToString.Contains("TOSSAA") Then
                    strOpposingTeam = strOpposingTeam & clsSchedules.GetOSSAATourneyType(.Item("strType"), .Item("intGame"), .Item("NeutralSiteCoor"))
                ElseIf .Item("Tournament") Is System.DBNull.Value Then
                ElseIf .Item("Tournament") = "" Then
                Else
                    strOpposingTeam = strOpposingTeam & " @ " & .Item("Tournament")
                End If

                ' Results...
                strWL = ""
                If .Item("TotalScore") = 0 And .Item("oTotalScore") = 0 Then
                    strGameDate = strShortDate.Replace("12:00:00 AM", "") & " @ " & .Item("Time")
                    strWL = "-"
                    strResults = ""
                Else
                    If .Item("TotalScore") > .Item("oTotalScore") Then
                        strWL = "W"
                    ElseIf .Item("TotalScore") = .Item("oTotalScore") Then
                        strWL = "T"
                    Else
                        strWL = "L"
                    End If
                    Dim gStatus As String = ""
                    Try
                        ' Changed 11/21/2017...
                        'gStatus = clsSchedules.FilterGameStatus(.Item("gStatus"), strSportID)
                        gStatus = .Item("gStatus")
                    Catch
                    End Try
                    If .Item("strResults") Is System.DBNull.Value Then
                        If gStatus = "Rain Out" Or gStatus = "Suspended" Or gStatus = "Postponed" Or gStatus = "Canceled" Or gStatus = "Forfeit" Or gStatus = "Terminated" Then
                            strResults = gStatus
                        ElseIf gStatus.Contains("Final (") Then
                            strResults = .Item("TotalScore") & "-" & .Item("oTotalScore") & " : " & gStatus
                        Else
                            If strSportID.Contains("Wrestling") And .Item("strType") = "TOURNEY" And .Item("TotalScore") > 0 And .Item("oTotalScore") = 0 Then
                                strResults = "Place : " & .Item("TotalScore")
                            ElseIf strSportID.Contains("Golf") And .Item("strType") = "TOURNEY" And .Item("TotalScore") > 0 And .Item("oTotalScore") = 0 Then
                                strResults = "Score : " & .Item("TotalScore")
                            Else
                                strResults = .Item("TotalScore") & "-" & .Item("oTotalScore")
                            End If
                        End If
                    Else
                        If strSportID.Contains("Wrestling") And .Item("strType") = "TOURNEY" And .Item("TotalScore") > 0 And .Item("oTotalScore") = 0 Then
                            strResults = "Place : " & .Item("TotalScore") & " - " & .Item("strResults")
                        ElseIf strSportID.Contains("Golf") And .Item("strType") = "TOURNEY" And .Item("TotalScore") > 0 And .Item("oTotalScore") = 0 Then
                            strResults = "Score : " & .Item("TotalScore") & " - " & .Item("strResults")
                        Else
                            strResults = .Item("TotalScore") & "-" & .Item("oTotalScore") & " : " & .Item("strResults")
                        End If
                    End If
                    strOpposingTeam = strOpposingTeam
                    strGameDate = strShortDate.Replace("12:00:00 AM", "")
                End If

                ' Write Results..
                .Item("WL") = strWL
                .Item("Date") = strGameDate
                If .Item("strType") Is System.DBNull.Value Then
                Else
                    If .Item("strType") = "DIST" Then
                        strResults = strResults & " **"
                    End If
                End If
                .Item("Opposing Team") = strOpposingTeam & " <strong>" & strResults & "</strong>"

            End With
        Next

        Return ds
    End Function

    Shared Function LoadSchedulesList(ByVal schoolID As Long) As DataSet
        Dim strSQL As String = ""
        Dim ds As DataSet

        strSQL = "SELECT DISTINCT tblTeams.teamID, tblTeams.sportID, tblSports.SportGenderKey, tblSports.GenderSport1, dbo.tblSports.Class AS strClass "
        strSQL = strSQL & "FROM tblTeams INNER JOIN tblSports ON tblTeams.sportID = tblSports.sportID INNER JOIN tblSchedules ON tblTeams.teamID = tblSchedules.teamID "
        strSQL = strSQL & "WHERE tblTeams.schoolID = " & schoolID & " AND tblTeams.intYear = " & clsFunctions.GetCurrentYear
        strSQL = strSQL & " ORDER BY tblSports.GenderSport1"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return ds
    End Function

	Shared Function GetScheduleGameTypeDataSet(ByVal strSport As String) As DataSet
		Dim strSQL As String
		Dim ds As DataSet

		strSQL = "SELECT strType, strDescription FROM ossaauser.tblScheduleGameTypes WHERE strSport = '" & strSport & "' ORDER BY intSort, strDescription"
		ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

		Return ds

	End Function

	Shared Function GetScheduleTeamSQL(ByVal intTeamID As Long) As String
        Dim sql As String = ""

        sql = "SELECT 'Date' AS [Date], tblSchedules.gameTime AS [Time], CASE WHEN tblTeams.SchoolName IS NULL THEN OtherTeam ELSE tblTeams.SchoolName END AS [Opposing Team], tblSchedules.Location AS [Location], 'Results' AS [Results], tblSchedules.strResults, 'Game Results' AS [View], 'Opponent' AS [Hyperlink], "
        sql = sql & "tblSchedules.NeutralSiteCoor, tblSchedules.District, tblSchedules.intGame, tblSchedules.OtherTeam, tblSchedules.Tournament, tblSchedules.TotalScore, tblSchedules.strLink, tblSchedules.oTeamID, tblSchedules.oTotalScore, tblSchedules.gameDate, tblSports.Class, tblSports.sportID, tblTeams.teamID, tblSchedules.gStatus, tblSchedules.rank, tblSchedules.orank, tblSchedules.WL, tblSchedules.scheduleId, tblSchedules.strType, tblSchedules.sportID AS teamSportID "
        sql = sql & "FROM tblSchool INNER JOIN "
        sql = sql & "tblTeams ON tblSchool.schoolID = tblTeams.schoolID INNER JOIN "
        sql = sql & "tblSports ON tblTeams.sportID = tblSports.sportID RIGHT OUTER JOIN "
        sql = sql & "tblSchedules ON tblTeams.teamID = tblSchedules.oTeamID "
        sql = sql & "WHERE (tblSchedules.teamID = " & intTeamID & " AND tblSchedules.ysnActive <> 0) "
        sql = sql & "ORDER BY tblSchedules.gamedate, tblSchedules.gametime, tblSchedules.Tournament "

        Return sql
    End Function

    Shared Function GetScheduleSportDaySQL(ByVal strSportID As String, ByVal strClass As String, ByVal strDate As String, ByVal strType As String, nogames As Integer, Optional ysnScroller As Boolean = False) As String
        Dim sql As String = ""
        Dim sqlAll As String = ""
        Dim strTop20 As String = ""

        sql = "SELECT tblSchedules.scheduleID, tblSchedules.intGame, tblSchedules.teamID, tblSchedules.District, tblSchedules.strType, tblTeams.SchoolName AS School, "
        sql = sql & "tblSchedules.NeutralSiteCoor, tblSchedules.oTeamID, tblSchool_1.SchoolName AS oSchool, tblSchedules.gamedate, tblSchedules.gStatus, "
        sql = sql & "tblSchedules.gametime, tblSchedules.OtherTeam, tblSchedules.Location,  tblSchedules.strLink, tblSchedules.rank, tblSchedules.orank, "
        sql = sql & "tblSchedules.Tournament, tblSchedules.TotalScore, tblSchedules.oTotalScore, tblSchedules.rank, tblSchedules.OtherTeam, "
        sql = sql & "tblSchedules.strResults AS results, "
        sql = sql & "tblSchedules.orank, tblSchedules.dtmStamp, tblSports_1.Class, tblSports_1.sportID, tblSports_1.SportGenderKey, "
        sql = sql & "0 AS DuplicateGame, tblSchool.SchoolName AS strSort, "
        sql = sql & "tblSports.Class AS oClass, tblSports.sportID AS oSportID, tblSports.SportGenderKey As oSportGenderKey, 'Game' as Game, 'Score' as Score, 'Summary' as Summary "
        sql = sql & ", '<a href=mailto:' + dbo.GetTeamsEmailAddress(tblSchedules.TeamID) + '>Email</a> : <a href=mailto:' + dbo.GetTeamsEmailAddress(tblSchedules.oTeamID) + '>Email</a>' AS strEmail "
        sql = sql & "FROM tblSchool AS tblSchool_1 INNER JOIN "
        sql = sql & "tblTeams AS tblTeams_1 ON tblSchool_1.schoolID = tblTeams_1.schoolID INNER JOIN "
        sql = sql & "tblSports ON tblTeams_1.sportID = tblSports.sportID RIGHT OUTER JOIN "
        sql = sql & "tblSports AS tblSports_1 INNER JOIN "
        sql = sql & "tblTeams ON tblSports_1.sportID = tblTeams.sportID INNER JOIN "
        sql = sql & "tblSchool ON tblTeams.schoolID = tblSchool.schoolID RIGHT OUTER JOIN "
        sql = sql & "tblSchedules ON tblTeams.teamID = tblSchedules.teamID ON "
        sql = sql & "tblTeams_1.teamID = tblSchedules.oTeamID "
        sqlAll = sql

        If strClass.Contains("Top") Then
            strClass = strClass.Replace(" Top 20", "")
            strSportID = strSportID.Replace(" Top 20", "")
            strClass = strClass.Replace(" Top 15", "")
            strSportID = strSportID.Replace(" Top 15", "")
            strClass = strClass.Replace(" Top 12", "")
            strSportID = strSportID.Replace(" Top 12", "")
            'strTop20 = " AND ((rank <> 0 AND tblSports_1.Class = '" & strClass & "' AND tblSports_1.sportID = '" & strSportID & "') OR (oRank <> 0 AND tblSports.Class = '" & strClass & "' AND tblSports.sportID = '" & strSportID & "')) "
            strTop20 = " AND (rank <> 0 AND tblSports_1.Class = '" & strClass & "' AND tblSports_1.sportID = '" & strSportID & "') "
        Else
            strTop20 = ""
        End If

        If strType = "WEEK4" Then
            If strClass = "ALL" Or strClass = "Select Class..." Or strClass = "" Then
                sqlAll = sqlAll & "WHERE (tblSchedules.sportID Like '" & strSportID & "%') AND (tblSchedules.ysnActive <> 0) AND (tblSchedules.strType = 'TOSSAA4' OR tblSchedules.strType = 'TOSSAA2') AND (gameDate > '12/8/2013' AND gameDate <= '12/15/2013') " & strTop20
            Else
                sqlAll = sqlAll & "WHERE (tblSchedules.sportID = '" & strSportID & "') AND (tblSchedules.ysnActive <> 0) AND ((tblSports.Class = '" & strClass & "') OR (tblSports_1.Class = '" & strClass & "')) AND (tblSchedules.strType = 'TOSSAA4' OR tblSchedules.strType = 'TOSSAA2') AND (gameDate > '12/8/2013' AND gameDate <= '12/15/2013') " & strTop20
            End If
        ElseIf strType = "WEEK3" Then
            If strClass = "ALL" Or strClass = "Select Class..." Or strClass = "" Then
                sqlAll = sqlAll & "WHERE (tblSchedules.sportID Like '" & strSportID & "%') AND (tblSchedules.ysnActive <> 0) AND (tblSchedules.strType = 'TOSSAA4' OR tblSchedules.strType = 'TOSSAA8') AND (gameDate > '11/25/2013' AND gameDate <= '12/1/2013') " & strTop20
            Else
                sqlAll = sqlAll & "WHERE (tblSchedules.sportID = '" & strSportID & "') AND (tblSchedules.ysnActive <> 0) AND ((tblSports.Class = '" & strClass & "') OR (tblSports_1.Class = '" & strClass & "')) AND (tblSchedules.strType = 'TOSSAA4' OR tblSchedules.strType = 'TOSSAA8') AND (gameDate > '11/25/2013' AND gameDate <= '12/1/2013') " & strTop20
            End If
        ElseIf strType = "WEEK2" Then       ' Specific for Playoff Football Week #2...
            If strClass = "ALL" Or strClass = "Select Class..." Or strClass = "" Then
                sqlAll = sqlAll & "WHERE (tblSchedules.sportID Like '" & strSportID & "%') AND (tblSchedules.ysnActive <> 0) AND (tblSchedules.strType = 'TOSSAA16' OR tblSchedules.strType = 'TOSSAA8') AND (gameDate > '11/18/2013' AND gameDate <= '11/24/2013') " & strTop20
            Else
                sqlAll = sqlAll & "WHERE (tblSchedules.sportID = '" & strSportID & "') AND (tblSchedules.ysnActive <> 0) AND ((tblSports.Class = '" & strClass & "') OR (tblSports_1.Class = '" & strClass & "')) AND (tblSchedules.strType = 'TOSSAA16' OR tblSchedules.strType = 'TOSSAA8') AND (gameDate > '11/18/2013' AND gameDate <= '11/24/2013') " & strTop20
            End If
        ElseIf strDate = "ALL" Or strDate = "" Then
            If strClass = "ALL" Or strClass = "Select Class..." Or strClass = "" Then
                sqlAll = sqlAll & "WHERE (tblSchedules.sportID Like '" & strSportID & "%') AND (tblSchedules.ysnActive <> 0) AND (tblSchedules.strType = '" & strType & "') " & strTop20
            Else
                sqlAll = sqlAll & "WHERE (tblSchedules.sportID = '" & strSportID & "') AND (tblSchedules.ysnActive <> 0) AND ((tblSports.Class = '" & strClass & "') OR (tblSports_1.Class = '" & strClass & "')) AND (tblSchedules.strType = '" & strType & "') " & strTop20
            End If
        Else
            If strClass = "ALL" Or strClass = "Select Class..." Or strClass = "" Then
                sqlAll = sqlAll & "WHERE (tblSchedules.sportID Like '" & strSportID & "%') AND (tblSchedules.ysnActive <> 0) AND (tblSchedules.gamedate = CONVERT(DATETIME, '" & strDate & "', 102)) " & strTop20
            Else
                sqlAll = sqlAll & "WHERE (tblSchedules.sportID = '" & strSportID & "') AND (tblSchedules.ysnActive <> 0) AND ((tblSports.Class = '" & strClass & "') OR (tblSports_1.Class = '" & strClass & "')) AND (tblSchedules.gamedate = CONVERT(DATETIME, '" & strDate & "', 102)) " & strTop20
            End If
        End If

        ' 9/28/2015 added...
        If nogames = 1 Then
            sqlAll = sqlAll & "AND (tblSchedules.TotalScore = 0 AND tblSchedules.oTotalScore = 0) "
        End If

        sqlAll = sqlAll & "AND tblSchool.SchoolName IS NOT NULL "

        If ysnScroller Then
            sqlAll = sqlAll & "ORDER BY tblSchedules.TotalScore DESC"
        ElseIf strTop20 = "" Then
            sqlAll = sqlAll & "ORDER BY tblTeams.SchoolName"
        Else
            sqlAll = sqlAll & "ORDER BY tblSchedules.rank"
        End If

        'clsLog.LogSQL(sqlAll)

        Return sqlAll

    End Function


    ' TODO : Verify that this works correctly?
    Shared Function GetTournaments(ByVal intTeamID As Long, ByVal strSport As String, ByVal intYear As Integer) As DataSet
        Dim ds As DataSet
        Dim strSQL As String

        strSport = GetScheduleSport(strSport)

        strSQL = "SELECT tournamentID, TourneyName As Tournament FROM tblSchedulesTournament WHERE (ysnActive = 1 AND Sport = '" & strSport & "' AND intYear = " & intYear & ")"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return ds
    End Function


    Shared Function GetTournamentGame(ByVal sID As Long) As String
        Dim strSQL As String
        Dim strTournament As String

        If sID = 0 Then
            ' Do nothing...
            strTournament = ""
        Else

            '''''strSport = GetScheduleSport(strSport)
            strSQL = "SELECT [Tournament] FROM tblSchedules WHERE scheduleID = " & sID
            Try
                strTournament = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            Catch
                strTournament = ""
            End Try
        End If

        Return strTournament
    End Function

    '''''Shared Function IsDistrictGame(ByVal intTeamID As Long, ByVal intTeamIDo As Long, ByVal strSport As String) As Boolean
    Shared Function IsDistrictGame(ByVal intTeamID As Long, ByVal intTeamIDo As Long) As Boolean
        ' Calculate if this is a district game...
        Dim strSQL As String
        Dim ds As DataSet
        Dim ysnDistrictGame As Boolean = False

        strSQL = "SELECT tblTeams.teamID, tblTeams.District, tblTeams_1.teamID AS teamIDo, tblTeams_1.District AS Districto, tblSports.Class, "
        strSQL = strSQL & "tblSports_1.Class AS Classo FROM  tblTeams AS tblTeams_1 INNER JOIN "
        strSQL = strSQL & "tblSports AS tblSports_1 ON tblTeams_1.sportID = tblSports_1.sportID CROSS JOIN "
        strSQL = strSQL & "tblTeams INNER JOIN "
        strSQL = strSQL & "tblSports ON tblTeams.sportID = tblSports.sportID "
        strSQL = strSQL & "WHERE (tblTeams.teamID = " & intTeamID & ") AND (tblTeams_1.teamID = " & intTeamIDo & ")"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Try
            With ds.Tables(0).Rows(0)
                If (.Item("District") = .Item("Districto")) And (.Item("Class") = .Item("Classo")) Then
                    ysnDistrictGame = True
                Else
                    ysnDistrictGame = False
                End If
            End With
        Catch
            ysnDistrictGame = False
        End Try

        Return ysnDistrictGame
    End Function

    ' TODO : NOT NEEDED???
    Shared Function GetScheduleSport(ByVal strSport As String) As String

        If InStr(strSport, "Baseball") > 0 Then
            strSport = "Baseball"
        ElseIf InStr(strSport, "Softball") > 0 Then
            strSport = "Baseball"
        ElseIf InStr(strSport, "Soccer") > 0 Then
            strSport = "Soccer"
        ElseIf InStr(strSport, "Golf") > 0 Then
            strSport = "Golf"
        ElseIf InStr(strSport, "Track") > 0 Then
            strSport = "Track"
        ElseIf InStr(strSport, "Basketball") > 0 Then
            strSport = ""
        ElseIf InStr(strSport, "Wrestling") > 0 Then
            strSport = "Wrestling"
        ElseIf InStr(strSport, "Tennis") > 0 Then
            strSport = "Tennis"
        End If

        Return strSport
    End Function


    Shared Function ChangeDataSet(ByVal ds As DataSet, ByVal strSportSchedule As String, ByVal ysnPublic As Boolean, ByVal intTeamID2 As Long) As DataSet
        Dim x As Long
        Dim strOpposingTeam As String
        Dim strShortDate As String
        Dim intCurrentRanking As Integer
        Dim strDistrict As String
        Dim gStatus As String = ""

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then

        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                With ds.Tables(0).Rows(x)
                    'If strSportSchedule = "Football" Or strSportSchedule = "Soccer" Then
                    '    If .Item("District") = True Then strDistrict = "**" Else strDistrict = ""
                    'Else
                    '    strDistrict = ""
                    'End If
                    If .Item("strType") = "DIST" Then strDistrict = "**" Else strDistrict = ""

                    Try
                        gStatus = clsSchedules.FilterGameStatus(.Item("gStatus"), strSportSchedule)
                        'gStatus = .Item("gStatus")
                    Catch ex As Exception
                        gStatus = ""
                    End Try

                    ' Date...
                    strShortDate = Format(.Item("gameDate"), "MM/dd/yy")
                    .Item("Date") = strShortDate.Replace("12:00:00 AM", "") & " @ " & .Item("Time")

                    ' Opposing Team...
                    If .Item("oTeamID") = 0 Then
                        Try
                            strOpposingTeam = .Item("OtherTeam")
                        Catch
                            Try
                                strOpposingTeam = .Item("Tournament")
                            Catch
                                strOpposingTeam = ""
                            End Try
                        End Try
                        'strOpposingTeam = "</a>" & strOpposingTeam
                        .Item("otherTeam") = strOpposingTeam
                    ElseIf .Item("Opposing Team") Is System.DBNull.Value Then
                        strOpposingTeam = .Item("OtherTeam")
                        .Item("otherTeam") = strOpposingTeam
                    Else
                        If .Item("teamID") Is System.DBNull.Value Then
                            intCurrentRanking = 0
                        Else
                            intCurrentRanking = clsRankings.GetCurrentRank(.Item("sportID"), .Item("teamID"), "")
                        End If
                        If intCurrentRanking > 0 Then
                            'strOpposingTeam = Trim(.Item("Opposing Team")) & "</a> (" & .Item("Class") & ") #" & intCurrentRanking
                            strOpposingTeam = Trim(.Item("Opposing Team")) & " (" & .Item("Class") & ") #" & intCurrentRanking
                            .Item("otherTeam") = strOpposingTeam
                        Else
                            strOpposingTeam = "<a href='../TeamPage.aspx?t=" & .Item("oteamID") & "' "
                            If ysnPublic Then
                                strOpposingTeam = strOpposingTeam & "target='_self'>"
                            Else
                                strOpposingTeam = strOpposingTeam & "target='_blank'>"
                            End If
                            'strOpposingTeam = strOpposingTeam & .Item("Opposing Team") & " (" & .Item("Class") & ") " & "</a>"
                            'strOpposingTeam = strOpposingTeam & Trim(.Item("Opposing Team")) & "</a> (" & .Item("Class") & ") "
                            strOpposingTeam = strOpposingTeam & Trim(.Item("Opposing Team")) & " (" & .Item("Class") & ") "
                            .Item("otherTeam") = .Item("Opposing Team")
                        End If
                    End If
                    'End If
                    strOpposingTeam = strOpposingTeam.Replace(" High School", "")

                    ' Tournament...
                    If .Item("Tournament") Is System.DBNull.Value Then
                    ElseIf .Item("Tournament") = "" Then
                    Else
                        If strSportSchedule = "Wrestling" Then
                            ' Do nothing...
                        Else
                            strOpposingTeam = strOpposingTeam & " @ " & .Item("Tournament")
                        End If
                    End If
                    .Item("Opposing Team") = strOpposingTeam & strDistrict

                    ' Score field...
                    If strSportSchedule = "Wrestling" Then
                        If .Item("TotalScore") = 0 And .Item("oTotalScore") = 0 Then
                            .Item("Results") = " -"
                        Else
                            .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & .Item("WL")
                        End If
                    ElseIf strSportSchedule = "Golf" Or strSportSchedule = "Tennis" Or strSportSchedule = "Track" Then
                        If .Item("Results") Is System.DBNull.Value Then
                            .Item("Results") = "No Results"
                        ElseIf .Item("Results") = "" Then
                            .Item("Results") = "No Results"
                        Else
                            .Item("Results") = "Results"
                        End If
                    ElseIf strSportSchedule = "Swimming" Then
                        If .Item("opposingTeamID") = 0 Then
                            If Not .Item("Tournament") Is System.DBNull.Value Then
                                If .Item("strResults") Is System.DBNull.Value Then
                                    .Item("Results") = clsSports.GetNoScore(.Item("sportID"), .Item("strType"), gStatus, False, "", "")
                                ElseIf .Item("strResults") = "" Then
                                    .Item("Results") = clsSports.GetNoScore(.Item("sportID"), .Item("strType"), gStatus, False, "", "")
                                Else
                                    .Item("Results") = clsSports.GetNoScore(.Item("sportID"), .Item("strType"), gStatus, False, "", "")
                                End If
                            Else
                                If .Item("TotalScore") = 0 And .Item("oTotalScore") = 0 Then
                                    .Item("Results") = clsSports.GetNoScore(.Item("sportID"), .Item("strType"), gStatus, False, "", "")
                                Else
                                    .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & .Item("WL")
                                End If
                            End If
                        ElseIf .Item("TotalScore") = 0 And .Item("oTotalScore") = 0 Then
                            .Item("Results") = clsSports.GetNoScore(.Item("sportID"), .Item("strType"), gStatus, False, "", "")
                        Else
                            .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & .Item("WL")
                        End If

                    ElseIf gStatus = "Postponed" Or gStatus = "Forfeit" Or gStatus = "Canceled" Or gStatus = "Cancelled" Or gStatus = "Rain Out" Or gStatus = "Terminated" Then
                        .Item("Results") = gStatus

                    ElseIf .Item("WL") Is System.DBNull.Value Then
                        .Item("Results") = clsSports.GetNoScore(.Item("sportID"), .Item("strType"), gStatus, False, "", "")

                    ElseIf .Item("WL") = "-" Then
                        If strSportSchedule = "Soccer" Then
                            If .Item("TotalScore") = 0 And .Item("oTotalScore") = 0 Then
                                .Item("Results") = clsSports.GetNoScore(.Item("sportID"), .Item("strType"), gStatus, False, "", "")
                            Else
                                .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore")
                            End If
                        Else
                            .Item("Results") = clsSports.GetNoScore(.Item("sportID"), .Item("strType"), gStatus, False, "", "")
                        End If

                    ElseIf strSportSchedule = "Volleyball" Then
                        If .Item("WL") = "W" Then
                            .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore") & " W"
                        ElseIf .Item("WL") = "L" Then
                            .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore") & " L"
                        ElseIf gStatus = "Tie" Or .Item("WL") = "T" Then
                            .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore") & " Tie"
                        ElseIf .Item("WL") = "-" And (.Item("TotalScore") > 0 And .Item("oTotalScore") > 0) Then
                            .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore") & " Tie"
                        Else
                            .Item("Results") = clsSports.GetNoScore(.Item("sportID"), .Item("strType"), gStatus, False, "", "")
                        End If

                    Else
                        If gStatus = "Postponed" Or gStatus = "Forfeit" Or gStatus = "Canceled" Or gStatus = "Cancelled" Or gStatus = "Rain Out" Then
                            .Item("Results") = gStatus
                        ElseIf .Item("WL") = "-" Then
                            .Item("Results") = clsSports.GetNoScore(.Item("sportID"), .Item("strType"), gStatus, False, "", "")
                        Else
                            If gStatus = "OT" Or gStatus.Contains("Final (") Then
                                .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & .Item("WL") & " " & gStatus

                            ElseIf gStatus = "8 Inn" Or gStatus = "9 Inn" Or gStatus = "10 Inn" Or gStatus = "Ex Inn" Then
                                .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & .Item("WL") & " " & gStatus

                            ElseIf gStatus = "Shoot Out" Then
                                If strSportSchedule = "Soccer" Then
                                    .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & .Item("WL") & " SHO (" & .Item("OT") & "-" & .Item("oOT") & ")"
                                Else
                                    .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & .Item("WL") & " SHO"
                                End If
                            Else
                                .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & .Item("WL")
                            End If
                        End If

                    End If

                    ' '' ''If strSportSchedule = "Swimming" Then
                    ' '' ''    .Item("Results2") = GetSwimmingBoysResults(.Item("scheduleID"), intTeamID2)
                    ' '' ''End If

                End With
            Next
        End If

        Return ds

    End Function

    Shared Function CalcTop20(ByVal rankValue As Integer, ByVal teamID As Long, ByVal scheduleSport As String, ByVal intShowRanking As Integer) As String
        Dim strSQL As String
        Dim ds2 As DataSet
        Dim tooltip As String

        If scheduleSport = "Basketball" Then
            scheduleSport = ""
        End If

        ' Calc the Last 5 Games for this team...
        strSQL = "SELECT RIGHT(CONVERT(char(10), tblSchedules" & scheduleSport & ".gamedate, 11), 7) AS gamedate, RTRIM(ISNULL(REPLACE(tblSchools.School, 'High School', ''), "
        strSQL = strSQL & "REPLACE(tblSchedules" & scheduleSport & ".OtherTeam, 'High School', ''))) AS oppSchool, tblSchedules" & scheduleSport & ".TotalScore, tblSchedules" & scheduleSport & ".oTotalScore, tblSchedules" & scheduleSport & ".oRank, "
        If scheduleSport = "Swimming" Or scheduleSport = "Wrestling" Then
            strSQL = strSQL & "tblSchedules" & scheduleSport & ".WL, 0 AS OT, tblSchedules" & scheduleSport & ".TotalScore, ISNULL(tblSports.Class, 'TRN') AS Class, tblSchedules" & scheduleSport & ".gStatus "
        Else
            strSQL = strSQL & "tblSchedules" & scheduleSport & ".WL, tblSchedules" & scheduleSport & ".OT, tblSchedules" & scheduleSport & ".TotalScore, ISNULL(tblSports.Class, 'TRN') AS Class, tblSchedules" & scheduleSport & ".gStatus "
        End If
        strSQL = strSQL & "FROM tblSchools INNER JOIN "
        strSQL = strSQL & "tblTeams ON tblSchools.schoolID = tblTeams.schoolID INNER JOIN "
        strSQL = strSQL & "tblSports ON tblTeams.sportID = tblSports.sportID RIGHT OUTER JOIN "
        strSQL = strSQL & "tblSchedules" & scheduleSport & " ON tblTeams.teamID = tblSchedules" & scheduleSport & ".opposingTeamID "
        If rankValue <= 20 And rankValue > 0 Then
            strSQL = strSQL & "WHERE ((tblSchedules" & scheduleSport & ".teamID = " & teamID & ") AND (tblSchedules" & scheduleSport & ".ysnActive=1) AND (((tblSchedules" & scheduleSport & ".TotalScore > 0) OR (tblSchedules" & scheduleSport & ".oTotalScore > 0)) AND (tblSchedules" & scheduleSport & ".oRank <= " & rankValue & " AND tblSchedules" & scheduleSport & ".oRank <> 0))) "
        Else
            strSQL = strSQL & "WHERE (tblSchedules" & scheduleSport & ".teamID = " & teamID & ") AND (tblSchedules" & scheduleSport & ".ysnActive=1) AND (((tblSchedules" & scheduleSport & ".TotalScore > 0) OR (tblSchedules" & scheduleSport & ".oTotalScore > 0)) OR (tblSchedules" & scheduleSport & ".gStatus <> 'Final')) "
        End If
        strSQL = strSQL & "ORDER BY CONVERT(datetime, tblSchedules" & scheduleSport & ".gamedate) DESC"
        ds2 = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        tooltip = ""
        If ds2 Is Nothing Then
            tooltip = "No Games"
        ElseIf ds2.Tables.Count = 0 Then
            tooltip = "No Games"
        ElseIf ds2.Tables(0).Rows.Count = 0 Then
            tooltip = "No Games"
        Else
            tooltip = ""
            For z = 0 To ds2.Tables(0).Rows.Count - 1
                With ds2.Tables(0).Rows(z)
                    If .Item("gStatus") = "8 Inn" Or .Item("gStatus") = "9 Inn" Or .Item("gStatus") = "10 Inn" Or .Item("gStatus") = "Ex Inn" Then
                        tooltip = tooltip & .Item("WL") & " " & .Item("gStatus") & " " & .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & .Item("gamedate") & " " & .Item("oppSchool") & " (" & .Item("class") & ")"
                    ElseIf (.Item("gStatus") <> "Final" And .Item("gStatus") <> "OT") Then
                        tooltip = tooltip & .Item("gStatus") & " - " & .Item("gamedate") & " " & .Item("oppSchool") & " (" & .Item("class") & ")"
                    ElseIf .Item("OT") > 0 And .Item("OT") <> .Item("TotalScore") Then
                        tooltip = tooltip & .Item("WL") & " OT " & .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & .Item("gamedate") & " " & .Item("oppSchool") & " (" & .Item("class") & ")"
                    ElseIf .Item("gStatus") = "OT" Then
                        tooltip = tooltip & .Item("WL") & " OT " & .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & .Item("gamedate") & " " & .Item("oppSchool") & " (" & .Item("class") & ")"
                    Else
                        tooltip = tooltip & .Item("WL") & " " & .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & .Item("gamedate") & " " & .Item("oppSchool") & " (" & .Item("class") & ")"
                    End If
                    If .Item("oRank") > 0 Then
                        tooltip = tooltip & " #" & .Item("oRank") & vbCrLf
                    Else
                        tooltip = tooltip & vbCrLf
                    End If

                End With
            Next
        End If

        Return tooltip

    End Function


End Class
