Public Class clsBSData

#Region "GridHeadersAndDetails"

    'Shared Function GetBootstrapCardRowsWithDetail() As String
    '    Dim strRows As String = ""
    '    Dim strSQL As String = ""
    '    Dim ds As DataSet
    '    Dim dsd As DataSet
    '    Dim x As Integer = 0
    '    Dim y As Integer = 0
    '    Dim strCoach As String = ""

    '    strSQL = "SELECT TOP 50 RANK() OVER (ORDER BY intWins DESC) As Rank, CAST(intWins AS varchar(5)) + '-' + strCoachesName + ' (' + strLastSchool + ')' AS strDisplayWins, * FROM tblCoachesRecords WHERE strSportGenderKey = 'Football' AND intWins >= 195 ORDER BY intWins DESC"
    '    ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionIWATG, CommandType.Text, strSQL)

    '    For x = 0 To ds.Tables(0).Rows.Count - 1
    '        With ds.Tables(0).Rows(x)
    '            strCoach = .Item("strCoachesName")
    '            ' Header of Row...
    '            strRows += "<article class='card card-custom'>"
    '            strRows += "<div Class='card-standing-position card-standing-counter'></div>"
    '            strRows += "<div Class='card-header' id='accordion1Heading" & (x + 1) & "' role='tab'>"
    '            strRows += "<div Class='card-standing-team-item'>"
    '            strRows += "<div Class='card-standing-team'>"
    '            'strRows += "<div Class='card-standing-team-figure'><img src='site/images/football/football32.gif' alt='' width='32' height='41'/>"
    '            'strRows += "</div>"
    '            strRows += "<div Class='card-standing-team-title'>"
    '            strRows += "<div Class='card-standing-team-name-1'>" & .Item("strCoachesName") & "</div>"
    '            strRows += "<div Class='card-standing-team-country'>" & .Item("strLastSchool") & "</div>"
    '            strRows += "</div>"
    '            strRows += "</div>"
    '            strRows += "<div Class='card-standing-number'>" & .Item("intYears") & "</div>"
    '            strRows += "<div Class='card-standing-number'>" & .Item("intWins") & "</div>"
    '            strRows += "<div Class='card-standing-number'>" & .Item("intLosses") & "</div>"
    '            strRows += "<div Class='card-standing-button'><a class='card-standing-toogle material-icons-remove collapsed' role='button' data-toggle='collapse' data-parent='#accordion1' href='#accordion1Collapse" & (x + 1) & "' aria-controls='accordion1Collapse" & (x + 1) & "'></a></div>"
    '            strRows += "</div>"
    '            strRows += "</div>"

    '            ' Accordian Collapse...
    '            strRows += "<div Class='collapse' id='accordion1Collapse" & (x + 1) & "' role='tabpanel' aria-labelledby='accordion1Heading" & (x + 1) & "'>"
    '            strRows += "<div Class='card-body'>"

    '            strSQL = "SELECT * FROM tblYearlyRecords WHERE Coach = '" & strCoach & "' ORDER BY Year DESC"
    '            dsd = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionIWATG, CommandType.Text, strSQL)

    '            If dsd Is Nothing Then
    '            ElseIf dsd.Tables.Count = 0 Then
    '            ElseIf dsd.Tables(0).Rows.Count = 0 Then
    '            Else
    '                For y = 0 To dsd.Tables(0).Rows.Count - 1

    '                    strRows += "<div Class='card-standing-team-details'>"
    '                    strRows += "<div Class='card-standing-year' >" & dsd.Tables(0).Rows(y).Item("Year") & "</div>"
    '                    strRows += "<div Class='card-standing-game-status'>" & dsd.Tables(0).Rows(y).Item("School") & "</div>"
    '                    strRows += "<div Class='card-standing-number'>" & dsd.Tables(0).Rows(y).Item("intW") & "</div>"
    '                    strRows += "<div Class='card-standing-number'>" & dsd.Tables(0).Rows(y).Item("intL") & "</div>"
    '                    strRows += "<div Class='card-standing-number'>" & dsd.Tables(0).Rows(y).Item("intT") & "</div>"
    '                    strRows += "</div>"
    '                Next
    '            End If
    '            strRows += "</div>"
    '            strRows += "</div>"

    '            strRows += "</Article>"
    '        End With
    '    Next

    '    Return strRows

    'End Function

    'Shared Function GetBootstrapCardRowsNoDetail1Column(strType As String, strParameterField As String, strParameterValue As String) As String
    '    Dim strRows As String = ""
    '    Dim strSQL As String = ""
    '    Dim ds As DataSet
    '    Dim x As Integer = 0
    '    Dim y As Integer = 0
    '    Dim strConnectionString As String = ""

    '    Select Case strType
    '        Case "FPRunsScored"
    '            If strParameterField = "" Then
    '                strSQL = "SELECT TOP 75 FORMAT(CAST(intRunsPG AS decimal(18,2)),'0.00') + ' - ' + strSchoolName + ' (' + strClass + ')' AS strDisplay FROM mviewFastPitchRunsPG ORDER BY intRunsPG DESC"
    '            Else
    '                strSQL = "SELECT FORMAT(CAST(intRunsPG AS decimal(18,2)),'0.00') + ' - ' + strSchoolName + ' (' + strClass + ')' AS strDisplay FROM mviewFastPitchRunsPG WHERE " & strParameterField & "='" & strParameterValue & "' ORDER BY intRunsPG DESC"
    '            End If
    '            strConnectionString = SqlHelper.SQLConnectionOSSAARankings
    '        Case "BAFRunsScored"
    '            If strParameterField = "" Then
    '                strSQL = "SELECT TOP 75 FORMAT(CAST(intRunsPG AS decimal(18,2)),'0.00') + ' - ' + strSchoolName + ' (' + strClass + ')' AS strDisplay FROM mviewBaseballFallRunsPG ORDER BY intRunsPG DESC"
    '            Else
    '                strSQL = "SELECT FORMAT(CAST(intRunsPG AS decimal(18,2)),'0.00') + ' - ' + strSchoolName + ' (' + strClass + ')' AS strDisplay FROM mviewBaseballFallRunsPG WHERE " & strParameterField & "='" & strParameterValue & "' ORDER BY intRunsPG DESC"
    '            End If
    '            strConnectionString = SqlHelper.SQLConnectionOSSAARankings
    '        Case "FBWinningStreaks"
    '            strSQL = "SELECT *, CAST(intWins AS varchar) + ' - ' + strTeam + ' (' + strDateStart + ' - ' + strDateEnd + ') (' + strTeamStartLoss + ' - ' + strTeamEndLoss + ')' AS strDisplay FROM tblFootballWinningStreaks WHERE strType = '11-Man' AND strState = 'OK' ORDER BY intWins DESC"
    '            strConnectionString = SqlHelper.SQLConnectionIWATG
    '    End Select

    '    ds = SqlHelper.ExecuteDataset(strConnectionString, CommandType.Text, strSQL)

    '    For x = 0 To ds.Tables(0).Rows.Count - 1
    '        With ds.Tables(0).Rows(x)
    '            ' Header of Row...
    '            strRows += "<article class='card card-custom'>"
    '            strRows += "<div Class='card-standing-position card-standing-counter'></div>"
    '            strRows += "<div Class='card-header' id='accordion1Heading" & (x + 1) & "' role='tab'>"
    '            strRows += "<div Class='card-standing-team-item'>"
    '            strRows += "<div Class='card-standing-team'>"
    '            'strRows += "<div Class='card-standing-team-figure'><img src='site/images/football/football32.gif' alt='' width='32' height='41'/>"
    '            'strRows += "</div>"
    '            strRows += "<div Class='card-standing-team-title'>"
    '            strRows += "<div Class='card-standing-team-name'>" & .Item("strDisplay") & "</div>"
    '            'strRows += "<div Class='card-standing-team-country'>" & .Item("strDisplay") & "</div>"
    '            strRows += "</div>"
    '            strRows += "</div>"
    '            strRows += "<div Class='card-standing-button'><a class='card-standing-toogle material-icons-remove collapsed' role='button' data-toggle='collapse' data-parent='#accordion1' href='#accordion1Collapse" & (x + 1) & "' aria-controls='accordion1Collapse" & (x + 1) & "'></a></div>"
    '            strRows += "</div>"
    '            strRows += "</div>"

    '            '' Accordian Collapse...
    '            'strRows += "<div Class='collapse' id='accordion1Collapse" & (x + 1) & "' role='tabpanel' aria-labelledby='accordion1Heading" & (x + 1) & "'>"
    '            'strRows += "<div Class='card-body'>"

    '            'strSQL = "SELECT * FROM tblYearlyRecords WHERE Coach = '" & strCoach & "' ORDER BY Year DESC"
    '            'dsd = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionIWATG, CommandType.Text, strSQL)

    '            'If dsd Is Nothing Then
    '            'ElseIf dsd.Tables.Count = 0 Then
    '            'ElseIf dsd.Tables(0).Rows.Count = 0 Then
    '            'Else
    '            '    For y = 0 To dsd.Tables(0).Rows.Count - 1

    '            '        strRows += "<div Class='card-standing-team-details'>"
    '            '        strRows += "<div Class='card-standing-year' >" & dsd.Tables(0).Rows(y).Item("Year") & "</div>"
    '            '        strRows += "<div Class='card-standing-game-status'>" & dsd.Tables(0).Rows(y).Item("School") & "</div>"
    '            '        strRows += "<div Class='card-standing-number'>" & dsd.Tables(0).Rows(y).Item("intW") & "</div>"
    '            '        strRows += "<div Class='card-standing-number'>" & dsd.Tables(0).Rows(y).Item("intL") & "</div>"
    '            '        strRows += "<div Class='card-standing-number'>" & dsd.Tables(0).Rows(y).Item("intT") & "</div>"
    '            '        strRows += "</div>"
    '            '    Next
    '            'End If
    '            'strRows += "</div>"
    '            'strRows += "</div>"

    '            strRows += "</Article>"
    '        End With
    '    Next

    '    Return strRows

    'End Function


