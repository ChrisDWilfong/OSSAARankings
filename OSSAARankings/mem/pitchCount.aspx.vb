Public Class pitchCount
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblHeader.Text = "20" & clsFunctions.GetCurrentYear & " SPRING BASEBALL PITCH COUNT - OSSAARankings.com"
        If Not IsPostBack Then
            Session("pitchCountTotals") = "None"
            Session("pitchCountDetails") = "None"
        End If
    End Sub

    Public Function GetPitchCountInfoDetails(teamID As Long) As String
        Dim strPC As String = ""
        Dim strSQL As String = ""
        Dim strKey As String = ""
        Dim x As Integer
        Dim ds As DataSet
        Dim strScore As String = ""
        Dim strOpponent As String = ""

        strSQL = "SELECT * FROM viewPitchCount WHERE teamID = " & teamID & " ORDER BY gameDate DESC, scheduleID, intPitchCount DESC"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                With ds.Tables(0).Rows(x)
                    ' Get the TeamKey..
                    If ds.Tables(0).Rows(x).Item("strOpponent") Is System.DBNull.Value Then
                        strOpponent = .Item("OtherTeam")
                    Else
                        strOpponent = .Item("strOpponent")
                    End If
                    If strOpponent & .Item("gameDate") & .Item("scheduleID") <> strKey Then
                        strScore = " " & .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & .Item("WL")
                        If ds.Tables(0).Rows(x).Item("strOpponent") Is System.DBNull.Value Then
                            strPC = strPC & "<strong>" & FormatDateTime(ds.Tables(0).Rows(x).Item("gameDate"), DateFormat.ShortDate) & " vs " & ds.Tables(0).Rows(x).Item("OtherTeam") & "</strong>" & strScore & "<br>"
                        Else
                            strPC = strPC & "<strong>" & FormatDateTime(ds.Tables(0).Rows(x).Item("gameDate"), DateFormat.ShortDate) & " vs " & ds.Tables(0).Rows(x).Item("strOpponent") & "</strong>" & strScore & "<br>"
                        End If
                        If ds.Tables(0).Rows(x).Item("strOpponent") Is System.DBNull.Value Then
                            strKey = .Item("OtherTeam") & .Item("gameDate") & .Item("scheduleID")
                        Else
                            strKey = .Item("strOpponent") & .Item("gameDate") & .Item("scheduleID")
                        End If
                    End If
                    strPC = strPC & "<style='font-size:small'> - " & .Item("FullName") & "  (" & .Item("intPitchCount") & ")" & "</style><br>"
                End With
            Next
        End If

        Return strPC
    End Function

    Public Function GetPitchCountInfoTotals(teamID As Long) As String
        Dim strPC As String = ""
        Dim strSQL As String = ""
        Dim x As Integer
        Dim ds As DataSet

        strSQL = "SELECT * FROM viewPitchCountSUM WHERE teamID = " & teamID & " ORDER BY totalPitches DESC"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                With ds.Tables(0).Rows(x)
                    strPC = strPC & .Item("FullName") & " - " & .Item("totalPitches") & " (" & .Item("totalGames") & ")" & "<br>"
                End With
            Next
        End If

        Return strPC
    End Function

    Private Sub cboTeams_DataBound(sender As Object, e As System.EventArgs) Handles cboTeams.DataBound
        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem1.Value = 0
        objItem1.Text = "Select..."
        cboTeams.Items.Insert(0, objItem1)
    End Sub

    Private Sub cboTeams_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeams.SelectedIndexChanged
        Session("pitchCountTotals") = GetPitchCountInfoTotals(sender.SelectedValue)
        Session("pitchCountDetails") = GetPitchCountInfoDetails(sender.SelectedValue)
    End Sub
End Class