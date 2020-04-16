Imports OSSAARankings.SqlHelper

Public Class clsSchedule
    Public scheduleID As Long
    Public oTeamID As Long
    Public opposingTeamName As String
    Public scoreMy As Integer
    Public scoreThem As Integer
    Public otherTeam As String
    Public tournament As String
    Public location As String
    Public gamedate As String
    Public timeHour As String
    Public timeMin As String
    Public timeAMPM As String
    Public gameTime As String
    Public scheduleSport As String
    Public opponentOnSchedule As String
    Public gameStatus As String
    Public gResults As String
    Public teamID As Long
    Public gameType As String
    Public scheduleIDxref As Long
    Public scheduleIDxrefG As Long

    Public pitcherID1 As Long
    Public pitcherID2 As Long
    Public pitcherID3 As Long
    Public pitcherID4 As Long
    Public pitcherID5 As Long
    Public pitcherID6 As Long
    Public pitcherID7 As Long

    Public pitchCount1 As Integer
    Public pitchCount2 As Integer
    Public pitchCount3 As Integer
    Public pitchCount4 As Integer
    Public pitchCount5 As Integer
    Public pitchCount6 As Integer
    Public pitchCount7 As Integer

    Public intGame As Integer

    Public Sub New(ByVal scheduleID As Long)
        'Public Sub GetScheduleInfo(ByVal strSport As String, ByVal scheduleID As Integer)
        Dim strSQL As String
        Dim ds As DataSet
        Dim strTime As String
        Dim strSportID As String

        If scheduleID = 0 Then
            ' Skip it...
        Else

            strSQL = "SELECT * FROM tblSchedules WHERE scheduleID = " & scheduleID
            ds = ExecuteDataset(SQLConnection, CommandType.Text, strSQL)

            With ds.Tables(0).Rows(0)

                scheduleID = .Item("scheduleID")
                strSportID = .Item("sportID")
                intGame = .Item("intGame")

                Try
                    oTeamID = .Item("oTeamID")
                Catch ex As Exception
                    oTeamID = 0
                End Try

                Try
                    teamID = .Item("teamID")
                Catch
                    teamID = 0
                End Try

                scoreMy = .Item("TotalScore")
                scoreThem = .Item("oTotalScore")

                Try
                    ' 11/21/2017 changed...
                    'gameStatus = clsSchedules.FilterGameStatus(.Item("gStatus"), strSportID)
                    gameStatus = .Item("gStatus")
                Catch
                    gameStatus = "Final"
                End Try

                If .Item("strResults") Is System.DBNull.Value Then
                    gResults = ""
                Else
                    gResults = .Item("strResults")
                End If

                opposingTeamName = ""
                If .Item("OtherTeam") Is System.DBNull.Value Then
                    otherTeam = ""
                Else
                    otherTeam = .Item("OtherTeam")
                    opposingTeamName = otherTeam
                End If

                If opposingTeamName = "" Then
                    opposingTeamName = clsTeams.GetTeamNameFromTeamID(oTeamID)
                End If

                If .Item("tournament") Is System.DBNull.Value Then
                    tournament = ""
                Else
                    tournament = .Item("tournament")
                End If

                ' Calc Opponent...
                If tournament = "" Then
                    opponentOnSchedule = opposingTeamName
                Else
                    opponentOnSchedule = opposingTeamName & " @ " & tournament
                End If

                If .Item("location") Is System.DBNull.Value Then
                    location = ""
                Else
                    location = .Item("location")
                End If

                If .Item("gamedate") Is System.DBNull.Value Then
                    gamedate = ""
                Else
                    gamedate = .Item("gamedate")
                End If

                Try
                    scheduleIDxref = .Item("scheduleIDxref")
                Catch
                    scheduleIDxref = 0
                End Try
                Try
                    scheduleIDxrefG = .Item("scheduleIDxrefG")
                Catch
                    scheduleIDxrefG = 0
                End Try

                ' Game Time...
                If .Item("gametime") Is System.DBNull.Value Then
                    gameTime = ""
                Else
                    gameTime = .Item("gametime")
                End If

                If .Item("strType") Is System.DBNull.Value Then
                    gameType = ""
                Else
                    gameType = .Item("strType")
                End If

                If gameTime <> "" And gameTime <> "TBA" Then
                    Dim objArray As Array
                    objArray = gameTime.Split(":")
                    timeHour = objArray(0)
                    Try
                        strTime = objArray(1)
                    Catch
                        strTime = "5:00 PM"
                    End Try
                    If InStr(gameTime, "AM") > 0 Then
                        timeAMPM = "AM"
                        timeMin = strTime.Replace(" AM", "")
                        timeMin = strTime.Replace(" am", "")
                        ' CDW added 11/12/2018...
                        timeMin = strTime.Replace("AM", "")
                        timeMin = strTime.Replace("am", "")
                    Else
                        timeAMPM = "PM"
                        timeMin = strTime.Replace(" PM", "")
                        timeMin = strTime.Replace(" pm", "")
                        ' CDW added 11/12/2018...
                        timeMin = strTime.Replace("PM", "")
                        timeMin = strTime.Replace("pm", "")
                    End If
                End If

                pitcherID1 = .Item("intPitcherID1")
                pitcherID2 = .Item("intPitcherID2")
                pitcherID3 = .Item("intPitcherID3")
                pitcherID4 = .Item("intPitcherID4")
                pitcherID5 = .Item("intPitcherID5")
                pitcherID6 = .Item("intPitcherID6")
                pitcherID7 = .Item("intPitcherID7")

                pitchCount1 = .Item("intPitchCount1")
                pitchCount2 = .Item("intPitchCount2")
                pitchCount3 = .Item("intPitchCount3")
                pitchCount4 = .Item("intPitchCount4")
                pitchCount5 = .Item("intPitchCount5")
                pitchCount6 = .Item("intPitchCount6")
                pitchCount7 = .Item("intPitchCount7")

            End With
        End If

    End Sub


End Class
