Public Class mSportsGolfDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Page.Title = "OSSAA Golf"
        Session("sportsGolfContent") = clsWebBuilder.BuildPage("OSSAA.COM", "Golf", "100%")

    End Sub



End Class