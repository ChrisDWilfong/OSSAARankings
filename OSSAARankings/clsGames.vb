Public Class clsGames

    Shared Function SwapWL(strWLIn As String) As String
        Dim strWLOut As String = ""
        If strWLIn Is Nothing Then
        Else
            strWLIn = strWLIn.Trim
            Select Case strWLIn
                Case "W"
                    strWLOut = "L"
                Case "L"
                    strWLOut = "W"
                Case "T"
                    strWLOut = "T"
                Case Else
                    strWLOut = strWLIn
            End Select
        End If
        Return strWLOut
    End Function
    Shared Function SwapLocation(strLocationIn As String) As String
        Dim strLocationOut As String = ""
        If strLocationIn Is Nothing Then
            strLocationOut = strLocationIn
        Else
            Select Case strLocationIn
                Case "Home"
                    strLocationOut = "Away"
                Case "Away"
                    strLocationOut = "Home"
                Case "Scrimmage (H)"
                    strLocationOut = "Scrimmage (A)"
                Case "Scrimmage (A)"
                    strLocationOut = "Scrimmage (H)"
                Case Else
                    strLocationOut = strLocationIn
            End Select
        End If
        Return strLocationOut
    End Function


End Class
