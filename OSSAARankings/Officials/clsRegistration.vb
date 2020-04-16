Public Class clsRegistration

    Shared Function GetSportFromAbb(strAbb As String) As String
        Dim strSport As String = ""

        Select Case strAbb
            Case "BA"
                strSport = "BASEBALL"
            Case "BK"
                strSport = "BASKETBALL"
            Case "FB"
                strSport = "FOOTBALL"
            Case "FP"
                strSport = "FAST PITCH"
            Case "SP"
                strSport = "SLOW PITCH"
            Case "SC"
                strSport = "SOCCER"
            Case "TK"
                strSport = "TRACK"
            Case "VB"
                strSport = "VOLLEYBALL"
            Case "WR"
                strSport = "WRESTLING"
        End Select
        Return strSport
    End Function

    ' CDW removed 5/29/2019...
    'Shared Function GetRegistrationURL(strDoRegistration As String, strRegistrationSport As String) As String
    '    ' Based on the selection of the Official, get the appropriate URL for them to go to...
    '    Dim strURL As String = ""

    '    Select Case strDoRegistration
    '        Case "NEW-MEMBER"
    '            Select Case strRegistrationSport
    '                Case "BA"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Baseball-Registration-NEW-MEMBER"
    '                Case "BK"
    '                    strURL = "https://www1.arbitersports.com/front/106940/registration/2018-19-Basketball-Registration-NEW-MEMBER"
    '                Case "FB"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Football-Registration-NEW-MEMBER"
    '                Case "FP"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Fast-Pitch-Registration-NEW-MEMBER"
    '                Case "SP"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Slow-Pitch-Registration-NEW-MEMBER"
    '                Case "SC"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Soccer-Registration-NEW-MEMBER"
    '                Case "TK"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Track-Registration-NEW-MEMBER"
    '                Case "VB"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Volleyball-Registration-NEW-MEMBER"
    '                Case "WR"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Wrestling-Registration-NEW-MEMBER"
    '                Case Else
    '                    strURL = "Registration1.aspx"
    '            End Select
    '        Case "OUT-OF-STATE"
    '            Select Case strRegistrationSport
    '                Case "BA"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Baseball-Registration-OUT-OF-STATE"
    '                Case "BK"
    '                    strURL = "https://www1.arbitersports.com/front/106940/registration/2018-19-Basketball-Registration-OUT-OF-STATE"
    '                Case "FB"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Football-Registration-OUT-OF-STATE"
    '                Case "FP"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Fast-Pitch-Registration-OUT-OF-STATE"
    '                Case "SP"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Slow-Pitch-Registration-OUT-OF-STATE"
    '                Case "SC"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Soccer-Registration-OUT-OF-STATE"
    '                Case "TK"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Track-Registration-OUT-OF-STATE"
    '                Case "VB"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Volleyball-Registration-OUT-OF-STATE"
    '                Case "WR"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Wrestling-Registration-OUT-OF-STATE"
    '                Case Else
    '                    strURL = "Registration1.aspx"
    '            End Select
    '        Case "RETURNING-MEMBER"
    '            Select Case strRegistrationSport
    '                Case "BA"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Baseball-Registration-RETURNING-MEMBER"
    '                Case "BK"
    '                    strURL = "https://www1.arbitersports.com/front/106940/registration/2018-19-Basketball-Registration-RETURNING-MEMBER"
    '                Case "FB"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Football-Registration-RETURNING-MEMBER"
    '                Case "FP"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Fast-Pitch-Registration-RETURNING-MEMBER"
    '                Case "SP"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Slow-Pitch-Registration-RETURNING-MEMBER"
    '                Case "SC"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Soccer-Registration-RETURNING-MEMBER"
    '                Case "TK"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Track-Registration-RETURNING-MEMBER"
    '                Case "VB"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Volleyball-Registration-RETURNING-MEMBER"
    '                Case "WR"
    '                    strURL = "http://www1.arbitersports.com/front/106940/Registration/2018-19-Wrestling-Registration-RETURNING-MEMBER"
    '                Case Else
    '                    strURL = "Registration1.aspx"
    '            End Select
    '        Case Else
    '            strURL = "INVALID"
    '    End Select

    '    Return strURL
    'End Function

End Class
