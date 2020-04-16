Public Class PrintRankings
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("sel") = Request.QueryString("sel")

        Dim objControlRight As UserControl
        Dim strControlName As String = ""

        Select Case Session("sel")
            Case "rankings", "tr"
                If Session("gGender") = "5" Or Session("gGender") = "5d" Then
                    strControlName = "ucViewRankingAll5.ascx"
                ElseIf Session("gGender") = "5d8" Then
                    strControlName = "ucViewRankingAll58.ascx"
                Else
                    strControlName = "ucViewRankingAll.ascx"
                End If
        End Select
        objControlRight = CType(LoadControl(strControlName), UserControl)
        objControlRight.Session.Add("gGender", Session("gGender"))
        objControlRight.Session.Add("gSport", Session("gSport"))
        objControlRight.Session.Add("sel", Session("sel"))
        objControlRight.Session.Add("gSportGenderKey", Session("gSportGenderKey"))
        objControlRight.Session.Add("gTeamID", Session("gTeamID"))
        objControlRight.Session.Add("printOnly", 1)
        PlaceHolderRightPane.Controls.Add(objControlRight)

    End Sub

End Class