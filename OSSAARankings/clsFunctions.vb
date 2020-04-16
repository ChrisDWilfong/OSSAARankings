Public Class clsFunctions

    Shared Function StripFeet(strValueIn As String) As String
        ' Added 8/22/2017...
        Dim strResult As String = ""

        Try
            strResult = strValueIn
            strResult = strResult.Replace(" ft", "")
            strResult = strResult.Replace(" feet", "")
            strResult = strResult.Replace("ft", "")
            strResult = strResult.Replace("feet", "")
            strResult = strResult.Replace(" FT", "")
            strResult = strResult.Replace(" FEET", "")
            strResult = strResult.Replace("FT", "")
            strResult = strResult.Replace("FEET", "")
            strResult = strResult.Replace(" Ft", "")
            strResult = strResult.Replace(" Feet", "")
            strResult = strResult.Replace("Ft", "")
            strResult = strResult.Replace("Feet", "")
            strResult = strResult.Replace("'", "")
        Catch ex As Exception
            strResult = strValueIn
        End Try
        Return strResult
    End Function
    Shared Function GetDayOfTheWeekString(intDayOfTheWeek As Integer) As String
        Select Case intDayOfTheWeek
            Case 2
                Return "Monday"
            Case 3
                Return "Tuesday"
            Case 4
                Return "Wednesday"
            Case 5
                Return "Thursday"
            Case 6
                Return "Friday"
            Case 7
                Return "Saturday"
            Case 1
                Return "Sunday"
            Case Else
                Return ""
        End Select
    End Function
    Shared Function GetClassFromADForBasketball(schoolID As Long) As String
        ' MOVED from OSSAAWebsite on 3/8/2016...
        Dim strSQL As String = ""
        Dim strClass As String = ""

        strSQL = "SELECT sportID FROM allCoachesDetail WHERE intYear = " & GetCurrentYear() & " AND sportID Like 'BasketballGirls%' AND schoolID = " & schoolID
        Try
            strClass = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Catch
        End Try

        If strClass = "" Then
        Else
            strClass = strClass.Replace("BasketballGirls", "")
            strClass = strClass.Replace("BasketballBoys", "")
        End If

        Return strClass
    End Function

    Shared Function GetIneligibleReason(strEmail As String, strSportKey As String) As String
        ' MOVED from OSSAAWebsite on 3/8/2016...
        Dim strResult As String = ""
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT * FROM prodOfficials WHERE strEmail = '" & strEmail & "'"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
            strResult = "Official is not REGISTERED."
        ElseIf ds.Tables.Count = 0 Then
            strResult = "Official is not REGISTERED."
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            strResult = "Official is not REGISTERED."
        Else
            With ds.Tables(0).Rows(0)
                If .Item("ysnConcussion") = 0 Then
                    strResult = strResult & " - No Concussion Information on File"
                End If
                If .Item("ysnHeat") = 0 Then
                    strResult = strResult & " - No Heat Information on File"
                End If
                Select Case strSportKey
                    Case "Baseball"
                        If .Item("ysnMeeting14") = 0 And .Item("ysnMeeting8") = 0 Then
                            strResult = strResult & " - No Rules Meeting on File"
                        End If
                        If .Item("intTestBaseball") < 75 Then
                            strResult = strResult & " - Test Score is < 75"
                        End If
                    Case "SoftballSP"
                        If .Item("intTestSoftballSP") < 75 Then
                            strResult = strResult & " - Test Score is < 75"
                        End If
                    Case "SoftballFP"
                        If .IsNull("intTestSoftball") < 75 Then
                            strResult = strResult & " - Test Score is < 75"
                        End If
                    Case Else
                End Select

            End With
        End If

        If strResult = "" Then
        Else
            strResult = strResult & ". Please email Sheree Riddell (sriddell@ossaa.com) or call 405.840.1116"
        End If

        GetIneligibleReason = strResult
    End Function


    Shared Function GetTodaysDate() As String

        If ConfigurationManager.AppSettings("TodaysDate") = "Today" Then
            Return Format(Now, "MM/dd/yyyy")
        Else
            Return ConfigurationManager.AppSettings("TodaysDate")
        End If

    End Function

    Shared Function StringValidate(ByVal sIn As String) As String
        Dim sOut As String
        Dim badChars As New ArrayList

        Try
            sIn = RTrim(sIn)
        Catch
        End Try
        sIn = sIn.Replace("'", "")
        sOut = sIn
        badChars.Add("select")
        badChars.Add("drop table")
        badChars.Add(";")
        badChars.Add("--")
        badChars.Add("insert")
        badChars.Add("delete")
        badChars.Add("xp_")
        badChars.Add("sp_")
        badChars.Add("www")
        badChars.Add("http://")
        badChars.Add("<script>")
        badChars.Add("declare")
        badChars.Add("update")
        badChars.Add("@@")
        badChars.Add(".js ")
        badChars.Add(Chr(34))

        For i = 0 To badChars.Count - 1
            sOut = Replace(sOut, badChars(i), "")
            sOut = Replace(sOut, UCase(badChars(i)), "")
        Next
        Return sOut
    End Function


    Shared Function StringValidateSQL(ByVal sIn As String) As String
        Dim sOut As String
        Dim badChars As New ArrayList

        sOut = sIn
        badChars.Add("select")
        badChars.Add("drop table")
        badChars.Add(";")
        badChars.Add("--")
        badChars.Add("insert")
        badChars.Add("delete")
        badChars.Add("xp_")
        badChars.Add("sp_")
        badChars.Add("www")
        badChars.Add("http://")
        badChars.Add("<script>")
        badChars.Add("declare")
        badChars.Add("upcate")
        badChars.Add("@@")

        For i = 0 To badChars.Count - 1
            sOut = Replace(sOut, badChars(i), "")
            sOut = Replace(sOut, UCase(badChars(i)), "")
        Next

        Return sOut
    End Function

    Shared Function GetCurrentYearDisplay(strSportDisplay As String, intYear As Integer) As String
        Dim strYear As String = ""

        Dim strYearOne As String = "20" & (intYear - 1)
        Dim strYearTwo As String = "20" & intYear
        Dim strYearBoth As String = "20" & (intYear - 1) & "-" & intYear

        Select Case strSportDisplay
            Case "Academic"
                strYear = strYearBoth
            Case "Baseball"
                strYear = strYearTwo
            Case "Baseball Fall", "Baseball (Fall)"
                strYear = strYearOne
            Case "Basketball", "Boys Basketball", "Girls Basketball", "Basketball (Boys)", "Basketball (Girls)"
                strYear = strYearBoth
            Case "Cheerleading"
                strYear = strYearOne
            Case "Cross Country", "Boys Cross Country", "Girls Cross Country", "Cross Country (Boys)", "Cross Country (Girls)"
                strYear = strYearOne
            Case "Football"
                strYear = strYearOne
            Case "Fast Pitch Softball", "Fast Pitch"
                strYear = strYearOne
            Case "Golf", "Boys Golf", "Girls Golf", "Golf (Boys)", "Golf (Girls)"
                strYear = strYearTwo
            Case "Soccer", "Boys Soccer", "Girls Soccer", "Soccer (Boys)", "Soccer (Girls)"
                strYear = strYearTwo
            Case "Slow Pitch Softball", "Slow Pitch"
                strYear = strYearTwo
            Case "Swimming", "Boys Swimming", "Girls Swimming", "Swimming (Boys)", "Swimming (Girls)"
                strYear = strYearBoth
            Case "Tennis", "Boys Tennis", "Girls Tennis", "Tennis (Boys)", "Tennis (Girls)"
                strYear = strYearTwo
            Case "Track", "Boys Track", "Girls Track", "Track (Boys)", "Track (Girls)"
                strYear = strYearTwo
            Case "Volleyball"
                strYear = strYearOne
            Case "Wrestling"
                strYear = strYearBoth
            Case "Wrestling Dual", "Wrestling (Dual)"
                strYear = strYearBoth
        End Select
        ' '' ''End If

        Return strYear
    End Function

    Shared Function GetCurrentYear() As Integer
        Return System.Configuration.ConfigurationManager.AppSettings("CurrentYear")
    End Function

    Shared Function GetDisplaySport(strSportGenderKey As String) As String
        Dim strResult As String = ""
        Try
            strResult = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT TOP 1 GenderSport1 FROM tblSports WHERE SportGenderKey = '" & strSportGenderKey & "'")
        Catch
            strResult = ""
        End Try
        Return strResult

    End Function
    Shared ReadOnly Property ParseSchool(ByVal strSchoolIn As String) As String
        Get
            Dim strResult As String
            strResult = Replace(strSchoolIn, " High School", "")
            strResult = Replace(strResult, " School", "")
            Return strResult
        End Get
    End Property

End Class
