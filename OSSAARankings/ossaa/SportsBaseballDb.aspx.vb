Public Class SportsBaseballDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("sportsBaseballContent") = clsWebBuilder.BuildPage("OSSAA.COM", "Baseball", "100%")

    End Sub



End Class