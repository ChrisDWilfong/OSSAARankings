Public Class SportsFootballDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Football"
        Session("sportsFootballContent") = clsWebBuilder.BuildPage("OSSAA.COM", "Football", "100%")

    End Sub



End Class