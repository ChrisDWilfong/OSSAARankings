Public Class HomeColumn3Db
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strResult As String = ""
        strResult = clsWebBuilder.BuildPage("OSSAA.COM", "HomeColumn3", "97%")
        strResult = strResult.Replace("Arial", "Lato")
        Session("homeColumn3") = strResult
    End Sub

End Class