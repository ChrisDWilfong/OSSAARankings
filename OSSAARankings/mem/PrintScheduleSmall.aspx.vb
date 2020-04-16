Public Class PrintScheduleSmall
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intTeamID As Integer = 0
        Dim strSelect As String = ""

        strSelect = Request.QueryString("sel")
        intTeamID = Request.QueryString("t")

        Dim objControlRight As UserControl
        Dim strControlName As String = ""
        strControlName = "ucScheduleListSmall.ascx"

        objControlRight = CType(LoadControl(strControlName), UserControl)
        objControlRight.Session.Add("memsel", strSelect)
        objControlRight.Session.Add("memprintOnly", 1)
        PlaceHolderRightPane.Controls.Add(objControlRight)

    End Sub

End Class