#End Region

#Region "GetDataSources"
    Shared Function GetDataSourceDropDown_States() As DataSet
        'Dim ds As DataSet
        'Dim strSQL As String = "SELECT strStateAbb AS strValueField, strState AS strTextField FROM tblStates WHERE ysnActive <> 0"
        'ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionIWATG, CommandType.Text, strSQL)
        'Return ds
    End Function

    Shared Function GetDataSourceDropDown_Sports(strStateAbb As String) As DataSet
        'Dim ds As DataSet
        'Dim strSQL As String = "SELECT strSportGenderKey AS strValueField, strSport AS strTextField FROM tblSports WHERE strState = '" & strStateAbb & "' ORDER BY strSportGenderKey"
        'ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionIWATG, CommandType.Text, strSQL)
        'Return ds
    End Function

    Shared Function GetDataSourceDropDown_Years(strStateAbb As String, strSportGenderKey As String) As DataSet
        'Dim ds As DataSet
        'Dim strSQL As String = "SELECT DISTINCT intYear AS strValueField, intYear AS strTextField FROM tblStateChampions WHERE strState = '" & strStateAbb & "' AND strSportGenderKey = '" & strSportGenderKey & "' ORDER BY intYear DESC"
        'ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionIWATG, CommandType.Text, strSQL)
        'Return ds
    End Function

    Shared Function GetDataSourceDropDown_Classes(strStateAbb As String, strSportGenderKey As String) As DataSet
        'Dim ds As DataSet
        'Dim strSQL As String = "SELECT DISTINCT strClass AS strValueField, strClass AS strTextField FROM tblStateChampions WHERE strState = '" & strStateAbb & "' AND strSportGenderKey = '" & strSportGenderKey & "' ORDER BY strClass DESC"
        'ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionIWATG, CommandType.Text, strSQL)
        'Return ds
    End Function
