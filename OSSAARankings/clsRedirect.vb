Public Class clsRedirect

    Shared Function Schedule(ByVal strSport As String, ByVal cmd As String) As String
        If strSport = "Wrestling" Then
            If cmd = "" Then
                Return "MemberScheduleWrestling.aspx"     ' Redirect so we can clear the cmd and refresh the changes...
            Else
                Return "MemberScheduleWrestling.aspx?cmd=" & cmd
            End If
        ElseIf strSport = "Swimming" Then
            If cmd = "" Then
                Return "MemberScheduleSwimming.aspx"
            Else
                Return "MemberScheduleSwimming.aspx?cmd=" & cmd
            End If
        ElseIf strSport = "Soccer" Then
            If cmd = "" Then
                Return "MemberScheduleSoccer.aspx"
            Else
                Return "MemberScheduleSoccer.aspx?cmd=" & cmd
            End If
        Else
            Return "MemberSchedule.aspx"
        End If
    End Function

    Shared Function MemberIndex(ByVal strSport As String) As String
        If strSport = "Swimming" Then
            Return "MemberIndex2.aspx"
        ElseIf strSport = "Wrestling" Then
            Return "MemberIndex3.aspx"
        Else
            Return "MemberIndex.aspx"
        End If
    End Function
End Class
