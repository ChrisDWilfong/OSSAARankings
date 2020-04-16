Public Class ucRankingsOthers
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If cboSelectSchool.Items.Count < 5 Then
            LoadDropDowns()
        End If
    End Sub

    Public Sub LoadDropDowns()
        Dim ds As DataSet
        Dim dsW As DataSet
        Dim sid As String

        ' Load Weeks for this sport/class...
        sid = Session("memgSportID")
        If Session("event") = "RankingsOthers1" Then
            If sid.Contains("Wrestling") Then sid = sid.Replace("Wrestling", "WrestlingDual")
        Else
        End If
        dsW = clsRankings.GetRankingsSchedule(sid, clsFunctions.GetCurrentYear, False)
        cboSelectWeek.DataSource = dsW
        cboSelectWeek.DataBind()

        ' Load Schools for this class...
        If Session("memdsClassTeamsOther") Is Nothing Then
            ds = clsTeams.GetSportTeamsForClass(sid, clsFunctions.GetCurrentYear, 0, Session("event"), Session("memgPlayoffsRegionals"))
            Session("memdsClassTeamsOther") = ds
        ElseIf Session("memdsClassTeamsOther").tables(0).rows.count = 0 Then
            ds = clsTeams.GetSportTeamsForClass(sid, clsFunctions.GetCurrentYear, 0, Session("event"), Session("memgPlayoffsRegionals"))
            Session("memdsClassTeamsOther") = ds
        Else
            ds = Session("memdsClassTeamsOther")
        End If

        cboSelectSchool.DataSource = ds
        cboSelectSchool.DataBind()
        cboSelectSchool.Items.Insert(0, "Select...")

        Try
            If Not Session("memarrTeamID")(0) Is Nothing Then
                cboSelectSchool.SelectedValue = Session("memarrTeamID")(0)
            End If
        Catch
        End Try

    End Sub

    Private Sub cmdGo_Click(sender As Object, e As System.EventArgs) Handles cmdGo.Click
        Response.Redirect("Home.aspx?sel=RankingsOthers")
    End Sub

    Private Sub cboSelectSchool_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboSelectSchool.SelectedIndexChanged
        If cboSelectWeek.SelectedItem.ToString = "Select..." Then
            lblMessage.Text = "Please selecte a Week."
        End If
    End Sub
End Class