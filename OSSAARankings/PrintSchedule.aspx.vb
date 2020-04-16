Public Class PrintSchedule1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("sel") = Request.QueryString("sel")
        Session("gTeamID") = Request.QueryString("t")

        Dim objControlRight As UserControl
        Dim objControlHeader As UserControl
        Dim strControlName As String = ""

        Select Case Session("sel")
            Case "teamschedule", "ts"
                strControlName = "ucViewTeamSchedule.ascx"
                objControlHeader = CType(LoadControl("ucViewTeamHeader.ascx"), UserControl)
                PlaceHolderRightPane.Controls.Add(objControlHeader)
            Case "vs" ' View schedule...
                strControlName = "ucViewSchedule.ascx"
            Case Else
                ' Do nothing...
        End Select

        objControlRight = CType(LoadControl(strControlName), UserControl)
        objControlRight.Session.Add("gScoreboardClass", Session("gScoreboardClass"))
        objControlRight.Session.Add("gScoreboardDate", Session("gScoreboardDate"))
        objControlRight.Session.Add("gGender", Session("gGender"))
        objControlRight.Session.Add("gSport", Session("gSport"))
        objControlRight.Session.Add("sel", Session("sel"))
        objControlRight.Session.Add("gSportGenderKey", Session("gSportGenderKey"))
        objControlRight.Session.Add("gTeamID", Session("gTeamID"))
        objControlRight.Session.Add("printOnly", 1)
        PlaceHolderRightPane.Controls.Add(objControlRight)

    End Sub

End Class