#End Region


    Shared Function GetScheduleSportDaySQL(ByVal strSportID As String, ByVal strClass As String, ByVal strDate As String, ByVal strType As String, nogames As Integer, Optional ysnScroller As Boolean = False) As String
        Dim sql As String = ""
        Dim sqlAll As String = ""
        Dim strTop20 As String = ""

        sql = "Select tblSchedules.scheduleID, tblSchedules.intGame, tblSchedules.teamID, tblSchedules.District, tblSchedules.strType, tblTeams.SchoolName As School, "
        sql = sql & "tblSchedules.NeutralSiteCoor, tblSchedules.oTeamID, tblSchool_1.SchoolName As oSchool, tblSchedules.gamedate, tblSchedules.gStatus, "
        sql = sql & "tblSchedules.gametime, tblSchedules.OtherTeam, tblSchedules.Location,  tblSchedules.strLink, tblSchedules.rank, tblSchedules.orank, "
        sql = sql & "tblSchedules.Tournament, tblSchedules.TotalScore, tblSchedules.oTotalScore, tblSchedules.rank, tblSchedules.OtherTeam, "
        sql = sql & "tblSchedules.strResults As results, "
        sql = sql & "tblSchedules.orank, tblSchedules.dtmStamp, tblSports_1.Class, tblSports_1.sportID, tblSports_1.SportGenderKey, "
        sql = sql & "0 As DuplicateGame, tblSchool.SchoolName As strSort, "
        sql = sql & "tblSports.Class As oClass, tblSports.sportID As oSportID, tblSports.SportGenderKey As oSportGenderKey, 'Game' as Game, 'Score' as Score, 'Summary' as Summary "
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

    Shared Function FilterGameStatus(strStatus As String, sportID As String) As String
        ' Copied from OSSAARankings.com 8/17/2019...
        Dim strResult As String = strStatus

        If sportID.Contains("Soccer") Or sportID.Contains("Basketball") Then
            If strStatus.Contains("OT") Then
                strResult = "OT"
            End If
        End If

        Return strResult
    End Function

    Shared Function GetSportString(strSportGenderKey As String) As String
        Select Case strSportGenderKey
            Case "FPSoftball"
                Return "Fast Pitch"
            Case "BaseballFall", "FallBaseball"
                Return "Fall Baseball"
            Case Else
                Return strSportGenderKey
        End Select
    End Function

    Shared Function GetStateString(strStateAbb As String) As String
        Select Case strStateAbb
            Case "AL"
                Return "Alabama"
            Case "AZ"
                Return "Arizona"
            Case "CO"
                Return "Colorado"
            Case "MI"
                Return "Michigan"
            Case "MO"
                Return "Missouri"
            Case "OK"
                Return "Oklahoma"
            Case "TX"
                Return "Texas"
            Case Else
                Return strStateAbb
        End Select
    End Function

End Class
