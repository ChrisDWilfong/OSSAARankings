Public Class SportsVolleyballDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Volleyball"
        Session("sportsVolleyballContent") = clsWebBuilder.BuildPage("OSSAA.COM", "Volleyball", "100%")

    End Sub



End Class