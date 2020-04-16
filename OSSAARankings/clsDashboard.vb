Public Class clsDashboard
    ' MOVED FROM OSSAAWebsite on 3/8/2016...

    Public gId As Long
    Public gType As String
    Public gSportKey As String
    Public gYear As String
    Public gYearInt As Integer
    Public gTournaments As Integer
    Public gStartDate As DateTime
    Public gStartTime As String
    Public gEndDate As DateTime
    Public gEndTime As String
    Public gReadyDate As DateTime
    Public gReadyTime As String
    Public gLoginPage As String
    Public gHomePage As String
    Public gHomePageSub As String
    Public gHomePageURL As String
    Public gViewEligible As String
    Public gTableSource As String
    Public gTableSourceDetail As String
    Public gTourneyName1 As String
    Public gLoginHeader As String
    Public gTourney101 As String
    Public gTourney102 As String
    Public gTourney103 As String
    Public gTourney104 As String
    Public gTourney105 As String
    Public gTourney106 As String
    Public gTourney107 As String
    Public gTourney108 As String
    Public gTourney109 As String
    Public gTourney110 As String
    Public gTourneyName2 As String
    Public gTourney201 As String
    Public gTourney202 As String
    Public gTourney203 As String
    Public gTourney204 As String
    Public gTourney205 As String
    Public gTourney206 As String
    Public gTourney207 As String
    Public gTourney208 As String
    Public gTourney209 As String
    Public gTourney210 As String
    Public gTourneyName3 As String
    Public gTourney301 As String
    Public gTourney302 As String
    Public gTourney303 As String
    Public gTourney304 As String
    Public gTourney305 As String
    Public gTourney306 As String
    Public gTourney307 As String
    Public gTourney308 As String
    Public gTourney309 As String
    Public gTourney310 As String
    Public gTourneyName4 As String
    Public gTourney401 As String
    Public gTourney402 As String
    Public gTourney403 As String
    Public gTourney404 As String
    Public gTourney405 As String
    Public gTourney406 As String
    Public gTourney407 As String
    Public gTourney408 As String
    Public gTourney409 As String
    Public gTourney410 As String
    Public gTourneyName5 As String
    Public gTourney501 As String
    Public gTourney502 As String
    Public gTourney503 As String
    Public gTourney504 As String
    Public gTourney505 As String
    Public gTourney506 As String
    Public gTourney507 As String
    Public gTourney508 As String
    Public gTourney509 As String
    Public gTourney510 As String

    Public Sub New(ByVal strType As String, strSportKey As String, intYear As Integer)
        On Error Resume Next
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT * FROM tblDashboardOfficials WHERE strType = '" & strType & "' AND strSportKey = '" & strSportKey & "' AND intYear = " & intYear
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            gType = strType
            gSportKey = strSportKey

            With ds.Tables(0).Rows(0)
                gId = .Item("Id")
                gYear = .Item("strYear")
                gYearInt = intYear
                gTournaments = .Item("intTournaments")
                gStartDate = .Item("dtmStartDate")
                If gStartDate.TimeOfDay.Hours > 12 Then
                    gStartTime = gStartDate.TimeOfDay.Hours - 12 & " PM"
                Else
                    gStartTime = gStartDate.TimeOfDay.Hours & " AM"
                End If
                gEndDate = .Item("dtmEndDate")
                If gEndDate.TimeOfDay.Hours > 12 Then
                    gEndTime = gEndDate.TimeOfDay.Hours - 12 & " PM"
                Else
                    gEndTime = gEndDate.TimeOfDay.Hours & " AM"
                End If
                gReadyDate = .Item("dtmReadyDate")
                If gReadyDate.TimeOfDay.Hours > 12 Then
                    gReadyTime = gReadyDate.TimeOfDay.Hours - 12 & " PM"
                Else
                    gReadyTime = gReadyDate.TimeOfDay.Hours & " AM"
                End If
                gLoginPage = .Item("strLoginPage")
                gHomePage = .Item("strHomePage")
                If .Item("strHomePageSub") Is System.DBNull.Value Then
                    gHomePageSub = ""
                Else
                    gHomePageSub = .Item("strHomePageSub")
                End If
                gHomePageURL = .Item("strHomePageURL")
                gViewEligible = .Item("strViewEligible")
                gTableSource = .Item("strTableSource")
                gTableSourceDetail = .Item("strTableSourceDetail")
                gLoginHeader = .Item("strLoginHeader")
                gTourneyName1 = .Item("strTourneyName1")
                gTourneyName2 = .Item("strTourneyName2")
                gTourneyName3 = .Item("strTourneyName3")
                gTourneyName4 = .Item("strTourneyName4")
                gTourneyName5 = .Item("strTourneyName5")
                gTourney101 = .Item("strTourney101")
                gTourney102 = .Item("strTourney102")
                gTourney103 = .Item("strTourney103")
                gTourney104 = .Item("strTourney104")
                gTourney105 = .Item("strTourney105")
                gTourney106 = .Item("strTourney106")
                gTourney107 = .Item("strTourney107")
                gTourney108 = .Item("strTourney108")
                gTourney109 = .Item("strTourney109")
                gTourney110 = .Item("strTourney110")
                gTourney201 = .Item("strTourney201")
                gTourney202 = .Item("strTourney202")
                gTourney203 = .Item("strTourney203")
                gTourney204 = .Item("strTourney204")
                gTourney205 = .Item("strTourney205")
                gTourney206 = .Item("strTourney206")
                gTourney207 = .Item("strTourney207")
                gTourney208 = .Item("strTourney208")
                gTourney209 = .Item("strTourney209")
                gTourney210 = .Item("strTourney210")
                gTourney301 = .Item("strTourney301")
                gTourney302 = .Item("strTourney302")
                gTourney303 = .Item("strTourney303")
                gTourney304 = .Item("strTourney304")
                gTourney305 = .Item("strTourney305")
                gTourney306 = .Item("strTourney306")
                gTourney307 = .Item("strTourney307")
                gTourney308 = .Item("strTourney308")
                gTourney309 = .Item("strTourney309")
                gTourney310 = .Item("strTourney310")
                gTourney401 = .Item("strTourney401")
                gTourney402 = .Item("strTourney402")
                gTourney403 = .Item("strTourney403")
                gTourney404 = .Item("strTourney404")
                gTourney405 = .Item("strTourney405")
                gTourney406 = .Item("strTourney406")
                gTourney407 = .Item("strTourney407")
                gTourney408 = .Item("strTourney408")
                gTourney409 = .Item("strTourney409")
                gTourney410 = .Item("strTourney410")
                gTourney501 = .Item("strTourney501")
                gTourney502 = .Item("strTourney502")
                gTourney503 = .Item("strTourney503")
                gTourney504 = .Item("strTourney504")
                gTourney505 = .Item("strTourney505")
                gTourney506 = .Item("strTourney506")
                gTourney507 = .Item("strTourney507")
                gTourney508 = .Item("strTourney508")
                gTourney509 = .Item("strTourney509")
                gTourney510 = .Item("strTourney510")
            End With

        End If

    End Sub

End Class
