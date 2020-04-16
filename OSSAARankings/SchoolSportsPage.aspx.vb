Public Class SchoolSportsPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("gSchool") = Request.QueryString("sc")
        Session("gTeamID") = Request.QueryString("t")
        Session("sel") = Request.QueryString("sel")

        Dim objControlRight As UserControl
        Dim objControlHeader As UserControl
        Dim strControlName As String = ""

        Select Case Session("sel")
            Case "ts"
                strControlName = "ucViewTeamSchedule.ascx"
                objControlHeader = CType(LoadControl("ucViewSchoolHeader.ascx"), UserControl)
                PlaceHolderRightPane.Controls.Add(objControlHeader)
        End Select

        objControlRight = CType(LoadControl(strControlName), UserControl)
        objControlRight.Session.Add("gGender", Session("gGender"))
        objControlRight.Session.Add("gSport", Session("gSport"))
        objControlRight.Session.Add("sel", Session("sel"))
        objControlRight.Session.Add("gSportGenderKey", Session("gSportGenderKey"))
        objControlRight.Session.Add("gTeamID", Session("gTeamID"))

        PlaceHolderRightPane.Controls.Add(objControlRight)
    End Sub

    Public Sub LoadMenuItems()
        Dim objGroupBar As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
        Dim ds As DataSet
        Dim x As Integer

        WebExplorerBarSchedules.Groups.Add("Schedules")
        ds = clsSchool.LoadSchedulesList(Session("gSchoolID"))

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                objGroupBar.Text = ds.Tables(0).Rows(x).Item("GenderSport1")
                objGroupBar.NavigateUrl = ""
            Next
        End If


    End Sub

End Class