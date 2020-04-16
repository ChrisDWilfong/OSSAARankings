Public Class SportsBasketballDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("sportsBasketballContent") = clsWebBuilder.BuildPage("OSSAA.COM", "Basketball", "100%")

    End Sub



End Class