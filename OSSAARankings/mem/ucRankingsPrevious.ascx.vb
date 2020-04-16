Public Class ucRankingsPrevious
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If cboSelectSchool.Items.Count < 5 Then
            LoadDropDowns()
        End If
    End Sub

    Public Sub LoadDropDowns()
        Dim ds As DataSet
        Dim dsW As DataSet

        ' Load Weeks for this sport/class...
        dsW = clsRankings.GetRankingsSchedule(Session("memgSportID"), clsFunctions.GetCurrentYear, False)
        cboSelectWeek.DataSource = dsW
        cboSelectWeek.DataBind()

        ' Load Schools for this class...
        If Session("memdsClassTeamsOther") Is Nothing Then
            ds = clsTeams.GetSportTeamsForClass(Session("memgSportGenderKey"), Session("memgClass"), clsFunctions.GetCurrentYear, 0)
            Session("memdsClassTeamsOther") = ds
        ElseIf Session("memdsClassTeamsOther").tables(0).rows.count = 0 Then
            ds = clsTeams.GetSportTeamsForClass(Session("memgSportGenderKey"), Session("memgClass"), clsFunctions.GetCurrentYear, 0)
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