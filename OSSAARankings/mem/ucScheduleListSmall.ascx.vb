Public Class ucScheduleListSmall
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intTeamID As Integer = 0

        Dim strSQL As String
        Dim ds As DataSet

        Try
            intTeamID = CInt(Request.QueryString("t"))
        Catch
            intTeamID = 0
        End Try

        If intTeamID = 0 Then

        Else
            ' Get Team Info...
            Dim objTeam As New clsTeam(intTeamID)
            Session("memgShowRanking") = objTeam.getShowRanking
            lblPlayoffs.Text = objTeam.getPlayoffSchedule
            lblTeamInfo.Text = objTeam.getSchoolDisplay & " " & objTeam.getSportGenderDisplay & " (" & objTeam.getClass & ") : " & objTeam.getWL
            If objTeam.getCurrentRank > 0 Then
                If Session("memgShowRanking") = 0 Then
                    lblTeamInfo.Text = lblTeamInfo.Text
                Else
                    lblTeamInfo.Text = lblTeamInfo.Text & " #" & objTeam.getCurrentRank
                End If
            End If

                ' Get Teams Schedule...
            strSQL = clsSchedules.GetScheduleTeamSQL(intTeamID)
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            ds = clsSchedules.ChangeDatasetSmall(ds, False, Session("memgSportID"))

            GridView1.DataSource = ds
            GridView1.DataBind()
        End If

        If Session("memprintOnly") = 1 Then
            hlPrint.Visible = False
        Else
            hlPrint.Visible = True
            hlPrint.NavigateUrl = "PrintScheduleSmall.aspx?sel=ts&t=" & intTeamID
        End If

        Session("memprintOnly") = 0
    End Sub

End Class