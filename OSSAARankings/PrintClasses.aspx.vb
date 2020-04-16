Public Class PrintClasses
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("sel") = Request.QueryString("sel")

        Dim objControlRight As UserControl
        Dim strControlName As String = ""

        Select Case Session("sel")
            Case "vc" ' View classes...
                strControlName = "ucViewScheduleClass.ascx"
            Case Else
                ' Do nothing...
        End Select

        'Try
        objControlRight = CType(LoadControl(strControlName), UserControl)
        objControlRight.Session.Add("gScoreboardClass", Session("gScoreboardClass"))
        objControlRight.Session.Add("gGender", Session("gGender"))
        objControlRight.Session.Add("gSport", Session("gSport"))
        objControlRight.Session.Add("sel", Session("sel"))
        objControlRight.Session.Add("gSportGenderKey", Session("gSportGenderKey"))
        objControlRight.Session.Add("printOnly", 1)
        PlaceHolderRightPane.Controls.Add(objControlRight)
        'Catch
        'End Try

    End Sub

End Class