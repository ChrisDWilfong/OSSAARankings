Public Class ucScheduleList
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strSQL As String
        Dim ds As DataSet

        If Session("memgTeamID") Is Nothing Then

        ElseIf Session("memgTeamID") = 0 Then
            ' Added 10/1/2014...
        Else
            strSQL = clsSchedules.GetScheduleTeamSQL(Session("memgTeamID"))
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            ds = clsSchedules.ChangeDatasetSchedule(ds, False, Session("memgResults"), Session("memgShowRanking"), True)

            If Session("memgSport") = "Volleyball" Then
                Me.GridView1.Columns(5).Visible = True
            Else
                Me.GridView1.Columns(5).Visible = False
            End If
            GridView1.DataSource = ds
            GridView1.DataBind()
        End If

        lblPlayoffs.Text = Session("memgPlayoffSchedule")

    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        ' Turn off the Hyperlink for non-OSSAA teams...
        Dim objHL As New HyperLink
        Dim strHL As String = ""

        Try
            objHL = e.Row.Cells(2).Controls(0)
            strHL = objHL.Text
        Catch
        End Try

        If strHL = "" Then
            Try
                objHL = e.Row.Cells(3).Controls(0)
                strHL = objHL.Text
            Catch

            End Try
        End If

        If Session("memprintOnly") = 1 Then
            objHL.Enabled = False
        ElseIf strHL.Contains("t=0") Then
            objHL.Enabled = False
        ElseIf strHL.Contains("t=") Then
            objHL.Enabled = True
        Else
            objHL.Enabled = False
        End If

    End Sub
End Class