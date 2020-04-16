Public Class SportsSoccerDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = "OSSAA Soccer"
        Session("sportsSoccerContent") = clsWebBuilder.BuildPage("OSSAA.COM", "Soccer", "100%")
    End Sub

End Class