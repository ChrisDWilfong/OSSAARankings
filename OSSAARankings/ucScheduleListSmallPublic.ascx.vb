Public Class ucScheduleListSmallPublic
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
            Session("gShowRanking") = objTeam.getShowRanking

            If objTeam.getSportGenderDisplay = "Wrestling" And objTeam.getClass1 <> "" Then
                lblTeamInfo.Text = objTeam.getSchoolDisplay & " " & objTeam.getSportGenderDisplay & " (" & objTeam.getClass & ") (" & objTeam.getClass1 & " - Dual) : " & objTeam.getWL
            Else
                lblTeamInfo.Text = objTeam.getSchoolDisplay & " " & objTeam.getSportGenderDisplay & " (" & objTeam.getClass & ") : " & objTeam.getWL
            End If

            If objTeam.getCurrentRank > 0 Then
                If Session("gShowRanking") = 0 Then
                    lblTeamInfo.Text = lblTeamInfo.Text
                Else
                    lblTeamInfo.Text = lblTeamInfo.Text & " #" & objTeam.getCurrentRank
                End If
            End If

            ' Add the coach... 1/11/2018...
            If objTeam.getHeadCoach = "" Then
            Else
                lblTeamInfo.Text = lblTeamInfo.Text & "<br>Head Coach : " & objTeam.getHeadCoach
            End If

            lblPlayoffs.Text = objTeam.getPlayoffSchedule

            ' Get Teams Schedule...
            strSQL = clsSchedules.GetScheduleTeamSQL(intTeamID)
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            ds = clsSchedules.ChangeDatasetSmall(ds, Session("showHL"), objTeam.getSportGenderDisplay)

            GridView1.DataSource = ds
            GridView1.DataBind()
        End If

        If Session("printOnly") = 1 Then
            hlPrint.Visible = False
        Else
            hlPrint.Visible = True
            hlPrint.NavigateUrl = "\mem\PrintScheduleSmall.aspx?sel=ts&t=" & intTeamID
        End If

        Session("printOnly") = 0
    End Sub

End Class