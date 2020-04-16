Public Class clsSports

    Shared Function GetPlayoffSchedule(ByVal strSportID As String) As String         ' 11/4/2013 added...
        Dim strSQL As String
        Dim strReturn As String = ""
        strSQL = "SELECT strPlayoffSchedule FROM tblSports WHERE SportID = '" & strSportID & "'"
        Try
            strReturn = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Catch
        End Try
        Return strReturn
    End Function

    Shared Function GetGenderSportFromSGK(strSportGenderKey As String) As String
        Dim strSQL As String
        strSQL = "SELECT GenderSport FROM tblSports WHERE SportGenderKey = '" & strSportGenderKey & "'"
        Return SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
    End Function


    Shared Function GetSportsForSchoolDS(intSchoolID As Long, intYear As Integer) As DataSet
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT tblTeams.teamID, GenderSport1 AS SportDisplay, memberID, tblSports.sportID, tblTeams.SportGenderKey AS SportGenderKey  "
        strSQL = strSQL & "FROM tblTeams INNER JOIN "
        strSQL = strSQL & "tblSports ON tblTeams.sportID = tblSports.sportID "
        strSQL = strSQL & "WHERE tblTeams.schoolID = " & intSchoolID & " AND tblTeams.intYear = " & intYear

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return ds

    End Function

    Shared Function GetContactsDataset(strSport As String) As DataSet
        Dim strSQL As String = ""
        Dim ds As DataSet

        strSQL = "SELECT * FROM ossaauser.tblSportsContacts WHERE strSport = '" & strSport & "' ORDER BY intSort"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return ds

    End Function

    Shared Function GetNoScore(ByVal strSportID As String, ByVal strType As String, ByVal strStatus As String, ByVal ysnMakeBold As Boolean, ByVal strTime As String, ByVal strDate As String) As String
        Dim strResults As String
        Dim strDay As String = ""

        If strDate = "" Then
        Else
            Dim dtmDate As Date
            dtmDate = strDate
            strDay = dtmDate.DayOfWeek.ToString
            If strDay = "Friday" Then
                strDay = "FRI, "
            ElseIf strDay = "Saturday" Then
                strDay = "<strong>SAT, </strong>"
            ElseIf strDay = "Thursday" Then
                strDay = "<strong>THUR, </strong>"
            End If

        End If

        If strType = "SCRIM" Then
            strResults = "Scrimmage"
        ElseIf strStatus = "Rain Out" Or strStatus = "Suspended" Or strStatus = "Postponed" Or strStatus = "Canceled" Or strStatus = "Forfeit" Or strStatus = "Cancelled" Or strStatus = "Terminated" Then
            If ysnMakeBold Then
                strResults = "<strong>" & strStatus & "</strong>"
            Else
                strResults = strStatus
            End If
        ElseIf strTime <> "" Then
            strResults = "@ " & strDay & strTime
        ElseIf strSportID.Contains("Wrestling") Or strSportID.Contains("Swimming") Or strSportID.Contains("CrossCountry") Or strSportID.Contains("Golf") Or strSportID.Contains("Tennis") Or strSportID.Contains("Track") Then
            strResults = "No Results"
        Else
            strResults = "No Score"
        End If

        Return strResults

    End Function

    Shared Function ShowResults(strSportID As String) As Boolean

        If strSportID = "" Then
            Return False
        Else
            If strSportID.Contains("Wrestling") Or strSportID.Contains("Swimming") Or strSportID.Contains("CrossCountry") Or strSportID.Contains("Golf") Or strSportID.Contains("Tennis") Or strSportID.Contains("Track") Then
                Return True
            Else
                Return False
            End If
        End If

    End Function

End Class
