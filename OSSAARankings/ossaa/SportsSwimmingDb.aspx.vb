Public Class SportsSwimmingDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Swimming"
        Session("sportsSwimmingContent") = clsWebBuilder.BuildPage("OSSAA.COM", "Swimming", "100%")

    End Sub



End Class