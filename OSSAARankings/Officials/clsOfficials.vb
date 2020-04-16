Public Class clsOfficials

    Shared Sub LogRegistration(strType As String, strEvent As String, strSport As String, strIP As String, strUserAgent As String, intOSSAAID As Long, strEmail As String, strState As String, strZipCode As String, doRegistration As String, regStatus As String)
        Dim strSQL As String = ""

        strSQL = "INSERT INTO prodOfficialsRegistration (strType, intOSSAAID, strSport, strEvent, strIP, strUserAgent, strEmail, strState, strZipCode, doRegistration, regStatus) VALUES ("
        strSQL = strSQL & "'" & strType & "', " & intOSSAAID & ", '" & strSport & "', '" & strEvent & "', '" & strIP & "', '" & strUserAgent & "', '" & strEmail & "', '" & strState & "', '" & strZipCode & "', '" & doRegistration & "', '" & regStatus & "')"

        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

    End Sub

    ' Added 6/25/2018...
    Shared Function GetZipCodeZone(strZipCode As String) As Integer
        Dim strSQL As String = "SELECT TOP 1 Zone FROM viewOfficialsZipCodeZone WHERE strZip = '" & strZipCode & "'"
        Dim intValue As Integer

        Try
            intValue = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        Catch ex As Exception
            intValue = 0
        End Try

        Return intValue
    End Function

    Shared Function GetZipCode(strEmailAddress As String, intOSSAAID As Long, strZipCodeIn As String) As String
        Dim strReturn As String = ""

        Try
            strReturn = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strZip FROM prodOfficials WHERE strEmail = '" & strEmailAddress & "' AND intOSSAAID > 0")
        Catch ex As Exception
            strReturn = ""
        End Try

        If strReturn = "" Then
            If strZipCodeIn Is Nothing Then
                strReturn = ""
            ElseIf strZipCodeIn = "" Then
                strReturn = ""
            Else
                strReturn = strZipCodeIn
            End If
        End If

        Return strReturn
    End Function

    Shared Function GetRegistrationURL(strRegistrationType As String, strSportAbb As String) As String
        ' Added 5/29/2019...
        Dim strSQL As String = ""
        Dim strURL As String = ""

        strSQL = "SELECT strURL FROM prodOfficialsArbiterRegistrations WHERE intYear = 20 AND strRegistrationType = '" & strRegistrationType & "' AND strRegistrationSport = '" & strSportAbb & "'"
        strURL = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        Return strURL
    End Function
    Shared Sub SetRegistrationStatus(intOSSAAID As Long, strEmail As String, strStatus As String)
        ' 5/31/2018...
        Dim strSQL As String
        strSQL = "UPDATE prodOfficials SET strRegisteredThisYear = '" & strStatus & "' WHERE strEmail = '" & strEmail & "' AND intOSSAAID > 0"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
    End Sub

    Shared Function GetRegistrationStatus(intOSSAAID As Long, strEmail As String, Optional lookInRegistrationTable As Boolean = False) As String
        Dim strSQL As String = ""
        Dim strStatus As String = ""

        If lookInRegistrationTable Then
            strSQL = "SELECT TOP 1 regStatus FROM prodOfficialsRegistration WHERE strEmail = '" & strEmail & "' AND intOSSAAID = " & intOSSAAID & " AND (Not regStatus Is Null AND Not regStatus = '') ORDER BY ID"
        Else
            strSQL = "SELECT TOP 1 strRegisteredThisYear FROM prodOfficials WHERE strEmail = '" & strEmail & "' AND intOSSAAID > 0 ORDER BY intOSSAAID DESC"
        End If

        Try
            strStatus = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        Catch
            strStatus = ""
        End Try
        Return strStatus
    End Function

    Shared Function GetOfficialsInfo(strEmail As String, intOSSAAID As Int32, ByRef strFullName As String) As String
        Dim strResult As String = "OK"
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT * FROM prodOfficials WHERE strEmail = '" & strEmail & "' AND intOSSAAID = " & intOSSAAID & " AND intOSSAAID > 0"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        If ds Is Nothing Then
            strResult = "NONE"
        ElseIf ds.Tables.Count = 0 Then
            strResult = "NONE"
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            strResult = "NONE"
        Else
            strFullName = ds.Tables(0).Rows(0).Item("strLastName") & ", " & ds.Tables(0).Rows(0).Item("strFirstName")
            strResult = "OK"
        End If

        Return strResult

    End Function

    Shared Function GetEligibleOfficialsSQL(strSelectedSport As String, strOrderByClause As String, ysnShowRatings As Boolean, ByRef strMessage As String) As String
        Dim strSQL As String
        Dim strWhereClause As String
        Dim strYears As String

        If strOrderByClause = "OfficialRating" Then strOrderByClause = "OfficialRating DESC"
        If strOrderByClause = "intYears" Then strOrderByClause = "intYears DESC"
        If strOrderByClause = "strLastName" Then strOrderByClause = "strLastName, strFirstName" ' Added 12/12/2012...
        If strOrderByClause = "strCity" Then strOrderByClause = "UPPER([strCity])"

        Select Case strSelectedSport
            Case "Baseball"
                strWhereClause = "([ysnCurrentBaseball] = -1) And (intTestBaseball >= " & ConfigurationManager.AppSettings("GetOfficialsPassingScore") & ") And (intOSSAAID > 0) And (intAge >= 18)"
                strMessage = "For " & strSelectedSport
                strYears = "[intYearsBaseball] As [intYears]"
            Case "Football"
                strWhereClause = "(([ysnCurrentFootball] = -1) And (intTestFootball >= " & ConfigurationManager.AppSettings("GetOfficialsPassingScore") & ") And (intOSSAAID > 0) And (intAge >= 18))"
                ' THIS WAS REMOVED 7/31/2015 per SR...
                'strWhereClause = "(([ysnCurrentFootball] = -1) And (intTestFootball >= 75) And (intOSSAAID > 0) And (intAge >= 18) And (strState = 'OK'))"
                'strWhereClause = strWhereClause & " OR (([ysnCurrentFootball] = -1) AND (intOSSAAID > 0) AND (intAge >= 18) AND (strState <> 'OK'))"
                strMessage = "for " & strSelectedSport
                strYears = "[intYearsFootball] As [intYears]"
            Case "Basketball"
                strWhereClause = "(([ysnCurrentBasketball] = -1) And (intTestBasketball >= " & ConfigurationManager.AppSettings("GetOfficialsPassingScore") & ") And (intOSSAAID > 0) AND (intAge >= 18) AND (strState = 'OK'))"
                strWhereClause = strWhereClause & " OR (([ysnCurrentBasketball] = -1) AND (intTestBasketball >= " & ConfigurationManager.AppSettings("GetOfficialsPassingScore") & ") AND (intOSSAAID > 0) AND (intAge >= 18) AND (strState <> 'OK'))"
                strMessage = "for " & strSelectedSport
                strYears = "[intYearsBasketball] As [intYears]"
            Case "Softball FP"
                strWhereClause = "([ysnCurrentSoftball] = -1) And (intTestSoftball >= " & ConfigurationManager.AppSettings("GetOfficialsPassingScore") & ") And (intOSSAAID > 0) AND (intAge >= 18)"
                strMessage = "for " & strSelectedSport
                strYears = "[intYearsSoftball] As [intYears]"
            Case "Softball SP"
                strWhereClause = "([ysnCurrentSoftballSP] = -1) And (intTestSoftballSP >= " & ConfigurationManager.AppSettings("GetOfficialsPassingScore") & ") And (intOSSAAID > 0) AND (intAge >= 18)"
                'strWhereClause = "([ysnCurrentSoftballSP] = -1)"
                strMessage = "for " & strSelectedSport
                strYears = "[intYearsSoftballSP] As [intYears]"
            Case "Volleyball"
                strWhereClause = "([ysnCurrentVolleyball] = -1) And (intTestVolleyball >= " & ConfigurationManager.AppSettings("GetOfficialsPassingScore") & ") And (intOSSAAID > 0) AND (intAge >= 18)"
                strMessage = "for " & strSelectedSport
                strYears = "[intYearsVolleyball] As [intYears]"
            Case "Wrestling"
                strWhereClause = "([ysnCurrentWrestling] = -1) And (intTestWrestling >= " & ConfigurationManager.AppSettings("GetOfficialsPassingScore") & ") And (intOSSAAID > 0) AND (intAge >= 18)"
                strMessage = "for " & strSelectedSport
                strYears = "[intYearsWrestling] As [intYears]"
            Case "Soccer"
                strWhereClause = "([ysnCurrentSoccer] = -1) And (intTestSoccer >= " & ConfigurationManager.AppSettings("GetOfficialsPassingScore") & ") And (intOSSAAID > 0) AND (intAge >= 18)"
                'strWhereClause = "([ysnCurrentSoccer] = -1)"
                strMessage = "for " & strSelectedSport
                strYears = "[intYearsSoccer] As [intYears]"
            Case "Track"
                strWhereClause = "([ysnCurrentTrack] = -1) And (intTestTrack >= " & ConfigurationManager.AppSettings("GetOfficialsPassingScore") & ") And (intOSSAAID > 0) AND (intAge >= 18)"
                strMessage = "for " & strSelectedSport
                strYears = "[intYearsTrack] As [intYears]"
            Case Else
                strWhereClause = "([ysnCurrentFootball] = 100)"
                strYears = "[intYearsFootball] As [intYears]"
                strMessage = ""
        End Select

        If strSelectedSport = "Football" Then
            strSQL = "SELECT *, UPPER([strLastName] + ', ' + [strFirstName]) AS [FullName], UPPER([strCity]) AS strCity, UPPER([strState]) AS strState, [strClassFootball] AS [OfficialClass], [dblRatingFootball] AS [OfficialRating], " & strYears & ", 0 As Miles FROM [prodOfficials] WHERE " & strWhereClause & " ORDER BY " & strOrderByClause
        ElseIf strSelectedSport = "Basketball" Then
            strSQL = "SELECT *, UPPER([strLastName] + ', ' + [strFirstName]) AS [FullName], UPPER([strCity]) AS strCity, UPPER([strState]) AS strState, [strClassBasketball] AS [OfficialClass], [dblRatingBasketball] AS [OfficialRating], " & strYears & ", 0 As Miles FROM [prodOfficials] WHERE " & strWhereClause & " ORDER BY " & strOrderByClause
        Else
            strSQL = "SELECT *, UPPER([strLastName] + ', ' + [strFirstName]) AS [FullName], UPPER([strCity]) AS strCity, UPPER([strState]) AS strState, '-' AS [OfficialClass], 0 AS [OfficialRating], " & strYears & ", 0 As Miles FROM [prodOfficials] WHERE " & strWhereClause & " ORDER BY " & strOrderByClause
        End If

        Dim intCount As Integer = 0
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, Data.CommandType.Text, "SELECT Count(*) AS intCount FROM prodOfficials WHERE " & strWhereClause)

        If intCount = 0 Then
            strMessage = "0 found"
        Else
            strMessage = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & intCount & " Eligible Officials " & strMessage
        End If

        Return strSQL

    End Function

    Shared Function GetNumberOfSavedOfficials(strSport As String, intDistrictKey As Integer, strClass As String) As Integer
        Dim intCount As Integer = 0
        Dim strSQL As String = ""

        Select Case strSport
            Case "Basketball"
                strSQL = "SELECT COUNT(Id) FROM tblDistrictPrefsDetailBB WHERE idDistrictPrefs = " & intDistrictKey & " AND intYear = " & clsFunctions.GetCurrentYear & " AND strClass = '" & strClass & "'"
                intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Case Else
                intCount = 0
        End Select

        Return intCount
    End Function

    Shared Function GetDefaultYear() As Integer
        Return ConfigurationManager.AppSettings("CurrentYear")
    End Function
    ' TODO : Change this each week...
    Shared Function GetPrefClassBasketball() As String
        Return ConfigurationManager.AppSettings("PrefClassBasketball")
    End Function


    Shared Function IsEligibleUnusedOfficialFootball(ByVal intOfficialID As Long) As String
        Dim strReturn As String = "OK"
        Dim intValue As Integer = 0

        strReturn = IsEligibleOfficialFootball(intOfficialID, False)

        If strReturn = "NOHEAT" Then
            Return "NO HEAT CERT ON FILE"
        ElseIf strReturn = "NOCONCUSSION" Then
            Return "NO CONCUSSION ON FILE"
        ElseIf Not strReturn.Contains("FAILED") Then
            ' REMOVED CDW 10/15/2015...
            'Dim strSQL As String

            'strSQL = "SELECT intPlayoffCrewU AS intPlayoffCrew FROM prodOfficialsPlayoffs WHERE intPlayoffCrewU = " & intOfficialID
            'strSQL = strSQL & " UNION SELECT intPlayoffCrewHL AS intPlayoffCrew FROM prodOfficialsPlayoffs WHERE intPlayoffCrewHL = " & intOfficialID
            'strSQL = strSQL & " UNION SELECT intPlayoffCrewLJ AS intPlayoffCrew FROM prodOfficialsPlayoffs WHERE intPlayoffCrewLJ = " & intOfficialID
            'strSQL = strSQL & " UNION SELECT intPlayoffCrewBJ AS intPlayoffCrew FROM prodOfficialsPlayoffs WHERE intPlayoffCrewBJ = " & intOfficialID

            'Try
            '    intValue = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            '    If intValue = 0 Then
            '    Else
            '        strReturn = "DUPLICATE OFFICIAL"
            '    End If
            'Catch
            '    strReturn = "DUPLICATE OFFICIAL"
            'End Try
        Else

        End If

        Return strReturn

    End Function

    Shared Function IsEligibleOfficialFootball(ByVal intOfficialID As Long, ysnByPassHeat As Boolean) As String
        Dim strReturn As String = "FAILED"
        Dim strSQL As String
        Dim ds As DataSet

        ' CDW swapped back 10/18/2019 for WHITE HAT 2019 FOOTBALL PLAYOFF AVAILABILITY...
        strSQL = "SELECT strFirstName + ' ' + strLastName + ' (' + CASE WHEN strClassFootball Is Null THEN 'X' ELSE strClassFootball END + '-' + CASE WHEN dblRatingFootball Is Null THEN 'NONE' ELSE CAST(dblRatingFootball AS VARCHAR(10)) END + ')' AS OName,ysnHeat, ysnConcussion FROM prodOfficials WHERE ([ysnCurrentFootball] = -1) And (intTestFootball >= " & ConfigurationManager.AppSettings("GetOfficialsPassingScore") & ") And (intOSSAAID = " & intOfficialID & ")"
        'strSQL = "SELECT strFirstName + ' ' + strLastName + ' (' + CASE WHEN strClassFootball Is Null THEN 'X' ELSE strClassFootball END + '-' + CASE WHEN dblRatingFootball Is Null THEN 'NONE' ELSE CAST(dblRatingFootball AS VARCHAR(10)) END + ')' AS OName, ysnHeat, ysnConcussion FROM viewOfficialsFootballEligiblePlayoffs WHERE intOSSAAID = " & intOfficialID
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
            strReturn = "FAILED (20)"
        ElseIf ds.Tables.Count = 0 Then
            strReturn = "FAILED (21)"
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            strReturn = "FAILED (22)"
        Else
            If intOfficialID = 7556 Then
                strReturn = ds.Tables(0).Rows(0).Item("OName")
            ElseIf ysnByPassHeat Then
                strReturn = ds.Tables(0).Rows(0).Item("OName")
            Else
                If ds.Tables(0).Rows(0).Item("ysnHeat") = 0 Then
                    strReturn = "NOHEAT"
                Else
                    If ds.Tables(0).Rows(0).Item("ysnConcussion") = 0 Then
                        strReturn = "NOCONCUSSION"
                    Else
                        strReturn = ds.Tables(0).Rows(0).Item("OName")
                    End If
                End If
            End If
        End If

        Return strReturn
    End Function

    Shared Function IsWhiteHatFootball(ByVal intOfficialID As Long) As String
        Dim strReturn As String = "FAILED (23)"
        Dim strSQL As String

        strSQL = "SELECT strFirstName + ' ' + strLastName FROM prodOfficials WHERE ([ysnCurrentFootball] = -1) And ([ysnWhiteHat] = -1) And (intOSSAAID = " & intOfficialID & ")"

        Try
            strReturn = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            strReturn = "OK"
        Catch
            strReturn = "FAILED (24)"
        End Try

        Return strReturn
    End Function

    Shared Function IsWhiteHatCrewTestFootball(ByVal intOfficialID As Long) As String
        Dim strReturn As String = "FAILED (25)"
        Dim strSQL As String

        strSQL = "SELECT strFirstName + ' ' + strLastName FROM prodOfficials WHERE ([ysnCurrentFootball] = -1) And ([ysnWhiteHat] = -1) And (intOSSAAID = " & intOfficialID & ")"

        Try
            strReturn = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            strReturn = "OK"
        Catch
            strReturn = "FAILED (26)"
        End Try

        Return strReturn
    End Function

    Shared Function GetInvalidOfficialMessage() As String
        Return "INVALID Official"
    End Function

    Shared Function GetInvalidOfficialNameMessage() As String
        Return "INVALID OSSAAID#"
    End Function

    Shared Function GetNoHeatMessage() As String
        Return "NO HEAT CERT ON FILE"
    End Function

    Shared Function GetNoConcussionMessage() As String
        Return "NO CONCUSSION ON FILE"
    End Function

    Public Function ParseString(ByVal strIn As Object) As String
        Dim strTemp As String = ""

        Try
            strTemp = strIn
            strTemp = strTemp.Replace("'", "")
            strTemp = strTemp.Replace("""", "")
            strTemp = strTemp.Replace("DELETE", "")
            strTemp = strTemp.Replace("SELECT ", "")
            strTemp = strTemp.Replace("INSERT INTO ", "")
        Catch

        End Try

        Return strTemp
    End Function
End Class
