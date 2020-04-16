Public Class clsRoster
    Public gTeamID As Long
    Public gFirstName As String
    Public gLastName As String
    Public gPosition As String
    Public gHeight As String
    Public gWeight As String
    Public gGrade As String
    Public gJersey As String
    Public gStarter As Boolean
    Public gPitcher As Boolean
    Public gStats As String
    Public gPicture As String

    Public Sub New(ByVal intRosterID As Long)
        Dim strSQL As String
        Dim ds As DataSet
        Dim ysnFind As Boolean

        strSQL = "SELECT * FROM tblRosters WHERE rosterID = " & intRosterID
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
            ysnFind = False
        ElseIf ds.Tables.Count = 0 Then
            ysnFind = False
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            ysnFind = False
        Else
            ysnFind = True
        End If

        If ysnFind Then
            With ds.Tables(0).Rows(0)
                gTeamID = .Item("teamID")
                gFirstName = .Item("FirstName")
                gLastName = .Item("LastName")
                Try
                    gPosition = .Item("Pos")
                Catch
                    gPosition = ""
                End Try
                Try
                    gHeight = .Item("Height")
                Catch
                    gHeight = ""
                End Try
                Try
                    gWeight = .Item("Weight")
                Catch
                    gWeight = ""
                End Try
                Try
                    gGrade = .Item("Grade")
                Catch
                    gGrade = ""
                End Try
                Try
                    gJersey = .Item("Jersey")
                Catch
                    gJersey = ""
                End Try
                Try
                    If .Item("ysnPitcher") Then
                        gPitcher = True
                    Else
                        gPitcher = False
                    End If
                Catch
                    gPitcher = False
                End Try
                Try
                    If .Item("ysnStarter") Then
                        gStarter = True
                    Else
                        gStarter = False
                    End If
                Catch
                    gStarter = False
                End Try
                Try
                    gPicture = .Item("strPicture")
                Catch
                    gPicture = ""
                End Try
                Try
                    gStats = .Item("strStats")
                Catch
                    gStats = ""
                End Try
            End With
        Else
            gTeamID = 0
            gFirstName = ""
            gLastName = ""
            gPosition = ""
            gHeight = ""
            gWeight = ""
            gGrade = ""
            gJersey = ""
            gStats = ""
            gPicture = ""
        End If

    End Sub

End Class
