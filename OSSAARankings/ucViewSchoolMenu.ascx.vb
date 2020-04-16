Partial Class ucViewSchoolMenu
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadMenuItems()
    End Sub

    Public Sub LoadMenuItems()

        Dim ds As DataSet
        Dim x As Integer

        ' Load Rosters...
        WebExplorerBarRosters.Groups.Add("Rosters")
        ds = clsRosters.LoadRostersList(Session("gSchoolID"))
        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                Dim objItem As New Infragistics.Web.UI.NavigationControls.ExplorerBarItem
                objItem.Text = ds.Tables(0).Rows(x).Item("GenderSport1") & " (" & ds.Tables(0).Rows(x).Item("strClass") & ")"
                objItem.NavigateUrl = "?sel=sros&sc=" & Session("gSchoolID") & "&t=" & ds.Tables(0).Rows(x).Item("teamID")
                WebExplorerBarRosters.Groups(0).Items.Add(objItem)
            Next
        End If

        ' Load Schedules...
        WebExplorerBarSchedules.Groups.Add("Schedules")
        ds = clsSchedules.LoadSchedulesList(Session("gSchoolID"))

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                Dim objItem As New Infragistics.Web.UI.NavigationControls.ExplorerBarItem
                objItem.Text = ds.Tables(0).Rows(x).Item("GenderSport1") & " (" & ds.Tables(0).Rows(x).Item("strClass") & ")"
                objItem.NavigateUrl = "?sel=ssch&sc=" & Session("gSchoolID") & "&t=" & ds.Tables(0).Rows(x).Item("teamID")
                WebExplorerBarSchedules.Groups(0).Items.Add(objItem)
            Next
        End If


    End Sub

End Class